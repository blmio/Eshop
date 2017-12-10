using System;
using System.Collections.Generic;
using System.Web;
using ask;

public partial class admin_Shop_GoodsInfo : System.Web.UI.Page
{
    public int mi = 0, age = 1;
    public string head = "所有",tle = "title", upid,upids;
    protected void Page_Load(object sender, EventArgs e)
    {
        //查询条件
        string Where = "";
        string emid = Request.QueryString["emid"],
            title = Request.QueryString["title"],
            price = Request.QueryString["price"];
        if (!string.IsNullOrEmpty(emid)) { Where += " and [emid] like '%" + emid + "%'"; }
        if (!string.IsNullOrEmpty(title)) { Where += " and [title] like '%" + title + "%'"; }
        if (!string.IsNullOrEmpty(price))
        {
            double pr = 0.00, pr2 = 0.00;
            double.TryParse(price, out pr);
            pr2 = pr - 10;
            pr = pr + 10;
            Where += " and [price] between " + pr2.ToString() + " and " + pr.ToString();
        }
        upid = Request.QueryString["upid"];
        upids = Request.QueryString["upids"];
        if (!string.IsNullOrEmpty(upid))
        {
            head = DBHelp.fr_string("select [" + tle + "] from [e_goods_cate] where [Number]='" + upid + "'");
            Where += " and ([upid]='" + upid + "' or [upid] in (select [Number] from [e_goods_cate] where [upid]='" + upid + "'))";
        }
        if (!string.IsNullOrEmpty(upids))
        {
            Where += " and [upids]='" + upids + "'";
        }
        //编号
        string Pa = Request.QueryString["Page"];
        int.TryParse(Pa, out age); if (age < 1) age = 1; if (age != 1) age = 16 * (age - 1) + 1;
        //分页参数
        this.PageAd1.TableName = "[e_goods]";
        this.PageAd1.Field = "[Number]";
        this.PageAd1.Fieldcolumn = "[Number],[upid],[upids],[ImgS],[title],[price],[CloseS],[Stat]";
        this.PageAd1.Order = " order by [Stat],[Number]";
        this.PageAd1.Url = "GoodsInfo.aspx";
        this.PageAd1.PageSize = 16;
        this.PageAd1.Where = Where;
        this.PageAd1.Repe = this.Repeater1;
        this.PageAd1.NoCh = this.NoCh;
    }
    public int miT(int mi) { return mi + age; }
    protected string MR(object pic) { return ask.Web.AppInf.MR(pic); }
    protected string toCate(object upid, object upids)
    {
        string str = string.Empty;
        string upidValue = str, upidsValue = str;
        if (upid != null) upidValue = upid.ToString();
        if (upids != null) upidsValue = upids.ToString();

        str = DBHelp.fr_string("select [title] from [e_goods_cate] where [Number]='" + upidValue + "'");
        str += "-" + DBHelp.fr_string("select [title] from [e_goods_cate] where [Number]='" + upidsValue + "'");
        return str;
    }
}