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
        }
    }
    /// <summary>
    /// 获取指定商品的信息，并将其显示在界面上
    /// </summary>
 
    public bool IsValidInt(string num)
    {

        return Regex.IsMatch(num, @"^[0-9]+(.[0-9]{2})?$");

    }
}
