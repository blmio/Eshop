using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.Security;
using ask;

public partial class admin_user_MemberModify : System.Web.UI.Page
{
    protected string R(string T) { return Request.Form[T]; }
    protected string[] Vr = new string[13];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            daohang_bind();
        else
            Bu_Click();
    }
    protected void daohang_bind()
    {
        string id = Request.QueryString["Number"], upid = Request.QueryString["upid"];
        if (!string.IsNullOrEmpty(id))
        {
            DateTime dt = DateTime.Now;
            string Field = "[Number],[Name],[Password],[NickName],[Sex],[Birth],[Mobile],[RealName],[UserPic],[Email],[Address],[Content],[Lotimes],[CloseS]";
            DataSet ds = DBHelp.DataSet_ds("select " + Field + " from [e_member] where [Number]='" + id + "'", "@value");
            foreach (DataRow rs in ds.Tables["@value"].Select())
            {
                this.lblID.Text = rs["Number"].ToString();
                Vr[0] = rs["Number"].ToString();
                Vr[1] = rs["Name"].ToString();
                Vr[2] = rs["Password"].ToString();
                Vr[3] = rs["NickName"].ToString();
                Vr[4] = rs["Sex"].ToString();
                Vr[5] = rs["Birth"].ToString();
                Vr[6] = rs["Mobile"].ToString();
                Vr[7] = rs["RealName"].ToString();
                Vr[8] = rs["UserPic"].ToString();
                Vr[9] = rs["Email"].ToString();
                Vr[10] = rs["Address"].ToString();
                Vr[11] = rs["Lotimes"].ToString();
                Vr[12] = rs["CloseS"].ToString();

                this.Name.Text = rs["Name"].ToString();
                this.Password.Text = ask.Web.EncryptHelper.Decrypt(rs["Password"].ToString());
                this.NickName.Text = rs["NickName"].ToString();
                this.RealName.Text = rs["RealName"].ToString();
                this.Email.Text = rs["Email"].ToString();
                this.Mobile.Text = rs["Mobile"].ToString();
                if (!string.IsNullOrEmpty(rs["Birth"].ToString()))
                {
                    DateTime.TryParse(rs["Birth"].ToString(), out dt);
                    this.Birth.Text = dt.ToString("yyyy-MM-dd");
                }
                this.ImgS.Text = rs["UserPic"].ToString();
                this.Address.Text = rs["Address"].ToString();
                this.Content.Text = rs["Content"].ToString();
                this.Lotimes.Text = rs["Lotimes"].ToString();
                if (rs["CloseS"].ToString() == "1")
                    this.CloseS.Checked = true;
                else
                    this.CloseS.Checked = false;
            }
            ds.Clear();
            ds.Dispose();
        }
    }
    protected void Bu_Click()
    {
        string Number = this.lblID.Text;
        if (string.IsNullOrEmpty(Number)) Number = IdNumber.NumberSec("e_member", "m");
        string Pass = this.Password.Text;
        if(string.IsNullOrEmpty(Pass)) 
            Pass = Vr[2];
        else
            Pass = ask.Web.EncryptHelper.Encrypt(Pass);
        string Imgad = string.Empty;
        if (!string.IsNullOrEmpty(this.FImgS.FileName))
            Imgad = shopfile.FileGet(this.FImgS, "bxite-" + Number, "~/upload/vip", 50000000);
        else
            Imgad = ImgS.Text;
        string T = "NickName|Birth|Mobile|RealName|Email|Address|Content|Lotimes";
        string[] Text = { "Number", "Name", "Password","Sex", "UserPic" };
        string[] Value = { Number, R("Name"), Pass, R("Sex"), Imgad };
        if (!string.IsNullOrEmpty(this.lblID.Text))
        {
            if (UpdateClass.fromUpdate("e_member", T, "CloseS", Text, Value, this.form1, " [Number]='" + this.lblID.Text + "'"))
                jsFontcion.Cleload();
            else
                jsFontcion.ResponseW("修改操作出错");
        }
        else
        {
            if (AddClass.fromAdd("e_member", T, "CloseS", Text, Value, this.form1))
                jsFontcion.Cleload();
            else
                jsFontcion.ResponseW("添加操作出错");
        }
    }
    protected string Sexra()
    {
        if (string.IsNullOrEmpty(Vr[4])) Vr[4] = "男";
        string str = string.Empty;
        string[] V = { "男", "女", "保密" };
        string[] K = { "1", "2", "0" };
        int im = 0;
        foreach (string s in V)
        {
            str += "<input type=\"radio\" name=\"Sex\" value=\"" + K[im] + "\" id=\"Sex-" + K[im] + "\"";
            if (Vr[4] == K[im]) str += " checked=\"checked\"";
            str += "/>";
            str += " <label for=\"Sex-" + K[im] + "\">" + s + "</label> &nbsp;";

            im++;
        }
        return str;
    }
}