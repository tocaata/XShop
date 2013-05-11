<%@ Control Language="C#" AutoEventWireup="true" CodeFile="navigationControl.ascx.cs"
  Inherits="UserControl_navigationControl" %>
<%-- <%@ OutputCache Duration ="15" VaryByParam="None" %>--%>
<table style="width: 220px; height: 549px; font-size: 9pt; vertical-align: top; border: 1px solid #d0d0d0; background: #2E9AFE" cellpadding="0" cellspacing="0">
  <tr valign="top" align="center">
    <td>
    <div style="display: inline-block; height: 60px; text-align: center;"><br /><h3 style="color: White">商品分类</h3></div>
      <asp:DataList ID="DLClass" runat="server" DataKeyField="category_id" OnEditCommand="DLClass_EditCommand">
        <ItemTemplate>
          <div class="nav" style="width: 220px">
            <div class="menu"><asp:Image ID="imageRefine" runat="server" CssClass="class_image" ImageUrl='<%#Eval("image_url")%>' /></div>
            <div class="menu"><asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="Edit" CssClass="white_link" ForeColor="White" Font-Size="16px" CausesValidation="False"><%# Eval("name") %></asp:LinkButton></div>
          </div>
        </ItemTemplate>
      </asp:DataList>
    </td>
  </tr>
</table>
