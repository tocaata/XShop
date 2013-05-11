<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Goods.ascx.cs" Inherits="UserControl_Goods" %>
<div align="left" style="width: 760px; height: 19px; border-bottom: 2px #d0d0d0 solid;">
  <span class="name">
    <asp:Label ID="lbClassName" runat="server" Text="Label"></asp:Label></span>
</div>
<asp:DataList ID="DLClass" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
  DataKeyField="item_id" OnItemCommand="DLClass_ItemCommand">
  <ItemTemplate>
    <table align="left" cellpadding="0" cellspacing="0" class="good_list change_account">
      <tr align="center" valign="bottom" style="width: 240px; height: 11px; font-size: 9pt;">
        <td style="font-size: 16px; padding-right: 38px" colspan="2" align="right">
          <%#Eval("name")%>
        </td>
      </tr>
      <tr align="center" style="width: 240px; height: 86px; font-size: 9pt;">
        <td rowspan="6">
          <asp:Image ID="imageRefine" CssClass="item_image" runat="server" ImageUrl='<%#Eval("image_url")%>' />
        </td>
      </tr>
      
      <tr align="center" valign="bottom" style="width: 240px; height: 45px; font-size: 9pt; padding-bottom: 5px;">
        <td>
          <span>价格￥</span> <span class="price"><strong>
            <%#GetVarMKP(Eval("price").ToString())%></strong></span>
        </td>
      </tr>
      <tr align="center" style="width: 240px; height: 45px; font-size: 9pt; padding-bottom: 5px;">
        <td>
          已卖/库存:
          <br />
          <span align="center">
            <%#Eval("sell_count")%>/<%#Eval("quota")%></span>
        </td>
      </tr>
      <tr align="center" valign="bottom" style="width: 240px; height: 45px; font-size: 9pt; padding-bottom: 5px;">
        <td colspan="2" align="center">
          <asp:LinkButton ID="lnkbtnClass" CssClass="top_lnk" runat="server" CommandName="detailSee">详细</asp:LinkButton>
          <asp:LinkButton ID="lnkbtnBuy" CssClass="buy" runat="server" CommandName="buyGoods"
            CommandArgument='<%#Eval("price") %>'>购买</asp:LinkButton>
        </td>
      </tr>
    </table>
  </ItemTemplate>
</asp:DataList>