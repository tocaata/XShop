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

public partial class Manger_Main : System.Web.UI.Page
{
    UserInfoClass uiObj = new UserInfoClass();
    MangerClass mcObj = new MangerClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvNewOBind();
            gvNewMBind();
        
        }
    }
    public string GetMemberName(int P_Int_MemberId)
    {   
        DataSet ds = new DataSet();
        ds = uiObj.ReturnUIDsByID(P_Int_MemberId, "UserInfo");
        return  (ds.Tables["UserInfo"].Rows[0][1].ToString());  
    }
    public void gvNewOBind()
    {
        if (mcObj.IsExistsNI("orders"))
        {
            DataSet ds = mcObj.GetNewOrder("OrderInfo");
            gvOrderList.DataSource = ds.Tables["OrderInfo"].DefaultView;
            gvOrderList.DataBind();
        }
    }
    public void gvNewMBind()
    {
        if (mcObj.IsExistsNI("users"))
        {
            DataSet ds = mcObj.GetNewUser("MemberInfo");
            gvMember.DataSource = ds.Tables["MemberInfo"].DefaultView;
            gvMember.DataBind();
        }
    }

    protected void gvOrderList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOrderList.PageIndex = e.NewPageIndex;
        gvNewOBind();
    }
    protected void gvMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMember.PageIndex = e.NewPageIndex;
        gvNewMBind();
    }
}
