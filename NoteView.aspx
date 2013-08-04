<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="NoteView.aspx.cs" Inherits="NoteView" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div id="content_left_guid">
            <div id="content_left_guid_head"></div>
                        
                
        </div>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">在线咨询</span><span class="head_right" id="sitemap" runat="server">当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;</span></div>
               <div id="content_center_info_main">
                    <div id="news_title"><%=mynote.Title %></div>
                    <div id="news_publisher">发布时间：<%=myfun.ShortDateTime(mynote.PubTime,"YMD") %>&nbsp;&nbsp;&nbsp;&nbsp;点击数：<%=mynote.VisitNum%>次</div>
                    <div id="news_info"><%=mynote.Info %></div>
               </div>
              <% if(Session["userid"]!=null&&Session["userid"].ToString()!=""){ %>
              <hr />
              <div style="padding-left:10px; line-height:20px; font-size:13px;">回复如下：<br />
              <%=mynote.ReplyInfo %>
              </div>
              <%} %>
               <% if (Session["admin"]!=null&&Session["admin"].ToString()=="ok")
                  { %>
                    <div class="input" style="display:none;">标题：<input id="title" value="<%=mynote.Title %>" disabled="disabled" type="text" style="width:439px;" /><a name="#re"></a></div>
                    <div class="input">回复：<textarea id="info" style="width: 442px; height: 139px"><%=mynote.ReplyInfo %></textarea></div>
                    <div style=" padding-left:50px; margin-bottom:40px;"><input onclick="submitzx()" type="button" value="发表" /><input type="hidden" value="<%=mynote.NoteID %>" id="replyid" /></div>
                    <script language="javascript" type="text/javascript">
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
                                       data:"replyid="+replyid+"&act=reply&type=zx&title="+escape(title)+"&info="+escape(info),
                                       success: function(data){
                                                if(data=="ok")
                                                {
                                                    location.href="NoteView.aspx?id="+replyid;
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
                <%} %>
        </div>
 
</asp:Content>

