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

public partial class Manger_OrderModify : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    UserInfoClass uiObj = new UserInfoClass();
    public static CommonProperty order = new CommonProperty();
    protected void Page_Load(object sender, EventArgs e)
    {
        order = GetOrderInfo();
        if (!IsPostBack)
        {
            rpBind();
            IsCPCPBind();
        }
     
    }
    public void IsCPCPBind()
    {
        DataTable ds = mcObj.GetOdIfDS(Convert.ToInt32(Request["OrderID"].Trim()));
        chkConfirm.Checked = Convert.ToBoolean(ds.Rows[0][10].ToString());
        chkPay.Checked = Convert.ToBoolean(ds.Rows[0][11].ToString());
        chkConsignment.Checked = Convert.ToBoolean(ds.Rows[0][12].ToString());
        chkPigeonhole.Checked = Convert.ToBoolean(ds.Rows[0][13].ToString());
    
    }
    public void rpBind()
    {
        DataTable ds=mcObj.GetGIByOID(Convert.ToInt32(Request["OrderID"].Trim()));
        rptOrderItems.DataSource = ds.DefaultView;
        rptOrderItems.DataBind();
    }
    /// <summary>
    /// 获取指定订单信息
    /// </summary>
    /// <returns>返回CommonProperty类的实例对像</returns>
    public CommonProperty GetOrderInfo()
    {
       
        DataTable ds = mcObj.GetOdIfDS(Convert.ToInt32(Request["OrderID"].Trim()));
        DataTable UIDs = uiObj.ReturnUIDsByID(Convert.ToInt32(ds.Rows[0][7].ToString()));
        order.OrderNo = Convert.ToInt32(ds.Rows[0][0].ToString());
        order.OrderTime = Convert.ToDateTime(ds.Rows[0][1].ToString());
        order.ProductPrice = float.Parse (ds.Rows[0][2].ToString());
        order.TotalPrice = float.Parse (ds.Rows[0][3].ToString());
        order.ShipPrice = float.Parse (ds.Rows[0][4].ToString());
        order.ReceiverName=ds.Rows[0][8].ToString();
        order.ReceiverPhone =ds.Rows[0][9].ToString();
        order.ReceiverPostalcode=ds.Rows[0][14].ToString();
        order.ReceiverAddress =ds.Rows[0][15].ToString();
        order.ReceiverEmail =ds.Rows[0][16].ToString();
        order.ShipType = Convert.ToInt32(ds.Rows[0][5].ToString());
        order.PayType = Convert.ToInt32(ds.Rows[0][6].ToString());
        order.BuyerAddress = UIDs.Rows[0][9].ToString();
        order.BuyerEmail = UIDs.Rows[0][8].ToString();
        order.BuyerName = UIDs.Rows[0][1].ToString();
        order.BuyerPhone = UIDs.Rows[0][7].ToString();
        order.BuyerPostalcode = UIDs.Rows[0][11].ToString();
        
        return (order);

    
    }
    public string GetShippingName(int P_Int_ShipType)
    {
        return mcObj.GetShipWay(P_Int_ShipType);

    }
    public string GetPaymentName(int P_Int_PayType)
    {
        return mcObj.GetPayWay(P_Int_PayType);
    }
    public string GetStatus(int P_Int_OrderID)
    {
        DataTable ds = mcObj.GetStatusDS(P_Int_OrderID);
        return (ds.Rows[0][0].ToString() + "|" + ds.Rows[0][1].ToString() + "<Br>" + ds.Rows[0][2].ToString() + "|" + ds.Rows[0][3].ToString());
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool IsConfirm;
        bool IsPayment;
        bool IsConsignment;
        bool IsPigeonhole;
        if (chkConfirm.Checked ==true )
        {
            IsConfirm = true;
        }
        else
        {
            IsConfirm = false;
        }
        if (chkPay.Checked ==true)
        {
            IsPayment = true;
        }
        else
        {
            IsPayment = false;
        }
        if (chkConsignment.Checked==true)
        {
            IsConsignment = true;
        }
        else
        {
            IsConsignment = false;
        }
        if(chkPigeonhole.Checked ==true)
        {
            IsPigeonhole = true;
        }
        else
        {
            IsPigeonhole = false;
        }
        mcObj.UpdateOI(Convert.ToInt32(Request["OrderID"].Trim()), IsConfirm, IsPayment, IsConsignment, IsPigeonhole);
        Response.Write("<script>alert('修改成功！')</script>");
        return;
    }
}
