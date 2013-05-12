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

public partial class Manger_OrderList : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    UserInfoClass uiObj = new UserInfoClass();
    public static int P_Int_IsSearch = 0;
    public static int P_Int_List = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pageBind();
        }
    }
    //绑定货品总额
    public string GetVarGF(string P_Str_GoodsFee)
    {
        return mcObj.VarStr(P_Str_GoodsFee, 2);
    }
    //绑定运费
    public string GetVarSF(string P_Str_ShipFee)
    {
        return mcObj.VarStr(P_Str_ShipFee, 2);
    }
    //绑定总金额
    public string GetVarTP(string P_Str_TotalPrice)
    {
        return mcObj.VarStr(P_Str_TotalPrice, 2);
    }
    /// <summary>
    /// 获取指定订单的信息
    /// </summary>
    public void pageBind()
    {
        DataTable ds = mcObj.OrderByStatus(false, 1);
        gvOrderList.DataSource = ds.DefaultView;
        gvOrderList.DataBind();
    }

    /// <summary>
    /// 获取符合条件的订单信息
    /// </summary>
    public void gvSearchBind()
    {
        DataTable ds = mcObj.OrderByStatus(Int32.Parse(ddlShipped.SelectedValue), Int32.Parse(ddlConfirmed.SelectedValue), Int32.Parse(ddlReturn.SelectedValue),
            Int32.Parse(ddlSpeed.SelectedValue), Int32.Parse(ddlReceive.SelectedValue));
        gvOrderList.DataSource = ds.DefaultView;
        gvOrderList.DataBind();
    }

    protected void gvOrderList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOrderList.PageIndex = e.NewPageIndex;
        //if (P_Int_IsSearch == 1)
        //{
        //    gvSearchBind();
        //}
        //else
        //{
        pageBind();

        //}

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        P_Int_IsSearch = 1;
        gvSearchBind();
    }
    protected void gvOrderList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int P_Int_id = Convert.ToInt32(gvOrderList.DataKeys[e.RowIndex].Value);
        mcObj.DeleteOrderInfo(P_Int_id);
        if (P_Int_IsSearch == 1)
        {
            gvSearchBind();
        }
        else
        {
            pageBind();

        }

    }
    public string GetShipName(int P_Int_ShipType)
    {
        return mcObj.GetShipWay(P_Int_ShipType);

    }
    public string GetPayName(int P_Int_PayType)
    {
        return mcObj.GetPayWay(P_Int_PayType);
    }
    public string GetMemberName(int P_Int_MemberId)
    {
        DataTable ds = new DataTable();
        ds = uiObj.ReturnUIDsByID(P_Int_MemberId);
        return (ds.Rows[0][1].ToString());

    }
    public string GetStatus(int P_Int_OrderID)
    {
        DataTable ds = mcObj.GetStatusDS(P_Int_OrderID);
        return (ds.Rows[0][0].ToString() + "|" + ds.Rows[0][1].ToString() + "<Br>" + ds.Rows[0][2].ToString() + "|" + ds.Rows[0][3].ToString());
    }


}
