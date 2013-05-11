<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
  CodeFile="GoodsDetail.aspx.cs" Inherits="User_GoodsDetail" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" runat="Server">
  <table cellspacing="0" cellpadding="0" width="480" align="center" border="0">
    <tr>
      <th align="left" height="25" colspan="2">
        &nbsp;&nbsp;
        <asp:Label ID="lblTitleInfo" runat="server">商品详细信息</asp:Label>
      </th>
  </table>
  <table cellspacing="1" cellpadding="1" width="480" align="center" border="0">
    <tr>
      <td>
        <table class="tableBorder" cellspacing="0" cellpadding="0" width="95%" align="center"
          border="0">
          <tr>
            <td align="left" style="width: 93px">
              商品名称：
            </td>
            <td style="width: 359px" align="left">
              <asp:TextBox ID="txtName" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td align="left" style="width: 93px">
              父级类别名：
            </td>
            <td style="width: 359px" align="left">
              <asp:TextBox ID="txtFName" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td align="left" height="19" style="width: 93px">
              市场价格：
            </td>
            <td colspan="3" height="19" align="left" style="width: 371px">
              <asp:TextBox ID="txtMarketPrice" runat="server" ReadOnly="True">0</asp:TextBox>￥
            </td>
          </tr>
          <tr>
            <td align="left" style="height: 22px; width: 93px;">
              商品图像：
            </td>
            <td colspan="3" style="height: 22px; width: 371px;" align="left">
              <asp:ImageMap ID="ImageMapPhoto" CssClass="good_detail" runat="server">
              </asp:ImageMap>
            </td>
          </tr>
          <tr>
            <td align="left" style="width: 93px">
              是否打折：
            </td>
            <td colspan="3" align="left" style="width: 371px">
              <asp:CheckBox ID="cbxDiscount" runat="server" Checked="True" AutoPostBack="True"
                Enabled="False"></asp:CheckBox>
            </td>
          </tr>
          <tr>
            <td align="left" style="width: 93px">
              简单描述：
            </td>
            <td style="width: 359px" align="left">
              <asp:TextBox ID="txtShortDesc" runat="server" Width="307px" Height="89px" ReadOnly="True"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td align="center" colspan="4">
              <br>
              <asp:Button ID="btnExit" runat="server" Text="返回" OnClick="btnExit_Click"></asp:Button>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
</asp:Content>
