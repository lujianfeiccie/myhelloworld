<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="DownloadView.aspx.cs" Inherits="DownloadView" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content_left_guid">
            <div id="content_left_guid_head"></div>
            
             <asp:Repeater ID="top10" runat="server">
                    <ItemTemplate>
                        <a href="DownloadView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>"><div class="content_left_top_item" ><%# myfun.ShortString( DataBinder.Eval(Container.DataItem,"title").ToString(),26,false) %></div></a>       
                    </ItemTemplate>
                </asp:Repeater>
    
             
            
        </div>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1">软件下载</span><span class="head_right" id="sitemap">当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;<a href="DownloadList.aspx">软件下载</a>&nbsp;<img src="images/next.jpg" />&nbsp;<%=mydown.Title %></span></div>
               <div id="download_info">
                    <div class="download_head"><%=mydown.Title %></div>
                    <div>
                    <div class="download_intro">
                        
                         <div class="download_info" style="height:54px; overflow:hidden; width: 405px;"><span class="download_left"><img src="images/download_green.jpg" />&nbsp;&nbsp;<img src="images/download_safe.jpg" /></span><span class="download_right"><img src="images/download_safe2.jpg" /></span></div>
                         <div class="download_info"><span class="download_left">软件大小：<%=myfun.GetFileSize(mydown.FileSize) %></span><span class="download_right">热门等级：<%=mydown.Rank %></span></div>
                         <div class="download_info"><span class="download_left">更新时间：<%=myfun.ShortDateTime(mydown.UpdateTime,"YMD") %></span><span class="download_right">下载次数：<%=mydown.DownloadTimes %></span></div>
                         <div class="download_info"><span class="download_left">开发商：<%=mydown.Author %></span><span class="download_right">软件类别：<%=mydown.TypeName %></span></div>
                         <div class="download_info"><span class="download_left">软件语言：<%=mydown.Language %></span><span class="download_right" style="width: 217px">应用平台：<%=mydown.PlatForm %></span></div>
                         <div class="download_info"><span class="download_left">软件性质：<%=mydown.XingZhi %></span><span class="download_right">浏览量：<%=mydown.VisitNum %></span></div>
                         
                    </div>
                    </div>
                    <div class="download_detail"><table border="0" cellpadding="0" cellspacing="4"><tr>
                              <td><a href="DownloadFile.aspx?id=<%=mydown.ID %>" target="_blank"><img style="cursor:pointer; border:none;"  src="images/download.jpg"  /></a></td>
                              </tr></table><%=mydown.Info %></div>
                     <div class="download_info"></div>
                    <div class="download_info">
                        &nbsp;</div>

               </div>
                  
                   
        </div>
        <script language="javascript" type="text/javascript">
            function addcomment(type,id)
            {
                 $.ajax({ type:"Get",
                   url: "DoDownload.aspx",
                   cache: false,
                   data:"id="+id+"&type="+type,
                   success: function(data){
                        if(data=="ok")
                         {alert("投票成功！"); location.href="DownloadView.aspx?id="+id;}
                          
                        else alert(data);
                   }
                }); 
            }
        
        </script>
</asp:Content>

