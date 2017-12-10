using System;
using System.Web;
using System.Web.UI;
using ask;

public partial class eWebEditor_aspx_i : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str = "", action, style, skey, h;
        action = Request.QueryString["action"];
        style = Request.QueryString["style"];
        skey = Request.QueryString["skey"];
        h = Request.QueryString["h"];
        str = IOFile.ReadFile("~/eWebEditor/aspx/ajs/" + style + ".js");
        Response.Write(str);
    }
}