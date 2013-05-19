using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
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
                ucObj.OrderTabBind(OrderItems, int.Parse(Session["UID"].ToString()), Convert.ToInt32(Request["order_id"].Trim()));
                DataTable dt = DBClass.GetDataTable("SELECT SUM(price * count), SUM(count) FROM order_items WHERE order_id = @order_id", new SqlParameter("@order_id", Convert.ToInt32(Request["order_id"].Trim())));
                lbSumPrice.Text = dt.Rows[0][0].ToString();
                lbSumNum.Text = dt.Rows[0][1].ToString();
            }
        }
    }

    protected void RepCmd(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "detailSee")
        {
            Session["address"] = "";
            Session["address"] = "Orders.aspx?order_id=" + Request["order_id"].Trim();
            Response.Redirect("~/User/GoodsDetail.aspx?GoodsID=");
        }
    }

    protected void OrderIndexChange(object sender, GridViewPageEventArgs e)
    {
        OrderItems.PageIndex = e.NewPageIndex;
        ucObj.OrderTabBind(OrderItems, int.Parse(Session["UID"].ToString()), 2);

    }
}