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

public partial class LoadingControl : System.Web.UI.UserControl
{
    DBClass dbObj = new DBClass();
    UserInfoClass uiObj = new UserInfoClass(); 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbValid.Text = new randomCode().RandomNum(4);//产生验证码
             if (Session["UID"] != null)
            {

                tabLoad.Visible = true;
                 tabLoading.Visible =false ;
            }        
        }
       
    }

    protected void btnLoad_Click(object sender, EventArgs e)
    {
        Session["UID"] = null ;
        Session["Username"] = null ;
        if (txtName.Text.Trim() == "" || txtPassword.Text.Trim () == "")
        {


            Response.Write("<script>alert('登录名和密码不能为空！');location='javascript:history.go(-1)';</script>");
        }
        else
        {
            if (txtValid.Text.Trim() == lbValid.Text.Trim())
            {

                bool P_Int_IsExists = uiObj.UserExists(txtName.Text.Trim(), txtPassword.Text.Trim());
                if (P_Int_IsExists)
                {
                    DataSet ds = uiObj.ReturnUIDs(txtName.Text.Trim(), txtPassword.Text.Trim(), "users");

                    Session["UID"] = Convert.ToInt32(ds.Tables["users"].Rows[0][0].ToString());
                    Session["Username"] = ds.Tables["users"].Rows[0][1].ToString();
                    Response.Redirect("index.aspx");
                  
                }
                else
                {
                    //Page.RegisterStartupScript("0", "<script>alert('您的登录有误，请核对后再重新登录！');location='javascript:history.go(-1)';</script>");
                    Response.Write("<script>alert('您的登录有误，请核对后再重新登录！');location='javascript:history.go(-1)';</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('请正确输入验证码！');location='javascript:history.go(-1)';</script>");            
            }
           
        
        
        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
    protected void lnkbtnResetInfo_Click(object sender, EventArgs e)
    {
        Response.Write("<script language=javascript>window.open('ResetMemberInfo.aspx','','width=655,height=655')</script>");
    }
 
}
