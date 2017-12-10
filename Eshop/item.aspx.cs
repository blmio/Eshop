using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using ask;

public partial class item : System.Web.UI.Page
{
    protected string[] Vt = new string[12];
    protected string goodId;
    protected int totalAppra = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        goodId = Request.QueryString["id"];
        string sql = "select [Number],[upid],[upids],[emid],[title],[subtitle],[price],[ImgS],[BuyT],[Content],[PackList],[CloseS],[hot] from [e_goods]", where = " where [CloseS]<>1";
        if (!string.IsNullOrEmpty(goodId))
        {
            if (!string.IsNullOrEmpty(goodId)) where += "and [emid]='" + goodId + "'";
            Vt = DBHelp.frS_string(sql + where);
            if (Vt == null)
                Response.Redirect("error.aspx?tip=无此商品信息！");
            else
                DBHelp.insert("e_goods", "[ScanT]=[ScanT]+1", "[emid]='" + goodId + "'");
            totalAppra = config.DataCount("select [Number] from [e_appra] where [emid]='" + goodId + "'");
        }
        else
            Response.Redirect("error.aspx?tip=无此商品信息！");
    }
    protected string top() { return ask.Web.Comway.top(); }
    protected string footer() { return ask.Web.Comway.footer(); }
    protected string goTop() { return ask.Web.Comway.goTop(); }
    protected string refrCart() { return ask.Web.Comway.refrCart(); }
    protected string wrap_navitems()
    {
        int i = 0;
        string str = string.Empty;
        DataSet ds = DBHelp.DataSet_ds("select top 6 [upid],[title],[url],[CloseS] from [e_navigation] where [CloseS]<>1 order by [Stat],[Number]", "@value");
        foreach (DataRow rs in ds.Tables["@value"].Select())
        {
            i++;
            str += "<li class=\"fore" + i + "\"><a href=\"" + rs["url"].ToString() + "\" target=\"_blank\">" + rs["title"].ToString() + "</a></li>";
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

    protected string wrap_reco()
    {
        string str = string.Empty;
        int i = 0;
        DataSet ds = DBHelp.DataSet_ds("select top 6 [Number],[upid],[upids],[emid],[title],[price],[ImgS] from [e_goods] where [CloseS]<>1 and [Reded]=1 and [hot] = 1 and [upid]='" + Vt[1] + "' order by [Stat],[Number]", "@value");
        foreach (DataRow rs in ds.Tables["@value"].Select())
        {
            i++;
            str += "<li class=\"fore" + i + "\">";
            str += "<div class=\"p-img\"><a href=\"item.aspx?id=" + rs["emid"].ToString() + "\" target=\"_blank\">";
            str += "<img src=\"Apply/avatar.aspx?Type=fixnone&size=160x160&key=" + rs["Imgs"].ToString() + "\" width=\"160\" height=\"160\" title=\"" + rs["title"].ToString() + "\" class=\"err-product\" />";
            str += "</a></div><div class=\"p-name\">";
            str += "<a href=\"item.aspx?id=" + rs["emid"].ToString() + "\" target=\"_blank\" title=\"" + rs["title"].ToString() + "\">" + rs["title"].ToString() + "</a>";
            str += "</div><div class=\"p-info p-bfc\"><div class=\"p-price\"><strong><i>¥</i>" + rs["price"].ToString() + "</strong></div></div></li>";
        }
        ds.Clear();
        ds.Dispose();
        return str;
    }
    protected string MR(object pic) { return ask.Web.AppInf.MR(pic); }
    protected string wrap_parameter()
    {
        string str = string.Empty;
        string[] info = new string[] { };
        if (!string.IsNullOrEmpty(Vt[9]))
        {
            str = "<div class=\"p-parameter\"><ul id=\"parameter2\" class=\"p-parameter-list\">";
            info = Vt[9].Split('|');
            foreach (string subinfo in info)
            {
                if (!string.IsNullOrEmpty(subinfo))
                {
                    string[] subArr = subinfo.Split('\\');
                    str += "<li title=\"" + subArr[1] + "\">" + subArr[0] + "：" + subArr[1] + "</li>";
                }

            }
            str += "</ul></div>";
        }
        return str;
    }
    protected string wrap_detail()
    {
        string str = string.Empty;
        string[] info = new string[] { };
        str = "<div class=\"detail-content clearfix\"><div class=\"detail-content-wrap\"><div class=\"detail-content-item\">";
        DataSet ds = DBHelp.DataSet_ds("select [Number],[upid],[title],[ImgS] from [e_goods_pic] where [upid]='" + Vt[0] + "' order by [Stat],[Number]", "@value");
        foreach (DataRow rs in ds.Tables["@value"].Select())
        {
            str += "<img src=\"" + rs["ImgS"].ToString().Replace("~/", "") + "\" alt=\"" + rs["title"].ToString() + "\" class=\"err-product\">";
        }
        str += "</div></div></div>";
        return str;
    }

    protected string wrap_breadcrumb()
    {
        string str = string.Empty;
        string crumb = DBHelp.fr_string("select [title] from [e_goods_cate] where [Number]='" + Vt[1] + "'");
        string subCrumb = DBHelp.fr_string("select [title] from [e_goods_cate] where [Number]='" + Vt[2] + "'");
        str += "<strong><a href=\"default.aspx\">" + crumb + "</a></strong>";
        str += "<span>&nbsp;&gt;&nbsp;<a href=\"search.aspx?keys=" + subCrumb + "\">" + subCrumb + "</a><span>";
        str += "<span>&nbsp;&gt;&nbsp;<a href=\"item.aspx?id=" + Vt[3] + "\">" + Vt[4] + "</a><span>";
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


    protected string wrap_appra()
    {
        string str = string.Empty, all = str, good = str, middle = str, bad = str;
        int acount = 0, bcount = 0, mcount = 0, gcount = 0;
        string title = "<div class=\"com-table-header\"> <span class=\"item column1\">评价心得</span> <span class=\"item  column2\">评价等级</span> <span class=\"item column3\">购买时间</span> ";
        title += "<span class=\"item column4\">评论 者</span> </div><div class=\"com-table-main\"><div class=\"comments-item\">";
        all = "<div id=\"comment-0\" class=\"mc ui-comments-panel comments-table ui-comments-panel-selected\" style=\"display:block\">" + title;
        good = "<div id=\"comment-1\" class=\"mc hide ui-comments-panel comments-table\" style=\"display:none;\" >" + title;
        middle = "<div id=\"comment-2\" class=\"mc hide ui-comments-panel comments-table\" style=\"display:none;\" >" + title;
        bad = "<div id=\"comment-3\" class=\"mc hide ui-comments-panel comments-table\" style=\"display:none;\" >" + title;

        DataSet ds = DBHelp.DataSet_ds("select [upid],[emid],[Name],[title],[Level],[Content],[buyTime],[Atime] from [e_appra] where [CloseS]<>1 order by [Stat] desc,[Atime] desc", "@value");
        foreach (DataRow rs in ds.Tables[0].Select())
        {

            all += "<ul class=\"clearfix\"><li class=\"item1\"> <span>" + rs["Content"].ToString() + "</span> <b>" + rs["Atime"].ToString() + "</b> </li>";
            all += "<li class=\"item2\"> <span>" + checkLevel(rs["Level"].ToString()) + "</span> </li><li class=\"item3\"> <span>" + rs["buyTime"].ToString() + "</span>";
            all += "</li><li class=\"item4\"> <span>" + rs["Name"].ToString() + "</span> </li></ul>";
            if (rs["Level"].ToString() == "2")
            {
                bad += "<ul class=\"clearfix\"><li class=\"item1\"> <span>" + rs["Content"].ToString() + "</span> <b>" + rs["Atime"].ToString() + "</b> </li>";
                bad += "<li class=\"item2\"> <span>" + checkLevel(rs["Level"].ToString()) + "</span> </li><li class=\"item3\"> <span>" + rs["buyTime"].ToString() + "</span>";
                bad += "</li><li class=\"item4\"> <span>" + rs["Name"].ToString() + "</span> </li></ul>";
                bcount++;
            }
            else if (rs["Level"].ToString() == "1")
            {
                middle += "<ul class=\"clearfix\"><li class=\"item1\"> <span>" + rs["Content"].ToString() + "</span> <b>" + rs["Atime"].ToString() + "</b> </li>";
                middle += "<li class=\"item2\"> <span>" + checkLevel(rs["Level"].ToString()) + "</span> </li><li class=\"item3\"> <span>" + rs["buyTime"].ToString() + "</span>";
                middle += "</li><li class=\"item4\"> <span>" + rs["Name"].ToString() + "</span> </li></ul>";
                mcount++;
            }
            else
            {
                good += "<ul class=\"clearfix\"><li class=\"item1\"> <span>" + rs["Content"].ToString() + "</span> <b>" + rs["Atime"].ToString() + "</b> </li>";
                good += "<li class=\"item2\"> <span>" + checkLevel(rs["Level"].ToString()) + "</span> </li><li class=\"item3\"> <span>" + rs["buyTime"].ToString() + "</span>";
                good += "</li><li class=\"item4\"> <span>" + rs["Name"].ToString() + "</span> </li></ul>";
                gcount++;
            }
            acount++;
        }
        ds.Clear();
        ds.Dispose();

        str += "<div id=\"comments-list\" class=\"m\"><div class=\"mt\"><div class=\"mt-inner m-tab-trigger-wrap clearfix\">";
        str += "<ul class=\"m-tab-trigger\"><li class=\"ui-comments-item trig-item curr\" ><a href=\"javascript:;\">全部评价<em>(" + acount + ")</em></a></li>";
        str += "<li class=\"ui-comments-item trig-item\" ><a href=\"javascript:;\">好评<em>(" + gcount + ")</em></a></li>";
        str += "<li class=\"ui-comments-item trig-item\" ><a href=\"javascript:;\">中评<em>(" + mcount + ")</em></a></li>";
        str += "<li class=\"ui-comments-item trig-item\" ><a href=\"javascript:;\">差评<em>(" + bcount + ")</em></a></li></ul></div></div>";

        str += all + "</div></div></div>" + good + "</div></div></div>" + middle + "</div></div></div>" + bad + "</div></div></div></div>";
        return str;
    }

    protected string checkLevel(string Level)
    {
        if (Level == "2")
            return "差评";
        else if (Level == "1")
            return "中评";
        else
            return "好评";
    }
}