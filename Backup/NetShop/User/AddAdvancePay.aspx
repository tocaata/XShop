<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AddAdvancePay.aspx.cs" Inherits="User_AddAdvancePay" Title="Untitled Page" %>
<%@ Register Src="../UserControl/LoadingControl.ascx" TagName="LoadingControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server">
<table  id="tabAddPayment" cellSpacing="0" cellPadding="0" width="95%" align="center"
							border="0" runat =server >
							 <tr style ="font-size: 9pt; font-family: 宋体;">
                                <td align="left" style="height: 24px" width="250"   colspan =2>
                                    会员充值：</td>
                                    </tr>
                                    <tr>
                                    
                                <td align="right" style="height: 24px; width: 158px;">
                                请选择银行名称
                                    </td>
                                        <td style="height: 24px" align="left"><asp:DropDownList ID="ddlPayWay" runat="server" Width="127px" Font-Size="9pt">
                                <asp:ListItem>中国银行</asp:ListItem>
                                <asp:ListItem>交通银行</asp:ListItem>
                                <asp:ListItem>商业银行</asp:ListItem>
                                <asp:ListItem>农业银行</asp:ListItem>
                                <asp:ListItem>工商银行</asp:ListItem>
                                <asp:ListItem>邮政</asp:ListItem> 
                            </asp:DropDownList></td>
                            </tr>
							 <tr style ="font-size: 9pt; font-family: 宋体;">
                                <td align="right" style="height: 24px; width: 158px;">
                                    帐号：</td>
                                <td style="height: 24px" align="left">
                                    <asp:textbox id="txtCode" runat="server"  MaxLength="20"></asp:textbox><FONT color="red">*</FONT>
                                    <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCode"
                                        Display="Dynamic" ErrorMessage="请输入账号"></asp:RequiredFieldValidator></td>
                            </tr>
                    <tr style ="font-size: 9pt; font-family: 宋体;">
                        <td align="right" style="height: 24px; width: 158px;">
                            身份证号：</td>
                        <td style="height: 24px" align="left">
                            <asp:TextBox ID="txtStatus" runat="server" MaxLength="20"></asp:TextBox><FONT color="red">*</font>
                            <asp:RegularExpressionValidator ID="revStatus" runat="server" ErrorMessage="请正确输入" ValidationExpression="\d{17}[\d|X]|\d{15}" ControlToValidate="txtStatus"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="txtStatus"
                                Display="Dynamic" ErrorMessage="请输入身份证号"></asp:RequiredFieldValidator></td>
                    </tr>
							 <tr style ="font-size: 9pt; font-family: 宋体;">
                                <td align="right" style="height: 24px; width: 158px;">
                                    密码：</td>
                                <td style="height: 24px" align="left">
                                    <asp:textbox id="txtCodePassword" runat="server"  MaxLength="20"></asp:textbox></td>
                            </tr>
                                         <tr style ="font-size: 9pt; font-family: 宋体;">
                                <td align="right" style="height: 24px; width: 158px;">
                                    会员充值：</td>
                                <td style="height: 24px" align="left">
                                    <asp:textbox id="txtAdvancePayment" runat="server"  MaxLength="20">0</asp:textbox>￥<FONT color="red">*</FONT>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAdvancePayment"
                                        ErrorMessage="请正确输入（格式：1.00）" ValidationExpression="^[0-9]+(.[0-9]{2})?$"></asp:RegularExpressionValidator></td>
                                        </tr>
                                        <tr style ="font-size: 9pt; font-family: 宋体;">
                                        <td style="height: 24px" colspan =2 align =center >
                                            <asp:Button ID="btnConfirm" runat="server" Text="确定" OnClick="btnConfirm_Click"  />
                                            <asp:Button ID="btnExit" runat="server" Text="退出" CausesValidation="False" OnClick="btnExit_Click" /></td>
                            </tr>
						</table>
</asp:Content>




