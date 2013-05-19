using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manger_UserStatistics : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Sumbit.Click += new EventHandler(this.Sumbit_Click);
            DataTable dt = DBClass.GetDataTable("SELECT users.user_id, users.name, SUM(order_items.count) AS count, SUM(order_items.count * order_items.price) AS total_price FROM users JOIN orders ON orders.user_id = users.user_id JOIN order_items ON order_items.order_id = orders.order_id LEFT JOIN carts ON carts.order_id = orders.order_id WHERE orders.create_at < @end AND orders.create_at > @start AND orders.status = 4 AND carts.cart_id IS NULL  GROUP BY users.user_id, users.name",
                new SqlParameter("@start", DateTime.Now.AddMonths(-1)), new SqlParameter("@end", DateTime.Now));
            UserStat.DataSource = dt.DefaultView;
            UserStat.DataBind();
        }
    }
    protected void Sumbit_Click(object sender, EventArgs e)
    {
        if (Start.SelectedDate == DateTime.MinValue || End.SelectedDate == DateTime.MinValue || Start.SelectedDate > End.SelectedDate)
        {
            Response.Write("<script>alert('请选择正确的开始时间和结束时间！');</script>");
            return;
        }
        DataTable dt = DBClass.GetDataTable("SELECT users.user_id, users.name, SUM(order_items.count) AS count, SUM(order_items.count * order_items.price) AS total_price FROM users JOIN orders ON orders.user_id = users.user_id JOIN order_items ON order_items.order_id = orders.order_id LEFT JOIN carts ON carts.order_id = orders.order_id WHERE orders.create_at < @end AND orders.create_at > @start AND orders.status = 4 AND carts.cart_id IS NULL  GROUP BY users.user_id, users.name",
            new SqlParameter("@start", Start.SelectedDate == DateTime.MinValue ? DateTime.Now : Start.SelectedDate), new SqlParameter("@end", End.SelectedDate == DateTime.MinValue ? DateTime.Now : End.SelectedDate));
        UserStat.DataSource = dt.DefaultView;
        UserStat.DataBind();
    }
}