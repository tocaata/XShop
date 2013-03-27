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

public partial class User_AddAdvancePay : System.Web.UI.Page
{
    UserInfoClass uiObj = new UserInfoClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
         GetMIByID();
        } 
    }
    protected void GetMIByID()
    {
        if (Convert.ToString(Session["UID"]) == "")
        {
            Response.Redirect("index.aspx");
        }
        else
        {

            DataSet ds = new DataSet();
            ds = uiObj.ReturnUIDsByID(Convert.ToInt32(Session["UID"].ToString()), "UserInfo");
            txtAdvancePayment.Text = ds.Tables["UserInfo"].Rows[0][12].ToString();
        }
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        uiObj.UpdateAP(Convert.ToInt32(Session["UID"].ToString()), float.Parse (txtAdvancePayment.Text.Trim()));

        Response.Write("<script>alert('恭喜您，充值成功！');location='javascript:history.go(-1)';</script>");
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
}
