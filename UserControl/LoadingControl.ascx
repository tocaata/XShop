<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoadingControl.ascx.cs"
  Inherits="LoadingControl" %>
<table class="change_account" style="border: 1px solid #2E9AFE;margin-top: 5px;width: 228px; height: 117px" cellpadding="0" cellspacing="0" runat="server" id="tabLoading">
  <tr>
    <td align="center" valign="top" style="height: 117px; width: 228px;">
      <table style="width: 178px; height: 90px; font-size: 9pt;">
        <tr style="width: 152px; height: auto; font-size: 9pt;">
          <td style="width: 160px" align="left">
            会员名：
          </td>
          <td>
            <asp:TextBox ID="txtName" runat="server" Width="101px"></asp:TextBox>
          </td>
        </tr>
        <tr style="width: 152px; font-size: 9pt;">
          <td align="left">
            密  码：
          </td>
          <td style="width: 158px">
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="101px"></asp:TextBox>
          </td>
        </tr>
        <tr style="width: 152px; font-size: 9pt; font-family: 宋体;">
          <td align="left">
            验证码：
          </td>
          <td style="width: 158px">
            <asp:TextBox ID="txtValid" runat="server" Width="62px"></asp:TextBox>
            <asp:Label ID="lbValid" runat="server" Text="8888" BackColor="Silver" Font-Names="幼圆"></asp:Label>
          </td>
        </tr>
        <tr>
          <td colspan="2">
            &nbsp; &nbsp; &nbsp;
            <asp:Button ID="btnLoad" runat="server" Text="登录" CssClass="login" OnClick="btnLoad_Click" Width="40px"
              CausesValidation="False" /><asp:Button ID="btnRegister" runat="server" Text="注册"
                OnClick="btnRegister_Click" Width="40px" CausesValidation="False" />
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
<table class="change_account" style="border: 1px solid #2E9AFE; margin-top: 5px;width: 228px; height: 117px;
  font-size: 9pt; font-family: 宋体;" runat="server" id="tabLoad" visible="false" border="0"
  cellpadding="0" cellspacing="0">
  <tr>
    <td align="center" valign="top" style="height: 117px; width: 228px;">
      <br />
      <br />
      <table style="width: 178px; height: 50px; font-size: 9pt;">
        <tr>
          <td colspan="2">
            &nbsp; 欢迎客户<u><%=Session["UserName"]%></u>光临！
          </td>
        </tr>
        <tr>
          <td colspan="2">
            &nbsp; &nbsp;&nbsp;
            <asp:HyperLink ID="hpLinkUser" runat="server" NavigateUrl="~/User/UpdateMember.aspx">更新信息</asp:HyperLink>
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
