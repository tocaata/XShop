<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="Manger_OrderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>无标题页</title>
</head>
<body style="font-size: 9pt;">
  <form id="form1" runat="server">
  <div>
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
      <tr>
        <th align="left" height="25">
          &nbsp;&nbsp; 订单管理<asp:Label ID="lblTitleInfo" runat="server"></asp:Label>
        </th>
        </tr>
    </table>
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
      <tr>
        <td align="center">
          <table cellspacing="0" cellpadding="0" width="95%" align="center">
            <tr>
              <td align="right">
                关键字：
              </td>
              <td>
                <asp:DropDownList ID="ddlKeyType" runat="server">
                  <asp:ListItem Selected="True" Value="order_id">订单号</asp:ListItem>
                  <asp:ListItem Value="MemberID">会员号</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revInt" runat="server" ControlToValidate="txtKeyword"
                  ErrorMessage="请输入整数" ValidationExpression="[0-9]*$"></asp:RegularExpressionValidator>
              </td>
            </tr>
            <tr>
              <td align="right">
                订单状态：
              </td>
              <td>
                <%--<asp:DropDownList ID="ddlPayed" runat="server">
                  <asp:ListItem Selected="True" Value="All">是否已付款</asp:ListItem>
                  <asp:ListItem Value="2">已付款</asp:ListItem>
                  <asp:ListItem Value="0">未付款</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlShipped" runat="server">
                  <asp:ListItem Selected="True" Value="All">是否已发货</asp:ListItem>
                  <asp:ListItem Value="2">已发货</asp:ListItem>
                  <asp:ListItem Value="0">未发货</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlFinished" runat="server">
                  <asp:ListItem Selected="True" Value="All">是否已归档</asp:ListItem>
                  <asp:ListItem Value="1">已归档</asp:ListItem>
                  <asp:ListItem Value="0">未归档</asp:ListItem>
                </asp:DropDownList>--%>
                <asp:DropDownList ID="ddlConfirmed" runat="server">
                  <asp:ListItem Selected="True" Value="2">是否已确认</asp:ListItem>
                  <asp:ListItem Value="1">已确认</asp:ListItem>
                  <asp:ListItem Value="0">未确认</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlShipped" runat="server">
                  <asp:ListItem Selected="True" Value="2">是否已发货</asp:ListItem>
                  <asp:ListItem Value="1">已发货</asp:ListItem>
                  <asp:ListItem Value="0">未发货</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlSpeed" runat="server">
                  <asp:ListItem Selected="True" Value="2">是否加急</asp:ListItem>
                  <asp:ListItem Value="1">加急中</asp:ListItem>
                  <asp:ListItem Value="0">未加急</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlReceive" runat="server">
                  <asp:ListItem Selected="True" Value="2">是否收到货</asp:ListItem>
                  <asp:ListItem Value="1">收货</asp:ListItem>
                  <asp:ListItem Value="0">未收货</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlReturn" runat="server">
                  <asp:ListItem Selected="True" Value="2">是否退货</asp:ListItem>
                  <asp:ListItem Value="1">退货</asp:ListItem>
                  <asp:ListItem Value="0">未退货</asp:ListItem>
                </asp:DropDownList>
              </td>
            </tr>
            <tr>
              <td align="right">
              </td>
              <td>
                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click">
                </asp:Button>
              </td>
            </tr>
          </table>
        </td>
      </tr>
      <tr>
        <td style="height: 23px">
          <asp:GridView ID="gvOrderList" runat="server" HorizontalAlign="Center" Width="100%"
            DataKeyNames="order_id" AutoGenerateColumns="False" PageSize="5" AllowPaging="True"
            OnPageIndexChanging="gvOrderList_PageIndexChanging" OnRowDeleting="gvOrderList_RowDeleting">
            <HeaderStyle Font-Bold="True" />
            <Columns>
              <asp:TemplateField HeaderText="单号">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                <ItemTemplate>
                  <%# Eval("order_id") %>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="create_at" HeaderText="下订时间" DataFormatString="{0:yyyy-MM-dd HH:mm}">
                <ItemStyle HorizontalAlign="Center" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="总金额">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                  <%# GetVarTP(Eval("total_price").ToString()) %>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="会员ID">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                  <%# Eval("user_id") %>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="购物会员">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                  <%# GetMemberName(Convert.ToInt32(Eval("user_id").ToString())) %>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="收货人">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                  <%# Eval("name") %>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="联系电话">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                  <%# Eval("phone") %>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="订单状态">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                  <%# Eval("status")%>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                  <a href='OrderModify.aspx?order_id=<%# Eval("order_id") %>'>
                    管理</a>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:CommandField ShowDeleteButton="True" />
            </Columns>
          </asp:GridView>
          <%--<asp:ButtonColumn Text="&lt;div id=&quot;de&quot; onclick=&quot;javascript:return confirm('确认删除吗？')&quot;&gt;删除&lt;/div&gt;"
									CommandName="Delete">
									<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid>--%>
        </td>
      </tr>
    </table>
  </div>
  </form>
</body>
</html>
