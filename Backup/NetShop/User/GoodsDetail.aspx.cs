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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetGoodsInfo();
        }
    }
    public string GetClass(int P_Int_ClassID)
    {
        string P_Str_ClassName = mcObj.GetClass(P_Int_ClassID);
        return P_Str_ClassName;
    }
    public void GetGoodsInfo()
    {
        DataSet ds = mcObj.GetGoodsInfoByIDDs(Convert.ToInt32(Request["GoodsID"].Trim()), "GoodsInfo");
        txtName.Text = ds.Tables["GoodsInfo"].Rows[0][2].ToString();
        txtFName.Text = GetClass(Convert.ToInt32(ds.Tables["GoodsInfo"].Rows[0][1].ToString()));
        txtBrand.Text = ds.Tables["GoodsInfo"].Rows[0][4].ToString();
        txtUnit.Text = ds.Tables["GoodsInfo"].Rows[0][5].ToString();
        txtWeight.Text = mcObj.VarStr(ds.Tables["GoodsInfo"].Rows[0][6].ToString(),2);
        txtMarketPrice.Text =mcObj.VarStr(ds.Tables["GoodsInfo"].Rows[0][8].ToString(),2);
        txtMemberPrice.Text =mcObj.VarStr(ds.Tables["GoodsInfo"].Rows[0][9].ToString(),2);
        ImageMapPhoto.ImageUrl = ds.Tables["GoodsInfo"].Rows[0][7].ToString();
        cbxCommend.Checked = Convert.ToBoolean(ds.Tables["GoodsInfo"].Rows[0][10].ToString());
        cbxHot.Checked = Convert.ToBoolean(ds.Tables["GoodsInfo"].Rows[0][11].ToString());
        cbxDiscount.Checked = Convert.ToBoolean(ds.Tables["GoodsInfo"].Rows[0][13].ToString());
        txtShortDesc.Text = ds.Tables["GoodsInfo"].Rows[0][3].ToString();
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
}
