<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MHelp.ascx.cs" Inherits="UserControl_MHelp" %>
<table  style ="width:985px;background: #D8D8D8; height :41px; font-size: 9pt; text-align: center;" cellpadding="0" cellspacing="0">
    <tr>
        <td  >
        <A href="Help.aspx?TextName=jkfs" style="font-size: 9pt;text-decoration:none; color: black;">交款方式</A>┊<A href="Help.aspx?TextName=thhyz"  style="font-size: 9pt;text-decoration:none; color: black;">退换货原则</A>┊<A href="Help.aspx?TextName=psfw"  style="font-size: 9pt;text-decoration:none;color: black;">配送范围</A>┊<A href="Help.aspx?TextName=jytk"  style="font-size: 9pt;text-decoration:none; color: black;">交易条款</A>┊<A href="Help.aspx?TextName=bmxy"  style="font-size: 9pt;text-decoration:none; color: black;">保密协议</A>┊<asp:LinkButton ID="lbtnALogin" runat="server" 
        OnClick="lbtnALogin_Click" Font-Size="9pt" Font-Underline="False" ForeColor="Black" CausesValidation="False">后台入口</asp:LinkButton>
            </td>
    </tr>
</table>
