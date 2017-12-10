using System;
using System.Data;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using ask;

public partial class admin_system_AdminModify : System.Web.UI.Page
{
    string id;
    public string adminD = "1";
    string url, admin;
    protected void Page_Load(object sender, EventArgs e)
    {
        admin = Request.QueryString["admin"];
        if (!IsPostBack)
        {
            ViewState["Aname"] = "";
            DataBindAd();
        }
        else
        {
            url = strFunction.url("~/admin/system/AdminModify.aspx?s=s");
            if (admin == "admin") url += "&admin=admin";
            Ima_Click();
        }
    }
    private void DataBindAd()
    {
        id = Request.QueryString["Number"];
        if (admin == "admin") id = thisUInRsid("Number");
        if (!string.IsNullOrEmpty(id) && id != "0")
        {
            adminD = "0";
            lblID.Text = id;
            DataSet ds = DBHelp.DataSet_ds("select [Aname],[RealityName],[Apasswoid] from [e_admin] where [Number]='" + id + "'", "@value");
            foreach (DataRow row in ds.Tables["@value"].Select())
            {
                this.TAname.Text = row["Aname"].ToString();
                ViewState["Aname"] = this.TAname.Text;
                this.TRealityName.Text = row["RealityName"].ToString();
                this.LApasswoid.Text = row["Apasswoid"].ToString();
            }
            ds.Clear();
            ds.Dispose();
        }
    }

    private string thisUInRsid(string UInR)
    {
        if (Request.Cookies["loginInfoSxmy"] != null)
        {
            if (Request.Cookies["loginInfoSxmy"][UInR] != null && Request.Cookies["loginInfoSxmy"][UInR] != null)
            {
                return Request.Cookies["loginInfoSxmy"][UInR];
            }
        }
        return string.Empty;
    }

    protected void Ima_Click()
    {
        N_Members us = new N_Members();
        us.CloseS = 0;
        us.Rank = 0;
        string up = thisUInRsid("Number");
        if (!string.IsNullOrEmpty(up))
            us.Upid = up;
        else
            us.Upid = "0";
        us.Aname = strFunction.check_input(this.TAname.Text);
        us.RealityName = strFunction.check_input(this.TRealityName.Text);
        us.Apasswoid = strFunction.check_input(this.TApasswoid2.Text);
        if (!DBHelp.fr_bool("select [Number] from [e_admin] where [Aname]='" + us.Aname + "'"))
        {
            Buttond(us);
        }
        else
        {
            string use = ViewState["Aname"].ToString();
            if (use == us.Aname)
                Buttond(us);
            else
                jsFontcion.ResponseW("用户已存在,不能重复！");
        }
    }

    protected void Buttond(N_Members us)
    {
        string password1 = this.TApasswoid1.Text;
        id = lblID.Text;
        if (!string.IsNullOrEmpty(id) && id != "0")
        {
            us.Number = id;
            if (us.Apasswoid == password1 && us.Aname != "")
            {
                if (us.Apasswoid != "" && password1 != null)
                {
                    string Apasswoid = ask.Web.EncryptHelper.Encrypt(this.TApasswoid.Text);
                    if (Apasswoid != this.LApasswoid.Text)
                    {
                        jsFontcion.ResponseW("旧密码不正确！");
                    }
                    else
                    {
                        if (us.Apasswoid != password1)
                        {
                            jsFontcion.ResponseW("确认密码不正确！");
                        }
                        else
                        {
                            if (Members.UpdateAdmin(us))
                            {
                                if (thisUInRsid("Aname") == us.Aname)
                                {
                                    Response.Cookies["UserSettings"]["Aname"] = "";
                                    jsFontcion.Reloade();
                                }
                                else
                                {
                                    jsFontcion.Cleload();
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (us.Apasswoid == "" && password1 == "" && us.Aname != "")
                    {
                        if (Members.UpdateAdminA(us))
                        {
                            if (thisUInRsid("Aname") == us.Aname)
                            {
                                Response.Cookies["UserSettings"]["Aname"] = "";
                                jsFontcion.Reloade();
                            }
                            else
                            {
                                jsFontcion.Cleload();
                            }
                        }
                    }
                    else
                        jsFontcion.ResponseW("请认真填写管理员信息！");
                }
            }
            else
                jsFontcion.ResponseW("请认真填写管理员信息！");
        }
        else
        {
            if (us.Apasswoid == password1 && us.Aname != "")
            {
                if (us.Apasswoid != password1)
                {
                    jsFontcion.ResponseW("确认密码不正确！");
                }
                else
                {
                    if (Members.InsertAdmin(us))
                    {
                        jsFontcion.Cleload();
                    }
                }
            }
            else
                jsFontcion.ResponseW("请认真填写管理员信息！");
        }
    }
}