<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditProduct.aspx.cs" Inherits="Manger_EditProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <link rel="stylesheet" href="../main.css" type="text/css" />
  <title>无标题页</title>
</head>
<body style="font-family: 宋体; font-size: 9pt;">
  <form id="form1" runat="server">
  <div align="center">
    <table cellspacing="0" cellpadding="0" width="480" align="center" border="0">
      <tr>
        <th align="left" height="25" colspan="2">
          &nbsp;&nbsp;
          <asp:Label ID="lblTitleInfo" runat="server">商品详细信息</asp:Label>
        </th>
    </table>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BackColor="White"
      BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="item_id"
      DataSourceID="ProductDetails" CssClass="update" GridLines="Vertical">
      <AlternatingRowStyle BackColor="#DCDCDC" />
      <Fields>
        <asp:BoundField DataField="item_id" HeaderText="商品ID" InsertVisible="False" ReadOnly="True"
          SortExpression="item_id" />
        <asp:BoundField DataField="name" HeaderText="商品名" SortExpression="name" />
        <asp:BoundField DataField="price" HeaderText="价格" SortExpression="price" DataFormatString="￥{0}" />
        <asp:BoundField DataField="description" HeaderText="商品描述" SortExpression="description" />
        <asp:BoundField DataField="create_at" HeaderText="添加时间" SortExpression="create_at" />
        <asp:BoundField DataField="image_url" HeaderText="图像" SortExpression="image_url" />
        <asp:BoundField DataField="quota" HeaderText="库存量" SortExpression="quota" />
        <asp:BoundField DataField="sell_count" HeaderText="总销售量" SortExpression="sell_count" />
        <asp:BoundField DataField="cat_id" HeaderText="类别ID" SortExpression="cat_id" />
        <asp:CheckBoxField DataField="is_discount" HeaderText="是否打折" 
          SortExpression="is_discount" ReadOnly="True" />
        <asp:BoundField DataField="cat_name" HeaderText="商品类别名" 
          SortExpression="cat_name" ReadOnly="True" />
        <asp:CommandField ShowEditButton="True" EditText="修改" CancelText="取消" 
          UpdateText="提交"/>
      </Fields>
      <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
      <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
      <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
      <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="ProductDetails" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
      SelectCommand="SELECT items.*, categories.name AS cat_name FROM items JOIN categories ON items.cat_id = categories.category_id WHERE items.item_id = @item_id"
      
      UpdateCommand="UPDATE items SET items.name = @name, price = @price, description = @description , sell_count = @sell_count, quota = @quota, cat_id = @cat_id WHERE items.item_id = @item_id">
      <SelectParameters>
        <asp:QueryStringParameter DefaultValue="-1" Name="item_id" QueryStringField="GoodsID"
          Type="Int32" />
      </SelectParameters>
      <UpdateParameters>
        <asp:Parameter Name="name" Type="String" />
        <asp:Parameter Name="price" Type="String" />
        <asp:Parameter Name="description" Type="String" />
        <asp:Parameter Name="sell_count" Type="Int32" />
        <asp:Parameter Name="quota" Type="Int32" />
        <asp:Parameter Name="cat_id" Type="Int32" />
        <asp:Parameter Name="item_id" Type="Int32" />
      </UpdateParameters>
    </asp:SqlDataSource>
  </div>
  </form>
</body>
</html>
