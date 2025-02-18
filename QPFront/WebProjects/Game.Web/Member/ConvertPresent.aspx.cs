﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Game.Entity.Accounts;
using Game.Entity.Treasure;
using Game.Facade;
using Game.Utils;
using Game.Kernel;

namespace Game.Web.Member
{
    public partial class ConvertPresent : UCPageBase
    {
        #region 继承属性

        protected override bool IsAuthenticatedUser
        {
            get
            {
                return true;
            }
        }

        #endregion

        protected int rate = 0;
        private AccountsFacade accountsFacade = new AccountsFacade();
        private TreasureFacade treasureFacade = new TreasureFacade();

        protected void Page_Load( object sender, EventArgs e )
        {
            SystemStatusInfo systemStatusInfo = accountsFacade.GetSystemStatusInfo( "PresentExchangeRate" );
            rate = systemStatusInfo == null ? 1 : systemStatusInfo.StatusValue;

            if( !IsPostBack )
            {
                Message umsg = accountsFacade.GetUserGlobalInfo( Fetch.GetUserCookie().UserID, 0, "" );
                if( umsg.Success )
                {
                    UserInfo user = umsg.EntityList[0] as UserInfo;
                    this.lblAccounts.Text = user.Accounts;
                    this.lblExchangeLoves.Text = user.Present.ToString();
                    this.lblGameID.Text = user.GameID.ToString();
                    this.lblTotalLoves.Text = user.LoveLiness.ToString();
                    this.lblUnExchangeLoves.Text = ( user.LoveLiness - user.Present ).ToString();

                    this.txtPresent.Text = ( user.LoveLiness - user.Present ).ToString();
                }

                GameScoreInfo scoreInfo = treasureFacade.GetTreasureInfo2( Fetch.GetUserCookie().UserID );
                if( scoreInfo != null )
                {
                    this.lblInsureScore.Text = scoreInfo.InsureScore.ToString();
                }
            }

            Themes.Standard.Common_Header sHeader = (Themes.Standard.Common_Header)this.FindControl( "sHeader" );
            sHeader.title = "会员中心";
        }

        protected void btnUpdate_Click( object sender, EventArgs e )
        {
            int present = Utility.StrToInt( txtPresent.Text.Trim(), 0 );
            if( present <= 0 )
            {
                Show( "兑换的魅力点必须为正整数！" );
                return;
            }
            Message umsg = accountsFacade.UserConvertPresent( Fetch.GetUserCookie().UserID, present, rate, GameRequest.GetUserIP() );
            if( umsg.Success )
            {
                ShowAndRedirect( "魅力兑换成功!", "/Member/ConvertPresent.aspx" );
            }
            else
            {
                Show( umsg.Content );
            }
        }
    }
}
