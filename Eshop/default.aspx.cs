using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using ask;

public partial class _default : System.Web.UI.Page
{
    protected string url = strFunction.Authorityurl_2();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected string MR(object pic) { return ask.Web.AppInf.MR(pic); }
    protected string top() { return ask.Web.Comway.top(); }
    protected string footer() { return ask.Web.Comway.footer(); }
    protected string goTop() { return ask.Web.Comway.goTop(); }
    protected string refrCart() { return ask.Web.Comway.refrCart(); }
    protected string wrap_cate()
    {
        string str = string.Empty;
        string item_count = string.Empty, sub_item = item_count;
        int i = 0;
        DataSet ds1 = DBHelp.DataSet_ds("select [Number],[upid],[title],[CloseS] from [e_goods_cate] where [CloseS]<>1 and [upid]='0' order by [Stat],[Number]", "@value");
        foreach (DataRow rs1 in ds1.Tables["@value"].Select())
        {
            int j = 0;
            if (i == ds1.Tables["@value"].Rows.Count - 1)
                str += "<div class=\"item lastItem\">";
            else
                str += "<div class=\"item\">";

            item_count = "<div class=\"item_cont\"><span><a href=\"javascript:;\">" + rs1["title"].ToString() + "</a></span><em>";
            sub_item = "<div class=\"sub_item clearfix\" style=\"display: none;\">";
            DataSet ds2 = DBHelp.DataSet_ds("select [Number],[upid],[title],[CloseS],[Reded] from [e_goods_cate] where [CloseS]<>1 and [upid]='" + rs1["Number"].ToString() + "' order by [Stat],[Number]", "@value");
            foreach (DataRow rs2 in ds2.Tables["@value"].Select())
            {
                if (j < 2)
                    item_count += "<a href=\"search.aspx?keys=" + rs2["title"].ToString() + "\" target=\"_blank\">" + rs2["title"].ToString() + "</a>";
                if (rs2["Reded"].ToString() == "1")
                    sub_item += "<a href=\"search.aspx?keys=" + rs2["title"].ToString() + "\" class=\"style-red\" target=\"_blank\">" + rs2["title"].ToString() + "</a>";
                else
                    sub_item += "<a href=\"search.aspx?keys=" + rs2["title"].ToString() + "\" target=\"_blank\">" + rs2["title"].ToString() + "</a>";

                j++;
            }
            ds2.Clear();
            ds2.Dispose();
            str += item_count + "</em></div>" + sub_item + "</div></div>";

            i++;
        }
        ds1.Clear();
        ds1.Dispose();
        return str;
    }
    protected string wrap_flash()
    {
        int i = 0;
        string str = string.Empty;
        string wrap = string.Empty, trigger = wrap;
        str = "<div class=\"auc_slider\" id=\"auc_slider\">";
        wrap = "<div class=\"auc_wrap\"><ul style=\"position: relative;\">";
        trigger = "<div class=\"auc_trigger\">";
        DataSet ds = DBHelp.DataSet_ds("select top 6 [upid],[url],[ImgS],[title],[Description],[CloseS] from [e_flash] where [CloseS]<>1 order by [Stat],[Number]", "@value");
        foreach (DataRow rs in ds.Tables["@value"].Select())
        {
            if (i == 0)
            {
                wrap += "<li style=\"position: absolute; z-index: 1; opacity: 1;\" class=\"panel-selected\">";
                trigger += "<a href=\"javascript:void(0)\" class=\"auc_slider_trigger curr\"></a>";
            }
            else
            {
                wrap += "<li style=\"position: absolute; z-index: 0; opacity: 0;\">";
                trigger += "<a href=\"javascript:void(0)\" class=\"auc_slider_trigger\"></a>";
            }
            wrap += "<div class=\"l_wrap\"><div class=\"l_inner\"><a href=\"" + rs["url"].ToString() + "\" target=\"_blank\">";
            wrap += "<img src=\"" + rs["ImgS"].ToString().Replace("~/", "") + "\" width=\"1920\" height=\"360\" alt=\"" + rs["Description"].ToString() + "\" class=\"err-product\" />";
            wrap += "</div></div></li>";

            i++;
        }
        ds.Clear();
        ds.Dispose();
        str += wrap + "</ul></div>" + trigger + "</div></div>";
        return str;
    }

    protected string wrap_navitems()
    {
        int i = 0;
        string str = string.Empty;
        DataSet ds = DBHelp.DataSet_ds("select top 6 [title],[url],[CloseS] from [e_navigation] where [CloseS]<>1 order by [Stat],[Number]", "@value");
        foreach (DataRow rs in ds.Tables["@value"].Select())
        {
            if( i == 0)
                str += "<li class=\"fore" + i + " hover\"><a href=\"" + rs["url"].ToString() + "\">" + rs["title"].ToString() + "</a></li>";
            else
                str += "<li class=\"fore" + i + "\"><a href=\"" + rs["url"].ToString() + "\" target=\"_blank\">" + rs["title"].ToString() + "</a></li>";

            i++;
        }
        ds.Clear();
        ds.Dispose();
        return str;
    }
    protected string wrap_ads_flash()
    {
        int i = 0;
        string str = string.Empty;
        DataSet ds = DBHelp.DataSet_ds("select top 5 [upid],[url],[ImgS],[title],[Description],[CloseS] from [e_ads_flash] where [CloseS]<>1 order by [Stat],[Number]", "@value");
        foreach (DataRow rs in ds.Tables["@value"].Select())
        {
            i++;
            str += "<li class=\"fore" + i + "\"><a href=\"" + rs["url"].ToString() + "\" target=\"_blank\">";
            str += "<img src=\"" + rs["ImgS"].ToString().Replace("~/", "") + "\" width=\"234\" height=\"220\" alt=\"" + rs["Description"].ToString() + "\"  class=\"err-product\" />";
            str += "</a></li>";
        }
        ds.Clear();
        ds.Dispose();
        return str;
    }

    protected string wrap_hotwords()
    {
        string str = string.Empty;
        DataSet ds = DBHelp.DataSet_ds("select top 6 [Number],[keywords],[hot] from [e_keydata] where [CloseS]<>1 and [Reded]=1 order by [Stat],[Number]", "@value");
        foreach (DataRow rs in ds.Tables["@value"].Select())
        {
            string keys = rs["keywords"].ToString();
            if (rs["hot"].ToString() == "1")
                str += "<a href=\"search.aspx?keys=" + keys + "\" class=\"style-red\">" + keys + "</a>";
            else
                str += "<a  href=\"search.aspx?keys=" + keys + "\">" + keys + "</a>";
        }
        ds.Clear();
        ds.Dispose();
        return str;
    }

    protected string wrap_helplist()
    {
        string str = string.Empty;
        string item_count = string.Empty, sub_item = item_count;
        str += "<div class=\"help-list\">";
        DataSet ds1 = DBHelp.DataSet_ds("select [Number],[upid],[title],[CloseS] from [e_helplist] where [CloseS]<>1 and [upid]='0' order by [Stat],[Number]", "@value");
        foreach (DataRow rs1 in ds1.Tables["@value"].Select())
        {
            str += "<dl><dt>" + rs1["title"].ToString() + "</dt>";
            DataSet ds2 = DBHelp.DataSet_ds("select [Number],[upid],[title],[CloseS],[Reded] from [e_helplist] where [CloseS]<>1 and [upid]='" + rs1["Number"].ToString() + "' order by [Stat],[Number]", "@value");
            foreach (DataRow rs2 in ds2.Tables["@value"].Select())
            {
                str += "<dd><a href=\"#\" target=\"_blank\">" + rs2["title"].ToString() + "</a></dd>";
            }
            ds2.Clear();
            ds2.Dispose();
            str += "</dl>";
        }
        ds1.Clear();
        ds1.Dispose();
        return str + "</div>";
    }

    protected string wrap_recomyou()
    {
        string str = string.Empty;
        int i = 0;
        DataSet ds = DBHelp.DataSet_ds("select top 6 [Number],[upid],[upids],[emid],[title],[price],[ImgS] from [e_goods] where [CloseS]<>1 and [Reded]=1 and [hot] = 1 order by [Stat],[Number]", "@value");
        foreach (DataRow rs in ds.Tables["@value"].Select())
        {
            i++;
            str += "<li class=\"fore" + i + "\">";
            str += "<div class=\"p-img\"><a href=\"item.aspx?id=" + rs["emid"].ToString() + "\" target=\"_blank\">";
            str += "<img src=\"Apply/avatar.aspx?Type=fixnone&size=130x130&key=" + rs["Imgs"].ToString() + "\" width=\"130\" height=\"130\" title=\"" + rs["title"].ToString() + "\" class=\"err-product\" />";
            str += "</a></div><div class=\"p-info\"><div class=\"p-name\">";
            str += "<a href=\"item.aspx?id=" + rs["emid"].ToString() + "\" target=\"_blank\" title=\"" + rs["title"].ToString() + "\">" + rs["title"].ToString() + "</a>";
            str += "</div><div class=\"p-price\"><i>¥</i>" + MR(rs["price"].ToString()) + "</div></div></li>";
        }
        ds.Clear();
        ds.Dispose();
        return str;
    }

    protected string wrap_floorList(string title)
    {
        string str = string.Empty;
        int i = 0;
        string cateNum = DBHelp.fr_string("select [Number] from [e_goods_cate] where [title]='" + title + "'");
        string sql = "select top 12 [Number],[upid],[upids],[emid],[title],[price],[ImgS] from [e_goods] where [CloseS]<>1 and [Reded]=1 and [upid]='" + cateNum + "' order by [Stat],[Number]";
        str = "<ul>";
        DataSet ds = DBHelp.DataSet_ds(sql, "@value");
        foreach (DataRow rs in ds.Tables["@value"].Select())
        {
            i++;
            if (i > 7) { str += "</ul><ul>"; i = 1; }

            str += "<li class=\"fore" + i + "\">";
            str += "<div class=\"p-img\"><a href=\"item.aspx?id=" + rs["emid"].ToString() + "\" target=\"_blank\">";
            str += "<img src=\"Apply/avatar.aspx?Type=fixnone&size=130x130&key=" + rs["Imgs"].ToString() + "\" width=\"130\" height=\"130\" title=\"" + rs["title"].ToString() + "\"  class=\"err-product\"/>";
            str += "</a></div><div class=\"p-info\"><div class=\"p-name\">";
            str += "<a href=\"item.aspx?id=" + rs["emid"].ToString() + "\" target=\"_blank\" title=\"" + rs["title"].ToString() + "\">" + rs["title"].ToString() + "</a>";
            str += "</div><div class=\"p-price\"><i>¥</i>" + MR(rs["price"].ToString()) + "</div></div></li>";
        }
        ds.Clear();
        ds.Dispose();
        str += "</ul>";
        return str;
    }
}