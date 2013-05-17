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
public partial class Manger_Category : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvBind();
        }
    }
    public void gvBind()
    {
        DataTable dt = mcObj.GetCategory("ClassInfo");
        gvCategoryList.DataSource = dt.DefaultView;
        gvCategoryList.DataBind();
    }

    protected void gvCategoryList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCategoryList.PageIndex = e.NewPageIndex;
        gvBind();

    }
    protected void gvCategoryList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int P_Int_ClassID = Convert.ToInt32(gvCategoryList.DataKeys[e.RowIndex].Value);

        try
        {
            DBClass.ExecuteCommand("DELETE FROM categories WHERE category_id = @cat_id", new SqlParameter("@cat_id", P_Int_ClassID));
        }
        catch (Exception)
        {
            Response.Write("<script>alert('在删除分类之前，需要删除该分类的所有商品！');</script>");
        }
        gvBind();
    }
}
