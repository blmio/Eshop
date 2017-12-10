using System;
using System.Collections.Generic;
using System.Web;
using ask;

public partial class admin_system_AdsPic : System.Web.UI.Page
{
    public int mi = 0, age = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        string Pa = Request.QueryString["Page"];
        int.TryParse(Pa, out age); if (age < 1) age = 1; if (age != 1) age = 16 * (age - 1) + 1;
        this.PageAd1.TableName = "[e_ads_flash]";
        this.PageAd1.Field = "[Number]";
        this.PageAd1.Fieldcolumn = "[Number],[url],[ImgS],[title],[Description],[CloseS],[Stat]";
        this.PageAd1.Order = " order by [Stat],[Number]";
        this.PageAd1.Url = "AdsPic.aspx";
        this.PageAd1.PageSize = 16;
        this.PageAd1.Repe = this.Repeater1;
        this.PageAd1.NoCh = this.NoCh;
    }
    public int miT(int mi) { return mi + age; }
}