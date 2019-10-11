<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="网络用户管理系统.EditUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 190px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 301px">
    
       <table style="width: 100%; height: 135px;">
            <caption>
                修改用户</caption>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;用户名称</td>
                <td>
                    <asp:TextBox ID="UserName" runat="server" Height="19px" Width="162px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 电子邮件</td>
                <td>
                    <asp:TextBox ID="Email" runat="server" Height="19px" Width="162px"></asp:TextBox>
                    &nbsp
                    </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfE" runat="server" ErrorMessage="电子邮件不能为空" ControlToValidate="Email" Font-Overline="False" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="电子邮件的格式不正确" ControlToValidate="Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="UpdataBtn" runat="server" Text="修改" Width="123px" Height="28px" OnClick="UpdataBtn_Click" />
                </td>
                <td>
                    <asp:Button ID="ReturnRtn" runat="server" Text="返回" Width="123px" Height="28px" OnClick="ReturnRtn_Click" CausesValidation="False" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
