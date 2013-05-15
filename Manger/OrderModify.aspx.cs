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
using System.Data.SqlClient;

public partial class Manger_OrderModify : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    UserInfoClass uiObj = new UserInfoClass();
    public static CommonProperty order = new CommonProperty();
    protected void Page_Load(object sender, EventArgs e)
    {
        order = GetOrderInfo();
        if (!IsPostBack)
        {
            rpBind();
            IsCPCPBind();
        }
     
    }
    public void IsCPCPBind()
    {
        DataTable ds = DBClass.GetDataTable("SELECT  * FROM orders WHERE order_id = @order_id", new SqlParameter("@order_id", Convert.ToInt32(Request["order_id"].Trim())));
        orderStatus.SelectedValue = ds.Rows[0][5].ToString();
    }
    public void rpBind()
    {
        DataTable ds = DBClass.GetDataTable("SELECT order_items.*, items.name AS name, order_items.price * order_items.count AS sum_price, items.is_discount FROM order_items JOIN items ON order_items.item_id = items.item_id WHERE order_id = @order_id", new SqlParameter("@order_id", Convert.ToInt32(Request["order_id"].Trim())));
        rptOrderItems.DataSource = ds.DefaultView;
        rptOrderItems.DataBind();
    }
    /// <summary>
    /// 获取指定订单信息
    /// </summary>
    /// <returns>返回CommonProperty类的实例对像</returns>
    public CommonProperty GetOrderInfo()
    {
        //0: order_id, 1: name, 2: create_at, 3: finish_at, 4: user_id, 5: status, 6: address, 7: phone, 8: is_speed
        DataTable ds = DBClass.GetDataTable("SELECT *, (SELECT SUM(price * count) FROM order_items WHERE order_items.order_id = orders.order_id) AS total_price FROM orders WHERE order_id = @order_id",
            new SqlParameter("@order_id", Convert.ToInt32(Request["order_id"].Trim())));
        //0: user_id, 1: name, 2: password, 3: email, 4: true_name, 5: address, 6: phone, 7: create_at, 8: delete_at, 9: sex, 10: city
        DataTable UIDs = DBClass.GetDataTable("SELECT * FROM users WHERE user_id = @user_id", new SqlParameter("@user_id", Convert.ToInt32(ds.Rows[0][4].ToString())));
        order.OrderNo = Convert.ToInt32(ds.Rows[0][0].ToString());
        order.OrderTime = Convert.ToDateTime(ds.Rows[0][2].ToString());
        order.ProductPrice = ds.Rows[0][9].ToString().Length == 0 ? 0 : float.Parse(ds.Rows[0][9].ToString());
        order.ReceiverName=ds.Rows[0][1].ToString();
        order.ReceiverPhone =ds.Rows[0][7].ToString();
        order.ReceiverAddress =ds.Rows[0][6].ToString();
        order.BuyerAddress = UIDs.Rows[0][5].ToString();
        order.BuyerEmail = UIDs.Rows[0][3].ToString();
        order.BuyerName = UIDs.Rows[0][4].ToString();
        order.BuyerPhone = UIDs.Rows[0][6].ToString();
        order.Status = Convert.ToInt32(ds.Rows[0][5].ToString());
        
        return (order);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        mcObj.UpdateOI(Convert.ToInt32(Request["order_id"].Trim()), Convert.ToInt32(orderStatus.SelectedValue));
        Response.Write("<script>alert('修改成功！')</script>");
        return;
    }
}
