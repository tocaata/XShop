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

public partial class Manger_Manager : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvMemberBind();
        }
    }
    public void gvMemberBind()
    {
        DataSet ds = mcObj.ReturnMemberDs("Member");
        gvMemberList.DataSource = ds.Tables["Member"].DefaultView;
        gvMemberList.DataBind();
    
    }
    protected void gvMemberList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMemberList.PageIndex = e.NewPageIndex;
        gvMemberBind();
    }
    protected void gvMemberList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int P_Int_MemberID = Convert.ToInt32(gvMemberList.DataKeys[e.RowIndex].Value.ToString());
        mcObj.DeleteMemberInfo(P_Int_MemberID);
        gvMemberBind();
    }

}
