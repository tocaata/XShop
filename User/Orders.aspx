<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
  CodeFile="Orders.aspx.cs" Inherits="User_Orders" Title="User Order List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FartherMain" runat="Server">
  <h3 style="text-align: center">
    订单列表</h3>
  <br />
  <asp:Repeater ID="Orders" runat="server" OnItemCommand="RepCmd">
    <HeaderTemplate>
      <table class="tb_void change_account" width="100%" align="center">
        <thead>
          <tr class="tb_void">
            <th>
              订单编号
            </th>
            <th>
              订单状态
            </th>
            <th>
              收货人
            </th>
            <th>
              收货地址
            </th>
            <th>
              订单金额
            </th>
            <th>
              操作
            </th>
          </tr>
        </thead>
    </HeaderTemplate>
    <ItemTemplate>
      <tr class="tb_void">
        <td>
          <asp:HyperLink ID="OrderID" runat="server" NavigateUrl='<%# "OrderItems.aspx?order_id=" + Eval("order_id") %>'><%# Eval("order_id")%></asp:HyperLink>
          <br />
          <%# Eval("create_at")%>
          <br />
        </td>
        <td>
          <%# StatusToString(Convert.ToInt32(Eval("status"))) %>
        </td>
        <td>
          <%# Eval("name") %>
        </td>
        <td>
          <%# Eval("address") %>
        </td>
        <td>
          ￥<%# Eval("total_price") %></td>
        <td>
          <asp:LinkButton ID="LnkBtnConfirm" runat="server" CommandName="confirm" CssClass="lnk_btn" Visible='<%# Convert.ToInt32(Eval("status")) == 3 ? true : false %>'
            CommandArgument='<%# Eval("order_id") %>'>确认收货</asp:LinkButton>
          <asp:LinkButton ID="LinkButtonReturn" runat="server" CommandName="return" CssClass="lnk_btn" Visible='<%# Convert.ToInt32(Eval("status")) == 4 ? true : false %>'
            CommandArgument='<%# Eval("order_id") %>'>退货</asp:LinkButton>
        </td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      </table>
    </FooterTemplate>
  </asp:Repeater>
</asp:Content>
