<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CategoryAdd.aspx.cs" Inherits="Manger_CategoryAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body style ="font-family :宋体; font-size :9pt;" >
    <form id="Form1" method="post" runat="server">
    <div>
			<table class="tableBorder" cellSpacing="1" cellPadding="1" width="640" align="center" border="0">
			<tr>
			<td  height="25" align="left">
			&nbsp;&nbsp; 商品类别添加
			</td>
			</tr>
				<tr>
					<td>
						<table class="tableBorder" cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
							<tr>
								<td align="left" style="height: 24px">
									分类名：
								</td>
								<td style="height: 24px">
									<asp:TextBox id="txtName" runat="server"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td align="left" style="height: 22px">
                                    图像：
								</td>
								<td colSpan="3" style="height: 22px">
                                    <asp:DropDownList ID="ddlUrl" runat="server" OnSelectedIndexChanged="ddlUrl_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList></td>
							</tr>
                            <tr>
                                <td align="left" style="height: 22px">
                                </td>
                                <td colspan="3" style="height: 22px">
                                    <asp:ImageMap ID="ImageMapPhoto" runat="server" ImageUrl="~/Images/ftp/图书.gif">
                                    </asp:ImageMap></td>
                            </tr>
							<tr>
								<td align="center" colspan="2"><br>
									<asp:Button id="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:Button>
									</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>

    </div>
    </form>
</body>
</html>
