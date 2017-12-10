using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Drawing;
using ask;

public partial class Apply_avatar : System.Web.UI.Page
{
    string UsID;
    protected void Page_Load(object sender, EventArgs e)
    {
        UsID = Request.QueryString["ImgID"];
        string Type = Request.QueryString["Type"];
        Response.Write(Write(Type));
    }
    private string Write(string Type)
    {
        switch (Type)
        {
            case "ImgID":
                Response.Redirect(ImgID(UsID));
                return "";
            case "agencyData":
                Response.Redirect(agencyData(UsID));
                return "";
            case "forum_new":
                Response.Redirect(forum_new(UsID));
                return "";
            case "Level":
                Response.Redirect(Level(UsID));
                return "";
            case "UPhotos":
                Response.Redirect(UPhotos(UsID));
                return "";
            case "fixnone":
                fixnone();
                return "";
        }
        return "../Temp/get_image.gif";
    }
    /// <summary>
    /// 机构头像
    /// </summary>
    /// <param name="UsID"></param>
    /// <returns></returns>
    private string agencyData(string UsID)
    {
        string syst = Request["syst"];
        string ImgID = Request["ImgID"];
        string Vt = DBHelp.fr_string("select [ImgS] from [agencyData] where [Number]='" + ImgID + "'");
        string str = "~/Temp/no-pic.jpg";
        if (!string.IsNullOrEmpty(Vt))
            str = Vt;
        if (!System.IO.File.Exists(Request.MapPath(str)))
        {
            if (syst == "yes")
                str = "~/image/systempm.png";
            else
                str = "~/Temp/no-pic.jpg";
        }
        return Level(str);
    }
    /// <summary>
    /// 会员图片
    /// </summary>
    /// <param name="UsID"></param>
    /// <returns></returns>
    private string UPhotos(string UsID)
    {
        string size = Request["size"];
        string syst = Request["syst"];
        string str = "~/image/noavatar_middle.gif";
        if (!string.IsNullOrEmpty(UsID))
            str = "~/upload/avatars/" + UsID + "/" + size + ".jpg";
        if (string.IsNullOrEmpty(str))
            str = "~/image/noavatar_middle.gif";
        if (!System.IO.File.Exists(Request.MapPath(str)))
        {
            if (syst == "yes")
                str = "~/image/systempm.png";
            else
                str = "~/image/noavatar_middle.gif";
        }
        return Level(str);
    }
    private string Level(string str) { return strFunction.Auth(str); }
    private string forum_new(string str)
    {
        if (string.IsNullOrEmpty(str)) str = "~/Temp/forum_new.gif";
        return strFunction.Auth(str);
    }
    private string ImgID(string UsID)
    {
        if (string.IsNullOrEmpty(UsID)) UsID = "~/Temp/noavatar_middle.gif";
        return strFunction.Auth(UsID);
    }
    /// <summary>
    /// 生成图片
    /// </summary>
    /// <returns></returns>
    private void fixnone()
    {
        string aid = Request["aid"];
        string size = Request["size"];
        string key = Request["key"];
        if (!System.IO.File.Exists(Server.MapPath(key))) key = "~/Temp/get_image.gif";
        string[] Si = size.Split('x');
        int sW = 100, sH = 100;
        int.TryParse(Si[0], out sW);
        int.TryParse(Si[1], out sH);

        string name = key, Tn, Tm;//得到文件名字
        name = System.IO.Path.GetExtension(name);
        Tn = name.Replace(".", "");
        Tm = Tn.ToUpper();
        MakeThumbnail(Server.MapPath(key), sW, sH, "Cut", Tm);
    }
    /// <summary>
    /// 生成缩略图
    /// </summary>
    /// <param name="originalImagePath">源图路径（物理路径）</param>
    /// <param name="width">缩略图宽度</param>
    /// <param name="height">缩略图高度</param>
    /// <param name="mode">生成缩略图的方式</param> 
    private void MakeThumbnail(string originalImagePath, int width, int height, string mode, string type)
    {
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

        int towidth = width;
        int toheight = height;
        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;
        switch (mode)
        {
            case "HW"://指定高宽缩放（可能变形） 
                break;
            case "W"://指定宽，高按比例 
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://指定高，宽按比例
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://指定高宽裁减（不变形） 
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            case "DB"://等比缩放（不变形，如果高大按高，宽大按宽缩放） 
                if ((double)originalImage.Width / (double)towidth < (double)originalImage.Height / (double)toheight)
                {
                    toheight = height;
                    towidth = originalImage.Width * height / originalImage.Height;
                }
                else
                {
                    towidth = width;
                    toheight = originalImage.Height * width / originalImage.Width;
                }
                break;
            default:
                break;
        }

        //新建一个bmp图片
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

        //新建一个画板
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //清空画布并以透明背景色填充
        g.Clear(System.Drawing.Color.Transparent);

        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
        new System.Drawing.Rectangle(x, y, ow, oh),
        System.Drawing.GraphicsUnit.Pixel);
        //System.Drawing.Font f = new System.Drawing.Font("Verdana", 12);
        //System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Gray);
        //g.DrawString(addText, f, b, 5, height - 40);
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        try
        {
            //保存缩略图
            if (type == "JPG") { bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); }
            if (type == "BMP") { bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp); }
            if (type == "GIF") { bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Gif); }
            if (type == "PNG") { bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png); }
            Response.ClearContent();
            Response.ContentType = "Image/Gif";
            Response.BinaryWrite(ms.ToArray());
        }
        catch (System.Exception e) { throw e; }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }
}
