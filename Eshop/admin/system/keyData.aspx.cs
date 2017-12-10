using System;
using System.Collections.Generic;
using System.Web;
using ask;

public partial class admin_system_keyData : System.Web.UI.Page
{
    public string str = "关键词信息";
    public string upid;
    public int mi = 0, age = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        string Where = string.Empty;
        upid = Request.QueryString["upid"];
        string Pa = Request.QueryString["Page"];
        int.TryParse(Pa, out age); if (age < 1) age = 1; if (age != 1) age = 16 * (age - 1) + 1;
        if (!string.IsNullOrEmpty(upid)) Where += " and [upid]='" + upid + "'";

        this.PageAd1.TableName = "[e_keydata]";
        this.PageAd1.Fieldcolumn = "[Number],[upid],[keywords],[Stat],[CloseS],[Atime],[Reded],[num],[UserHostAddress]";
        this.PageAd1.Field = "[Number]";
        this.PageAd1.Order = "order by [Atime],[Stat],[Number]";
        this.PageAd1.Url = "keyData.aspx";
        this.PageAd1.Where = Where;
        this.PageAd1.Repe = this.Repeater1;
        this.PageAd1.PageSize = 15;
        this.PageAd1.NoCh = this.NoCh;
    }
    public int miT(int mi) { return mi + age; }
}