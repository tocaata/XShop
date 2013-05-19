﻿using System;
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
        DataTable ds = mcObj.ReturnMemberDs();
        gvMemberList.DataSource = ds.DefaultView;
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
        try
        {
            DBClass.ExecuteScalar("SELECT order_id FROM orders WHERE user_id = @user_id AND status < 4 AND status > 0;", new SqlParameter("@user_id", P_Int_MemberID));
            Response.Write("<script>alert('用户还有未完成订单，不能删除用户');</script>");
        }
        catch
        {
            mcObj.DeleteMemberInfo(P_Int_MemberID);
            gvMemberBind();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable ds = mcObj.SearchUser("users", txtKey.Text.Trim(), chkDeleted.Checked);
        gvMemberList.DataSource = ds.DefaultView;
        gvMemberList.DataBind();
    }
}
