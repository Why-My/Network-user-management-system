using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace 网络用户管理系统
{
    public partial class UserManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindUserData();
            }

        }

        private void BindUserData() 
        {
            IUser user = new User();
            SqlDataReader dr = user.GetUsers();

            UserView.DataSource = dr;
            UserView.DataBind();

            dr.Close();
        
        }

        
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string commandName = e.CommandName;
            int nUserID = -1;
            if (Int32.TryParse(e.CommandArgument.ToString(),out nUserID)==false||commandName=="")
            {
                return;
            }
            IUser user = new User();
            switch (commandName)
            {
                case "delete":
                    {
                        user.DeleteUser(nUserID);
                        string str_Message = "删除成功";
                        ClientScriptManager scriptManager = ((Page)System.Web.HttpContext.Current.Handler).ClientScript;
                        scriptManager.RegisterStartupScript(typeof(string), "", "alert('" + str_Message + "');", true);
                        BindUserData();
                        break;

                    }
                case "admin":
                    {
                        Button button = (Button)e.CommandSource;
                        if (button==null)
                        {
                            break;
                        }
                        user.UpdateUserAdmin(nUserID,button.Text=="取消管理员权限"?false:true);
                       
                        BindUserData();
                        break;
                    }

                default:
                    break;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddUser.aspx");
        }

       

       
    }
}