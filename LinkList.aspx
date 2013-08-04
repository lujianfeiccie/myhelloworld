<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="LinkList.aspx.cs" Inherits="LinkList" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content_left_guid">
            <div id="content_left_guid_head"></div>
            
                 <a href="LinkList.aspx?type=xkzywz"><div <%=xkzywz %> >学科专业网站</div></a>       
                  <a href="LinkList.aspx?type=xnzy"><div <%=xnzy %> >校内资源</div> </a>    
                  <a href="LinkList.aspx?type=xwzy"><div <%=xwzy %> >校外资源</div></a>       
                  <a href="LinkList.aspx?type=xnlj"><div <%=xnlj %> >校内链接</div> </a>     
                  <a href="LinkList.aspx?type=xwlj"><div <%=xwlj %> >校外链接</div> </a>      
                
                  
            
        </div>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">网站链接</span><span class="head_right" id="sitemap" runat="server">当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;</span></div>
               <ul class="news_list">
                    <asp:Repeater ID="link_list_all" runat="server">
                    <ItemTemplate>
                    <li class="news_list_item" style="background-image:none; line-height:22px;"><a href="<%# DataBinder.Eval(Container.DataItem,"url")%>" title="<%# DataBinder.Eval(Container.DataItem,"title")%>" target="_blank"><%# DataBinder.Eval(Container.DataItem,"title")%></a> </li></ItemTemplate>
                </asp:Repeater>
               </ul>
            
        </div>
</asp:Content>

