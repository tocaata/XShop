<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoadingControl.ascx.cs" Inherits="LoadingControl" %>        
<table style="background-image: url(../Images/index/��¼.jpg); width: 220px; height: 117px" border="0" cellpadding="0" cellspacing="0" runat =server   id=tabLoading >
    <tr>
        <td align="center" valign="top" style="height: 117px; width: 220px;" >
              <table style ="width: 178px; height: 90px; font-size: 9pt; font-family: ����;"   >
                <tr style ="width: 152px;height: 18px; font-size: 9pt; font-family: ����;">
                    <td>
                        &nbsp;
                        ��Ա����</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" Height="12px" Width="101px"></asp:TextBox></td>
                  
                </tr>
                <tr style ="width: 152px;height: 18px;font-size: 9pt; font-family: ����;">
                    <td>
                        &nbsp; &nbsp;
                        ���룺</td>
                    <td style="width: 158px">
                        <asp:TextBox ID="txtPassword" runat="server"  TextMode="Password" Height="12px" Width="101px"></asp:TextBox></td>
                   
                </tr>
                <tr style ="width: 152px;height: 18px;font-size: 9pt; font-family: ����;">
                    <td style="width: 1785px; height: 18px;" >
                        &nbsp;
                        ��֤�룺</td>
                    <td style="width: 158px">
                        <asp:TextBox ID="txtValid" runat="server" Height="12px" Width="62px"></asp:TextBox>
                        <asp:Label ID="lbValid" runat="server" Text="8888" BackColor="Silver" Font-Names="��Բ" ></asp:Label></td>
                  
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btnLoad" runat="server" Text="��¼" OnClick="btnLoad_Click" Height="18px" Width="40px" CausesValidation="False" /><asp:Button ID="btnRegister" runat="server" Text="ע��" OnClick="btnRegister_Click" Height="18px" Width="40px" CausesValidation="False" /></td>
                </tr>
            </table>  
        </td>
    </tr>
</table>
  <table  style="background-image: url(../Images/index/��¼.jpg); width: 220px; height: 117px; font-size: 9pt; font-family: ����;"   runat =server id=tabLoad visible =false border="0" cellpadding="0" cellspacing="0"  >
                <tr>
                          <td align="center" valign="top" style="height: 117px; width: 220px;" >
                             <br /><br /><table style ="width: 178px; height: 50px; font-size: 9pt; font-family: ����;"   >
                <tr>
                    <td colspan="2"  >
                        &nbsp; 
                        ��ӭ�ͻ�<u><%=Session["UserName"]%></u>���٣�</td>
                </tr> 
                <tr>
                    <td colspan="2" >
                        &nbsp; &nbsp;&nbsp;
                        <asp:HyperLink ID="hpLinkUser" runat="server" NavigateUrl="~/User/UpdateMember.aspx">������Ϣ</asp:HyperLink>
                        <asp:HyperLink ID="hpLinkAddAP" runat="server" NavigateUrl="~/User/AddAdvancePay.aspx">��Ա��ֵ</asp:HyperLink></td>
                </tr>
            </table></td></tr></table>


      
           
             