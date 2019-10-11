using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.Data.SqlClient;//用于SQL Sever数据访问的命名空间
using System.Data;
using System.Security.Cryptography;
using System.Configuration;               //DataSet类的命名空间



namespace 网络用户管理系统
{
    public partial class Default : System.Web.UI.Page,IDefault
    {
        private static string sValidator = "";
        private StringBuilder LetterList = new StringBuilder();
        private readonly string sValidatorImageUrl = "Validdateimage.aspx";
        bool valid = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if(!Page.IsPostBack)
            {
                sValidator = CreatValidateString(4);
                Session["Validator"] = sValidator;
                Image1.ImageUrl = sValidatorImageUrl;
            
            }



        }

        public string CreatValidateString(int nLen)//创建验证码
        {
            InitLetterList();
            StringBuilder sb = new StringBuilder(nLen);//验证码长度
            for (int i = 0; i < nLen; i++)
            {
                int index = GetRandomInt(0,LetterList.Length-1);//获取验证码数字
                sb.Append(LetterList[index].ToString());//添加数字到验证码
                LetterList.Remove(index,1);//防止验证码重复
            }
            return(sb.ToString());
        }

        public void InitLetterList()//创建组成验证码数字的数字或集合
        {
            for (int i = 0; i < 10; i++)
            {
                LetterList.Append(i.ToString());//获取自然数

            }
            for (int i = 0; i < 26; i++)
            {
                LetterList.Append(((char)((int)'a'+i)).ToString());//添加小写字母

            }
            for (int i = 0; i < 26; i++)
            {
                 LetterList.Append(((char)((int)'A'+i)).ToString());//添加大写字母
            }
        }

        public int GetRandomInt(int min, int max)//获取随机数
        {
            Random random = new Random();
            return(random.Next(min,max));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Page.IsValid == true)
            {
                
            if (Validator.Text != sValidator)
              {   //弹出提示窗口
               string str_Message = "验证码错误";
               ClientScriptManager scriptManager = ((Page)System.Web.HttpContext.Current.Handler).ClientScript;
               scriptManager.RegisterStartupScript(typeof(string), "", "alert('" + str_Message + "');", true);
               //刷新验证码
               sValidator = CreatValidateString(4);
               Session["Validator"] = sValidator;
               Image1.ImageUrl = sValidatorImageUrl;
                }
                else
                {
                    string UserId = "";
                    //定义并获取用户信息
                    IUser User = new User();

                    string sUserName = Server.HtmlDecode(UserName.Text.Trim());
                    string sPassword = Server.HtmlDecode(Password.Text.Trim());

                    int X=User.WhetherIsAdmin(sUserName);
                    if (X == 1)
                    {
                        SqlDataReader recu;
                        if (sUserName == "汪海洋")
                        {   
                            recu = User.GetUserLoginByProc(sUserName, sPassword);

                        }
                        else
                        {//通过系统添加的用户，因为密码经过了加密，所以验证时密码须需要加密处理
                            string ssPassword = User.Encrypt(sPassword);
                            recu = User.GetUserLoginByProc(sUserName, ssPassword);
                        }



                        if (recu.Read())
                        {
                            UserId = recu["UserID"].ToString();
                            Response.Redirect("~/UserManage.aspx");

                        }
                        else
                        {
                            sValidator = CreatValidateString(4);
                            Session["Validator"] = sValidator;
                            Image1.ImageUrl = sValidatorImageUrl;

                            string str_Message = "用户名或密码错误";
                            ClientScriptManager scriptManager = ((Page)System.Web.HttpContext.Current.Handler).ClientScript;
                            scriptManager.RegisterStartupScript(typeof(string), "", "alert('" + str_Message + "');", true);
                        }
                    }
                    else
                    {
                        string str_Message = "抱歉您没有权限访问！";
                        ClientScriptManager scriptManager = ((Page)System.Web.HttpContext.Current.Handler).ClientScript;
                        scriptManager.RegisterStartupScript(typeof(string), "", "alert('" + str_Message + "');", true);
                    
                    }

                }
            }
        } 

        protected void Button2_Click(object sender, EventArgs e)
        {
            UserName.Text = Password.Text = Validator.Text="";
            sValidator = CreatValidateString(4);
            Session["Validator"] = sValidator;
            Image1.ImageUrl = sValidatorImageUrl;
        }

      

      
    }
}