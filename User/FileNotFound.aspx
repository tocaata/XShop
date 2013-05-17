<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="FileNotFound.aspx.cs" Inherits="User_FileNotFound" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" runat="Server">
  <div style="background: #FFFFE3;border: 1px solid #E7D3B8; display: block">
    <b class="icon_error" style="margin-left: 20px;width: 48px;height: 48px;display: inline-block;background: url(~/Images/index/icon48x48.png) no-repeat;background-position: -50px 0; position: relative; top: -60px"></b>
    <div style="display:inline-block; margin-left: 20px">
      <h3 style="color: Red">非常抱歉，商品或页面没有找到。</h3>
  
      <p>您浏览的页面暂时无法显示。这可能是因为输入的网址不正确或网页已经过期。</p>
      <p>您可以：</p>
      <a href="index.aspx">返回首页</a>
    </div>
  </div>
</asp:Content>