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

public partial class UserControl_navigationControl : System.Web.UI.UserControl
{
    UserInfoClass ucObj = new UserInfoClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ucObj.DLClassBind(DLClass);
        }
    }
    protected void DLClass_EditCommand(object source, DataListCommandEventArgs e)
    {
        Response.Redirect("~/User/ClassGoods.aspx?ClassID="+DLClass.DataKeys[e.Item.ItemIndex].ToString());
    }

}
