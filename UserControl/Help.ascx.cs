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

public partial class UserControl_Help : System.Web.UI.UserControl
{
    protected string content = "", header = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string sName = Page.Request.QueryString["TextName"].ToString();
        string path = Server.MapPath("~\\App_Data\\" + sName + ".html");
        System.IO.StreamReader reader = new System.IO.StreamReader(path, System.Text.Encoding.Default);
        header = reader.ReadLine();
        content = reader.ReadToEnd();
        reader.Close();
    }
}
