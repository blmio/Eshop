using System;
using System.Data;
using ask;

public partial class Apply_Dselect : System.Web.UI.Page
{
    string from, typeID, typeName, where, Number, and = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        string HTML = Request.QueryString["HTML"];
        if (string.IsNullOrEmpty(HTML)) HTML = "|";
        from = Request.QueryString["from"];
        typeID = Request.QueryString["typeID"];
        typeName = Request.QueryString["typeName"];
        where = Request.QueryString["where"];
        Number = Request.QueryString["Number"];
        and = Request.QueryString["and"];
        int i = 0;
        if (!string.IsNullOrEmpty(Number))
        {
            if (string.IsNullOrEmpty(typeID))
            {
                DataSet ds = DBHelp.DataSet_ds("select [" + typeName + "] from [" + from + "] where [" + where + "]='" + Number + "'" + and + " order by [Stat],[Number]", "@value");
                foreach (DataRow rs in ds.Tables["@value"].Select())
                {
                    if (i != 0)
                        Response.Write(HTML);
                    Response.Write(rs[typeName].ToString() + "," + rs[typeName].ToString());
                    i++;
                }
                ds.Clear();
                ds.Dispose();
            }
            else
            {
                DataSet ds = DBHelp.DataSet_ds("select [" + typeID + "],[" + typeName + "] from [" + from + "] where [" + where + "]='" + Number + "'" + and + " order by [Stat],[Number]", "@value");
                foreach (DataRow rs in ds.Tables["@value"].Select())
                {
                    if (i != 0)
                        Response.Write(HTML);
                    Response.Write(rs[typeName].ToString() + "," + rs[typeID].ToString());
                    i++;
                }
                ds.Clear();
                ds.Dispose();
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(typeID))
            {
                DataSet ds = DBHelp.DataSet_ds("select [" + typeID + "],[" + typeName + "] from [" + from + "]" + and + " order by [Stat],[Number]", "@value");
                foreach (DataRow rs in ds.Tables["@value"].Select())
                {
                    if (i != 0)
                        Response.Write(HTML);
                    Response.Write(rs[typeName].ToString() + "," + rs[typeID].ToString());
                    i++;
                }
                ds.Clear();
                ds.Dispose();
            }
            else
            {
                DataSet ds = DBHelp.DataSet_ds("select [" + typeName + "] from [" + from + "]" + and + " order by [Stat],[Number]", "@value");
                foreach (DataRow rs in ds.Tables["@value"].Select())
                {
                    if (i != 0)
                        Response.Write(HTML);
                    Response.Write(rs[typeName].ToString() + "," + rs[typeName].ToString());
                    i++;
                }
                ds.Clear();
                ds.Dispose();
            }
        }
    }
}
