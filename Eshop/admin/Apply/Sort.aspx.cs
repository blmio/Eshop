using System;
using System.Data;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using ask;

public partial class admin_Apply_Sort : System.Web.UI.Page
{
    string from, sql, id, isSort;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
            SortBind();
        else
            btnSort_Click();
    }
    protected void SortBind()
    {
        from = Request.QueryString["from"];
        id = Request.QueryString["id"];
        isSort = Request.QueryString["isSort"];
        if (string.IsNullOrEmpty(isSort))
        {
            isSort = "Stat";
        }
        if (id != null && id != "" && from != null)
        {
            this.txtSort.Text = DBHelp.fr_string("select [" + isSort + "] from [" + from + "] where [Number]='" + id + "'");
        }
        else
        {
            Response.Redirect(".");
        }
    }
    protected void btnSort_Click()
    {
        string Sort = this.txtSort.Text;
        long i = 0;
        if (long.TryParse(Sort, out i))
        {
            from = Request.QueryString["from"];
            id = Request.QueryString["id"];
            isSort = Request.QueryString["isSort"];
            if (string.IsNullOrEmpty(isSort))
            {
                isSort = "Stat";
            }
            sql = "[" + isSort + "]=" + Sort;
            if (DBHelp.insert(from, sql, "[Number]='" + id + "'"))
            {
                jsFontcion.Cleload();
            }
        }
    }

}