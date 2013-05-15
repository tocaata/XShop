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

public partial class index : System.Web.UI.Page
{
    UserInfoClass ucObj = new UserInfoClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Request["login"] != null && Request["login"] == "false")
            {
                Response.Write("<script>alert('请先登录，谢谢合作！');</script>");
            }

            GoodsControl.setAll(DBClass.GetDataTable("SELECT TOP 9 * FROM items WHERE deleted IS NULL OR deleted = 0"), "All", "展示商品");
        }
    }
    //绑定市场价格
    public string GetMKPStr(string P_Str_MarketPrice)
    {
        return ucObj.VarStr(P_Str_MarketPrice, 2);
    }
    //绑定会员价格
    public string GetMBPStr(string P_Str_MemberPrice)
    {
       return  ucObj.VarStr(P_Str_MemberPrice, 2); 
    }
}
