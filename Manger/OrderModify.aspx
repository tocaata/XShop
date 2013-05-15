<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderModify.aspx.cs" Inherits="Manger_OrderModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>无标题页</title>
</head>
<body style="font-family: 宋体; font-size: 9pt;">
  <form id="form1" runat="server">
  <div>
    <object id="WebBrowser" height="0" width="0" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2">
    </object>
    <table id="Table1" cellspacing="0" cellpadding="0" width="100%" bgcolor="#ffffff"
      border="0">
      <tbody>
        <tr>
          <td valign="middle" width="3%">
            <strong>
              <br>
            </strong>
          </td>
          <td valign="middle" align="center" width="30%">
          </td>
          <td class="body-shoptitle" valign="middle" align="center" width="67%">
            订单号码：<%=order.OrderNo%><br>
            下单日期：<%=order.OrderTime%>
          </td>
        </tr>
      </tbody>
    </table>
    <table id="Table2" cellspacing="0" cellpadding="0" width="100%" bgcolor="#ffffff"
      border="0">
      <tbody>
        <tr>
          <td>
            &nbsp;
          </td>
        </tr>
      </tbody>
    </table>
    <table id="Table3" cellspacing="0" cellpadding="1" width="100%" bgcolor="#ffffff"
      border="0">
      <tbody>
        <tr>
          <td>
            <strong>订单信息</strong>
            <hr noshade size="1">
          </td>
        </tr>
      </tbody>
    </table>
    <table id="Table4" cellspacing="3" cellpadding="3" width="100%" bgcolor="#ffffff"
      border="0">
      <tbody>
        <tr>
          <td style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid;
            border-bottom: #000000 1px solid; height: 24px;" align="center" width="64">
            序号
          </td>
          <td style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid;
            border-bottom: #000000 1px solid; height: 24px;" align="left" valign="middle" width="284">
            商品名称<br/>
          </td>
          <td style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid;
            border-bottom: #000000 1px solid; height: 24px;" align="center" width="99">
            数量
          </td>
          <td style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid;
            border-bottom: #000000 1px solid; height: 24px;" align="center" width="98">
            商城价<br/>
          </td>
          <td style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid;
            border-bottom: #000000 1px solid; height: 24px;" align="center" width="98">
            小计<br/>
          </td>
          <td style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid;
            border-bottom: #000000 1px solid; height: 24px;" align="center" width="130">
            是否参与打折
          </td>
        </tr>
        <!-- BEGIN row -->
        <asp:Repeater ID="rptOrderItems" runat="server">
          <ItemTemplate>
            <tr>
              <td nowrap align="center" width="64" height="20">
                <%# DataBinder.Eval(Container.DataItem, "item_id")%>
              </td>
              <td align="left" width="334" height="20">
                <%# DataBinder.Eval(Container.DataItem, "name")%>
              </td>
              <td align="center" width="99" height="20">
                <%#DataBinder.Eval(Container.DataItem, "count")%>
              </td>
              <td align="center" width="98" height="20">
                <%# DataBinder.Eval(Container.DataItem, "price", "{0:f2}")%>￥
              </td>
              <td align="center" width="104" height="20">
                <%# DataBinder.Eval(Container.DataItem, "sum_price", "{0:f2}")%>￥
              </td>
              <td width="80" align="center">
                <%# DataBinder.Eval(Container.DataItem, "is_discount")%>
              </td>
            </tr>
          </ItemTemplate>
        </asp:Repeater>
        <tr>
          <td align="center" width="64">
            &nbsp;
          </td>
          <td width="334">
            &nbsp;
          </td>
          <td width="98">
            &nbsp;
          </td>
          <td width="99">
            &nbsp;
          </td>
          <td width="104">
            &nbsp;
          </td>
        </tr>
      </tbody>
    </table>
    <table id="Table5" cellspacing="0" cellpadding="2" width="100%" bgcolor="#ffffff"
      border="0">
      <tr>
        <td valign="top" width="50%">
          <table id="Table6" width="100%">
            <tr>
              <td>
                定单状态：<%= order.statusString%>
              </td>
            </tr>
          </table>
        </td>
        <td width="50%">
          <table id="Table7" width="100%">
            <tr>
              <td style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid;
                border-bottom: #000000 1px solid" align="right" width="50%">
                商品总金额：
              </td>
              <td width="10%">
              </td>
              <td>
                <%=string.Format("{0:f}",order.ProductPrice)%>￥
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
    <table id="Table8" cellspacing="3" cellpadding="3" width="100%" bgcolor="#ffffff"
      border="0">
      <tr>
        <td>
          <strong>购货人信息</strong>
        </td>
        <td>
          <strong>收货人信息</strong>
        </td>
      </tr>
      <tr>
        <td style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid;
          border-bottom: #000000 1px solid" width="50%">
          <table id="Table9">
            <tr>
              <td align="right">
                购货人姓名：
              </td>
              <td>
                <%=order.BuyerName%>
              </td>
            </tr>
            <tr>
              <td align="right">
                联系电话：
              </td>
              <td>
                <%=order.BuyerPhone%>
              </td>
            </tr>
            <tr>
              <td align="right">
                Email地址：
              </td>
              <td>
                <%=order.BuyerEmail%>
              </td>
            </tr>
            <tr>
              <td align="right">
                购货人地址：
              </td>
              <td>
                <%=order.BuyerAddress%>
              </td>
            </tr>
          </table>
        </td>
        <td style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid;
          border-bottom: #000000 1px solid" width="50%">
          <table id="Table10">
            <tr>
              <td align="right">
                收货人姓名：
              </td>
              <td style="width: 3px">
                <%=order.ReceiverName%>
              </td>
            </tr>
            <tr>
              <td align="right">
                联系电话：
              </td>
              <td style="width: 100px">
                <%=order.ReceiverPhone%>
              </td>
            </tr>
            <tr>
            </tr>
            <tr>
              <td align="right">
                收货人地址：
              </td>
              <td style="width: 3px">
                <%=order.ReceiverAddress%>
              </td>
            </tr>
            <tr>
            </tr>

          </table>
        </td>
      </tr>
    </table>
    <table id="Table11" width="100%" bgcolor="#ffffff">
      <tr>
        <td>
          <strong>修改订单状态</strong>
          <hr noshade size="1">
        </td>
      </tr>
      <tr>
        <td>
          <asp:DropDownList ID="orderStatus" runat="server" AutoPostBack="True">
            <asp:ListItem Value="1">未审核</asp:ListItem>
            <asp:ListItem Value="2">审核通过</asp:ListItem>
            <asp:ListItem Value="3">已发货</asp:ListItem>
            <asp:ListItem Value="4">已收货</asp:ListItem>
            <asp:ListItem Value="5">退货中</asp:ListItem>
          </asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td height="20" align="center" valign="middle">
          <asp:Button ID="btnSave" runat="server" Text="修 改" Style="border-right: #000000 1px solid;
            border-top: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid"
            Width="69" Height="22" OnClick="btnSave_Click"></asp:Button>
          <input type="button" id="btnInput" onclick="document.all.WebBrowser.ExecWB(6,1)"
            style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid;
            border-bottom: #000000 1px solid" value="打印文档资料" />
        </td>
      </tr>
    </table>
  </div>
  </form>
</body>
</html>
