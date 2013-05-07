<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="OrderItems.aspx.cs" Inherits="User_OrderItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" runat="Server">
<asp:repeater id="OrderItems" runat="server" onitemcommand="RepCmd">
<HeaderTemplate>
<table class="tb_void" width="100%">
<thead>
<tr class="tb_void">
<th>订单编号</th>
<th>订单状态</th>
<th>收货人</th>
<th>收货地址</th>
<th>订单金额</th>
</tr>
</thead>
</HeaderTemplate>
<ItemTemplate >
<tr class="tb_void">
<td>
<%# Eval("order_id")%>
<br />
<%# Eval("create_at")%>
<br />
</td>
<td>
<%# Eval("status")%>
</td>
<td>
<%# Eval("name") %>
</td>
<td>
<%# Eval("address") %>
</td>
<td>
￥<%# Eval("total_price")%>
</td>
</tr>
</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>
</asp:repeater>
</asp:Content>