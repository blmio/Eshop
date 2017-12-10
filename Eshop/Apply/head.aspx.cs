using System;
using System.Collections.Generic;
using System.Configuration;

public partial class Apply_head : System.Web.UI.Page
{
    protected string Route = ConfigurationManager.ConnectionStrings["route"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}