/*
 * 版本：4.0
 * 时间：2011-8-1
 * 作者：http://www.foxuc.com
 *
 * 描述：实体类
 *
 */

using System;
using System.Collections.Generic;

namespace Game.Entity.Treasure
{
	/// <summary>
	/// 实体类 OnLineOrder。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OnLineOrder  
	{
		#region 常量

		/// <summary>
		/// 表名
		/// </summary>
		public const string Tablename = "OnLineOrder" ;

		/// <summary>
		/// 订单标识
		/// </summary>
		public const string _OnLineID = "OnLineID" ;

		/// <summary>
		/// 操作用户
		/// </summary>
		public const string _OperUserID = "OperUserID" ;

		/// <summary>
		/// 服务标识
		/// </summary>
		public const string _ShareID = "ShareID" ;

		/// <summary>
		/// 用户标识
		/// </summary>
		public const string _UserID = "UserID" ;

		/// <summary>
		/// 游戏ID
		/// </summary>
		public const string _GameID = "GameID" ;

		/// <summary>
		/// 用户名
		/// </summary>
		public const string _Accounts = "Accounts" ;

		/// <summary>
		/// 订单号码
		/// </summary>
		public const string _OrderID = "OrderID" ;

		/// <summary>
		/// 卡类标识
		/// </summary>
		public const string _CardTypeID = "CardTypeID" ;

		/// <summary>
		/// 会员卡价格
		/// </summary>
		public const string _CardPrice = "CardPrice" ;

		/// <summary>
		/// 卡金币
		/// </summary>
		public const string _CardGold = "CardGold" ;

		/// <summary>
		/// 充卡数量
		/// </summary>
		public const string _CardTotal = "CardTotal" ;

		/// <summary>
		/// 订单金额
		/// </summary>
		public const string _OrderAmount = "OrderAmount" ;

		/// <summary>
		/// 折扣比例
		/// </summary>
		public const string _DiscountScale = "DiscountScale" ;

		/// <summary>
		/// 实付金额
		/// </summary>
		public const string _PayAmount = "PayAmount" ;

		/// <summary>
		/// 订单状态  0:未付款;1:已付款待处理;2:处理完成
		/// </summary>
		public const string _OrderStatus = "OrderStatus" ;

		/// <summary>
		/// 订单地址
		/// </summary>
		public const string _IPAddress = "IPAddress" ;

		/// <summary>
		/// 订单日期
		/// </summary>
		public const string _ApplyDate = "ApplyDate" ;
		#endregion

		#region 私有变量
		private int m_onLineID;					//订单标识
		private int m_operUserID;				//操作用户
		private int m_shareID;					//服务标识
		private int m_userID;					//用户标识
		private int m_gameID;					//游戏ID
		private string m_accounts;				//用户名
		private string m_orderID;				//订单号码
		private int m_cardTypeID;				//卡类标识
		private decimal m_cardPrice;			//会员卡价格
		private long m_cardGold;				//卡金币
		private int m_cardTotal;				//充卡数量
		private decimal m_orderAmount;			//订单金额
		private decimal m_discountScale;		//折扣比例
		private decimal m_payAmount;			//实付金额
		private byte m_orderStatus;				//订单状态  0:未付款;1:已付款待处理;2:处理完成
		private string m_iPAddress;				//订单地址
		private DateTime m_applyDate;			//订单日期
		#endregion

		#region 构造方法

		/// <summary>
		/// 初始化OnLineOrder
		/// </summary>
		public OnLineOrder()
		{
			m_onLineID=0;
			m_operUserID=0;
			m_shareID=0;
			m_userID=0;
			m_gameID=0;
			m_accounts="";
			m_orderID="";
			m_cardTypeID=0;
			m_cardPrice=0;
			m_cardGold=0;
			m_cardTotal=0;
			m_orderAmount=0;
			m_discountScale=0;
			m_payAmount=0;
			m_orderStatus=0;
			m_iPAddress="";
			m_applyDate=DateTime.Now;
		}

		#endregion

		#region 公共属性

		/// <summary>
		/// 订单标识
		/// </summary>
		public int OnLineID
		{
			get { return m_onLineID; }
			set { m_onLineID = value; }
		}

		/// <summary>
		/// 操作用户
		/// </summary>
		public int OperUserID
		{
			get { return m_operUserID; }
			set { m_operUserID = value; }
		}

		/// <summary>
		/// 服务标识
		/// </summary>
		public int ShareID
		{
			get { return m_shareID; }
			set { m_shareID = value; }
		}

		/// <summary>
		/// 用户标识
		/// </summary>
		public int UserID
		{
			get { return m_userID; }
			set { m_userID = value; }
		}

		/// <summary>
		/// 游戏ID
		/// </summary>
		public int GameID
		{
			get { return m_gameID; }
			set { m_gameID = value; }
		}

		/// <summary>
		/// 用户名
		/// </summary>
		public string Accounts
		{
			get { return m_accounts; }
			set { m_accounts = value; }
		}

		/// <summary>
		/// 订单号码
		/// </summary>
		public string OrderID
		{
			get { return m_orderID; }
			set { m_orderID = value; }
		}

		/// <summary>
		/// 卡类标识
		/// </summary>
		public int CardTypeID
		{
			get { return m_cardTypeID; }
			set { m_cardTypeID = value; }
		}

		/// <summary>
		/// 会员卡价格
		/// </summary>
		public decimal CardPrice
		{
			get { return m_cardPrice; }
			set { m_cardPrice = value; }
		}

		/// <summary>
		/// 卡金币
		/// </summary>
		public long CardGold
		{
			get { return m_cardGold; }
			set { m_cardGold = value; }
		}

		/// <summary>
		/// 充卡数量
		/// </summary>
		public int CardTotal
		{
			get { return m_cardTotal; }
			set { m_cardTotal = value; }
		}

		/// <summary>
		/// 订单金额
		/// </summary>
		public decimal OrderAmount
		{
			get { return m_orderAmount; }
			set { m_orderAmount = value; }
		}

		/// <summary>
		/// 折扣比例
		/// </summary>
		public decimal DiscountScale
		{
			get { return m_discountScale; }
			set { m_discountScale = value; }
		}

		/// <summary>
		/// 实付金额
		/// </summary>
		public decimal PayAmount
		{
			get { return m_payAmount; }
			set { m_payAmount = value; }
		}

		/// <summary>
		/// 订单状态  0:未付款;1:已付款待处理;2:处理完成
		/// </summary>
		public byte OrderStatus
		{
			get { return m_orderStatus; }
			set { m_orderStatus = value; }
		}

		/// <summary>
		/// 订单地址
		/// </summary>
		public string IPAddress
		{
			get { return m_iPAddress; }
			set { m_iPAddress = value; }
		}

		/// <summary>
		/// 订单日期
		/// </summary>
		public DateTime ApplyDate
		{
			get { return m_applyDate; }
			set { m_applyDate = value; }
		}
		#endregion
	}
}
