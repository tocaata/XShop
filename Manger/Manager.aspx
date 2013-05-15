<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manager.aspx.cs" Inherits="Manger_Manager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>无标题页</title>
</head>
<body style="font-family: 宋体; font-size: 9pt;">
  <form id="form1" runat="server">
  <div>
    <table class="tableBorder" cellspacing="0" cellpadding="0" width="650" align="center"
      border="0">
      <tr>
        <th class="tableHeaderText" height="25" align="left">
          管理会员
        </th>
      </tr>
    </table>
    <table class="tableBorder" cellspacing="0" cellpadding="0" width="650" align="center"
      border="0">
      <tr>
        <td align="center">
          搜索：&nbsp;
          <asp:TextBox ID="txtKey" runat="server"></asp:TextBox>&nbsp;
          <asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click"></asp:Button>
          <asp:CheckBox ID="chkDeleted" runat="server" Text="删除的用户"/>
        </td>
      </tr>
      <tr>
        <td height="23">
          <asp:GridView ID="gvMemberList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            PageSize="5" DataKeyNames="user_id" Width="100%" HorizontalAlign="Center" HeaderStyle-CssClass="summary-title"
            OnPageIndexChanging="gvMemberList_PageIndexChanging" OnRowDeleting="gvMemberList_RowDeleting">
            <HeaderStyle Font-Bold="True" CssClass="summary-title"></HeaderStyle>
            <Columns>
              <asp:BoundField DataField="user_id" HeaderText="会员代号" ReadOnly="True">
                <ItemStyle HorizontalAlign="Left" Width="40px" />
                <HeaderStyle HorizontalAlign="center" />
              </asp:BoundField>
              <asp:BoundField DataField="true_name" HeaderText="真实姓名">
                <ItemStyle HorizontalAlign="Left" />
                <HeaderStyle HorizontalAlign="center" />
              </asp:BoundField>
              <asp:BoundField DataField="phone" HeaderText="电话号码">
                <ItemStyle HorizontalAlign="Left" />
                <HeaderStyle HorizontalAlign="center" />
              </asp:BoundField>
              <asp:BoundField DataField="email" HeaderText="会员Email" />
              <asp:BoundField DataField="City" HeaderText="所在城市" />
              <asp:TemplateField HeaderText="详细地址">
                <HeaderStyle HorizontalAlign="center" />
                <ItemStyle HorizontalAlign="left" />
                <ItemTemplate>
                  <%#Eval("address")%>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="加入日期">
                <HeaderStyle HorizontalAlign="center" />
                <ItemStyle HorizontalAlign="left" />
                <ItemTemplate>
                  <%#Convert.ToDateTime(Eval("create_at").ToString()).ToLongDateString()%>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:CommandField ShowDeleteButton="True" DeleteText="删除"/>
            </Columns>
          </asp:GridView>
        </td>
      </tr>
    </table>
  </div>
  </form>
</body>
</html>
