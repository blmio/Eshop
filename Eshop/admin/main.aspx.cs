using System;
using System.Data;
using System.Web.UI.WebControls;
using ask;

public partial class admin_main : System.Web.UI.Page
{
    protected string[] Vt = new string[20];
    protected void Page_Load(object sender, EventArgs e)
    {
        Vt[0] = htmlCookie.AccessCookieid("loginInfoSxmy", "Number");
        if (string.IsNullOrEmpty(Vt[0])) Response.Redirect("login.aspx");
        string[] Us = DBHelp.frS_string("select [Aname],[Lasttime],[Lotimes] from [e_admin] where [Number]='" + Vt[0] + "'");
        Vt[0] = Us[0]; Vt[1] = Us[1]; Vt[2] = Us[2];
    }
}