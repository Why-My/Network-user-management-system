using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 网络用户管理系统
{
    public partial class EditPwd : System.Web.UI.Page
    {
        private int nUserID = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Request.Params["UserID"] != null)
            {

                if (Int32.TryParse(Request.Params["UserID"].ToString(), out nUserID) == false)
                {
                    return;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                IUser user = new User();
                try
                {
                    user.UpdateUserPwd(nUserID,XPassword.Text.Trim());

                    string str_Message = "密码修改成功";
                    ClientScriptManager scriptManager = ((Page)System.Web.HttpContext.Current.Handler).ClientScript;
                    scriptManager.RegisterStartupScript(typeof(string), "", "alert('" + str_Message + "');", true);
                }
                catch (SqlException ex)
                {

                    Response.Redirect("~/ErrorPage.aspx?ErrorMsg=" + ex.Message + "&ErrorUrl=" + Request.Url.ToString());
                }
            }
        }

        protected void nReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserManage.aspx");
        }
    }
}