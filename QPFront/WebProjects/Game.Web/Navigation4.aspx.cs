﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Game.Web
{
    public partial class Navigation4 : System.Web.UI.Page
    {
        protected void Page_Load( object sender , EventArgs e )
        {
            Response.Redirect( "/Match/Index.aspx" );
        }
    }
}
