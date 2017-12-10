using System;
using System.Data;
using System.Web.UI.WebControls;
using ask;

public partial class admin_Shop_GoodsList : System.Web.UI.Page
{
    public int mi = 0, age = 1;
    protected string upid;
    protected void Page_Load(object sender, EventArgs e)
    {
        string Pa = Request.QueryString["Page"];
        int.TryParse(Pa, out age); if (age < 1) age = 1; if (age != 1) age = 16 * (age - 1) + 1;
        upid = Request.QueryString["upid"];
        DataBindManager.REP(this.Repeater1, "select [Number],[upid],[title],[ImgS],[Stat],[CloseS] from [e_goods_pic] where [upid]='" + upid + "' order by [Stat],[Atime],[Number]");
        if (this.Repeater1.Items.Count < 1) this.NoCh.Visible = true;
    }
    public int miT(int mi) { return mi + age; }
    protected string ImgID(object ImgS, object Number)
    {
        string str = string.Empty;
        str += "<a class=\"img\" simg=\"" + ImgS + "\" id=\"IM" + Number + "\">";
        str += "<img src=\"../../image/s.gif\" style=\"";
        str += "background-image:url(../../Apply/avatar.aspx?Type=fixnone&size=25x20&key=" + ImgS + ")";
        str += "\" />";
        str += "</a>";
        return str;
    }
}