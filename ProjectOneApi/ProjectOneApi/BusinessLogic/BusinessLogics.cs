using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using ProjectOneApi.DataLogic;
using ProjectOneApi.EntityObjects;

namespace ProjectOneApi.BusinessLogic
{
    public class BusinessLogics
    {
        //public string GenerateAccountNumber()
        //{
        //    try
        //    {
        //        object[] paras = { };
        //        DataBaseHandler dbh = new DataBaseHandler();
        //        DataTable dt = dbh.GetData(CmdCommands.GetCustomerCount, paras);
        //        int ccount = Convert.ToInt32(dt.Rows[0][0]) + 01;
        //        string NewAC = "AC30267" + "0" + ccount;
        //        return NewAC;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public string RegisterUser(string firstname, string lastname, string email, string telephone, string password)
        {
            try
            {

                //string UserId = GetUserId();
                string Password = EncryptText(password);
                object[] paras = { firstname, lastname, email, telephone, Password };
                DataBaseHandler dbh = new DataBaseHandler();
                string r = dbh.ExecuteDataset(CmdCommands.RegisterUser, paras);
                if (Convert.ToInt32(r) > 0)
                {
                    //string AccountType = "CORPORATE";
                    //Double MiniBalance = 2000000;
                    //string CreatedBy = "Admin";
                    //string UserAgentAccount = "C" + GenerateAccountNumber();
                    //object[] paras2 = { UserId, UserAgentAccount, AccountType, MiniBalance, CreatedBy };
                    //string r2 = dbh.ExecuteDataset(CmdCommands.CreateCustomerAccount, paras2);
                    return r.ToString();
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable LoginUser(string email, string password)
        {
            try
            {
                string Password = EncryptText(password);
                object[] paras = { email, Password };
                DataBaseHandler dbh = new DataBaseHandler();
                DataTable dt = dbh.GetData(CmdCommands.LoginUser, paras);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string EncryptText(string PlainTExt)
        {
            string hash = "foxle@rn";
            byte[] data = UTF8Encoding.UTF8.GetBytes(PlainTExt);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };

            ICryptoTransform transform = tripleDes.CreateEncryptor();
            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
            string EncryptedPassword = Convert.ToBase64String(results);
            return EncryptedPassword;
        }

        public string DecryptText(string EncryptedString)
        {
            string hash = "foxle@rn";
            byte[] data = Convert.FromBase64String(EncryptedString);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
            ICryptoTransform transform = tripleDes.CreateDecryptor();
            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
            string PlainText = UTF8Encoding.UTF8.GetString(results);
            return PlainText;
        }
        //public DataTable GetCustomerAccountDetails(string AccountNo)
        //{
        //    try
        //    {
        //        object[] paras = { AccountNo };
        //        DataBaseHandler dbh = new DataBaseHandler();
        //        DataTable dt = dbh.GetData(CmdCommands.GetCustomerAccountDetails, paras);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public DataTable GetCustomerAccountStatement(string AccountNumber, string StartDate, string EndDate)
        //{
        //    try
        //    {
        //        object[] paras = { AccountNumber, StartDate, EndDate };
        //        DataBaseHandler dbh = new DataBaseHandler();
        //        DataTable dt = dbh.GetData(CmdCommands.GetAccountStatement, paras);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public DataTable GetOpeningAndClosingBalance(string AccountNumber, string StartDate, string EndDate)
        //{
        //    try
        //    {
        //        object[] paras = { AccountNumber, StartDate, EndDate };
        //        DataBaseHandler dbh = new DataBaseHandler();
        //        DataTable dt = dbh.GetData(CmdCommands.GetOpeningAndClosingBalance, paras);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public DataTable GetAccountTransactionsByDate(string AccountNumber, string StartDate, string EndDate)
        //{
        //    try
        //    {
        //        object[] paras = { AccountNumber, StartDate, EndDate };
        //        DataBaseHandler dbh = new DataBaseHandler();
        //        DataTable dt = dbh.GetData(CmdCommands.GetAccountTransactionsByDate, paras);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public string DebitAccount(string AccountNumber, string DebitAmount, string userId, string TranType)
        //{
        //    try
        //    {
        //        DataBaseHandler dh = new DataBaseHandler();
        //        string TransRef = "T" + GetUserId();
        //        //object[] paras= new object[5];
        //        if (TranType.Equals("Deposit"))
        //        {
        //            string AccountToDebit = GetAccountToDebit(userId);
        //            string narration = null;
        //            narration = "Debit of " + DebitAmount + " to " + AccountToDebit + " has been made";
        //            object[] paras = { TransRef, AccountToDebit, AccountNumber, DebitAmount, "", narration };
        //            string k = dh.ExecuteDataset(CmdCommands.debitAccount, paras);
        //            string r = null;
        //            if (Convert.ToInt32(k) > 0)
        //            {
        //                paras[5] = "Credit of " + DebitAmount + " to " + AccountNumber + " has been made";
        //                r = dh.ExecuteDataset(CmdCommands.creditAccount, paras);
        //            }
        //            return r;

        //        }
        //        else if (TranType.Equals("Withdraw"))
        //        {
        //            string CorporateAccount = GetAccountToDebit(userId);
        //            string narration = "Debit of " + DebitAmount + " to " + AccountNumber + " has been made";
        //            object[] paras = { TransRef, AccountNumber, CorporateAccount, DebitAmount, "", narration };
        //            string k = dh.ExecuteDataset(CmdCommands.debitAccount, paras);
        //            string r = null;
        //            if (Convert.ToInt32(k) > 0)
        //            {
        //                paras[5] = "Credit of " + DebitAmount + " to " + CorporateAccount + " has been made";
        //                r = dh.ExecuteDataset(CmdCommands.creditAccount, paras);
        //            }
        //            return r;
        //        }
        //        else
        //        {
        //            return "";
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public string CreditAccount(object[] paras)
        //{
        //    try
        //    {
        //        DataBaseHandler dh = new DataBaseHandler();
        //        string r = dh.ExecuteDataset(CmdCommands.creditAccount, paras);
        //        return r;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public string GetAccountToDebit(string UserId)
        //{
        //    try
        //    {
        //        object[] paras = { UserId };
        //        DataBaseHandler dbh = new DataBaseHandler();
        //        DataTable dt = dbh.GetData(CmdCommands.GetAccountToDebit, paras);
        //        return dt.Rows[0][1].ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public Boolean ValidateCustomerAccount(string AccountNumber)
        //{
        //    try
        //    {
        //        object[] paras = { AccountNumber };
        //        DataBaseHandler dbh = new DataBaseHandler();
        //        DataTable dt = dbh.GetData(CmdCommands.GetCustomerAccount, paras);
        //        Boolean IsValid;
        //        if (dt.Rows.Count > 0)
        //        {
        //            IsValid = true;
        //        }
        //        else
        //        {
        //            IsValid = false;
        //        }
        //        return IsValid;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void ComposeEmail(string tranType, string AccountNumber, string Amount, string Balance, string EmailAddrress, string CustomerName)
        //{
        //    try
        //    {
        //        if (tranType.Equals("Deposit") || tranType.Equals("WithDraw"))
        //        {
        //            string[] cc = { };
        //            string Suject = "Account " + tranType;
        //            string[] to = { EmailAddrress };
        //            string from = "judebwayo@gmail.com";
        //            string message;
        //            message = "<p style='font-size:14px;'>Dear," + CustomerName + "<br/>";
        //            message += "Your " + tranType + " of : <b>" + Amount + "</b> for <b>ACCNo</b>:" + AccountNumber + " was succsessful" + "<br/>";
        //            message += "Your current balance is : <b>" + Balance + "</b></p>";
        //            message += "<br/>";
        //            message += "<b style='font-size:14px;'>Thank You</b><br/>";
        //            message += "<b style='font-size:14px;'>Pegasus Online Transactions Channel</b><br/>";

        //            string[] attachments = { };
        //            EmailProcessor emp = new EmailProcessor();
        //            emp.SendMailNew(to, cc, message, Suject, attachments, from);
        //        }
        //        else if (tranType.Equals("Account-Registration"))
        //        {
        //            string[] cc = { };
        //            string Suject = tranType;
        //            string[] to = { EmailAddrress };
        //            string from = "judebwayo@gmail.com";
        //            string message;
        //            message = "<p style='font-size:14px;'>Dear," + CustomerName + "<br/>";
        //            message += "Your Account :<b>" + AccountNumber + "</b> has been successfully created</p>";
        //            message += "<br/>";
        //            message += "<b style='font-size:14px;'>Thank You</b><br/>";
        //            message += "<b style='font-size:14px;'>Pegasus Online Transactions Channel</b><br/>";

        //            string[] attachments = { };
        //            EmailProcessor emp = new EmailProcessor();
        //            emp.SendMailNew(to, cc, message, Suject, attachments, from);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public DataTable GetUserToEmail()
        //{
        //    try
        //    {
        //        object[] paras = { };
        //        DataBaseHandler dbh = new DataBaseHandler();
        //        DataTable dt = dbh.GetData(CmdCommands.GetCustomerRegistrationDetails, paras);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public DataTable GetDepositsToNotify()
        //{
        //    try
        //    {
        //        object[] paras = { };
        //        DataBaseHandler dbh = new DataBaseHandler();
        //        DataTable dt = dbh.GetData(CmdCommands.DepositNotifier, paras);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public string UpdateCustomerNotificationStatus(string AccountNumber)
        //{
        //    try
        //    {
        //        object[] paras = { AccountNumber };
        //        DataBaseHandler dh = new DataBaseHandler();
        //        string k = dh.ExecuteDataset(CmdCommands.UpdateCustomerNotificationStatus, paras);
        //        return k;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public string UpdateDepositNotificationStatus(int RecordId)
        //{
        //    try
        //    {
        //        object[] paras = { RecordId };
        //        DataBaseHandler dh = new DataBaseHandler();
        //        string k = dh.ExecuteDataset(CmdCommands.UpdateDepositNotificationStatus, paras);
        //        return k;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public DataTable GetWithdrawsToNotify()
        //{
        //    try
        //    {
        //        object[] paras = { };
        //        DataBaseHandler dbh = new DataBaseHandler();
        //        DataTable dt = dbh.GetData(CmdCommands.GetWithdrawsToNotify, paras);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public string UpdatesWithdrawNotificationStatus(int RecordId)
        //{
        //    try
        //    {
        //        object[] paras = { RecordId };
        //        DataBaseHandler dh = new DataBaseHandler();
        //        string k = dh.ExecuteDataset(CmdCommands.WithdrawNotification, paras);
        //        return k;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public DataTable GetAccounts()
        //{
        //    try
        //    {
        //        object[] paras = { };
        //        DataBaseHandler dbh = new DataBaseHandler();
        //        DataTable dt = dbh.GetData(CmdCommands.GetCustomerAccounts, paras);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public DataTable GetRunningBalance(String AccountNumber)
        //{
        //    try
        //    {
        //        object[] paras = { AccountNumber };
        //        DataBaseHandler dbh = new DataBaseHandler();
        //        DataTable dt = dbh.GetData(CmdCommands.balanceDetails, paras);

        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        
        //public string RegisterCustomer(Customer customer)
        //{
        //    try
        //    {
        //        string CustomerACNo = GenerateAccountNumber();
        //        string UserId = GetUserId();
        //        object[] paras = { UserId, CustomerACNo, customer.FirstName, customer.LastName, customer.Telephone, customer.Email };
        //        DataBaseHandler dbh = new DataBaseHandler();
        //        string r = dbh.ExecuteDataset(CmdCommands.RegisterCustomer, paras);
        //        if (Convert.ToInt32(r) > 0)
        //        {
        //            string AccountType = "CUSTOMER";
        //            Double MiniBalance = 0;
        //            string CreatedBy = "Admin";
        //            object[] paras2 = { UserId, CustomerACNo, AccountType, MiniBalance, CreatedBy };
        //            string r2 = dbh.ExecuteDataset(CmdCommands.CreateCustomerAccount, paras2);
        //            return r2;
        //        }
        //        else
        //        {
        //            return "0";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public string CreateCustomerAccount(string AccountNumber, string AccountType, string MiniBalance, string CreatedBy)
        //{
        //    object[] paras = { AccountNumber, AccountType, MiniBalance, CreatedBy, };
        //    DataBaseHandler dbh = new DataBaseHandler();
        //    string r = dbh.ExecuteDataset(CmdCommands.CreateCustomerAccount, paras);
        //    return r;
        //}

        //public string GetUserId()
        //{
        //    string userId = DateTime.Now.ToString("yyssffff");
        //    return userId;
        //}


        //public DataTable systemLogs()
        //{
        //    try
        //    {
        //        object[] paras = { };
        //        DataBaseHandler dbh = new DataBaseHandler();
        //        DataTable dt = dbh.GetData(CmdCommands.retrieveSystemLogs, paras);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



    }

}