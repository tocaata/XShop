<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserStatistics.aspx.cs" Inherits="Manger_UserStatistics" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link rel="stylesheet" href="../main.css" type="text/css" />
  <title>无标题页</title>
</head>
<body style="font-family: 宋体; font-size: 9pt;">
  <form id="form1" runat="server">
  <div>
    <table cellspacing="0" cellpadding="0" width="640" align="center" border="0">
      <tr>
        <th class="tableHeaderText" height="25" align="left">
          <span style="">商品销售统计</span>
        </th>
      </tr>
    </table>
    <div style="text-align: center;">
      <div class="calendar">
        <asp:Calendar ID="Start" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4"
          DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" SelectedDate="<%# DateTime.Now %>"
          Height="180px" Width="200px">
          <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
          <NextPrevStyle VerticalAlign="Bottom" />
          <OtherMonthDayStyle ForeColor="#808080" />
          <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
          <SelectorStyle BackColor="#CCCCCC" />
          <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
          <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
          <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
      </div>
      <div class="calendar">
        <asp:Calendar ID="End" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4"
          DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" SelectedDate="<%# DateTime.Now %>"
          Height="180px" Width="200px">
          <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
          <NextPrevStyle VerticalAlign="Bottom" />
          <OtherMonthDayStyle ForeColor="#808080" />
          <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
          <SelectorStyle BackColor="#CCCCCC" />
          <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
          <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
          <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
      </div>
      <asp:Button ID="Sumbit" runat="server" Text="统计" OnClick="Sumbit_Click" />
    </div>
    <asp:GridView ID="UserStat" runat="server" AllowPaging="True" Align="center" AllowSorting="True"
      AutoGenerateColumns="False" DataKeyNames="user_id">
      <Columns>
        <asp:BoundField DataField="user_id" HeaderText="用户ID" InsertVisible="False" ReadOnly="True"
          SortExpression="user_id" />
        <asp:BoundField DataField="name" HeaderText="用户名" SortExpression="name" />
        <asp:BoundField DataField="count" HeaderText="购买商品总量" ReadOnly="True" SortExpression="count" />
        <asp:BoundField DataField="total_price" HeaderText="购买商品总额" ReadOnly="True" SortExpression="total_price" />
      </Columns>
    </asp:GridView>
    <br />
  </div>
  </form>
</body>
</html>
