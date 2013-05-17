using System;
using System.Collections.Generic;
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


public partial class User_Search : System.Web.UI.Page
{
    UserInfoClass ucObj = new UserInfoClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["string"] != null && Request["string"].Trim() != "")
            {
                GoodsControl.setAll(ucObj.SearchBind(Request["string"].Trim()), "result", "搜索结果");
            }
            else
            {
                Response.Write("<script>alert('请输入商品名！');</script>");
            }
        }
    }
}