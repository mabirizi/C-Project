using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ProjectOneApi.BusinessLogic;
using ProjectOneApi.EntityObjects;
using ProjectOneApi.DataLogic;
using System.Data;

namespace ProjectOneApi
{
    /// <summary>
    /// Summary description for App
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class App : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        BusinessLogics bl = new BusinessLogics();

        [WebMethod]
        public string RegisterUser(string firstname, string lastname, string email, string telephone, string password)
        {
            try
            {
                string r = bl.RegisterUser(firstname, lastname, email, telephone, password);
                string result = null;
                if (Convert.ToInt32(r) > 0)
                {
                    result = "User Registered Successfully";
                }
                else
                {
                    result = "User Registration Failed";
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        [WebMethod]
        public Boolean LoginUser(string email, string password)
        {
            try
            {

                object[] paras = { };
                DataBaseHandler dbh = new DataBaseHandler();
                DataTable dt = bl.LoginUser(email, password);
                Boolean ValidUser;
                if (dt.Rows.Count > 0)
                {
                    string UserId = dt.Rows[0][1].ToString();
                    ValidUser = true;
                }
                else
                {
                    ValidUser = false;
                }
                return ValidUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
