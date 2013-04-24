<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ClassGoods.aspx.cs" Inherits="User_ClassGoods" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" runat="Server">
    <table style="font-size: 9pt; ">
        <tr>
            <td align="left" style="width: 560px; height: 19px;" background="../Images/index/名字空白.JPG">
                &nbsp;&nbsp; &nbsp;<asp:Label ID="lbClassName" runat="server" Text="Label" Font-Names="宋体"
                    Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 560px;" background="../Images/index/产品展销---最底部.jpg">
                <asp:DataList ID="DLClass" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                    DataKeyField="item_id" OnItemCommand="DLClass_ItemCommand">
                    <ItemTemplate>
                        <table align="left" cellpadding="0" cellspacing="0" style="width: 135px; height: 158px;">
                            <tr align="center" style="width: 135px; height: 65px; font-size: 9pt; ">
                                <td colspan="2">
                                    <asp:Image ID="imageRefine" runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem,"image_url")%>' />
                                </td>
                            </tr>
                            <tr align="center" valign="bottom" style="width: 135px; height: 11px; font-size: 9pt;
                                ">
                                <td colspan="2" align="center">
                                    <%#DataBinder.Eval(Container.DataItem, "name")%>
                                </td>
                            </tr>
                            <tr align="center" valign="bottom" style="width: 135px; height: 11px; font-size: 9pt; ">
                                <td align="center">
                                    价格
                                </td>
                                <td align="left">
                                   <strong>￥<%#GetVarMKP(DataBinder.Eval(Container.DataItem, "price").ToString())%></strong>
                                </td>
                            </tr>
                            <tr align="center" style="width: 135px; height: 11px; font-size: 9pt; ">
                                <td>
                                    已卖/库存: <br /><%#DataBinder.Eval(Container.DataItem, "sell_count")%> / <%#DataBinder.Eval(Container.DataItem, "quota")%>
                                </td>
                            </tr>
                            <tr align="center" valign="bottom" style="width: 135px; height: 11px; font-size: 9pt; ">
                                <td colspan="2" align="left">
                                    &nbsp; &nbsp;
                                    <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee">详细</asp:LinkButton>
                                    <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandName="buyGoods" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"price") %>'>购买</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>
