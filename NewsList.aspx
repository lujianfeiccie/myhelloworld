<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="NewsList" Title="Untitled Page" %>
<%@ Register Src="~/Contrl/PageNum.ascx" TagName="pagelist" TagPrefix="ucl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content_left_guid">
            <div id="content_left_guid_head"></div>
            <%if (showtype == "news")
              { %>
                 <a href="NewsList.aspx?type=news"><div class="content_left_guid_item_on" >网站新闻</div></a>       
                  <a href="NewsList.aspx?type=notice"><div class="content_left_guid_item" >网站公告</div> </a>      
             <%}
               else if(showtype=="notice")
               { %>   
               <a href="NewsList.aspx?type=news"><div class="content_left_guid_item" >网站新闻</div> </a>      
                  <a href="NewsList.aspx?type=notice"><div class="content_left_guid_item_on" >网站公告</div>  </a>
             <%}
               else if (showtype == "px")
               {%>
               <a href="DownloadList.aspx?type=wt"><div class="content_left_guid_item"  >常见问题</div></a>       
                  <a href="NewsList.aspx?type=px"><div class="content_left_guid_item_on"  >读者培训</div> </a>    
                 <a href="DownloadList.aspx?type=download"><div class="content_left_guid_item"  >软件下载</div> </a>  
             <%} %>
        </div>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">网站新闻</span><span class="head_right" id="sitemap" runat="server">当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;</span></div>
               <ul class="news_list">
                    <asp:Repeater ID="news_list_all" runat="server">
                    <ItemTemplate>
                    <li class="news_list_item"><span class="datetime"><%# myfun.ShortDateTime(DateTime.Parse(DataBinder.Eval(Container.DataItem,"pub_time").ToString()),"YMD") %></span><a href="NewsView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>" title="<%# DataBinder.Eval(Container.DataItem,"title")%>" target="_self"><%# DataBinder.Eval(Container.DataItem,"title")%></a> </li></ItemTemplate>
                </asp:Repeater>
               </ul>
               <ucl:pagelist ID="mypage" runat="server"  />
        </div>
</asp:Content>