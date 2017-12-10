<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageNum.ascx.cs" Inherits="Ascx_Order_PageNum" %>
<%=html%>
<%=input("2")%>
<script type="text/javascript">
    Pagerul = '<%=strid("$||$") %>'; pageall = '<%=Pageall %>';
    function checkPage(evt, page) {
        evt = (evt) ? evt : ((window.event) ? event : null);
        if (isNaN(page)) { page = ""; return false; } if (evt) {
            if (evt.keyCode == 13) {
                if (page != "") LPage(page);
            }
        }
    }
    function LPage(page) {
        if (Number(pageall) < Number(page)) return false;
        if (page == "") return false;
        if (Pagerul != null) {
            Pagerul = Pagerul.replace("$||$", page);
            location.href = Pagerul;
        }
    }
</script>

