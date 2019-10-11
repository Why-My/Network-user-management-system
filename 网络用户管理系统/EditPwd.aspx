<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPwd.aspx.cs" Inherits="网络用户管理系统.EditPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 216px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 205px">
    
        <table style="width: 100%; height: 167px;">
            <caption>
                修改密码</caption>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 新密码</td>
                <td>
                    <asp:TextBox ID="XPassword" runat="server" Height="22px" Width="167px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="nPassword" runat="server" Height="25px" Text="确定" Width="113px" OnClick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="nReturn" runat="server" Height="25px" style="margin-top: 0px" Text="返回" Width="100px" OnClick="nReturn_Click" CausesValidation="False" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
