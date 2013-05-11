<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
  CodeFile="ClassGoods.aspx.cs" Inherits="User_ClassGoods" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" runat="Server">
  <table style="font-size: 9pt;">
    <tr>
      <td align="left" style="width: 760px; height: 19px; border-bottom: 2px #d0d0d0 solid;">
        <span class="name"><asp:Label ID="lbClassName" runat="server" Text="Label"></asp:Label></span>
      </td>
    </tr>
    <tr>
      <td align="left" style="width: 760px;">
        <asp:DataList ID="DLClass" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
          DataKeyField="item_id" OnItemCommand="DLClass_ItemCommand">
          <ItemTemplate>
            <table align="left" cellpadding="0" cellspacing="0" class="good_list change_account">
              <tr align="center" style="width: 240px; height: 86px; font-size: 9pt;">
                <td rowspan="6">
                  <asp:Image ID="imageRefine" CssClass="item_image" runat="server" ImageUrl='<%#Eval("image_url")%>' />
                </td>
              </tr>
              <tr align="center" valign="bottom" style="width: 240px; height: 11px; font-size: 9pt;">
                <td align="center">
                  <%#Eval("name")%>
                </td>
              </tr>
              <tr align="center" valign="bottom" style="width: 240px; height: 11px; font-size: 9pt;">
                <td>
                  <span align="center">价格￥</span>
                  <span align="center" class="price"><strong><%#GetVarMKP(Eval("price").ToString())%></strong></span></td>
              </tr>
              <tr align="center" style="width: 240px; height: 11px; font-size: 9pt;">
                <td>
                  已卖/库存:
                  <br />
                  <span align="center">
                    <%#Eval("sell_count")%>/<%#Eval("quota")%></span></td>
              </tr>
              <tr align="center" valign="bottom" style="width: 240px; height: 11px; font-size: 9pt;">
                <td colspan="2" align="center">
                  <asp:LinkButton ID="lnkbtnClass" CssClass="top_lnk" runat="server" CommandName="detailSee">详细</asp:LinkButton>
                  <asp:LinkButton ID="lnkbtnBuy" CssClass="buy" runat="server" CommandName="buyGoods" CommandArgument='<%#Eval("price") %>'>购买</asp:LinkButton>
                </td>
              </tr>
            </table>
          </ItemTemplate>
        </asp:DataList>
      </td>
    </tr>
  </table>
</asp:Content>
