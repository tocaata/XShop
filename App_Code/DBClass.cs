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
    /// <summary>
    /// 数据库连接
    /// </summary>
    /// <returns>SqlConnection对象</returns>
    public SqlConnection GetConnection()
    {
        SqlConnection myConn = new SqlConnection(connstr);
        return myConn;
    }

    public Object[] GetData(String command)
    {
        Object[] values = null;
        using (SqlConnection sqlConn = GetConnection())
        {
            sqlConn.Open();
            using (SqlCommand myCmd = new SqlCommand(command, sqlConn))
            {
                SqlDataReader reader = myCmd.ExecuteReader();
                try
                {
                    values = new Object[reader.FieldCount];
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                finally
                {
                    reader.Close();
                }
            }
        }
        return values;
    }

    public DataSet GetDataSet(String command, String table_name)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection sqlConn = GetConnection())
        {
            sqlConn.Open();
            using (SqlCommand myCmd = new SqlCommand(command, sqlConn))
            {
                myCmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(myCmd);
                if (table_name == null)
                {
                    da.Fill(dataSet);
                }
                else
                {
                    da.Fill(dataSet, table_name);
                }
            }
        }
        return dataSet;
    }

    public DataSet GetDataSet(String command, String table_name, params SqlParameter[] arugments)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection sqlConn = GetConnection())
        {
            sqlConn.Open();
            SqlCommand myCmd = new SqlCommand(command, sqlConn);
            try
            {
                for (int i = 0; i < arugments.Length; i++)
                {
                    myCmd.Parameters.Add(arugments[i]);
                }
                //myCmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(myCmd);
                if (table_name == null)
                {
                    da.Fill(dataSet);
                }
                else
                {
                    da.Fill(dataSet, table_name);
                }
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            finally
            {
                myCmd.Dispose();
            }
        }
        return dataSet;
    }

    public int GetInt32(String command, params SqlParameter[] arugments)
    {
        DataSet ds = GetDataSet(command, "re", arugments);
        if (ds.Tables["re"].Rows.Count > 0)
        {
            return Convert.ToInt32(ds.Tables["re"].Rows[0][0].ToString());
        }
        else
        {
            throw(new Exception("Can't find this record"));
        }
    }

    public void Update(String command, params SqlParameter[] arugments)
    {
        GetDataSet(command, "re", arugments);
    }

    public DataSet Find(String table_name, params SqlParameter[] arugments)
    {
        DataSet dataSet = new DataSet();
        StringBuilder cmd = new StringBuilder();
        cmd.AppendFormat("select * from {0} where ", table_name);
        for (int i = 0; i < arugments.Length; i++)
        {
            cmd.AppendFormat("{0} = {1} ", arugments[0].ParameterName.Trim('@'), arugments[0].ParameterName);
        }
        using (SqlConnection sqlConn = GetConnection())
        {
            sqlConn.Open();
            SqlCommand myCmd = new SqlCommand(cmd.ToString(), sqlConn);
            try
            {
                for (int i = 0; i < arugments.Length; i++)
                {
                    myCmd.Parameters.Add(arugments[i]);
                }
                myCmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(myCmd);
                if (table_name == null)
                {
                    da.Fill(dataSet);
                }
                else
                {
                    da.Fill(dataSet, table_name);
                }
            }
            finally
            {
                myCmd.Dispose();
            }
        }
        return dataSet;
    }

    //private String[] GetVariable(String str)
    //{
    //    int count = 0;
    //    for (int i = 0; i < str.Length; i++)
    //    {
    //        if (str[i] == '@')
    //            count++;
    //    }

    //    String [] ret = new String[count];

    //    for (int i = str.IndexOf('@'); i != -1; i = str.IndexOf('@', i + 1))
    //    {
    //        int j = str.IndexOf(
    //    }
    //}
}
