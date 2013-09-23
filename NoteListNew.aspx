<%@ Page Language="C#" MasterPageFile="~/AllPage2.master" AutoEventWireup="true" CodeFile="NoteListNew.aspx.cs" Inherits="NoteListNew" Title="Untitled Page" %>
<%@ Register Src="~/Contrl/PageNum.ascx" TagName="pagelist" TagPrefix="ucl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content_left_guid">
            <div id="content_left_guid_head"></div>
            
                 <a href="NoteList.aspx?type=zx"><div <%=zx %> >在线咨询</div></a>       
                  <a href="NoteList.aspx?type=mail"><div <%=mail %> >馆长信箱</div> </a>    
                 <a href="NoteList.aspx?type=dc"><div <%=dc %> >在线调查</div> </a>  
                  
            
        </div>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">在线咨询</span><span class="head_right" id="sitemap" runat="server">当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;</span></div>
               <%if (type == "zx")
                 { %>
                 <div ><input onclick="javascript:location.href='addnote.aspx'" type="button" value="我要咨询" /></div>
               <ul class="news_list" style="padding-left:0px;">
                    <asp:Repeater ID="note_list" runat="server">
                    <ItemTemplate>
                    <li class="news_list_item" style="line-height:22px; background-color:#f0f0f0; margin-bottom:15px;"><span class="datetime"><%# myfun.ShortDateTime(DateTime.Parse(DataBinder.Eval(Container.DataItem,"pub_time").ToString()),"YMD") %></span>【<%# DataBinder.Eval(Container.DataItem,"pub_user")%>】&nbsp;在线咨询：<a href="#re" style="padding-left:40px; float:right; display:none;" ><%# ShowIsReply(bool.Parse(DataBinder.Eval(Container.DataItem, "isover").ToString()))%></a><br />
                        <span style="line-height:22px; text-indent:2em;"><%# DataBinder.Eval(Container.DataItem,"info")%><br />
                        <%# ShowReply(DataBinder.Eval(Container.DataItem,"replyuser").ToString(), myfun.ShortDateTime(DateTime.Parse(DataBinder.Eval(Container.DataItem,"replytime").ToString()),"YMD"),DataBinder.Eval(Container.DataItem,"replyinfo").ToString()) %>  </span> </li></ItemTemplate>
                </asp:Repeater>
               </ul>
               <ucl:pagelist ID="mypage" runat="server"  />
               <%} %>
               <div id="addnewnote">
               <% if (type == "zx")  { %>
                    <div class="input" style="display:none;">标题：<input id="title" type="text" value="在线咨询" style="width:439px;" /><a name="#re"></a></div>
                    <div class="input" style="display:none;">内容：<textarea id="info" onkeyup="checkLength(this);" style="width: 442px; height: 139px;"></textarea></div>
                    <div style=" padding-left:50px; margin-bottom:40px;display:none;"><input onclick="submitzx()" type="button" value="我要发表" />还可以输入&nbsp;<font id="chLeft" color="red">300</font>&nbsp;字<input type="hidden" value="" id="replyid" /></div>
                    <script type="text/javascript" language="javascript">
                    function checkLength(which) {
                    var maxChars = 300;
                    if (which.value.length > maxChars)
                    which.value = which.value.substring(0,maxChars);
                    var curr = maxChars - which.value.length;
                    document.getElementById("chLeft").innerHTML = curr.toString();
                    }
                    </script>
               <% }
                  else if (type == "mail")
                  { %>
                    
                    <div class="input">标题：<input id="title2" type="text" style="width:320px;" />
                        <select id="typename">
                            <option selected="selected" value="信息服务">信息服务</option>
                            <option  value="工作评价与建议">工作评价与建议</option>
                            <option  value="投诉处理">投诉处理</option>
                            <option  value="其他问题">其他问题</option>
                        </select>
                    </div>
                    <div class="input">内容：<textarea id="info2" style="width: 442px; height: 139px"></textarea></div>
                    <div style=" padding-left:50px; margin-bottom:40px;"><input type="button" onclick="submitmail()" value="发表" /></div>
               <% }
                  else
                  { %>
                  
                  <div class="right_block" id="vote" style="width:560px; padding-left:8px;">
                        <div class="right_block_head"><span class="head_title">在线调查</span></div>
                        <div class="right_block_info" id="myvote">
                             <ul id="lib_vote" runat="server">
                                
                                              
                            </ul>
                        </div>
                    </div>
                  <script language="javascript" type="text/javascript">
                  
                    var indexoriginhtml=$("#myvote").html(); //获取最原始的投票代码 
                  </script>
               <%} %>
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

