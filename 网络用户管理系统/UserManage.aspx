<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="网络用户管理系统.UserManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 324px">
    <table>
        <tr>
            <td>
        <asp:GridView ID="UserView" runat="server" AutoGenerateColumns="False" BackColor="#CCFFFF" BorderColor="#66CCFF" BorderWidth="1px" CellPadding="4" Height="186px" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" Width="762px"   >
            <Columns>
             <asp:TemplateField HeaderText="用户名称" >
                    <ItemTemplate>
                        <a href='ViewUser.aspx?UserID=<%#DataBinder.Eval(Container.DataItem,"UserID") %>'>
                            <%#DataBinder.Eval(Container.DataItem,"UserName") %>
                        </a>
                     </ItemTemplate><ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                 
             <asp:TemplateField HeaderText="电子邮件" >
                    <ItemTemplate>
                        <a href='mailto:<%#DataBinder.Eval(Container.DataItem,"Email") %>'>
                            <%#DataBinder.Eval(Container.DataItem,"Email") %>
                        </a>
                    </ItemTemplate><ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

             <asp:TemplateField HeaderText="是否为管理员" >
                    <ItemTemplate>
                        <asp:CheckBox ID="IsAdminCheck" runat="server" Enabled="false" Checked='<%#DataBinder.Eval(Container.DataItem,"IsAdmin") %>' />
                        </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" />
                 <HeaderStyle HorizontalAlign="Center" />
                 <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>

             <asp:TemplateField HeaderText="用户操作" >
                    <ItemTemplate>
                        <a href='EditUser.aspx?UserID=<%#DataBinder.Eval(Container.DataItem,"UserID") %>'>
                          编辑
                        </a>&nbsp&nbsp&nbsp;
                        <a href='EditPwd.aspx?UserID=<%#DataBinder.Eval(Container.DataItem,"UserID") %>'>
                            修改密码
                        </a>&nbsp&nbsp&nbsp;
                        <asp:ImageButton ID="DeleteBtn" runat="server" CommandName="delete" ImageUrl="~/Resources/Image2.bmp" AlternateText="删除该用户" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"UserID") %>' />
                    </ItemTemplate><ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

             <asp:TemplateField HeaderText="管理员设置">
                    <ItemTemplate>
                        <asp:Button ID="SetAdminBtn" CommandName="admin" Width="120" Text='<%#(bool)DataBinder.Eval(Container.DataItem,"IsAdmin")==true?"取消管理员权限":"设置为管理员" %>'  runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"UserID") %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

            </Columns>

            <AlternatingRowStyle BorderColor="#66ccff" />
            <FooterStyle BackColor="#FFFF99" ForeColor="#33CCFF" />
            <HeaderStyle BackColor="#3366FF" CssClass="&quot;GbText&quot;" Font-Bold="True" ForeColor="#99FFCC" />
            <RowStyle BorderColor="#FFFFCC" BorderStyle="Solid" ForeColor="#CCFFFF" />
            <SelectedRowStyle BackColor="#FFCCCC" BorderColor="#FFCC99" Font-Bold="True" ForeColor="#FFFFCC" />

        </asp:GridView>
           </td>
      </tr>
        <tr>
            <td>
        <br />
       
             <asp:Button ID="AddBtn" runat="server" Text="添加新用户" width="160" OnClick="AddBtn_Click"/>
           </td>
       </tr>
    </table>
        </div>
    </form>
</body>
</html>
