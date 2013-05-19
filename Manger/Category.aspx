<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Manger_Category" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>无标题页</title>
</head>
<body style="font-family: 宋体; font-size: 9pt;">
  <form id="form1" runat="server">
  <div>
    <table class="tableBorder" cellspacing="0" cellpadding="0" width="450" align="center"
      border="0">
      <tr>
        <th class="tableHeaderText" height="25" align="left">
          &nbsp;&nbsp; 商品类别管理
        </th>
      </tr>
      <tr><td>
        <div style="color: Red;"><%= err_msg %></div>
      </td></tr>
    </table>
    <table class="tableBorder" cellspacing="0" cellpadding="0" width="450" align="center"
      border="0">
      <tr>
        <td height="23" class="forumRowHighlight">
          &nbsp;<asp:GridView ID="gvCategoryList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            PageSize="5" DataKeyNames="category_id" Width="100%" HorizontalAlign="Center" HeaderStyle-CssClass="summary-title"
            OnPageIndexChanging="gvCategoryList_PageIndexChanging" OnRowDeleting="gvCategoryList_RowDeleting">
            <HeaderStyle Font-Bold="True"></HeaderStyle>
            <Columns>
              <asp:CheckBoxField DataField="deleted" HeaderText="是否删除">
                <ItemStyle Width="55px" />
              </asp:CheckBoxField>
              <asp:BoundField DataField="category_id" HeaderText="分类ID" ItemStyle-Width="40" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
              </asp:BoundField>
              <asp:BoundField DataField="name" HeaderText="类别名称" ItemStyle-HorizontalAlign="Left"
                HeaderStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
              </asp:BoundField>
              <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="30" ItemStyle-HorizontalAlign="Center">
                <ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
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
