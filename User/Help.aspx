<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Help.aspx.cs" Inherits="User_Help" Title="Untitled Page" %>

<%@ Register Src="../UserControl/Help.ascx" TagName="Help" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server">
    <uc1:Help ID="Help1" runat="server" />
</asp:Content>

