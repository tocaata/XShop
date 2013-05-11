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

public partial class Manger_CategoryAdd : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //mcObj.ddlUrl(ddlUrl);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "")
        {
            Response.Write("<script>alert('请输入商品类别！');location='javascript:history.go(-1)';</script>");
        }
        else
        {
            try
            {
                mcObj.AddCategory(txtName.Text.Trim(), ImageUrl.Text.Trim()); //ddlUrl.SelectedItem.Value.ToString());
                Response.Write("<script>alert('添加成功！');location='javascript:history.go(-1)';</script>");
            }
            catch (Exception err)
            {
                Response.Write("<script>alert('" + err.Message + "');location='javascript:history.go(-1)';</script>");
            }
        }

    }
    protected void ddlUrl_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ImageMapPhoto.ImageUrl = ddlUrl.SelectedItem.Value;
    }

    protected void UploadImage_OnClick(object sender, EventArgs e)
    {
        try
        {
            lbIamge.Visible = true;
            if (imageUpload.PostedFile.FileName == "")
            {
                lbIamge.Text = "要上传的文件不允许为空！";
                return;
            }
            else
            {
                string filePath = imageUpload.PostedFile.FileName;
                string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                string serverpath = Server.MapPath(@"~\Images\ftp\") + filename;
                string relativepath = @"~\Images\ftp\" + filename;
                imageUpload.PostedFile.SaveAs(serverpath);
                lbIamge.Text = "上传成功！";
                ImageUrl.Text = relativepath;
            }

        }
        catch (Exception error)
        {
            lbIamge.Text = "处理发生错误！原因：" + error.ToString();
        }
    }
}
