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

public partial class Manger_Product : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvBind();
        }
    }
    public string GetClass(int P_Int_ClassID)
    {
        string P_Str_ClassName = mcObj.GetClass(P_Int_ClassID);
        return P_Str_ClassName;
    }
    public String GetVarStr(string P_Str_MemberPrice)
    {
       return  mcObj.VarStr(P_Str_MemberPrice, 2);
    }
    /// <summary>
    /// 绑定所有商品的信息
    /// </summary>
    public void gvBind()
    {
        DataTable ds = mcObj.GetGoodsInfoDs();
        gvGoodsInfo.DataSource = ds.DefaultView;
        gvGoodsInfo.DataBind();
    }
    /// <summary>
    /// 在搜索中绑定商品信息
    /// </summary>
    public void gvSearchBind()
    {
        DataTable ds = mcObj.SearchGoodsInfoDs(txtKey.Text.Trim());
        gvGoodsInfo.DataSource = ds.DefaultView;
        gvGoodsInfo.DataBind();
    }

    protected void gvGoodsInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGoodsInfo.PageIndex = e.NewPageIndex;
        if (txtKey.Text.Trim() == "")
        {
            gvBind();
        }
        else
        {
            gvSearchBind();
        }
    }

    protected void gvGoodsInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int P_Int_GoodsID = Convert.ToInt32(gvGoodsInfo.DataKeys[e.RowIndex].Value);
        mcObj.DeleteGoodsInfo(P_Int_GoodsID);
        if (txtKey.Text.Trim() == "")
        {
            gvBind();
        }
        else
        {
            gvSearchBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gvSearchBind();
    }
}
