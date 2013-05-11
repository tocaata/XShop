<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="User_Search" Title="User Search" %>
<%@ Register Src="../UserControl/Goods.ascx" TagName="GoodsDiff" TagPrefix="uc6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" runat="Server">
<uc6:GoodsDiff ID="GoodsControl" runat="server" />
</asp:Content>