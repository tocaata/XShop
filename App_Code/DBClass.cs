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
using System.Collections;

public class RecordNotExisted : Exception

{
    public RecordNotExisted(string Message) : base(Message)
    {
    }

    public RecordNotExisted()
        : base()
    {
    }
}

/// <summary>
/// DBClass 的摘要说明
/// </summary>
public class DBClass
{
    private static string connstr = ConfigurationManager.AppSettings["ConnectionString"].ToString();
	public DBClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    private static SqlConnection connection;
    /// <summary>
    /// 数据库连接
    /// </summary>
    /// <returns>SqlConnection对象</returns>
    /// 
    public SqlConnection GetConnection()
    {
        SqlConnection myConn = new SqlConnection(connstr);
        return myConn;
    }

    public static SqlConnection Connection
    {
        get
        {///最好把这个连接字符串写道配置文件里在读取出来， 这样有利于维护
            string connectionString = connstr;
            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            else if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            else if (connection.State == System.Data.ConnectionState.Broken)
            {
                connection.Close();
                connection.Open();
            }
            return connection;
        }
    }

    //这是通用的增删改的方法不带参数的

    public static int ExecuteCommand(string safeSql)
    {
        SqlCommand cmd = new SqlCommand(safeSql, Connection);
        int result = cmd.ExecuteNonQuery();
        cmd.Dispose();
        return result;
    }

    //这是通用的增删改的方法带参数的

    public static int ExecuteCommand(string sql, params SqlParameter[] values)
    {
        SqlCommand cmd = new SqlCommand(sql, Connection);
        cmd.Parameters.AddRange(values);
        int result = cmd.ExecuteNonQuery();
        cmd.Dispose();
        return result;
    }

    //这是通用的增删改的方法只带一个参数的

    public static int ExecuteCommand(string sql, SqlParameter value)
    {
        SqlCommand cmd = new SqlCommand(sql, Connection);
        cmd.Parameters.Add(value);
        int result = cmd.ExecuteNonQuery();
        cmd.Dispose();
        return result;
    }

    //执行返回首行首列不带参数的
    public static int ExecuteScalar(string safeSql)
    {
        SqlCommand cmd = new SqlCommand(safeSql, Connection);
        object result = cmd.ExecuteScalar();
        cmd.Dispose();
        if (result == null)
        {
            throw new RecordNotExisted("记录不存在");
        }
        return Convert.ToInt32(result);
    }

    ///执行返回首行首列带参数的
    public static int ExecuteScalar(string sql, params SqlParameter[] values)
    {
        SqlCommand cmd = new SqlCommand(sql, Connection);
        cmd.Parameters.AddRange(values);
        object result = cmd.ExecuteScalar();
        cmd.Dispose();
        if (result == null)
        {
            throw new RecordNotExisted("记录不存在");
        }
        return Convert.ToInt32(result);
    }

    public static int ExecuteScalar(string sql, SqlParameter value)
    {
        SqlCommand cmd = new SqlCommand(sql, Connection);
        cmd.Parameters.Add(value);
        object result = cmd.ExecuteScalar();
        cmd.Dispose();
        if (result == null)
        {
            throw new RecordNotExisted("记录不存在");
        }
        return Convert.ToInt32(result);
    }

    //查询数据库是否存在该记录
    public static bool IsExisted(string sql, params SqlParameter[] values)
    {
        SqlCommand cmd = new SqlCommand(sql, Connection);
        cmd.Parameters.AddRange(values);
        if (cmd.ExecuteScalar() == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// 执行无参数的sql语句
    /// </summary>
    /// <param name="safeSql"></param>
    /// <returns></returns>
    public static SqlDataReader ExecuteReader(string safeSql)
    {
        SqlCommand cmd = new SqlCommand(safeSql, Connection);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    /// <summary>
    /// 执行有参数的sql语句
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static SqlDataReader ExecuteReader(string sql, SqlParameter value)
    {

        SqlCommand cmd = new SqlCommand(sql, Connection);
        cmd.Parameters.Add(value);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader ExecuteReader(string sql, SqlParameter[] values)
    {
        SqlCommand cmd = new SqlCommand(sql, Connection);
        cmd.Parameters.AddRange(values);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }
   
    public static DataTable GetDataTable(string safeSql, params SqlParameter[] values)
    {
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand(safeSql, Connection);
        cmd.Parameters.AddRange(values);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        cmd.Dispose();
        return ds.Tables[0];
    }


    public static SqlDataReader GetReader(string safeSql)
    {
        SqlCommand cmd = new SqlCommand(safeSql, Connection);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }

    public static SqlDataReader GetReader(string sql, params SqlParameter[] values)
    {
        SqlCommand cmd = new SqlCommand(sql, Connection);
        cmd.Parameters.AddRange(values);
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }
}
 