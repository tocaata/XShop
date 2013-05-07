using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class User_OrderItems : System.Web.UI.Page
{
    UserInfoClass ucObj = new UserInfoClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UID"] == null)
            {
                Response.Write("<script>alert('您还没有登录，请先登录！')</script>");
            }
            else
            {
                ucObj.OrderBind(OrderItems, int.Parse(Session["UID"].ToString()));
            }
        }
    }

    protected void RepCmd(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "detailSee")
        {
            Session["address"] = "";
            Session["address"] = "index.aspx";
            Response.Redirect("~/User/GoodsDetail.aspx?GoodsID=");
        }
    }
}