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

public partial class User_CheckOut : System.Web.UI.Page
{
    UserInfoClass ucObj = new UserInfoClass();
    public  static float  P_Flt_TotalSF;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ddlCityBind();
            //ddlShipBind();
            //ddlPayBind();
            //labKM.Text = ddlShipCity.SelectedValue.ToString();
        
        }
    }
    //public void ddlCityBind()
    //{
    //    ucObj.ddlCityBind(ddlShipCity);
    //}
    //public void ddlShipBind()
    //{
    //    ucObj.ddlShipBind(ddlShipType);
    //}
    //public void ddlPayBind()
    //{
    //    ucObj.ddlPayBind(ddlPayType);
    //}
    public float  TotalGoodsPrice()
    {
        DataSet ds = ucObj.ReturnTotalDs(Convert.ToInt32(Session["UID"].ToString()), "TotalInfo");
       float  P_Flt_TotalGP = float.Parse(ds.Tables["TotalInfo"].Rows[0][0].ToString());
       return P_Flt_TotalGP;
    }
  /// <summary>
  ///  所有商品运输费用
  /// </summary>
    /// <returns>返回商品运输费用</returns>
    //public float  TotalShipFee()
    //{
    //    P_Flt_TotalSF = 0;
    //    DataSet ds = ucObj.ReturnSCDs(Convert.ToInt32(Session["UID"].ToString()), "SCInfo");

    //    for (int i = 0; i < ds.Tables["SCInfo"].Rows.Count; i++)
    //    {
    //        //if (ucObj.GetSFValue(Convert.ToInt32(ds.Tables["SCInfo"].Rows[i][1].ToString()), ddlShipType.SelectedItem.Text.ToString()) ==100)
    //        //{

    //        //    Response.Write("<script>alert('添加失败，由于购买的商品运输费还没有添加，请重新购买！');location='index.aspx';</script>");
    //        //    return 100;
    //        //}
    //        float  P_Flt_SF = ucObj.GetSFValue(Convert.ToInt32(ds.Tables["SCInfo"].Rows[i][1].ToString()), ddlShipType.SelectedItem.Text.ToString());

    //        P_Flt_TotalSF =P_Flt_TotalSF +(float.Parse (ds.Tables["SCInfo"].Rows[i][5].ToString())) * P_Flt_SF*(Convert.ToInt32(ddlShipCity.SelectedItem.Value.ToString()));  
    //    }
    //    return P_Flt_TotalSF;
    
    
    //}
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtReciverName.Text == "" || txtReceiverAddress.Text == "" || txtReceiverPhone.Text == "" || txtReceiverEmails.Text == "")
        {
            Response.Write("<script>alert('请输入完整的信息 ！')</script>");
            return;
        }
        else
        {
            int UserID = Convert.ToInt32(Session["UID"].ToString());
            float P_Flt_TotalSF = 0;//TotalShipFee();
            //if (P_Flt_TotalSF <= 0 || P_Flt_TotalSF == 100)
            //{
            //    return;
            //}
            float P_Flt_TotalGP = TotalGoodsPrice();
            //int P_Int_Cart = ucObj.IsUserCart(UserID, P_Flt_TotalGP, P_Flt_TotalSF);
            //if (P_Int_Cart == -100 && ddlPayType.SelectedItem.Text.Trim() == "会员卡")
            //{
            //    Response.Write("<script>alert('您的会员卡中余额不足，不能购买商品，请充值！')</script>");
            //    return;
            //}
            //else
            //{
                //int P_Int_OrderID = ucObj.AddOrderInfo(UserID, P_Flt_TotalGP, P_Flt_TotalSF, Convert.ToInt32(ddlShipType.SelectedItem.Value.ToString()), Convert.ToInt32(ddlPayType.SelectedItem.Value.ToString()), UserID, txtReciverName.Text.Trim(), txtReceiverPhone.Text.Trim(), txtReceiverPostCode.Text.Trim(), txtReceiverAddress.Text.Trim(), txtReceiverEmails.Text.Trim());
                //int P_Int_OrderID = ucObj.AddOrderInfo(UserID, P_Flt_TotalGP, P_Flt_TotalSF, 0, 0, UserID, txtReciverName.Text.Trim(), txtReceiverPhone.Text.Trim(), "", txtReceiverAddress.Text.Trim(), txtReceiverEmails.Text.Trim());
                //DataSet ds = ucObj.ReturnSCDs(UserID, "SCInfo");
                //for (int i = 0; i < ds.Tables["SCInfo"].Rows.Count; i++)
                //{
                //    ucObj.AddBuyInfo(Convert.ToInt32(ds.Tables["SCInfo"].Rows[i][1].ToString()), Convert.ToInt32(ds.Tables["SCInfo"].Rows[i][2].ToString()), P_Int_OrderID, float.Parse(ds.Tables["SCInfo"].Rows[i][3].ToString()), Convert.ToInt32(ds.Tables["SCInfo"].Rows[i][4].ToString()));
                //}
                //ucObj.DeleteSCInfo(UserID);
            //    Response.Write("<script>alert('购物成功 ！');location='index.aspx'</script>");
            //    return;
            //}
            int P_Int_OrderID = ucObj.AddOrderInfo(UserID, P_Flt_TotalGP, P_Flt_TotalSF, 0, 0, UserID, txtReciverName.Text.Trim(), txtReceiverPhone.Text.Trim(), "", txtReceiverAddress.Text.Trim(), txtReceiverEmails.Text.Trim());
            Response.Write("<script>alert('购物成功 ！');location='index.aspx'</script>");
            return;
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
    protected void lnkbtnSee_Click(object sender, EventArgs e)
    {

        Response.Write("<script language=javascript>window.open('ShipFeeInfo.aspx','','width=640,height=640')</script>");
    }
    //protected void ddlShipCity_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    labKM.Text = ddlShipCity.SelectedItem.Value;
    //}
}
