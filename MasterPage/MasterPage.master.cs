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

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        labDate.Text = DateTime.Now.ToLongDateString();
        labDateTime.Text = DateTime.Today.DayOfWeek.ToString();
    }

    protected void lnkbtnShopCart_Click(object sender, EventArgs e)
    {
        if (Session["UID"] == null)
        {
            Response.Write("<script>alert('您还没有登录，请先登录！')</script>");

        }
        else
        {
            Response.Redirect("CommitGoods.aspx");
        }

    }
}
