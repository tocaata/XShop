﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
  CodeFile="index.aspx.cs" Inherits="index" Title="User Page" %>

<%@ Register Src="../UserControl/Goods.ascx" TagName="GoodsDiff" TagPrefix="uc6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" runat="Server">
  <uc6:GoodsDiff ID="GoodsControl" runat="server" />
</asp:Content>
