var url = "../";
function $p(){return document.getElementById?document.getElementById(arguments[0]):eval(arguments[0]);}
function trim(s){if(s!=""&&s!=null){return s.replace(/(^\s*)|(\s*$)/g,"");} return null;}
function XMLHttps()
{
    try{return new ActiveXObject('Msxml2.XMLHTTP'); /*IE5.0*/}catch(e){}
    try{return new ActiveXObject('Microsoft.XMLHTTP'); /*IE5.5*/}catch(e){}
    try{return new XMLHttpRequest();/*IE7及其他类型浏览器*/}catch(e){}
    return null;
}
function TanCen(){
    if(!$p("SX") || !$p("shield"))
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
        if($p("SX")){document.body.removeChild($p("SX"));}
        if($p("shield")){document.body.removeChild($p("shield"));}
    }
}
function hidden()
{
    if($p("SX")){document.body.removeChild($p("SX"));}
    if($p("shield")){document.body.removeChild($p("shield"));}
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
    if(!$p("SXH") || !$p("shieldH"))
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
        if($p("SXH")){document.body.removeChild($p("SXH"));}
        if($p("shieldH")){document.body.removeChild($p("shieldH"));}
    }
    mSx=self.setInterval("hiddenstr()",1000);
}
function hiddenstr()
{
    if($p("SXH")){document.body.removeChild($p("SXH"));}
    if($p("shieldH")){document.body.removeChild($p("shieldH"));}
    mSx=window.clearInterval(mSx);
}
