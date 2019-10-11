<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="网络用户管理系统.AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 242px;
        }
        .auto-style2 {
            width: 154px;
        }
        .auto-style3 {
            width: 242px;
            height: 35px;
        }
        .auto-style4 {
            width: 154px;
            height: 35px;
        }
        .auto-style5 {
            height: 35px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 201px">
    
        <table style="width: 100%; height: 88px;">
            <caption>
                用户注册</caption>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 用户名称&nbsp;</td>
                <td class="auto-style2">
                    <asp:TextBox ID="UserName" runat="server" Height="25px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfN" runat="server" ErrorMessage="用户名不能为空" ControlToValidate="UserName" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;用户密码</td>
                <td class="auto-style4">
                    <asp:TextBox ID="NewPassword" runat="server" Height="25px" TextMode="Password"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="rfP" runat="server" ErrorMessage="密码不能为空" ControlToValidate="NewPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;确认密码</td>
                <td class="auto-style2">
                    <asp:TextBox ID="PasswordStr" runat="server" Height="25px" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfS" runat="server" ErrorMessage="密码不能为空！" ControlToValidate="PasswordStr" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="两次密码不一样"
                         ControlToCompare="NewPassword" ControlToValidate="PasswordStr"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 电子邮箱&nbsp;</td>
                <td class="auto-style2">
                    <asp:TextBox ID="Email" runat="server" Height="25px" ></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfE" runat="server" ErrorMessage="电子邮箱不能为空" ControlToValidate="Email"></asp:RequiredFieldValidator>
                    &nbsp;
                    <asp:RegularExpressionValidator ID="reE" runat="server" ErrorMessage="电子邮件格式不正确" ControlToValidate="Email" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="AddBtn" runat="server" Height="29px" Text="注册" Width="96px" OnClick="AddBtn_Click" />
                </td>
                <td>
                    <asp:Button ID="ReturnBtn" runat="server" Height="29px" Text="返回" Width="96px" CausesValidation="False" OnClick="ReturnBtn_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
