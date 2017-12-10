using System;
using System.Data;
using System.Web.UI.WebControls;
using ask;

public partial class admin_user_CateInfoModify : System.Web.UI.Page
{
    public string adminD = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            daohang_bind();
        else
            Bu_Click();
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
            string[] V = DBHelp.frS_string("select [upid],[title],[Grade] from [e_goods_cate] where [Number]='" + pid + "'");
            pid = V[1];
            upiddf = V[0];
            LGrade.Text = V[2];
            if (string.IsNullOrEmpty(upiddf)) upiddf = "1";

            string sql = "select [Number],[title] from [e_goods_cate] where [upid]='" + upiddf + "' and [CloseS]<>1 order by [Stat],[Number]";
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

    protected void daohang_bind()
    {
        string upid = Request.QueryString["upid"];
        string id = Request.QueryString["Number"];
        if (!string.IsNullOrEmpty(id))
        {
            DataSet ds = DBHelp.DataSet_ds("select [Number],[title],[sitetitle],[Keywords],[Description],[CloseS],[Reded],[upid],[top] from [e_goods_cate] where [Number]='" + id + "'", "@value");
            foreach (DataRow rs in ds.Tables["@value"].Select())
            {
                upid = rs["upid"].ToString();
                this.lblID.Text = rs["Number"].ToString();
                this.title.Text = rs["title"].ToString();
                this.sitetitle.Text = rs["sitetitle"].ToString();
                this.Keywords.Text = rs["Keywords"].ToString();
                this.Description.Text = rs["Description"].ToString();
                if (rs["CloseS"].ToString() == "1")
                    this.CloseS.Checked = true;
                else
                    this.CloseS.Checked = false;
                if (rs["Reded"].ToString() == "1")
                    this.Reded.Checked = true;
                else
                    this.Reded.Checked = false;
                if (rs["top"].ToString() == "1")
                    this.top.Checked = true;
                else
                    this.top.Checked = false;
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
        if (string.IsNullOrEmpty(Number)) Number = Useid.Number("e_goods_cate", 8, "C");
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
        if (!string.IsNullOrEmpty(this.lblID.Text))
        {
            if (UpdateClass.fromUpdate("e_goods_cate", "title|sitetitle|Keywords|Description", "CloseS|Reded|top", Text, Value, this.form1, " [Number]='" + this.lblID.Text + "'"))
                jsFontcion.Cleload();
            else
                jsFontcion.ResponseW("修改操作出错");
        }
        else
        {
            int stat = config.Sort_max("select max(Stat) from [e_goods_cate] where [upid]='" + this.DropDupid.SelectedValue + "'");
            Text = new string[] { "upid", "Number", "Stat", "Grade" };
            Value = new string[] { this.DropDupid.SelectedValue, Number, stat.ToString(), Grade };
            if (AddClass.fromAdd("e_goods_cate", "title|sitetitle|Keywords|Description", "CloseS|Reded|top", Text, Value, this.form1))
                jsFontcion.Cleload();
            else
                jsFontcion.ResponseW("添加操作出错");
        }
    }
}