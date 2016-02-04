using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using SurveyApplication;
using System.Data;

public partial class Account_Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        if (!String.IsNullOrEmpty(returnUrl))
        {
        
        }
    }

    protected void LogIn(object sender, EventArgs e)
    {
        if (IsValid)
        {
            // Validate the user password
            //var manager = new UserManager();
            //ApplicationUser user = manager.Find(UserName.Text, Password.Text);
            //if (user != null)
            //{
            //    IdentityHelper.SignIn(manager, user, RememberMe.Checked);
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            
            if (UserName.Text != null)
            {
                DataAdapter da = new DataAdapter();
                DataSet userSet=da.ExecuteSelectQuery("Select * from Users where UserArchived=0 and UserToken='"+UserName.Text.Replace("'","''")+"'");
                if(userSet!=null && userSet.Tables.Count>0 && userSet.Tables[0].Rows.Count > 0)
                {
                    da.ExecuteUpdateQuery("Update Users set UserLastLoggedIn=GETDATE() where UserToken='" + UserName.Text.Replace("'", "''") + "'");
                    DataTable userTable = userSet.Tables[0];
                    Session["UserToken"]=userTable.Rows[0]["UserId"];
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }

            }
            else
            {
                FailureText.Text = "Invalid code";
                ErrorMessage.Visible = true;
            }
        }
    }
}