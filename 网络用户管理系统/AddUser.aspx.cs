using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace 网络用户管理系统
{    
    public partial class AddUser : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                User user = new User();
                try
                {
                    user.AddUser(UserName.Text.Trim(),user.Encrypt(NewPassword.Text.Trim()),Email.Text.Trim());
                    string str_Message = "新用户添加成功";
                    ClientScriptManager scriptManager = ((Page)System.Web.HttpContext.Current.Handler).ClientScript;
                    scriptManager.RegisterStartupScript(typeof(string), "", "alert('" + str_Message + "');", true);
                }
                catch (SqlException ex)
                {

                    Response.Redirect("~/ErrorPage.aspx?ErrorMsg=" + ex.Message + "&ErrorUrl=" + Request.Url.ToString());
                }
            }
        }

        protected void ReturnBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserManage.aspx");
        }
    }
}