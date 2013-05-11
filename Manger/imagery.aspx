<%@ Page Language="C#" AutoEventWireup="true" CodeFile="imagery.aspx.cs" Inherits="Manger_imagegallery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>无标题页</title>
</head>
<body style="font-size: 9pt;">
  <form id="form1" runat="server">
  <div>
    <table cellspacing="0" cellpadding="0" width="450" align="center" border="0">
      <tr>
        <th height="25" align="left">
          上传商品图片
        </th>
      </tr>
    </table>
    <table cellspacing="0" cellpadding="0" width="450" align="center" border="0">
      <tr>
        <td height="23">
          <asp:DataList ID="dlImage" runat="server" DataKeyField="ImageID" RepeatDirection="Horizontal"
            RepeatColumns="4" OnDeleteCommand="dlImage_DeleteCommand">
            <ItemTemplate>
              <table>
                <tr valign="top" align="left">
                  <td align="left" valign="top">
                    <asp:Image ID="imgUrl" runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem,"ImageUrl")%>' />
                  </td>
                </tr>
                <tr>
                  <td align="left" valign="top">
                    <asp:Label ID="lbImageName" runat="server" Font-Bold="True" Font-Names="隶书" Text='<%#DataBinder.Eval(Container.DataItem,"ImageName")%>'></asp:Label>
                  </td>
                </tr>
                <tr>
                  <td align="center" valign="top">
                    <asp:LinkButton ID="lnkbtnDelete" runat="server" CommandName="delete">删除</asp:LinkButton>
                  </td>
                </tr>
              </table>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" />
          </asp:DataList>
        </td>
      </tr>
      <tr>
        <tr>
          <td valign="top">
            <asp:FileUpload ID="imageUpload" runat="server" Font-Size="9pt" />
            <asp:Button ID="UploadImage" Text="上传" runat="server" OnClick="UploadImage_OnClick" />
          </td>
        </tr>
        <tr>
          <td valign="top">
            <asp:Label ID="lbIamge" runat="server" Font-Bold="True" Font-Size="9pt"></asp:Label>
          </td>
        </tr>
    </table>
  </div>
  </form>
</body>
</html>
