using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UserControl_MHelp : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void lbtnALogin_Click(object sender, EventArgs e)
    {
        Response.Write("<script language=javascript>window.open('../Manger/Login.aspx','','width=455,height=255')</script>");
    }
}
