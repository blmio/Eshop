using System;
using System.Configuration;
using System.Web.Security;
using System.Web;
using ask;

public partial class admin_Apply_xmlWrite : System.Web.UI.Page
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
            case "addCate":
                addCate();
                break;
            case "addNav":
                addNav();
                break;
        }
    }

    private void login()
    {
        string name = R("adname"), pwd = R("adpassword"), remember = R("chkRememberMe");
        string Pass = ask.Web.EncryptHelper.Encrypt(pwd);
        string[] adArr = DBHelp.frS_string("select [Number],[upid],[Rank],[CloseS],[Aname],[Apasswoid],[RealityName],[Lotimes] from [e_admin] where [Aname]='" + name + "'");
        if (adArr[0] == null)
        {
            Write("Xerror|2|账户名不存在，请重新输入");
            return;
        }
        else if (adArr[3] == "1")
        {
            Write("Xerror|2|登录失败，该用户已被锁定");
            return;
        }
        else if (adArr[5] != Pass)
        {
            Write("Xerror|3|账户名和密码不一致");
            return;
        }
        else
        {
            HttpCookie myCookie = new HttpCookie("loginInfoSxmy");
            myCookie["Number"] = adArr[0];
            myCookie["Upid"] = adArr[1];
            myCookie["Rank"] = adArr[2];
            myCookie["Aname"] = HttpUtility.UrlEncode(adArr[4]);
            myCookie["Apasswoid"] = adArr[5];
            myCookie["Title"] = adArr[4];
            myCookie["RealityName"] = HttpUtility.UrlEncode(adArr[6]);
            Response.Cookies.Add(myCookie);
        }

        DBHelp.insert("e_admin", "[Lasttime]='" + DateTime.Now.ToString() + "',[Lotimes]=[Lotimes]+1", "[Number]='" + adArr[0] + "'");
        HttpCookie myreme = new HttpCookie("remeSxmy");
        DateTime dt = DateTime.Now;
        if (remember == "on")
        {
            myreme.Expires = dt.AddDays(3);
            myreme.Values.Add("Aname", name);
            myreme.Values.Add("Apasswoid", Pass);
        }
        else
            myreme.Expires = dt.AddDays(-3);
        Response.AppendCookie(myreme);

        Write("Xerror|1|欢迎登入后台系统！");
    }

    /// <summary>
    /// 写入分类数据
    /// </summary>
    private void addCate()
    {
        string[] title = { "电脑配件", "手机配件", "数码影音", "家用电器", "办公打印", "网络产品", "外设产品", "服务产品" };
        string[] descript = { "CPU|主板|显卡|硬盘|SSD固态硬盘|内存|机箱|电源|显示器|刻录机/光驱|声卡/扩展卡|散热器", 
            "电池/移动电源|蓝牙耳机|充电器/数据线|手机耳机|贴膜|存储卡|保护套|车载iPhone配件|创意配件|便携/无线音箱|手机饰品", 
            "数码相机|单电/微单相机|单反相机|拍立得|运动相机|摄像机|镜头|户外器材|影棚器材|冲印服务|数码相框|耳机/耳麦|音箱/音响|麦克风|MP3/MP4", 
            "平板电视|空调|冰箱|洗衣机|家庭影院|DVD|迷你音响|电话机|热水器|电风扇|净化器|电压力锅|电饭锅|咖啡机", 
            "投影机|多功能一体机|打印机|传真设备|验钞/点钞机|扫描设备|复合机|碎纸机|考勤机|收款/POS机|会议音频视频", 
            "路由器|网卡|交换机|网络存储|4G/3G上网|网络盒子", 
            "鼠标|键盘|游戏设备|U盘移动硬盘|摄像头|线缆电玩|手写板|外置盒|UPS|插座", 
            "上门服务|远程服务|电脑软件"};
        string num = string.Empty, upid = num;

        for (int i = 0; i < title.Length; i++)
        {
            num = Useid.Number("e_goods_cate", 8, "C");
            string[] key = { "Number", "title", "Stat", "Grade" };
            string[] value = { num, title[i], i + 1 + "","0" };
            if (!AddClass.fromAdd("e_goods_cate", key, value))
                Write("写入数据失败！");
        }

        for (int j = 0; j < descript.Length; j++)
        {
            string[] descriptArr = descript[j].Split('|');
            for (int n = 0; n < descriptArr.Length; n++)
            {
                num = Useid.Number("e_goods_cate", 8, "C");
                upid = DBHelp.fr_string("select [Number] from [e_goods_cate] where [Stat] ='" + (j + 1) + "'");

                string[] key = { "Number", "upid", "title", "Stat", "Grade" };
                string[] value = { num, upid, descriptArr[n], n + 1 + "", "1" };
                AddClass.fromAdd("e_goods_cate", key, value);
            }
        }

        Write("写入数据成功！");
    }

    /// <summary>
    /// 写入导航栏数据
    /// </summary>
    private void addNav()
    {
        string[] title = { "首页","电脑配件", "手机配件", "数码影音", "家用电器", "办公打印", "网络产品", "外设产品", "服务产品" };
        for (int i = 0; i < title.Length; i++)
        {
            string number = IdNumber.NumberSman("e_navigation", "N");
            string[] key = { "Number", "upid", "title" };
            string[] value = { number, "0", title[i] };
            if (!AddClass.fromAdd("e_navigation", key, value))
                Write("写入数据失败！");
        }
        Write("写入数据成功！");
    }

}