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
using System.Text.RegularExpressions;

public partial class Manger_EditProduct : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mcObj.ddlClassBind(ddlCategory);
            mcObj.ddlUrl(ddlUrl);
            GetGoodsInfo();
        }
    }
    /// <summary>
    /// 获取指定商品的信息，并将其显示在界面上
    /// </summary>
    public void GetGoodsInfo()
    {
        DataSet ds = mcObj.GetGoodsInfoByIDDs(Convert.ToInt32(Request["GoodsID"].Trim()),"GoodsInfo");
        txtName.Text=ds.Tables["GoodsInfo"].Rows[0][2].ToString();
        ddlCategory.SelectedValue = ds.Tables["GoodsInfo"].Rows[0][1].ToString();
        txtBrand.Text = ds.Tables["GoodsInfo"].Rows[0][4].ToString();
        txtUnit.Text = ds.Tables["GoodsInfo"].Rows[0][5].ToString();
        txtWeight.Text =mcObj.VarStr( ds.Tables["GoodsInfo"].Rows[0][6].ToString(),2);
        txtMarketPrice.Text = mcObj.VarStr(ds.Tables["GoodsInfo"].Rows[0][8].ToString(),2);
        txtMemberPrice.Text = mcObj.VarStr(ds.Tables["GoodsInfo"].Rows[0][9].ToString(),2);
        ddlUrl.SelectedValue = ds.Tables["GoodsInfo"].Rows[0][7].ToString();
        ImageMapPhoto.ImageUrl = ddlUrl.SelectedItem.Value;
        cbxCommend.Checked = Convert.ToBoolean(ds.Tables["GoodsInfo"].Rows[0][10].ToString());
        cbxHot.Checked = Convert.ToBoolean(ds.Tables["GoodsInfo"].Rows[0][11].ToString());
        cbxDiscount.Checked = Convert.ToBoolean(ds.Tables["GoodsInfo"].Rows[0][13].ToString());
        txtShortDesc.Text = ds.Tables["GoodsInfo"].Rows[0][3].ToString();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "" || txtBrand.Text == "" || txtUnit.Text == "" || txtWeight.Text == "" || txtMemberPrice.Text == "" || txtMarketPrice.Text == "")
        {
            Response.Write("<script>alert('请输入必要的信息！')</script>");

        }
        else if (IsValidInt(txtWeight.Text.Trim()) == false || IsValidInt(txtMarketPrice.Text.Trim()) == false || IsValidInt(txtMemberPrice.Text.Trim()) == false)
        {
            Response.Write("<script>alert('请正确输入（格式：1.00）！')</script>");
        }
        else
        {
            bool Isrefinement;
            bool IsHot;
            bool IsDisCount;
            if (cbxCommend.Checked == true)
            {
                Isrefinement = true;
            }
            else
            {
                Isrefinement = false;
            }
            if (cbxHot.Checked == true)
            {
                IsHot = true;
            }
            else
            {
                IsHot = false;
            }
            if (cbxDiscount.Checked == true)
            {
                IsDisCount = true;
            }
            else
            {
                IsDisCount = false;
            }
            mcObj.UpdateGInfo(Convert.ToInt32(ddlCategory.SelectedItem.Value.ToString()), txtName.Text.Trim(), txtShortDesc.Text.Trim(), txtBrand.Text.Trim(), txtUnit.Text.Trim(), float.Parse(txtWeight.Text.Trim()), ddlUrl.SelectedItem.Value.Trim(), float.Parse(txtMarketPrice.Text.Trim()), float.Parse(txtMemberPrice.Text.Trim()), Isrefinement, IsHot, IsDisCount, Convert.ToInt32(Request["GoodsID"].Trim()));
            Response.Write("<script>alert('该商品修改成功！');</script>");
           
        }
    }
    public bool IsValidInt(string num)
    {

        return Regex.IsMatch(num, @"^[0-9]+(.[0-9]{2})?$");

    }
    protected void ddlUrl_SelectedIndexChanged(object sender, EventArgs e)
    {
        ImageMapPhoto.ImageUrl = ddlUrl.SelectedItem.Value;
    }
}
