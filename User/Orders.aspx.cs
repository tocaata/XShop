using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class User_Orders : System.Web.UI.Page
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
                ucObj.OrderBind(Orders, int.Parse(Session["UID"].ToString()));
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
        else if (e.CommandName == "confirm")
        {
            int order_id = Convert.ToInt32(e.CommandArgument);
            try
            {
                ucObj.OrderChangeStatus(order_id, 1);
                Response.Write("<script>alert('确认收货成功');location='" + Request.Url.ToString() + "'</script>");
                //Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ecp)
            {
                Response.Write("<script>alert('" + ecp.Message + "');location='" + Request.Url.ToString() + "'</script>");
                //Response.Redirect(Request.Url.ToString());
            }
        } else if (e.CommandName == "return")
        {
            int order_id = Convert.ToInt32(e.CommandArgument);
            try
            {
                ucObj.OrderChangeStatus(order_id, 2);
                Response.Write("<script>alert('已提交退货申请');location='" + Request.Url.ToString() + "'</script>");
                //Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ecp)
            {
                Response.Write("<script>alert('" + ecp.Message + "');location='" + Request.Url.ToString() + "'</script>");
                //Response.Redirect(Request.Url.ToString());
            }
        }
    }

    protected String StatusToString(int status)
    {
        String stat = "";
        switch (Convert.ToInt32(Eval("status")))
        {
            case 0: stat = "购物车";
                break;
            case 1: stat = "未审核";
                break;
            case 2: stat = "审核";
                break;
            case 3: stat = "出货";
                break;
            case 4: stat = "已收货";
                break;
            case 5: stat = "退货中";
                break;
        }
        return stat;
    }
}