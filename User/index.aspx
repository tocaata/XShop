<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
  CodeFile="index.aspx.cs" Inherits="index" Title="User Page" %>

<%@ Register Src="../UserControl/Goods.ascx" TagName="GoodsDiff" TagPrefix="uc6" %>
<%@ Register Src="../UserControl/Goods.ascx" TagName="GoodsDiff2" TagPrefix="uc7" %>
<%@ Register Src="../UserControl/Goods.ascx" TagName="GoodsDiff3" TagPrefix="uc8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" runat="Server">
  <uc6:GoodsDiff ID="GoodsControl" runat="server" />
  <uc7:Goodsdiff2 ID="GoodsControl2" runat="server" />
  <uc8:Goodsdiff3 ID="GoodsControl3" runat="server" />
</asp:Content>
