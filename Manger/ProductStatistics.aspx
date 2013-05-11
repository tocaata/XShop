<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductStatistics.aspx.cs" Inherits="Manger_ProductStatistics" %>

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
          <asp:GridView ID="ProductStat" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="item_id" 
            DataSourceID="Products">
            <Columns>
              <asp:BoundField DataField="item_id" HeaderText="商品ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="item_id" />
              <asp:BoundField DataField="name" HeaderText="商品名" SortExpression="name" />
              <asp:BoundField DataField="total_price" HeaderText="商品销售量" ReadOnly="True" SortExpression="total_price" />
              <asp:BoundField DataField="total_price" HeaderText="商品总价格" 
                ReadOnly="True" SortExpression="total_price" />
            </Columns>
          </asp:GridView>
          <asp:SqlDataSource ID="Products" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT items.item_id, items.name, SUM(order_items.count), SUM(order_items.count * order_items.price) AS total_price FROM items JOIN order_items ON items.item_id = order_items.item_id GROUP BY items.item_id, items.name">
          </asp:SqlDataSource>
          <br />
        </td>
      </tr>
    </table>
  </div>
  </form>
</body>
</html>
