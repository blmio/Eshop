using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using ask;

public partial class member_login : System.Web.UI.Page
{
    protected string[] Rv = new string[3];
    private NameValueCollection SinaSection = (NameValueCollection)ConfigurationManager.GetSection("SinaSectionGroup/SinaSection");
    private NameValueCollection QzoneSection = (NameValueCollection)ConfigurationManager.GetSection("QQSectionGroup/QzoneSection");
    protected string sinaKey, sinaSecret, scallbackUrl;
    protected string qqKey, qqSecret, qcallbackUrl, scope;

    protected void Page_Load(object sender, EventArgs e)
    {
        //微博登录
        sinaKey = SinaSection["AppKey"];
        sinaSecret = SinaSection["AppSecret"];
        scallbackUrl = SinaSection["CallBackURI"];   //请自行设置回调地址，一般这里不用填应用实际地址，填站内应用地址也是可以的
        //QQ登录
        qqKey = QzoneSection["AppKey"];
        qqSecret = QzoneSection["AppSecret"];
        qcallbackUrl = QzoneSection["CallBackURI"];   //请自行设置回调地址，一般这里不用填应用实际地址，填站内应用地址也是可以的
        scope = "get_user_info,add_share,list_album,upload_pic,check_page_fans,add_t,add_pic_t,del_t,get_repost_list,get_info,get_other_info,get_fanslist,get_idolist,add_idol,del_idol,add_one_blog,add_topic,get_tenpay_addr";
                
        // 是否选择自动登录
        if (Request.Cookies["uremember"] != null)
        {
            Rv[0] = Request.Cookies["uremember"]["username"];
            Rv[1] = ask.Web.EncryptHelper.Decrypt(Request.Cookies["uremember"]["password"]);
            if (!string.IsNullOrEmpty(Rv[0])) Rv[2] = "on";
        }
    }
}