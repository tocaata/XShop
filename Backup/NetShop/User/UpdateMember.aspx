<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateMember.aspx.cs" Inherits="User_UpdateMember" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server">
 <table  id="tabAddUserInfo" cellSpacing="1" cellPadding="1" width="560" align="center"
				border="0" runat =server>
				<tr>
					<td style="width: 540px">
						<table class="tableBorder" id="tabAddMenber" cellSpacing="0" cellPadding="0" width="95%" align="center"
							border="0" runat =server >
							<tr>
					             <td class="tableHeaderText" align="left" height="25" colspan="2">
                                     &nbsp; &nbsp;&nbsp;
                                     更新会员信息</td>
				           </tr>
							<tr>
								<td align="right" width="250">用户名：
								</td>
								<td align="left"><asp:textbox id="txtName" runat="server"  MaxLength="50"></asp:textbox><FONT color="red">*</FONT></td>
							</tr>
							<tr>
								<td align="right" width="250" style="height: 24px">密 码：
								</td>
								<td style="height: 24px" align="left"><asp:textbox id="txtPassword" runat="server"  MaxLength="50" ></asp:textbox><FONT color="red">*</FONT></td>
							</tr>
						
							<tr>
								<td align="right" width="250">性别：</td>
								<td align="left"><asp:dropdownlist id="ddlSex" runat="server">
                                    <asp:ListItem Selected="True" Value="1">男</asp:ListItem>
                                    <asp:ListItem Value="0">女</asp:ListItem>
                                </asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right" width="250">
                                    真实姓名：
								</td>
								<td align="left"><asp:textbox id="txtTrueName" runat="server"  MaxLength="50"></asp:textbox><FONT color="red">*</FONT></td>
							</tr>
							<tr>
								<td align="right" width="250">
                                    所在城市：
								</td>
								<td align="left"><asp:DropDownList ID="ddlCity" runat="server" Width="127px" Font-Size="9pt">
                                <asp:ListItem>长春</asp:ListItem>
                                <asp:ListItem>太原</asp:ListItem>
                                <asp:ListItem>北京</asp:ListItem>
                                <asp:ListItem>上海</asp:ListItem>
                                <asp:ListItem>天津</asp:ListItem>
                                <asp:ListItem>吉林</asp:ListItem>
                                <asp:ListItem>乌鲁木齐</asp:ListItem>
                                <asp:ListItem>呼和浩特</asp:ListItem>
                                <asp:ListItem>银川</asp:ListItem>
                                <asp:ListItem>拉萨</asp:ListItem>
                                <asp:ListItem>五台山</asp:ListItem>
                                <asp:ListItem>太行山</asp:ListItem>
                                <asp:ListItem>吐鲁番</asp:ListItem>
                            </asp:DropDownList></td>
							</tr>
							<tr>
								<td align="right" width="250">
                                    详细住址：
								</td>
								<td  valign =middle align="left"  ><asp:textbox id="txtAddress" runat="server"  MaxLength="100" Height="115px" Width="206px" TextMode="MultiLine"></asp:textbox><span
                                        style="color: #ff0000">*</span></td>
							</tr>
							<tr>
								<td align="right" width="250">
                                    邮编：
								</td>
								<td align="left"><asp:textbox id="txtPostCode" runat="server"  MaxLength="50" AutoPostBack="True"></asp:textbox><FONT color="red">*</FONT></td>
							</tr>
							<tr>
								<td align="right" width="250">
                                    固定电话号码：
								</td>
								<td align="left"><asp:textbox id="txtPhone" runat="server"  MaxLength="50" AutoPostBack="True"></asp:textbox><FONT color="red">*</FONT></td>
							</tr>
                            <tr>
                                <td align="right" style="height: 24px" width="250">
                                    e-mail：</td>
                                <td style="height: 24px" align="left">
                                    <asp:textbox id="txtEmail" runat="server"  MaxLength="80" AutoPostBack="True"></asp:textbox><FONT color="red">*</FONT>
                                    </td>
                            </tr>
                            
							<tr>
								<td align="center" colSpan="2"><br>
									<asp:button id="btnUpdate" runat="server" Text="更新" OnClick="btnUpdate_Click" ></asp:button></td>
							</tr>
							</table>
							
					</td>
				</tr>
			
			</table>
</asp:Content>





