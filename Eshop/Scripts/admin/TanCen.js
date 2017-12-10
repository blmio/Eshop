function XMLHttps()
{
    try{return new ActiveXObject('Msxml2.XMLHTTP'); /*IE5.0*/}catch(e){}
    try{return new ActiveXObject('Microsoft.XMLHTTP'); /*IE5.5*/}catch(e){}
    try{return new XMLHttpRequest();/*IE7及其他类型浏览器*/}catch(e){}
    return null;
}

function TanCen(){
    if(!$("SX") || !$("shield"))
    {
    //背景层
        var shield=document.createElement("div");
        shield.id="shield";
        shield.className = "shieldH";
        document.body.appendChild(shield);
        var SX=document.createElement("div");
        SX.id="SX";
        SX.className = "SXH";
        SX.innerHTML="<div style=\"padding:10px;width:300px;height:40px;border:1px solid #D1D1D1;text-align:center;background-color: #FFFFFF;\"><img src=\""+ url +"images/images/loading.gif\" /></div>";
        document.body.appendChild(SX);
    }else{
        if($("SX")){document.body.removeChild($("SX"));}
        if($("shield")){document.body.removeChild($("shield"));}
    }
}
function hidden()
{
    if($("SX")){document.body.removeChild($("SX"));}
    if($("shield")){document.body.removeChild($("shield"));}
}

function TLNode(node,str)
{
    var nodeTemp=node,l=0;
    while(nodeTemp!=document.body&&nodeTemp!=null)
    {
	    if(str=="Top"){l+=nodeTemp.offsetTop;}
	    if(str=="Left"){l+=nodeTemp.offsetLeft;}
	    nodeTemp=nodeTemp.offsetParent;
	}
    return l;
}

var mSx;

function TanCenstr(str){
    if(!$("SXH") || !$("shieldH"))
    {
    //背景层
        var shield=document.createElement("div");
        shield.id="shieldH";
        shield.className = "shieldH";
        document.body.appendChild(shield);
        var SX=document.createElement("div");
        SX.id="SXH";
        SX.className = "SXH";
        SX.innerHTML="<div style=\"padding:10px;width:300px;height:40px;border:1px solid #D1D1D1;text-align:center;background-color: #FFFFFF;\">"+str+"</div>";
        document.body.appendChild(SX);
    }else{
        if($("SXH")){document.body.removeChild($("SXH"));}
        if($("shieldH")){document.body.removeChild($("shieldH"));}
    }
    mSx=self.setInterval("hiddenstr()",1000);
}
function TanCe(str) {
    if (!$("SXH") || !$("shieldH")) {
        //背景层
        var shield = document.createElement("div");
        shield.id = "shieldH";
        shield.className = "shieldH";
        document.body.appendChild(shield);
        var SX = document.createElement("div");
        SX.id = "SXH";
        SX.className = "SXH";
        SX.innerHTML = "<div style=\"padding:10px;width:300px;height:40px;border:1px solid #D1D1D1;text-align:center;background-color: #FFFFFF;\" id='TanCstrm'>" + str + "</div>";
        document.body.appendChild(SX);
    } else {
        if ($("SXH")) { document.body.removeChild($("SXH")); }
        if ($("shieldH")) { document.body.removeChild($("shieldH")); }
    }
}
function TanCstr(s) { $("TanCstrm").innerHTML = s; }
function hiddenstr()
{
    if($("SXH")){document.body.removeChild($("SXH"));}
    if($("shieldH")){document.body.removeChild($("shieldH"));}
    mSx=window.clearInterval(mSx);
}

var TBcust = 0,Pagerul = "",pageall=0;

function Pages(Page){if(Pagerul!=""){
    if(document.getElementById("VwmM") && !Vwm.hidden)
        window.VwmM.location.href = Pagerul+"&Page=" + Page;
    if(document.getElementById("BasicR") && !winlay.hidden)
        window.BasicR.location.href = Pagerul+"&Page=" + Page;
    else
        window.btFrame.comi1.location.href = Pagerul + "&Page=" + Page;
}}
function checkPage(evt,page){
    evt = (evt) ? evt : ((window.btFrame.comi1.event) ? event : null);
    if(pageall<=1){return false;}
    var Textp = window.btFrame.comi1.document.getElementById("PageText").value;
    if(isNaN(page) && page==""){Textp = "";return false;}
    if(evt){if (evt.keyCode==13){
        var pa = Number(page);if(pa<=pageall){Pages(page);}else{return false;}
    }}else{return false;}
}
function changeUrl(page){if(pageall > 1){if(!isNaN(page) && page != ""){var pa = Number(page);if(pa <= pageall){Pages(page);}}}}

function sAlert(str)
{
	var msgw,msgh,bordercolor,bxite,ht,com;
    ht="http:";
	msgw=460;//提示窗口的宽度
    msgh=300;//提示窗口的高度
	com=".com/";
    bordercolor="#336699";//提示窗口的边框颜色
    titlecolor="#99CCFF";//提示窗口的标题颜色
	bxite="//bxite";//提示窗口的路径
    
    var sWidth,sHeight;
    sWidth=document.body.offsetWidth;
    sHeight=document.body.offsetHeight;
	
    var bgObj=document.createElement("div");
    bgObj.setAttribute('id','bgDiv');
    bgObj.style.position="absolute";
    bgObj.style.top="0";
    bgObj.style.background="#777";
    bgObj.style.filter="progid:DXImageTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75";
    bgObj.style.opacity="0.6";
    bgObj.style.left="0";
    bgObj.style.width=sWidth + "px";
    bgObj.style.height=sHeight + "px";
    document.body.appendChild(bgObj);
    var msgObj=document.createElement("div");
    msgObj.setAttribute("id","msgDiv");
    msgObj.setAttribute("align","center");
    msgObj.style.position="absolute";
    msgObj.style.background="white";
    msgObj.style.font="12px/1.6em Verdana, Geneva, Arial, Helvetica, sans-serif";
    msgObj.style.border="1px solid " + bordercolor;
    msgObj.style.width=msgw + "px";
    msgObj.style.height=msgh + "px";
    msgObj.style.top=(document.documentElement.scrollTop + (sHeight-msgh)/2) + "px";
    msgObj.style.left=(sWidth-msgw)/2 + "px";
    var title=document.createElement("h4");
    title.setAttribute("id","msgTitle");
    title.setAttribute("align","right");
    title.style.margin="0";
    title.style.padding="3px";
    title.style.background=bordercolor;
    title.style.filter="progid:DXImageTransform.Microsoft.Alpha(startX=20, startY=20, finishX=100, finishY=100,style=1,opacity=75,finishOpacity=100);";
    title.style.opacity="0.75";
    title.style.border="1px solid " + bordercolor;
    title.style.height="18px";
    title.style.font="12px Verdana, Geneva, Arial, Helvetica, sans-serif";
    title.style.color="white";
    title.style.cursor="pointer";
    title.innerHTML="关闭";
    title.onclick=function()
	{
		document.body.removeChild(bgObj);
		document.getElementById("msgDiv").removeChild(title);
		document.body.removeChild(msgObj);
	}
    document.body.appendChild(msgObj);
    document.getElementById("msgDiv").appendChild(title);
    var txt=document.createElement("p");
    txt.style.margin="1em 0"
    txt.setAttribute("id","msgTxt");
	txt.innerHTML = "<iframe src=\"" + ht+bxite+com+"admin/"+str + "\" width=\"100%\" height=\"100%\" frameborder=\"0\" style=\"border:none;\"></iframe>";
    document.getElementById("msgDiv").appendChild(txt);
}

var  highlightcolor='#F3FFE3';
//此处clickcolor只能用win系统颜色代码才能成功,如果用#xxxxxx的代码就不行,还没搞清楚为什么:(
var  clickcolor='#F3FFE3';
var cs,source,even;
function changeto(sou)
{
    try{
	    source=sou;
	    if(source!=null)
	    {
	        if(source.tagName=="TR"||source.tagName=="TABLE")
	        return;
	        while(source.tagName!="TD")
	        source=source.parentElement;
	        source=source.parentElement;
	        cs  =  source.children;
	        if  (cs[0].style.backgroundColor!=highlightcolor&&source.id!="nc"&&cs[0].style.backgroundColor!=clickcolor)
	        {
		        for(i=0;i<cs.length;i++)
		        {
			        cs[i].style.backgroundColor=highlightcolor;
		        }
	        }
	    }
	}catch(e){}
}

function changeback(evens)
{
    try{
	    even = evens;
		if(even.fromElement.contains(even.toElement)||source.contains(even.toElement)||source.id=="nc")
	    return;
	    if(cs!=null)
	    {
	        if(even.toElement!=source&&cs[0].style.backgroundColor!=clickcolor)
	        {
		        for(i=0;i<cs.length;i++)
		        {
			        cs[i].style.backgroundColor="";
		        }
	        }
	    }
	}catch(e){}
}


function chkDelet(strM)
{
    var str = "";
    var i = 0;
    var objForm = btFrame.comi1.document.getElementsByTagName("input");
    var objLen = objForm.length;
    for (var iCount = 0; iCount < objLen; iCount++)
    {
        if (objForm[iCount].type == "checkbox")
        {
            if(objForm[iCount].name=="check" && objForm[iCount].checked == true)
            {
                if(i==0)
                {
                    str += objForm[iCount].value;
                }
                else
                {
                    str += "|" + objForm[iCount].value
                }                
                i++;
            }
        }
    }
    if(str!="")
    {
        BoxfirmD("真的要删除这些记录吗?",strM + "&id=" + str);
    }
    else
    {
        alert("请选取后再提交！");
    }
}

function chkalls(input2)
{
    var objdoc = btFrame.comi1.document;
    var objForm = objdoc.getElementsByTagName("input");
    var objLen = objForm.length;
    for (var iCount = 0; iCount < objLen; iCount++){
        if (input2.checked == true){
             if (objForm[iCount].type == "checkbox") objForm[iCount].checked = true;
        }else{
            if (objForm[iCount].type == "checkbox") objForm[iCount].checked = false;
        }
    }
}

//判断第一个为显示div
function Visible(div1, div2) {
    var objdoc = eval(frid + '.document');
    if (objdoc.getElementById(div1).style.display == "none") {
        objdoc.getElementById(div1).style.display = "block"; objdoc.getElementById(div2).style.display = "none";
    } else {
        objdoc.getElementById(div1).style.display = "none"; objdoc.getElementById(div2).style.display = "block";
    }
}
//判断第一个为显示div
function Visili(div1, div2) {
    var objdoc = listframe.document;
    if (objdoc.getElementById(div1).style.display == "none") {
        objdoc.getElementById(div1).style.display = "block"; objdoc.getElementById(div2).style.display = "none";
    } else {
        objdoc.getElementById(div1).style.display = "none"; objdoc.getElementById(div2).style.display = "block";
    }
}