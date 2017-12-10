using System;
using System.Data;
using System.Web.UI.WebControls;
using ask;

public partial class admin_system_Admin : System.Web.UI.Page
{
    public string admin = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RepBind();
            admin = Request.QueryString["admin"];
            if (admin == "admin")
                admin = "<script type=\"text/javascript\">Re.zOpen('&admin=admin','操作员添加');</script>";
        }
    }
    protected void RepBind()
    {
        DataBindManager.REP(this.Repeater1, "select [Number],[upid],[Rank],[Aname],[RealityName],[CloseS],[Atime] from [e_admin]");
    }

    protected string RepBound(object sender)
    {
        if (sender.ToString() == logRoles() || sender.ToString() == "A2014080711250001")
            return "3";
        else
            return "1";
    }
    protected string logRoles()
    {
        if (Request.Cookies["loginInfoSxmy"] != null)
        {
            if (Request.Cookies["loginInfoSxmy"]["Number"] != null)
            {
                return Request.Cookies["loginInfoSxmy"]["Number"];
            }
        }
        return string.Empty;
    }
    public string Rank(object upid, object upid1)
    {
        string str = "";
        if (upid1.ToString() != "0")
            str = Rankupid(upid1.ToString());
        else
        {
            if (!string.IsNullOrEmpty(upid.ToString()) && upid != "0")
                str = DBHelp.fr_string("select [Aname] from [e_admin] where [Number]='" + upid + "'");
            else
                str = "未指定操作员";
        }
        return str;
    }
    public string Rankupid(string upid)
    {
        switch (upid)
        {
            case "1":
                return "超级操作员";
            case "2":
                return "一级操作员";
            case "3":
                return "二级操作员";
            case "4":
                return "三级操作员";
            default:
                return "四级操作员";
        }
    }
}
