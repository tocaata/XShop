<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
  CodeFile="index.aspx.cs" Inherits="index" Title="User Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" runat="Server">
  <table cellpadding="0" cellspacing="0" style="font-size: 9pt; width: 560px; vertical-align: top;
    border-top-style: none; border-right-style: none; border-left-style: none; text-align: left;
    border-bottom-style: none;">
    <tr align="left">
      <td align="left" style="width: 560px; height: 22px; vertical-align: top; text-align: left;"
        colspan="0" rowspan="0">
        <span class="name">精品推荐</span>
        <span class="name_en">Refinement</span>
      </td>
    </tr>
    <tr>
      <td align="left" style="width: 560px;">
        <asp:DataList ID="DLrefinement" DataKeyField="item_id" runat="server" RepeatColumns="5"
          RepeatDirection="Horizontal" OnItemCommand="DLrefinement_ItemCommand" 
          CellPadding="4" ForeColor="#333333">
          <AlternatingItemStyle BackColor="White" />
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <ItemStyle BackColor="#EFF3FB" />
          <ItemTemplate>
            <table align="left" cellpadding="0" cellspacing="0" class="good_list">
              <tr align="center" style="width: 135px; height: 65px;">
                <td colspan="2" align="center">
                  <asp:Image ID="imageRefine" CssClass="item_image" runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem,"image_url")%>' />
                </td>
              </tr>
              <tr align="center" valign="bottom" style="width: 135px; height: 11px; font-size: 9pt;">
                <td colspan="2" align="center">
                  <%#Eval("name")%>
                </td>
              </tr>
              <tr align="center" valign="bottom" style="width: 135px; height: 11px; font-size: 9pt;">
                <td align="center">
                  价格
                </td>
                <td align="left">
                  ￥<%#GetMKPStr(Eval("price").ToString())%></td>
              </tr>
              <tr align="left" valign="bottom" style="width: 135px; height: 11px; font-size: 9pt;">
                <td colspan="2" align="center">
                  <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee">详细</asp:LinkButton>
                  <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandName="buyGoods" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"price") %>'>购买</asp:LinkButton>
                </td>
              </tr>
            </table>
          </ItemTemplate>
          <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:DataList>
      </td>
    </tr>
  </table>
  <table style="font-size: 9pt; font-family: 宋体;" cellpadding="0" cellspacing="0">
    <tr>
      <td align="left" style="width: 560px; height: 22px; vertical-align: top; text-align: left;">
        <span class="name">热销商品</span>
        <span class="name_en">h o t</span>
      </td>
    </tr>
    <tr>
      <td style="width: 560px;" align="left">
        <asp:DataList ID="DLHot" runat="server" DataKeyField="item_id" RepeatColumns="5"
          RepeatDirection="Horizontal" OnItemCommand="DLHot_ItemCommand" 
          CellPadding="4" ForeColor="#333333">
          <AlternatingItemStyle BackColor="White" />
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <ItemStyle BackColor="#EFF3FB" />
          <ItemTemplate>
            <table align="left" cellpadding="0" cellspacing="0" class="good_list">
              <tr align="center" style="width: 135px; height: 65px; font-size: 9pt; font-family: 宋体;">
                <td colspan="2">
                  <asp:Image ID="imageHot" CssClass="item_image" runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem,"image_url")%>' />
                </td>
              </tr>
              <tr align="center" valign="bottom" style="width: 135px; height: 11px; font-size: 9pt;
                font-family: 宋体;">
                <td colspan="2" align="center">
                  <%#Eval("name")%>
                </td>
              </tr>
              <tr align="center" valign="bottom" style="width: 135px; height: 11px; font-size: 9pt;
                font-family: 宋体;">
                <td align="center">
                  价格
                </td>
                <td align="left">
                  ￥<%#GetMKPStr(Eval("price").ToString())%></td>
              </tr>
              <tr align="center" valign="bottom" style="width: 135px; height: 11px; font-size: 9pt;
                font-family: 宋体;">
                <td colspan="2" align="center">
                  <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee">详细</asp:LinkButton>
                  <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandName="buyGoods" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"price") %>'>购买</asp:LinkButton>
                </td>
              </tr>
            </table>
          </ItemTemplate>
          <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:DataList>
      </td>
    </tr>
  </table>
  <table style="font-size: 9pt; font-family: 宋体; vertical-align: top; text-align: left;"
    cellpadding="0" cellspacing="0">
    <tr>
      <td align="left" style="width: 560px; height: 22px;">
        <span class="name">特价商品</span>
        <span class="name_en">At a sale</span>
      </td>
    </tr>
    <tr>
      <td align="left" style="width: 560px;">
        <asp:DataList ID="DLDiscount" runat="server" DataKeyField="item_id" RepeatColumns="5"
          RepeatDirection="Horizontal" OnItemCommand="DLDiscount_ItemCommand" 
          CellPadding="4" ForeColor="#333333">
          <AlternatingItemStyle BackColor="White" />
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <ItemStyle BackColor="#EFF3FB" />
          <ItemTemplate>
            <table align="left" cellpadding="0" cellspacing="0"  class="good_list">
              <tr align="center" valign="bottom" style="width: 135px; height: 65px; font-size: 9pt;
                font-family: 宋体;">
                <td colspan="2">
                  <asp:Image ID="imageDiscount" CssClass="item_image" runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem,"image_url")%>' />
                </td>
              </tr>
              <tr align="center" valign="bottom" style="width: 135px; height: 11px; font-size: 9pt;
                font-family: 宋体;">
                <td colspan="2" align="center">
                  <%#Eval("name")%>
                </td>
              </tr>
              <tr align="center" valign="bottom" style="width: 135px; height: 11px; font-size: 9pt;
                font-family: 宋体;">
                <td align="center">
                  价格
                </td>
                <td align="left">
                  ￥<%#GetMKPStr(Eval("price").ToString())%></td>
              </tr>
              <tr align="center" valign="bottom" style="width: 135px; height: 11px; font-size: 9pt;
                font-family: 宋体;">
                <td colspan="2" align="center">
                  <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee">详细</asp:LinkButton>
                  <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandName="buyGoods" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"price") %>'>购买</asp:LinkButton>
                </td>
              </tr>
            </table>
          </ItemTemplate>
          <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:DataList>
      </td>
    </tr>
  </table>
</asp:Content>
