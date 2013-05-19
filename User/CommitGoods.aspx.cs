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
using System.Text.RegularExpressions;
using System.Collections.Specialized;

public partial class User_CommitGoods : System.Web.UI.Page
{
    UserInfoClass ucObj = new UserInfoClass();
    MangerClass mcObj = new MangerClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetUserId();
            ShopCartBind();
            TotalDs();
        }
    }
    //绑定市场价
    public string GetMKPStr(string P_Str_MarketPrice)
    {
        return ucObj.VarStr(P_Str_MarketPrice, 1);
    }
    //绑定会员价
    public string GetMBPStr(string P_Str_MemberPrice)
    {
        return ucObj.VarStr(P_Str_MemberPrice, 1);
    }
    //绑定小计
    public string GetSPStr(string P_Str_SumPrice)
    {
        return ucObj.VarStr(P_Str_SumPrice, 1);
    }
    /// <summary>
    /// 获取购物车中的商品信息
    /// </summary>
    public void ShopCartBind()
    {
        int userId = GetUserId();
        ucObj.SCIBind(gvShopCart, userId);
    }
   /// <summary>
   /// 显示购物车中的商品合计金额和商品数量
   /// </summary>
    public void  TotalDs()
    {
       GetUserId();
       DataTable ds= ucObj.ReturnTotalDs(Convert.ToInt32(Session["UID"].ToString()));
       lbSumPrice.Text = ucObj.VarStr(ds.Rows[0][0].ToString(),1);
       lbSumNum.Text = ucObj.VarStr(ds.Rows[0][1].ToString(),1);
    }
    protected void lnkbtnContinue_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
    protected void lnkbtnCheck_Click(object sender, EventArgs e)
    {
        Response.Redirect("CheckOut.aspx");
    }
    protected void lnkbtnClear_Click(object sender, EventArgs e)
    {
        GetUserId();
        ucObj.ClearShopCart(Convert.ToInt32(Session["UID"].ToString()));
        ShopCartBind();
        TotalDs();
        lbLag.Visible = true;
    }
    protected void gvShopCart_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GetUserId();
        gvShopCart.PageIndex = e.NewPageIndex;
        ShopCartBind();
        
    }
    protected void gvShopCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GetUserId();
        int P_Int_CartID = Convert.ToInt32(gvShopCart.DataKeys[e.RowIndex].Value.ToString());
        ucObj.RemoveOrderItemByID(Convert.ToInt32(Session["UID"].ToString()), P_Int_CartID);
        ShopCartBind();
        TotalDs();
    }
    protected void gvShopCart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GetUserId();
        gvShopCart.EditIndex = -1;
        ShopCartBind();
        TotalDs();
    }
    protected void gvShopCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GetUserId();
        IOrderedDictionary a = e.Keys, b = e.NewValues;

        int P_Int_CartID = Convert.ToInt32(gvShopCart.DataKeys[e.RowIndex].Value.ToString());
        int P_Int_Num =Convert.ToInt32( ((TextBox)(gvShopCart.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString());
        if (IsValidNum(P_Int_Num.ToString()) == true)
        {
            ucObj.UpdateItemOrder(Convert.ToInt32(Session["UID"].ToString()), P_Int_CartID, P_Int_Num);
            gvShopCart.EditIndex = -1;
            ShopCartBind();
            TotalDs();
        }
        else
        {
            gvShopCart.EditIndex = -1;
            ShopCartBind();
            TotalDs();
        }
    }
    protected void gvShopCart_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvShopCart.EditIndex = e.NewEditIndex;
        GetUserId();
        ShopCartBind();
        TotalDs();
    }
    //判断修改的数据是否为有效的数据
    public bool IsValidNum(string num)
    {
        return Regex.IsMatch(num, @"^\+?[1-9][0-9]*$");
    }

    protected int GetUserId()
    {
        try
        {
            return Convert.ToInt32(Session["UID"].ToString());
        }
        catch (Exception)
        {
            Response.Redirect("index.aspx?login=false");
        }
        return -1;
    }
}
