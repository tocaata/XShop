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

public partial class Register : System.Web.UI.Page
{
    UserInfoClass uiObj = new UserInfoClass();
    public static int G_Int_MemberID;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtPostCode.Text.Trim() == "" && txtPassword.Text.Trim()=="")
        {
            Response.Write("<script>alert('请输入完整信息！');location='javascript:history.go(-1)';</script>");
        }
        else
        { 
            bool P_Bl_Sex;
            if(Convert.ToInt32(ddlSex.SelectedItem.Value.Trim())==1)
            {
                P_Bl_Sex =true ;
            
            }
            else 
            {
              P_Bl_Sex =false ;
            
            }
            G_Int_MemberID = uiObj.AddUInfo(txtName.Text.Trim(), P_Bl_Sex, txtPassword.Text.Trim(), txtTrueName.Text.Trim(), "", "", txtPhone.Text.Trim(), txtEmail.Text.Trim(), ddlCity.SelectedItem.Text.Trim(), txtAddress.Text.Trim(), txtPostCode.Text.Trim());

            Session["Username"] = "";
            Session["Username"] =txtName.Text.Trim();
            Response.Write("<script>alert('恭喜您，注册成功！');location='index.aspx'</script>");
        }
    }
}
