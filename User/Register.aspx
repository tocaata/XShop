<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register"
    MasterPageFile="~/MasterPage/MasterPage.master" Title="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" runat="server">
    <table id="tabAddUserInfo" cellspacing="1" cellpadding="1" width="540" align="center"
        border="0" runat="server">
        <tr>
            <td>
                <table class="tableBorder" id="tabAddMenber" cellspacing="0" cellpadding="0" width="95%"
                    align="center" border="0" runat="server">
                    <tr>
                        <td class="tableHeaderText" align="left" height="25" colspan="2">
                            添加会员
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 149px">
                            用户名：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtName" runat="server" MaxLength="50"></asp:TextBox><font color="red">*<asp:RequiredFieldValidator
                                ID="rfvLoginName" runat="server" ControlToValidate="txtName" Font-Size="9pt"
                                Height="1px" Width="117px">会员登录名不能为空</asp:RequiredFieldValidator></font>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 24px; width: 149px;">
                            密 码：
                        </td>
                        <td style="height: 24px" align="left">
                            <asp:TextBox ID="txtPassword" runat="server" MaxLength="50" TextMode="Password" Width="148px"></asp:TextBox><font
                                color="red">*<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                    Font-Size="9pt" Height="1px" Width="117px">密码不能为空</asp:RequiredFieldValidator></font>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 149px">
                            性别：
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlSex" runat="server">
                                <asp:ListItem Selected="True" Value="1">男</asp:ListItem>
                                <asp:ListItem Value="0">女</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 149px">
                            真实姓名：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtTrueName" runat="server" MaxLength="50"></asp:TextBox><font color="red">*<asp:RequiredFieldValidator
                                ID="rfvTrueName" runat="server" ControlToValidate="txtTrueName" Font-Size="9pt" Height="1px"
                                Width="117px">会员真实名不能为空</asp:RequiredFieldValidator></font>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 149px">
                            所在城市：
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlCity" runat="server" Width="127px" Font-Size="9pt">
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
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 149px">
                            详细住址：
                        </td>
                        <td valign="middle" align="left">
                            <asp:TextBox ID="txtAddress" runat="server" MaxLength="100" Height="115px" Width="206px"
                                TextMode="MultiLine"></asp:TextBox><span style="color: #ff0000">*<asp:RequiredFieldValidator
                                    ID="rfvAddress" runat="server" ControlToValidate="txtAddress" Font-Size="9pt" Height="1px"
                                    Width="117px">会员的详细地址不能为空</asp:RequiredFieldValidator></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 149px">
                            手机：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPhone" runat="server" MaxLength="50"></asp:TextBox><font color="red">*<asp:RegularExpressionValidator
                                ID="revPhone" runat="server" ControlToValidate="txtPhone" Display="Dynamic" ErrorMessage="您输入的电话号码有误，请重新输入"
                                ValidationExpression="(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}$"></asp:RegularExpressionValidator></font>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 24px; width: 149px;">
                            e-mail：
                        </td>
                        <td style="height: 24px" align="left">
                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="80"></asp:TextBox><span style="color:Red">*
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    Width="132px">您输入的E-mail地址格式不正确，请重新输入</asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="revEmailNotNull" runat="server" ControlToValidate="txtEmail"
                                Font-Size="9pt" Height="1px" Width="117px">E-mail不能为空</asp:RequiredFieldValidator>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <br>
                            <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
