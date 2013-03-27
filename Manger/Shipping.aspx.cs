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

public partial class Manger_Shipping : System.Web.UI.Page
{
    MangerClass mcObj = new MangerClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.Request.QueryString["Action"] == "Manage")
            {
                lblAction.Text = "配送方式管理";
                gvShipBind();
            }
            else if(this.Request.QueryString["Action"]=="Add" )
            {
               lblAction.Text="添加配送方式信息";
               ddlClass();

            }
            else if (this.Request.QueryString["Action"] == "Modify")
            {
                lblAction.Text = "修改配送方式信息";
                ddlClass();
                GetShipInfo();
            }

           
        }
    }
    public string GetVarStr(string P_Str_ShipFee)
    {
        return mcObj.VarStr(P_Str_ShipFee, 2);
    
    }
    public string GetClass(int P_Int_ClassID)
    {
        string P_Str_ClassName = mcObj.GetClass(P_Int_ClassID);
        return P_Str_ClassName;
    }
    public void gvShipBind()
    {
        DataSet ds = mcObj.ReturnShipDs("ShipInfo");
        gvShip.DataSource = ds.Tables["ShipInfo"].DefaultView;
        gvShip.DataBind();
    
    }
    protected void gvShip_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShip.PageIndex = e.NewPageIndex;
        gvShipBind();
    }
    protected void gvShip_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int P_Int_ShipID = Convert.ToInt32(gvShip.DataKeys[e.RowIndex].Value.ToString());
        mcObj.DeleteShipInfo(P_Int_ShipID);
        gvShipBind();
    }
    public void ddlClass()
    {
        mcObj.ddlClassBind(ddlClassName);
    }
    public void GetShipInfo()
    {
        DataSet ds = mcObj.ReturnShipDsByID(Convert.ToInt32(this.Request["ShipID"].ToString()), "ShipInfo");
        txtName.Text=ds.Tables["ShipInfo"].Rows[0][1].ToString();
        txtPrice.Text =mcObj.VarStr(ds.Tables["ShipInfo"].Rows[0][2].ToString(),2);
        ddlClassName.SelectedItem.Value = ds.Tables["ShipInfo"].Rows[0][3].ToString();
      
    
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (this.Request.QueryString["Action"] == "Add")
        {
            if (txtName.Text == "" || txtPrice.Text == "")
            {
                Response.Write("<script>alert('请输入完整信息')</script>");
                return;
            }
            else
            {
                if (IsValidInt(txtPrice.Text.Trim()) == false)
                {
                    Response.Write("<script>alert('请正确输入（格式：1.00）！')</script>");
                    return;

                }
                else
                {
                    mcObj.InsertShip(txtName.Text.Trim(), float.Parse(txtPrice.Text.Trim()), Convert.ToInt32(ddlClassName.SelectedItem.Value.Trim()));
                  Response.Write("<script>alert('插入成功！')</script>");
                  return;
                }
            
            }

        }
        else if (this.Request.QueryString["Action"] == "Modify")
        { 
         
            if (txtName.Text == "" || txtPrice.Text == "")
            {
                Response.Write("<script>alert('请输入完整信息')</script>");
                return;
            }
            else
            {
                if (IsValidInt(txtPrice.Text.Trim()) == false)
                {
                    Response.Write("<script>alert('请正确输入（格式：1.00）！')</script>");
                    return;

                }
                else
                { 
                  mcObj.UpdateShip(Convert.ToInt32(this.Request["ShipID"].ToString()),txtName.Text.Trim(),float.Parse (txtPrice.Text.Trim()),Convert.ToInt32(ddlClassName.SelectedItem.Value.Trim()));
                  Response.Write("<script>alert('修改成功！')</script>");
                  return;
                }
            
            }
        
        
        }
    }
    public bool IsValidInt(string num)
    {
        return Regex.IsMatch(num, @"^[0-9]+(.[0-9]{2})?$");
    
    }
}
