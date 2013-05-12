using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_Goods : System.Web.UI.UserControl
{
    MangerClass mcObj = new MangerClass();
    UserInfoClass ucObj = new UserInfoClass();

    protected DataTable _dataTable;
    public string table, _title;

    public DataTable source
    {
        get
        {
            return _dataTable;
        }
        set
        {
            _dataTable = value;
        }
    }

    public void setAll(DataTable ds, string tb, string tt)
    {
        _dataTable = ds;
        table = tb;
        _title = tt;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dlClassBind();
            lbClassName.Text = _title;
        }
    }
    public string GetClass(int P_Int_ClassID)
    {
        string P_Str_ClassName = mcObj.GetClass(P_Int_ClassID);
        return P_Str_ClassName;
    }
    //绑定市场价格
    public string GetVarMKP(string P_Str_MarketPrice)
    {
        return ucObj.VarStr(P_Str_MarketPrice, 2);
    }
    //绑定会员价格


    /// <summary>
    /// 显示指定类别的商品信息
    /// </summary>
    public void dlClassBind()
    {
        DLClass.DataSource = _dataTable.DefaultView;
        DLClass.DataBind();
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
    protected void DLClass_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "detailSee")
        {
            Session["address"] = "";
            Session["address"] = "ClassGoods.aspx?ClassID=" + Convert.ToInt32(1);
            Response.Redirect("~/User/GoodsDetail.aspx?GoodsID=" + Convert.ToInt32(DLClass.DataKeys[e.Item.ItemIndex].ToString()));
        }
        else if (e.CommandName == "buyGoods")
        {
            AddShopCart(e, DLClass);
        }
    }
}