using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace 网络用户管理系统
{
    interface IUser
    {
        //SqlDataReader GetUserLoginBySQL(string UserName,string sPassword);
        SqlDataReader GetUserLoginByProc(string sUserName, String sPassword);//
        SqlDataReader GetUsers();
        SqlDataReader GetSingleUser(int nUserID);
        int AddUser(string sUserName,string sPassword,string sEmail);
        int UpdateUserEmail(int nUserID,string sEmail);
        int UpdateUserPwd(int nUserID, string sPassword);
        int UpdateUserAdmin(int nUserID,bool bIsAdmin);
        int DeleteUser(int nUserID);
        string Encrypt(string Password);
        int UpdataUserName(int nUserID, string sUserName);
        int WhetherIsAdmin(string sUserName);
    }
}
