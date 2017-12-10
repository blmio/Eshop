<%@ Page Language="C#" AutoEventWireup="true" CodeFile="head.aspx.cs" Inherits="Apply_head" %>
var Eurl = "<%=Route %>";
function wsystem() {
    //平台、设备和操作系统
    var system = { win: false, mac: false, xll: false, ipad: false };
    //检测平台
    var p = navigator.platform; system.win = p.indexOf("Win") == 0; system.mac = p.indexOf("Mac") == 0;
    system.x11 = (p == "X11") || (p.indexOf("Linux") == 0);
    system.ipad = (navigator.userAgent.match(/iPod/i) != null) ? true : false;
    if (system.win || system.mac || system.xll || system.ipad) {
        //PC计算机电脑
        return true;
    } else {
        //手机
        return false;
    }
}
if (!wsystem()) {
    location.href = "http://wap.eshop.com/";
}
document.write('<script type="text/javascript" src="' + Eurl + 'Scripts/jquery/jquery-min.js\"></script>');
document.write('<script type="text/javascript" src="' + Eurl + 'Scripts/global.js\"></script>');