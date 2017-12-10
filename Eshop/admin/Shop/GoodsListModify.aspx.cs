using System;
using System.Data;
using System.Web;
using ask;

public partial class admin_Shop_GoodsListModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            daohang_bind();
        else
            Bu_Click();
    }
    protected void daohang_bind()
    {
        string id = Request.QueryString["Number"];
        this.upid.Text = Request.QueryString["upid"];
        if (!string.IsNullOrEmpty(id))
        {
            DataSet ds = DBHelp.DataSet_ds("select [Number],[upid],[title],[ImgS],[CloseS],[Reded],[Stat] from [e_goods_pic] where [Number]='" + id + "'", "@value");
            foreach (DataRow rs in ds.Tables["@value"].Select())
            {
                this.lblID.Text = rs["Number"].ToString();
                this.upid.Text = rs["upid"].ToString();
                this.title.Text = rs["title"].ToString();
                this.ImgS.Text = rs["ImgS"].ToString();
                this.Stat.Text = rs["Stat"].ToString();
                if (rs["CloseS"].ToString() == "1")
                    this.CloseS.Checked = true;
                else
                    this.CloseS.Checked = false;
            }
            ds.Clear();
            ds.Dispose();
        }
    }
    protected string R(string t) { return Request.Form[t]; }
    /// <summary>
    /// 增加和修改
    /// </summary>
    protected void Bu_Click()
    {
        string Number = this.lblID.Text;
        if (string.IsNullOrEmpty(Number)) Number = R("Number");
        if (string.IsNullOrEmpty(Number)) Number = IdNumber.NumberSman("e_goods_pic", "P");
        string ImgSd;
        if (!string.IsNullOrEmpty(this.FImgS.FileName))
        {
            ImgSd = shopfile.FileGet(this.FImgS, Number, "~/upload/list", 50000000);
        }
        else
        {
            ImgSd = ImgS.Text;
        }

        string tat = this.Stat.Text;
        int m = 0;
        int.TryParse(tat, out m);
        if (m < 1) m = 1; tat = m.ToString();

        if (!string.IsNullOrEmpty(this.lblID.Text))
        {
            string[] Text = { "upid", "Stat", "ImgS" };
            string[] Value = { this.upid.Text, tat, ImgSd };
            if (UpdateClass.fromUpdate("e_goods_pic", "title", "CloseS", Text, Value, this.form1, " [Number]='" + this.lblID.Text + "'")){
                jsFontcion.listload();
            }
            else
                jsFontcion.ResponseW("修改操作出错");
        }
        else
        {
            if (string.IsNullOrEmpty(tat) || tat == "1")
                tat = config.Sort_max("select max(stat) from [e_goods_pic] where [upid]='" + this.upid.Text + "'").ToString();
            string[] Text = { "Number", "upid", "Stat", "ImgS"};
            string[] Value = { Number, this.upid.Text, tat, ImgSd};
            if (AddClass.fromAdd("e_goods_pic", "title", "CloseS", Text, Value, this.form1)) {
                jsFontcion.listload();
            }
            else
                jsFontcion.ResponseW("添加操作出错");
        }
    }
}