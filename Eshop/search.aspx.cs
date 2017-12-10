using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Data;
using ask;

public partial class search : System.Web.UI.Page
{
    protected string[] Vt = new string[] { };
    protected string name, psort;
    protected void Page_Load(object sender, EventArgs e)
    {
        psort = Request.QueryString["psort"];
        name = Request.QueryString["keys"];
        //分页
        string where = "where [CloseS] <> 1";
        string order = " order by";
        string ckName = DBHelp.fr_string("select [Number] from [e_goods] where [title] like'%" + name + "%'");
        if (!string.IsNullOrEmpty(ckName))
            where += "and [title] like'%" + name + "%'";
        else
            Response.Redirect("error.aspx?tip=" + name + "&gd=yes");

        //排序条件
        switch (psort)
        {
            case "3":
                order += "[BuyT] desc,";
                break;
            case "1":
                order += "[price],";
                break;
            case "2":
                order += "[price] desc,";
                break;
            case "4":
                order += "[ScanT] desc,";
                break;
        }
        order += "[Stat] desc,[Atime] desc";

        this.PageNum1.Repe = this.Repeater1;
        this.PageNum1.PageSize = 20;
        this.PageNum1.Field = "[Number]";
        this.PageNum1.Fieldcolumn = "[Number],[upid],[upids],[emid],[title],[subtitle],[price],[ImgS],[BuyT],[ScanT]";
        this.PageNum1.Where = where;
        this.PageNum1.TableName = "[e_goods]";
        this.PageNum1.Order = order;
        this.PageNum1.NoCh = this.NoCh;
        this.PageNum1.Url = "search.aspx";
    }
    protected string top() { return ask.Web.Comway.top(); }
    protected string footer() { return ask.Web.Comway.footer(); }
    protected string goTop() { return ask.Web.Comway.goTop(); }
    protected string refrCart() { return ask.Web.Comway.refrCart(); }
    protected string MR(object pic) { return ask.Web.AppInf.MR(pic); }
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
    protected string wrap_leftCate()
    {
        string str = string.Empty;
        string item_count = string.Empty, sub_item = item_count;
        int i = 0;
        DataSet ds1 = DBHelp.DataSet_ds("select [Number],[upid],[title] from [e_goods_cate] where [CloseS]<>1 and [upid]='0' order by [Stat],[Number]", "@value");
        foreach (DataRow rs1 in ds1.Tables["@value"].Select())
        {
            if (i < 1)
                str += " <div class=\"item fore hover\">";
            else
                str += " <div class=\"item fore\">";
            str += "<h3><b></b><a href=\"\">" + rs1["title"].ToString() + "</a> </h3><ul>";
            DataSet ds2 = DBHelp.DataSet_ds("select [Number],[upid],[title] from [e_goods_cate] where [CloseS]<>1 and [upid]='" + rs1["Number"].ToString() + "' order by [Stat],[Number]", "@value");
            foreach (DataRow rs2 in ds2.Tables["@value"].Select())
            {
                str += "<li><s></s><a href=\"search.aspx?keys=" + rs2["title"].ToString() + "\">" + rs2["title"].ToString() + "</a> </li>";
            }
            ds2.Clear();
            ds2.Dispose();
            str += "</ul></div>";
            
            i++;
        }
        ds1.Clear();
        ds1.Dispose();
        return str;
    }
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
    protected string wrap_reco()
    {
        string str = string.Empty;
        int i = 0;
        DataSet ds = DBHelp.DataSet_ds("select top 6 [Number],[upid],[upids],[emid],[title],[price],[ImgS] from [e_goods] where [CloseS]<>1 and [Reded]=1 and [title] like '%" + name + "%' order by [Stat],[Number]", "@value");
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
    protected string showImg(object path)
    {
        string str = string.Empty;
        if (path != null) str = path.ToString();
        return "Apply/avatar.aspx?Type=fixnone&size=220x220&key=" + str;
    }
    protected string showTitle(object title)
    {
        string str = string.Empty;
        int i = 0;
        Regex regex = new Regex(name);  //以name分割 
        string[] val = regex.Split(title.ToString());
        foreach(string s in val)
        {
            if(i == 0)
                str += s;
            else
                str += "<font class=\"skcolor_ljg\">" + name + "</font>" + s;
            i++;
        }
        return str;
    }
}