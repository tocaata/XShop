<%@ Control Language="C#" AutoEventWireup="true" CodeFile="navigationControl.ascx.cs"
  Inherits="UserControl_navigationControl" %>
<%-- <%@ OutputCache Duration ="15" VaryByParam="None" %>--%>
<table style="width: 220px; height: 549px; font-size: 9pt; font-family: 宋体; vertical-align: top; border: 1px solid #d0d0d0" cellpadding="0" cellspacing="0">
  <tr valign="top" align="center">
    <td>
    <div style="display: inline-block; height: 60px; text-align: center;"><br /><h3>商品分类</h3></div>
      <asp:DataList ID="DLClass" runat="server" DataKeyField="category_id" OnEditCommand="DLClass_EditCommand">
        <ItemTemplate>
          <table>
            <tr>
              <td align="left" style="width: 28px; height: 23px;">
                <asp:Image ID="imageRefine" runat="server" CssClass="class_image" ImageUrl='<%#Eval("image_url")%>' />
              </td>
              <td>
              </td>
              <td align="left" style="width: 80px; font-size: 9pt; font-family: 宋体;">
                <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="Edit" CausesValidation="False"><%# Eval("name") %></asp:LinkButton>
              </td>
            </tr>
          </table>
        </ItemTemplate>
      </asp:DataList>
    </td>
  </tr>
</table>
