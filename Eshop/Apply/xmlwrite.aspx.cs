using System;
using System.Configuration;
using System.Web.Security;
using System.Security.Cryptography;
using System.Data;
using System.Web;
using System.Text;
using System.Net;
using ask;

public partial class Apply_xmlwrite : System.Web.UI.Page
{
    private string R(string T) { return Request.Form[T]; }
    private string Q(string T) { return Request.QueryString[T]; }
    protected string UEs(string str) { return strFunction.ToUnicode(str); }
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
            case "login":
                login();
                break;
            case"reg":
                register();
                break;
            case "ckCode":
                ckCode();
                break;
            case "ckName":
                ckName();
                break;
            case "cart":
                cart();
                break;
            case "dCart":
                dCart();
                break;
            case "refrCart":
                Write(refrCart());
                break;
        }
    }

    /// <summary>
    /// 用户登录
    /// </summary>
    private void login()
    {
        string name = R("loginname"), pwd = R("nloginpwd"), remember = R("chkRememberMe"), login = Request["login"];
        // 退出登录
        if (login == "Logoff")
        {
            //清除"number"的键值
            HttpCookie ucookies = Request.Cookies["userSett"];
            ucookies.Values.Remove("number");
            Response.AppendCookie(ucookies);

            //删除Cookies["uremember"]
            HttpCookie rcookies = Request.Cookies["uremember"];
            if (rcookies != null)
            {
                rcookies.Expires = DateTime.Now.AddDays(-3); //删除整个Cookie，只要把过期时间设置为负值
                Response.AppendCookie(rcookies);
            }
            string url = Request.QueryString["url"];
            if (string.IsNullOrEmpty(url))
                Response.Redirect("~/vip/login.aspx");
            else
                Response.Redirect(url);
            return;
        }

        //密码加密
        string pass = ask.Web.EncryptHelper.Encrypt(pwd);
        string[] mebArr = DBHelp.frS_string("select [Number],[Name],[Password],[NickName] from [e_member] where [Name]='"+ name +"'");
        if (mebArr[0] == null) { Write("Xerror|2|账户名不存在，请重新输入"); return; }
        if (mebArr[2] != pass) { Write("Xerror|3|账户名和密码不一致"); return; }

        HttpCookie myuser = new HttpCookie("userSett");
        myuser.Expires = DateTime.Now.AddDays(3);
        myuser["number"] = mebArr[0];
        myuser["username"] = HttpUtility.UrlEncode(mebArr[1]);
        myuser["password"] = mebArr[2];
        myuser["nickname"] = HttpUtility.UrlEncode(mebArr[3]);
        Response.Cookies.Add(myuser);

        DBHelp.insert("e_member", "[Lotimes]=[Lotimes]+1", "[Number]='" + mebArr[0] + "'");
        HttpCookie myreme = new HttpCookie("uremember");
        if (remember == "on")  {
            myreme.Expires = DateTime.Now.AddDays(3);
            myreme.Values.Add("username", name);
            myreme.Values.Add("password", pass);
        }
        else
            myreme.Expires = DateTime.Now.AddDays(-3);
        Response.AppendCookie(myreme);

        Write("Xerror|1|欢迎回到e商城！");
    }
    /// <summary>
    /// 用户注册
    /// </summary>
    private void register()
    {
        string name = R("regname"), npwd = R("nregpwd");
        string number = IdNumber.NumberSec("e_member", "m");
        //密码加密
        string pass = ask.Web.EncryptHelper.Encrypt(npwd);
        //自动获取用户IP
        string ip = HttpContext.Current.Request.ServerVariables.Get("REMOTE_ADDR");
        if (string.IsNullOrEmpty(ip) || ip == "::1") ip = HttpContext.Current.Request.UserHostAddress;

        string[] key = { "Number", "Name", "Password", "NickName","LogIp" };
        string[] value = { number, name, pass, name, ip };
        if (AddClass.fromAdd("e_member", key, value))
        {
            HttpCookie myuser = new HttpCookie("userSett");
            myuser.Expires = DateTime.Now.AddDays(3);
            myuser["number"] = number;
            myuser["username"] = HttpUtility.UrlEncode(name);
            myuser["password"] = pass;
            myuser["nickname"] = HttpUtility.UrlEncode(name);
            Response.Cookies.Add(myuser);

            Write("Xerror|1|注册成功!");
        }
        else
            Write("Xerror|0|注册出错,请重试！");
    }

    /// <summary>
    /// 判断验证码是否正确
    /// </summary>
    private void ckCode()
    {
        string CheckCode = string.Empty, val = Q("val");
        if (Session["CheckCode"] != null)
            CheckCode = Session["CheckCode"].ToString();
        // 不区分大小写
        Write(CheckCode.Equals(val, StringComparison.OrdinalIgnoreCase) ? "0" : "1");
    }

    /// <summary>
    /// 判断字段值是否存在
    /// </summary>
    private void ckName()
    {
        string key = Request.QueryString["key"];
        string val = Request.QueryString["val"];
        string Num = DBHelp.fr_string("select [Number] from [e_member] where [" + key + "]='" + val + "'");
        Write(string.IsNullOrEmpty(Num)? "0" : "1");
    }

    /// <summary>
    /// 获取本地IP地址
    /// </summary>
    /// <returns></returns>
    private String GetIPAddress()
    {
        String result = string.Empty;
        String hostName = Dns.GetHostName();
        IPHostEntry IpEntry = Dns.GetHostEntry(hostName);
        foreach (IPAddress ip in IpEntry.AddressList)
        {
            if (ip.AddressFamily.ToString() == "InterNetwork")
            {
                result = ip.ToString();
                break;
            }
        }
        return result;
    }
    /// <summary>
    /// 显示购物车数据
    /// </summary>
    protected void cart()
    {
        string number = Request.Cookies["userSett"]["number"];
        string emid = Q("emid"), count = Q("count");
        string[] gdInfo = DBHelp.frS_string("select [emid],[title],[price],[ImgS] from [e_goods] where [emid]='"+emid+"'");

        string[] Text = { "Number", "upid", "emid", "title", "price", "ImgS", "count" };
        string[] value = { IdNumber.NumberSec("e_cart", "ca"), number, emid, gdInfo[1], gdInfo[2], gdInfo[3], count };
        string ck = DBHelp.fr_string("select [Number] from [e_cart] where [emid]='"+ emid +"'");
        if (!string.IsNullOrEmpty(ck))
        {
            if(UpdateClass.fromUpdate("e_cart",Text,value,"[emid]='"+emid+"'"))
                Write("Xerror|2|已加入购物车");
            else
                 Write("Xerror|0|加入购物车出错");
        }
        else
        {
            if(AddClass.fromAdd("e_cart",Text,value))
                Write("Xerror|1|已加入购物车");
            else
                Write("Xerror|0|加入购物车出错");
        }
    }
    /// <summary>
    /// 删除购物车数据
    /// </summary>
    private void dCart()
    {
        string number = Request.Cookies["userSett"]["number"];
        string emid = Q("emid");
        if(!string.IsNullOrEmpty(emid))
        {
            if(Delet.DeletboolW("e_cart", "[emid]='"+ emid +"'"))
                Write("Xerror|1|数据删除成功");
            else
                Write("Xerror|0|数据删除失败");
        }
    }

    /// <summary>
    /// 购物车刷新
    /// </summary>
    /// <returns></returns>
    public string refrCart()
    {
        string number = Request.Cookies["userSett"]["number"];
        string str = string.Empty;
        int count = config.DataCount("select [Number] from [e_cart] where [upid]='" + number + "'");
        string[] cartValue = DBHelp.frS_string("select top 1 [emid],[title],[price],[ImgS],[count] from [e_cart] where [upid]='" + number + "' order by [Atime] desc");
        str += "<div class=\"cw-icon\"><i class=\"ci-left\"></i>";

        if (!string.IsNullOrEmpty(cartValue[0]))
        {
            str += "<i class=\"ci-right\">&gt;</i><i class=\"ci-count\" id=\"shopping-amount\">" + count + "</i>";
            str += " <a target=\"_blank\" href=\"vip/default.aspx\">我的购物车</a> </div>";
            str += "<div class=\"dorpdown-layer\"><div class=\"spacer\"></div><div id=\"settleup-content\">";
            str += "<div class=\"smt\"><h4 class=\"fl\">最新加入的商品</h4></div><div class=\"smc\">";
            str += "<ul id=\"mcart-mz\"><li><div class=\"p-img fl\"><a href=\"item.aspx?id=" + cartValue[0] + "\" target=\"_blank\">";
            str += "<img src=\"Apply/avatar.aspx?Type=fixnone&size=50x50&key=" + cartValue[3] + "\" width=\"50\" height=\"50\" alt=\"\"></a></div>";
            str += "<div class=\"p-name fl\"><span></span><a href=\"item.aspx?id=" + cartValue[0] + "\" title=\"" + cartValue[1] + "\" target=\"_blank\">" + cartValue[1] + "</a></div>";
            str += "<div class=\"p-detail fr ar\"> <span class=\"p-price\"><strong>￥" + ask.Web.AppInf.MR(cartValue[2]) + "</strong>x" + cartValue[4] + "</span> <br>";
            str += "<a class=\"delete\" data-id=\"" + cartValue[0] + "\"  href=\"javascript:;\">删除</a></div></li></ul></div></div>";
        }
        else
        {
            str += "<i class=\"ci-right\">&gt;</i><i class=\"ci-count\" id=\"shopping-amount\">0</i>";
            str += " <a target=\"_blank\" href=\"vip/default.aspx\">我的购物车</a> </div>";
            str += "<div class=\"dorpdown-layer\"><div class=\"spacer\"></div><div class=\"prompt\">";
            str += "<div class=\"nogoods\"><b></b>购物车中还没有商品，赶紧选购吧！</div></div>";
        }
        str += "</div>";
        return str;
    }
}