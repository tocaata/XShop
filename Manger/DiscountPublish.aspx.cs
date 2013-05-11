using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Manger_DiscountPublish : System.Web.UI.Page
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
        return mcObj.VarStr(P_Str_MemberPrice, 2);
    }
    /// <summary>
    /// 绑定所有商品的信息
    /// </summary>
    public void gvBind()
    {
        DataSet ds = mcObj.GetGoodsInfoDs("GoodsInfo");
        gvGoodsInfo.DataSource = ds.Tables["GoodsInfo"].DefaultView;
        gvGoodsInfo.DataBind();
    }
    /// <summary>
    /// 在搜索中绑定商品信息
    /// </summary>
    public void gvSearchBind()
    {
        DataSet ds = mcObj.SearchGoodsInfoDs("GoodsInfo", txtKey.Text.Trim());
        gvGoodsInfo.DataSource = ds.Tables["GoodsInfo"].DefaultView;
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

    protected void DiscountChanged(object sender, EventArgs e) 
    {
        GridViewRow gvr = (GridViewRow)((CheckBox)sender).Parent.Parent;
        string values = gvGoodsInfo.DataKeys[gvr.RowIndex].Value.ToString();

        mcObj.SetDiscount(Int32.Parse(values), ((CheckBox)sender).Checked);
    }

    protected void gvGoodsInfo_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvGoodsInfo.EditIndex = e.NewEditIndex;
        gvBind();
    }

    protected void gvGoodsInfo_RowCancel(object sender, GridViewCancelEditEventArgs e)
    {
        gvGoodsInfo.EditIndex = -1;
        gvBind();
    }

    protected void gvGoodsInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int GoodID = Convert.ToInt32(gvGoodsInfo.DataKeys[e.RowIndex].Value.ToString());
        Double Price = Convert.ToDouble(((TextBox)(gvGoodsInfo.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString());
        mcObj.SetPrice(GoodID, Price);
        gvGoodsInfo.EditIndex = -1;
        gvBind();
    }
}