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

public partial class User_ShipFeeInfo : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvShipBind();
        }
    }
    public string GetVarStr(string P_Str_ShipFee)
    {
        return mcObj.VarStr(P_Str_ShipFee, 2);

    }
    public string GetClass(int P_Int_ClassID)
    {
        string P_Str_ClassName = mcObj.GetClass(P_Int_ClassID);
        return P_Str_ClassName;
    }
    public void gvShipBind()
    {
        DataSet ds = mcObj.ReturnShipDs("ShipInfo");
        gvShip.DataSource = ds.Tables["ShipInfo"].DefaultView;
        gvShip.DataBind();

    }
    protected void gvShip_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShip.PageIndex = e.NewPageIndex;
        gvShipBind();
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();location='javascript:history.go(-1)';</script>");
    }
}
