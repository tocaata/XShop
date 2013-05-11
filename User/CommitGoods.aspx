<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="CommitGoods.aspx.cs" Inherits="User_CommitGoods" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" runat="Server">
<div class="title"><asp:Label ID="lblTitleInfo" runat="server">购物车</asp:Label></div>
    
    <br />
    <asp:GridView ID="gvShopCart" CssClass="table_cart" 
      DataKeyNames="order_item_id" runat="server" AllowPaging="True"
        AutoGenerateColumns="False" PageSize="5" OnPageIndexChanging="gvShopCart_PageIndexChanging"
        OnRowCancelingEdit="gvShopCart_RowCancelingEdit" OnRowDeleting="gvShopCart_RowDeleting"
        OnRowEditing="gvShopCart_RowEditing"
      OnRowUpdating="gvShopCart_RowUpdating" CellPadding="4" ForeColor="#333333" 
      GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:HyperLinkField DataTextField="name" HeaderText="商品名称" 
                DataNavigateUrlFields="item_id" 
                DataNavigateUrlFormatString="~/User/GoodsDetail.aspx?GoodsID={0}" />
            <asp:BoundField DataField="price" HeaderText="单价" ReadOnly="True">
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="count" HeaderText="购买数量">
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="sum_price" HeaderText="金额小计" ReadOnly="True">
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:CommandField ShowEditButton="True" EditText="编辑" UpdateText="保存" CancelText="取消" />
            <asp:CommandField ShowDeleteButton="True" DeleteText="删除" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
    <asp:Label ID="lbLag" runat="server" Text="现购物车为空" Visible="False"></asp:Label>
    <br style="clear: both" />
    合计： &nbsp; &nbsp;
    <div class="right_div">
    <asp:Label ID="lbSumPrice" runat="server" Text="Label"></asp:Label>￥  
    <br />
    商品数量：
    <asp:Label ID="lbSumNum" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:LinkButton ID="lnkbtnClear" runat="server" OnClick="lnkbtnClear_Click">清空购物车</asp:LinkButton>
    <asp:LinkButton ID="lnkbtnContinue" runat="server" OnClick="lnkbtnContinue_Click">继续购物</asp:LinkButton>
    <asp:LinkButton ID="lnkbtnCheck" runat="server" OnClick="lnkbtnCheck_Click">结账</asp:LinkButton>
    </div>
</asp:Content>
