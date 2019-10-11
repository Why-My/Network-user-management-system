using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace 网络用户管理系统
{
    public partial class ViewUser : System.Web.UI.Page
    {
        private int nUserID = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Request.Params["UserID"] != null)//判断是否获取UserID参数
            {
                //将字符型转换成整型
                if (Int32.TryParse(Request.Params["UserID"].ToString(), out nUserID) == false)
                {
                    return;
                }
            }
            if (!Page.IsPostBack)
            {//判断是否转换成功
                if (nUserID > -1)
                {
                    BindUserData(nUserID);
                }
            }


        }

        protected void ReturnRtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserManage.aspx");

        }
        private void BindUserData(int nUserId)//根据UserID获取UserName和Email并付给相应控件显示
        {
            IUser user = new User();
            SqlDataReader dr = user.GetSingleUser(nUserID);
            if (dr.Read())
            {   
                Email.Text=dr["Email"].ToString();
                UserName.Text = dr["UserName"].ToString();
                
            }
            dr.Close();
        
        }
    }
}