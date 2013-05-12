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

public partial class Manger_Payment : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.Request.QueryString["Action"] == "Manage")
            {
                lblAction.Text = "支付方式管理";
                gvPayBind();
            }
            else if (this.Request.QueryString["Action"] == "Add")
            {
                lblAction.Text = "添加支付方式信息";
               

            }
            else if (this.Request.QueryString["Action"] == "Modify")
            {
                lblAction.Text = "修改支付方式信息";
                GetPayInfo();
            }

           
        }

    }
    public void gvPayBind()
    {
        DataTable ds = mcObj.ReturnPayDs("PayInfo");
        gvPay.DataSource = ds.DefaultView;
        gvPay.DataBind();
    
    }
    protected void gvPay_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPay.PageIndex = e.NewPageIndex;
        gvPayBind();
    }
    protected void gvPay_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int P_Int_PayID = Convert.ToInt32(gvPay.DataKeys[e.RowIndex].Value.ToString());
        mcObj.DeletePayInfo(P_Int_PayID);
        gvPayBind();

    }
    public void GetPayInfo()
    {
        DataTable ds = mcObj.ReturnPayDsByID(Convert.ToInt32(this.Request["PayID"].ToString()));
        txtName.Text = ds.Rows[0][1].ToString();
    
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.Request.QueryString["Action"] == "Add")
        {
            if (txtName.Text == "")
            {
                Response.Write("<script>alert('请输入完整信息')</script>");
                return;
            }
            else
            {

                mcObj.InsertPay(txtName.Text.Trim());
                Response.Write("<script>alert('添加成功！')</script>");
                return;
            

            }

        }
        else if (this.Request.QueryString["Action"] == "Modify")
        {

            if (txtName.Text == "")
            {
                Response.Write("<script>alert('请输入完整信息')</script>");
                return;
            }
            else
            {
                mcObj.UpdatePay(Convert.ToInt32(this.Request["PayID"].ToString()), txtName.Text.Trim());
                Response.Write("<script>alert('修改成功！')</script>");
                return;

            }


        }
    }
}
