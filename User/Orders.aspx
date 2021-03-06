﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="User_Orders" Title="User Order List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FartherMain" runat="Server">
<h3 style="text-align: center">订单列表</h3>
<br />
<asp:repeater id="Orders" runat="server" onitemcommand="RepCmd">
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
<asp:HyperLink ID="OrderID" runat="server" NavigateUrl='<%# "OrderItems.aspx?order_id=" + DataBinder.Eval(Container.DataItem,"order_id") %>'><%# Eval("order_id")%></asp:HyperLink>
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
￥<%# Eval("total_price")%></td>
</tr>
</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>
</asp:repeater>
</asp:Content>