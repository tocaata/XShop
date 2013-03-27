<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="GoodsDetail.aspx.cs" Inherits="User_GoodsDetail" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server">
<table  cellSpacing="0" cellPadding="0" width="480" align="center" border="0">
				<tr>
					<th  align="left" height="25" colspan="2">
						&nbsp;&nbsp;
						<asp:label id="lblTitleInfo" Runat="server">商品详细信息</asp:label>
					</th>
				<tr>
				</tr>
			</table>
			<table  cellSpacing="1" cellPadding="1" width="480" align="center" border="0">
				<tr>
					<td>
						<table class="tableBorder" cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
							<tr>
								<td align="left" style="width: 93px">商品名称：</td>
								
								<td style="width: 359px" align =left ><asp:textbox id="txtName" runat="server" ReadOnly="True"></asp:textbox></td>
								
								
							</tr>
							<tr>
								<td align="left" style="width: 93px">
                                    父级类别名：
								</td>
								<td style="width: 359px" align="left">
                                    <asp:TextBox ID="txtFName" runat="server" ReadOnly="True"></asp:TextBox></td>
							</tr>

							<tr>
								<td align="left" style="height: 24px; width: 93px;">商品品牌：
								</td>
								<td style="width: 359px; height: 24px;" align="left"><asp:textbox id="txtBrand" runat="server" ReadOnly="True"></asp:textbox><span style="color: #ff0000"></span></td>
							</tr>
							
							<tr>
								<td align="left" style="width: 93px">计量单位：
								</td>
								<td style="width: 359px" align="left"><asp:textbox id="txtUnit" runat="server" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr>
								<td align="left" height="17" style="width: 93px">
                                    商品重量：
								</td>
								<td height="17" style="width: 359px" align="left"><asp:textbox id="txtWeight" runat="server" ReadOnly="True">0</asp:textbox>千克</td>
							</tr>
							<tr>
								<td align="left" height="19" style="width: 93px">市场价格：
								</td>
								<td colSpan="3" height="19" align="left" style="width: 371px"><asp:textbox id="txtMarketPrice" runat="server" ReadOnly="True">0</asp:textbox>￥</td>
							</tr>
							<tr>
								<td align="left" style="width: 93px">会员价格：
								</td>
								<td colSpan="3" align="left" style="width: 371px"><asp:textbox id="txtMemberPrice" runat="server" ReadOnly="True">0</asp:textbox>￥</td>
							</tr>
							<tr>
								<td align="left" colspan="4" style="height: 15px"><b>附件设置</b></td>
							</tr>
							<tr>
								<td align="left" style="height: 22px; width: 93px;">
                                    商品图像：
								</td>
								<td colSpan="3" style="height: 22px; width: 371px;" align="left">
                                    <asp:ImageMap ID="ImageMapPhoto" runat="server">
                                    </asp:ImageMap></td>
							</tr>
							<tr>
								<td align="left" style="height: 20px; width: 93px;">是否推荐：
								</td>
								<td colSpan="3" style="height: 20px; width: 371px;" align="left"><asp:checkbox id="cbxCommend" runat="server" Checked="True" AutoPostBack="True" Enabled="False"></asp:checkbox></td>
							</tr>
							
							<tr>
								<td align="left" style="width: 93px">是否热卖：
								</td>
								<td colSpan="3" align="left" style="width: 371px"><asp:checkbox id="cbxHot" runat="server" Checked="True" AutoPostBack="True" Enabled="False"></asp:checkbox></td>
							</tr>
							<tr>
								<td align="left" style="width: 93px">是否参与打折：
								</td>
								<td colSpan="3" align="left" style="width: 371px"><asp:checkbox id="cbxDiscount" runat="server" Checked="True" AutoPostBack="True" Enabled="False"></asp:checkbox></td>
							</tr>
							<tr>
								<td align="left" style="width: 93px">简单描述：
								</td>
								<td style="width: 359px" align="left"><asp:textbox id="txtShortDesc" runat="server" Width="307px" Height="89px" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr>
								<td align="center" colSpan="4"><br>
									<asp:button id="btnExit" runat="server" Text="返回" OnClick="btnExit_Click" ></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
</asp:Content>

