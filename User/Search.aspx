<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="User_Search" Title="User Search" %>

<asp:Content ID="search_result" ContentPlaceHolderID="FartherMain" runat="Server">
<ul>
    <asp:DataList ID="searchResult" runat="server" DataKeyField="item_id" RepeatColumns="3" RepeatDirection="Horizontal" OnItemCommand="ItemCommand">
    <ItemTemplate>
        <li style="width: 150px; height: 220px; border: 1px solid #d0d0d0; text-align:center">
        <asp:LinkButton ID="lnkbtnItem" runat="server" CommandName="detailSee"><asp:Image ID="image1" runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem,"image_url")%>' /></asp:LinkButton>
        <br />
        名字:
        <asp:Label ID="nameLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"name") %>' />
        <br />
        价格: ￥
        <asp:Label ID="priceLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"price") %>' />
        <br />
        描述:
        <asp:Label ID="descriptionLabel" runat="server" 
            Text='<%# DataBinder.Eval(Container.DataItem,"description") %>' />
        <br />
        库存:
        <asp:Label ID="quotaLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"quota") %>' />
        <br />
        已销售:
        <asp:Label ID="sell_countLabel" runat="server" 
            Text='<%# DataBinder.Eval(Container.DataItem,"sell_count") %>' />
        <br />
        是否打折:
        <asp:Label ID="is_discountLabel" runat="server" 
            Text='<%# Eval("is_discount") %>' />
        <br />
        <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee">详细</asp:LinkButton>
        <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandName="buyGoods" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"price") %>'>购买</asp:LinkButton>
        </li>
    </ItemTemplate>
</asp:DataList>
</ul>
</asp:Content>