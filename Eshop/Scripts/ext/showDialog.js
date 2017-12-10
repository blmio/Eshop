function showDialog(url){
    //url = url.toLowerCase();
    if (!history.saved){saveHistory();}
    var arr = showModalDialog(url, window, "dialogWidth:0px;dialogHeight:0px;help:no;scroll:no;status:no");
    saveHistory();
}
function showMsDialog(url,width,height){
    if (!history.saved){saveHistory();}
    var arr = showModelessDialog(url, window, "dialogWidth:" + width + "px;dialogHeight:" + height + "px;help:no;scroll:no;status:no");
    saveHistory();
}

function showopen(url,name,iWidth,iHeight){
    //var url; //转向网页的地址;
    //var name; //网页名称，可为空;
    //var iWidth; //弹出窗口的宽度;
    //var iHeight; //弹出窗口的高度;
    var iTop = (window.screen.availHeight-30-iHeight)/2; //获得窗口的垂直位置;
    var iLeft = (window.screen.availWidth-10-iWidth)/2; //获得窗口的水平位置
    var selProdWnd = window.open(url,name,'height='+iHeight+',,innerHeight='+iHeight+',width='+iWidth+',innerWidth='+iWidth+',top='+iTop+',left='+iLeft+',toolbar=no,menubar=no,scrollbars=no,resizeable=no,location=no,status=no');
    if(selProdWnd.opener == null) selProdWnd.opener = self;return (false);
}

var sCurrMode = null;
var history = new Object;
history.data = [];
history.position = 0;
history.bookmark = [];
history.saved = false;

function saveHistory() {
	history.saved = true;
	var html = getHTML();
	if (history.data[history.position] != html){
		var nBeginLen = history.data.length;
		var nPopLen = history.data.length - history.position;
		for (var i=1; i<nPopLen; i++){
			history.data.pop();
			history.bookmark.pop();
		}

		history.data[history.data.length] = html;

		if (document.selection.type != "Control"){
			try{
				history.bookmark[history.bookmark.length] = document.selection.createRange().getBookmark();
			}catch(e){
				history.bookmark[history.bookmark.length] = "";
			}
		} else {
			var oRng = document.selection.createRange();
			var el = oRng.item(0);
			history.bookmark[history.bookmark.length] = "[object]|" + el.tagName + "|" + getElementTagIndex(el);
		}

		if (nBeginLen!=0){
			history.position++;
		}
	}
}

function getHTML() {
	var html;
	if((sCurrMode=="EDIT")||(sCurrMode=="VIEW")){
		html = document.body.innerHTML;
	}else{
		html = document.body.innerText;
	}
	if (sCurrMode!="TEXT"){
		if ((html.toLowerCase()=="<p>&nbsp;</p>")||(html.toLowerCase()=="<p></p>")){
			html = "";
		}
	}
	return html;
}

function Commlodurl(url) { showDialog(url); }