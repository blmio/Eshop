using System;
using System.Collections.Generic;
using System.Web;
using ask;

public partial class admin_system_AdsPicModify : System.Web.UI.Page
{
    string R(string t) { return Request.Form[t]; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            lunbo_bind();
        else
            Bu_Click();
    }

    protected void lunbo_bind()
    {
        string Number = Request.QueryString["Number"];
        if (!string.IsNullOrEmpty(Number))
        {
            string sql = "[Number],[url],[ImgS],[title],[Description],[CloseS],[Reded],[Stat]";
            string[] ds = DBHelp.frS_string("select " + sql + " from [e_ads_flash] where [Number]='" + Number + "'");
            this.lblID.Text = Number;
            this.title.Text = ds[3];
            this.url.Text = ds[1];
            this.ImgS.Text = ds[2];
            this.Description.Text = ds[4];

            if (ds[5] == "1")
                this.CloseS.Checked = true;
            else
                this.CloseS.Checked = false;
            if (ds[6] == "1")
                this.Reded.Checked = true;
            else
                this.Reded.Checked = false;
        }
    }

    protected void Bu_Click()
    {
        string Number = this.lblID.Text;
        if (string.IsNullOrEmpty(Number))
            Number = IdNumber.NumberSman("e_ads_flash", "A");
        string Imgad = string.Empty;
        if (!string.IsNullOrEmpty(this.FImgS.FileName))
            Imgad = shopfile.FileGet(this.FImgS, "bxite-" + Number, "~/upload/ads_flash", 50000000);
        else
            Imgad = ImgS.Text;
        string[] Text = { "ImgS", "Description" };
        string[] Value = { Imgad, Description.Text };
        if (!string.IsNullOrEmpty(this.lblID.Text))
        {
            if (UpdateClass.fromUpdate("e_ads_flash", "title|url", "CloseS|Reded", Text, Value, this.form1, " [Number]='" + this.lblID.Text + "'"))
                Cleload(this.lblID.Text);
            else
                jsFontcion.ResponseW("修改操作出错");
        }
        else
        {
            int stat = config.Sort_max("select max(Stat) from [e_ads_flash] ");
            Text = new string[] { "Number", "ImgS", "Description", "Stat" };
            Value = new string[] { Number, Imgad, Description.Text, stat + "" };
            if (AddClass.fromAdd("e_ads_flash", "title|url", "CloseS|Reded", Text, Value, this.form1))
                Cleload(Number);
            else
                jsFontcion.ResponseW("添加操作出错");
        }
    }

    protected void Cleload(string Nber)
    {
        if (this.Reded.Checked == true)
        {
            DBHelp.insert("e_ads_flash", "[Reded]=0", "[Number]<>'" + Nber + "'");
        }
        jsFontcion.Cleload();
    }
}