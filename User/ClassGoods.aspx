<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
  CodeFile="ClassGoods.aspx.cs" Inherits="User_ClassGoods" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" runat="Server">
  <table style="font-size: 9pt;">
    <tr>
      <td align="left" style="width: 560px; height: 19px;" background="../Images/index/名字空白.JPG">
        &nbsp;&nbsp; &nbsp;<asp:Label ID="lbClassName" runat="server" Text="Label" Font-Names="宋体"
          Font-Bold="True"></asp:Label>
      </td>
    </tr>
    <tr>
      <td align="left" style="width: 560px;">
        <asp:DataList ID="DLClass" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
          DataKeyField="item_id" OnItemCommand="DLClass_ItemCommand">
          <ItemTemplate>
            <table align="left" cellpadding="0" cellspacing="0" class="good_list">
              <tr align="center" style="width: 135px; height: 65px; font-size: 9pt;">
                <td colspan="2">
                  <asp:Image ID="imageRefine" CssClass="item_image" runat="server" ImageUrl='<%#Eval("image_url")%>' />
                </td>
              </tr>
              <tr align="center" valign="bottom" style="width: 135px; height: 11px; font-size: 9pt;">
                <td colspan="2" align="center">
                  <%#Eval("name")%>
                </td>
              </tr>
              <tr align="center" valign="bottom" style="width: 135px; height: 11px; font-size: 9pt;">
                <td>
                  <span align="center">价格 </span>
                  <span align="center"><strong>￥<%#GetVarMKP(Eval("price").ToString())%></strong>
                  </span>
                </td>
              </tr>
              <tr align="center" style="width: 135px; height: 11px; font-size: 9pt;">
                <td>
                  已卖/库存:
                  <br />
                  <span align="center">
                    <%#Eval("sell_count")%>/<%#Eval("quota")%>
                  </span>
                </td>
              </tr>
              <tr align="center" valign="bottom" style="width: 135px; height: 11px; font-size: 9pt;">
                <td colspan="2" align="center">
                  <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee">详细</asp:LinkButton>
                  <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandName="buyGoods" CommandArgument='<%#Eval("price") %>'>购买</asp:LinkButton>
                </td>
              </tr>
            </table>
          </ItemTemplate>
        </asp:DataList>
      </td>
    </tr>
  </table>
</asp:Content>
