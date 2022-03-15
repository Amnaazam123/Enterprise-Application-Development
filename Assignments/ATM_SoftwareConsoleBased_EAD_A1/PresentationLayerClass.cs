using System;
using System.Collections.Generic;
using System.Text;
using Login_BO;
using BusinessLogicLayer;
using CustomerBusinessObject;
using System.Globalization;

namespace PresentationLayer
{
    public class presentaionLayerClass
    {
        static public customer_BusinessObjectClass inputValidity()
        {
            string login, pinCode, holderName, type, status, balance;
            BusinessLogicClass BL = new BusinessLogicClass();
            bool isPinUnique = false;
            bool isUsernameUnique = false;
            bool specialChar = false;
            do    //this loop works untill you get valid unique username for create an account
            {
                specialChar = false;
                isUsernameUnique = false;
                Console.Write("Enter Login: ");
                login = Console.ReadLine();

                if (BL.isAnySpecialCharacter(login))
                {

                    Console.WriteLine("Username can not contain any special character.\nTry again");
                    specialChar = true;
                }

                if (!specialChar)
                {
                    login = BL.Encrypt(login);
                    if (!BL.isUserNameUnique(login))
                    {
                        Console.WriteLine("Sorry! this UserName already exists.");
                        isUsernameUnique = false;
                    }
                    else
                    {
                        isUsernameUnique = true;
                        break;
                    }
                }
            } while (!isUsernameUnique);
            do    //this loop works untill you get valid unique pin for create an account
            {
                isPinUnique = false;
                specialChar = false;
                Console.Write("Enter pin-code: ");
                pinCode = Console.ReadLine();
                if (pinCode.Length != 5)
                {
                    Console.WriteLine("Pin must be 5-digit long.");
                    continue;
                }

                if (BL.isAnySpecialCharacter(pinCode))
                {
                    Console.WriteLine("Pin code can not have special characters.\nTry again");
                    specialChar = true;
                }

                if (!specialChar)
                {
                    pinCode = BL.Encrypt(pinCode);
                    if (!BL.isPinUnique(pinCode))
                    {
                        Console.WriteLine("Sorry this PinCode already exists.");
                        isPinUnique = false;
                    }
                    else
                    {
                        isPinUnique = true;
                        break;
                    }
                }


            } while (!isPinUnique);


            Console.Write("Enter Holder Name: ");
            holderName = Console.ReadLine();

            do       //this loop works untill you get type current or savings.
            {
                Console.Write("Type(Saving, Current) :");
                type = Console.ReadLine();
                if ((type.ToLower() != "saving" && type.ToLower() != "current"))
                    Console.WriteLine("Type must be saving or current.\n");

            } while ((type.ToLower() != "saving" && type.ToLower() != "current"));


            Console.Write("Enter Balance: ");
            balance = Console.ReadLine();
            int result = 0;
            bool validBalance = int.TryParse(balance, out result);
            if (!validBalance)
            {
                do       //this loop works untill you input valid balance
                {
                    Console.WriteLine("Invalid input!");
                    Console.Write("Enter Balance Again! : ");
                    balance = Console.ReadLine();
                    if (int.TryParse(balance, out result))
                        break;

                } while (true);
            }

            do             //this loop works untill you get status disable or current.
            {
                Console.Write("Enter Status: ");
                status = Console.ReadLine();
                if ((status.ToLower() == "active" || status.ToLower() == "disable"))
                    break;
                else
                    Console.WriteLine("status must be Active or Disable.\n");

            } while ((status.ToLower() != "active" || status.ToLower() != "disable"));

            customer_BusinessObjectClass CBS = new customer_BusinessObjectClass();

            CBS.PinCode = pinCode;
            CBS.Login = login;
            CBS.HolderName = holderName;
            CBS.Type = type;
            CBS.Balance = balance;
            CBS.Status = status;
            return CBS;
        } 
        static void login(string choice)
        {
            bool isAdminVerified = false;
            bool isCustomerVerified = false;
            bool isUserNameVerified = false;
            bool isPasswordVerified = false;
            int attempts = 0;

            //admin interface - Admin can do disable customer status but not be disable yourself.
            //Admin do not have attempts limit bound.

            if (choice == "1")  
            {
                do            //take credentials input untill admin is verified.
                {
                    BusinessLogicClass bl = new BusinessLogicClass();
                    Console.Write("Enter Login: ");
                    string userName = Console.ReadLine();
                    userName = bl.Encrypt(userName);        //userName encryption

                    Console.Write("Enter Password: ");
                    string pin = Console.ReadLine();
                    pin = bl.Encrypt(pin);                 //pin encryption
                    
                    //Making business object for Login attributes
                    loginBO l = new loginBO();
                    l.username = userName;
                    l.password = pin;

                    //checking for Admin login credentials
                    isAdminVerified = bl.verifyAdminLogin(l);

                    if (!isAdminVerified)
                    {
                        Console.WriteLine("\noops! Username or password Wrong.");
                        Console.WriteLine("Enter these both credentials again.\n");
                    }
                    else            //admin verified.
                    {
                        Console.WriteLine("\n----------------------You have Loged in successfully----------------------");
                        adminMenu();
                    }

                }
                while (!isAdminVerified);
            }
            //customer interface - Customer Account can be disabled after 3 incorrect attempts
            // NOTE :: if in third attempt, there is password AND userName (BOTH) wrong then his/her account will not be disabled otherwise disabled.
            if (choice == "2")           
            {
                do         //take credentials input untill attempts are finished or customer credentials are verified.
                {
                    BusinessLogicClass bl = new BusinessLogicClass();
                    Console.Write("Enter Login: ");
                    string userName = Console.ReadLine();
                    userName = bl.Encrypt(userName);
                    
                    Console.Write("Enter 5-digit PIN code: ");
                    string pin = Console.ReadLine();
                    pin = bl.Encrypt(pin);
                    
                    //making business object
                    loginBO l = new loginBO();
                    l.username = userName;
                    l.password = pin;

                    isCustomerVerified = bl.verifyCustomerLogin(l);
                    isUserNameVerified = bl.verifyCustomerUsername(l);
                    isPasswordVerified = bl.verifyCustomerPassword(l);

                    if (!isCustomerVerified)                 //wrong credentials
                    {
                        attempts++;
                        Console.WriteLine("\noops! Username or password Wrong.");
                        if(attempts!=3)
                            Console.WriteLine("Enter these both credentials again.\n");
                        if (attempts >= 3)  //if all attempts are lost
                        {
                            //if password or userName is correct? so that his/her account can be disabled 
                            if (isUserNameVerified || isPasswordVerified)     
                            {
                                //if username is correct but password wrong
                                if (isUserNameVerified)           
                                    bl.disableAccountFromUsername(l);

                                //if password is correct but username wrong
                                if (isPasswordVerified)            
                                    bl.disableAccountFromPassword(l);


                                Console.WriteLine("------------------------------");
                                Console.WriteLine("You have tried THREE Times!!!");
                                Console.WriteLine("------------------------------");
                                Console.WriteLine("Your Account disabled temporaliy by admin.\n");
                                return;
                            }
                            else            //both username and pin not verified in third attempt
                            {
                                Console.WriteLine("------------------------------");
                                Console.WriteLine("You have tried THREE Times!!!\n------------------------------\nBoth username and password wrong");
                                Console.WriteLine("SO, we are unable to disable your account.");
                                Console.WriteLine("We are going to launch this application again for you.");
                                return;
                            }
                        }
                    }
                    else     //correct credentails
                    {
                        //before loging customer check status either user is active or disable
                        bool isActive = bl.checkUserStatus(l);
                        if (isActive)
                        {
                            Console.WriteLine("\nLogin successfully");
                            customerMenu(l);
                        }
                        else
                        {
                            Console.WriteLine("\nYour account was disabled.\nAdmin did not yet updated your account to make it active.");
                            return;
                        }
                        
                    }

                }
                while (!isCustomerVerified);
            }
        }
        static void adminMenu()
        {
            string input;
            do
            {
                Console.WriteLine("==================== Admin Menu =====================\n");
                Console.WriteLine(
                    "1----Create New Account.\n" +
                    "2----Delete Existing Account.\n" +
                    "3----Update Account Information.\n" +
                    "4----Search for Account.\n" +
                    "5----View Reports\n" +
                    "6----Exit");

                Console.Write("\nEnter your choice:");
                input = Console.ReadLine();

                //create an account
                if (input == "1")              
                {
                    
                    /*before creating an account, admin must follow some rules.
                     * 1 - username and pin must be unique.
                     * 2 - pin must be 5 digits long.
                     * 3 - pin and username must not contain any special character.
                     */


                    customer_BusinessObjectClass CBS = inputValidity();
                    BusinessLogicClass BL = new BusinessLogicClass();
                    Console.WriteLine("------------------------ ACCOUNT CREATED -----------------------------\n");
                    BL.createAnAccount(CBS);


                }
                //delete an account
                else if (input == "2")
                {
                    BusinessLogicClass BL = new BusinessLogicClass();
                    customer_BusinessObjectClass CBS = new customer_BusinessObjectClass();

                    string accountToDel;
                    Console.Write("Enter the account number to which you want to delete: ");
                    accountToDel = Console.ReadLine();
                    int result = 0;
                    bool validInput = int.TryParse(accountToDel, out result);
                    if (!validInput)
                    {
                        do       //this loop works untill you input valid integer for account number
                        {
                            Console.WriteLine("Invalid input!");
                            Console.Write("Enter valid integer for account! : ");
                            accountToDel = Console.ReadLine();
                            if (int.TryParse(accountToDel, out result))
                                break;

                        } while (true);
                    }

                    int accToDel = int.Parse(accountToDel);
                    CBS.tempAcc = accToDel;
                    bool isThere = BL.doesAccountExists(CBS);          //is this integer any existing account number?
                    if (isThere)
                    {
                        int accNum;
                        Console.Write($"You wish to delete the account held by {BL.holderNameOfAccount(accToDel)}; ");
                        Console.Write("\nIf this information is correct please re - enter the account number:");
                        accNum = int.Parse(Console.ReadLine());
                        if (accNum == accToDel)
                        {
                            BL.deleteAccount(CBS);
                        }
                        else
                        {
                            do
                            {
                                Console.WriteLine("Invalid accountNum, Make sure to give account number same as above.");
                                Console.WriteLine("If it was mistake, You can exit by giving input -1.");
                                Console.Write("Enter account Number again: ");
                                accNum = int.Parse(Console.ReadLine());
                                if (accNum == -1)
                                {
                                    return;
                                }
                            } while (accNum != accToDel);
                            BL.deleteAccount(CBS);
                        }


                    }
                    else
                    {
                        Console.WriteLine("SORRY! Not any customer with this accountNum exists.");
                    }
                }
                //update an account
                else if (input == "3")
                {
                    string accountToUpdate;

                    Console.Write("Enter the Account Number: ");
                    accountToUpdate = Console.ReadLine();
                    int result = 0;
                    bool validInput = int.TryParse(accountToUpdate, out result);
                    if (!validInput)
                    {
                        do       //this loop works untill you input valid integer for account number
                        {
                            Console.WriteLine("Invalid input!");
                            Console.Write("Enter valid integer for account! : ");
                            accountToUpdate = Console.ReadLine();
                            if (int.TryParse(accountToUpdate, out result))
                                break;

                        } while (true);
                    }

                    int accToUpdate = int.Parse(accountToUpdate);

                    customer_BusinessObjectClass CBS = new customer_BusinessObjectClass();
                    CBS.tempAcc = accToUpdate;
                    BusinessLogicClass BL = new BusinessLogicClass();
                    if (BL.doesAccountExists(CBS))
                    {
                        CBS = inputValidity();
                        BL.updateAccount(CBS);
                    }
                    else
                    {
                        Console.WriteLine("Sorry No record found for this account Number");
                    }

                }
                //search an account
                else if (input == "4")
                {
                    string login, pinCode, holderName, type, status;
                    string balance;
                    Console.WriteLine("Enter those credentials on that base you want data searched.");
                    Console.Write("Enter Login: ");
                    login = Console.ReadLine();
                    

                    Console.Write("Enter pin-code: ");
                    pinCode = Console.ReadLine();

                    Console.Write("Enter Holder Name: ");
                    holderName = Console.ReadLine();

                    Console.Write("Type(Savings, Current) :");
                    type = Console.ReadLine();

                    Console.Write("Enter Balance: ");
                    balance = Console.ReadLine();

                    Console.Write("Enter Status: ");
                    status = Console.ReadLine();


                    BusinessLogicClass BL = new BusinessLogicClass();
                    customer_BusinessObjectClass CBS = new customer_BusinessObjectClass();
                    CBS.Login = BL.Encrypt(login);
                    CBS.PinCode = BL.Encrypt(pinCode);
                    CBS.HolderName = holderName;
                    CBS.Type = type;
                    CBS.Balance = balance;
                    CBS.Status = status;

                    List<customer_BusinessObjectClass> list = BL.searchAccount(CBS);
                    if (list.Count == 0)
                    {
                        Console.WriteLine("No record found");
                    }
                    else
                    {
                        Console.WriteLine("\n{0,10}{1,15}{2,20}{3,20}{4,16}{5,20}{6,20}", "Account-Number","Login","Pin-Code","HolderName","Type","Balance","Status");
                        foreach (customer_BusinessObjectClass CBO in list)
                        {
                            CBO.PinCode = BL.Encrypt(CBO.PinCode);
                            CBO.Login = BL.Encrypt(CBO.Login);
                            Console.WriteLine("\n{0,10}{1,15}{2,20}{3,20}{4,16}{5,20}{6,20}", CBO.Account, CBO.Login, CBO.PinCode, CBO.HolderName, CBO.Type, CBO.Balance, CBO.Status);
                        }
                    }
                }
                //View Reports
                else if (input == "5")
                {
                    Console.WriteLine("1---Accounts By Amount\n2---Accounts By Date");
                    int choice;
                    Console.Write("Your Choice : ");
                    choice = int.Parse(Console.ReadLine());
                    if (choice == 1)     //accounts by amount
                    {
                        string maxAmnt, minAmnt;
                        Console.Write("Enter Max amount : ");
                        maxAmnt = Console.ReadLine();
                        int result = 0;
                        bool validMaxAmnt = int.TryParse(maxAmnt, out result);
                        if (!validMaxAmnt)
                        {
                            do       //this loop works untill you input valid max amount
                            {
                                Console.WriteLine("Invalid input!");
                                Console.Write("Enter Max Amount Again! : ");
                                maxAmnt = Console.ReadLine();
                                if (int.TryParse(maxAmnt, out result))
                                    break;

                            } while (true);
                        }
                        int maxAmt = int.Parse(maxAmnt);



                        Console.Write("Enter Min amount : ");
                        minAmnt = Console.ReadLine();
                        result = 0;
                        bool validMinAmnt = int.TryParse(minAmnt, out result);
                        if (!validMinAmnt)
                        {
                            do       //this loop works untill you input valid min amount
                            {
                                Console.WriteLine("Invalid input!");
                                Console.Write("Enter Min Amount Again! : ");
                                minAmnt = Console.ReadLine();
                                if (int.TryParse(minAmnt, out result))
                                    break;

                            } while (true);
                        }

                        int minAmt = int.Parse(minAmnt);
                        BusinessLogicClass BL = new BusinessLogicClass();
                        List<customer_BusinessObjectClass> list = BL.reportByAmount(maxAmt, minAmt);
                        Console.WriteLine("==== SEARCH RESULTS ======");
                        if (list.Count == 0)
                        {
                            Console.WriteLine("SORRY! no record found");
                        }
                        else
                        {
                            Console.WriteLine("\n{0,10}{1,15}{2,20}{3,20}{4,16}{5,20}", "Account ID", "User ID", "HolderName", "Type", "Balance", "Status");
                            foreach (customer_BusinessObjectClass CBO in list)
                            {
                                CBO.PinCode = BL.Encrypt(CBO.PinCode);
                                CBO.Login = BL.Encrypt(CBO.Login);
                                Console.WriteLine("{0,10}{1,15}{2,20}{3,20}{4,16}{5,20}", CBO.Account,CBO.PinCode,CBO.HolderName,CBO.Type,CBO.Balance,CBO.Status);
                            }
                        }
                    }
                    else if (choice == 2)
                    {
                        string sdt, ldt;
                        Console.Write("Enter the starting date: ");
                        sdt = Console.ReadLine();
                        DateTime result;
                        bool validSDate = DateTime.TryParseExact(sdt, "dd/MM/yyyy",
                                    CultureInfo.InvariantCulture,
                                    DateTimeStyles.None,
                                    out result);
                        if (!validSDate)
                        {
                            do       //this loop works untill you input valid date
                            {
                                Console.WriteLine("Invalid input!");
                                Console.Write("Enter starting date in dd/MM/yyyy format! : ");
                                sdt = Console.ReadLine();
                                if (DateTime.TryParse(sdt, out result))
                                    break;

                            } while (true);
                        }
                       
                        Console.Write("Enter the ending date: ");
                        ldt = Console.ReadLine();
                        bool validEDate = DateTime.TryParseExact(ldt, "dd/MM/yyyy",
                                     CultureInfo.InvariantCulture,
                                     DateTimeStyles.None,
                                     out result);
                        if (!validEDate)
                        {
                            do       //this loop works untill you input valid date
                            {
                                Console.WriteLine("Invalid input!");
                                Console.Write("Enter ending date in dd/MM/yyyy format! : ");
                                ldt = Console.ReadLine();
                                if (DateTime.TryParse(ldt, out result))
                                    break;

                            } while (true);
                        }


                        BusinessLogicClass BL = new BusinessLogicClass();
                        List<object> list = BL.reportByDate(sdt, ldt);
                        Console.WriteLine("==== SEARCH RESULTS ======");
                        if (list.Count == 0)
                        {
                            Console.WriteLine("SORRY! no record found");
                        }
                        else
                        {
                            Console.WriteLine("\n{0,10}{1,15}{2,20}{3,20}{4,16}", "Transaction Type", "User ID", "HolderName", "Amount", "Date");

                            foreach (object[] CBO in list)
                            {

                                CBO[1] = BL.Decrypt((string)CBO[1]);
                                Console.WriteLine("{0,10}{1,20}{2,20}{3,20}{4,20}",CBO[0],CBO[1],CBO[2],CBO[3],CBO[4]);
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else if (input == "6")
                {
                    return;
                }
            } while (input!="6");


        }
        static void customerMenu(loginBO l)
        {
            BusinessLogicClass BL = new BusinessLogicClass();
            string input ="0";
            do
            {
                Console.WriteLine("==================== Customer Menu =====================\n");
                Console.WriteLine("1----Withdraw Cash\n" +
                    "2----Cash Transfer\n" +
                    "3----Deposit Cash\n" +
                    "4----Display Balance\n" +
                    "5----Exit");
                Console.WriteLine("Enter your choice:");
                input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("1--- Fast Cash\n2--- Normal Cash");
                    Console.WriteLine("Please select a mode of withdrawal:");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        Console.WriteLine("1----500\n2----1000\n3----2000\n4----5000\n5----10000\n6----15000\n7----20000\n");
                        Console.WriteLine("Select one of the denominations of money:");
                        string choice1;
                        choice1 = Console.ReadLine();
                        char c;
                        int withdrwanAmt = 0;
                        if (choice1 == "1")
                        {
                            Console.WriteLine("Are you sure you want to withdraw Rs.500 (Y/N)?");
                            withdrwanAmt = 500;
                        }
                        else if (choice1 == "2")
                        {
                            Console.WriteLine("Are you sure you want to withdraw Rs.1000 (Y/N)?");
                            withdrwanAmt = 1000;

                        }
                        else if (choice1 == "3")
                        {
                            Console.WriteLine("Are you sure you want to withdraw Rs.2000 (Y/N)?");
                            withdrwanAmt = 2000;
                        }
                        else if (choice1 == "4")
                        {
                            Console.WriteLine("Are you sure you want to withdraw Rs.5000 (Y/N)?");
                            withdrwanAmt = 5000;
                        }
                        else if (choice1 == "5")
                        {
                            Console.WriteLine("Are you sure you want to withdraw Rs.10000 (Y/N)?");
                            withdrwanAmt = 10000;
                        }
                        else if (choice1 == "6")
                        {
                            Console.WriteLine("Are you sure you want to withdraw Rs.15000 (Y/N)?");
                            withdrwanAmt = 15000;
                        }
                        else if (choice1 == "7")
                        {
                            Console.WriteLine("Are you sure you want to withdraw Rs.20000 (Y/N)?");
                            withdrwanAmt = 20000;
                        }

                        c = char.Parse(Console.ReadLine());
                        if (c == 'y' || c == 'Y')
                        {
                            if (BL.isAmountInAccount(withdrwanAmt, l))
                            {

                                //check how many amount in this day has been withdrawn.
                                int total = BL.withdrawperDay(l) + withdrwanAmt;

                                if (total > 20000)
                                {
                                    Console.WriteLine("Sorry! You can not withdraw amount more than 20000 per day.");

                                }
                                else
                                {
                                    BL.withdrawAmount(withdrwanAmt, l);
                                    Console.WriteLine("Cash Successfully Withdrawn!");
                                    Console.Write("Do you wish to print a receipt (Y/N)?");
                                    c = char.Parse(Console.ReadLine());
                                    if (c == 'y' || c == 'Y')
                                    {
                                        object[] arr = BL.makeReceipt(l);
                                        Console.WriteLine($"\nAccount #{arr[0]}");
                                        Console.WriteLine($"Date: {DateTime.Now.ToString("dd/MM/yyyy")}");
                                        Console.WriteLine($"Withdrawn: {withdrwanAmt}");
                                        Console.WriteLine($"Balance: {arr[1]}");
                                    }
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("You have not enough amount for withdrawl.");
                            }

                        }
                        else if (c == 'n' || c == 'N')
                        {
                            Console.WriteLine("Receipt denied.");
                        }

                    }
                    else if (choice == "2")
                    {
                        int amt;
                        Console.Write("Enter the withdrawal amount:");
                        amt = int.Parse(Console.ReadLine());
                        if (BL.isAmountInAccount(amt, l))
                        {
                                // check how many amount in this day has been withdrawn.
                                int total = BL.withdrawperDay(l) + amt;

                            if (total > 20000)
                            {
                                Console.WriteLine("Sorry! You can not withdraw amount more than 20000 per day.");

                            }
                            else
                            {
                                BL.withdrawAmount(amt, l);
                                Console.WriteLine("Cash Successfully Withdrawn!");
                                Console.Write("Do you wish to print a receipt (Y/N)?");
                                char c = char.Parse(Console.ReadLine());
                                if (c == 'y' || c == 'Y')
                                {
                                    object[] arr = BL.makeReceipt(l);
                                    Console.WriteLine($"\nAccount #{arr[0]}");
                                    Console.WriteLine($"Date: {DateTime.Now.ToString("dd/MM/yyyy")}");
                                    Console.WriteLine($"Withdrawn: {arr[3]}");
                                    Console.WriteLine($"Balance: {arr[1]}");
                                }
                                else if (c == 'n' || c == 'N')
                                {
                                    Console.WriteLine("Receipt denied.");
                                }
                            }
                            
                        }
                    }
                }
                else if (input == "2")
                {
                    //deposit cash
                    customer_BusinessObjectClass CBS = new customer_BusinessObjectClass();
                    int amount = 0;
                    bool isThere = false;
                    if (BL.yourcurBalance(l.username) < 500)
                    {
                        Console.WriteLine("You are not eligible to transfer any amount beacuse your balance is too low.");
                        return;
                    }
                    do
                    {
                        //is this amount available?
                        isThere = false;
                        Console.WriteLine("Enter amount in multiples of 500:");
                        amount = int.Parse(Console.ReadLine());
                        if (amount % 500 != 0)
                        {
                            Console.WriteLine("Amount must be multiple of 500.");
                        }
                        else
                        {
                            if(BL.isAmountInAccount(amount, l))
                            {
                                isThere = true;
                            }
                        }

                    } while (amount % 500 != 0 || !isThere);
                    

                    int accountNum1,accountNum2;
                    Console.WriteLine("Enter the account number to which you want to transfer: ");
                    accountNum1= int.Parse(Console.ReadLine());
                    CBS.tempAcc = accountNum1;
                    bool transaction = false;
                    bool issThere = BL.doesAccountExists(CBS);
                    if (issThere)
                    {
                        Console.Write($"You wish to deposit Rs. {amount} in account held by {BL.holderNameOfAccount(accountNum1)}; ");
                        Console.Write("If this information is correct please re - enter the account number:");
                        accountNum2 = int.Parse(Console.ReadLine());
                        if (accountNum2 == accountNum1)
                        {
                            BL.transferAmount(l,amount,accountNum1);
                            transaction = true;

                        }
                        else
                        {
                            do
                            {
                                Console.WriteLine("Invalid accountNum, Make sure to give account number same as above.");
                                Console.WriteLine("If it was mistake, You can exit by giving input -1.");
                                Console.Write("Enter account Number again: ");
                                accountNum2 = int.Parse(Console.ReadLine());
                                if (accountNum2 == -1)
                                {
                                    return;
                                }
                            } while (accountNum1 != accountNum2);
                           BL.transferAmount(l,amount,accountNum1);
                           transaction = true;
                        }
                        if (transaction)
                        {
                            Console.WriteLine("\nTransaction confirmed.");
                            Console.WriteLine("Do you wish to print a receipt (Y/N)?");
                            char c = char.Parse(Console.ReadLine());
                            if (c == 'y' || c == 'Y')
                            {
                                object[] arr = BL.makeReceipt(l);
                                Console.WriteLine($"\nAccount #{arr[0]}");
                                Console.WriteLine($"Date: {DateTime.Now.ToString("dd/MM/yyyy")}");
                                Console.WriteLine($"Amount transfered: {amount}");
                                Console.WriteLine($"Balance: {arr[1]}");
                            }
                            else if (c == 'n' || c == 'N')
                            {
                                Console.WriteLine("Receipt denied.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("SORRY! Not any customer with this accountNum exists.\n");
                    }
                }
                else if (input == "3")
                {
                    int amt;
                    Console.Write("Enter the deposited amount:");
                    amt = int.Parse(Console.ReadLine());
                     BL.depositAmount(amt, l);
                      Console.WriteLine("Cash Deposited Successfully");
                            Console.Write("Do you wish to print a receipt (Y/N)?");
                            char c = char.Parse(Console.ReadLine());
                     if (c == 'y' || c == 'Y')
                     {
                        object[] arr = BL.makeReceipt(l);
                        Console.WriteLine($"\nAccount #{arr[0]}");
                        Console.WriteLine($"Date: {DateTime.Now.ToString("dd/MM/yyyy")}");
                        Console.WriteLine($"Amount deposited: {amt}");
                        Console.WriteLine($"Balance: {arr[1]}");
                     }
                     else if (c == 'n' || c == 'N')
                     {
                        Console.WriteLine("Receipt denied.");
                     }

                }
                else if (input == "4")
                {
                    Console.WriteLine("======================== YOUR BALANCE ========================");
                    object[] arr = BL.makeReceipt(l);
                    Console.WriteLine($"\nAccount #{arr[0]}");
                    Console.WriteLine($"Date: {DateTime.Now.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"Balance: {arr[1]}");
                }
                else if (input == "5")
                {
                    return;
                }
            } while (input != "5");
           
        }
        public void _interface()
        { 
            string choice ="0";
            do
            {
                Console.WriteLine("\n\n\n=============== Welcome to your ATM service ===============\n\n");
                Console.WriteLine("1-------Admin");
                Console.WriteLine("2-------Customer");
                Console.WriteLine("3-------Exit");

                Console.Write("Your choice : ");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("\nOK! You are going to use this application as Admin.");
                    login(choice);
                }
                else if (choice == "2")
                {
                    Console.WriteLine("\nOK! You are going to use this application as Customer.");
                    login(choice);
                }
                else if (choice == "3")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

            } while (choice != "3");
           

           
        }
    }
}
