using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using ask;

public partial class member_default : System.Web.UI.Page
{
    protected string number;
    protected void Page_Load(object sender, EventArgs e)
    {
        number = ask.Web.Comway.Cook("number");
        if (string.IsNullOrEmpty(number)) 
            Response.Redirect("login.aspx");

    }
    protected string top() { return ask.Web.Comway.top(); }
    protected string footer() { return ask.Web.Comway.footer(); }
    protected string goTop() { return ask.Web.Comway.goTop(); }
    protected string refrCart() { return ask.Web.Comway.refrCart(); }
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

    protected string wrap_hotwords()
    {
        string str = string.Empty;
        DataSet ds = DBHelp.DataSet_ds("select top 6 [Number],[keywords],[hot] from [e_keydata] where [CloseS]<>1 and [Reded]=1 order by [Stat],[Number]", "@value");
        foreach (DataRow rs in ds.Tables["@value"].Select())
        {
            string keys = rs["keywords"].ToString();
            if (rs["hot"].ToString() == "1")
                str += "<a href=\"../search.aspx?keys=" + keys + "\" class=\"style-red\">" + keys + "</a>";
            else
                str += "<a  href=\"../search.aspx?keys=" + keys + "\">" + keys + "</a>";
        }
        ds.Clear();
        ds.Dispose();
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
    protected string wrap_portrait()
    {
        string str = string.Empty;
        string[] value = DBHelp.frS_string("select [NickName],[UserPic] from [e_member] where [Number]='"+ number +"'");
        str += "<img src=\"../Apply/avatar.aspx?Type=fixnone&size=70x70&key="+value[1] +"\" ";
        str += "width=\"70\" height=\"70\" align=\"absmiddle\" alt=\"" + value[0] + "\" class=\"err-product portrait\"/>";
        return str;
    }
}