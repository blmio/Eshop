using System;
using System.Collections.Generic;
using System.Data;
using ask;

public partial class vip_item_portrait : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_preview_Click(object sender, EventArgs e)
    {
        string Imgad = string.Empty;
        string Number = Request.Cookies["userSett"]["number"];
        if (!string.IsNullOrEmpty(this.FImgS.FileName))
        {
            Imgad = shopfile.FileGet(this.FImgS, "bxite-" + Number, "~/upload/vip", 50000000);
            if (UpdateClass.fromUpdate("e_member", new string[] { "UserPic" }, new string[] { Imgad }, "[Number]='" + Number + "'"))
                this.tips.Text = "修改成功";
            else
                this.tips.Text = "修改出错，请重试";
        }
        else
            this.tips.Text = "请先选择图片";
    }
}