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

public partial class Manger_MemberAdd : System.Web.UI.Page
{
    MangerClass mc = new MangerClass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
        txtPass.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "")
        {
            Response.Write("<script>alert('请输入管理员名！');location='javascript:history.go(-1)';</script>");
        }
        else
        {
            int P_Int_returnValue = mc.AddAdmin(txtName.Text.Trim(),txtPass.Text.Trim());
            if (P_Int_returnValue==100)
            {
                Response.Write("<script>alert('该管理员名已存在！');location='javascript:history.go(-1)';</script>");
            }
            else
            {
                Response.Write("<script>alert('添加成功！');location='javascript:history.go(-1)';</script>");
            
            }
        
        }
    }
}
