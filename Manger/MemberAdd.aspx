<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberAdd.aspx.cs" Inherits="Manger_MemberAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body style ="font-size :9pt; font-family :宋体;">
    <form id="form1" runat="server">
    <div>
   <table class="tableBorder" cellSpacing="1" cellPadding="1" width="640" align="center" border="0">
			<tr>
			<td  height="25" align="left">
			&nbsp;&nbsp; 添加管理员
			</td>
			</tr>
				<tr>
					<td>
						<table class="tableBorder" cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
							<tr>
								<td align="left" style="height: 24px">
									管理员名：
								</td>
								<td style="height: 24px">
									<asp:TextBox id="txtName" runat="server"></asp:TextBox>
								</td>
							</tr>
                            <tr>
                                <td align="left" style="height: 25px">
                                    管理员密码：
                                </td>
                                <td style="height: 25px">
                                    <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
                                </td>
                            </tr>
							<tr>
								<td align="center" colspan="2"><br>
									<asp:Button id="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" ></asp:Button>
									<asp:Button id="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" ></asp:Button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
    
    
    </div>
    </form>
</body>
</html>
