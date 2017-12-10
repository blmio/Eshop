using System;
using System.Data;
using System.Web.UI.WebControls;
using ask;

public partial class admin_user_Member : System.Web.UI.Page
{
    public string upid, admin, sm;
    public int mi = 0, age = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        admin = Request.QueryString["admin"];
        //编号
        string Pa = Request.QueryString["Page"];
        int.TryParse(Pa, out age); if (age < 1) age = 1; if (age != 1) age = 16 * (age - 1) + 1;
        //条件
        string Where = string.Empty;
        upid = Request.QueryString["upid"];
        if (!string.IsNullOrEmpty(upid)) Where += "[upid]='" + upid + "'";
        //会员查询条件
        sm = Request.QueryString["sm"];
        if (sm == "pp") {
            string[] request = Request.RawUrl.Split('&')[1].Split('=');
            Where += " and [" + request[0] + "]='" + request[1] + "'";
        }

        this.PageAd1.TableName = "[e_member]";
        this.PageAd1.Fieldcolumn = "[Number],[Name],[Password],[NickName],[Sex],[Lotimes],[CloseS],[Atime]";
        this.PageAd1.Field = "[Number]";
        this.PageAd1.Order = "order by [Atime] desc,[Number] desc";
        this.PageAd1.Url = "Member.aspx";
        this.PageAd1.Where = Where;
        this.PageAd1.Repe = this.Repeater1;
        this.PageAd1.PageSize = 15;
        this.PageAd1.NoCh = this.NoCh;
    }
    protected string ET(object Dt)
    {
        string str = string.Empty;
        if (Dt != null) str = Dt.ToString();
        if (!string.IsNullOrEmpty(str))
            str = str.Replace("/", "-");
        return str;
    }
    public int miT(int mi) { return mi + age; }
    protected string Decrypt(object Pa) { return ask.Web.EncryptHelper.Decrypt(Pa.ToString()); }
}