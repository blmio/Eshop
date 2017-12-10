using System;
using System.Collections.Generic;
using System.Data;
using ask;

public partial class admin_Shop_GoodsInfoModify : System.Web.UI.Page
{
    protected string[] Vt = new string[6];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            daohang_bind();
        else
            Bu_Click();
    }

    protected string select(string upid)
    {
        string str = string.Empty;
        DataSet ds = DBHelp.DataSet_ds("select [Number],[title] from [e_goods_cate] where [CloseS]<>1 and [upid]='0' order by [Stat],[Number]", "@value");
        foreach (DataRow rs in ds.Tables["@value"].Select())
        {
            if (upid == rs["Number"].ToString())
                str += "<option value=\"" + rs["Number"] + "\" selected>" + rs["title"] + "</option>";
            else
                str += "<option value=\"" + rs["Number"] + "\">" + rs["title"] + "</option>";
        }
        ds.Clear();
        ds.Dispose();
        return str;
    }

    protected void daohang_bind()
    {
        Vt[1] = Request.QueryString["upid"];
        Vt[2] = Request.QueryString["upids"];
        string id = Request.QueryString["Number"];
        if (!string.IsNullOrEmpty(id))
        {
            DataSet ds = DBHelp.DataSet_ds("select [Number],[upid],[upids],[emid],[title],[subtitle],[price],[ImgS],[BuyT],[ScanT],[sitetitle],[Keywords],[Description],[Content],[ImgInfo],[PackList],[CloseS],[Reded],[hot] from [e_goods] where [Number]='" + id + "'", "@value");
            foreach (DataRow rs in ds.Tables["@value"].Select())
            {
                this.lblID.Text = rs["Number"].ToString();
                Vt[0] = rs["Number"].ToString();
                Vt[1] = rs["upid"].ToString();
                Vt[2] = rs["upids"].ToString();

                this.title.Text = rs["title"].ToString();
                this.subtitle.Text = rs["subtitle"].ToString();
                this.price.Text = MR(rs["price"].ToString());
                this.ImgS.Text = rs["ImgS"].ToString();
                this.emid.Text = rs["emid"].ToString();
                this.BuyT.Text = rs["BuyT"].ToString();
                this.ScanT.Text = rs["ScanT"].ToString();
                this.sitetitle.Text = rs["sitetitle"].ToString();
                this.PackList.Text = rs["PackList"].ToString();
                this.Keywords.Text = rs["Keywords"].ToString();
                this.Description.Text = rs["Description"].ToString();
                this.Content.Text = rs["Content"].ToString();

                if (rs["CloseS"].ToString() == "1")
                    this.CloseS.Checked = true;
                else
                    this.CloseS.Checked = false;
                if (rs["Reded"].ToString() == "1")
                    this.Reded.Checked = true;
                else
                    this.Reded.Checked = false;
                if (rs["hot"].ToString() == "1")
                    this.hot.Checked = true;
                else
                    this.hot.Checked = false;
            }
            ds.Clear();
            ds.Dispose();
        }
    }

    /// <summary>
    /// 增加和修改
    /// </summary>
    protected void Bu_Click()
    {
        string Number = this.lblID.Text, upids = Request.Form["upids"];
        if (string.IsNullOrEmpty(Number)) Number = Request.Form["Number"];
        if (string.IsNullOrEmpty(Number)) Number = IdNumber.NumberSman("e_goods", "G");
        string ImgS1 = "";
        if (!string.IsNullOrEmpty(this.FImgS.FileName))
            ImgS1 = shopfile.FileGet(this.FImgS, "bxite-" + Number, "~/upload/goods", 50000000);
        else
            ImgS1 = ImgS.Text;

        string T = "title|subtitle|emid|BuyT|ScanT|sitetitle|PackList|Keywords|Description|Content";
        string[] Text = { "upid", "ImgS",  "upids" };
        string[] Value = { Request.Form["upid"], ImgS1, upids };
        string[] mont = { "price" };
        double m = 0.00;
        double.TryParse(this.price.Text, out m);
        double[] money = { m };
        if (!string.IsNullOrEmpty(this.lblID.Text))
        {
            if (UpdateClass.fromUpdate("e_goods", T, "CloseS|Reded|hot", mont, money, Text, Value, this.form1, " [Number]='" + this.lblID.Text + "'"))
            {
                jsFontcion.Cleload();
            }
            else
                jsFontcion.ResponseW("修改操作出错");
        }
        else
        {
            int stat = 0;
            if (!string.IsNullOrEmpty(Request.Form["upid"]))
                stat = config.Sort_max("select max(Stat) from [e_goods] where [upid]='" + Request.Form["upid"] + "'");

            Text = new string[] { "upid", "Number", "Stat", "ImgS", "upids" };
            Value = new string[] { Request.Form["upid"], Number, stat.ToString(), ImgS1, upids };

            if (AddClass.fromAdd("e_goods", T, "CloseS|Reded|hot", mont, money, Text, Value, this.form1))
            {
                jsFontcion.Cleload();
            }
            else
                jsFontcion.ResponseW("添加操作出错");
        }
    }
    protected string MR(object pic) { return ask.Web.AppInf.MR(pic); }
}