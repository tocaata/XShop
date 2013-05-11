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
    public void gvBind(GridView gvName, SqlCommand myCmd, string P_Str_srcTable)
    {
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        gvName.DataSource = ds.Tables[P_Str_srcTable].DefaultView;
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
    public DataSet GetNewOrder(string TableSrc)
    {
        DataSet ds = dbObj.GetDataSet("SELECT * FROM orders LEFT JOIN carts ON carts.order_id = orders.order_id WHERE DATEDIFF(day, orders.create_at, getdate()) < 1 AND carts.cart_id IS NULL", TableSrc);
        return ds;
    }

    // 得到一天以内新建的用户
    public DataSet GetNewUser(string TableSrc)
    {
        DataSet ds = dbObj.GetDataSet("SELECT * FROM users WHERE DATEDIFF(day, create_at, getdate()) < 1", TableSrc);
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
    public DataSet OrderByStatus(bool flag, int Status, string TableSrc)
    {
        return dbObj.GetDataSet("SELECT *, (SELECT Sum(price*count) FROM order_items WHERE order_items.order_id = orders.order_id) AS total_price FROM orders LEFT JOIN carts ON orders.order_id = carts.order_id WHERE orders.status " + 
            (flag ? "=" : "<>") + " @status AND carts.cart_id IS NULL",
            TableSrc, new SqlParameter("@status", Status));
    }

    public DataSet OrderByStatus(int IsShipped, int IsConfirm, int IsReturn, int IsSpeed, int IsReceive, string TableSrc)
    {
        string[] str = { "1=1", "1=1", "1=1", "1=1", "1=1" };
        int[] stat = { IsShipped, IsConfirm, IsReturn, IsReceive }, value = {3, 2, 5, 4};

        for (int i = 0; i < 4; i++)
        {
            switch (stat[i])
            {
                case 0:
                    str[i] = "orders.status <> " + value[i];
                    break;
                case 1:
                    str[i] = "orders.status = " + value[i];
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
        return dbObj.GetDataSet("SELECT *, (SELECT Sum(price*count) FROM order_items WHERE order_items.order_id = orders.order_id) AS total_price FROM orders LEFT JOIN carts ON orders.order_id = carts.order_id WHERE " + condition + " AND carts.cart_id IS NULL", TableSrc);
    }

    public SqlCommand GetOrderInfo(int P_Int_Flag, int P_Int_IsMember, int P_Int_MemberID, int P_Int_OrderID, int P_Int_Confirm, int P_Int_Payed, int P_Int_Shipped, int P_Int_Finished, int P_Int_IsConfirm, int P_Int_IsPayment, int P_Int_IsConsignment, int P_Int_IsPigeonhole)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetOrderInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter Flag = new SqlParameter("@Flag", SqlDbType.Int, 4);
        Flag.Value = P_Int_Flag;
        myCmd.Parameters.Add(Flag);
        //添加参数
        SqlParameter IsMember = new SqlParameter("@IsMember", SqlDbType.Int, 4);
        IsMember.Value = P_Int_IsMember;
        myCmd.Parameters.Add(IsMember);
        //添加参数
        SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.Int, 4);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);
        //添加参数
        SqlParameter Confirm = new SqlParameter("@Confirm", SqlDbType.Int, 4);
        Confirm.Value = P_Int_Confirm;
        myCmd.Parameters.Add(Confirm);
        //添加参数
        SqlParameter Payed = new SqlParameter("@Payed", SqlDbType.Int, 4);
        Payed.Value = P_Int_Payed;
        myCmd.Parameters.Add(Payed);
        //添加参数
        SqlParameter Shipped = new SqlParameter("@Shipped", SqlDbType.Int, 4);
        Shipped.Value = P_Int_Shipped;
        myCmd.Parameters.Add(Shipped);
        SqlParameter Finished = new SqlParameter("@Finished", SqlDbType.Int, 4);
        Finished.Value = P_Int_Finished;
        myCmd.Parameters.Add(Finished);
        //添加参数
        SqlParameter IsConfirm = new SqlParameter("@IsConfirm", SqlDbType.Int, 4);
        IsConfirm.Value = P_Int_IsConfirm;
        myCmd.Parameters.Add(IsConfirm);
        //添加参数
        SqlParameter IsPayment = new SqlParameter("@IsPayment", SqlDbType.Int, 4);
        IsPayment.Value = P_Int_IsPayment;
        myCmd.Parameters.Add(IsPayment);
        //添加参数
        SqlParameter IsConsignment = new SqlParameter("@IsConsignment", SqlDbType.Int, 4);
        IsConsignment.Value = P_Int_IsConsignment;
        myCmd.Parameters.Add(IsConsignment);
        //添加参数
        SqlParameter IsPigeonhole = new SqlParameter("@IsPigeonhole", SqlDbType.Int, 4);
        IsPigeonhole.Value = P_Int_IsPigeonhole;
        myCmd.Parameters.Add(IsPigeonhole);
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
    /// <summary>
    /// 删除指定订单的信息
    /// </summary>
    /// <param name="P_Int_OrderID">订单编号</param>
    public void DeleteOrderInfo(int P_Int_OrderID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeleteOrderInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);
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
    }
    /// <summary>
    /// 获取运输方式名
    /// </summary>
    /// <param name="P_Int_ShipType">运输编号</param>
    /// <returns></returns>
    public string GetShipWay(int P_Int_ShipType)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetShipWay", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ShipType = new SqlParameter("@ShipType", SqlDbType.Int, 4);
        ShipType.Value = P_Int_ShipType;
        myCmd.Parameters.Add(ShipType);
        //执行过程
        myConn.Open();
        string P_Str_ShipWay = Convert.ToString(myCmd.ExecuteScalar());
        myCmd.Dispose();
        myConn.Close();
        return P_Str_ShipWay;
    }
    /// <summary>
    /// 获取支付方式名
    /// </summary>
    /// <param name="P_Int_PayType">获取支付编号</param>
    /// <returns></returns>
    public string GetPayWay(int P_Int_PayType)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetPayWay", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter PayType = new SqlParameter("@PayType", SqlDbType.Int, 4);
        PayType.Value = P_Int_PayType;
        myCmd.Parameters.Add(PayType);
        //执行过程
        myConn.Open();
        string P_Str_PayWay = Convert.ToString(myCmd.ExecuteScalar());
        myCmd.Dispose();
        myConn.Close();
        return P_Str_PayWay;
    }
    /// <summary>
    /// 获取订单状态的Dataset数据集
    /// </summary>
    /// <param name="P_Int_OrderID">订单编号</param>
    /// <param name="P_Str_srcTable">订单信息</param>
    /// <returns>返回Dataset</returns>
    public DataSet GetStatusDS(int P_Int_OrderID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetStatus", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);
        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    /// 获取订单状态的Dataset数据集
    /// </summary>
    /// <param name="P_Int_OrderID">订单编号</param>
    /// <param name="P_Str_srcTable">订单信息</param>
    /// <returns>返回Dataset</returns>
    public DataSet GetOdIfDS(int P_Int_OrderID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetOdIf", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);
        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    /// 通过订单ID代号，获取商品信息
    /// </summary>
    /// <param name="P_Int_OrderID">订单ID代号</param>
    /// <param name="P_Str_srcTable">信息</param>
    /// <returns>返回信息的数据集Ds</returns>
    public DataSet GetGIByOID(int P_Int_OrderID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetGIByOID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);
        //执行过程
        myConn.Open();
        myCmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        myCmd.Dispose();
        myConn.Dispose();
        return ds;
    }
    /// <summary>
    ///  修改订单中的信息
    /// </summary>
    /// <param name="P_Int_OrderID">订单编号</param>
    /// <param name="P_Bl_IsConfirm">是否确认</param>
    /// <param name="P_Bl_IsPayment">是否付款</param>
    /// <param name="P_Bl_IsConsignment">是否已发货</param>
    /// <param name="P_Bl_IsPigeonhole">是否已归档</param>
    public void UpdateOI(int P_Int_OrderID, bool P_Bl_IsConfirm, bool P_Bl_IsPayment, bool P_Bl_IsConsignment, bool P_Bl_IsPigeonhole)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_UpdateOI", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);
        //添加参数
        SqlParameter IsConfirm = new SqlParameter("@IsConfirm", SqlDbType.Bit, 1);
        IsConfirm.Value = P_Bl_IsConfirm;
        myCmd.Parameters.Add(IsConfirm);
        //添加参数
        SqlParameter IsPayment = new SqlParameter("@IsPayment", SqlDbType.Bit, 1);
        IsPayment.Value = P_Bl_IsPayment;
        myCmd.Parameters.Add(IsPayment);
        //添加参数
        SqlParameter IsConsignment = new SqlParameter("@IsConsignment", SqlDbType.Bit, 1);
        IsConsignment.Value = P_Bl_IsConsignment;
        myCmd.Parameters.Add(IsConsignment);
        //添加参数
        SqlParameter IsPigeonhole = new SqlParameter("@IsPigeonhole", SqlDbType.Bit, 1);
        IsPigeonhole.Value = P_Bl_IsPigeonhole;
        myCmd.Parameters.Add(IsPigeonhole);
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
            dbObj.Update("INSERT INTO categories (name, image_url) VALUES (@name, @image_url)",
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
    public DataSet GetCategory(string P_Str_srcTable)
    {
        return dbObj.GetDataSet("SELECT * FROM categories", P_Str_srcTable);
    }
    /// <summary>
    /// 删除指定商品的类别名
    /// </summary>
    /// <param name="P_Int_ClassID">类别编号</param>
    public void DeleteCategory(int P_Int_ClassID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeleteCategory", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ClassID = new SqlParameter("@ClassID", SqlDbType.BigInt, 8);
        ClassID.Value = P_Int_ClassID;
        myCmd.Parameters.Add(ClassID);
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
    }


    /// <summary>
    /// 绑定商品类别名
    /// </summary>
    /// <param name="ddlName">绑定控件名</param>
    public void ddlClassBind(DropDownList ddlName)
    {
        DataSet ds = dbObj.GetDataSet("SELECT category_id, name FROM categories", "Class");
        ddlName.DataSource = ds.Tables["Class"].DefaultView;
        ddlName.DataTextField = ds.Tables["Class"].Columns[1].ToString();
        ddlName.DataValueField = ds.Tables["Class"].Columns[0].ToString();
        ddlName.DataBind();
    }
    //*************************************************************************************************
    /// <summary>
    /// 绑定商品图像
    /// </summary>
    /// <param name="ddlName">绑定控件名</param>
    public void ddlUrl(DropDownList ddlName)
    {
        string P_Str_SqlStr = "select * from tb_Image";
        SqlConnection myConn = dbObj.GetConnection();
        SqlDataAdapter da = new SqlDataAdapter(P_Str_SqlStr, myConn);
        DataSet ds = new DataSet();
        da.Fill(ds, "Url");
        ddlName.DataSource = ds.Tables["Url"].DefaultView;
        ddlName.DataTextField = ds.Tables["Url"].Columns[1].ToString();
        ddlName.DataValueField = ds.Tables["Url"].Columns[2].ToString();
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
    public void AddGInfo(int P_Int_ClassID, string P_Str_GoodsName, string P_Str_GoodsIntroduce, string P_Str_GoodsUnit, string P_Str_GoodsUrl, float P_Flt_MemberPrice, bool P_Bl_IsDiscount)
    {
        bool isExisted = false;
        try
        {
            dbObj.GetInt32("SELECT item_id FROM items WHERE name = @name", new SqlParameter("@name", P_Str_GoodsName));
            isExisted = true;
        }
        catch (Exception)
        {
            dbObj.Update("INSERT INTO items (name, price, description, image_url, quota, cat_id, is_discount) VALUES (@name, @price, @des, @image, @quota, @cat_id, @discount)",
                new SqlParameter("@name", P_Str_GoodsName), new SqlParameter("@price", P_Flt_MemberPrice),
                new SqlParameter("@des", P_Str_GoodsIntroduce), new SqlParameter("@image", P_Str_GoodsUrl),
                new SqlParameter("@quota", P_Str_GoodsUnit), new SqlParameter("@cat_id", P_Int_ClassID),
                new SqlParameter("@discount", P_Bl_IsDiscount));
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
    public DataSet GetGoodsInfoDs(string P_Str_srcTable)
    {
        return dbObj.GetDataSet("SELECT items.*, categories.name as cat_name, categories.category_id as category_id FROM items JOIN categories ON items.cat_id = categories.category_id", P_Str_srcTable);
    }
    /// <summary>
    /// 获取指定商品信息的数据集
    /// </summary>
    /// <param name="P_Int_GoodsID">指定商品的ID</param>
    /// <param name="P_Str_srcTable">商品信息表</param>
    /// <returns>返回指定商品信息的数据集</returns>
    public DataSet GetGoodsInfoByIDDs(int P_Int_GoodsID, string P_Str_srcTable)
    {
        DataSet good = dbObj.GetDataSet(
            "select * from items where item_id = @item_id", P_Str_srcTable,
            new SqlParameter("@item_id", P_Int_GoodsID));
        return good;
        //SqlConnection myConn = dbObj.GetConnection();
        //SqlCommand myCmd = new SqlCommand("Proc_GetGoodsInfoByID", myConn);
        //myCmd.CommandType = CommandType.StoredProcedure;
        ////添加参数
        //SqlParameter GoodsID = new SqlParameter("@GoodsID", SqlDbType.BigInt, 8);
        //GoodsID.Value = P_Int_GoodsID;
        //myCmd.Parameters.Add(GoodsID);
        ////执行过程
        //myConn.Open();
        //myCmd.ExecuteNonQuery();
        //SqlDataAdapter da = new SqlDataAdapter(myCmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds, P_Str_srcTable);
        //myCmd.Dispose();
        //myConn.Dispose();
        //return ds;
    }
    /// <summary>
    /// 获取搜索商品信息的数据集
    /// </summary>
    /// <param name="P_Str_srcTable">商品信息表</param>
    /// <param name="P_Str_keywords">搜索的关键字</param>
    /// <returns>返回搜索商品信息的数据集</returns>
    public DataSet SearchGoodsInfoDs(string P_Str_srcTable, string P_Str_keywords)
    {
        return dbObj.GetDataSet(
            "SELECT items.*, categories.name as cat_name, categories.category_id as category_id FROM items JOIN categories ON items.cat_id = categories.category_id WHERE " +
            "items.name LIKE '%' + CONVERT(NVARCHAR(50),@keywords) + '%' or categories.name LIKE '%' + CONVERT(NVARCHAR(50),@keywords) +'%' or items.description LIKE '%' + CONVERT(NVARCHAR(50),@keywords) + '%'",
            P_Str_srcTable, new SqlParameter("@keywords", P_Str_keywords));

        //SqlConnection myConn = dbObj.GetConnection();
        //SqlCommand myCmd = new SqlCommand("Proc_SearchGoodsInfo", myConn);
        //myCmd.CommandType = CommandType.StoredProcedure;
        ////添加参数
        //SqlParameter keywords = new SqlParameter("@keywords", SqlDbType.VarChar, 50);
        //keywords.Value = P_Str_keywords;
        //myCmd.Parameters.Add(keywords);

        ////执行过程
        //myConn.Open();
        //myCmd.ExecuteNonQuery();
        //SqlDataAdapter da = new SqlDataAdapter(myCmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds, P_Str_srcTable);
        //myCmd.Dispose();
        //myConn.Dispose();
        //return ds;
    }
    /// <summary>
    /// 删除指定的商品信息
    /// </summary>
    /// <param name="P_Int_GoodsID">指定商品的编号</param>
    public void DeleteGoodsInfo(int P_Int_GoodsID)
    {
        dbObj.Update("DELETE FROM items WHERE item_id = @id", new SqlParameter("@id", P_Int_GoodsID));
    }
    public void UpdateGInfo(int P_Int_ClassID, string P_Str_GoodsName, string P_Str_GoodsIntroduce, string P_Str_GoodsBrand, string P_Str_GoodsUnit, float P_Flt_GoodsWeight, string P_Str_GoodsUrl, float P_Flt_MarketPrice, float P_Flt_MemberPrice, bool P_Bl_Isrefinement, bool P_Bl_IsHot, bool P_Bl_IsDiscount, int P_Int_GoodsID)
    {

        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_UpdateGoodsInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ClassID = new SqlParameter("@ClassID", SqlDbType.BigInt, 8);
        ClassID.Value = P_Int_ClassID;
        myCmd.Parameters.Add(ClassID);
        //添加参数
        SqlParameter GoodsName = new SqlParameter("@GoodsName", SqlDbType.VarChar, 50);
        GoodsName.Value = P_Str_GoodsName;
        myCmd.Parameters.Add(GoodsName);
        //添加参数
        SqlParameter GoodsIntroduce = new SqlParameter("@GoodsIntroduce", SqlDbType.NText, 16);
        GoodsIntroduce.Value = P_Str_GoodsIntroduce;
        myCmd.Parameters.Add(GoodsIntroduce);
        //添加参数
        SqlParameter GoodsBrand = new SqlParameter("@GoodsBrand", SqlDbType.VarChar, 50);
        GoodsBrand.Value = P_Str_GoodsBrand;
        myCmd.Parameters.Add(GoodsBrand);
        //添加参数
        SqlParameter GoodsUnit = new SqlParameter("@GoodsUnit", SqlDbType.VarChar, 10);
        GoodsUnit.Value = P_Str_GoodsUnit;
        myCmd.Parameters.Add(GoodsUnit);
        //添加参数
        SqlParameter GoodsWeight = new SqlParameter("@GoodsWeight", SqlDbType.Float, 8);
        GoodsWeight.Value = P_Flt_GoodsWeight;
        myCmd.Parameters.Add(GoodsWeight);
        //添加参数
        SqlParameter GoodsUrl = new SqlParameter("@GoodsUrl", SqlDbType.VarChar, 50);
        GoodsUrl.Value = P_Str_GoodsUrl;
        myCmd.Parameters.Add(GoodsUrl);
        //添加参数
        SqlParameter MarketPrice = new SqlParameter("@MarketPrice", SqlDbType.Float, 8);
        MarketPrice.Value = P_Flt_MarketPrice;
        myCmd.Parameters.Add(MarketPrice);
        //添加参数
        SqlParameter MemberPrice = new SqlParameter("@MemberPrice", SqlDbType.Float, 8);
        MemberPrice.Value = P_Flt_MemberPrice;
        myCmd.Parameters.Add(MemberPrice);
        //添加参数
        SqlParameter Isrefinement = new SqlParameter("@Isrefinement", SqlDbType.Bit, 1);
        Isrefinement.Value = P_Bl_Isrefinement;
        myCmd.Parameters.Add(Isrefinement);
        //添加参数
        SqlParameter IsHot = new SqlParameter("@IsHot", SqlDbType.Bit, 1);
        IsHot.Value = P_Bl_IsHot;
        myCmd.Parameters.Add(IsHot);
        //添加参数
        SqlParameter IsDiscount = new SqlParameter("@IsDiscount", SqlDbType.Bit, 1);
        IsDiscount.Value = P_Bl_IsDiscount;
        myCmd.Parameters.Add(IsDiscount);
        //添加参数
        SqlParameter GoodsID = new SqlParameter("@GoodsID", SqlDbType.BigInt, 8);
        GoodsID.Value = P_Int_GoodsID;
        myCmd.Parameters.Add(GoodsID);
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
    /// 判断管理员是否存在
    /// </summary>
    /// <param name="P_Str_Name">管理员名字</param>
    /// <param name="P_Str_Password">管理员密码</param>
    /// <returns></returns>
    public int AExists(string P_Str_Name, string P_Str_Password)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_AdminExists", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter Name = new SqlParameter("@Name", SqlDbType.VarChar, 50);
        Name.Value = P_Str_Name;
        myCmd.Parameters.Add(Name);
        //添加参数
        SqlParameter Password = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Password.Value = P_Str_Password;
        myCmd.Parameters.Add(Password);
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
        int P_Int_returnValue = Convert.ToInt32(returnValue.Value.ToString());
        return P_Int_returnValue;
    }
    /// <summary>
    /// 返回管理员信息
    /// </summary>
    /// <param name="P_Str_Name">管理员名</param>
    /// <param name="P_Str_Password">管理员密码</param>
    /// <param name="P_Str_srcTable">信息表名</param>
    /// <returns></returns>
    public DataSet ReturnAIDs(string P_Str_Name, string P_Str_Password, string P_Str_srcTable)
    {
        DataSet ds = dbObj.GetDataSet("SELECT * FROM admins WHERE name = @name AND password = @password", P_Str_srcTable, 
            new SqlParameter("@name", P_Str_Name), new SqlParameter("@password", P_Str_Password));
        if (ds.Tables[P_Str_srcTable].Rows.Count > 0)
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
    public DataSet ReturnAdminIDs(string P_Str_srcTable)
    {
        return dbObj.GetDataSet("SELECT * FROM admins", P_Str_srcTable);
    }
    /// <summary>
    /// 删除指定管理员信息
    /// </summary>
    /// <param name="P_Int_AdminID">管理员编号</param>
    public void DeleteAdminInfo(int P_Int_AdminID)
    {
        dbObj.Update("DELETE FROM admins WHERE admin_id = @id", new SqlParameter("@id", P_Int_AdminID));
    }
    public void UpdateAdminInfo(int P_Int_AdminID, string P_Str_Admin, string P_Str_Password)
    {
        dbObj.Update("UPDATE admins SET name = @name, password = @password WHERE admin_id = @id",
            new SqlParameter("@name", P_Str_Admin), new SqlParameter("@password", P_Str_Password), new SqlParameter("@id", P_Int_AdminID));
    }
    //***********************************************************************************************************
    /// <summary>
    /// 获取图像信息
    /// </summary>
    /// <param name="P_Str_srcTable">图像信息</param>
    /// <returns>返回图像信息数据集</returns>
    public DataSet ReturnImagerDs(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetImageInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
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
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;

    }
    /// <summary>
    /// 向图像表中插入信息
    /// </summary>
    /// <param name="P_Str_ImageName">图像名</param>
    /// <param name="P_Int_ImageUrl">图像路径</param>
    public void InsertImage(string P_Str_ImageName, string P_Str_ImageUrl)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_InsertImageInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ImageName = new SqlParameter("@ImageName", SqlDbType.VarChar, 50);
        ImageName.Value = P_Str_ImageName;
        myCmd.Parameters.Add(ImageName);
        //添加参数
        SqlParameter ImageUrl = new SqlParameter("@ImageUrl", SqlDbType.VarChar, 200);
        ImageUrl.Value = P_Str_ImageUrl;
        myCmd.Parameters.Add(ImageUrl);
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
    }
    /// <summary>
    /// 删除图片表中的信息
    /// </summary>
    /// <param name="P_Int_ImageID">图片表中ID</param>
    public void DeleteImage(int P_Int_ImageID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeleteImageInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ImageID = new SqlParameter("@ImageID", SqlDbType.BigInt, 8);
        ImageID.Value = P_Int_ImageID;
        myCmd.Parameters.Add(ImageID);
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
    }
    //**************************************************************************************************
    public DataSet ReturnMemberDs(string P_Str_srcTable)
    {
        return dbObj.GetDataSet("SELECT * FROM users", P_Str_srcTable);
    }
    /// <summary>
    /// 删除指定会员的信息
    /// </summary>
    /// <param name="P_Int_MemberID">会员ID</param>
    public void DeleteMemberInfo(int P_Int_MemberID)
    {
        dbObj.Update("DELETE FROM users WHERE user_id = @id", new SqlParameter("@id", P_Int_MemberID));
    }
    //*********************************************************************************************
    /// <summary>
    /// 获取配送方式的数据集
    /// </summary>
    /// <param name="P_Str_srcTable">配送方式表的信息</param>
    /// <returns>返回配送方式的数据集</returns>
    public DataSet ReturnShipDs(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetShipInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
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
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    /// <summary>
    /// 返回指定配送方式信息的数据集
    /// </summary>
    /// <param name="P_Int_ShipID">配送方式ID</param>
    /// <param name="P_Str_srcTable">配送方式信息</param>
    /// <returns></returns>
    public DataSet ReturnShipDsByID(int P_Int_ShipID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetShipInfoByID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ShipID = new SqlParameter("@ShipID", SqlDbType.BigInt, 8);
        ShipID.Value = P_Int_ShipID;
        myCmd.Parameters.Add(ShipID);
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
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    /// <summary>
    /// 删除指定配送方式信息
    /// </summary>
    /// <param name="P_Int_ShipID">指定配送方式的ID</param>
    public void DeleteShipInfo(int P_Int_ShipID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeleteShipInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ShipID = new SqlParameter("@ShipID", SqlDbType.BigInt, 8);
        ShipID.Value = P_Int_ShipID;
        myCmd.Parameters.Add(ShipID);
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
    }
    /// <summary>
    /// 返回指定类别的名称
    /// </summary>
    /// <param name="P_Int_ClassID">指定类别的ID</param>
    /// <returns></returns>
    public string GetClass(int P_Int_ClassID)
    {
        DataSet ds = dbObj.GetDataSet("select name from categories where category_id = @category_id", "catergory",
            new SqlParameter("@category_id", P_Int_ClassID));
        return ds.Tables["catergory"].Rows[0][0].ToString();
        //SqlConnection myConn = dbObj.GetConnection();
        //SqlCommand myCmd = new SqlCommand("Proc_GetClassName", myConn);
        //myCmd.CommandType = CommandType.StoredProcedure;
        ////添加参数
        //SqlParameter ClassID = new SqlParameter("@ClassID", SqlDbType.Int, 8);
        //ClassID.Value = P_Int_ClassID;
        //myCmd.Parameters.Add(ClassID);
        ////执行过程
        //myConn.Open();
        //string P_Str_Class = Convert.ToString(myCmd.ExecuteScalar());
        //myCmd.Dispose();
        //myConn.Close();
        //return P_Str_Class;
    }
    public void InsertShip(string P_Str_ShipWay, float P_Flt_ShipFee, int P_int_ClassID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_InsertShipInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ShipWay = new SqlParameter("@ShipWay", SqlDbType.VarChar, 50);
        ShipWay.Value = P_Str_ShipWay;
        myCmd.Parameters.Add(ShipWay);
        //添加参数
        SqlParameter ShipFee = new SqlParameter("@ShipFee", SqlDbType.Float, 8);
        ShipFee.Value = P_Flt_ShipFee;
        myCmd.Parameters.Add(ShipFee);

        //添加参数
        SqlParameter ClassID = new SqlParameter("@ClassID", SqlDbType.BigInt, 8);
        ClassID.Value = P_int_ClassID;
        myCmd.Parameters.Add(ClassID);
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
    }
    public void UpdateShip(int P_Int_ShipID, string P_Str_ShipWay, float P_Flt_ShipFee, int P_int_ClassID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_UpdateShipInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter ShipID = new SqlParameter("@ShipID", SqlDbType.BigInt, 8);
        ShipID.Value = P_Int_ShipID;
        myCmd.Parameters.Add(ShipID);
        //添加参数
        SqlParameter ShipWay = new SqlParameter("@ShipWay", SqlDbType.VarChar, 50);
        ShipWay.Value = P_Str_ShipWay;
        myCmd.Parameters.Add(ShipWay);
        //添加参数
        SqlParameter ShipFee = new SqlParameter("@ShipFee", SqlDbType.Float, 8);
        ShipFee.Value = P_Flt_ShipFee;
        myCmd.Parameters.Add(ShipFee);

        //添加参数
        SqlParameter ClassID = new SqlParameter("@ClassID", SqlDbType.BigInt, 8);
        ClassID.Value = P_int_ClassID;
        myCmd.Parameters.Add(ClassID);
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
    }
    //*********************************************************************************************
    /// <summary>
    /// 获取支付方式的数据集
    /// </summary>
    /// <param name="P_Str_srcTable">支付方式表的信息</param>
    /// <returns>返回支付方式的数据集</returns>
    public DataSet ReturnPayDs(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetPayInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
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
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    /// <summary>
    /// 返回指定支付方式信息的数据集
    /// </summary>
    /// <param name="P_Int_PayID">支付方式ID</param>
    /// <param name="P_Str_srcTable">支付方式信息</param>
    /// <returns></returns>
    public DataSet ReturnPayDsByID(int P_Int_PayID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetPayInfoByID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter PayID = new SqlParameter("@PayID", SqlDbType.BigInt, 8);
        PayID.Value = P_Int_PayID;
        myCmd.Parameters.Add(PayID);
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
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    /// <summary>
    /// 删除指定支付方式信息
    /// </summary>
    /// <param name="P_Int_PayID">指定支付方式的ID</param>
    public void DeletePayInfo(int P_Int_PayID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeletePayInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter PayID = new SqlParameter("@PayID", SqlDbType.BigInt, 8);
        PayID.Value = P_Int_PayID;
        myCmd.Parameters.Add(PayID);
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
    }
    public void InsertPay(string P_Str_PayWay)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_InsertPayInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter PayWay = new SqlParameter("@PayWay", SqlDbType.VarChar, 50);
        PayWay.Value = P_Str_PayWay;
        myCmd.Parameters.Add(PayWay);
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
    }
    public void UpdatePay(int P_Int_PayID, string P_Str_PayWay)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_UpdatePayInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter PayID = new SqlParameter("@PayID", SqlDbType.BigInt, 8);
        PayID.Value = P_Int_PayID;
        myCmd.Parameters.Add(PayID);
        //添加参数
        SqlParameter PayWay = new SqlParameter("@PayWay", SqlDbType.VarChar, 50);
        PayWay.Value = P_Str_PayWay;
        myCmd.Parameters.Add(PayWay);
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
    }
    //*********************************************************
    /// <summary>
    /// 查询所有配送地点信息
    /// </summary>
    /// <param name="P_Str_srcTable">地点表信息</param>
    /// <returns>返回所有配送地点信息数据集</returns>
    public DataSet ReturnAreaDs(string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetAreaInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
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
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    /// <summary>
    /// 删除指定地点的信息
    /// </summary>
    /// <param name="P_Int_AreaID">地点编号</param>
    public void DeleteAreaInfo(int P_Int_AreaID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeleteAreaInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AreaID = new SqlParameter("@AreaID", SqlDbType.BigInt, 8);
        AreaID.Value = P_Int_AreaID;
        myCmd.Parameters.Add(AreaID);
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
    }
    /// <summary>
    /// 查询指定地点编号信息的数据集
    /// </summary>
    /// <param name="P_Int_AreaID">地点编号</param>
    /// <param name="P_Str_srcTable">地点数据表</param>
    /// <returns>返回指定地点编号信息的数据集</returns>
    public DataSet ReturnAreaDsByID(int P_Int_AreaID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetAreaInfoByID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AreaID = new SqlParameter("@AreaID", SqlDbType.BigInt, 8);
        AreaID.Value = P_Int_AreaID;
        myCmd.Parameters.Add(AreaID);
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
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        return ds;
    }
    public void InsertArea(string P_Str_AreaName, int P_Int_AreaKM)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_InsertAreaInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AreaName = new SqlParameter("@AreaName", SqlDbType.VarChar, 50);
        AreaName.Value = P_Str_AreaName;
        myCmd.Parameters.Add(AreaName);
        //添加参数
        SqlParameter AreaKM = new SqlParameter("@AreaKM", SqlDbType.Int, 4);
        AreaKM.Value = P_Int_AreaKM;
        myCmd.Parameters.Add(AreaKM);
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
    }
    public void UpdateArea(int P_Int_AreaID, string P_Str_AreaName, int P_Int_AreaKM)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_UpdateAreaInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter AreaID = new SqlParameter("@AreaID", SqlDbType.BigInt, 8);
        AreaID.Value = P_Int_AreaID;
        myCmd.Parameters.Add(AreaID);
        //添加参数
        SqlParameter AreaName = new SqlParameter("@AreaName", SqlDbType.VarChar, 50);
        AreaName.Value = P_Str_AreaName;
        myCmd.Parameters.Add(AreaName);
        //添加参数
        SqlParameter AreaKM = new SqlParameter("@AreaKM", SqlDbType.Int, 4);
        AreaKM.Value = P_Int_AreaKM;
        myCmd.Parameters.Add(AreaKM);
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
    }

    public DataSet SearchUser(string TableSrc, string SearchStr)
    {
        return dbObj.GetDataSet("SELECT * FROM users WHERE name LIKE '%' + CONVERT(NVARCHAR(50),@keywords) + '%' or true_name LIKE '%' + CONVERT(NVARCHAR(50),@keywords) + '%' or " +
            "city LIKE '%' + CONVERT(NVARCHAR(50),@keywords) + '%' or " +
            "email LIKE '%' + CONVERT(NVARCHAR(50),@keywords) + '%'",
            TableSrc, new SqlParameter("@keywords", SearchStr));
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
