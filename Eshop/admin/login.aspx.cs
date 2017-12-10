using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ask;

public partial class admin_login : System.Web.UI.Page
{
    protected string[] Rv = new string[3];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["remeSxmy"] != null)
        {
            Rv[0] = Request.Cookies["remeSxmy"]["Aname"];
            Rv[1] = ask.Web.EncryptHelper.Decrypt(Request.Cookies["remeSxmy"]["Apasswoid"]);
            if (!string.IsNullOrEmpty(Rv[0])) Rv[2] = "on";
        }
    }
}