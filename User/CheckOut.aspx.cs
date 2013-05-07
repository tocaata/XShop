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
    
    public float  TotalGoodsPrice()
    {
        DataSet ds = ucObj.ReturnTotalDs(Convert.ToInt32(Session["UID"].ToString()), "TotalInfo");
       float  P_Flt_TotalGP = float.Parse(ds.Tables["TotalInfo"].Rows[0][0].ToString());
       return P_Flt_TotalGP;
    }

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
            float P_Flt_TotalGP = TotalGoodsPrice();
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
}
