﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// CommonProperty 的摘要说明
/// </summary>
public class CommonProperty
{
    public int OrderNo;  //订单编号
    public DateTime OrderTime;//下单时间
    public float  ProductPrice;//商品总金额
    public float ShipPrice;//商品运费
    public float TotalPrice;//订单总金额
    public string BuyerName;//购货人姓名
    public string BuyerPhone;//联系人电话
    public string BuyerEmail;//Email地址
    public string BuyerAddress;//购货人地址
    public string BuyerPostalcode;//邮政编码
    public string ReceiverName;//收货人姓名
    public string ReceiverPhone;//联系人电话
    public string ReceiverEmail;//Email地址
    public string ReceiverAddress;//购货人地址
    public string ReceiverPostalcode;//邮政编码
    public int ShipType;//运输类型
    public int PayType;//支付类型
    public int Status;

    public string statusString
    {
        get
        {
            string stat = "";
            switch (Status)
            {
                case 0: stat = "购物车";
                    break;
                case 1: stat = "未审核";
                    break;
                case 2: stat = "审核通过";
                    break;
                case 3: stat = "发货";
                    break;
                case 4: stat = "订单完成";
                    break;
                case 5: stat = "退货中";
                    break;
                case 6: stat = "已退货";
                    break;
            }
            return stat;
        }
    }
   

	public CommonProperty()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    
}
