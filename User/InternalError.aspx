<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="InternalError.aspx.cs" Inherits="InternalError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" runat="Server">
  <div style="background: #FFFFE3;border: 1px solid #E7D3B8; display: block">
    <b class="icon_error" 
      style="margin-left: 20px;width: 48px;height: 48px;display: inline-block;background: url('~/Images/index/icon48x48.png') no-repeat -50px 0; position: relative; top: -30px"></b>
    <div style="display:inline-block; margin-left: 20px">
      <h3 style="color: Red">非常抱歉，服务器发生内部错误。</h3>
      <p>您可以：</p>
      <a href="index.aspx">返回首页</a>
    </div>
  </div>
</asp:Content>