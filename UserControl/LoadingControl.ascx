<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoadingControl.ascx.cs" Inherits="LoadingControl" %>        
<table style="background-image: url(../Images/index/登录.jpg); width: 220px; height: 117px" border="0" cellpadding="0" cellspacing="0" runat =server   id=tabLoading >
    <tr>
        <td align="center" valign="top" style="height: 117px; width: 220px;" >
              <table style ="width: 178px; height: 90px; font-size: 9pt; font-family: 宋体;"   >
                <tr style ="width: 152px;height: 18px; font-size: 9pt; font-family: 宋体;">
                    <td>
                        &nbsp;
                        会员名：</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" Height="12px" Width="101px"></asp:TextBox></td>
                  
                </tr>
                <tr style ="width: 152px;height: 18px;font-size: 9pt; font-family: 宋体;">
                    <td>
                        &nbsp; &nbsp;
                        密码：</td>
                    <td style="width: 158px">
                        <asp:TextBox ID="txtPassword" runat="server"  TextMode="Password" Height="12px" Width="101px"></asp:TextBox></td>
                   
                </tr>
                <tr style ="width: 152px;height: 18px;font-size: 9pt; font-family: 宋体;">
                    <td style="width: 1785px; height: 18px;" >
                        &nbsp;
                        验证码：</td>
                    <td style="width: 158px">
                        <asp:TextBox ID="txtValid" runat="server" Height="12px" Width="62px"></asp:TextBox>
                        <asp:Label ID="lbValid" runat="server" Text="8888" BackColor="Silver" Font-Names="幼圆" ></asp:Label></td>
                  
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btnLoad" runat="server" Text="登录" OnClick="btnLoad_Click" Height="18px" Width="40px" CausesValidation="False" /><asp:Button ID="btnRegister" runat="server" Text="注册" OnClick="btnRegister_Click" Height="18px" Width="40px" CausesValidation="False" /></td>
                </tr>
            </table>  
        </td>
    </tr>
</table>
  <table  style="background-image: url(../Images/index/登录.jpg); width: 220px; height: 117px; font-size: 9pt; font-family: 宋体;"   runat =server id=tabLoad visible =false border="0" cellpadding="0" cellspacing="0"  >
                <tr>
                          <td align="center" valign="top" style="height: 117px; width: 220px;" >
                             <br /><br /><table style ="width: 178px; height: 50px; font-size: 9pt; font-family: 宋体;"   >
                <tr>
                    <td colspan="2"  >
                        &nbsp; 
                        欢迎客户<u><%=Session["UserName"]%></u>光临！</td>
                </tr> 
                <tr>
                    <td colspan="2" >
                        &nbsp; &nbsp;&nbsp;
                        <asp:HyperLink ID="hpLinkUser" runat="server" NavigateUrl="~/User/UpdateMember.aspx">更新信息</asp:HyperLink>
                        <asp:HyperLink ID="hpLinkAddAP" runat="server" NavigateUrl="~/User/AddAdvancePay.aspx">会员充值</asp:HyperLink></td>
                </tr>
            </table></td></tr></table>


      
           
             