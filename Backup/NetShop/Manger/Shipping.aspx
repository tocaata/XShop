<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Shipping.aspx.cs" Inherits="Manger_Shipping" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body style ="font-family :宋体; font-size :9pt;">
		<form id="Form1" method="post" runat="server">
			<table  cellSpacing="0" cellPadding="0" width="640" align="center" border="0">
				<tr>
					<th height="25" align="left">
						
						<asp:Label id="lblAction" runat="server"></asp:Label></th>
					
				<tr>
				</tr>
			</table>
			<% if(this.Request.QueryString["Action"] == "Manage"){%>
			<table cellSpacing="0" cellPadding="0" width="640" align="center" border="0">
				<tr>
					<td height="23" >
                      <asp:GridView ID="gvShip" runat="server" AllowPaging =true  AutoGenerateColumns =false DataKeyNames ="ShipID" Width =100% HeaderStyle-HorizontalAlign =center HeaderStyle-CssClass="summary-title" OnPageIndexChanging="gvShip_PageIndexChanging" OnRowDeleting="gvShip_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="ShipID" HeaderText="序号" HeaderStyle-HorizontalAlign =left ItemStyle-HorizontalAlign=left ItemStyle-Width =30px/>
                                <asp:BoundField DataField="ShipWay" HeaderText="配送方式名称" HeaderStyle-HorizontalAlign =center ItemStyle-HorizontalAlign=center ItemStyle-Width =100px/>
                                
                                 <asp:TemplateField HeaderText="配送物品类别">
                                  <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
									<ItemTemplate>
										<%# GetClass(Convert.ToInt32(DataBinder.Eval(Container.DataItem, "ClassID").ToString()))%>
									</ItemTemplate>
                                </asp:TemplateField>
                                
                              <asp:TemplateField HeaderText="配送默认价格">
                                  <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
									<ItemTemplate>
										<%# GetVarStr(DataBinder.Eval(Container.DataItem, "ShipFee").ToString())%>￥
									</ItemTemplate>
                                </asp:TemplateField>
                                
                               
                                  <asp:TemplateField>
                                  <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
									<ItemTemplate>
										<a href='Shipping.aspx?Action=Modify&ShipID=<%# DataBinder.Eval(Container.DataItem, "ShipID") %>'>
											修改</a>
									</ItemTemplate>
                                </asp:TemplateField>
                             
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
					</td>
				</tr>
			</table>
			<%}if(this.Request.QueryString["Action"] == "Add" | this.Request.QueryString["Action"] == "Modify"){%>
			<table cellSpacing="0" cellPadding="0" width="640" align="center" border="0">
				<tr>
					<td height="23">
						<table class="tableBorder" cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
							<tr>
								<td align="left" style="height: 24px">
									配送方式名称：
								</td>
								<td style="height: 24px">
									<asp:TextBox id="txtName" runat="server"></asp:TextBox>
                                    </td>
							</tr>
							
							<tr>
								<td align="left">
									配送物品类别：
								</td>
								<td>
								    <asp:DropDownList id =ddlClassName runat =server Width="155px" ></asp:DropDownList>
								</td>
							</tr>
							<tr>
								<td align="left" valign="top" style="height: 24px">
									默认配送价格
								</td>
								<td style="height: 24px">
									<P>
										<asp:TextBox id="txtPrice" runat="server">0</asp:TextBox>￥</P>	
								</td>
							</tr>
							<tr>
								<td align="left" valign="top">
                                    说明：
								</td>
								<td>
									<P>
                                        总运费=配送价格＊配送地点公里数＊总重量(g)<br />
                                  
                                        这里定义配送价格
                                   
								</P>
                                   
								</td>
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
			<%}%>
		</form>
	</body>

</html>
