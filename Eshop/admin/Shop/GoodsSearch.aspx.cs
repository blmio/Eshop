using System;
using System.Data;
using ask;

public partial class admin_Shop_GoodsSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected string select()
    {
        string str = string.Empty;
        DataSet ds = DBHelp.DataSet_ds("select [Number],[title] from [e_goods_cate] where [CloseS]<>1 and [upid]='0' order by [Stat],[Number]", "@value");
        foreach (DataRow rs in ds.Tables["@value"].Select())
        {
            str += "<option value=\"" + rs["Number"] + "\">" + rs["title"] + "</option>";
        }
        ds.Clear();
        ds.Dispose();
        return str;
    }
}