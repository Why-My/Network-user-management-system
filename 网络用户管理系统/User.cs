using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace 网络用户管理系统
{
    public class User:IUser
    {
       
       private static readonly string GETUSERS = "SELECT * FROM Users";
       private static readonly string GETSINGLEUSER = "SELECT * FROM Users WHERE UserID=";
       private static readonly string ADDUSER = "INSERT INTO Users(UserID,UserName,Password,Email,IsAdmin)VALUES";
       private static readonly string UPDATEUSERSEMAIL= "UPDATE Users SET Email=";
       private static readonly string UPDATEUSERSISADMIN = "UPDATE Users SET IsAdmin=";
       private static readonly string UPDATEUSERSPWD = "UPDATE Users SET Password=";
       private static readonly string UPDATEUSERSENAME = "UPDATE Users SET UserName=";
       private static readonly string DELETEUSER = "DELETE FROM Users WHERE UserID=";
       private static readonly string GETUSERID = "SELECT UserID FROM Users WHERE UserName=";
       private static readonly string GETUSERIDCOUNT2 = "SELECT COUNT(UserID) FROM Users ";
       private static readonly string WhetherIsAdmin2= "SELECT IsAdmin FROM Users WHERE UserName=";


       public SqlDataReader GetUserLoginByProc(string sUserName, String sPassword)
       {
           string conn = ConfigurationManager.ConnectionStrings["Query1.dtq"].ConnectionString;
           SqlConnection myConnection = new SqlConnection(conn);
           SqlCommand myCommand = new SqlCommand("Pr_GetUserLogin", myConnection);
           myCommand.CommandType = CommandType.StoredProcedure;

           SqlParameter pUserName = new SqlParameter("@UserName", SqlDbType.VarChar, 23);
           pUserName.Value = sUserName;
           myCommand.Parameters.Add(pUserName);

           SqlParameter pPassword = new SqlParameter("@Password", SqlDbType.VarChar, 255);
           pPassword.Value = sPassword;
           myCommand.Parameters.Add(pPassword);

           SqlDataReader dr = null;
           try
           {
               myConnection.Open();
               dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);


           }
           catch (SqlException ex)
           {

               throw new Exception(ex.Message, ex);


           }

           return dr;
       }
       public string Encrypt(string Password)
       {
           MD5 md5Hash = MD5.Create();
           //获取Byte
           Byte[] ClearByte = Encoding.Default.GetBytes(Password);
           //获取Hash
           Byte[] HashedByte = md5Hash.ComputeHash(ClearByte);
           //返回加密后的信息
           return BitConverter.ToString(HashedByte);

       }
       public SqlDataReader GetUsers()
       {
           string conn = ConfigurationManager.ConnectionStrings["Query1.dtq"].ConnectionString;
           SqlConnection myConnection = new SqlConnection(conn);
           SqlCommand myCommand = new SqlCommand(GETUSERS, myConnection);
           SqlDataReader dr = null;
           try
           {
               myConnection.Open();
               dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
           }
           catch (SqlException ex)
           {

               throw new Exception(ex.Message, ex);
           }
           return dr;
       
       }
       public SqlDataReader GetSingleUser(int nUserID)
       {
           string conn = ConfigurationManager.ConnectionStrings["Query1.dtq"].ConnectionString;
           SqlConnection myConnection = new SqlConnection(conn);
           string cmdText = GETSINGLEUSER + "'" + nUserID.ToString() + "'";
           SqlCommand myCommand = new SqlCommand(cmdText,myConnection);
           SqlDataReader dr = null;
           try
           {
               myConnection.Open();
               dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
           }
           catch (SqlException ex)
           {

               throw new Exception(ex.Message, ex);
           }
           return dr;
          
       
       }
       public int UpdateUserEmail(int nUserID,string sEmail)
       {
           string conn = ConfigurationManager.ConnectionStrings["Query1.dtq"].ConnectionString;
           SqlConnection myConnection = new SqlConnection(conn);
           string cmdText = UPDATEUSERSEMAIL + "'" + sEmail + "'" + "WHERE UserID="+"'"+nUserID.ToString() + "'";
           SqlCommand myCommand = new SqlCommand(cmdText, myConnection);
           int nResult = -1;
           try
           {
               myConnection.Open();
               nResult = myCommand.ExecuteNonQuery();
           }
           catch (SqlException ex)
           {

               throw new Exception(ex.Message, ex);
           }
           finally
           {
               myConnection.Close();
           }
           return nResult;
        }
       public int AddUser(string sUserName, string sPassword, string sEmail)
       {
           int XUserID = GETUSERIDCOUNT();
           int SUserID = XUserID+1;
           string conn = ConfigurationManager.ConnectionStrings["Query1.dtq"].ConnectionString;
           SqlConnection myConnection = new SqlConnection(conn);
           string cmdText = ADDUSER + "(" +"'"+SUserID+"',"+ "'" + sUserName + "'," + "'" + sPassword + "'," + "'" + sEmail + "'," + "'0'" + ")";
           SqlCommand myCommand = new SqlCommand(cmdText,myConnection);
           int nResult = -1;
           try
           {
               myConnection.Open();
               nResult = myCommand.ExecuteNonQuery();

           }
           catch (SqlException ex)
           {

               throw new Exception(ex.Message, ex);
           }
           finally
           {
               myConnection.Close();
           
           }
           return nResult;
       }
       public int UpdateUserAdmin(int nUserID,bool bIsAdmin)
       {
           string conn = ConfigurationManager.ConnectionStrings["Query1.dtq"].ConnectionString;
           SqlConnection myConnection = new SqlConnection(conn);
           string cmdText = UPDATEUSERSISADMIN + "'" + (bIsAdmin ? 1 : 0).ToString() + "'" + "WHERE UserID=" + "'" + nUserID.ToString() + "'";
           SqlCommand myCommand = new SqlCommand(cmdText,myConnection);
           int nResult = -1;
           try
           {
               myConnection.Open();
               nResult = myCommand.ExecuteNonQuery();
           }
           catch (SqlException ex)
           {

               throw new Exception(ex.Message, ex);
           }
           finally
           {
               myConnection.Close();
           
           }
           return nResult;
       }
       public int UpdataUserName(int nUserID, string sUserName)
       {
           string conn = ConfigurationManager.ConnectionStrings["Query1.dtq"].ConnectionString;
           SqlConnection myConnection = new SqlConnection(conn);
           string cmdText = UPDATEUSERSENAME + "'" + sUserName + "'" + "WHERE UserID=" + "'" + nUserID.ToString() + "'";
           SqlCommand myCommand = new SqlCommand(cmdText, myConnection);
           int nResult = -1;
           try
           {
               myConnection.Open();
               nResult = myCommand.ExecuteNonQuery();
           }
           catch (SqlException ex)
           {

               throw new Exception(ex.Message, ex);
           }
           finally
           {
               myConnection.Close();
           }
           return nResult;
       
       }
       public int DeleteUser(int nUserID)
       {
           string conn = ConfigurationManager.ConnectionStrings["Query1.dtq"].ConnectionString;
           SqlConnection myConnection = new SqlConnection(conn);
           string cmdText = DELETEUSER + "'" + nUserID.ToString() + "'";
           SqlCommand myCommand = new SqlCommand(cmdText, myConnection);
           int nResult = -1;
           try
           {
               myConnection.Open();
               nResult = myCommand.ExecuteNonQuery();
           }
           catch (SqlException ex)
           {

               throw new Exception(ex.Message, ex);
           }
           finally
           {
               myConnection.Close();
           }
           return nResult;


       }
       public int UpdateUserPwd(int nUserID, string sPassword)
       {
           string conn = ConfigurationManager.ConnectionStrings["Query1.dtq"].ConnectionString;
           SqlConnection myConnection = new SqlConnection(conn);
           string ssPassword = Encrypt( sPassword);
           string cmdText = UPDATEUSERSPWD + "'"+ssPassword+"'"+"WHERE UserID=" +"'" + nUserID.ToString() + "'";
           SqlCommand myCommand = new SqlCommand(cmdText, myConnection);
           int nResult = -1;
           try
           {
               myConnection.Open();
               nResult = myCommand.ExecuteNonQuery();
           }
           catch (SqlException ex)
           {

               throw new Exception(ex.Message, ex);
           }
           finally
           {
               myConnection.Close();
           }
           return nResult;
       }
       public int GETUSERIDCOUNT()
       {
           string conn = ConfigurationManager.ConnectionStrings["Query1.dtq"].ConnectionString;
           SqlConnection myConnection = new SqlConnection(conn);
           SqlDataAdapter IdCount = new SqlDataAdapter(GETUSERIDCOUNT2,myConnection);
           DataSet da = new DataSet();
           IdCount.Fill(da);
           int a = Convert.ToInt32(da.Tables[0].Rows[0][0].ToString());
           return a;
       }
       public int WhetherIsAdmin(string sUserName)
       {
           string conn = ConfigurationManager.ConnectionStrings["Query1.dtq"].ConnectionString;
           SqlConnection myConnection = new SqlConnection(conn);
           string  WhetherIsAdmin3=WhetherIsAdmin2+"'"+sUserName+"'";
           SqlDataAdapter IdCount = new SqlDataAdapter(WhetherIsAdmin3, myConnection);
           DataSet da = new DataSet();
           IdCount.Fill(da);
           int a = Convert.ToInt32(da.Tables[0].Rows[0][0]);
           return a;


       }
    }
}