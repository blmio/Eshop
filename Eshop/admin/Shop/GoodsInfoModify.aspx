<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodsInfoModify.aspx.cs" Inherits="admin_Shop_GoodsInfoModify" StylesheetTheme="Members" %>
<!DOCTYPE html >
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="../../Scripts/admin/ad_/GoodsModify.js"></script>
    <title>产品信息添加、修改</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="tabbtm" id="tabbtm">
            <p class="p"><a id="t1">产品信息</a></p>
            <p><a id="t2">详细信息</a></p>
            <p><a id="t3">图片介绍</a></p>
        </div>
        <div id="divt1" class="dili">
            <table width="98%" border="0" cellspacing="0" cellpadding="0" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)" onmouseout="pWin.changeback(event)">
                <tr>
                    <td width="11%" align="right">产品标题：</td>
                    <td width="39%">
                        <asp:TextBox ID="title" runat="server" Width="280"></asp:TextBox></td>
                    <td width="11%" rowspan="2" align="right">产品子标题：</td>
                    <td width="39%" rowspan="2">
                        <asp:TextBox ID="subtitle" runat="server" Width="280" Height="60" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">产品价格：</td>
                    <td>
                        <asp:TextBox ID="price" runat="server" Width="280" Text="0.00"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">一级类别：</td>
                    <td>
                        <select name="upid" id="upid">
                            <option value="">== 请选择商品类别 ==</option>
                            <%=select(Vt[1])%></select></td>
                    <td align="right">二级类别：</td>
                    <td>
                        <select name="upids" id="upids">
                            <option value="">== 请选择商品类别 ==</option>
                        </select></td>
                </tr>
                <tr>
                    <td align="right">缩略图：</td>
                    <td>
                        <div id="div1">
                            <asp:TextBox ID="ImgS" runat="server" Width="140"></asp:TextBox>
                            &nbsp;<a href="javascript:pWin.Visible('div1','div2')">上传图片</a>
                            <img src="../../images/admin/memo.gif" width="16" height="16" title="图标，可以是网络地址如：http://www.bxite.com/img/sslm_logo.gif 点击 上传图片 是本地上传 " />
                        </div>
                        <div id="div2" style="display: none;">
                            <asp:FileUpload ID="FImgS" runat="server" Width="150" />&nbsp;<a href="javascript:pWin.Visible('div1','div2')">取消上传</a>
                        </div>
                    </td>
                    <td align="right">产品编号：</td>
                    <td>
                        <asp:TextBox ID="emid" runat="server" Width="280"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">购买次数：</td>
                    <td>
                        <asp:TextBox ID="BuyT" runat="server" Width="280"></asp:TextBox></td>
                    <td align="right">浏览次数：</td>
                    <td>
                        <asp:TextBox ID="ScanT" runat="server" Width="280"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">SEO 标 题：</td>
                    <td>
                        <asp:TextBox ID="sitetitle" runat="server" Width="280" /></td>
                    <td rowspan="3" align="right">包装清单：</td>
                    <td rowspan="3">
                        <asp:TextBox ID="PackList" runat="server" Width="280" Height="60" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">SEO关键字：</td>
                    <td>
                        <asp:TextBox ID="Keywords" runat="server" Width="280" /></td>
                </tr>
                <tr>
                    <td align="right">SEO 描 述：</td>
                    <td>
                        <asp:TextBox ID="Description" runat="server" Width="280" /></td>
                </tr>
                <tr>
                    <td align="right">开关设置：</td>
                    <td colspan="3">
                        <asp:CheckBox ID="CloseS" runat="server" Text="关闭" />
                        <asp:CheckBox ID="Reded" runat="server" Text="推荐" />
                        <asp:CheckBox ID="hot" runat="server" Text="热门" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divt2" style="display: none;" class="dili">
            <table width="98%" border="0" cellspacing="0" cellpadding="0" onmouseover="pWin.changeto(event.srcElement ? event.srcElement : event.target)" onmouseout="pWin.changeback(event)">
                <tr>
                    <td align="right" width="15%">详细信息：(标题\内容|标题\内容|...)</td>
                    <td align="left" width="85%">
                        <asp:TextBox ID="Content" runat="server" Width="210" TextMode="MultiLine" Style="display: none"></asp:TextBox><iframe id="I1" frameborder="0" height="240" name="I1" scrolling="No" src="../../eWebEditor/ewebeditor.htm?id=Content&style=expand650&skin=flat9&Page=yes" width="100%"></iframe>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divt3" style="display: none;" class="dili">
            <iframe id="GoodsClass" frameborder="0" height="240" name="goodslist" src="GoodsList.aspx?upid=<%=Vt[0] %>" width="100%"></iframe>
            <div class="Model"><b>图片列表:</b><a id="Goodsadd">新增</a></div>
        </div>
        <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
        <input type="hidden" name="VEtitle" id="VEtitle" value="<%=Vt[0] %>" />
        <input type="hidden" name="Vupid" id="Vupid" value="<%=Vt[1] %>" />
        <input type="hidden" name="Vupids" id="Vupids" value="<%=Vt[2] %>" />
    </form>
</body>
</html>