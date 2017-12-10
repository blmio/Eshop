using System;
using System.Collections;
using System.Configuration;
using System.Data;
using ask;

public partial class admin_system_keyDataModify : System.Web.UI.Page
{
    protected string R(string T) { return Request.Form[T]; }
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
            DataSet ds = DBHelp.DataSet_ds("select [Number],[upid],[keywords],[num],[CloseS],[Reded],[hot] from [e_keydata] where [Number]='" + id + "'", "@value");
            foreach (DataRow rs in ds.Tables["@value"].Select())
            {
                this.lblID.Text = rs["Number"].ToString();
                this.keywords.Text = rs["keywords"].ToString();
                this.num.Text = rs["num"].ToString();
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
        }
    }
    /// <summary>
    /// 增加和修改
    /// </summary>
    protected void Bu_Click()
    {
        string Number = this.lblID.Text;
        if (string.IsNullOrEmpty(Number))
            Number = IdNumber.NumberSman("e_keydata", "K");


        string[] Text = { "num" };
        string[] Value = { R("num") };
        if (!string.IsNullOrEmpty(this.lblID.Text))
        {
            if (UpdateClass.fromUpdate("e_keydata", "keywords", "CloseS|Reded|hot", Text, Value, this.form1, " [Number]='" + this.lblID.Text + "'"))
                jsFontcion.Cleload();
            else
                jsFontcion.ResponseW("修改操作出错");
        }
        else
        {
            int stat = config.Sort_max("select max(Stat) from [e_keydata]");
            Text = new string[] { "Number", "Stat", "num" ,"keydate", "UserHostAddress", "UserHostName" };
            Value = new string[] { Number, stat.ToString(), R("num"), DateTime.Now.ToShortDateString(), Request.UserHostAddress, Request.UserHostName };
            if (AddClass.fromAdd("e_keydata", "keywords", "CloseS|Reded|hot", Text, Value, this.form1))
                jsFontcion.Cleload();
            else
                jsFontcion.ResponseW("添加操作出错");
        }
    }
}