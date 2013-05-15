<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Manger_Product" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>无标题页</title>
</head>
<body style="font-family: 宋体; font-size: 9pt;">
  <form id="form1" runat="server">
  <div>
    <table cellspacing="0" cellpadding="0" width="640" align="center" border="0">
      <tr>
        <th class="tableHeaderText" height="25" align="left">
          &nbsp;&nbsp; 商品管理
        </th>
      </tr>
    </table>
    <table cellspacing="0" cellpadding="0" width="640" align="center" border="0">
      <tr>
        <td align="center">
          搜索：&nbsp;
          <asp:TextBox ID="txtKey" runat="server"></asp:TextBox>&nbsp;
          <asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click"></asp:Button>&nbsp;
          &nbsp; &nbsp; &nbsp; &nbsp;
        </td>
      </tr>
      <tr>
        <td>
          <br />
          <asp:GridView ID="gvGoodsInfo" runat="server" CellPadding="4" Width="100%" HorizontalAlign="Center"
            DataKeyNames="item_id" HeaderStyle-CssClass="summary-title" AutoGenerateColumns="False"
            OnPageIndexChanging="gvGoodsInfo_PageIndexChanging" OnRowDeleting="gvGoodsInfo_RowDeleting"
            AllowPaging="True" PageSize="5">
            <HeaderStyle Font-Bold="True" CssClass="summary-title"></HeaderStyle>
            <Columns>
              <asp:BoundField DataField="item_id" HeaderText="商品ID">
                <ItemStyle HorizontalAlign="Center" />
              </asp:BoundField>
              <asp:BoundField DataField="name" HeaderText="商品名称">
                <ItemStyle HorizontalAlign="Center" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="商品类别">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                  <%# Eval("cat_name")%>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="商品价格">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                  <%# GetVarStr(Eval("price").ToString())%>￥
                </ItemTemplate>
              </asp:TemplateField>
              <asp:CheckBoxField DataField="deleted" HeaderText="是否下架" />
              <asp:HyperLinkField HeaderText="详细信息" Text="详细信息" DataNavigateUrlFields="item_id"
                DataNavigateUrlFormatString="EditProduct.aspx?GoodsID={0}">
                <ControlStyle Font-Underline="False" ForeColor="Black" />
                <ItemStyle HorizontalAlign="Center" />
              </asp:HyperLinkField>
              <asp:CommandField HeaderText="删除" ShowDeleteButton="True">
                <ControlStyle Font-Underline="False" ForeColor="Black" />
                <ItemStyle HorizontalAlign="Center" />
              </asp:CommandField>
            </Columns>
          </asp:GridView>
        </td>
      </tr>
    </table>
  </div>
  </form>
</body>
</html>
