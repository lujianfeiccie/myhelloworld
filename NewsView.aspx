<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="NewsView.aspx.cs" Inherits="NewsView" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content_left_guid">
            <div id="content_left_guid_head"></div>
                        
                <asp:Repeater ID="top10" runat="server">
                    <ItemTemplate>
                    <div class="content_left_top_item"><a href="NewsView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>" title="<%# DataBinder.Eval(Container.DataItem,"title")%>" target="_self"><%# myfun.ShortString(DataBinder.Eval(Container.DataItem,"title").ToString(),28,false)%></a> </div></ItemTemplate>
                </asp:Repeater>
        </div>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">网站新闻</span><span class="head_right" id="sitemap" runat="server">当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;</span></div>
               <div id="content_center_info_main">
                    <div id="news_title"><%=mynews.Title %></div>
                    <div id="news_publisher">发布时间：<%=mynews.PubTime.Year+"-"+mynews.PubTime.Month+"-"+mynews.PubTime.Day %>&nbsp;&nbsp;&nbsp;&nbsp;点击数：<%=mynews.VisitNum%>次</div>
                    <div id="news_info"><%=mynews.Info %></div>
               </div>
        </div>
</asp:Content>

