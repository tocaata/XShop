<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="User_CheckOut" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server">
<table  cellSpacing="0" cellPadding="0" width="480" align="center" border="0">
				<tr style =" font :9pt; font-family :宋体;">
					<th  align="left" height="25px" colspan="2px">
						&nbsp;&nbsp;
						<asp:label id="lblTitleInfo" Runat="server">请正确填写以下收货信息</asp:label>
					</th>
				<tr>
				</tr>
			</table>
			<table  cellSpacing="1" cellPadding="1" width="480" align="center" border="0">
				<tr style =" font :9pt; font-family :宋体;">
					<td>
						<table class="tableBorder" cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
							<tr style =" font :9pt; font-family :宋体;">
								<td align="left" width="100" style="height: 28px">
                                    收货人真实姓名：</td>
								
								<td style="width: 359px; height: 28px;" align =left ><asp:textbox id="txtReciverName" runat="server"></asp:textbox><font color="red">*</font></td>
								
								
							</tr>
							<tr style =" font :9pt; font-family :宋体;">
								<td align="left">
                                    收货人详细地址：
								</td>
								<td style="width: 359px" align =left >
									<asp:textbox id="txtReceiverAddress" runat="server"></asp:textbox><font color="red">*</font></td>
							</tr>

							<tr style =" font :9pt; font-family :宋体;">
								<td align="left" style="height: 24px">
                                    联系电话：
								</td>
								<td style="width: 359px; height: 24px;"  align =left ><asp:textbox id="txtReceiverPhone" runat="server"></asp:textbox><font color="red">*<asp:RegularExpressionValidator
                                        ID="revPhone" runat="server" ControlToValidate="txtReceiverPhone" Display="Dynamic"
                                        ErrorMessage="您输入的电话号码有误，请重新输入" ValidationExpression="(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}$"></asp:RegularExpressionValidator></font></td>
							</tr>
							
							<tr style =" font :9pt; font-family :宋体;">
								<td align="left">
                                    收货邮编：
								</td>
								<td style="width: 359px" align =left ><asp:textbox id="txtReceiverPostCode" runat="server"></asp:textbox><font color="red">*<asp:RegularExpressionValidator
                                        ID="revPostCode" runat="server" ControlToValidate="txtReceiverPostCode" Font-Size="9pt"
                                        ValidationExpression="\d{6}" Width="134px">您的邮编输入有误</asp:RegularExpressionValidator></font></td>
							</tr>
							<tr style =" font :9pt; font-family :宋体;">
								<td align="left" height="17">
                                    电子信箱：
								</td>
								<td height="17" style="width: 359px" align =left ><asp:textbox id="txtReceiverEmails" runat="server"></asp:textbox><font color="red">*<asp:RegularExpressionValidator
                                        ID="revEmail" runat="server" ControlToValidate="txtReceiverEmails" Font-Size="9pt"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Width="132px">您输入的E-mail地址格式不正确，请重新输入</asp:RegularExpressionValidator></font></td>
							</tr>
							<tr style =" font :9pt; font-family :宋体;">
								<td align="left" height="19">
                                    送货所在城市：
								</td>
								<td colSpan="3" height="19" align =left ><asp:DropDownList id="ddlShipCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlShipCity_SelectedIndexChanged">
                                </asp:DropDownList>
                                    <asp:Label ID="labKM" runat="server" Text=""></asp:Label>公里</td>
							</tr>
							<tr style =" font :9pt; font-family :宋体;">
								<td align="left" height="19">
                                    送货方式：
								</td>
								<td colSpan="3" height="19" align =left ><asp:DropDownList id="ddlShipType" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                                    <asp:LinkButton ID="lnkbtnSee" runat="server" OnClick="lnkbtnSee_Click">查看配送费</asp:LinkButton></td>
							</tr>
							<tr style =" font :9pt; font-family :宋体;">
								<td align="left">
                                    支付方式：
								</td>
								<td colSpan="3" align =left ><asp:DropDownList id="ddlPayType" runat="server" AutoPostBack="True">
                                </asp:DropDownList></td>
							</tr>
							<tr style =" font :9pt; font-family :宋体;">
								<td align="center" colSpan="4"><br>
									<asp:button id="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" ></asp:button><asp:button id="btnReset" runat="server" Text="退出" OnClick="btnReset_Click"  ></asp:button>
                                    </td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
</asp:Content>

