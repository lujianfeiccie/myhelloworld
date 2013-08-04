<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="AddNote.aspx.cs" Inherits="AddNote" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content_left_guid">
            <div id="content_left_guid_head"></div>
            
                 <a href="NoteList.aspx?type=zx"><div  class="content_left_guid_item_on"  >在线咨询</div></a>       
                  <a href="NoteList.aspx?type=mail"><div  class="content_left_guid_item"  >馆长信箱</div> </a>    
                 <a href="NoteList.aspx?type=dc"><div  class="content_left_guid_item"  >在线调查</div> </a>  
                  
            
        </div>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">在线咨询</span><span class="head_right" id="sitemap" runat="server">当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;</span></div>

               <div id="addnewnote">

                    <div class="input" style="display:none;">标题：<input id="title" type="text" value="在线咨询" style="width:439px;" /><a name="#re"></a></div>
                    <div class="input">内容：<textarea id="info" onkeyup="checkLength(this);" style="width: 442px; height: 139px;"></textarea></div>
                    <div style=" padding-left:50px; margin-bottom:40px;"><input onclick="submitzx()" type="button" value="我要发表" />还可以输入&nbsp;<font id="chLeft" color="red">300</font>&nbsp;字<input type="hidden" value="" id="replyid" /></div>
                    <script type="text/javascript" language="javascript">
                    function checkLength(which) {
                    var maxChars = 300;
                    if (which.value.length > maxChars)
                    which.value = which.value.substring(0,maxChars);
                    var curr = maxChars - which.value.length;
                    document.getElementById("chLeft").innerHTML = curr.toString();
                    }
                    </script>

              

                  
                  

               </div>
            
        </div>
 <script type="text/javascript" language="javascript">
 function reply(titleid)
 {
    var title= $("#title"+titleid).text();
    $("#title").val(title);
    $("#title").attr("disabled","disabled");
    $("#replyid").val(titleid);
    
 }
 function submitzx()
 {
    var title=$("#title").val();
    var info=$("#info").val();
    var replyid=$("#replyid").val();
    if(title==""||info=="")
    {
        alert("请输入内容");
        return;
    }
    else
    {
         $.ajax({ type:"Get",
           url: "DoNote.aspx",
           cache: false,
           data:"act=add&type=zx&title="+escape(title)+"&info="+escape(info),
           success: function(data){
                    if(data=="ok")
                    {
                        alert("发布成功！");
                        location.href="NoteList.aspx?type=zx";
                    }
                    else
                    {
                         alert(data);
                     }
           }
        }); 
    }
 }
 
 function submitmail()
 {
     var title=$("#title2").val();
    var info=$("#info2").val();
    var typename=$("#typename").val();
    if(title==""||info=="")
    {
        alert("请输入内容");
        return;
        
    }
    else
    {
         $.ajax({ type:"Get",
           url: "DoNote.aspx",
           cache: false,
           data:"act=add&type=mail&title="+escape(title)+"&info="+escape(info)+"&typename="+escape(typename),
           success: function(data){
                    if(data=="ok")
                    {
                         alert("发布成功！");
                        location.href="NoteList.aspx?type=zx";
                    }
                    else
                    {
                         alert(data);
                     }
           }
        }); 
    }
 }
 
 </script>
</asp:Content>

