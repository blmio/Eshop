using System;
using System.Data;
using System.Web.UI.WebControls;
using ask;

public partial class admin_left : System.Web.UI.Page
{
    protected string mer = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        mer = Request.QueryString["mer"];
    }
    protected string PartClass(string indCase)
    {
        if (string.IsNullOrEmpty(indCase)) return "";
        string str = string.Empty;
        string[] Arr = indCase.Split(',');
        if (!string.IsNullOrEmpty(Arr[1])) Arr[1] = " and " + Arr[1];
        if (string.IsNullOrEmpty(Arr[2])) Arr[2] = "anc";
        if (string.IsNullOrEmpty(Arr[3])) Arr[3] = "?a=";
        DataSet ds = DBHelp.DataSet_ds("select [Number],[title] from [" + Arr[0] + "] where [CloseS]<>1 " + Arr[1] + " order by [Stat],[Number]", "@value");
        foreach (DataRow rs in ds.Tables["@value"].Select())
        {
            str += "<p><em class=\"" + Arr[2] + "\"></em><a href=\"" + Arr[3] + rs["Number"] + "\" target=\"comi1\">" + rs["title"] + "</a></p>";
        }
        ds.Clear();
        ds.Dispose();
        return str;
    }
}