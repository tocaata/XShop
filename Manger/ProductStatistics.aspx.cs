using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manger_ProductStatistics : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Sumbit.Click += new EventHandler(this.Sumbit_Click);
            Start.SelectedDate = DateTime.Now.AddMonths(-1);
            End.SelectedDate = DateTime.Now;
            DataTable dt = DBClass.GetDataTable("SELECT items.item_id, items.name, SUM(order_items.count) AS count, SUM(order_items.count * order_items.price) AS total_price FROM items JOIN order_items ON items.item_id = order_items.item_id JOIN orders ON orders.order_id = order_items.order_id WHERE orders.create_at > @start AND orders.create_at < @end AND orders.status > 3 GROUP BY items.item_id, items.name",
                new SqlParameter("@start", DateTime.Now.AddMonths(-1)), new SqlParameter("@end", DateTime.Now));
            ProductStat.DataSource = dt.DefaultView;
            ProductStat.DataBind();
        }
    }
    protected void Sumbit_Click(object sender, EventArgs e)
    {
        if (Start.SelectedDate == DateTime.MinValue || End.SelectedDate == DateTime.MinValue || Start.SelectedDate > End.SelectedDate)
        {
            Response.Write("<script>alert('请选择正确的开始时间和结束时间！');</script>");
            return;
        }
        DataTable dt = DBClass.GetDataTable("SELECT items.item_id, items.name, SUM(order_items.count) AS count, SUM(order_items.count * order_items.price) AS total_price FROM items JOIN order_items ON items.item_id = order_items.item_id JOIN orders ON orders.order_id = order_items.order_id WHERE orders.create_at > @start AND orders.create_at < @end AND orders.status > 3 GROUP BY items.item_id, items.name",
            new SqlParameter("@start", Start.SelectedDate == DateTime.MinValue ? DateTime.Now : Start.SelectedDate), new SqlParameter("@end", End.SelectedDate == DateTime.MinValue ? DateTime.Now : End.SelectedDate));
        ProductStat.DataSource = dt.DefaultView;
        ProductStat.DataBind();
    }
}