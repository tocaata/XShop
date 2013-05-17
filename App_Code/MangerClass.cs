using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// MangerClass 的摘要说明
/// </summary>
public class MangerClass
{
    DBClass dbObj = new DBClass();
    public MangerClass()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    //*************************************************************************************************
    /// <summary>
    /// GridView控件的绑定
    /// </summary>
    /// <param name="gvName">控件名字</param>
    /// <param name="P_Str_srcTable">绑定信息</param>
    public void gvBind(GridView gvName, SqlCommand myCmd)
    {
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataTable ds = new DataTable();
        da.Fill(ds);
        gvName.DataSource = ds.DefaultView;
        gvName.DataBind();
    }
    /// <summary>
    /// 判断有没有最新的订单或新会员
    /// </summary>
    /// <param name="P_Str_ProcName">执行语句的存储过程名</param>
    /// <returns></returns>
    public bool IsExistsNI(string TableName)
    {
        try
        {
            dbObj.GetInt32("SELECT " + TableName.Substring(0, TableName.Length - 1) + "_id FROM " + TableName + " WHERE DATEDIFF(day, create_at, getdate()) < 1");
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    // 得到一天以内的所有订单
    public DataTable GetNewOrder()
    {
        DataTable ds = DBClass.GetDataTable("SELECT * FROM orders LEFT JOIN carts ON carts.order_id = orders.order_id WHERE DATEDIFF(day, orders.create_at, getdate()) < 1 AND carts.cart_id IS NULL");
        return ds;
    }

    // 得到一天以内新建的用户
    public DataTable GetNewUser()
    {
        DataTable ds = DBClass.GetDataTable("SELECT * FROM users WHERE DATEDIFF(day, create_at, getdate()) < 1");
        return ds;
    }
    /// <summary>
    /// 绑定最新信息(最新订单信息，最新用户信息量)
    /// </summary>
    /// <param name="P_Str_ProcName">执行语句的存储过程名</param>
    /// <returns></returns>
    public SqlCommand GetNewICmd(string P_Str_ProcName)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand(P_Str_ProcName, myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter returnValue = myCmd.Parameters.Add("returnValue", SqlDbType.Int, 4);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        try
        {
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            myCmd.Dispose();
            myConn.Close();

        }

        return myCmd;
    }
    //*************************************************************************************************
    /// <summary>
    ///  获取订单信息
    /// </summary>
    /// <param name="P_Int_Flag">是否是功能菜单栏传来的值</param>
    /// <param name="P_Int_IsMember">是否是以员工来查询</param>
    /// <param name="P_Int_MemberID">员工编号</param>
    /// <param name="P_Int_OrderID">订单编号</param>
    /// <param name="P_Int_Confirm">是否选择了确认下拉菜单</param>
    /// <param name="P_Int_Payed">是否选择了确认下拉菜单</param>
    /// <param name="P_Int_Shipped">是否选择了付款下拉菜单</param>
    /// <param name="P_Int_Finished">是否选择了归档下拉菜单</param>
    /// <param name="P_Int_IsConfirm">订单是否已确认</param>
    /// <param name="P_Int_IsPayment">订单是否已付款</param>
    /// <param name="P_Int_IsConsignment">订单是否已发贷</param>
    /// <param name="P_Int_IsPigeonhole">订单是否已归档</param>
    /// <returns>返回Sqlcommand</returns>
    /// 

    public DataTable OrderByStatus(int OrderStr, int UserStr, int IsShipped, int IsConfirm, int IsReturn, int IsSpeed, int IsReceive)
    {
        string[] str = { "1=1", "1=1", "1=1", "1=1", "1=1" };
        int[] stat = { IsShipped, IsConfirm, IsReturn, IsReceive }, value = {3, 2, 5, 4};
        string search = "";
        if (OrderStr != 0)
        {
            search = " AND orders.order_id = " + OrderStr.ToString();
        }

        if (UserStr != 0)
        {
            search += " AND orders.user_id = " + UserStr.ToString();
        }

        for (int i = 0; i < 4; i++)
        {
            switch (stat[i])
            {
                case 0:
                    str[i] = "orders.status < " + value[i];
                    break;
                case 1:
                    str[i] = "orders.status >= " + value[i];
                    break;
                default:
                    str[i] = "1=1";
                    break;
            }
        }

        switch (IsSpeed)
        {
            case 0:
                str[3] = "orders.is_speed <> 1";
                break;
            case 1:
                str[3] = "orders.is_speed = 0";
                break;
        }


        String condition = String.Join(" AND ", str);
        return DBClass.GetDataTable("SELECT *, (SELECT Sum(price*count) FROM order_items WHERE order_items.order_id = orders.order_id) AS total_price FROM orders LEFT JOIN carts ON orders.order_id = carts.order_id WHERE " + condition + " AND carts.cart_id IS NULL" + search);
    }


    /// <summary>
    ///  修改订单中的信息
    /// </summary>
    /// <param name="P_Int_OrderID">订单编号</param>
    /// <param name="P_Bl_IsConfirm">是否确认</param>
    /// <param name="P_Bl_IsPayment">是否付款</param>
    /// <param name="P_Bl_IsConsignment">是否已发货</param>
    /// <param name="P_Bl_IsPigeonhole">是否已归档</param>
    public void UpdateOI(int OrderID, int Status)
    {
        DBClass.ExecuteCommand("UPDATE orders SET status = @status WHERE order_id = @order_id", new SqlParameter("@order_id", OrderID), new SqlParameter("@status", Status));
    }
    //*************************************************************************************************
    /// <summary>
    /// 添加商品类别名称
    /// </summary>
    /// <param name="P_Str_ClassName">商品类别名称</param>
    /// <param name="P_Str_categoryUrl">商品类别图像</param>
    /// <returns></returns>
    public void AddCategory(string P_Str_ClassName, string P_Str_categoryUrl)
    {
        bool isExisted = false;
        try
        {
            dbObj.GetInt32("SELECT category_id FROM categories WHERE name = @name", new SqlParameter("@name", P_Str_ClassName));
            isExisted = true;
        }
        catch (Exception)
        {
            DBClass.ExecuteCommand("INSERT INTO categories (name, image_url) VALUES (@name, @image_url)",
                new SqlParameter("@name", P_Str_ClassName), new SqlParameter("@image_url", P_Str_categoryUrl));
        }
        finally
        {
            if (isExisted)
            {
                throw new DuplicateNameException("该商品类别名已存在，请输入其它的商品类别名！");
            }
        }
    }
    /// <summary>
    /// 获取商品类别的数据集
    /// </summary>
    /// <param name="P_Str_srcTable">商品类别信息表名</param>
    /// <returns>商品类别的数据集</returns>
    public DataTable GetCategory(string P_Str_srcTable)
    {
        return DBClass.GetDataTable("SELECT * FROM categories");
    }
   


    /// <summary>
    /// 绑定商品类别名
    /// </summary>
    /// <param name="ddlName">绑定控件名</param>
    public void ddlClassBind(DropDownList ddlName)
    {
        DataTable ds = DBClass.GetDataTable("SELECT category_id, name FROM categories");
        ddlName.DataSource = ds.DefaultView;
        ddlName.DataTextField = ds.Columns[1].ToString();
        ddlName.DataValueField = ds.Columns[0].ToString();
        ddlName.DataBind();
    }
    //*************************************************************************************************
    /// <summary>
    /// 绑定商品图像
    /// </summary>
    /// <param name="ddlName">绑定控件名</param>
    public void ddlUrl(DropDownList ddlName)
    {
        DataTable dt = DBClass.GetDataTable("select * from tb_Image");
        ddlName.DataSource = dt.DefaultView;
        ddlName.DataTextField = dt.Columns[1].ToString();
        ddlName.DataValueField = dt.Columns[2].ToString();
        ddlName.DataBind();
    }
    /// <summary>
    /// 添加商品信息
    /// </summary>
    /// <param name="P_Int_ClassID">商品编号</param>
    /// <param name="P_Str_GoodsName">商品名称</param>
    /// <param name="P_Str_GoodsIntroduce">商品描述</param>
    /// <param name="P_Str_GoodsBrand">商品品牌</param>
    /// <param name="P_Str_GoodsUnit">商品单位</param>
    /// <param name="P_Fl_GoodsWeight">商品重量</param>
    /// <param name="P_Str_GoodsUrl">商品图像</param>
    /// <param name="P_Fl_MarketPrice">商品市场价</param>
    /// <param name="P_Fl_MemberPrice">商品会员价</param>
    /// <param name="P_Bl_Isrefinement">是否是精品</param>
    /// <param name="P_Bl_IsHot">是否是热销商品</param>
    /// <param name="P_Bl_IsDiscount">是否是打折商品</param>
    /// <returns>返回一个值，判断商品是否存在</returns>
    public void AddGInfo(int P_Int_ClassID, string P_Str_GoodsName, string P_Str_GoodsIntroduce, string P_Str_GoodsUnit, string P_Str_GoodsUrl, float P_Flt_MemberPrice)
    {
        bool isExisted = false;
        try
        {
            dbObj.GetInt32("SELECT item_id FROM items WHERE name = @name", new SqlParameter("@name", P_Str_GoodsName));
            isExisted = true;
        }
        catch (Exception)
        {
            DBClass.ExecuteCommand("INSERT INTO items (name, price, description, image_url, quota, cat_id, is_discount) VALUES (@name, @price, @des, @image, @quota, @cat_id, 0)",
                new SqlParameter("@name", P_Str_GoodsName), new SqlParameter("@price", P_Flt_MemberPrice),
                new SqlParameter("@des", P_Str_GoodsIntroduce), new SqlParameter("@image", P_Str_GoodsUrl),
                new SqlParameter("@quota", P_Str_GoodsUnit), new SqlParameter("@cat_id", P_Int_ClassID));
        }
        finally
        {
            if (isExisted)
            {
                throw new DuplicateNameException("该商品已经存在");
            }
        }
    }
    /// <summary>
    /// 获取商品信息的数据集
    /// </summary>
    /// <param name="P_Str_srcTable">商品信息表</param>
    /// <returns>返回商品信息的数据集</returns>
    public DataTable GetGoodsInfoDs()
    {
        return DBClass.GetDataTable("SELECT items.*, categories.name as cat_name, categories.category_id as category_id FROM items JOIN categories ON items.cat_id = categories.category_id");
    }
    /// <summary>
    /// 获取指定商品信息的数据集
    /// </summary>
    /// <param name="P_Int_GoodsID">指定商品的ID</param>
    /// <param name="P_Str_srcTable">商品信息表</param>
    /// <returns>返回指定商品信息的数据集</returns>
    public DataTable GetGoodsInfoByIDDs(int P_Int_GoodsID)
    {
        DataTable good = DBClass.GetDataTable(
            "select items.*, categories.name as class_name from items join categories on items.cat_id = categories.category_id where item_id = @item_id",
            new SqlParameter("@item_id", P_Int_GoodsID));
        return good;
    }
    /// <summary>
    /// 获取搜索商品信息的数据集
    /// </summary>
    /// <param name="P_Str_srcTable">商品信息表</param>
    /// <param name="P_Str_keywords">搜索的关键字</param>
    /// <returns>返回搜索商品信息的数据集</returns>
    public DataTable SearchGoodsInfoDs(string P_Str_keywords)
    {
        return DBClass.GetDataTable(
            "SELECT items.*, categories.name as cat_name, categories.category_id as category_id FROM items JOIN categories ON items.cat_id = categories.category_id WHERE " +
            "items.name LIKE '%' + CONVERT(NVARCHAR(50),@keywords) + '%' or categories.name LIKE '%' + CONVERT(NVARCHAR(50),@keywords) +'%' or items.description LIKE '%' + CONVERT(NVARCHAR(50),@keywords) + '%'",
            new SqlParameter("@keywords", P_Str_keywords));
    }
    /// <summary>
    /// 删除指定的商品信息
    /// </summary>
    /// <param name="P_Int_GoodsID">指定商品的编号</param>
    public void DeleteGoodsInfo(int P_Int_GoodsID)
    {
        DBClass.ExecuteCommand("UPDATE items SET items.deleted = 1 WHERE item_id = @id", new SqlParameter("@id", P_Int_GoodsID));
    }

    public void SetDiscount(int P_Int_GoodsID, bool IsDiscount)
    {
        DBClass.ExecuteCommand("UPDATE items SET items.is_discount = @discount WHERE item_id = @id", new SqlParameter("@discount", IsDiscount), new SqlParameter("@id", P_Int_GoodsID));
    }

    public void SetPrice(int P_Int_GoodsID, Double Price)
    {
        DBClass.ExecuteCommand("UPDATE items SET items.price = @price WHERE item_id = @id", new SqlParameter("@price", Price), new SqlParameter("@id", P_Int_GoodsID));
    }

    
    //*************************************************************************************************
    /// <summary>
    /// 添加管理员
    /// </summary>
    /// <param name="P_Str_Admin">管理员名</param>
    /// <returns></returns>
    public int AddAdmin(string P_Str_Admin, string P_Str_Password)
    {
        bool adminExisted = false;
        try
        {
            dbObj.GetInt32("SELECT admin_id FROM admins WHERE name = @name", new SqlParameter("@name", P_Str_Admin));
            adminExisted = true;
        }
        catch (Exception)
        {
            return dbObj.GetInt32("INSERT INTO admins (name, password) VALUES (@name, @password);select @@identity;", new SqlParameter("@name", P_Str_Admin), new SqlParameter("@password", P_Str_Password));
        }
        finally
        {
            if (adminExisted)
            {
                throw new DuplicateNameException("The name has existed.");
            }
        }

        return -1;
    }
   
    /// <summary>
    /// 返回管理员信息
    /// </summary>
    /// <param name="P_Str_Name">管理员名</param>
    /// <param name="P_Str_Password">管理员密码</param>
    /// <param name="P_Str_srcTable">信息表名</param>
    /// <returns></returns>
    public DataTable ReturnAIDs(string P_Str_Name, string P_Str_Password)
    {
        DataTable ds = DBClass.GetDataTable("SELECT * FROM admins WHERE name = @name AND password = @password", 
            new SqlParameter("@name", P_Str_Name), new SqlParameter("@password", P_Str_Password));
        if (ds.Rows.Count > 0)
        {
            return ds;
        }
        else
        {
            throw new Exception("错误的用户名或密码");
        }
    }
    /// <summary>
    /// 获取所有管理员信息
    /// </summary>
    /// <param name="P_Str_srcTable">管理员信息表名</param>
    /// <returns>返回所有管理员信息的数据集</returns>
    public DataTable ReturnAdminIDs(string P_Str_srcTable)
    {
        return DBClass.GetDataTable("SELECT * FROM admins");
    }
    /// <summary>
    /// 删除指定管理员信息
    /// </summary>
    /// <param name="P_Int_AdminID">管理员编号</param>
    public void DeleteAdminInfo(int P_Int_AdminID)
    {
        DBClass.ExecuteCommand("DELETE FROM admins WHERE admin_id = @id", new SqlParameter("@id", P_Int_AdminID));
    }
    public void UpdateAdminInfo(int P_Int_AdminID, string P_Str_Admin, string P_Str_Password)
    {
        DBClass.ExecuteCommand("UPDATE admins SET name = @name, password = @password WHERE admin_id = @id",
            new SqlParameter("@name", P_Str_Admin), new SqlParameter("@password", P_Str_Password), new SqlParameter("@id", P_Int_AdminID));
    }
    
    
    //**************************************************************************************************
    public DataTable ReturnMemberDs()
    {
        return DBClass.GetDataTable("SELECT * FROM users WHERE delete_at IS NULL");
    }
    /// <summary>
    /// 删除指定会员的信息
    /// </summary>
    /// <param name="P_Int_MemberID">会员ID</param>
    public void DeleteMemberInfo(int P_Int_MemberID)
    {
        DBClass.ExecuteCommand("UPDATE users SET users.delete_at = getdate() WHERE user_id = @id", new SqlParameter("@id", P_Int_MemberID));
    }
    
    /// <summary>
    /// 返回指定类别的名称
    /// </summary>
    /// <param name="P_Int_ClassID">指定类别的ID</param>
    /// <returns></returns>
    public string GetClass(int P_Int_ClassID)
    {
        DataTable ds = DBClass.GetDataTable("select name from categories where category_id = @category_id",
            new SqlParameter("@category_id", P_Int_ClassID));
        return ds.Rows[0][0].ToString();
    }
    
    

    public DataTable SearchUser(string TableSrc, string SearchStr, bool Deleted)
    {
        return DBClass.GetDataTable("SELECT * FROM users WHERE " + (Deleted ? "delete_at IS NOT NULL AND" : "delete_at IS NULL AND") + "( name LIKE '%' + CONVERT(NVARCHAR(50),@keywords) + '%' or true_name LIKE '%' + CONVERT(NVARCHAR(50),@keywords) + '%' or " +
            "city LIKE '%' + CONVERT(NVARCHAR(50),@keywords) + '%' or " +
            "email LIKE '%' + CONVERT(NVARCHAR(50),@keywords) + '%')",
            new SqlParameter("@keywords", SearchStr));
    }
    /// <summary>
    /// 用来将字符串保留到指定长度，将超出部分用“...”代替。
    /// </summary>
    /// <param name="sString">sString原字符串。</param>
    /// <param name="nLeng">nLeng长度。</param>
    /// <returns>处理后的字符串。</returns>
    public string SubStr(string sString, int nLeng)
    {
        if (sString.Length <= nLeng)
        {
            return sString;
        }
        int nStrLeng = nLeng - 3;
        string sNewStr = sString.Substring(0, nStrLeng);
        sNewStr = sNewStr + "...";
        return sNewStr;
    }
    /// <summary>
    /// 用来截取小数点后nleng位
    /// </summary>
    /// <param name="sString">sString原字符串。</param>
    /// <param name="nLeng">nLeng长度。</param>
    /// <returns>处理后的字符串。</returns>
    public string VarStr(string sString, int nLeng)
    {
        int index = sString.IndexOf(".");
        if (index == -1 || index + 2 >= sString.Length)
            return sString;
        else
            return sString.Substring(0, (index + nLeng + 1));
    }

}
