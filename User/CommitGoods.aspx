<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="CommitGoods.aspx.cs" Inherits="User_CommitGoods" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" runat="Server">
    <table cellspacing="0" cellpadding="0" width="480" align="center" border="0">
        <tr style="font: 9pt; ">
            <th align="left" height="25" colspan="2">
                &nbsp;&nbsp;
                <asp:Label ID="lblTitleInfo" runat="server">购物车</asp:Label>
            </th>
            <tr>
            </tr>
    </table>
    <table cellspacing="1" cellpadding="1" width="480" align="center" border="0">
        <tr style="font: 9pt; ">
            <td>
                <table cellspacing="0" cellpadding="0" width="95%" align="center" border="0">
                    <tr style="font: 9pt; ">
                        <td align="left" style="height: 135px">
                            <asp:GridView ID="gvShopCart" DataKeyNames="order_item_id" runat="server" AllowPaging="True"
                                AutoGenerateColumns="False" PageSize="5" OnPageIndexChanging="gvShopCart_PageIndexChanging"
                                OnRowCancelingEdit="gvShopCart_RowCancelingEdit" OnRowDeleting="gvShopCart_RowDeleting"
                                OnRowEditing="gvShopCart_RowEditing" OnRowUpdating="gvShopCart_RowUpdating">
                                <Columns>
                                    <asp:BoundField DataField="name" HeaderText="商品名称" ReadOnly="True">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="单个价格">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%#GetMKPStr(DataBinder.Eval(Container.DataItem,"price").ToString())%>￥
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="count" HeaderText="数量">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="小计">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%#GetSPStr(DataBinder.Eval(Container.DataItem, "sum_price").ToString())%>￥
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowDeleteButton="True" />
                                    <asp:CommandField ShowEditButton="True" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="center">
                            <asp:Label ID="lbLag" runat="server" Text="现购物车为空" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            合计： &nbsp; &nbsp;
                            <asp:Label ID="lbSumPrice" runat="server" Text="Label"></asp:Label>￥
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            商品数量：
                            <asp:Label ID="lbSumNum" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:LinkButton ID="lnkbtnClear" runat="server" OnClick="lnkbtnClear_Click">清空购物车</asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnContinue" runat="server" OnClick="lnkbtnContinue_Click">继续购物</asp:LinkButton>
                            <asp:LinkButton ID="lnkbtnCheck" runat="server" OnClick="lnkbtnCheck_Click">结账</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
