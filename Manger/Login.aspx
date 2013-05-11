<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminManage_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>管理员登录</title>
  <style>
    body
    {
      margin-top: 0px;
    }
  </style>
</head>
<body style="text-align: center">
  <form id="form1" runat="server">
  <div style="width: 455px; height: 255px;">
    <br />
    <br />
    <br />
    <br />
    <br />
    <table style="width: 256px; height: 86px; font-size: 9pt;" border="0" cellpadding="0"
      cellspacing="0" align="center">
      <tr style="width: 152px; height: 18px;" valign="top">
        <td style="width: 263px" align="right">
          管理员姓名：
        </td>
        <td style="width: 113px">
          <asp:TextBox ID="txtAdminName" runat="server" Height="12px" Width="101px"></asp:TextBox>
        </td>
        <td style="width: 51px">
        </td>
      </tr>
      <tr style="color: #000000">
        <td style="width: 263px;" valign="top" align="right">
          管理员密码：
        </td>
        <td style="width: 113px;" valign="top">
          <asp:TextBox ID="txtAdminPwd" runat="server" TextMode="Password" Width="101px" Height="12px"></asp:TextBox>
        </td>
        <td style="width: 51px;" valign="top">
        </td>
      </tr>
      <tr style="color: #000000" valign="top">
        <td style="width: 263px" align="right">
          验 &nbsp; 证 &nbsp;码：
        </td>
        <td style="width: 113px">
          <asp:TextBox ID="txtAdminCode" runat="server" Height="12px" Width="101px"></asp:TextBox>
        </td>
        <td style="width: 51px" valign="top">
          &nbsp;
          <asp:Label ID="labCode" runat="server" BackColor="#FFC0FF">8888</asp:Label>
        </td>
      </tr>
      <tr>
        <td colspan="3" style="text-align: center; height: 29px;" align="center">
          &nbsp;<asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" />
          &nbsp;&nbsp;
          <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" CausesValidation="False" />
        </td>
      </tr>
    </table>
    <br />
  </div>
  </form>
</body>
</html>
