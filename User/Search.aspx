<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="User_Search" Title="User Search" %>

<asp:Content ID="search_result" ContentPlaceHolderID="FartherMain" runat="Server">
    <asp:DataList ID="searchResult" runat="server" DataKeyField="item_id" RepeatColumns="4" RepeatDirection="Horizontal">
    <ItemTemplate>
        name:
        <asp:Label ID="nameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"name") %>' />
        <br />
        price:
        <asp:Label ID="priceLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"price") %>' />
        <br />
        description:
        <asp:Label ID="descriptionLabel" runat="server" 
            Text='<%# DataBinder.Eval(Container.DataItem,"description") %>' />
        <br />
        image_url:
        <asp:Label ID="image_urlLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"image_url") %>' />
        <br />
        quota:
        <asp:Label ID="quotaLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"quota") %>' />
        <br />
        sell_count:
        <asp:Label ID="sell_countLabel" runat="server" 
            Text='<%# DataBinder.Eval(Container.DataItem,"sell_count") %>' />
        <br />
        is_discount:
        <asp:Label ID="is_discountLabel" runat="server" 
            Text='<%# DataBinder.Eval(Container.DataItem,"is_discount") %>' />
        <br />
        is_group_buy:
        <asp:Label ID="is_group_buyLabel" runat="server" 
            Text='<%# DataBinder.Eval(Container.DataItem,"is_group_buy") %>' />
        <br />
        is_rush_buy:
        <asp:Label ID="is_rush_buyLabel" runat="server" 
            Text='<%# DataBinder.Eval(Container.DataItem,"is_rush_buy") %>' />
        <br />
<br />
    </ItemTemplate>
</asp:DataList>
</asp:Content>