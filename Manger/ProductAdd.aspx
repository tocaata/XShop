<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductAdd.aspx.cs" Inherits="Manger_ProductAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>无标题页</title>
</head>
<body style="font-family: 宋体; font-size: 9pt;">
  <form id="Form1" method="post" runat="server">
  <table cellspacing="0" cellpadding="0" width="480" align="center" border="0">
    <tr>
      <th align="left" height="25" colspan="2">
        &nbsp;&nbsp;
        <asp:Label ID="lblTitleInfo" runat="server">添加商品</asp:Label>
      </th>
    </tr>
  </table>
  <table cellspacing="1" cellpadding="1" width="480" align="center" border="0" id="tabAddProduct">
    <tr>
      <td style="width: 478px">
        <table class="tableBorder" cellspacing="0" cellpadding="0" width="95%" align="center"
          border="0">
          <tr>
            <td align="left" width="80">
              商品名称：
            </td>
            <td style="width: 359px">
              <asp:TextBox ID="txtName" runat="server"></asp:TextBox><font color="red">*</font>
            </td>
          </tr>
          <tr>
            <td align="left">
              父级类别名：
            </td>
            <td style="width: 359px">
              <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True">
              </asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td align="left">
              库存量：
            </td>
            <td style="width: 359px">
              <asp:TextBox ID="txtUnit" runat="server"></asp:TextBox><font color="red">*</font>
            </td>
          </tr>
          <tr>
            <td align="left">
              商城价格：
            </td>
            <td colspan="3">
              <asp:TextBox ID="txtMemberPrice" runat="server">0</asp:TextBox><font color="red">*<asp:RegularExpressionValidator
                ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMemberPrice"
                ErrorMessage="请正确输入（格式：1.00）" ValidationExpression="^[0-9]+(.[0-9]{2})?$"></asp:RegularExpressionValidator></font>
            </td>
          </tr>
          <tr>
            <td align="left" colspan="4" style="height: 15px">
              <b>附件设置</b>
            </td>
          </tr>
          <%--<tr>
            <td align="left" style="height: 22px">
              商品图像：
            </td>
            <td colspan="3" style="height: 22px">
              <asp:DropDownList ID="ddlUrl" runat="server" OnSelectedIndexChanged="ddlUrl_SelectedIndexChanged"
                AutoPostBack="True">
              </asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td align="left" style="height: 22px">
            </td>
            <td colspan="3" style="height: 22px">
              <asp:ImageMap ID="ImageMapPhoto" runat="server" ImageUrl="~/Images/icon_7.gif">
              </asp:ImageMap>
            </td>
          </tr>--%>
          <tr>
          <td align="left" style="height: 22px">
              商品图像：
          </td>
          <td valign="top">
            <asp:FileUpload ID="imageUpload" runat="server" Font-Size="9pt" />
            <asp:Button ID="UploadImage" Text="上传" runat="server" OnClick="UploadImage_OnClick" />
          </td>
          </tr>
          <tr>
            <td align="left" style="height: 22px"></td>
            <td valign="top">
              <asp:Label ID="lbIamge" runat="server" Font-Bold="True" Font-Size="9pt"></asp:Label>
              <asp:TextBox ID="ImageUrl" runat="server" Visible="false"></asp:TextBox>
            </td>
          </tr>
          <%--<tr>
            <td align="left">
              是否参与打折：
            </td>
            <td colspan="3">
              <asp:CheckBox ID="cbxDiscount" runat="server" Checked="True" AutoPostBack="True">
              </asp:CheckBox>
            </td>
          </tr>--%>
          <tr>
            <td align="left">
              商品简单描述：
            </td>
            <td style="width: 359px">
              <asp:TextBox ID="txtShortDesc" runat="server" Width="307px" Height="89px" TextMode="MultiLine"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td align="center" colspan="4">
              <br>
              <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:Button><asp:Button
                ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click"></asp:Button>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
  </form>
</body>
</html>
