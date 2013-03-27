using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// SaveSubGoodsClass 的摘要说明
/// </summary>
public class SaveSubGoodsClass
{
    public int GoodsID;  //商品编号
    public float  MemberPrice;//会员价格
    public int Num;//商品数量
    public float   SumPrice;//小计
    public float  GoodsWeight;//重量

	public SaveSubGoodsClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
  
}
