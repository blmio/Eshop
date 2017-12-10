using System;
using System.Data;
using System.Web;
using System.Web.Security;
using ask.Web;
using ask;

public partial class Apply_admin : System.Web.UI.Page
{
    private void xmlWrite(string str)
    {
        Response.Clear();
        Response.ContentType = "text/xml";
        Response.Charset = "utf-8";
        Response.Write("<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n");
        Response.Write("<root><![CDATA[");
        Response.Write(str);
        Response.Write("]]></root>\n");
        Response.End();
    }
    /// <summary>
    /// 输出javascript客户端信息
    /// </summary>
    /// <param name="str"></param>
    private void Write(string str)
    {
        Response.Clear();
        Response.ContentType = "text/html";
        Response.Charset = "utf-8";
        Response.Write(str);
        Response.End();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        switch (Request["mod"])
        {
            case "avatar":
                Response.Redirect(avatar());
                break;
            case "upidChang":
                upidChang();
                break;
        }
    }

    private void upidChang()
    {
        string name = Request.QueryString["Mname"];
        if (!string.IsNullOrEmpty(name))
        {
            if (DBHelp.fr_bool("select [Number] from [Member] where [Username]='" + name + "'"))
                Response.Write("1");
            else
                Response.Write("0");
        }
    }
    /// <summary>
    /// 处理图片
    /// </summary>
    /// <returns></returns>
    private string avatar()
    {
        string img = Request["img"];
        return strFunction.Authl(img);
    }
}