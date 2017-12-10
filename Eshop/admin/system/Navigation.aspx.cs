using System;
using System.Data;
using ask;

public partial class admin_system_Navigation : System.Web.UI.Page
{
    protected string upid, clid;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Pageview1.TableName = "[e_navigation]";
        this.Pageview1.Field = "[Number]";
        this.Pageview1.Fieldcolumn = "[Number],[title],[sitetitle],[Keywords],[Description],[Stat],[Reded],[CloseS]";
        this.Pageview1.Order = " order by [Stat],[Number]";
        this.Pageview1.Url = "Navigation.aspx";
        this.Pageview1.PageSize = 15;
        this.Pageview1.Repe = this.Repeater1;
        this.Pageview1.NoCh = this.NoCh;
    }

    protected string Fun(object T)
    {
        if (T == null) return "&nbsp;";
        string str;
        str = T.ToString();
        if (string.IsNullOrEmpty(str)) return "&nbsp;";
        return "<span title=\"" + str + "\">" + str + "</span>";
    }

}