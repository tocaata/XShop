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
using System.Text;


public class NoneUserException : Exception
{
    public NoneUserException(String m) : base(m)
    {
    }

    public NoneUserException() : base()
    {
    }
}

/// <summary>
/// UserInfoClass 的摘要说明
/// </summary>
public class UserInfoClass
{
    DBClass dbObj = new DBClass();
	public UserInfoClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    //***************************************登录界面************************************************************
    /// <summary>
    /// 判断用户是否存在
    /// </summary>
    /// <param name="P_Str_Name">会员登录名</param>
    /// <param name="P_Str_Password">会员登录密码</param>
    /// <returns></returns>
    public bool UserExists(string P_Str_Name,string P_Str_Password)
    {
        DataTable ds = DBClass.GetDataTable("SELECT * FROM users WHERE name=@name and password=@password", new SqlParameter("@name", P_Str_Name), new SqlParameter("@password", P_Str_Password));
        int hasUser = ds.Rows.Count;
        if (hasUser == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
  /// <summary>
  /// 获取会员信息
  /// </summary>
  /// <param name="P_Str_Name">会员登录名</param>
  /// <param name="P_Str_Password">会员登录密码</param>
  /// <param name="P_Str_srcTable">查询表信息</param>
  /// <returns></returns>
    public DataTable ReturnUIDs(string P_Str_Name, string P_Str_Password,string P_Str_srcTable)
    {
        StringBuilder cmd = new StringBuilder();
        cmd.AppendFormat("SELECT * FROM users WHERE name='{0}' and password='{1}'", P_Str_Name, P_Str_Password);
        return DBClass.GetDataTable(cmd.ToString());
    }

    public DataTable ReturnUsers(string name, string password)
    {
        return DBClass.GetDataTable("SELECT * FROM users WHERE name=@name and password=@password", new SqlParameter("@name", name), new SqlParameter("@password", password));
    }

    //***************************************注册界面************************************************************
    /// <summary>
    /// 向用户表中插入信息
    /// </summary>
    /// <param name="P_Str_Name">会员名</param>
    /// <param name="P_Bl_Sex">性别</param>
    /// <param name="P_Str_Password">密码</param>
    /// <param name="P_Str_TrueName">真实姓名</param>
    /// <param name="P_Str_Questions">找回密码问题</param>
    /// <param name="P_Str_Answers">找回密码答案</param>
    /// <param name="P_Str_Phonecode">电话号码</param>
    /// <param name="P_Str_Emails">E_Mail</param>
    /// <param name="P_Str_City">会员所在城市</param>
    /// <param name="P_Str_Address">会员详细地址</param>
    /// <param name="P_Str_PostCode">邮编</param>
    /// <param name="P_Flt_AdvancePayment">预付金额</param>
    /// <param name="P_Date_LoadDate">登录日期</param>
    public int AddUInfo(string P_Str_Name, bool P_Bl_Sex, string P_Str_Password, string P_Str_TrueName, string P_Str_Questions, string P_Str_Answers, string P_Str_Phonecode, string P_Str_Emails, string P_Str_City, string P_Str_Address)
    {
        if (DBClass.IsExisted("SELECT user_id FROM users WHERE name = @name", new SqlParameter("@name", P_Str_Name)))
        {
            throw new DuplicateNameException("该用户名已经存在，请换一个用户名重新注册");
        }
        else
        {
            int user_id = DBClass.ExecuteScalar("Insert users(name,sex,password,true_name,phone,email,address) values(@Name,@Sex,@Password,@True_name,@Phone,@Email,@Address);select @@identity;",
            new SqlParameter("@Name", P_Str_Name), new SqlParameter("@sex", P_Bl_Sex),
            new SqlParameter("@Password", P_Str_Password),
            new SqlParameter("@True_name", P_Str_TrueName),
            new SqlParameter("@Phone", P_Str_Phonecode),
            new SqlParameter("@Email", P_Str_Emails),
            new SqlParameter("@Address", P_Str_Address));

            int order_id = DBClass.ExecuteScalar("insert into orders (name, user_id, status) values ('cart', @user_id, 0); select @@identity", new SqlParameter("@user_id", user_id));
            DBClass.ExecuteCommand("insert into carts (order_id, user_id) values (@order_id, @user_id)", new SqlParameter("@order_id", order_id), new SqlParameter("@user_id", user_id));
            return user_id;
        }
    }
    /// <summary>
    /// 修改会员充值
    /// </summary>
    /// <param name="UserId">会员ID</param>
    /// <param name="P_Flt_AdvancePayment">充值金额</param>
    public void UpdateAP(int UserId, float P_Flt_AdvancePayment)
    {
        DataTable ds = DBClass.GetDataTable("set @OldPayment=(select AdvancePayment from users where MemberID=@MemberID);update tb_Member set AdvancePayment=(@AdvancePayment+@OldPayment) where MemberID=@MemberID", 
            new SqlParameter("@MemberID", UserId),
            new SqlParameter("@AdvancePayment", P_Flt_AdvancePayment));
    }

    //********************************更新用户信息*************************************************
    /// <summary>
    /// 获取会员信息
    /// </summary>
    /// <param name="UserId">会员编号</param>
    /// <param name="P_Str_srcTable">表的信息</param>
    /// <returns></returns>
    public DataTable ReturnUIDsByID(int UserId)
    {
        return DBClass.GetDataTable("select user_id, name, sex, password, true_name, phone, email, address, city from users where user_id=@user_id", new SqlParameter("@user_id", UserId));
    }
    /// <summary>
    /// 修改会员表中的信息
    /// </summary>
    /// <param name="P_Str_Name">会员名</param>
    /// <param name="P_Bl_Sex">性别</param>
    /// <param name="P_Str_Password">密码</param>
    /// <param name="P_Str_TrueName">真实姓名</param>
    /// <param name="P_Str_Questions">找回密码问题</param>
    /// <param name="P_Str_Answers">找回密码答案</param>
    /// <param name="P_Str_Phonecode">电话号码</param>
    /// <param name="P_Str_Emails">E_Mail</param>
    /// <param name="P_Str_City">会员所在城市</param>
    /// <param name="P_Str_Address">会员详细地址</param>
    /// <param name="P_Str_PostCode">邮编</param>
    /// <param name="P_Flt_AdvancePayment">预付金额</param>
    /// <param name="P_Date_LoadDate">登录日期</param>
    public void  UpdateUInfo(bool P_Bl_Sex, string P_Str_Password, string P_Str_TrueName, string P_Str_Questions, string P_Str_Answers, string P_Str_Phonecode, string P_Str_Emails, string P_Str_City, string P_Str_Address,int UserId)
    {
        DBClass.ExecuteCommand("update users set sex=@sex, password=@password, phone=@phone, email=@email,address=@address, city=@city, true_name=@true_name where user_id=@user_id",
            new SqlParameter("@sex", P_Bl_Sex),
            new SqlParameter("@password", P_Str_Password),
            new SqlParameter("@phone", P_Str_Phonecode), 
            new SqlParameter("@email", P_Str_Emails),
            new SqlParameter("@address", P_Str_Address),
            new SqlParameter("@user_id", UserId),
            new SqlParameter("@city", P_Str_City),
            new SqlParameter("@true_name", P_Str_TrueName));
    }
    //**********************************************************************************
    /// <summary>
    /// 商品功能菜单导航
    /// </summary>
    /// <param name="dlName">商品类别信息</param>
    public void DLClassBind(DataList  dlName)
    {
        DataTable ds = DBClass.GetDataTable("select * from categories where parent_id is null");
        dlName.DataSource = ds.DefaultView;
        dlName.DataBind();
    }

  /// <summary>
  /// 绑定商品信息(精品　热销商品 打折商品)
  /// </summary>
  /// <param name="P_Int_Deplay">(精品　热销商品 打折商品)三种类别的标志</param>
  /// <param name="P_Str_srcTable">表信息</param>
  /// <param name="DLName">绑定控件名</param>
    public void DGIBind(int P_Int_Deplay,DataList DLName)
    {
        String stat = null;
        switch (P_Int_Deplay) 
        {
            case 0:
                stat = "is_rush_buy";
                break;
            case 1:
                stat = "is_group_buy";
                break;
            case 2:
                stat = "is_discount";
                break;
            default:
                throw(new Exception("Error Deplay"));
        }
        DataTable ds = DBClass.GetDataTable("select top 4 * from items where " + stat + " = 1");
        DLName.DataSource = ds.DefaultView;
        DLName.DataBind();
    }

    public DataTable DGIBind(int P_Int_Deplay)
    {
        String stat = null;
        switch (P_Int_Deplay)
        {
            case 0:
                stat = "is_rush_buy";
                break;
            case 1:
                stat = "is_group_buy";
                break;
            case 2:
                stat = "is_discount";
                break;
            default:
                throw (new Exception("Error Deplay"));
        }
        return DBClass.GetDataTable("select top 4 * from items where " + stat + " = 1");
    }
    /// <summary>
    /// 以商品类别分类绑定商品信息
    /// </summary>
    /// <param name="P_Int_ClassID">商品类别编号</param>
    /// <param name="P_Str_srcTable">表信息</param>
    /// <param name="DLName">绑定控件名</param>
    public void DCGIBind(int P_Int_ClassID, DataList DLName)
    {
        DataTable ds = DBClass.GetDataTable("select * from items where cat_id = @cat_id",
            new SqlParameter("@cat_id", P_Int_ClassID));
        DLName.DataSource = ds.DefaultView;
        DLName.DataBind();
    }
    //**************************购物车**********************************************************
    /// <summary>
    /// 向购物车中添加信息
    /// </summary>
    /// <param name="P_Int_GoodsID">商品编号</param>
    /// <param name="P_Flt_MemberPrice">会员价格</param>
    /// <param name="UserId">会员编号</param>
    public void AddShopCart(int P_Int_GoodsID, float P_Flt_MemberPrice, int UserId, float P_Flt_GoodsWeight)
    {
        int OrderId = DBClass.ExecuteScalar("select order_id from carts where user_id = @user_id",
            new SqlParameter("@user_id", UserId));
        int OrderItemId = -1;
        try
        {
            OrderItemId = DBClass.ExecuteScalar("select order_items.order_item_id from order_items where order_id = @order_id and item_id = @item_id",
             new SqlParameter("@order_id", OrderId), new SqlParameter("@item_id", P_Int_GoodsID));
            DBClass.ExecuteCommand("update order_items set count = count + 1 where order_item_id = @order_item_id", new SqlParameter("@order_item_id", OrderItemId));
        }
        catch (RecordNotExisted)
        {
            DBClass.ExecuteCommand("insert into order_items (item_id, order_id, count, price) select item_id, @order_id, 1, price from items where item_id = @item_id",
                new SqlParameter("@order_id", OrderId), new SqlParameter("@item_id", P_Int_GoodsID));
        }
    }
    /// <summary>
    /// 显示购物车中的信息
    /// </summary>
    /// <param name="P_Str_srcTable">信息表名</param>
    /// <param name="gvName">控件名</param>
    /// <param name="UserId">会员编号</param>
    public void SCIBind(GridView  gvName, int UserId)
    {
        DataTable ds = DBClass.GetDataTable(
            "select order_items.order_item_id, items.name, order_items.price, order_items.count, order_items.price * order_items.count as sum_price, carts.user_id, order_items.item_id from " +
            "carts join order_items on carts.order_id = order_items.order_id join items on order_items.item_id = items.item_id where carts.user_id = @user_id", 
            new SqlParameter("@user_id", UserId));
        gvName.DataSource = ds.DefaultView;
        gvName.DataBind();
    }

    public void OrderTabBind(GridView ItemData, int UserId, int OrderId)
    {
        DataTable ds = DBClass.GetDataTable(
            "SELECT order_items.order_item_id, items.name, order_items.price, order_items.count, order_items.price * order_items.count AS sum_price, orders.user_id, order_items.item_id FROM " +
            "orders JOIN order_items ON orders.order_id = order_items.order_id JOIN items ON order_items.item_id = items.item_id WHERE orders.user_id = @user_id AND orders.order_id = @order_id",
            new SqlParameter("@user_id", UserId),
            new SqlParameter("@order_id", OrderId));
        ItemData.DataSource = ds.DefaultView;
        ItemData.DataBind();
    }
    /// <summary>
    /// 返回合计总数的Ds
    /// </summary>
    /// <param name="P_Str_srcTable">信息表名</param>
    /// <param name="UserId">员工编号</param>
    /// <returns>返回合计总数的Ds</returns>
    public DataTable ReturnTotalDs(int UserId)
    {
        return DBClass.GetDataTable(
            "select Sum(order_items.price), Sum(order_items.count) from carts " + 
            "join order_items " +
            "on order_items.order_id = carts.order_id " +
            "where carts.user_id = @user_id", new SqlParameter("@user_id", UserId));
    }
    /// <summary>
    /// 删除购物车中的信息
    /// </summary>
    /// <param name="UserId">会员编号</param>
    public void ClearShopCart(int UserId)
    {
        int order_id = DBClass.ExecuteScalar("select order_id from carts where user_id = @user_id", new SqlParameter("@user_id", UserId));
        DBClass.ExecuteCommand("delete from order_items where order_id = @order_id", new SqlParameter("@order_id", order_id));
    }
    /// <summary>
    ///  删除指定购物车中的信息
    /// </summary>
    /// <param name="UserId">会员编号</param>
    /// <param name="CartId">商品编号</param>
    public void RemoveOrderItemByID(int UserId,int CartId)
    {
        DBClass.ExecuteCommand(
            "delete from order_items where order_item_id = @order_item_id",
            new SqlParameter("@order_item_id", CartId));

    }
    /// <summary>
    /// 当购物车中商品数量改变时，修改购物车中的信息
    /// </summary>
    /// <param name="UserId">会员ID号</param>
    /// <param name="CartId">商品编号</param>
    /// <param name="Num">商品数量</param>
    public void UpdateItemOrder(int UserId, int CartId, int Num)
    {
        DBClass.ExecuteCommand("update order_items set count = @count where order_item_id = @order_item_id",
            new SqlParameter("@count", Num),
            new SqlParameter("@order_item_id", CartId));
    }
    //*********************************结账********************************************************

    public int AddOrderInfo(int UserId, string TrueName, string Mobile, string Address, string Email)
    {
        // 获取购物车
        DataTable order = DBClass.GetDataTable(
            "select order_id, cart_id from carts where carts.user_id = @user_id",
            new SqlParameter("@user_id", UserId));

        // 创建新订单
        int newOrderId = DBClass.ExecuteScalar(
            "insert orders " +
            "(user_id, status) " +
            "values (@user_id, 0) " +
            "select @@identity",
            new SqlParameter("@user_id", UserId));

        // 设定购物车指向新的订单
        // 订单状态, 0: 购物车状态, 1:审核状态, 2: 审核完/等待出货， 3：出货状态， 4：收货状态, 5: 退货状态
        DBClass.ExecuteCommand(
            "update carts " + 
            "set order_id = @order_id " + 
            "where cart_id = @cart_id",
            new SqlParameter("@order_id", newOrderId),
            new SqlParameter("@cart_id", getInt32(order, "order", 0, 1)));

        // 设定原订单状态，脱离购物车，成为单独一个订单
        DBClass.ExecuteCommand(
            "update orders set status = 1, address = @address, phone = @phone, name = @name where order_id = @order_id",
            new SqlParameter("@address", Address),
            new SqlParameter("@phone", Mobile),
            new SqlParameter("@name", TrueName),
            new SqlParameter("@order_id", getInt32(order, "order", 0, 0)));

        //修改商品数量
        DBClass.ExecuteCommand("UPDATE items SET items.quota = items.quota - order_items.count, items.sell_count = items.sell_count + order_items.count FROM orders JOIN order_items ON order_items.order_id = orders.order_id JOIN items ON order_items.item_id = items.item_id WHERE orders.order_id = @order_id", 
            new SqlParameter("@order_id", getInt32(order, "order", 0, 0)));
        return getInt32(order, "order", 0, 0);
    }

    public void  AddBuyInfo(int P_Int_GoodsID, int Num, int P_Int_OrderID, float  P_Flt_SumPrice, int UserId)
    {
        DBClass.ExecuteCommand("insert into tb_BuyInfo(GoodsID,Num,OrderID,SumPrice, MemberID) values (@GoodsID,@Num,@OrderID,@SumPrice, @MemberID)",
            new SqlParameter("@GoodsID", P_Int_GoodsID), new SqlParameter("@Num", Num),
            new SqlParameter("@OrderID", P_Int_OrderID), new SqlParameter("@SumPrice", P_Flt_SumPrice),
            new SqlParameter("@MemberID", UserId));
    }
    /// <summary>
    /// 查询购物车中的信息
    /// </summary>
    /// <param name="UserId">会员ID</param>
    /// <param name="P_Str_srcTable">信息表</param>
    /// <returns>返回购物车中的信息的数据集</returns>
    public DataTable ReturnSCDs(int UserId)
    {
        return DBClass.GetDataTable("select * from cart where MemberID=@MemberID", new SqlParameter("@MemberID", UserId));
    }
    /// <summary>
    /// 当购物车中的信息已生成订单后，删除购物车中的信息
    /// </summary>
    /// <param name="UserId">会员ID</param>
    public void DeleteSCInfo(int UserId)
    {
        DBClass.GetDataTable("delete from tb_ShopCart where MemberID=@MemberID", null, new SqlParameter("@MemberID", UserId));
    }
   /// <summary>
   ///　获取运输费用
   /// </summary>
   /// <param name="P_Int_GoodsID">商品ID</param>
   /// <param name="P_Str_ShipWay">运输方式</param>
    /// <returns>返回运输费用</returns>
    public float  GetSFValue(int P_Int_GoodsID,string P_Str_ShipWay)
    {
        DataTable ds = DBClass.GetDataTable("select ShipFee from tb_ShipType where shipWay=@shipWay and ClassID=(select ClassID from tb_GoodsInfo where GoodsID=@GoodsID)",
            new SqlParameter("@GoodsID", P_Int_GoodsID),
            new SqlParameter("@ShipWay", P_Str_ShipWay));
        if (ds.Rows.Count > 0)
        {
            return Convert.ToInt32(ds.Rows[0][0].ToString());
        }
        else
        {
            return 100;
        }
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

    public void SearchBind(DataList searchResult, string searchStr)
    {
        DataTable ds = DBClass.GetDataTable(
            "SELECT [item_id], [name], [price], [description], [image_url], [quota], [sell_count], [is_discount], [is_group_buy], [is_rush_buy] FROM [items] WHERE name LIKE '%' + CONVERT(NVARCHAR(50),@keywords) + '%' OR " +
            "description LIKE '%' +  CONVERT(NVARCHAR(50),@keywords) + '%'",
            new SqlParameter("@keywords", searchStr));
        int c = ds.Rows.Count;
        searchResult.DataSource = ds.DefaultView;
        searchResult.DataBind();
    }

    public DataTable SearchBind(string searchStr)
    {
        return DBClass.GetDataTable(
            "SELECT [item_id], [name], [price], [description], [image_url], [quota], [sell_count], [is_discount], [is_group_buy], [is_rush_buy] FROM [items] WHERE name LIKE '%' + CONVERT(NVARCHAR(50),@keywords) + '%' OR " +
            "description LIKE '%' +  CONVERT(NVARCHAR(50),@keywords) + '%'",
            new SqlParameter("@keywords", searchStr));
    }

    public void OrderBind(Repeater OrderList, int UserId)
    {
        DataTable ds = DBClass.GetDataTable(
            "SELECT orders.order_id, orders.create_at, orders.status, orders.name, orders.finish_at, (SELECT Sum(price*count) FROM order_items WHERE order_id = orders.order_id) AS total_price," +
            " orders.address FROM orders LEFT JOIN carts ON orders.order_id = carts.order_id WHERE orders.user_id = @user_id AND carts.cart_id IS NULL",
            new SqlParameter("@user_id", UserId));
        int c = ds.Rows.Count;
        OrderList.DataSource = ds.DefaultView;
        OrderList.DataBind();
    }


    // 如果该订单为发货状态，将状态改为收货状态
    // 行为Action
    // 0：修改为收货状态； 1：修改为退货状态
    public void OrderChangeStatus(int OrderID, int Action)
    {
        int[,] statHash = new int[,]{{2, 3, 4}, {3, 4, 5}}; //从状态2 -- 3, 3 --> 4 , 4 --> 5
        DataTable ds = DBClass.GetDataTable(
            "SELECT status FROM orders WHERE order_id = @order_id",
            new SqlParameter("@order_id", OrderID)
            );
        int status = Convert.ToInt32(ds.Rows[0][0].ToString());
        if (status != statHash[0,Action])
        {
            throw new Exception("无法改变订单状态，不满足改变订单状态条件");
        }
        else
        {
            // 状态3 为发货状态，状态4 为收货状态
            DBClass.ExecuteCommand("UPDATE orders SET status = " + statHash[1,Action] + " WHERE order_id = @order_id", new SqlParameter("@order_id", OrderID));
        }
    }

    public DataTable GetComment(int ItemID)
    {
        return DBClass.GetDataTable("SELECT users.name AS name, comments.* FROM comments JOIN users ON users.user_id = comments.user_id WHERE item_id = @item_id",
            new SqlParameter("@item_id", ItemID));
    }

    public bool HasRightComment(int UserId, int ItemId)
    {
        if (DBClass.IsExisted("SELECT * FROM order_items JOIN orders ON orders.order_id = order_items.order_id WHERE order_items.item_id = @item_id AND orders.user_id = @user_id",
                new SqlParameter("@item_id", ItemId), new SqlParameter("@user_id", UserId)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private int getInt32(DataTable ds, String tableName, int x, int y)
    {
        return Convert.ToInt32(ds.Rows[x][y].ToString());
    }
}
