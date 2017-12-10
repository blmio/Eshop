using System;
using System.Data;
using System.Web;
using System.Web.Security;
using ask.Web;
using ask;

public partial class admin_Apply_Boxhtml : System.Web.UI.Page
{
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
    private string Q(string T) { return Request.QueryString[T]; }
    private string F(string T) { return Request.Form[T]; }
    private string R(string T) { return Request[T]; }
    protected void Page_Load(object sender, EventArgs e)
    {
        string mod = Request.Form["mod"];
        if (string.IsNullOrEmpty(mod)) mod = Request.QueryString["mod"];
        switch (mod)
        {
            case "Lock":
                LockLoad();
                break;
            case "BoxDelet":
                BoxDelet();
                break;
            case "left":
                Write(leftall());
                break;
            case "Agents":
                Write(Agents());
                break;
            case "Member":
                Write(Member());
                break;
            case "MemSmallcl":
                Write(MemSmallcl());
                break;
            case "welfare":
                Write(welfare());
                break;
        }
    }
    #region  Agents() 代理商
    /// <summary>
    /// 会员子分类
    /// </summary>
    /// <returns></returns>
    private string MemSmallcl()
    {
        string str = string.Empty, upid = Q("upid");
        DataSet ds;
        if (upid == "Ag00003")
        {
            ds = DBHelp.DataSet_ds("select [Number],[title] from [Manage] where [Inq]=1 and [CloseS]<>1 order by [Stat],[Number]", "@value");
        }
        else
        {
            ds = DBHelp.DataSet_ds("select [Number],[title] from [MemSmallcl] where [upid]='" + upid + "' order by [Atime],[Number]", "@value");
        }
        foreach (DataRow rs in ds.Tables["@value"].Select())
        {
            if (!string.IsNullOrEmpty(str)) str += "|";
            str += rs["Number"] + "," + rs["title"];
        }
        ds.Clear();
        ds.Dispose();
        return str;
    }
    private string Agents()
    {
        string Rank = Request["Rank"], Soid = Request["Soid"];
        string str = "select [Number],[CityV],[Aname],[RealName],[Company],[Address] from [Agents] where [CloseS]<>1";
        if (!string.IsNullOrEmpty(Rank))
            str += " and [Rank]='" + Rank + "'";
        if (!string.IsNullOrEmpty(Soid))
            str += " and [Soid]='" + Soid + "'";
        DataSet ds = DBHelp.DataSet_ds(str + " order by [Atime] desc,[Number] desc", "@value");
        str = "";
        string v = string.Empty, ci = v;
        foreach (DataRow rs in ds.Tables["@value"].Select())
        {
            v = rs["Number"] + "|$|" + rs["CityV"] + "|$|" + rs["Aname"] + "|$|" + rs["RealName"] + "|$|" + rs["Company"] + "|$|" + rs["Address"];
            ci = rs["Company"].ToString();
            if (string.IsNullOrEmpty(ci)) ci = rs["RealName"].ToString();
            if (string.IsNullOrEmpty(ci)) ci = rs["Aname"].ToString();
            str += "<li>";
            str += "<input type=\"checkbox\" value=\"" + v + "\" id=\"" + rs["Number"] + "\" onClick=\"Me.lic('" + rs["Number"] + "');\"> <a";
            //if (!string.IsNullOrEmpty(tid)) str += " style='color:#FF0000;'";
            str += " href=\"javascript:Me.lic('" + rs["Number"] + "');\" title=\"" + rs["CityV"] + "-" + ci + "\">" + ci + "</a>";
            str += "</li>";
        }
        ds.Clear();
        ds.Dispose();
        return "<ul>" + str + "</ul>";
    }
    /// <summary>
    /// 会员
    /// </summary>
    /// <returns></returns>
    private string Member()
    {
        string MCid = Request["MCid"], MSid = Request["MSid"], MLid = Request["MLid"];
        string str = "select [Number],[Username],[Nickname],[Email],[Mobile] from [Member] where [CloseS]<>1";
        if (!string.IsNullOrEmpty(MCid))
            str += " and [upid]='" + MCid + "'";
        if (!string.IsNullOrEmpty(MSid))
            str += " and [Smid]='" + MSid + "'";
        if (!string.IsNullOrEmpty(MLid))
            str += " and [Rating]='" + MLid + "'";
        DataSet ds = DBHelp.DataSet_ds(str + " order by [Atime] desc,[Number]", "@value");
        str = "";
        string v = string.Empty, ci = v;
        foreach (DataRow rs in ds.Tables["@value"].Select())
        {
            ci = rs["Nickname"].ToString();
            if (string.IsNullOrEmpty(ci)) ci = rs["Username"].ToString();
            if (string.IsNullOrEmpty(ci)) ci = rs["Email"].ToString();
            if (string.IsNullOrEmpty(ci)) ci = rs["Mobile"].ToString();
            v = rs["Number"] + "|$|" + ci;
            str += "<li>";
            str += "<input type=\"checkbox\" value=\"" + v + "\" id=\"" + rs["Number"] + "\" onClick=\"Me.lic('" + rs["Number"] + "');\"> <a";
            //if (!string.IsNullOrEmpty(tid)) str += " style='color:#FF0000;'";
            str += " href=\"javascript:Me.lic('" + rs["Number"] + "');\" title=\"" + ci + "\">" + ci + "</a>";
            str += "</li>";
        }
        ds.Clear();
        ds.Dispose();
        return "<ul>" + str + "</ul>";
    }
    private string welfare()
    {
        string str = "select [Number],[title] from [welfare] where [CloseS]<>1 and [upid]<>'0'";
        DataSet ds = DBHelp.DataSet_ds(str + " order by [Atime] desc,[Number]", "@value");
        str = "";
        string v = string.Empty;
        foreach (DataRow rs in ds.Tables["@value"].Select())
        {
            v = rs["Number"] + "|$|" + rs["title"];
            str += "<li>";
            str += "<input id='Num" + rs["Number"] + "' type=\"checkbox\" value=\"" + v + "\" id=\"" + rs["Number"] + "\" onClick=\"Me.lic('" + rs["Number"] + "');\"> <label for=\"Num" + rs["Number"] + "\" title=\"" + rs["title"] + "\">" + rs["title"] + "</label>";
            str += "</li>";
        }
        ds.Clear();
        ds.Dispose();
        return "<ul>" + str + "</ul>";
    }
    #endregion

    #region  leftall() 处理后台左边菜单 | LockLoad() 开关处理
    /// <summary>
    /// 处理后台左边菜单
    /// </summary>
    /// <returns></returns>
    private string leftall()
    {
        string str = string.Empty, mer = Request.QueryString["mer"];
        str = IOFile.ReadFile("~/admin/Apply/lefthtml/left" + mer + ".html");
        if (str.IndexOf("{div|") > -1) { str = ask.Web.left.divClass(str); }
        if (str.IndexOf("{p|") > -1) { str = ask.Web.left.pClass(str); }
        return str;
    }
    /// <summary>
    /// 开关设置数据库操作
    /// </summary>
    private void LockLoad()
    {
        string Surl = Q("url"), from = Q("from"), id = Q("id"), Stat = Q("Stat"), aler = Q("aler"), type = Q("type");
        if (!string.IsNullOrEmpty(id))
        {
            if (!string.IsNullOrEmpty(type))
            {
                if (type == "1")
                {
                    if (DBHelp.insert(from, "[" + Stat + "]=1", "[Number]='" + id + "'")) Response.Write(aler + "成功!");
                }
                else
                {
                    if (DBHelp.insert(from, "[" + Stat + "]=0", "[Number]='" + id + "'")) Response.Write("取消" + aler + "成功!");
                }
            }
            else if (DBHelp.fr_bool("select [Number] from [" + from + "] where [" + Stat + "]=1 and [Number]='" + id + "'"))
            {
                if (DBHelp.insert(from, "[" + Stat + "]=0", "[Number]='" + id + "'")) jsFontcion.ResponseW(aler + "成功!", Surl);
            }
            else
            {
                if (DBHelp.insert(from, "[" + Stat + "]=1", "[Number]='" + id + "'")) jsFontcion.ResponseW("取消" + aler + "成功!", Surl);
            }
        }
    }
    /// <summary>
    /// 删除操作
    /// </summary>
    private void BoxDelet()
    {
        string SMfrom = R("SMfrom"), Sonfrom = R("Sonfrom"), from = R("from"), id = R("id");
         if (string.IsNullOrEmpty(id)) return;
        string usid = R("usid"), ImgS = R("ImgS"), Files = R("Files"), cssupid = R("cssupid");
        if (!string.IsNullOrEmpty(cssupid)) Delet.Cssupid = cssupid;
        string[] newstr = id.Split('|'); int i = 0; id = "";
        foreach (string s in newstr)
        {
            if (string.IsNullOrEmpty(id)) id += "'" + s + "'"; else id += ",'" + s + "'";
        }

        if (!string.IsNullOrEmpty(Files))
        {
            string name = Request["_name"]; newstr = name.Split('|');
            foreach (string s in newstr) { IOFile.DeleteFolder2(s); }
        }
        if (!string.IsNullOrEmpty(SMfrom))
        {
            if (string.IsNullOrEmpty(ImgS))
            {
                i = Delet.Deletint(from, Sonfrom, SMfrom, id);
            }
            else
            {
                i = Delet.Deletimg(from, Sonfrom, SMfrom, id, ImgS);
            }
            if (i > 0)
            {
                Response.Write("删除成功！共删除 " + i + "子表条记录");
            }
            else
            {
                Response.Write("删除成功！没有子表条记录");
            }
        }
        else if (!string.IsNullOrEmpty(Sonfrom))
        {
            if (string.IsNullOrEmpty(ImgS))
            {
                i = Delet.Deletint(from, Sonfrom, id);
            }
            else
            {
                i = Delet.Deletimg(from, Sonfrom, id, ImgS);
            }
            if (i > 0)
            {
                Response.Write("删除成功！共删除 " + i + "子表条记录");
            }
            else
            {
                Response.Write("删除成功！没有子表条记录");
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(usid))
            {
                i = DBHelp.insert("delete from [" + from + "] where [Sid]=" + id + " and [usid]=" + usid);
                if (i > 0)
                {
                    Response.Write("删除成功！共删除 " + i + "条记录");
                }
                else
                {
                    Response.Write("删除失败");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(ImgS))
                    i = Delet.Deletint(from, id);
                else
                    i = Delet.Deletimg(from, id, ImgS);
                if (i > 0)
                    Response.Write("删除成功！共删除 " + i + "条记录");
                else
                    Response.Write("删除失败");
            }
        }
    }
    #endregion
}