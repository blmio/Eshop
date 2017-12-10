using System;
using System.Collections.Generic;
using System.Web;
using ask;

public partial class admin_default : System.Web.UI.Page
{
    protected string url = strFunction.Authorityurl_2(), uesrname = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (!logRoles())
            {
                Response.Redirect("~/admin/login.aspx");
                Response.End();
            }
        }
        string login = Request.QueryString["login"];
        if (login == "login")
        {
            Response.Cookies["loginInfoSxmy"]["Aname"] = "";
            jsFontcion.JS("location.replace(location)");
        }
    }
    /// <summary>
    /// 判断用户是否有登录
    /// </summary>
    /// <returns></returns>
    protected bool logRoles()
    {
        if (Request.Cookies["loginInfoSxmy"] != null)
        {
            if (Request.Cookies["loginInfoSxmy"]["Aname"] != null && Request.Cookies["loginInfoSxmy"]["Aname"] != "" && Request.Cookies["loginInfoSxmy"]["Number"] != null)
            {
                uesrname = Request.Cookies["loginInfoSxmy"]["Aname"];
                return true;
            }
        }
        return false;
    }
}