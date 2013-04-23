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

public partial class User_CommitGoods : System.Web.UI.Page
{
    UserInfoClass ucObj = new UserInfoClass();
    MangerClass mcObj = new MangerClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {  
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
        ucObj.SCIBind("ShopCart", gvShopCart, Convert.ToInt32(Session["UID"].ToString()));
    }
   /// <summary>
   /// 显示购物车中的商品合计金额和商品数量
   /// </summary>
    public void  TotalDs()
    {
       DataSet ds= ucObj.ReturnTotalDs(Convert.ToInt32(Session["UID"].ToString()), "TotalInfo");
       lbSumPrice.Text = ucObj.VarStr(ds.Tables["TotalInfo"].Rows[0][0].ToString(),1);
       lbSumNum.Text = ucObj.VarStr(ds.Tables["TotalInfo"].Rows[0][1].ToString(),1);
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
        ucObj.DeleteShopCart(Convert.ToInt32(Session["UID"].ToString()));
        ShopCartBind();
        TotalDs();
        lbLag.Visible = true;
    }
    protected void gvShopCart_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShopCart.PageIndex = e.NewPageIndex;
        ShopCartBind();
        
    }
    protected void gvShopCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int P_Int_CartID = Convert.ToInt32(gvShopCart.DataKeys[e.RowIndex].Value.ToString());
        ucObj.DeleteShopCartByID(Convert.ToInt32(Session["UID"].ToString()), P_Int_CartID);
        ShopCartBind();
        TotalDs();
    }
    protected void gvShopCart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvShopCart.EditIndex = -1;
        ShopCartBind();
        TotalDs();
    }
    protected void gvShopCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int P_Int_CartID = Convert.ToInt32(gvShopCart.DataKeys[e.RowIndex].Value.ToString());
        int P_Int_Num =Convert.ToInt32( ((TextBox)(gvShopCart.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString());
        if (IsValidNum(P_Int_Num.ToString()) == true)
        {
            ucObj.UpdateSCI(Convert.ToInt32(Session["UID"].ToString()), P_Int_CartID, P_Int_Num);
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
        ShopCartBind();
        TotalDs();
    }
    //判断修改的数据是否为有效的数据
    public bool IsValidNum(string num)
    {
        return Regex.IsMatch(num, @"^\+?[1-9][0-9]*$");
    }

 
}
