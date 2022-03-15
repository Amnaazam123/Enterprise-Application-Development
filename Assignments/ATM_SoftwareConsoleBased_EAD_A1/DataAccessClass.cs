using System;
using System.Collections.Generic;
using System.Text;
using Login_BO;
using Microsoft.Data.SqlClient;
using CustomerBusinessObject;


namespace DataAccessLayer
{
    public class DataAccessClass
    {
        string conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ATM_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public bool isPinUnique(string pin)
        {
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM customerTable WHERE Pin=@pin", conn);
            SqlParameter p = new SqlParameter("@pin", pin);
            cmd.Parameters.Add(p);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                conn.Close();
                return false;
            }
            else
            {
                conn.Close();
                return true;
            }

        }
        public bool isUserNameUnique(string userName)
        {
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM customerTable WHERE Login=@l", conn);
            SqlParameter p = new SqlParameter("@l", userName);
            cmd.Parameters.Add(p);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                conn.Close();
                return false;
            }
            else
            {
                conn.Close();
                return true;
            }
        }
        public bool checkUserStatus(loginBO LBO)
        {
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();


            SqlCommand cmd1 = new SqlCommand("SELECT Status From customerTable WHERE Login=@l AND Pin=@p", conn);
            SqlParameter p1 = new SqlParameter("@p", LBO.password);
            SqlParameter p2 = new SqlParameter("@l", LBO.username);

            cmd1.Parameters.Add(p1);
            cmd1.Parameters.Add(p2);
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            if ((string)dr[0] == "Active" || (string)dr[0] == "active" || (string)dr[0] == "ACTIVE")
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }


        }
        public void disableAccountFromUsername(loginBO LBO)
        {
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();


            SqlCommand cmd1 = new SqlCommand("UPDATE customerTable SET Status=@s WHERE Login=@l", conn);
            SqlParameter p1 = new SqlParameter("@s", "Disabled");
            SqlParameter p2 = new SqlParameter("@l", LBO.username);

            cmd1.Parameters.Add(p1);
            cmd1.Parameters.Add(p2);
            cmd1.ExecuteNonQuery();
            conn.Close();
        }
        public void disableAccountFromPassword(loginBO LBO)
        {
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();


            SqlCommand cmd1 = new SqlCommand("UPDATE customerTable SET Status=@s WHERE Pin=@p", conn);
            SqlParameter p1 = new SqlParameter("@s", "Disabled");
            SqlParameter p2 = new SqlParameter("@p", LBO.password);

            cmd1.Parameters.Add(p1);
            cmd1.Parameters.Add(p2);
            cmd1.ExecuteNonQuery();
            conn.Close();
        }
        public bool verifyCustomerUsername(loginBO LBO)
        {
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM customerTable WHERE Login=@n", conn);

            SqlParameter p = new SqlParameter("@n", LBO.username);
            cmd.Parameters.Add(p);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }
        public bool verifyCustomerPassword(loginBO LBO)
        {
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM customerTable WHERE Pin=@p", conn);

            SqlParameter p1 = new SqlParameter("@p", LBO.password);
            cmd.Parameters.Add(p1);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }
        public bool isAdminThere(loginBO LBO)
        {
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM adminTable WHERE UserName=@n AND Password=@p", conn);

            SqlParameter p = new SqlParameter("@n", LBO.username);
            SqlParameter p1 = new SqlParameter("@p", LBO.password);
            cmd.Parameters.Add(p);
            cmd.Parameters.Add(p1);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;

        }
        public bool isCustomerThere(loginBO LBO)
        {
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM customerTable WHERE Login=@n AND Pin=@p", conn);

            SqlParameter p = new SqlParameter("@n", LBO.username);
            SqlParameter p1 = new SqlParameter("@p", LBO.password);
            cmd.Parameters.Add(p);
            cmd.Parameters.Add(p1);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;

        }
        public void createAnAccount(customer_BusinessObjectClass CBO)
        {
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand($"INSERT INTO customerTable(Login,Pin,HolderName,Type,Balance,Status) VALUES (@l,@p,@h,@t,@b,@s)", conn);

            SqlParameter p1 = new SqlParameter("@l", CBO.Login);
            SqlParameter p2 = new SqlParameter("@p", CBO.PinCode);
            SqlParameter p3 = new SqlParameter("@b", CBO.Balance);
            SqlParameter p5 = new SqlParameter("@h", CBO.HolderName);
            SqlParameter p6 = new SqlParameter("@t", CBO.Type);
            SqlParameter p7 = new SqlParameter("@s", CBO.Status);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);
            cmd.Parameters.Add(p7);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM customerTable WHERE Login=@l", conn);

            SqlParameter pp = new SqlParameter("@l", CBO.Login);
            cmd1.Parameters.Add(pp);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Console.WriteLine($"Account Successfully Created – the account number assigned is: {dr[0]}");
            }
            conn.Close();

        }
        public bool isAccountExists(customer_BusinessObjectClass CBO)
        {
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM customerTable WHERE AccountNo=@accountnum", conn);

            SqlParameter p1 = new SqlParameter("@accountnum", CBO.tempAcc);
            cmd.Parameters.Add(p1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }
        public void deleteAccount(customer_BusinessObjectClass CBO)
        {
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE customerTable WHERE AccountNo=@accountnum", conn);

            SqlParameter p1 = new SqlParameter("@accountnum", CBO.tempAcc);
            cmd.Parameters.Add(p1);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Account deleted successfully.");
            conn.Close();
        }
        public customer_BusinessObjectClass prevRecord(customer_BusinessObjectClass CBO)
        {
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            SqlCommand cmd = new SqlCommand($"SELECT * FROM customerTable WHERE AccountNo=@accountnum ", conn);

            SqlParameter p = new SqlParameter("@accountnum", CBO.tempAcc);
            cmd.Parameters.Add(p);
            SqlDataReader dr = cmd.ExecuteReader();


            customer_BusinessObjectClass tempCBO = new customer_BusinessObjectClass();

            dr.Read();
            tempCBO.Login = (string)dr[1];
            tempCBO.PinCode = (string)dr[2];
            tempCBO.HolderName = (string)dr[3];
            tempCBO.Type = (string)dr[4];
            tempCBO.Balance = (string)dr[5];
            tempCBO.Status = (string)dr[6];


            conn.Close();
            return tempCBO;
        }
        public void updateAccount(customer_BusinessObjectClass CBO)
        {
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE customerTable SET Login = @l, Pin = @p, HolderName=@h,Type=@t,Balance=@b,Status=@s WHERE AccountNo=@accountnum", conn);
            SqlParameter p1 = new SqlParameter("@accountnum", CBO.tempAcc);
            SqlParameter p2 = new SqlParameter("@l", CBO.Login);
            SqlParameter p3 = new SqlParameter("@p", CBO.PinCode);
            SqlParameter p4 = new SqlParameter("@b", CBO.Balance);
            SqlParameter p5 = new SqlParameter("@h", CBO.HolderName);
            SqlParameter p6 = new SqlParameter("@t", CBO.Type);
            SqlParameter p7 = new SqlParameter("@s", CBO.Status);

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);
            cmd.Parameters.Add(p7);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Account updated successfully.");
            conn.Close();
        }
        public List<customer_BusinessObjectClass> searchAccount(customer_BusinessObjectClass CBO)
        {
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            int flag = 0;
            string query = "SELECT * FROM customerTable ";
            if (CBO.Login != "" && flag == 0)
            {
                query += "WHERE Login=@l";
                flag++;
            }
            else if (CBO.Login != "" && flag != 0)
            {
                query += "AND Login=@l";
                flag++;
            }
            if (CBO.PinCode != "" && flag == 0)
            {
                query += "WHERE Pin=@p";
                flag++;
            }
            else if (CBO.PinCode != "" && flag != 0)
            {
                query += " AND Pin=@p";
                flag++;
            }
            if (CBO.HolderName != "" && flag == 0)
            {
                query += "WHERE HolderName=@h";
                flag++;
            }
            else if (CBO.HolderName != "" && flag != 0)
            {
                query += " AND HolderName=@h";
                flag++;
            }
            if (CBO.Type != "" && flag == 0)
            {
                query += "WHERE Type=@t";
                flag++;
            }
            else if (CBO.Type != "" && flag != 0)
            {
                query += " AND Type=@t";
                flag++;
            }
            if (CBO.Balance != "" && flag == 0)
            {
                query += "WHERE Balance=@b";
                flag++;
            }
            else if (CBO.Balance != "" && flag != 0)
            {
                query += " AND Balance=@b";
                flag++;
            }
            if (CBO.Status != "" && flag == 0)
            {
                query += "WHERE Status=@s";
                flag++;
            }
            else if (CBO.Status != "" && flag != 0)
            {
                query += " AND Status=@s";
                flag++;
            }


            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter p2 = new SqlParameter("@l", CBO.Login);
            SqlParameter p3 = new SqlParameter("@p", CBO.PinCode);
            SqlParameter p4 = new SqlParameter("@b", CBO.Balance);
            SqlParameter p5 = new SqlParameter("@h", CBO.HolderName);
            SqlParameter p6 = new SqlParameter("@t", CBO.Type);
            SqlParameter p7 = new SqlParameter("@s", CBO.Status);

            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);
            cmd.Parameters.Add(p7);

            List<customer_BusinessObjectClass> list = new List<customer_BusinessObjectClass>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                customer_BusinessObjectClass tempCBO = new customer_BusinessObjectClass();
                tempCBO.Account = (int)dr[0];
                tempCBO.Login = (string)dr[1];
                tempCBO.PinCode = (string)dr[2];
                tempCBO.HolderName = (string)dr[3];
                tempCBO.Type = (string)dr[4];
                tempCBO.Balance = (string)dr[5];
                tempCBO.Status = (string)dr[6];
                list.Add(tempCBO);
            }

            conn.Close();
            return list;

        }
        public List<customer_BusinessObjectClass> reportByAmount(int max, int min)
        {
            List<customer_BusinessObjectClass> list = new List<customer_BusinessObjectClass>();
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM customerTable WHERE Balance <= @maxx AND Balance >= @minn", conn);

            SqlParameter p1 = new SqlParameter("@maxx", max);
            SqlParameter p2 = new SqlParameter("@minn", min);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                customer_BusinessObjectClass CBO = new customer_BusinessObjectClass();
                CBO.Account = (int)dr[0];
                CBO.Login = (string)dr[1];
                CBO.PinCode = (string)dr[2];
                CBO.HolderName = (string)dr[3];
                CBO.Type = (string)dr[4];
                CBO.Balance = (string)dr[5];
                CBO.Status = (string)dr[6];
                list.Add(CBO);

            }
            conn.Close();
            return list;

        }
        public List<object> reportByDate(string starting, string ending)
        {
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT transactionTable.transactionType, customerTable.Pin,customerTable.HolderName,transactionTable.transactionAmount, transactionTable.transactionDate " +
                           "FROM customerTable INNER JOIN transactionTable " +
                           "ON customerTable.AccountNo=transactionTable.F_AccountNum " +
                           "WHERE transactionTable.transactionDate>=@sdt AND transactionTable.transactionDate <= @ldt", conn);
            SqlParameter p1 = new SqlParameter("@sdt",starting);
            SqlParameter p2 = new SqlParameter("@ldt",ending);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            SqlDataReader dr = cmd.ExecuteReader();
            List<object> list = new List<object>();

            while (dr.Read())
            {
                object[] myarr = new object[5];
                myarr[0] = (string)dr[0];
                myarr[1] = (string)dr[1];
                myarr[2] = (string)dr[2];
                myarr[3] = (int)dr[3];
                myarr[4] = (string)dr[4];
                list.Add(myarr);
            }
            conn.Close();
            return list;
        }
        public bool isAmountEnough(int amount, loginBO LBO)
        {
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM customerTable WHERE Login=@l AND pin=@p", conn);

            SqlParameter p1 = new SqlParameter("@l", LBO.username);
            SqlParameter p2 = new SqlParameter("@p", LBO.password);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string balance = (string)dr["Balance"];
            int mybalance = int.Parse(balance);
            if (mybalance >= amount)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }
        public void withdrawAmount(int amount, loginBO LBO)
        {
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM customerTable WHERE Login=@l AND pin=@p", conn);

            SqlParameter p1 = new SqlParameter("@l", LBO.username);
            SqlParameter p2 = new SqlParameter("@p", LBO.password);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string balance = (string)dr["Balance"];
            int accountNum = (int)dr["AccountNo"];
            int mybalance = int.Parse(balance);
            int totalBalance = mybalance - amount;
            conn.Close();
            conn.Open();


            SqlCommand cmd1 = new SqlCommand("UPDATE customerTable SET Balance=@b WHERE Login=@l AND pin=@p", conn);
            SqlParameter p3 = new SqlParameter("@b", totalBalance);
            SqlParameter p4 = new SqlParameter("@l", LBO.username);
            SqlParameter p5 = new SqlParameter("@p", LBO.password);

            cmd1.Parameters.Add(p3);
            cmd1.Parameters.Add(p4);
            cmd1.Parameters.Add(p5);

            cmd1.ExecuteNonQuery();

            conn.Close();

            conn.Open();
            SqlCommand cmd2 = new SqlCommand($"INSERT INTO transactionTable(F_AccountNum, transactionAmount, transactionDate, transactionType) VALUES(@a, @wa, @wd, @tt)", conn);

            SqlParameter p6 = new SqlParameter("@a", accountNum);
            SqlParameter p7 = new SqlParameter("@wa", amount);
            SqlParameter p8 = new SqlParameter("@wd", DateTime.Now.ToString("dd/MM/yyyy"));
            SqlParameter p9 = new SqlParameter("@tt", "withdraw");

            cmd2.Parameters.Add(p6);
            cmd2.Parameters.Add(p7);
            cmd2.Parameters.Add(p8);
            cmd2.Parameters.Add(p9);

            cmd2.ExecuteNonQuery();
            conn.Close();

        }
        public object[] makeReceipt(loginBO LBO)
        {
            object[] myarr = new object[4];
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT customerTable.AccountNo,customerTable.Balance,transactionTable.transactionDate, transactionTable.transactionAmount " +
                "FROM customerTable INNER JOIN transactionTable " +
                "ON customerTable.AccountNo=transactionTable.F_AccountNum " +
                "WHERE customerTable.Login=@l AND customerTable.Pin = @p", conn);
            SqlParameter p1 = new SqlParameter("@l", LBO.username);
            SqlParameter p2 = new SqlParameter("@p", LBO.password);

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();


            myarr[0] = (int)dr[0];
            myarr[1] = (string)dr[1];
            myarr[2] = (string)dr[2];
            myarr[3] = (int)dr[3];

            conn.Close();
            return myarr;

        }
        public int withdrawperDay(loginBO LBO)
        {
            int total = 0;
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT transactionTable.transactionAmount FROM customerTable INNER JOIN transactionTable " +
                "ON customerTable.AccountNo=transactionTable.F_AccountNum " +
                "WHERE customerTable.Login=@n AND customerTable.Pin=@p AND transactionTable.transactionDate=@dt", conn);
            string d = DateTime.Now.ToString("dd/MM/yyyy");
            SqlParameter p = new SqlParameter("@n", LBO.username);
            SqlParameter p1 = new SqlParameter("@p", LBO.password);
            SqlParameter p2 = new SqlParameter("@dt", d);
            cmd.Parameters.Add(p);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                total += (int)dr[0];
            }
            conn.Close();
            return total;
        }
        public int yourcurBalance(string login)
        {
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Balance FROM customerTable WHERE Login=@l", conn);

            SqlParameter p1 = new SqlParameter("@l", login);
            cmd.Parameters.Add(p1);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string balance = (string)dr[0];
            int mybalance = int.Parse(balance);
            return mybalance;

        }
        public string userOfAccount(int account)
        {
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Login FROM customerTable WHERE AccountNo=@acc", conn);

            SqlParameter p1 = new SqlParameter("@acc", account);
            cmd.Parameters.Add(p1);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string userName = (string)dr[0];
            return userName;
        }
        public string holderNameOfAccount(int account)
        {
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT HolderName FROM customerTable WHERE AccountNo=@acc", conn);

            SqlParameter p1 = new SqlParameter("@acc", account);
            cmd.Parameters.Add(p1);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string h = (string)dr[0];
            return h;
        }
        public int accountFromUser(string username)
        {
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT AccountNo FROM customerTable WHERE Login=@l", conn);

            SqlParameter p1 = new SqlParameter("@l", username);
            cmd.Parameters.Add(p1);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int account = (int)dr[0];
            return account;
        }
        public void transferAmount(loginBO LBO, int amount, int toAccount)
        {

            //getting my account
            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            SqlCommand cmdd = new SqlCommand("SELECT * FROM customerTable WHERE Login=@l AND pin=@p", conn);

            SqlParameter p = new SqlParameter("@l", LBO.username);
            SqlParameter pp = new SqlParameter("@p", LBO.password);
            cmdd.Parameters.Add(p);
            cmdd.Parameters.Add(pp);
            SqlDataReader dr = cmdd.ExecuteReader();
            dr.Read();
            string balance = (string)dr["Balance"];
            int accountNum = (int)dr["AccountNo"];
            int mybalance = int.Parse(balance);
            conn.Close();

            //update your balance

            int remainingBalance = mybalance - amount;
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE customerTable SET Balance=@b WHERE Login=@l AND Pin=@p", conn);

            SqlParameter p1 = new SqlParameter("@l", LBO.username);
            SqlParameter p2 = new SqlParameter("@p", LBO.password);
            SqlParameter p3 = new SqlParameter("@b", remainingBalance);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.ExecuteNonQuery();
            conn.Close();

            //update toAccount balance
            conn.Open();
            string userName = userOfAccount(toAccount);
            mybalance = yourcurBalance(userName);
            remainingBalance = mybalance + amount;

            SqlCommand cmd1 = new SqlCommand("UPDATE customerTable SET Balance=@b WHERE Login=@l AND AccountNo=@acc", conn);

            SqlParameter p4 = new SqlParameter("@l", userName);
            SqlParameter p5 = new SqlParameter("@acc", toAccount);
            SqlParameter p6 = new SqlParameter("@b", remainingBalance);
            cmd1.Parameters.Add(p4);
            cmd1.Parameters.Add(p5);
            cmd1.Parameters.Add(p6);
            cmd1.ExecuteNonQuery();
            conn.Close();

            //create table
            conn.Open();
            SqlCommand cmd2 = new SqlCommand($"INSERT INTO transactionTable(F_AccountNum, transactionAmount, transactionDate, transactionType) VALUES(@a, @ta, @td,@tt)", conn);

            SqlParameter p7 = new SqlParameter("@a", accountNum);
            SqlParameter p8 = new SqlParameter("@tt", "Transfer");
            SqlParameter p9 = new SqlParameter("@td", DateTime.Now.ToString("dd/MM/yyyy"));
            SqlParameter p10 = new SqlParameter("@ta", amount);


            cmd2.Parameters.Add(p7);
            cmd2.Parameters.Add(p8);
            cmd2.Parameters.Add(p9);
            cmd2.Parameters.Add(p10);

            cmd2.ExecuteNonQuery();
            conn.Close();

        }
        public void depositAmount(int amt, loginBO LBO)
        {
            int balance = yourcurBalance(LBO.username);
            balance = balance + amt;
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE customerTable SET Balance=@b WHERE Login=@l AND Pin=@p", conn);

            SqlParameter p1 = new SqlParameter("@l", LBO.username);
            SqlParameter p2 = new SqlParameter("@p", LBO.password);
            SqlParameter p3 = new SqlParameter("@b", balance);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.ExecuteNonQuery();
            conn.Close();

            int accountNum = accountFromUser(LBO.username);
            conn.Open();
            SqlCommand cmd2 = new SqlCommand($"INSERT INTO transactionTable(F_AccountNum, transactionAmount, transactionDate, transactionType) VALUES(@a, @wa, @wd,@tt)", conn);

            SqlParameter p6 = new SqlParameter("@a", accountNum);
            SqlParameter p7 = new SqlParameter("@wa", amt);
            SqlParameter p8 = new SqlParameter("@wd", DateTime.Now.ToString("dd/MM/yyyy"));
            SqlParameter p9 = new SqlParameter("@tt", "Deposit");

            cmd2.Parameters.Add(p6);
            cmd2.Parameters.Add(p7);
            cmd2.Parameters.Add(p8);
            cmd2.Parameters.Add(p9);

            cmd2.ExecuteNonQuery();
            conn.Close();


        }
    }
}
