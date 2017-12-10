using System;
using System.Data;
using System.Web.UI.WebControls;
using ask;

public partial class admin_user_CateInfo : System.Web.UI.Page
{
    public int mi = 0, age = 1; public int miT(int mi) { return mi + age; }
    protected string upid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string where = "";
        string Pa = Request.QueryString["Page"];
        upid = Request.QueryString["upid"];
        int.TryParse(Pa, out age); if (age < 1) age = 1; if (age != 1) age = 16 * (age - 1) + 1;

        if (!string.IsNullOrEmpty(upid))
            where = " and [upid]='" + upid + "'";
        else
            where = " and [upid]='0'";
        this.PageAd1.Where = where;
        this.PageAd1.TableName = "[e_goods_cate]";
        this.PageAd1.Fieldcolumn = "[Number],[title],[Stat],[CloseS],(select [title] from [e_goods_cate] as [We] where [We].[Number]=[e_goods_cate].[upid]) as [upidT],[upid]";
        this.PageAd1.Field = "[Number]";
        this.PageAd1.Order = "order by [Stat],[Number]";
        this.PageAd1.Url = "CateInfo.aspx";
        this.PageAd1.Repe = this.Repeater1;
        this.PageAd1.PageSize = 16;
        this.PageAd1.NoCh = this.NoCh;
    }
    public string upber(object up)
    {
        if (up == null)
            return "主类别";
        else if (string.IsNullOrEmpty(up.ToString()))
            return "主类别";
        return up.ToString();
    }
}