using System;
using System.Data;
using System.Web.UI.WebControls;
using ask;

public partial class admin_system_HelpModify : System.Web.UI.Page
{
    public string adminD = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            daohang_bind();
        else
            Bu_Click();
    }
    protected void daohang_bind()
    {
        string upid = Request.QueryString["upid"];
        string id = Request.QueryString["Number"];
        if (!string.IsNullOrEmpty(id))
        {
            DataSet ds = DBHelp.DataSet_ds("select [Number],[title],[CloseS],[upid] from [e_helplist] where [Number]='" + id + "'", "@value");
            foreach (DataRow rs in ds.Tables["@value"].Select())
            {
                upid = rs["upid"].ToString();
                this.lblID.Text = rs["Number"].ToString();
                this.title.Text = rs["title"].ToString();
                if (rs["CloseS"].ToString() == "1")
                    this.CloseS.Checked = true;
                else
                    this.CloseS.Checked = false;
            }
            ds.Clear();
            ds.Dispose();
        }
        DropBind(upid);
    }
    /// <summary>
    /// 增加和修改
    /// </summary>
    protected void Bu_Click()
    {
        string Number = this.lblID.Text;
        string Grade = "0";
        if (this.DropDupid.SelectedValue != "0")
        {
            int F = 0;
            int.TryParse(LGrade.Text, out F);
            F = F + 1;
            Grade = F.ToString();
        }
        string[] Text = { "upid", "Grade" };
        string[] Value = { this.DropDupid.SelectedValue, Grade };
        if (string.IsNullOrEmpty(Number)) Number = Useid.Number("e_helplist", 4, "H");
        if (!string.IsNullOrEmpty(this.lblID.Text))
        {
            if (UpdateClass.fromUpdate("e_helplist", "title", "CloseS", Text, Value, this.form1, " [Number]='" + this.lblID.Text + "'"))
                jsFontcion.Cleload();
            else
                jsFontcion.ResponseW("修改操作出错");
        }
        else
        {
            string upid = this.DropDupid.SelectedValue;
            int stat = config.Sort_max("select max(Stat) from [e_helplist] where upid='" + upid + "'");
            Text = new string[] { "upid", "Grade", "Number", "Stat" };
            Value = new string[] { upid, Grade, Number, stat.ToString() };
            if (AddClass.fromAdd("e_helplist", "title", "CloseS", Text, Value, this.form1))
                jsFontcion.Cleload();
            else
                jsFontcion.ResponseW("添加操作出错");
        }
    }
    /// <summary>
    /// 绑定类别
    /// </summary>
    protected void DropBind(string pid)
    {
        string upiddf = "";
        string upid = pid;
        if (!string.IsNullOrEmpty(pid) && pid != "0")
        {
            string[] V = DBHelp.frS_string("select [upid],[title],[Grade] from [e_helplist] where [Number]='" + pid + "'");
            pid = V[1];
            upiddf = V[0];
            LGrade.Text = V[2];
            if (string.IsNullOrEmpty(upiddf)) upiddf = "1";

            string sql = "select [Number],[title] from [e_helplist] where [upid]='" + upiddf + "' and [CloseS]<>1 order by [Stat],[Number]";
            DataBindManager.DropDD_0(this.DropDupid, new ListItem(pid, upid), sql, "Number", "title", "== 请选择父类别 ==");
            if (upiddf != "1")
                adminD = "0";
        }
        else
        {
            this.DropDupid.Items.Add(new ListItem("默认分类", "0"));
            adminD = "1";
        }
    }
}