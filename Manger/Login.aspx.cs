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

public partial class AdminManage_Login : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    UserInfoClass uiObj = new UserInfoClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            labCode.Text = new randomCode().RandomNum(4);//产生验证码
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtAdminName.Text.Trim() == "" || txtAdminPwd.Text.Trim() == "")
        {
            Response.Write("<script>alert('登录名和密码不能为空！');location='javascript:history.go(-1)';</script>");
        }
        else
        {
            if (txtAdminCode.Text.Trim() == labCode.Text.Trim())
            {
                try
                {
                   DataSet ds = mcObj.ReturnAIDs(txtAdminName.Text.Trim(), txtAdminPwd.Text.Trim(), "AInfo");
                   Session["AID"] = Convert.ToInt32(ds.Tables["AInfo"].Rows[0][0].ToString());
                   Session["Aname"] = ds.Tables["AInfo"].Rows[0][1].ToString();
                   //Response.Write("<script>alert('登陆成功');location='javascript:history.go(-1)';</script>");
                   Response.Write("<script language=javascript>window.open('AdminIndex.aspx');window.close();</script>");
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('您输入的用户名或密码错误，请重新输入！');location='javascript:history.go(-1)';</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('验证码输入有误，请重新输入！');location='javascript:history.go(-1)';</script>");
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();location='javascript:history.go(-1)';</script>");
    }
}
