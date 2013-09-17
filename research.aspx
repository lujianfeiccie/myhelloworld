<%@ Page Language="C#" MasterPageFile="~/AllPage2.master" AutoEventWireup="true"
    CodeFile="research.aspx.cs" Inherits="research" Title="Untitled Page" %>

<%-- 在此处添加内容控件 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   <div class="content_center_info" >
    <div class="content_center_info_head" >
         <span class="head_title" id="title1" runat="server">在线调查</span></div>
           <div id="myvote">
           <ul class="content_center_info_ul" id="lib_vote" runat="server">
          <!-- <li><strong>您对图书馆网站的评价</strong></li>
            <li>
                <input type="radio" name="web_vote_value" value="4" />非常好</li>
            <li>
                <input type="radio" name="web_vote_value" value="7" />比较好</li>
            <li>
                <input type="radio" name="web_vote_value" value="2" />一般</li>
            <li>
                <input type="radio" name="web_vote_value" value="5" />比较差</li>
            <li>
                <img onclick="vote();" src="Images/vote.gif" />&nbsp;&nbsp;
                <img onclick="viewvote();" src="images/view.gif" /></li>
            -->
        </ul>
        </div>
    </div>
    <script type="text/javascript" language="javascript">
jQuery(function($) {
  createCode();
}); 
var indexoriginhtml=$("#myvote").html(); //获取最原始的投票代码 
function showToolTip2(evt)
{
     if (evt) {
        var url = evt.target;
    }
    else {
        evt = window.event;
        var url = evt.srcElement;
    }
    xPos = evt.clientX;
    yPos = evt.clientY;

   var toolTip = document.getElementById("toolTip");
   
  toolTip.style.top = parseInt(yPos)+2 + "px";
 //  toolTip.style.left = parseInt(xPos)+2 + "px";
   toolTip.style.visibility = "visible";
   
}
</script>
</asp:Content>
