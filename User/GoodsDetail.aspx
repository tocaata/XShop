<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
  CodeFile="GoodsDetail.aspx.cs" Inherits="User_GoodsDetail" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" runat="Server">
  <table cellspacing="0" cellpadding="0" width="760px" align="center" border="0">
    <tr>
      <th align="left" height="25" colspan="2" style=" border-bottom: 2px #d0d0d0 solid;">
        <span class="name" style="padding-left: 30px; width: 130px"><asp:Label ID="lblTitleInfo" runat="server">商品详细信息</asp:Label></span>
      </th>
    </tr>
  </table>
  <div>
    <asp:DetailsView ID="DetailsView" runat="server" Height="65px" Width="730px" CssClass="tab_detail"
      AutoGenerateRows="False" CellPadding="4" ForeColor="#333333" GridLines="None">
      <AlternatingRowStyle BackColor="White" />
      <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
      <EditRowStyle BackColor="#2461BF" />
      <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
      <Fields>
        <asp:BoundField DataField="name" HeaderText="商品名称">
          <HeaderStyle CssClass="td_header" />
        </asp:BoundField>
        <asp:BoundField DataField="class_name" HeaderText="父类别名">
          <HeaderStyle CssClass="td_header" />
        </asp:BoundField>
        <asp:BoundField DataField="price" HeaderText="商城价格">
          <HeaderStyle CssClass="td_header" />
        </asp:BoundField>
        <asp:ImageField DataImageUrlField="image_url" HeaderText="商品图像">
          <HeaderStyle CssClass="td_header" />
        </asp:ImageField>
        <asp:CheckBoxField DataField="is_discount" HeaderText="是否打折">
          <HeaderStyle CssClass="td_header" />
        </asp:CheckBoxField>
        <asp:BoundField DataField="description" HeaderText="商品描述">
          <HeaderStyle CssClass="td_header" />
        </asp:BoundField>
      </Fields>
      <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
      <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
      <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
      <RowStyle BackColor="#EFF3FB" />
    </asp:DetailsView>
  </div>
  <div style="margin-left: 60px;">
    <h4>
      全部评论:</h4>
  </div>
  <div>
    <asp:Repeater ID="Comments" runat="server">
      <HeaderTemplate>
        <div style="margin-left: 20px;">
      </HeaderTemplate>
      <ItemTemplate>
        <div style="clear: both;">
          <div class="user_name">
            <span style="float: left">会员: <strong>
              <%# Eval("name") %></strong> </span>
          </div>
          <div class="comment">
            <div class="time">
              <%# Eval("create_at") %></div>
            <div class="content">
              <%# Eval("comment") %></div>
          </div>
        </div>
      </ItemTemplate>
      <FooterTemplate>
        </div>
      </FooterTemplate>
    </asp:Repeater>
    <br />
    <div>
      <div style="margin-left: 30px;" class="user">
        <div style="clear: both">
          评价内容</div>
        <asp:TextBox ID="Comment" CssClass="text" runat="server">评论</asp:TextBox>
        <p>
          <asp:Button ID="Submit" runat="server" Text="提交" OnClick="Submit_Click"></asp:Button>
          <asp:Button ID="btnExit" runat="server" Text="返回" OnClick="btnExit_Click"></asp:Button>
        </p>
      </div>
    </div>
  </div>
</asp:Content>
