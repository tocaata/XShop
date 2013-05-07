<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="User_Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" runat="Server">
    <asp:Label ID="lblTitleInfo" runat="server">订单</asp:Label>
    <br />
    <asp:GridView ID="OrderList" CssClass="table_cart" DataKeyNames="order_item_id" runat="server" AllowPaging="True"
        AutoGenerateColumns="False" PageSize="5" OnPageIndexChanging="gvShopCart_PageIndexChanging">
        <Columns>
            <asp:HyperLinkField DataTextField="name" HeaderText="商品名称" 
                DataNavigateUrlFields="item_id" 
                DataNavigateUrlFormatString="~/User/GoodsDetail.aspx?GoodsID={0}" />
            <asp:BoundField DataField="price" HeaderText="单价" ReadOnly="True">
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="count" HeaderText="购买数量"  ReadOnly="True">
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="sum_price" HeaderText="金额小计" ReadOnly="True">
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <br style="clear: both" />
    合计： &nbsp; &nbsp;
    <div class="right_div">
    <asp:Label ID="lbSumPrice" runat="server" Text="Label"></asp:Label>￥  
    <br />
    商品数量：
    <asp:Label ID="lbSumNum" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>