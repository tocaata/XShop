<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserStatistics.aspx.cs" Inherits="Manger_UserStatistics" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>无标题页</title>
</head>
<body style="font-family: 宋体; font-size: 9pt;">
  <form id="form1" runat="server">
  <div>
    <table cellspacing="0" cellpadding="0" width="640" align="center" border="0">
      <tr>
        <th class="tableHeaderText" height="25" align="left">
          <span style="">商品销售统计</span>
        </th>
      </tr>
    </table>
    <table cellspacing="0" cellpadding="0" width="640" align="center" border="0">
      <tr>
        <br />
      </tr>
      <tr>
        <td>

          <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="user_id" 
            DataSourceID="Users">
            <Columns>
              <asp:BoundField DataField="user_id" HeaderText="用户ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="user_id" />
              <asp:BoundField DataField="name" HeaderText="用户名" SortExpression="name" />
              <asp:BoundField DataField="count" HeaderText="购买商品总量" ReadOnly="True" 
                SortExpression="count" />
              <asp:BoundField DataField="total_price" HeaderText="购买商品总额" ReadOnly="True" 
                SortExpression="total_price" />
            </Columns>
          </asp:GridView>
          <asp:SqlDataSource ID="Users" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT users.user_id, users.name, SUM(order_items.count) AS count, SUM(order_items.count * order_items.price) AS total_price FROM users JOIN orders ON orders.user_id = users.user_id JOIN order_items ON order_items.order_id = orders.order_id LEFT JOIN carts ON carts.order_id = orders.order_id WHERE orders.status > 3 AND carts.cart_id IS NULL  GROUP BY users.user_id, users.name">
          </asp:SqlDataSource>

          <br />
        </td>
      </tr>
    </table>
  </div>
  </form>
</body>
</html>