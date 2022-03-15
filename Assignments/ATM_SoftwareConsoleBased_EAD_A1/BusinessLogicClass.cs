using System;
using System.Collections.Generic;
using System.Text;
using Login_BO;
using DataAccessLayer;
using CustomerBusinessObject;

namespace BusinessLogicLayer
{
    public class BusinessLogicClass
    {
        public bool isAnySpecialCharacter(string s)
        {
            bool specialChar = false;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] >= 'A' && s[i] <= 'Z' ||               //valid
                    (s[i] >= 'a' && s[i] <= 'z') ||
                    (s[i] >= '0' && s[i] <= '9'))          
                {
                    specialChar = false;
                }
                else                     //invalid
                {
                    return true;
                }
            }
            return specialChar;

}
        public bool isUserNameUnique(string userName)
        {
            DataAccessClass DL = new DataAccessClass();
            bool isUnique = DL.isUserNameUnique(userName);
            return isUnique;
        }
        public bool isPinUnique(string pin)
        {
            DataAccessClass DL = new DataAccessClass();
            bool isUnique = DL.isPinUnique(pin);
            return isUnique;
        }
        public bool checkUserStatus(loginBO l)
        {
            DataAccessClass DL = new DataAccessClass();
            bool isActive = DL.checkUserStatus(l);
            return isActive;
        }
        public void disableAccountFromUsername(loginBO LBO)
        {
            DataAccessClass DL = new DataAccessClass();
            DL.disableAccountFromUsername(LBO);
        }
        public void disableAccountFromPassword(loginBO LBO)
        {
            DataAccessClass DL = new DataAccessClass();
            DL.disableAccountFromPassword(LBO);
        }
        public string Encrypt(string password)
        {
            List<char> encrytedList = new List<char>();
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 'A' && password[i] <= 'Z')
                    encrytedList.Add((char)(90 - (25 - (int)(90 - password[i]))));
                else if (password[i] >= 'a' && password[i] <= 'z')
                {
                    encrytedList.Add((char)(122 - (25 - (int)(122 - password[i]))));
                }
                else if (password[i] >= '0' && password[i] <= '9')
                {
                    encrytedList.Add(((char)((57 - password[i]) + 48)));
                }
            }


            string encryptedString = string.Join("", encrytedList.ToArray());
            return encryptedString;
        }
        public string Decrypt(string password)
        {
            List<char> decryptedList = new List<char>();
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 'A' && password[i] <= 'Z')
                    decryptedList.Add((char)(65 + (int)(90 - password[i])));
                else if (password[i] >= 'a' && password[i] <= 'z')
                {
                    decryptedList.Add((char)(97 + (int)(122 - password[i])));
                }
                else if (password[i] >= '0' && password[i] <= '9')
                {
                    decryptedList.Add(((char)((57 - password[i]) + 48)));
                }
            }


            string encryptedString = string.Join("", decryptedList.ToArray());
            return encryptedString;
        }
        public bool verifyCustomerUsername(loginBO LBO)
        {
            DataAccessClass dl = new DataAccessClass();
            if (dl.verifyCustomerUsername(LBO))
            {
                return true;
            }
            return false;
        }
        public bool verifyCustomerPassword(loginBO LBO)
        {
            DataAccessClass dl = new DataAccessClass();
            if (dl.verifyCustomerPassword(LBO))
            {
                return true;
            }
            return false;
        }
        public bool verifyAdminLogin(loginBO LBO)
        {
            DataAccessClass dl = new DataAccessClass();
            if (dl.isAdminThere(LBO))
            {
                return true;
            }
            return false;
        }
        public bool verifyCustomerLogin(loginBO LBO)
        {
            DataAccessClass dl = new DataAccessClass();
            if (dl.isCustomerThere(LBO))
            {
                return true;
            }
            return false;
        }
        public void createAnAccount(customer_BusinessObjectClass BL)
        {
            DataAccessClass DL = new DataAccessClass();
            DL.createAnAccount(BL);
        }
        public bool doesAccountExists(customer_BusinessObjectClass BL)
        {
            DataAccessClass DL = new DataAccessClass();
            bool isThere = DL.isAccountExists(BL);
            if (isThere)
                return true;
            else
                return false;
        }
        public void deleteAccount(customer_BusinessObjectClass BL)
        {
            DataAccessClass DL = new DataAccessClass();
            DL.deleteAccount(BL);
        }
        public void updateAccount(customer_BusinessObjectClass BL)
        {

            DataAccessClass DL = new DataAccessClass();
            customer_BusinessObjectClass prevBO = DL.prevRecord(BL);
            if (BL.Login == "")
            {
                BL.Login = prevBO.Login;
            }
            if (BL.PinCode == "")
            {
                BL.PinCode = prevBO.PinCode;
            }
            if (BL.HolderName == "")
            {
                BL.HolderName = prevBO.HolderName;
            }
            if (BL.Type == "")
            {
                BL.Type = prevBO.Type;
            }
            if (BL.Balance == "")
            {
                BL.Balance = prevBO.Balance;
            }
            if (BL.Status == "")
            {
                BL.Status = prevBO.Status;
            }
            DL.updateAccount(BL);
        }
        public List<customer_BusinessObjectClass> searchAccount(customer_BusinessObjectClass BO)
        {
            DataAccessClass DL = new DataAccessClass();
            List<customer_BusinessObjectClass> list = DL.searchAccount(BO);
            return list;

        }
        public List<customer_BusinessObjectClass> reportByAmount(int max, int min)
        {
            DataAccessClass DL = new DataAccessClass();
            List<customer_BusinessObjectClass> list = DL.reportByAmount(max, min);
            return list;
        }
        public List<object> reportByDate(string starting, string ending)
        {
            DataAccessClass DL = new DataAccessClass();
            List<object> myArr = DL.reportByDate(starting, ending);
            return myArr;
        }
        public bool isAmountInAccount(int amount, loginBO LBO)
        {
            DataAccessClass DL = new DataAccessClass();
            if (DL.isAmountEnough(amount, LBO))
                return true;
            return false;
        }
        public void withdrawAmount(int amount, loginBO LBO)
        {
            DataAccessClass DL = new DataAccessClass();
            DL.withdrawAmount(amount, LBO);
        }
        public object[] makeReceipt(loginBO LBO)
        {
            DataAccessClass DL = new DataAccessClass();
            object[] arr = DL.makeReceipt(LBO);
            return arr;
        }
        public int withdrawperDay(loginBO LBO)
        {
            DataAccessClass DL = new DataAccessClass();
            int total = DL.withdrawperDay(LBO);
            return total;
        }
        public int yourcurBalance(string login)
        {
            DataAccessClass dl = new DataAccessClass();
            int b = dl.yourcurBalance(login);
            return b;
        }
        public string userOfAccount(int account)
        {
            DataAccessClass dl = new DataAccessClass();
            string userName = dl.userOfAccount(account);
            return userName;
        }
        public string holderNameOfAccount(int account)
        {
            DataAccessClass dl = new DataAccessClass();
            string h = dl.holderNameOfAccount(account);
            return h;
        }
        public void transferAmount(loginBO LBO, int amount, int toAccount)
        {
            DataAccessClass DL = new DataAccessClass();
            DL.transferAmount(LBO, amount, toAccount);
        }
        public int accountFromUser(string username)
        {
            DataAccessClass dal = new DataAccessClass();
            int accountNum = dal.accountFromUser(username);
            return accountNum;
        }

        public void depositAmount(int amt,loginBO LBO)
        {
            DataAccessClass DL = new DataAccessClass();
            DL.depositAmount(amt, LBO);
        }
    }
}
