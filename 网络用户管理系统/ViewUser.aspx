<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="网络用户管理系统.ViewUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 191px;
        }
        .auto-style2 {
            width: 191px;
            height: 50px;
        }
        .auto-style3 {
            height: 50px;
        }
        .auto-style4 {
            width: 191px;
            height: 30px;
        }
        .auto-style5 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 310px">
    
        <table style="width: 100%; height: 111px; margin-top: 0px;">
            <caption>
                查看用户信息</caption>
            <tr>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;用户名</td>
                <td class="auto-style3">
                    <asp:TextBox ID="UserName" runat="server" Height="19px" Width="162px" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 电子邮箱&nbsp;</td>
                <td class="auto-style5">
                    <asp:TextBox ID="Email" runat="server" Height="19px" Width="162px" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="ReturnRtn" runat="server" Text="返回" Width="150px" CausesValidation="False" OnClick="ReturnRtn_Click"  />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
