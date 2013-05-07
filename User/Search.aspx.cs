using System;
using System.Collections.Generic;
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


public partial class User_Search : System.Web.UI.Page
{
    UserInfoClass ucObj = new UserInfoClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["string"] != null && Request["string"].Trim() != "")
            {
                ucObj.SearchBind(searchResult, Request["string"].Trim());
            }
            else
            {
                Response.Write("<script>alert('请输入商品名！');</script>");
            }
        }
    }
    protected void ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "detailSee")
        {
            Response.Redirect("~/User/GoodsDetail.aspx?GoodsID=" + Convert.ToInt32(searchResult.DataKeys[e.Item.ItemIndex].ToString()));
        }
        else if (e.CommandName == "buyGoods")
        {
            AddShopCart(e, searchResult);
        }
    }

    //当购买商品时，获取商品信息
    public SaveSubGoodsClass GetSubGoodsInformation(DataListCommandEventArgs e, DataList DLName)
    {
        //获取购物车中的信息
        SaveSubGoodsClass Goods = new SaveSubGoodsClass();
        Goods.GoodsID = int.Parse(DLName.DataKeys[e.Item.ItemIndex].ToString());
        string GoodsStyle = e.CommandArgument.ToString();
        Goods.MemberPrice = float.Parse(GoodsStyle);
        return (Goods);
    }

    public void AddShopCart(DataListCommandEventArgs e, DataList DLName)
    {
        if (Session["UID"] != null)
        {
            SaveSubGoodsClass Goods = null;
            Goods = GetSubGoodsInformation(e, DLName);
            if (Goods == null)
            {
                //显示错误信息
                Response.Write("<script>alert('没有可用的数据');</script>");
                return;
            }
            else
            {
                ucObj.AddShopCart(Goods.GoodsID, Goods.MemberPrice, Convert.ToInt32(Session["UID"].ToString()), Goods.GoodsWeight);
                Response.Write("<script>alert('恭喜您，添加成功！')</script>");

            }
        }
        else
        {
            Response.Write("<script>alert('请先登录，谢谢合作！');</script>");

        }

    }
}