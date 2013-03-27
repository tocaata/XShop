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
    public static int P_Int_IsSearch=0;
    public static int P_Int_List=0;
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

        return mcObj.VarStr(P_Str_GoodsFee,2);
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
        if (this.Request.QueryString["OrderList"].ToString() != String.Empty.Trim())
        {
            if (this.Request.QueryString["OrderList"].ToString() == "00" || this.Request.QueryString["OrderList"].ToString() == "01")
            {
                if (this.Request.QueryString["OrderList"].ToString() == "00")
                {
                    P_Int_List = 0;
                }
                else
                {
                    P_Int_List = 1;
                }
                gvConfirmBind(1);
            }
            else if (this.Request.QueryString["OrderList"].ToString() == "10" || this.Request.QueryString["OrderList"].ToString() == "11")
            {
               
                if (this.Request.QueryString["OrderList"].ToString() == "10")
                {
                    P_Int_List = 0;
                }
                else
                {
                    P_Int_List = 1;
                }
                gvPayedBind(2);
            }
            else if (this.Request.QueryString["OrderList"].ToString() == "20" || this.Request.QueryString["OrderList"].ToString() == "21")
            {
              
                if (this.Request.QueryString["OrderList"].ToString() == "20")
                {
                    P_Int_List = 0;
                }
                else
                {
                    P_Int_List = 1;
                }
                gvShippedBind(3);
            }
            else if (this.Request.QueryString["OrderList"].ToString() == "30" || this.Request.QueryString["OrderList"].ToString() == "31")
            {
              
                if (this.Request.QueryString["OrderList"].ToString() == "30")
                {
                    P_Int_List = 0;
                }
                else
                {
                    P_Int_List = 1;
                }
                gvFinishedBind(4);
            }

        }
    
    }
    /// <summary>
    /// 获取符合条件的订单信息
    /// </summary>
    /// <param name="P_Int_Flag">搜索信息的标志(1代表是否确认2代表是否付款3代表是否发货4代表是否已归档)</param>
    public void gvConfirmBind(int P_Int_Flag)
    {

        SqlCommand myCmd = mcObj.GetOrderInfo(P_Int_Flag, 0, 0, 0, 0, 0, 0, 0, P_Int_List, 0, 0, 0);
       mcObj.gvBind(gvOrderList, myCmd, "OrderInfo");
    }
    public void gvPayedBind(int P_Int_Flag)
    {
        SqlCommand myCmd = mcObj.GetOrderInfo(P_Int_Flag, 0, 0, 0, 0, 0, 0, 0, 0, P_Int_List, 0, 0);
        mcObj.gvBind(gvOrderList, myCmd, "OrderInfo");
    }
    public void gvShippedBind(int P_Int_Flag)
    {
        SqlCommand myCmd = mcObj.GetOrderInfo(P_Int_Flag, 0, 0, 0, 0, 0, 0, 0, 0, 0, P_Int_List, 0);
        mcObj.gvBind(gvOrderList, myCmd, "OrderInfo");
    }
    public void gvFinishedBind(int P_Int_Flag)
    {
        SqlCommand myCmd = mcObj.GetOrderInfo(P_Int_Flag, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, P_Int_List);
        mcObj.gvBind(gvOrderList, myCmd, "OrderInfo");
    }
    /// <summary>
    /// 获取符合条件的订单信息
    /// </summary>
    public void gvSearchBind()
    {
        int P_Int_Confirmed;
        int P_Int_Payed;
        int P_Int_Shipped;
        int P_Int_Finished;
        if(ddlConfirmed.SelectedIndex ==1)
          {
             P_Int_Confirmed =1;
          }
        else
          {
             P_Int_Confirmed =0;
          }
       if(ddlPayed.SelectedIndex ==1)
          {
              P_Int_Payed =1;
          }
       else
          {
              P_Int_Payed =0;
          }
       if(ddlShipped.SelectedIndex ==1)
          {
              P_Int_Shipped =1;
          }
       else
          {
              P_Int_Shipped =0;
          }
       if(ddlFinished.SelectedIndex ==1)
          {
              P_Int_Finished =1;
          }
       else 
          {
             P_Int_Finished =0;
          }
              if (ddlKeyType.SelectedIndex == 0)
                {
                    SqlCommand myCmd = mcObj.GetOrderInfo(0, 0, 0, Convert.ToInt32(txtKeyword.Text.Trim()), ddlConfirmed.SelectedIndex, ddlPayed.SelectedIndex, ddlShipped.SelectedIndex, ddlFinished.SelectedIndex, P_Int_Confirmed, P_Int_Payed, P_Int_Shipped, P_Int_Finished);
                    mcObj.gvBind(gvOrderList, myCmd, "OrderInfo");
                }
              else
                {
                    SqlCommand myCmd = mcObj.GetOrderInfo(0, 1, Convert.ToInt32(txtKeyword.Text.Trim()), 0, ddlConfirmed.SelectedIndex, ddlPayed.SelectedIndex, ddlShipped.SelectedIndex, ddlFinished.SelectedIndex, P_Int_Confirmed, P_Int_Payed, P_Int_Shipped, P_Int_Finished);
                    mcObj.gvBind(gvOrderList, myCmd, "OrderInfo");
                }
     
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
        if (txtKeyword.Text == "")
        {
            Response.Write("<script>alert('查询时关键字不能为空！')</script>");
        }
        else
        {
         P_Int_IsSearch = 1;
         gvSearchBind();
        }
       
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
        DataSet ds = new DataSet();
        ds = uiObj.ReturnUIDsByID(P_Int_MemberId, "UserInfo");
        return (ds.Tables["UserInfo"].Rows[0][1].ToString());  
    
    }
    public string GetStatus(int P_Int_OrderID)
    {
        DataSet ds = mcObj.GetStatusDS(P_Int_OrderID,"OrderInfo");
        return (ds.Tables["OrderInfo"].Rows[0][0].ToString() + "|" + ds.Tables["OrderInfo"].Rows[0][1].ToString() + "<Br>" + ds.Tables["OrderInfo"].Rows[0][2].ToString() + "|" + ds.Tables["OrderInfo"].Rows[0][3].ToString());
    }
   

}
