<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderModify.aspx.cs" Inherits="Manger_OrderModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body style =" font-family :宋体; font-size :9pt;">
    <form id="form1" runat="server">
    <div>
    <object id="WebBrowser" height="0" width="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></object>
    <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" bgColor="#ffffff" border="0">
				<TBODY>
					<TR>
						<TD vAlign="middle" width="3%"><STRONG><BR>
							</STRONG>
						</TD>
						<TD vAlign="middle" align="center" width="30%"></TD>
						<TD class="body-shoptitle" vAlign="middle" align="center" width="67%">订单号码：<%=order.OrderNo%><br>
							下单日期：<%=order.OrderTime%>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" bgColor="#ffffff" border="0">
				<TBODY>
					<TR>
						<TD>&nbsp;</TD>
					</TR>
				</TBODY>
			</TABLE>
			<TABLE id="Table3" cellSpacing="0" cellPadding="1" width="100%" bgColor="#ffffff" border="0">
				<TBODY>
					<TR>
						<TD><STRONG>订单信息</STRONG>
							<HR noShade SIZE="1">
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<TABLE id="Table4" cellSpacing="3" cellPadding="3" width="100%" bgColor="#ffffff" border="0">
				<TBODY>
					<TR>
						<TD style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; height: 24px;"
							align="center" width="64">序号</TD>
						<TD style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; height: 24px;"
							align="left"  valign=middle width="284">商品名称<BR>
						</TD>
						<TD style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; height: 24px;"
							align="center" width="99">数量</TD>
						<TD style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; height: 24px;"
							align="center" width="98">会员价<BR>
						</TD>
						<TD style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; height: 24px;"
							align="center" width="98">小计<BR>
						</TD>
						<td style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; height: 24px;"
							align="center" width="130">是否参与打折</td>
					</TR> <!-- BEGIN row -->
					<asp:repeater id="rptOrderItems" Runat="server">
						<ItemTemplate>
							<TR>
								<TD noWrap align="center" width="64" height="20"><%# DataBinder.Eval(Container.DataItem, "GoodsID")%></TD>
								<TD align="left" width="334" height="20"><%# DataBinder.Eval(Container.DataItem, "GoodsName")%></TD>
								<TD align="center" width="99" height="20"><%#DataBinder.Eval(Container.DataItem, "Num")%></TD>
								<TD align="center" width="98" height="20"><%# DataBinder.Eval(Container.DataItem, "MemberPrice", "{0:f2}")%>￥</TD>
								<TD align="center" width="104" height="20"><%# DataBinder.Eval(Container.DataItem, "SumPrice", "{0:f2}")%>￥</TD>
								<TD width="80" align="center"><%# DataBinder.Eval(Container.DataItem, "IsDiscount")%></TD>
							</TR>
						</ItemTemplate>
					</asp:repeater>
					<TR>
						<TD align="center" width="64">&nbsp;</TD>
						<TD width="334">&nbsp;</TD>
						<TD width="98">&nbsp;</TD>
						<TD width="99">&nbsp;</TD>
						<TD width="104">&nbsp;</TD>
					</TR>
				</TBODY>
			</TABLE>
			<TABLE id="Table5" cellSpacing="0" cellPadding="2" width="100%" bgColor="#ffffff" border="0">
				<tr>
					<td vAlign="top" width="50%">
						<table id="Table6" width="100%">
							<tr>
								<td>定单状态：<%=GetStatus(Convert.ToInt32 (order.OrderNo))%></td>
							</tr>
							<tr>
								<td>配送方式：<%=GetShippingName(Convert.ToInt32(order.ShipType))%></td>
							</tr>
							<tr>
								<td>支付方式：<%=GetPaymentName(Convert.ToInt32(order.PayType))%></td>
							</tr>
						</table>
					</td>
					<td width="50%">
						<table id="Table7" width="100%">
							<tr>
								<td style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid"
									align="right" width="50%">商品总金额：</td>
								<td width="10%"></td>
								<td><%=string.Format("{0:f}",order.ProductPrice)%>￥ </td>
							</tr>
							
							<tr>
								<td style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid"
									align="right" width="50%">商品运费：</td>
								<td width="10%"></td>
								<td><%=string.Format("{0:f}",order.ShipPrice)%>￥</td>
							</tr>
							<tr>
								<td style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid"
									align="right" width="50%">订单总金额：</td>
								<td width="10%"></td>
								<td><%=string.Format("{0:f}",order.TotalPrice)%>￥</td>
							</tr>
						</table>
					</td>
				</tr>
			</TABLE>
			<TABLE id="Table8" cellSpacing="3" cellPadding="3" width="100%" bgColor="#ffffff" border="0">
				<tr>
					<td><STRONG>购货人信息</STRONG></td>
					<td><STRONG>收货人信息</STRONG></td>
				</tr>
				<tr>
					<td style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid"
						width="50%">
						<table id="Table9">
							<tr>
								<td align="right">购货人姓名：</td>
								<td><%=order.BuyerName%></td>
							</tr>
							
							<tr>
								<td align="right">联系电话：</td>
								<td><%=order.BuyerPhone%></td>
							</tr>
							<tr>
								<td align="right">Email地址：</td>
								<td><%=order.BuyerEmail%></td>
							</tr>
							<tr>
								<td align="right">购货人地址：</td>
								<td><%=order.BuyerAddress%></td>
							</tr>
							<tr>
								<td align="right">邮政编码：</td>
								<td><%=order.BuyerPostalcode%></td>
							</tr>
						</table>
					</td>
					<td style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid"
						width="50%">
						<table id="Table10">
							<tr>
								<td align="right">收货人姓名：</td>
								<td style="width: 3px"><%=order.ReceiverName%></td>
							</tr>
							<tr>
								<td align="right">联系电话：</td>
								<td style="width: 100px"><%=order.ReceiverPhone%></td>
							</tr>
							<tr>
								<td align="right">Email地址：</td>
								<td style="width: 3px"><%=order.ReceiverEmail%></td>
							</tr>
							<tr>
								<td align="right">收货人地址：</td>
								<td style="width: 3px"><%=order.ReceiverAddress%></td>
							</tr>
							<tr>
								<td align="right">邮政编码：</td>
								<td style="width: 3px"><%=order.ReceiverPostalcode%></td>
							</tr>
							<tr>
								<td align="right"></td>
								<td style="width: 3px"></td>
							</tr>
						</table>
					</td>
				</tr>
			</TABLE>
			<table id="Table11" width="100%" bgColor="#ffffff">
				<tr>
					<td><STRONG>修改订单状态</STRONG>
						<HR noShade SIZE="1">
					</td>
				</tr>
				<tr>
					<td>
                        <asp:CheckBox ID="chkConfirm" runat="server" Text="是否已确认" AutoPostBack="True"/>
                        <asp:CheckBox ID="chkPay" runat="server" Text="是否已付款" AutoPostBack="True"/>
                        <asp:CheckBox ID="chkConsignment" runat="server" Text="是否已发货" AutoPostBack="True" />
                        <asp:CheckBox ID="chkPigeonhole" runat="server"  Text="是否已归档" AutoPostBack="True"/>
					</td>
				</tr>
				<tr>
					<td height="20" align="center" valign="middle">
						<asp:Button ID="btnSave" Runat="server" Text="修 改" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid"
							Width="69" Height="22" OnClick="btnSave_Click"></asp:Button>
						 <input type="button" id=btnInput onclick="document.all.WebBrowser.ExecWB(6,1)" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid" value="打印文档资料" /></td>

				</tr>
			</table>

    
    </div>
    </form>
</body>
</html>
