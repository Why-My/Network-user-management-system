<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="网络用户管理系统.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
        .auto-style2 {
            height: 20px;
            width: 257px;
        }
        .auto-style3 {
            width: 257px;
        }
        .auto-style4 {
            height: 20px;
            width: 232px;
        }
        .auto-style5 {
            width: 232px;
        }
        .auto-style6 {
            width: 369px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <div style="height: 465px">
    
        <table style="width:100%;">
            <caption>
                用户管理系统</caption>
            <tr>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 用户名</td>
                <td class="auto-style4">&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:RequiredFieldValidator ID="RfvUsername" runat="server" ErrorMessage="用户名不能为空" ControlToValidate="UserName" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 密码</td>
                <td class="auto-style5">&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="Password" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvPassword" runat="server" ErrorMessage="密码不能为空" ControlToValidate="PassWord"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 验证码</td>
                <td class="auto-style5">&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="Validator" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" Height="27px" Width="80px" />
                    <asp:RequiredFieldValidator ID="RfvImage" runat="server" ErrorMessage="验证码不能为空" ControlToValidate="Validator"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="登录" Width="78px" OnClick="Button1_Click" />
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="取消" Width="83px" OnClick="Button2_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
