<%@ Page Language="C#" AutoEventWireup="true" CodeFile="portrait.aspx.cs" Inherits="vip_item_portrait" %>
<!doctype html>
<html class="root">
<head runat="server">
<meta charset="utf-8">
<title>头像修改-e商城</title>
<link href="../../App_Themes/index/index.css" rel="stylesheet">
<link href="../../App_Themes/public/global.css" rel="stylesheet" >
<link href="../../App_Themes/vip/index.css" rel="stylesheet" />
</head>
<body>
<div class="right">
  <div class="section-header">
    <div class="fl">
      <h2><span>头像修改</span></h2>
    </div>
  </div>
  <div class="section-content">
    <form id="form1" class="picform" method="post" runat="server">
      <dl>
        <dt>图片文件：</dt>
        <dd>
          <asp:FileUpload ID="FImgS" runat="server" class="f_img" style="padding:0;"/>
          <asp:LinkButton ID="btn_preview" runat="server" class="btns" Text="保存修改" OnClick="btn_preview_Click" ></asp:LinkButton>
          <asp:Label ID="tips" runat="server" Text="" class="style-red" ></asp:Label>
        </dd>
      </dl>
    </form>
  </div>
</div>
</body>
</html>
