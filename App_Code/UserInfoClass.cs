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
        StringBuilder cmd = new StringBuilder();
        cmd.AppendFormat("SELECT * FROM users WHERE Name='{0}' and Password='{1}'", P_Str_Name, P_Str_Password);
        DataSet ds = dbObj.GetDataSet(cmd.ToString(), "users");
        int hasUser = ds.Tables["users"].Rows.Count;
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
    public DataSet ReturnUIDs(string P_Str_Name, string P_Str_Password,string P_Str_srcTable)
    {
        StringBuilder cmd = new StringBuilder();
        cmd.AppendFormat("SELECT * FROM users WHERE Name='{0}' and Password='{1}'", P_Str_Name, P_Str_Password);
        return dbObj.GetDataSet(cmd.ToString(), P_Str_srcTable);
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
    public int AddUInfo(string P_Str_Name, bool P_Bl_Sex, string P_Str_Password, string P_Str_TrueName, string P_Str_Questions, string P_Str_Answers, string P_Str_Phonecode, string P_Str_Emails, string P_Str_City, string P_Str_Address, string P_Str_PostCode)
    {
        DataSet ds = dbObj.GetDataSet("Insert users(Name,Sex,Password,TrueName,Questions,Answers,Phonecode,Emails,City,Address,PostCode) values(@Name,@Sex,@Password,@TrueName,@Questions,@Answers,@Phonecode,@Emails,@City,@Address,@PostCode);select @@identity;", "id",
            new SqlParameter("@Name", P_Str_Name), new SqlParameter("@sex", P_Bl_Sex),
            new SqlParameter("@Password", P_Str_Password), new SqlParameter("@TrueName", P_Str_TrueName),
            new SqlParameter("@Questions", P_Str_Questions), new SqlParameter("@Answers", P_Str_Answers),
            new SqlParameter("@Phonecode", P_Str_Phonecode), new SqlParameter("@Emails", P_Str_Emails),
            new SqlParameter("@City", P_Str_City), new SqlParameter("@Address", P_Str_Address),
            new SqlParameter("@PostCode", P_Str_PostCode));
        return Convert.ToInt32(ds.Tables["id"].Rows[0][0].ToString());
    }
    /// <summary>
    /// 修改会员充值
    /// </summary>
    /// <param name="P_Int_MemberID">会员ID</param>
    /// <param name="P_Flt_AdvancePayment">充值金额</param>
    public void UpdateAP(int P_Int_MemberID, float P_Flt_AdvancePayment)
    {
        DataSet ds = dbObj.GetDataSet("set @OldPayment=(select AdvancePayment from users where MemberID=@MemberID);update tb_Member set AdvancePayment=(@AdvancePayment+@OldPayment) where MemberID=@MemberID", 
            "return", new SqlParameter("@MemberID", P_Int_MemberID),
            new SqlParameter("@AdvancePayment", P_Flt_AdvancePayment));
    }
    //********************************更新用户信息*************************************************
    /// <summary>
    /// 获取会员信息
    /// </summary>
    /// <param name="P_Int_MemberID">会员编号</param>
    /// <param name="P_Str_srcTable">表的信息</param>
    /// <returns></returns>
    public DataSet ReturnUIDsByID(int P_Int_MemberID, string P_Str_srcTable)
    {
        return dbObj.GetDataSet("select * from users where MemberID=@MemberID", P_Str_srcTable, new SqlParameter("@MemberID", P_Int_MemberID));
        //SqlConnection myConn = dbObj.GetConnection();
        //SqlCommand myCmd = new SqlCommand("Proc_GetUIByID", myConn);
        //myCmd.CommandType = CommandType.StoredProcedure;
        ////添加参数
        //SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.BigInt, 8);
        //MemberID.Value = P_Int_MemberID;
        //myCmd.Parameters.Add(MemberID);
        ////执行过程
        //myConn.Open();
        //try
        //{
        //    myCmd.ExecuteNonQuery();

        //}
        //catch (Exception ex)
        //{
        //    throw (ex);
        //}
        //finally
        //{
        //    myCmd.Dispose();
        //    myConn.Close();

        //}
        //SqlDataAdapter da = new SqlDataAdapter(myCmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds, P_Str_srcTable);
        //return ds;
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
    public void  UpdateUInfo(string P_Str_Name, bool P_Bl_Sex, string P_Str_Password, string P_Str_TrueName, string P_Str_Questions, string P_Str_Answers, string P_Str_Phonecode, string P_Str_Emails, string P_Str_City, string P_Str_Address, string P_Str_PostCode,int P_Int_MemberID)
    {
        dbObj.GetDataSet("update users set Name=@Name, Sex=@Sex, Password=@Password, TrueName=@TrueName, Questions=@Questions, Answers=@Answers, Phonecode=@Phonecode, Emails=@Emails,City=@City,Address=@Address,PostCode=@PostCode where MemberID=@MemberID", "return",
            new SqlParameter("@Name", P_Str_Name), new SqlParameter("@Sex", P_Bl_Sex),
            new SqlParameter("@Password", P_Str_Password), new SqlParameter("@TrueName", P_Str_TrueName),
            new SqlParameter("@Questions", P_Str_Questions), new SqlParameter("@Answers", P_Str_Answers),
            new SqlParameter("@Phonecode", P_Str_Phonecode), new SqlParameter("@Emails", P_Str_Emails),
            new SqlParameter("@City", P_Str_City), new SqlParameter("@Address", P_Str_Address),
            new SqlParameter("@PostCode", P_Str_PostCode), new SqlParameter("@MemberID", P_Int_MemberID));
    }
    //**********************************************************************************
    /// <summary>
    /// 商品功能菜单导航
    /// </summary>
    /// <param name="dlName">商品类别信息</param>
    public void DLClassBind(DataList  dlName)
    {
        string P_Str_SqlStr = "select * from tb_Class";
        SqlConnection myConn = dbObj.GetConnection();
        SqlDataAdapter da = new SqlDataAdapter(P_Str_SqlStr, myConn);
        DataSet ds = new DataSet();
        da.Fill(ds, "Class");
        dlName.DataSource = ds.Tables["Class"].DefaultView;
        dlName.DataBind();
    }

  /// <summary>
  /// 绑定商品信息(精品　热销商品 打折商品)
  /// </summary>
  /// <param name="P_Int_Deplay">(精品　热销商品 打折商品)三种类别的标志</param>
  /// <param name="P_Str_srcTable">表信息</param>
  /// <param name="DLName">绑定控件名</param>
    public void DGIBind(int P_Int_Deplay, string P_Str_srcTable,DataList DLName)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeplayGInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter Deplay = new SqlParameter("@Deplay", SqlDbType.Int, 4);
        Deplay.Value = P_Int_Deplay;
        myCmd.Parameters.Add(Deplay);
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
        DLName.DataSource = ds.Tables[P_Str_srcTable].DefaultView;
        DLName.DataBind();
    
    }
    /// <summary>
    /// 以商品类别分类绑定商品信息
    /// </summary>
    /// <param name="P_Int_ClassID">商品类别编号</param>
    /// <param name="P_Str_srcTable">表信息</param>
    /// <param name="DLName">绑定控件名</param>
    public void DCGIBind(int P_Int_ClassID, string P_Str_srcTable, DataList DLName)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeplayGIByC", myConn);
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
        SqlDataAdapter da = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        da.Fill(ds, P_Str_srcTable);
        DLName.DataSource = ds.Tables[P_Str_srcTable].DefaultView;
        DLName.DataBind();

    }
    //**************************购物车**********************************************************
    /// <summary>
    /// 向购物车中添加信息
    /// </summary>
    /// <param name="P_Int_GoodsID">商品编号</param>
    /// <param name="P_Flt_MemberPrice">会员价格</param>
    /// <param name="P_Int_MemberID">会员编号</param>
    public void AddShopCart(int P_Int_GoodsID, float P_Flt_MemberPrice, int P_Int_MemberID, float P_Flt_GoodsWeight)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_InsertShopCart", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter GoodsID = new SqlParameter("@GoodsID", SqlDbType.BigInt, 8);
        GoodsID.Value = P_Int_GoodsID;
        myCmd.Parameters.Add(GoodsID);
        //添加参数
        SqlParameter MemberPrice = new SqlParameter("@MemberPrice", SqlDbType.Float, 8);
        MemberPrice.Value = P_Flt_MemberPrice;
        myCmd.Parameters.Add(MemberPrice);
        //添加参数
        SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.BigInt, 8);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);
        //添加参数
        SqlParameter GoodsWeight = new SqlParameter("@GoodsWeight", SqlDbType.Float , 8);
        GoodsWeight.Value = P_Flt_GoodsWeight;
        myCmd.Parameters.Add(GoodsWeight);
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
    /// 显示购物车中的信息
    /// </summary>
    /// <param name="P_Str_srcTable">信息表名</param>
    /// <param name="gvName">控件名</param>
    /// <param name="P_Int_MemberID">会员编号</param>
    public void SCIBind(string P_Str_srcTable, GridView  gvName, int P_Int_MemberID)
    {
        //SqlConnection myConn = dbObj.GetConnection();
        //SqlCommand myCmd = new SqlCommand("Proc_GetShopCart", myConn);
        //myCmd.CommandType = CommandType.StoredProcedure;
        ////添加参数
        //SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.BigInt, 8);
        //MemberID.Value = P_Int_MemberID;
        //myCmd.Parameters.Add(MemberID);
        ////执行过程
        //myConn.Open();
        //try
        //{
        //    myCmd.ExecuteNonQuery();

        //}
        //catch (Exception ex)
        //{
        //    throw (ex);
        //}
        //finally
        //{
        //    myCmd.Dispose();
        //    myConn.Close();

        //}
        //SqlDataAdapter da = new SqlDataAdapter(myCmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds, P_Str_srcTable);
        //gvName.DataSource = ds.Tables[P_Str_srcTable].DefaultView;
        //gvName.DataBind();
        DataSet ds = dbObj.GetDataSet("select CartID,GoodsName,MarketPrice,MemberPrice,Num,SumPrice,MemberID from tb_ShopCart b,tb_GoodsInfo i where b.GoodsID=i.GoodsID and MemberID=@MemberID", P_Str_srcTable,
            new SqlParameter("@MemberID", P_Int_MemberID));
        gvName.DataSource = ds.Tables[P_Str_srcTable].DefaultView;
        gvName.DataBind();
    }
    /// <summary>
    /// 返回合计总数的Ds
    /// </summary>
    /// <param name="P_Str_srcTable">信息表名</param>
    /// <param name="P_Int_MemberID">员工编号</param>
    /// <returns>返回合计总数的Ds</returns>
    public DataSet ReturnTotalDs(int P_Int_MemberID,string P_Str_srcTable)
    {
        return dbObj.GetDataSet("select Sum(SumPrice),Sum(GoodsWeight),Sum(Num) from tb_ShopCart where MemberID=@MemberID", P_Str_srcTable, new SqlParameter("@MemberID", P_Int_MemberID));
        //SqlConnection myConn = dbObj.GetConnection();
        //SqlCommand myCmd = new SqlCommand("Proc_TotalInfo", myConn);
        //myCmd.CommandType = CommandType.StoredProcedure;
        ////添加参数
        //SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.BigInt, 8);
        //MemberID.Value = P_Int_MemberID;
        //myCmd.Parameters.Add(MemberID);
        ////执行过程
        //myConn.Open();
        //try
        //{
        //    myCmd.ExecuteNonQuery();

        //}
        //catch (Exception ex)
        //{
        //    throw (ex);
        //}
        //finally
        //{
        //    myCmd.Dispose();
        //    myConn.Close();

        //}
        //SqlDataAdapter da = new SqlDataAdapter(myCmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds, P_Str_srcTable);
        //return ds;
         
    }
    /// <summary>
    /// 删除购物车中的信息
    /// </summary>
    /// <param name="P_Int_MemberID">会员编号</param>
    public void DeleteShopCart(int P_Int_MemberID)
    {
        dbObj.GetDataSet("delete from tb_ShopCart where MemberID=@MemberID", "return", new SqlParameter("@MemberID", P_Int_MemberID));
        //SqlConnection myConn = dbObj.GetConnection();
        //SqlCommand myCmd = new SqlCommand("Proc_DeleteShopCart", myConn);
        //myCmd.CommandType = CommandType.StoredProcedure;
        ////添加参数
        //SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.BigInt, 8);
        //MemberID.Value = P_Int_MemberID;
        //myCmd.Parameters.Add(MemberID);
        ////执行过程
        //myConn.Open();
        //try
        //{
        //    myCmd.ExecuteNonQuery();

        //}
        //catch (Exception ex)
        //{
        //    throw (ex);
        //}
        //finally
        //{
        //    myCmd.Dispose();
        //    myConn.Close();

        //}
    }
    /// <summary>
    ///  删除指定购物车中的信息
    /// </summary>
    /// <param name="P_Int_MemberID">会员编号</param>
    /// <param name="P_Int_CartID">商品编号</param>
    public void DeleteShopCartByID(int P_Int_MemberID,int P_Int_CartID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeleteSCByID", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.BigInt, 8);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);
        //添加参数
        SqlParameter CartID = new SqlParameter("@CartID", SqlDbType.BigInt, 8);
        CartID.Value = P_Int_CartID;
        myCmd.Parameters.Add(CartID);
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
    /// 当购物车中商品数量改变时，修改购物车中的信息
    /// </summary>
    /// <param name="P_Int_MemberID">会员ID号</param>
    /// <param name="P_Int_CartID">商品编号</param>
    /// <param name="P_Int_Num">商品数量</param>
    public void UpdateSCI(int P_Int_MemberID, int P_Int_CartID, int P_Int_Num)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_UpdateSC", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.BigInt, 8);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);
        //添加参数
        SqlParameter CartID = new SqlParameter("@CartID", SqlDbType.BigInt, 8);
        CartID.Value = P_Int_CartID;
        myCmd.Parameters.Add(CartID);
        //添加参数
        SqlParameter Num = new SqlParameter("@Num", SqlDbType.BigInt, 8);
        Num.Value = P_Int_Num;
        myCmd.Parameters.Add(Num);
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
    //*********************************结账********************************************************
    public void ddlCityBind(DropDownList ddlName)
    {
     SqlConnection myConn=dbObj.GetConnection();
     string P_Str_Sqlstr="select * from tb_Area";
     SqlDataAdapter da = new SqlDataAdapter(P_Str_Sqlstr, myConn);
     DataSet ds = new DataSet();
     da.Fill(ds,"Area");
     ddlName.DataSource = ds.Tables["Area"].DefaultView;
     ddlName.DataTextField = ds.Tables["Area"].Columns[1].ToString();
     ddlName.DataValueField = ds.Tables["Area"].Columns[2].ToString();
     ddlName.DataBind();
    
    }
    public void ddlShipBind(DropDownList ddlName)
    {
        SqlConnection myConn = dbObj.GetConnection();
        string P_Str_Sqlstr = "select * from tb_ShipType";
        SqlDataAdapter da = new SqlDataAdapter(P_Str_Sqlstr, myConn);
        DataSet ds = new DataSet();
        da.Fill(ds, "Ship");
        ddlName.DataSource = ds.Tables["Ship"].DefaultView;
        ddlName.DataTextField = ds.Tables["Ship"].Columns[1].ToString();
        ddlName.DataValueField = ds.Tables["Ship"].Columns[0].ToString();
        ddlName.DataBind();  
    }
    public void ddlPayBind(DropDownList ddlName)
    {
        SqlConnection myConn = dbObj.GetConnection();
        string P_Str_Sqlstr = "select * from tb_PayType";
        SqlDataAdapter da = new SqlDataAdapter(P_Str_Sqlstr, myConn);
        DataSet ds = new DataSet();
        da.Fill(ds, "Pay");
        ddlName.DataSource = ds.Tables["Pay"].DefaultView;
        ddlName.DataTextField = ds.Tables["Pay"].Columns[1].ToString();
        ddlName.DataValueField = ds.Tables["Pay"].Columns[0].ToString();
        ddlName.DataBind();   
    }
    public int AddOrderInfo(float P_Flt_GoodsFee, float P_Flt_ShipFee, int P_Int_ShipType, int P_Int_PayType, int P_Int_MemberID, string P_Str_RName, string P_Str_RPhone, string P_Str_RPostCode, string P_Str_RAddress, string P_Str_REmails)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_InsertOrderInfo", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;

        //添加参数
        SqlParameter GoodsFee = new SqlParameter("@GoodsFee", SqlDbType.Float, 8);
        GoodsFee.Value = P_Flt_GoodsFee;
        myCmd.Parameters.Add(GoodsFee);
        //添加参数
        SqlParameter ShipFee = new SqlParameter("@ShipFee", SqlDbType.Float , 8);
        ShipFee.Value = P_Flt_ShipFee;
        myCmd.Parameters.Add(ShipFee);
        //添加参数
        SqlParameter ShipType = new SqlParameter("@ShipType", SqlDbType.Int,4);
        ShipType.Value = P_Int_ShipType;
        myCmd.Parameters.Add(ShipType);
        //添加参数
        SqlParameter PayType = new SqlParameter("@PayType", SqlDbType.Int, 4);
        PayType.Value = P_Int_PayType;
        myCmd.Parameters.Add(PayType);
        //添加参数
        SqlParameter MemberID = new SqlParameter("@MemberID ", SqlDbType.BigInt,8);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);
        //添加参数
        SqlParameter RName = new SqlParameter("@RName", SqlDbType.VarChar, 50);
        RName.Value = P_Str_RName;
        myCmd.Parameters.Add(RName);
        //添加参数
        SqlParameter RPhone = new SqlParameter("@RPhone", SqlDbType.VarChar, 50);
        RPhone.Value = P_Str_RPhone;
        myCmd.Parameters.Add(RPhone);
        //添加参数
        SqlParameter RPostCode = new SqlParameter("@RPostCode", SqlDbType.Char, 10);
        RPostCode.Value = P_Str_RPostCode;
        myCmd.Parameters.Add(RPostCode);
        //添加参数
        SqlParameter RAddress = new SqlParameter("@RAddress", SqlDbType.VarChar, 200);
        RAddress.Value = P_Str_RAddress;
        myCmd.Parameters.Add(RAddress);
        
        //添加参数
        SqlParameter REmails = new SqlParameter("@REmails", SqlDbType.VarChar, 50);
        REmails.Value = P_Str_REmails;
        myCmd.Parameters.Add(REmails);
        //添加参数
        SqlParameter OrderID = myCmd.Parameters.Add("@OrderID", SqlDbType.BigInt,8);
        OrderID.Direction = ParameterDirection.Output;
       
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
        return Convert.ToInt32(OrderID.Value);
      

    }
    public void  AddBuyInfo(int P_Int_GoodsID, int P_Int_Num, int P_Int_OrderID, float  P_Flt_SumPrice, int P_Int_MemberID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_InsertBuy", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter GoodsID = new SqlParameter("@GoodsID", SqlDbType.BigInt, 4);
        GoodsID.Value = P_Int_GoodsID;
        myCmd.Parameters.Add(GoodsID);
        //添加参数
        SqlParameter Num = new SqlParameter("@Num", SqlDbType.Int, 4);
        Num.Value = P_Int_Num;
        myCmd.Parameters.Add(Num);
        //添加参数
        SqlParameter OrderID = new SqlParameter("@OrderID", SqlDbType.BigInt, 8);
        OrderID.Value = P_Int_OrderID;
        myCmd.Parameters.Add(OrderID);
        //添加参数
        SqlParameter SumPrice = new SqlParameter("@SumPrice", SqlDbType.Float , 8);
        SumPrice.Value = P_Flt_SumPrice;
        myCmd.Parameters.Add(SumPrice);
        //添加参数
        SqlParameter MemberID = new SqlParameter("@MemberID ", SqlDbType.BigInt, 8);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);
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
    /// 查询购物车中的信息
    /// </summary>
    /// <param name="P_Int_MemberID">会员ID</param>
    /// <param name="P_Str_srcTable">信息表</param>
    /// <returns>返回购物车中的信息的数据集</returns>
    public DataSet ReturnSCDs(int P_Int_MemberID, string P_Str_srcTable)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GetSCI", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.BigInt, 8);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);
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
    /// 当购物车中的信息已生成订单后，删除购物车中的信息
    /// </summary>
    /// <param name="P_Int_MemberID">会员ID</param>
    public void DeleteSCInfo(int P_Int_MemberID)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_DeleteSC", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.BigInt, 8);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);
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
   ///　获取运输费用
   /// </summary>
   /// <param name="P_Int_GoodsID">商品ID</param>
   /// <param name="P_Str_ShipWay">运输方式</param>
    /// <returns>返回运输费用</returns>
    public float  GetSFValue(int P_Int_GoodsID,string P_Str_ShipWay)
    {


        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_GSF", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter GoodsID = new SqlParameter("@GoodsID", SqlDbType.BigInt, 8);
        GoodsID.Value = P_Int_GoodsID;
        myCmd.Parameters.Add(GoodsID);
        //添加参数
        SqlParameter ShipWay = new SqlParameter("@ShipWay", SqlDbType.VarChar,50);
        ShipWay.Value = P_Str_ShipWay;
        myCmd.Parameters.Add(ShipWay);
        //添加参数
        SqlParameter returnValue = myCmd.Parameters.Add("returnvalue", SqlDbType.Float, 8);
        returnValue.Direction = ParameterDirection.ReturnValue;
        //执行过程
        myConn.Open();
        myCmd.ExecuteScalar();
        try
        { 
            if (Convert.ToInt32(returnValue.Value) == 100)
                return 100;
            else
            { 
                float  P_Flt_SF=float.Parse(myCmd.ExecuteScalar().ToString());
                return P_Flt_SF;
            }
        
        }
        catch(Exception ex)
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
    /// 用会员卡结账时，对会员卡的修改
    /// </summary>
    /// <param name="P_Int_MemberID">会员ID</param>
    /// <param name="P_Flt_GoodsFee">商品总费用</param>
    /// <param name="P_Flt_ShipFee">运输费用</param>
    /// <returns>查看会员卡中的钱是否能购买商品</returns>
    public int  IsUserCart(int P_Int_MemberID, float P_Flt_GoodsFee, float P_Flt_ShipFee)
    {
        SqlConnection myConn = dbObj.GetConnection();
        SqlCommand myCmd = new SqlCommand("Proc_IsUserCart", myConn);
        myCmd.CommandType = CommandType.StoredProcedure;
        //添加参数
        SqlParameter MemberID = new SqlParameter("@MemberID", SqlDbType.BigInt, 8);
        MemberID.Value = P_Int_MemberID;
        myCmd.Parameters.Add(MemberID);
        //添加参数
        SqlParameter GoodsFee = new SqlParameter("@GoodsFee", SqlDbType.Float, 8);
        GoodsFee.Value = P_Flt_GoodsFee;
        myCmd.Parameters.Add(GoodsFee);
        //添加参数
        SqlParameter ShipFee = new SqlParameter("@ShipFee", SqlDbType.Float , 8);
        ShipFee.Value = P_Flt_ShipFee;
        myCmd.Parameters.Add(ShipFee);
        //添加参数
        SqlParameter returnValue = myCmd.Parameters.Add("returnvalue", SqlDbType.Float , 8);
        returnValue.Direction=ParameterDirection.ReturnValue;
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
        return int.Parse(returnValue.Value.ToString());
       
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
