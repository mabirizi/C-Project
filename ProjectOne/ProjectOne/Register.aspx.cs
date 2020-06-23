using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectOne.AppApi;

namespace ProjectOne
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AdminLoginRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = txtFirstName.Text.ToString();
                string lastName = txtLastName.Text.ToString();
                string email = txtEmail.Text.ToString();
                string telephone = txtTelephoneNumber.Text.ToString();
                string password = txtPassword.Text.ToString();
                string cpassword = txtConfirmPassword.Text.ToString();
                if (firstName.Equals(""))
                {
                    ShowMessage("Please enter your first name:", true);
                }
                else
            if (lastName.Equals(""))
                {
                    ShowMessage("Please enter your last name", true);
                }
                else
                if (email.Equals(""))
                {
                    ShowMessage("Please enter your last name", true);
                }
                else
                if (telephone.Equals(""))
                {
                    ShowMessage("Please enter your telephone number", true);
                }
                else
                if (password.Equals(""))
                {
                    ShowMessage("Please enter your password", true);
                }
                else
                {
                    if (password.Equals(cpassword))
                    {
                        App api = new App();
                        string result = api.RegisterUser(firstName, lastName, email, telephone, password);
                        ShowMessage(result, false);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, true);
            }

        }

        public void ShowMessage(string ErrorMessage, Boolean IsError)
        {
            if (IsError)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Label1.ForeColor = System.Drawing.Color.Green;
            }
            Label1.Text = ErrorMessage;
        }
    }
}