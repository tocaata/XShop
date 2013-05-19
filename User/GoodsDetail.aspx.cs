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

public partial class User_GoodsDetail : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    UserInfoClass urObj = new UserInfoClass();
    DBClass dbObj = new DBClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                Convert.ToInt32(Request["GoodsID"].Trim());
                GetGoodsInfo();
                CommentBind(Convert.ToInt32(Request["GoodsID"].Trim()));
            }
            catch (Exception)
            {
                Response.Write("<script>alert('该页面无法访问');location='javascript:history.go(-1)';</script>");
            }
        }
    }
    public string GetClass(int P_Int_ClassID)
    {
        string P_Str_ClassName = mcObj.GetClass(P_Int_ClassID);
        return P_Str_ClassName;
    }
    public void GetGoodsInfo()
    {
        try
        {
            DataTable ds = mcObj.GetGoodsInfoByIDDs(Convert.ToInt32(Request["GoodsID"].Trim()));
            DetailsView.DataSource = ds.DefaultView;
            DetailsView.DataBind();
        }
        catch (Exception)
        {
        }
        
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        if (Session["address"] == null)
            Response.Redirect("index.aspx");
        else
        {

            string addr = Session["address"].ToString();
            Response.Redirect(addr);
        } 
    }

    protected void CommentBind(int ItemID)
    {
        DataTable ds = urObj.GetComment(ItemID);
        Comments.DataSource = ds.DefaultView;
        Comments.DataBind();
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        int UserId = Convert.ToInt32(Session["UID"].ToString());
        int ItemId = Convert.ToInt32(Request["GoodsID"].Trim());
        if (urObj.HasRightComment(UserId, ItemId))
        {
            DBClass.ExecuteCommand("INSERT INTO comments (user_id, item_id, comment) VALUES (@user_id, @item_id, @comment)", new SqlParameter("@user_id", UserId),
                new SqlParameter("@item_id", ItemId), new SqlParameter("@comment", Comment.Text.ToString()));
            GetGoodsInfo();
            CommentBind(Convert.ToInt32(Request["GoodsID"].Trim()));
        }
        else
        {
            Response.Write("<script>alert('没有买过该商品，不能评价！');location='javascript:history.go(-1)';</script>");
        }
    }
}
