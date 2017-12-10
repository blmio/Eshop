using System;
using System.Web.UI.WebControls;
using System.Data;
using ask;

public partial class Ascx_Order_Pageview : System.Web.UI.UserControl
{
    #region  传递的参数

    System.Web.UI.HtmlControls.HtmlTableRow noCh = null;
    public System.Web.UI.HtmlControls.HtmlTableRow NoCh { set { noCh = value; } }
    /// <summary>
    /// 当前绝对域名路径
    /// </summary>
    string url = "";
    /// <summary>
    /// 当前绝对域名路径
    /// </summary>
    public string Url { set { url = value; } }
    /// <summary>
    /// Repeater 绑控件
    /// </summary>
    Repeater repe = null;
    /// <summary>
    /// Repeater 绑控件
    /// </summary>
    public Repeater Repe { set { repe = value; } }
    /// <summary>
    /// 记录分页条数
    /// </summary>
    int pageSize = 20;
    /// <summary>
    /// 记录分页条数
    /// </summary>
    public int PageSize { set { pageSize = value; } }
    /// <summary>
    /// 表名
    /// </summary>
    string tableName;
    /// <summary>
    /// 表名
    /// </summary>
    public string TableName { set { tableName = value; } }
    /// <summary>
    /// 字段列表
    /// </summary>
    string fieldcolumn = " * ";
    /// <summary>
    /// 字段列表
    /// </summary>
    public string Fieldcolumn { set { fieldcolumn = value; } }
    /// <summary>
    /// 分页条件关键字段名
    /// </summary>
    string field = "[Number]";
    /// <summary>
    /// 分页条件关键字段名
    /// </summary>
    public string Field { set { field = value; } }
    /// <summary>
    /// 查询条件(注意: 不要加where)
    /// </summary>
    string where = "";
    /// <summary>
    /// 查询条件(注意: 不要加where)
    /// </summary>
    public string Where { set { where = value; } }
    /// <summary>
    /// 排序字段
    /// </summary>
    string order = "";
    /// <summary>
    /// 排序字段
    /// </summary>
    public string Order { set { order = value; } }
    /// <summary>
    /// 总页数
    /// </summary>
    int pagecount = 1;
    /// <summary>
    /// 总页数
    /// </summary>
    public int Pagecount { get { return pagecount; } set { pagecount = value; } }
    /// <summary>
    /// 总记录数
    /// </summary>
    int allcount = 0;
    /// <summary>
    /// 总记录数
    /// </summary>
    public int Allcount { get { return allcount; } set { allcount = value; } }
    /// <summary>
    /// 当前页数
    /// </summary>
    int pageint = 1;
    /// <summary>
    /// 首页
    /// </summary>
    string FirstPage;
    /// <summary>
    /// 上一页
    /// </summary>
    string pritPage;
    /// <summary>
    /// 下一页
    /// </summary>
    string NextPage;
    /// <summary>
    /// 尾页
    /// </summary>
    public string DownPage;

    #endregion
    /// <summary>
    /// 返回当前的分页html信息
    /// </summary>
    string html = "";
    /// <summary>
    /// 返回当前的分页html信息
    /// </summary>
    public string Html { get { return html; } set { html = value; } }
    string Auturl = strFunction.Authorityurl_2();

    protected void Page_Load(object sender, EventArgs e)
    {
        DatasBound();
    }

    private void DatasBound()
    {
        string page = Request["Page"];
        int.TryParse(page, out pageint); if (pageint < 1) { pageint = 1; }
        ///存储过程分页
        DataSet DSet = DBHelp.DataSet_ds(fieldcolumn, tableName, field, where, pageint, pageSize, order, out pagecount, out allcount);
        this.repe.DataSource = DSet;
        this.repe.DataBind();
        if (pageint > 1)
            FirstPage = "<a onclick=\"pWin.Pages('1');\"><img src=\"" + Auturl + "images/admin/first.gif\" /></a>";
        else
            FirstPage = "<a><img src=\"" + Auturl + "images/admin/first_1.gif\" /></a>";
        if ((pageint - 1) > 0)
            pritPage = "<a onclick=\"pWin.Pages('" + (pageint - 1) + "');\"><img src=\"" + Auturl + "images/admin/back.gif\" /></a>";
        else
            pritPage = "<a><img src=\"" + Auturl + "images/admin/back_1.gif\" /></a>";
        if ((pageint + 1) <= pagecount && pagecount != 1)
            NextPage = "<a onclick=\"pWin.Pages('" + (pageint + 1) + "');\"><img src=\"" + Auturl + "images/admin/next.gif\" /></a>";
        else
            NextPage = "<a><img src=\"" + Auturl + "images/admin/next_1.gif\" /></a>";
        if (pageint < pagecount && pagecount != 1)
            DownPage = "<a onclick=\"pWin.Pages('" + pagecount + "');\"><img src=\"" + Auturl + "images/admin/last.gif\" /></a>";
        else
            DownPage = "<a><img src=\"" + Auturl + "images/admin/last_1.gif\" /></a>";
        Html = "<div class=\"tabBCL\">共有 <span>" + allcount + "</span> 条记录，当前第 <span>" + pageint + "</span>/<span>" + pagecount + "</span> 页</div>\n";
        Html += "<div class=\"tabBCR\">" + FirstPage + " " + pritPage + " " + NextPage + " " + DownPage + " <span>转到第</span> <span><input onkeydown=\"return pWin.checkPage(event,this.value)\" type=\"text\" id=\"PageText\" class=\"TextBox\" value=\"" + pageint + "\" /></span> <span>页</span> <a><img src=\"" + Auturl + "images/admin/go.gif\" onclick=\"pWin.changeUrl($('PageText').value)\" /></a></div>\n";
        Html += "<script type=\"text/javascript\">pWin.Pagerul = \"" + strid() + "\";pWin.pageall=" + pagecount + ";</script>\n";
        if (this.noCh != null) { if (allcount < 1) { this.noCh.Visible = true; } }
    }
    #region 管理方法
    public string strid()
    {
        ask.Web.AppInf.PageP = "Pmt";
        return ask.Web.AppInf.strids(Request.QueryString["Page"], url);
    }
    #endregion
}
