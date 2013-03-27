<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register"  MasterPageFile="~/MasterPage/MasterPage.master" Title ="Register"%>
<asp:Content ID =Content1 ContentPlaceHolderID =FartherMain runat =server >
			
			  <table  id="tabAddUserInfo" cellSpacing="1" cellPadding="1" width="540" align="center"
				border="0" runat =server>
				<tr>
					<td>
						<table class="tableBorder" id="tabAddMenber" cellSpacing="0" cellPadding="0" width="95%" align="center"
							border="0" runat =server >
							<tr>
					             <td class="tableHeaderText" align="left" height="25" colspan="2">
                                    
						            添加会员</td>
				           </tr>
							<tr>
								<td align="right" style="width: 149px">用户名：
								</td>
								<td align="left"><asp:textbox id="txtName" runat="server"  MaxLength="50"></asp:textbox><FONT color="red">*<asp:RequiredFieldValidator
                                        ID="rfvLoginName" runat="server" ControlToValidate="txtName" Font-Size="9pt"
                                        Height="1px" Width="117px">会员登录名不能为空</asp:RequiredFieldValidator></FONT></td>
							</tr>
							<tr>
								<td align="right" style="height: 24px; width: 149px;">密 码：
								</td>
								<td style="height: 24px" align="left"><asp:textbox id="txtPassword" runat="server"  MaxLength="50" TextMode="Password" Width="148px"></asp:textbox><FONT color="red">*<asp:RequiredFieldValidator
                                        ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Font-Size="9pt"
                                        Height="1px" Width="117px">密码不能为空</asp:RequiredFieldValidator></FONT></td>
							</tr>
							
							<tr>
								<td align="right" style="width: 149px">性别：</td>
								<td align="left"><asp:dropdownlist id="ddlSex" runat="server">
                                    <asp:ListItem Selected="True" Value="1">男</asp:ListItem>
                                    <asp:ListItem Value="0">女</asp:ListItem>
                                </asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right" style="width: 149px">
                                    真实姓名：
								</td>
								<td align="left"><asp:textbox id="txtTrueName" runat="server"  MaxLength="50"></asp:textbox><FONT color="red">*<asp:RequiredFieldValidator
                                        ID="rfvTrueName" runat="server" ControlToValidate="txtName" Font-Size="9pt"
                                        Height="1px" Width="117px">会员真实名不能为空</asp:RequiredFieldValidator></FONT></td>
							</tr>
							<tr>
								<td align="right" style="width: 149px">
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
								<td align="right" style="width: 149px">
                                    详细住址：
								</td>
								<td  valign =middle align="left"  ><asp:textbox id="txtAddress" runat="server"  MaxLength="100" Height="115px" Width="206px" TextMode="MultiLine"></asp:textbox><span
                                        style="color: #ff0000">*<asp:RequiredFieldValidator ID="rfvAddress"
                                            runat="server" ControlToValidate="txtName" Font-Size="9pt" Height="1px" Width="117px">会员的详细地址不能为空</asp:RequiredFieldValidator></span></td>
							</tr>
							<tr>
								<td align="right" style="width: 149px">
                                    邮编：
								</td>
								<td align="left"><asp:textbox id="txtPostCode" runat="server"  MaxLength="50"></asp:textbox><FONT color="red">*<asp:RegularExpressionValidator
                                        ID="revPostCode" runat="server" ControlToValidate="txtPostCode" Font-Size="9pt"
                                        ValidationExpression="\d{6}" Width="134px">您的邮编输入有误</asp:RegularExpressionValidator></FONT></td>
							</tr>
							<tr>
								<td align="right" style="width: 149px">
                                    固定电话号码：
								</td>
								<td align =left > <asp:textbox id="txtPhone" runat="server"  MaxLength="50"></asp:textbox><FONT color="red">*<asp:RegularExpressionValidator
                                        ID="revPhone" runat="server" ControlToValidate="txtPhone"
                                        Display="Dynamic" ErrorMessage="您输入的电话号码有误，请重新输入" ValidationExpression="(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}$"></asp:RegularExpressionValidator></FONT></td>
							</tr>
                            <tr>
                                <td align="right" style="height: 24px; width: 149px;">
                                    e-mail：</td>
                                <td style="height: 24px" align="left">
                                    <asp:textbox id="txtEmail" runat="server"  MaxLength="80"></asp:textbox><FONT color="red">*</FONT>
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                        Font-Size="9pt" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        Width="132px">您输入的E-mail地址格式不正确，请重新输入</asp:RegularExpressionValidator></td>
                            </tr>
                            
							<tr>
								<td align="center" colSpan="2"><br>
									<asp:button id="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:button></td>
							</tr>
							
							</table>
							
					</td>
				</tr>
				
			</table>
			

   </asp:Content>

