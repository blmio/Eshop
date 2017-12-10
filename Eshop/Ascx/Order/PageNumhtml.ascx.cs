using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ask;

public partial class Ascx_Order_PageNumhtml : System.Web.UI.UserControl
{
    #region  传递的参数
    System.Web.UI.HtmlControls.HtmlGenericControl noCh = null;
    public System.Web.UI.HtmlControls.HtmlGenericControl NoCh { set { noCh = value; } }
    int pageSize = 20, pageinput = 0;
    public int PageSize { set { pageSize = value; } get { return pageSize; } }
    public int Pageinput { set { pageinput = value; } }
    string where = "";
    public string Where { set { where = value; } }
    string field = "[Number]";
    public string Field { set { field = value; } }
    string fieldcolumn = " * ";
    public string Fieldcolumn { set { fieldcolumn = value; } }
    string tableName;
    public string TableName { set { tableName = value; } }
    string order = "";
    public string Order { set { order = value; } }
    /// <summary>
    /// 总记录数
    /// </summary>
    int rowsCount = 0;
    /// <summary>
    /// 总记录数
    /// </summary>
    public int RowsCount { set { rowsCount = value; } get { return rowsCount; } }
    /// <summary>
    /// 总页数
    /// </summary>
    int pageall;
    /// <summary>
    /// 总页数
    /// </summary>
    public int Pageall { set { pageall = value; } get { return pageall; } }
    /// <summary>
    /// 当前页数
    /// </summary>
    int pageint = 1;
    /// <summary>
    /// 当前页数
    /// </summary>
    public int Pageint { set { pageint = value; } get { return pageint; } }
    /// <summary>
    /// 传来的当前页面
    /// </summary>
    string url = "";
    /// <summary>
    /// 传来的当前页面
    /// </summary>
    public string Url { set { url = value; } }
    /// <summary>
    /// 当前绝对域名路径
    /// </summary>
    string Auturl = strFunction.Authorityurl_2();
    /// <summary>
    /// 绑定到Repeater上的参数
    /// </summary>
    Repeater repe = null;
    /// <summary>
    /// Repeater 绑控件
    /// </summary>
    public Repeater Repe { set { repe = value; } }
    /// <summary>
    /// 记录条数
    /// </summary>
    #endregion

    public string html = "";
    /// <summary>
    /// 返回当前的分页
    /// </summary>
    public string Html { get { return "<script type=\"text/javascript\">document.write('" + html + "');" + input("1") + "</script>"; } set { html = value; } }
    protected void Page_Load(object sender, EventArgs e)
    {
        DatasBound();
    }
    protected void DatasBound()
    {
        string page = Request["Page"];
        if (string.IsNullOrEmpty(page))
        {
            pageint = int.Parse(page);
            if (pageint < 1)
                pageint = 1;
        }
        else
            pageint = 1;
        string roc = DBHelp.fr_string("select count(" + field + ") from " + tableName + where);
        int.TryParse(roc, out rowsCount);
        string sqlstr = "select top " + pageSize + " " + fieldcolumn + " from " + tableName + where + order;
        if (pageint > 1)
        {
            int pag = ((pageint - 1) * pageSize);
            string pagwhere = "";
            if (where.IndexOf("where") > -1)
            {
                if (ask.Web.AppInf.countnum(where, "where") > 1)
                {
                    string wh1 = where.Substring(0, where.LastIndexOf("where"));
                    string wh2 = where.Remove(0, wh1.Length);

                    pagwhere = wh1.Replace("where", "and") + " " + wh2;
                }
                else
                {
                    pagwhere = where.Replace("where", "and").Replace("WHERE", "and");
                }
            }
            else
                pagwhere = where;
            sqlstr = "select top " + pageSize + " " + fieldcolumn + " from " + tableName + " where " + field + " not in(select top " + pag + " " + field + " from " + tableName + where + order + ")" + pagwhere + order;
        }

        DataSet DSet = DBHelp.DataSet_ds(sqlstr);

        if (rowsCount <= pageSize)
            pageall = rowsCount / pageSize;
        else
            pageall = (rowsCount / pageSize) + 1;
        if ((rowsCount % pageSize) == 0)
            pageall = rowsCount / pageSize;

        if (pageall < 1) pageall = 1;

        this.repe.DataSource = DSet;
        if (pageinput == 0)
        {
            if ((pageint - 1) > 0) FirstPage = "<a href=\"" + strid("1") + "\" title=\"首页\">首页</a>"; else FirstPage = "<a disabled=\"disabled\" title=\"首页\">首页</a>";
            if ((pageint - 1) > 0) pritPage = "<a href=\"" + strid((pageint - 1).ToString()) + "\" title=\"上一页\">上一页</a>"; else pritPage = "<a disabled=\"disabled\" title=\"上一页\">上一页</a>";
            if ((pageint + 1) <= pageall) NextPage = "<a href=\"" + strid((pageint + 1).ToString()) + "\" title=\"下一页\">下一页</a>"; else NextPage = "<a disabled=\"disabled\" title=\"下一页\">下一页</a>";
            if ((pageint + 1) <= pageall) DownPage = "<a href=\"" + strid(pageall.ToString()) + "\" title=\"尾页\">尾页</a>"; else DownPage = "<a disabled=\"disabled\" title=\"尾页\">尾页;</a>";
        }
        else
        {
            if ((pageint - 1) > 0) FirstPage = "<a href=\"" + strid("1") + "\" title=\"首页\">首页</a>"; else FirstPage = "<a disabled=\"disabled\" title=\"首页\">首页</a>";
            if ((pageint - 1) > 0) pritPage = "<a href=\"" + strid((pageint - 1).ToString()) + "\" title=\"上一页\">上一页</a>"; else pritPage = "<a disabled=\"disabled\" title=\"上一页\">上一页</a>";
            if ((pageint + 1) <= pageall) NextPage = "<a href=\"" + strid((pageint + 1).ToString()) + "\" title=\"下一页\">下一页</a>"; else NextPage = "<a disabled=\"disabled\" title=\"下一页\">下一页</a>";
            if ((pageint + 1) <= pageall) DownPage = "<a href=\"" + strid(pageall.ToString()) + "\" title=\"尾页\">尾页</a>"; else DownPage = "<a  disabled=\"disabled\" title=\"尾页\">尾页</a>";
        }
        this.repe.DataBind();
        html = FirstPage + pritPage + DigitalW() + NextPage + DownPage;
        if (this.noCh != null) { if (rowsCount < 1) { this.noCh.Visible = true; } }
    }
    #region  页面参数
    /// <summary>
    /// 首页
    /// </summary>
    string FirstPage;
    /// <summary>
    /// 上一页
    /// </summary>
    string pritPage;
    /// <summary>
    /// 数字页
    /// </summary>
    string Digital;
    /// <summary>
    /// 下一页
    /// </summary>
    string NextPage;
    /// <summary>
    /// 尾页
    /// </summary>
    string DownPage;
    #endregion
    public string input(string N)
    {
        if (pageinput == 0)
        {
            string str = string.Empty;
            str += "<span class=\"s\"><input type=\"text\" name=\"page1\" title=\"输入页码，按回车快速跳转\" size=\"2\" onkeydown=\"checkPage(event,this.value)\" class=\"px\" value=\"" + pageint + "\" /><em> / " + pageall + " 页</em></span>";
            return str;
        }
        else
            return "";
    }
    /// <summary>
    /// 判断是否是当前页
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    protected string Pageints(int pa)
    {
        if (pageint != pa)
            return "<a href=\"" + strid(pa.ToString()) + "\">" + pa + "</a>";
        else
            return "<b>" + pa + "</b>";
    }
    protected string DigitalW()
    {
        string str = "";
        int n = 1;
        int m = 9;
        int s = 0;
        if ((pageint - 4) < 1)
        {
            if ((pageint + 4) > pageall)
                m = pageall;
            else
                m = pageint + 4;
            s = 9 - pageint;
            if (s > 0)
                if ((s + 4) <= pageall)
                    m = s + 4;
            if ((m - n) > 8) m = s + 3;
            if ((m - n) > 8) m = s + 2;
            if ((m - n) > 8) m = s + 1;
        }
        else
        {
            n = pageint - 4;
            if ((pageint + 4) > pageall)
                m = pageall;
            else
                m = pageint + 4;
            if (m == pageall)
            {
                s = pageint - 8;
                if (s > 0) n = pageint - 8;
                if ((m - n) > 8) n = m - 8;
            }
        }
        if (pageall == 9)
            m = 9;
        if (n >= m)
            m = n;
        if (pageall < 9)
            m = pageall;
        if (pageint < 3)
        {
            if (pageall < 9)
                m = pageall;
            if (pageall == 9)
                m = 9;
            if (pageall > 9)
                m = 9;
        }
        for (int k = n; k <= m; k++)
        {
            str += Pageints(k);
        }
        if (pageall < 2) str = "";
        return str;
    }
    public string strid(string p)
    {
        return ask.Web.AppInf.stridhtml(p, url);
    }
}
