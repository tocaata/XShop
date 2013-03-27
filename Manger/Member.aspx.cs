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

public partial class Manger_Member : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvAdminBind();
        }
    }
    public void gvAdminBind()
    {
        DataSet ds = mcObj.ReturnAdminIDs("Admin");
        gvCategoryList.DataSource = ds.Tables["Admin"].DefaultView;
        gvCategoryList.DataBind();  
    }
    protected void gvCategoryList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCategoryList.PageIndex = e.NewPageIndex;
        gvAdminBind();
    }
    protected void gvCategoryList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int P_Int_AdminID = Convert.ToInt32(gvCategoryList.DataKeys[e.RowIndex].Value.ToString());
        mcObj.DeleteAdminInfo(P_Int_AdminID);
        gvAdminBind();
    }
    protected void gvCategoryList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCategoryList.EditIndex = -1;
        gvAdminBind();
    }
    protected void gvCategoryList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCategoryList.EditIndex = e.NewEditIndex;
        gvAdminBind();
    }
    protected void gvCategoryList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int P_Int_AdminID = Convert.ToInt32(gvCategoryList.DataKeys[e.RowIndex].Value.ToString());
        string P_Str_Admin = ((TextBox)(gvCategoryList.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString();
        string P_Str_Password = ((TextBox)(gvCategoryList.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString();
        mcObj.UpdateAdminInfo(P_Int_AdminID, P_Str_Admin, P_Str_Password);
        gvCategoryList.EditIndex = -1;
        gvAdminBind();
    }
}
