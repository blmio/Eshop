using System;
using System.Configuration;
using System.Web.Security;
using System.Security.Cryptography;
using System.Data;
using System.Web;
using System.Text;
using System.Net;
using ask;

public partial class vip_Apply_xmlWrite : System.Web.UI.Page
{
    private string R(string T) { return Request.Form[T]; }
    private string Q(string T) { return Request.QueryString[T]; }
    protected string UEs(string str) { return strFunction.ToUnicode(str); }
    protected string MR(object pic) { return ask.Web.AppInf.MR(pic); }
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
            case "li-zl":
                Write(vipInfo());
                break;
            case "li-tx":
                Write(picInfo());
                break;
            case "li-mm":
                Write(changePwd());
                break;
            case "li-cart":
                Write(cartInfo());
                break;
            case "li-dd":
                Write(ddInfo());
                break;
            case "li-addr":
                Write(addrInfo());
                break;
            case "li-appra":
                Write(appraInfo());
                break;
            case "btn_base":
                vipPost();
                break;
            case "btn_pwd":
                vipPwd();
                break;
            case "btn_cart":
                vipCart();
                break;
            case "btn_addr":
                vipAddr();
                break;
            case "deleteCart":
                deleteCart();
                break;
        }
    }


    #region 用户信息
    /// <summary>
    /// 基本资料
    /// </summary>
    /// <returns></returns>
    protected string vipInfo()
    {
        string str = string.Empty;
        string number = Q("m");
        str += "<div class=\"section-header\"><div class=\"fl\"><h2><span>基本资料</span></h2></div></div>";
        str += "<div class=\"section-content\"><form id=\"form1\" class=\"baseform\" method=\"post\">";
        string[] value = DBHelp.frS_string("select [Number],[Name],[NickName],[Sex],[Birth],[Mobile],[RealName],[Email],[Address],[Content] from [e_member] where [Number]='" + number + "'");
        str += "<dl><dt>用户名：</dt><dd><span class=\"style-red\">" + value[1] + "</span></dd> </dl>";
        str += "<dl><dt>昵称：</dt><dd><input type=\"text\" maxlength=\"10\" class=\"cont-item\" name=\"nickn\"  id=\"nickn\" value=\"" + value[2] + "\"/><span class=\"tips\">不能超过10个字</span></dd></dl>";
        str += "<dl><dt>性别：</dt><dd>";
        if (value[3] == "1")
        {
            str += "<input type=\"radio\" name=\"sex\" id=\"sex-1\" checked value=\"1\" />男";
            str += "<input type=\"radio\" name=\"sex\" id=\"sex-2\"  value=\"2\"/>女";
            str += "<input type=\"radio\" name=\"sex\" id=\"sex-0\"  value=\"0\"/>保密";
        }
        else if (value[3] == "2")
        {
            str += "<input type=\"radio\" name=\"sex\" id=\"sex-1\"  value=\"1\" />男";
            str += "<input type=\"radio\" name=\"sex\" id=\"sex-2\"  checked value=\"2\"/>女";
            str += "<input type=\"radio\" name=\"sex\" id=\"sex-0\"  value=\"0\"/>保密";
        }
        else
        {
            str += "<input type=\"radio\" name=\"sex\" id=\"sex-1\"  value=\"1\" />男";
            str += "<input type=\"radio\" name=\"sex\" id=\"sex-2\"  value=\"2\"/>女";
            str += "<input type=\"radio\" name=\"sex\" id=\"sex-0\"  checked value=\"0\"/>保密";
        }
        str += "</dd></dl><dl><dt>出生年月：</dt><dd>";
        str += "<select  name=\"year\" class=\"year-y\">" + selectDate(1950, 2014, value[4]);
        str += "</select>年<select name=\"month\" class=\"year-m\">" + selectDate(1, 12, value[4]) + "</select>月";
        str += "</dd></dl><dl><dt>居住地：</dt><dd>";
        str += "<select name=\"ddlProvince\" id=\"ddlProvince\" onchange=\"selectMoreCity(this)\"></select>";
        str += "<select name=\"ddlCity\" id=\"ddlCity\"><option selected value=\"城市\">城市</option></select>";

        str += "</dd></dl><dl><dt>手机号码：</dt><dd>";
        str += "<input type=\"text\" class=\"cont-item\" name=\"mobile\" id=\"mobile\" value=\"" + value[5] + "\"/>";
        str += "</dd></dl><dl><dt>联系邮箱：</dt><dd>";
        str += "<input type=\"text\" class=\"cont-item\" name=\"email\"  id=\"email\" value=\"" + value[7] + "\"/>";
        str += "</dd></dl><dl><dt>个人中心：</dt><dd>";
        str += "<textarea name=\"Content\" id=\"Content\" >" + value[9] + "</textarea>";
        str += "</dd></dl><dl><dt>&nbsp;</dt><dd>";
        str += "<a href=\"javascript:;\" class=\"btns\" id=\"btn_base\" title=\"保存修改\" \">保存修改</a>";
        str += "</dd></dl></form>";
        str += "<script type=\"text/javascript\"> EDE.include('Scripts/jquery/city.js');  BindCity('" + value[8] + "');</script>";
        return str;
    }

    protected string selectDate(int start, int end, string birth)
    {
        string str = string.Empty;
        if (!string.IsNullOrEmpty(birth))
        {
            string[] ym = birth.Split('/');
            for (int i = start; i < end; i++)
            {
                if (ym[0] == i.ToString() || ym[1] == i.ToString())
                    str += "<option value=\"" + i + "\" ch selected>" + i + "</option>";
                else
                    str += "<option value=\"" + i + "\">" + i + "</option>";
            }
        }
        else
        {
            for (int i = start; i < end; i++)
            {
                str += "<option value=\"" + i + "\">" + i + "</option>";
            }
        }
        return str;
    }
    /// <summary>
    /// 上传头像
    /// </summary>
    /// <returns></returns>
    protected string picInfo()
    {
        return "<iframe src=\"item/portrait.aspx\" frameborder=\"0\" width=\"960\" height=\"200\" align=\"middle\"></iframe>";
    }
    /// <summary>
    /// 修改密码
    /// </summary>
    /// <returns></returns>
    protected string changePwd()
    {
        string str = string.Empty;
        str += "<div class=\"section-header\"><div class=\"fl\"><h2><span>修改密码</span></h2></div></div>";
        str += "<div class=\"section-content\"><form id=\"form1\" class=\"picform\" method=\"post\">";
        str += "<dl><dt>旧登录密码：</dt><dd>";
        str += "<input type=\"password\" class=\"cont-item\" name=\"pwd\"  id=\"pwd\" size=\"30\"/>";
        str += "</dd></dl><dl> <dt>新密码：</dt><dd>";
        str += "<input type=\"password\" class=\"cont-item\" name=\"newpwd\"  id=\"newpwd\" size=\"30\"/>";
        str += "</dd></dl><dl> <dt>确认密码：</dt><dd>";
        str += "<input type=\"password\" class=\"cont-item\" name=\"newpwd2\"  id=\"newpwd2\" size=\"30\"/>";
        str += "</dd></dl><dl> <dt>&nbsp;</dt><dd>";
        str += "<a href=\"javascript:;\" class=\"btns\" id=\"btn_pwd\" title=\"完成修改\">完成修改</a>";
        str += "</dd></dl></form></div>";
        return str;
    }
    /// <summary>
    /// 购物车
    /// </summary>
    /// <returns></returns>
    private string cartInfo()
    {
        string str = string.Empty, total = "0.00";
        string number = Q("m");
        int count = 0;
        str += "<div class=\"section-header\"><div class=\"fl\"><h2><span>我的购物车</span></h2></div></div>";
        str += "<div class=\"section-content\"><form id=\"form1\" class=\"cartform\" method=\"post\">";
        str += "<div class=\"cart-title\"><ul><li style=\"width:52%\">商品</li><li style=\"width:12%\">单价/元</li><li style=\"width:10%\">数量</li><li style=\"width:12%\">小计/元</li>";
        str += "<li class=\"lastItem\" style=\"width:12%\">操作</li></ul></div><div class=\"cart-cont\">";
        DataSet ds = DBHelp.DataSet_ds("select [Number],[upid],[emid],[title],[price],[ImgS],[count] from [e_cart] where [upid]='" + number + "'", "@value");
        foreach (DataRow rs in ds.Tables[0].Select())
        {
            str += "<ul class=\"item\"><li style=\"width:52%\"><div class=\"item-img\"><input type=\"checkbox\" class=\"item-checkbox\" name=\"item-selected\" ><input type=\"hidden\" id=\"item-gdid\" name=\"item-gdid\" value=\""+ rs["emid"].ToString() + "\" />";
            str += "<a href=\"../item.aspx?id=" + rs["emid"].ToString() + "\" class=\"img-box\" target=\"_blank\"><img src=\"../Apply/avatar.aspx?Type=fixnone&size=50x50&key=" + rs["ImgS"].ToString() + "\" ";
            str += "width=\"50\" height=\"50\" class=\"err-product\" alt=\"" + rs["title"].ToString() + "\" /></a></div>";
            str += "<div class=\"item-title\"><span><a href=\"../item.aspx?id=" + rs["emid"].ToString() + "\" target=\"_blank\" title=\"" + rs["title"].ToString() + "\">" + rs["title"].ToString() + "</a></span></div></li>";
            str += "<li style=\"width:12%\">" + MR(rs["price"].ToString()) + "</li><li class=\"item-count\" style=\"width:10%\">" + rs["count"].ToString() + "</li>";
            // 总价计算
            str += "<li class=\"total-price\" style=\"width:12%\">" + totalPrice(rs["price"].ToString(), rs["count"].ToString()) + "</li>";
            str += "<li class=\"lastItem\" style=\"width:12%\"><span><a href=\"#delete\" data-id=\""+ rs["emid"].ToString() +"\" class=\"delete\">删除</a></span></li></ul>";
        }
        ds.Clear();
        ds.Dispose();
        str += "</div><div class=\"cart-bar clearfix\"><div class=\"select-all\"><div class=\"cart-checkbox\">";
        str += "<input type=\"checkbox\" id=\"toggle-checkboxes_down\" name=\"toggle-checkboxes\" class=\"echeckbox\" >";
        str += "</div>全选</div><div class=\"operation\"><a href=\"#none\" class=\"remove-batch\">删除选中的商品</a></div>  <div class=\"clr\"></div><div class=\"toolbar-right\"><div class=\"normal\"><div class=\"comm-right\">";
        str += "<div class=\"btn-area\"><a href=\"javascript:void(0);\" onclick=\"return false;\" class=\"submit-btn \">去结算<b></b></a></div>";
        str += "<div class=\"price-sum\"><div><span class=\"txt\">总价（不含运费）：</span><span class=\"price\"><em data-bind=\"" + total + "\">¥" + total + "</em></span></div></div>";
        str += "<div class=\"amount-sum\">已选择<em>" + count + "</em>件商品</div><div class=\"clr\"></div>";
        str += "</div></div></div></div></form></div>";
        return str;
    }
    /// <summary>
    /// 我的订单
    /// </summary>
    /// <returns></returns>
    private string ddInfo()
    {
        string str = string.Empty;
        string number = Q("m");
        str += "<div class=\"section-header\"><div class=\"fl\"><h2><span>我的订单</span></h2></div></div>";
        str += "<div class=\"section-content\"><form id=\"form1\" class=\"orderform\" method=\"post\">";
        str += "<div class=\"myOrder-cate\" id=\"myOrder-cate\"><ul><li class=\"current\"><a href=\"javascript:;\"><span>全部<em></em></span></a></li>";
        str += "<li class=\"\"><a href=\"javascript:;\"><span>待评价<em id=\"nocommentNum\">0</em></span></a></li>";
        str += "<li class=\"\"><a href=\"javascript:;\"><span>待收货<em id=\"count-seltime\">0</em></span></a></li>";
        str += "<li class=\"\"><a href=\"javascript:;\"><span>已完成</span></a></li></ul></div>";
        str += "<div class=\"myOrder-record\" id=\"myOrders-list-content\"><div class=\"myOrder-title\"><ul>";
        str += "<li style=\"width:52%\">商品</li><li style=\"width:12%\">单价/元</li><li style=\"width:10%\">数量</li><li style=\"width:12%\">实付款/元</li>";
        str += "<li class=\"lastItem\" style=\"width:12%\">订单状态及操作</li></ul></div><div class=\"myOrder-cont\">";
        DataSet ds = DBHelp.DataSet_ds("select [Number],[upid],[emid],[title],[price],[ImgS],[Stus],[count] from [e_order] where [CloseS]<>1 and [upid]='" + number + "'", "@value");
        foreach (DataRow rs in ds.Tables[0].Select())
        {
            str += "<ul class=\"item\"><li style=\"width:52%\"><div class=\"item-img\"><a href=\"../item.aspx?id="+ rs["emid"].ToString() +"\" class=\"img-box\" target=\"_blank\">";
            str += "<img src=\"../Apply/avatar.aspx?Type=fixnone&size=50x50&key=" + rs["ImgS"].ToString() + "\" width=\"50\" height=\"50\" class=\"err-product\" alt=\"\" /> </a>";
            str += "</div><div class=\"item-title\"><a href=\"../item.aspx?id=" + rs["emid"].ToString() + "\" target=\"_blank\" title=\"" + rs["title"].ToString() + "\">" + rs["title"].ToString() + "</a></div></li>";
            str += "<li style=\"width:12%\">" +  MR(rs["price"].ToString()) + "</li><li style=\"width:10%\">"+ rs["count"].ToString() +"</li>";
            //总价计算
            str += "<li style=\"width:12%\">" + totalPrice(rs["price"].ToString(), rs["count"].ToString()) + "</li>";
            //状态
            str += "<li class=\"lastItem\" style=\"width:12%\"><span><a href=\"#\" class=\"confirm\">"+ ckStatus(rs["Stus"].ToString()) +"</a></span></li></ul>";
        }
        ds.Clear();
        ds.Dispose();
        str += "</div></div></div>";
        return str;
    }

    /// <summary>
    /// 总价计算
    /// </summary>
    /// <param name="value">单价</param>
    /// <param name="num">数量</param>
    /// <returns></returns>
    protected string totalPrice (string value, string num)
    {
        string total = "0.00";
        int count = 0;
        double price = 0.00;
        // 总价计算
        double.TryParse(value, out price);
        int.TryParse(num, out count);
        total = String.Format("{0:F}", price * count);//默认为保留两位搜索
        return total;
    }

    /// <summary>
    /// 订单状态
    /// </summary>
    /// <param name="stus"></param>
    /// <returns></returns>
    protected string ckStatus(string stus)
    {
        string str = string.Empty;
        if( stus == "2")
        {
            str += "<span><a href=\"#\" class=\"finished\">完成交易</a></span>";
            str += "<br><span><a href=\"#\" class=\"showAppra\">查看评价</a></span>";
        }
        else if (stus == "1")
        {
            str += "<span><a href=\"#\" class=\"finished\">完成交易</a></span>";
            str += "<br><span><a href=\"#\" class=\"toAppra\">评价晒单</a></span>";
        }
        else
        {
            str += "<span><a href=\"#\" class=\"confirmed\">确认收货</a></span>";
            str += "<br><span><a href=\"#\" class=\"showLogis\">查看物流</a></span>";
        }
        return str;
    }

    /// <summary>
    /// 收货地址管理
    /// </summary>
    /// <returns></returns>
    private string addrInfo()
    {
        string str = string.Empty;
        string number = Q("m");
        str += "<div class=\"section-header\"><div class=\"fl\"><h2><span>收货地址管理</span></h2></div></div>";
        str += "<div class=\"section-content\"><form id=\"form1\" class=\"addrform\" method=\"post\">";
        string[] value = DBHelp.frS_string("select [Number],[upid],[receN],[receA],[receAD],[Code],[Mobile],[Phone] from [e_address] where [upid]='" + number + "'");
        str += "<dl><dt><span class=\"required\">*</span>收货人：</dt><dd><input type=\"text\" maxlength=\"20\" class=\"cont-item\" name=\"recName\"  id=\"recName\" value=\""+value[2]+"\"/>";
        str += "</dl><dl><dt><span class=\"required\">*</span>收货地址：</dt><dd>";
        str += "<select name=\"ddlProvince\" id=\"ddlProvince\" onchange=\"selectMoreCity(this)\"></select>";
        str += "<select name=\"ddlCity\" id=\"ddlCity\"><option selected value=\"城市\">城市</option></select>";
        str += "</dd></dl><dl><dt>&nbsp;</dt><dd>";
        str += "<textarea name=\"adr-detail\" id=\"adr-detail\"  placeholder=\"详细地址\" maxlength=\"100\" style=\"width:480px;\">"+value[4]+"</textarea>";
        str += "</dd></dl><dl><dt>邮编：</dt><dd>";
        str += "<input type=\"text\" maxlength=\"6\" class=\"cont-item\" name=\"postcode\"  id=\"postcode\" value=\""+value[5]+"\"/>";
        str += "</dl><dl><dt><span class=\"required\">*</span>手机号码：</dt><dd>";
        str += " <input type=\"text\" maxlength=\"15\" class=\"cont-item\" name=\"mobile\"  id=\"mobile\" value=\"" + value[6] + "\"/>";
        str += "&nbsp;&nbsp;或者固定电话<input type=\"text\" maxlength=\"20\" class=\"cont-item\" name=\"phone\"  id=\"phone\" value=\""+ value[7] +"\"/>";
        str += "</dl><dl><dt>&nbsp;</dt><dd>";
        // onClick="return false;"去掉button默认提交行为
        str += "<button class=\"btns\" id=\"btn_addr\" title=\"保存修改\" onClick=\"return false;\" >保存修改</button></dd></dl></form></div>";
        str += "<script type=\"text/javascript\"> EDE.include('Scripts/jquery/city.js');  BindCity('" + value[3] + "');</script>";
        return str;
    }

    /// <summary>
    /// 我的评价
    /// </summary>
    /// <returns></returns>
    private string appraInfo()
    {
        string str = string.Empty;
        string number = Q("m");
        str += "<div class=\"section-header\"><div class=\"fl\"><h2><span>商品评价</span></h2>";
        str += "</div></div><div class=\"section-content\"><div class=\"appraise-title\"><ul>";
        str += "<li style=\"width:52%\">商品</li><li style=\"width:32%\">评价</li>";
        str += "<li class=\"lastItem\" style=\"width:12%\">操作</li></ul></div><div class=\"appraise-cont\">";
        string[] value = DBHelp.frS_string("select [Number],[emid],[title],[Level],[Content] from [e_appra] where [upid]='"+ number +"'");
        if(!string.IsNullOrEmpty(value[0]) )
        {
            str += "<ul class=\"item\"><li style=\"width:52%\"><div class=\"text\">";
            str += "<a href=\"#\" class=\"\" target=\"_blank\" title=\"" + value[2] + "\">" + value[2] + "</a></div></li>";
            str += "<li style=\"width:32%\"><div class=\"text\"><span>" + value[4] + "</div></li>";
            str += "<li class=\"lastItem\" style=\"width:12%\"><span><a href=\"javascript:;\" class=\"confirm\">查看</a></span></li></ul>";
        }
        str += "</div></div>";
        return str;
    }
    #endregion


    #region 表单处理
    protected void vipPost()
    {
        string nickn = R("nickn"), sex = R("sex"), year = R("year"), month = R("month"), ddlCity = R("ddlCity"),
            mobile = R("mobile"), email = R("email"), Content = R("Content");
        string number = Q("m");
        string[] Text = { "NickName", "Sex", "Birth", "Mobile", "Email", "Address", "Content" };
        string[] Value = { nickn, sex, year + "/" + month, mobile, email, ddlCity, Content };
        if (UpdateClass.fromUpdate("e_member", Text, Value, "[Number]='" + number + "'"))
        {
            //更新cookies
            HttpCookie myCook = Request.Cookies["userSett"];
            myCook.Values.Set("nickname", nickn);
            Response.AppendCookie(myCook);

            Write("Xerror|1|修改成功");
        }
        else
            Write("Xerror|0|修改出错");
    }

    protected void vipPwd()
    {
        string number = Q("m");
        string pwd = R("pwd"), newpwd = R("newpwd"), newpwd2 = R("newpwd2");
        string Pass = DBHelp.fr_string("select [Password] from [e_member] where [Number]='" + number + "'");
        //密码加密
        pwd = ask.Web.EncryptHelper.Encrypt(pwd);
        if (pwd != Pass) { Write("Xerror|2|旧密码错误"); return; }
        if (newpwd != newpwd2) { Write("Xerror|2|新密码不一致"); return; }

        newpwd = ask.Web.EncryptHelper.Encrypt(newpwd);
        if (UpdateClass.fromUpdate("e_member", new string[] { "Password" }, new string[] { newpwd }, "[Number]='" + number + "'"))
        {
            //更新cookies
            if (Request.Cookies["uremember"] != null)
            {
                HttpCookie myReme = Request.Cookies["uremember"];
                myReme.Values.Set("password", newpwd);
                Response.AppendCookie(myReme);
            }
            HttpCookie myUser = Request.Cookies["userSett"];
            myUser.Values.Set("password", newpwd);
            Response.AppendCookie(myUser);

            Write("Xerror|1|修改成功");
        }
        else
            Write("Xerror|0|修改出错");
    }

    /// <summary>
    /// 购物车结算
    /// </summary>
    private void vipCart()
    {
        string number = Q("m");
        string gdid = Q("gdid");
        if(!string.IsNullOrEmpty(gdid))
        {
            string[] value = gdid.Split('|');
            foreach(string id in value)
            {
                string[] Info = DBHelp.frS_string("select [upid],[title],[price],[ImgS],[count] from [e_cart] where [emid]='"+ id +"'");
                string[] Text = { "Number", "upid", "emid", "title", "price", "ImgS", "count" };
                string[] Value = { IdNumber.NumberSec("e_order", "or"), number, id, Info[1], Info[2], Info[3], Info[4] };
                if (AddClass.fromAdd("e_order", Text, Value))
                {
                    if (Delet.DeletintW("e_cart", "[upid]='" + number + "' and [emid] in (" + gdid.Replace("|", ",") + ")") > 0)
                        Write("Xerror|1|购买成功");
                    else
                        Write("Xerror|0|购买失败"); 
                }
                else
                    Write("Xerror|0|购买失败");
            }
        }
    }
    /// <summary>
    /// 删除购物车信息
    /// </summary>
    private void deleteCart()
    {
        string number = Q("m");
        string gdid = Q("gdid");
        if (Delet.DeletintW("e_cart", "[upid]='"+ number +"' and [emid] in (" + gdid.Replace("|", ",") + ")") > 0)
            Write("Xerror|1|删除成功");
        else
            Write("Xerror|0|删除失败");
    }
    /// <summary>
    /// 收货地址
    /// </summary>
    private void vipAddr()
    {
        string number = Q("m");
        string recName = R("recName"), ddlCity = R("ddlCity"), adrDetail = R("adr-detail"), postcode = R("postcode"), mobile = R("mobile"), phone = R("phone");
        string check = DBHelp.fr_string("select [receN] from [e_address] where [upid]='" + number + "'");
        string[] Text = { "Number", "upid", "receN", "receA", "receAD", "Code", "Mobile", "Phone" };
        string[] Value = { IdNumber.NumberSec("e_address", "ar"), number, recName, ddlCity, adrDetail, postcode, mobile, phone };
        if(!string.IsNullOrEmpty(check))
        {
            if (UpdateClass.fromUpdate("e_address", Text, Value, "[upid]='"+ number +"'"))
                Write("Xerror|1|保存成功");
            else
                Write("Xerror|0|保存失败");
        }
        else
        {
             if (AddClass.fromAdd("e_address", Text, Value))
                 Write("Xerror|1|保存成功");
             else
                 Write("Xerror|0|保存失败");
        }
    }
    #endregion
}