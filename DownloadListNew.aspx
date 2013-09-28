<%@ Page Language="C#" MasterPageFile="~/AllPage2.master" AutoEventWireup="true" CodeFile="DownloadListNew.aspx.cs" Inherits="DownloadListNew" Title="Untitled Page" %>
<%@ Register Src="~/Contrl/PageNum.ascx" TagName="pagelist" TagPrefix="ucl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<div id="content_left_guid">
            <div id="content_left_guid_head"></div>
                <a href="DownloadList.aspx?type=wt"><div <%=wt %> >常见问题</div></a>       
                  <a href="NewsList.aspx?type=px"><div <%=px %> >读者培训</div> </a>    
                 <a href="DownloadList.aspx?type=download"><div <%=download %> >软件下载</div> </a>  
                      
        </div>--%>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">常见问题</span><span class="head_right" id="sitemap" runat="server">当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;<a href="DownloadList.aspx">参考咨询</a>&nbsp;<img src="images/next.jpg" /></span></div>
               <%if (type == "download")
                      { %>
               <ul id="download_list">
               </ul>
            <ul>
                    
                    <asp:Repeater ID="download_list_all" runat="server">
                    <ItemTemplate> <li class="download_list_item">
                        <div class="download_item_head"><div class="headin"><a href="DownloadView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>" target="_blank"><span class="bold"><%# DataBinder.Eval(Container.DataItem,"title")%></span></a>[<%# DataBinder.Eval(Container.DataItem,"typename")%>]</div></div>
                        <div class="download_item_title"><%# DataBinder.Eval(Container.DataItem,"xingzhi")%>&nbsp;|&nbsp;<span class="bold">无插件</span>&nbsp|&nbsp;更新时间:<%# myfun.ShortDateTime(DateTime.Parse( DataBinder.Eval(Container.DataItem,"update_time").ToString()),"YMD")%>&nbsp|&nbsp;人气:<%# DataBinder.Eval(Container.DataItem,"down_num")%>&nbsp;|&nbsp;软件大小:<%# myfun.GetFileSize(int.Parse( DataBinder.Eval(Container.DataItem,"file_size").ToString()))%></div>
                        <div class="download_item_info"> <%# myfun.ClearHTML( DataBinder.Eval(Container.DataItem,"info").ToString(),300,true)%></div>
                    </li></ItemTemplate>
                </asp:Repeater>
            </ul>
            <ul>
            </ul>
               <ucl:pagelist ID="mypage" runat="server"  />
              
               <%}
                 else if (type == "px")
                 { %>
                 
                <%}
                  else
                  {%>
                  
                    <div>
                        下载排行<%=result[1] %></div>
               
                 <%} %>
        </div>
         <div><a href="Downloadsort.aspx">下载排行</a></div>
</asp:Content>

