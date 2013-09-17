<%@ Page Language="C#" MasterPageFile="~/AllPage2.master" AutoEventWireup="true" CodeFile="ViewPagesNew.aspx.cs" Inherits="ViewPagesNew" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content_left_guid">
<div id="content_left_guid_head"></div>
 <%=result[2] %>
</div>
<div id="content_center_info">
   <div id="content_center_info_head"><span class="head_title" id="title1" runat="server" style="width:120px;"><%=result[0] %></span><span class="head_right" id="sitemap" >当前位置：<a href="ViewPages.aspx"><%=result[3] %></a>&nbsp;<img src="images/next.jpg" />&nbsp;<%=result[0] %></span></div>
           <div id="content_center_info_main">
                <div id="news_title"><%=result[0]%></div>
                <div id="news_info" style="clear:both;"><%=result[1] %></div>
           </div>
    </div>
</asp:Content>

