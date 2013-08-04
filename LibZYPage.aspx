<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="LibZYPage.aspx.cs" Inherits="LibZYPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="content_left_guid">
            <div id="content_left_guid_head"></div>
                        
              
                 <a href="LibZYPage.aspx?type=ts"><div <%=ts %> >本校特色资源</div></a>       
                  <a href="LibZYPage.aspx?type=js"><div <%=js %> >军事电子资源</div> </a>    
                 <a href="LibZYPage.aspx?type=gg"><div <%=gg %> >公共电子资源</div> </a>  
                  
        </div>
        <div id="content_center_info">
        
                 <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">馆藏资源</span><span class="head_right" id="sitemap" runat="server">当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;</span></div>
               <ul class="news_list">
                    <asp:Repeater ID="link_list_all" runat="server">
                    <ItemTemplate>
                    <li class="news_list_item" style="background-image:url(images/4.gif); background-repeat:no-repeat;padding-left:45px; padding-top:14px; height:50px; font-size:14px;width:250px; float:left;display:block;"><a href="<%# DataBinder.Eval(Container.DataItem,"url")%>" title="<%# DataBinder.Eval(Container.DataItem,"title")%>" target="_blank"><%# DataBinder.Eval(Container.DataItem,"title")%></a> </li></ItemTemplate>
                </asp:Repeater>
               </ul>
            
        </div>
    
</asp:Content>

