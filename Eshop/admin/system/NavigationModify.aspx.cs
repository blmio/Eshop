using System;
using System.Data;
using System.Web.UI.WebControls;
using ask;

public partial class admin_system_NavigationModify : System.Web.UI.Page
{
    protected string[] Vt = new string[3];
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
        if (!string.IsNullOrEmpty(id))
        {
            DataSet ds = DBHelp.DataSet_ds("select [Number],[title],[sitetitle],[Keywords],[Description],[url] from [e_navigation] where [Number]='" + id + "'", "@value");
            foreach (DataRow rs in ds.Tables["@value"].Select())
            {
                this.lblID.Text = rs["Number"].ToString();
                this.title.Text = rs["title"].ToString();
                this.sitetitle.Text = rs["sitetitle"].ToString();
                this.Keywords.Text = rs["Keywords"].ToString();
                this.Description.Text = rs["Description"].ToString();
                this.url.Text = rs["url"].ToString();
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
        if (!string.IsNullOrEmpty(this.lblID.Text))
        {
            if (UpdateClass.fromUpdate("e_navigation", "title|sitetitle|Keywords|Description|url", this.form1, " [Number]='" + this.lblID.Text + "'"))
                jsFontcion.Cleload();
            else
                jsFontcion.ResponseW("修改操作出错");
        }
        else
        {
            int stat = config.Sort_max("select max(Stat) from [e_navigation]");
            string Number = IdNumber.NumberSman("e_navigation", "N");
            string upid = this.title.Text == "首页" ? "1" : "0";
            string[] Text = { "Number", "upid", "Stat" };
            string[] Value = { Number, upid, stat.ToString() };
            if (AddClass.fromAdd("e_navigation", "title|sitetitle|Keywords|Description|url", Text, Value, this.form1))
                jsFontcion.Cleload();
            else
                jsFontcion.ResponseW("添加操作出错");
        }
    }
}