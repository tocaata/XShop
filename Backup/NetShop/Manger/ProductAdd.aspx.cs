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

public partial class Manger_ProductAdd : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mcObj.ddlClassBind(ddlCategory);
            mcObj.ddlUrl(ddlUrl);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "" || txtBrand.Text == "" || txtUnit.Text == "" || txtWeight.Text == "" || txtMemberPrice.Text == "" || txtMarketPrice.Text == "")
        {
            Response.Write("<script>alert('请输入必要的信息！')</script>");

        }
        else
        { 
            bool Isrefinement ;
            bool IsHot;
            bool IsDisCount;
            if(cbxCommend.Checked ==true)
            {
              Isrefinement =true ;
            }
            else
            {
              Isrefinement =false ;
            }
            if(cbxHot.Checked==true)
            {
             IsHot=true;
            }
            else 
            {
             IsHot =false ;
            }
            if(cbxDiscount.Checked ==true)
            {
             IsDisCount=true ;
            }
            else
            {
            IsDisCount =false ;
            }
            int P_Int_returnValue = mcObj.AddGInfo(Convert.ToInt32(ddlCategory.SelectedItem.Value.ToString()), txtName.Text.Trim(), txtShortDesc.Text.Trim(), txtBrand.Text.Trim(), txtUnit.Text.Trim(), float.Parse (txtWeight.Text.Trim()), ddlUrl.SelectedItem.Value.Trim(), float.Parse(txtMarketPrice.Text.Trim()), float.Parse(txtMemberPrice.Text.Trim()), Isrefinement, IsHot, IsDisCount);
            if (P_Int_returnValue == -100)
            {
                Response.Write("<script>alert('该商品已存在！');</script>");
            }
            else
            {
                Response.Write("<script>alert('添加成功！');</script>");
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
        txtBrand.Text = "";
        txtUnit.Text = "";
        txtWeight.Text = "";
        txtMarketPrice.Text = "";
        txtMemberPrice.Text = "";
        txtShortDesc.Text = "";

    }

    protected void ddlUrl_SelectedIndexChanged(object sender, EventArgs e)
    {
        ImageMapPhoto.ImageUrl = ddlUrl.SelectedItem.Value;
    }
}
