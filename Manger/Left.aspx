<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="Manger_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    protected void Menu12_MenuItemClick(object sender, MenuEventArgs e)
    {
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
	<HEAD>
		<title>功能导航</title>
		<style type="text/css">
	body  { background:#7F9ED9; margin:0px; font:normal 12px 宋体; scrollbar-face-color: #799AE1; scrollbar-highlight-color: #799AE1; scrollbar-shadow-color: #799AE1; scrollbar-darkshadow-color: #799AE1; scrollbar-3dlight-color: #799AE1; scrollbar-arrow-color: #FFFFFF;scrollbar-track-color: #AABFEC;}
	table  { border:0px; }
	td  { font-size:12px ; }
	img  { vertical-align:bottom; border:0px; }
	a  { font-size: 12px ; color:#215DC6; text-decoration:none; }
	a:hover  { color:#428EFF }
	.sec_menu  { border-left:1px solid white; border-right:1px solid white; border-bottom:1px solid white; background:#E2ECFD; padding:5px 2px;}
	.menu_title  { }
	.menu_title span  { position:relative; top:2px; left:8px; color:#215DC6; font-weight:bold; }
	.menu_title2  { }
	.menu_title2 span  { position:relative; top:2px; left:8px; color:#428EFF; font-weight:bold; }
	</style>
	</HEAD>
	<body>
<script language="javascript" type="text/javascript">
<!--
function menuChange(obj,menu)
{
	if(menu.style.display=="")
	{
		obj.background="../Images/admin_title_bg_hide.gif";
		menu.style.display="none";
	}else{
		obj.background="../Images/admin_title_bg_show.gif";
		menu.style.display="";
	}
}

function proLoadimg()
{
	var i=new Image;
	i.src='../Images/admin_title_bg_hide.gif';
	i.src='../Images/admin_title_bg_show.gif';
}
function hideMenu(menu)
{
	menu.style.display="none";

}
proLoadimg();
-->
		</script>
		<table cellSpacing="0" cellPadding="0" width="158" align="center">
			<tr>
				<td style="background:url('../Images/admin_title_bg_quit.gif')"  height="25">&nbsp; &nbsp;<A href="main.aspx" target="right"><strong>管理首页</strong></A>&nbsp;
					<A href="../User/index.aspx" target="_top"><strong>退出</strong></A>
				</td>
			</tr>
		</table>
		&nbsp;
		<table cellSpacing="0" cellPadding="0" align="center">
			<tr style="CURSOR: hand">
				<td height="25" class="menu_title" style="background:url('../Images/admin_title_bg_show.gif'); width: 154px;" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" onclick="menuChange(this,menu1);">
				<span>订单管理</span>
				</td>
			</tr>
			<tr>
				<td style="width: 154px">
					<div class="sec_menu" id="menu1" style="WIDTH: 158px">
						<table cellSpacing="0" cellPadding="0" width="140" align="center" border="0">
							
							<tr>
								<td height="20"><A href="OrderList.aspx?OrderList=00" target="right">未确认</A> | <A href="OrderList.aspx?OrderList=01" target="right">
										已确认</A>
								</td>
							</tr>
							<tr>
								<td style="height: 20px"><A href="OrderList.aspx?OrderList=10" target="right">未付款</A> | <A href="OrderList.aspx?OrderList=11" target="right">
										已付款</A>
								</td>
							</tr>
							<tr>
								<td height="20"><A href="OrderList.aspx?OrderList=20" target="right">未发货</A> | <A href="OrderList.aspx?OrderList=21" target="right">
										已发货</A>
								</td>
							</tr>
							<tr>
								<td height="20"><A href="OrderList.aspx?OrderList=30" target="right">未归档</A> | <A href="OrderList.aspx?OrderList=31" target="right">
										已归档</A>
								</td>
							</tr>
							
						
						</table>
					</div>
				</td>
			</tr>
		</table>
      
		<script>hideMenu(menu1);</script>
		&nbsp;
		<table cellSpacing="0" cellPadding="0" width="158" align="center">
			<tr style="CURSOR: hand">
				<td height="25" class="menu_title" style="background:url('../Images/admin_title_bg_show.gif'); width: 165px;" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" onclick="menuChange(this,menu2);">
				<span>商品管理</span>
				</td>
			</tr>
			<tr>
				<td style="width: 165px">
					<div class="sec_menu" id="menu2" style="WIDTH: 158px">
						<table cellSpacing="0" cellPadding="0" width="140" align="center" border="0">
							
							<tr>
								<td height="20"><A href="ProductAdd.aspx" target="right">商品添加</A>| <A href="Product.aspx" target="right">
										管理</A>
								</td>
							</tr>
							
							<tr>
								<td height="20"><A href="CategoryAdd.aspx" target="right">类别添加</A>| <A href="Category.aspx" target="right">
										管理</A>
								</td>
							</tr>
							
						</table>
					</div>
				</td>
			</tr>
		</table>
		<script>hideMenu(menu2);</script>
		&nbsp;
		<table cellSpacing="0" cellPadding="0" width="158" align="center">
			<tr style="CURSOR: hand">
				<td height="25" class="menu_title" style="background:url('../Images/admin_title_bg_show.gif')" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" onclick="menuChange(this,menu3);">
				<span>会员管理</span>
				</td>
			</tr>
			<tr>
				<td>
					<div class="sec_menu" id="menu3" style="WIDTH: 158px">
						<table cellSpacing="0" cellPadding="0" width="140" align="center">
							
							<tr>
								<td height="20"><A href="MemberAdd.aspx" target="right">添加管理员</A>| <A href="Member.aspx" target="right">
										管理</A></td>
							</tr>
							
							<tr>
								<td height="20"><A href="Manager.aspx" target="right">管理会员</A></td>
							</tr>
							
						</table>
					</div>
				</td>
			</tr>
		</table>
		<script>hideMenu(menu3);</script>
		&nbsp;
		<table cellSpacing="0" cellPadding="0" width="158" align="center">
			<tr style="CURSOR: hand">
				<td height="25" class="menu_title" style="background:url('../Images/admin_title_bg_show.gif')" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" onclick="menuChange(this,menu4);">
				<span>物流系统</span>
				</td>
			</tr>
			<tr>
				<td>
					<div class="sec_menu" id="menu4" style="WIDTH: 158px">
						<table cellSpacing="0" cellPadding="0" width="140" align="center">
							
							<tr>
								<td height="20"><A href="Payment.aspx?Action=Add" target="right">支付方式添加</A> | <A href="Payment.aspx?Action=Manage" target="right">
										管理</A></td>
							</tr>
							
							<tr>
								<td height="20"><A href="Shipping.aspx?Action=Add" target="right">配送方式添加</A> | <A href="Shipping.aspx?Action=Manage" target="right">
										管理</A></td>
							</tr>
							<tr>
								<td height="20"><A href="ShipArea.aspx?Action=Add" target="right">配送地点添加</A> | <A href="ShipArea.aspx?Action=Manage" target="right">
										管理</A></td>
							</tr>
							
							
						</table>
					</div>
				</td>
			</tr>
		</table>
		<script>hideMenu(menu4);</script>
		&nbsp;
		<table cellSpacing="0" cellPadding="0" width="158" align="center">
			<tr style="CURSOR: hand">
				<td height="25" class="menu_title" style="background:url('../Images/admin_title_bg_show.gif')" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" onclick="menuChange(this,menu5);">
				<span>系统管理</span>
				</td>
			</tr>
			<tr>
				<td>
					<div class="sec_menu" id="menu5" style="WIDTH: 158px">
						<table cellSpacing="0" cellPadding="0" width="140" align="center">
							<%--<tr>
								<td height="20"><A href="SystemBackup.aspx" target="right">
										数据备份</A></td>
							</tr>--%>
							
							<tr>
								<td height="20"><A href="imagery.aspx" target="right">上传管理</A></td>
							</tr>
						</table>
					</div>
				</td>
			</tr>
		</table>
		<script>hideMenu(menu5);</script>
		&nbsp;
		<table cellSpacing="0" cellPadding="0" width="158" align="center">
			<tr style="CURSOR: hand">
				<td height="25" class="menu_title" style="background:url('../Images/admin_title_bg_show.gif')" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" onclick="menuChange(this,menu6);">
				<span>版权信息</span>
				</td>
			</tr>
			<tr>
				<td>
					<div class="sec_menu" id="menu6" style="WIDTH: 158px">
						<table cellSpacing="0" cellPadding="0" width="140" align="center">
							<tr>
								<td height="20">&nbsp;官方网站：<a href="http://www.dhu.edu.cn" target="_blank">东华大学</a></td>
							</tr>
							<tr>
								<td height="20">&nbsp;程序制作：<A href="http://www.dhu.edu.cn" target ="_blank">旭日工商管理学院</A></td>
							</tr>
						</table>
					</div>
				</td>
			</tr>
		</table>
		<br>
		<br>
	</body>
</HTML>
