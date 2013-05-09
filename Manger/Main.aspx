<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Manger_Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>管理员主页</title>
</head>
<body style="font-size: 9 pt; font-family: 宋体">
  <form id="form1" runat="server">
  <div>
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" height="600"
      bgcolor="#ffffff">
      <tr>
        <td valign="top" width="30%">
          <table width="50%">
            <tr>
              <td valign="middle">
                <img src="../Images/icons_orders.gif"><b><font size="2"><a href="OrderList.aspx?OrderList=00"
                  target="right">订单信息</a></font></b>
              </td>
            </tr>
            <tr>
              <td>
                <asp:GridView ID="gvOrderList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                  DataKeyNames="order_id" Width="100%" HorizontalAlign="Center" BorderWidth="1" BorderColor="#CCCCCC"
                  BackColor="#EDF6FF" Font-Size="Small" PageSize="5" OnPageIndexChanging="gvOrderList_PageIndexChanging">
                  <HeaderStyle BackColor="#E4E3E1"></HeaderStyle>
                  <Columns>
                    <asp:TemplateField HeaderText="单号">
                      <ItemStyle HorizontalAlign="Center" />
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemTemplate>
                        <a href='OrderModify.aspx?OrderID=<%# DataBinder.Eval(Container.DataItem, "order_id") %>'>
                          <%# DataBinder.Eval(Container.DataItem, "order_id") %>
                        </a>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="create_at" HeaderText="下订单时间" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                      <ItemStyle HorizontalAlign="Center" />
                      <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="购物会员">
                      <ItemStyle HorizontalAlign="Center" />
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemTemplate>
                        <%#GetMemberName(Convert.ToInt32(DataBinder.Eval(Container.DataItem,"user_id").ToString()))%>
                      </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
                </asp:GridView>
              </td>
            </tr>
            <tr>
              <td valign="middle">
                <img src="../Images/icons_customers.gif"><b><font size="2"><a href="Manager.aspx">会员信息</a></font></b>
              </td>
            </tr>
            <tr>
              <td>
                <asp:GridView ID="gvMember" runat="server" AutoGenerateColumns="False" DataKeyNames="user_id"
                  Width="100%" HorizontalAlign="Center" BorderWidth="1px" BorderColor="#CCCCCC" BackColor="#EDF6FF"
                  Font-Size="Small" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvMember_PageIndexChanging">
                  <HeaderStyle BackColor="#E4E3E1"></HeaderStyle>
                  <Columns>
                    <asp:TemplateField HeaderText="会员帐号">
                      <ItemStyle HorizontalAlign="Center" />
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemTemplate>
                        <a href='Manager.aspx?MemberID=<%# DataBinder.Eval(Container.DataItem, "user_id") %>'>
                          <%# DataBinder.Eval(Container.DataItem, "name")%>
                        </a>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="真实姓名">
                      <ItemStyle HorizontalAlign="Center" />
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemTemplate>
                        <a href='Manager.aspx?MemberID=<%# DataBinder.Eval(Container.DataItem, "user_id") %>'>
                          <%# DataBinder.Eval(Container.DataItem, "true_name")%>
                        </a>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="create_at" HeaderText="注册时间" DataFormatString="{0:yyyy-MM-dd}">
                      <ItemStyle HorizontalAlign="Center" />
                      <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                  </Columns>
                </asp:GridView>
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </div>
  </form>
</body>
</html>
