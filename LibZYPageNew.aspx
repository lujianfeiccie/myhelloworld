<%@ Page Language="C#" MasterPageFile="~/AllPage2.master" AutoEventWireup="true" CodeFile="LibZYPageNew.aspx.cs" Inherits="LibZYPageNew" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="content_left_guid">
            <div id="content_left_guid_head"></div>
                 <a href="LibZYPage.aspx?type=ts"><div <%=ts %> >本校特色资源</div></a>       
                  <a href="LibZYPage.aspx?type=js"><div <%=js %> >军事电子资源</div> </a>    
                 <a href="LibZYPage.aspx?type=gg"><div <%=gg %> >公共电子资源</div> </a>  
        </div>
        <div id="content_center_info">
                 <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">馆藏资源</span><span class="head_right" id="sitemap" runat="server">当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;</span></div>
             <%--  <ul class="news_list">
                    <asp:Repeater ID="link_list_all" runat="server">
                    <ItemTemplate>
                    <li class="news_list_item" style="background-image:url(images/4.gif); background-repeat:no-repeat;padding-left:45px; padding-top:14px; height:50px; font-size:14px;width:250px; float:left;display:block;">
                    <a href="<%# DataBinder.Eval(Container.DataItem,"url")%>" title="<%# DataBinder.Eval(Container.DataItem,"title")%>" target="_blank">
                    <%# DataBinder.Eval(Container.DataItem,"title")%></a> </li></ItemTemplate>
                </asp:Repeater>
               </ul>--%>
               <ul class="news_list">
                    <li 
                    onclick="location.href='http://27.120.80.224/EasyMadl/uaspx_madl/Search_Common.aspx?sid=1&dcode=EBOOK002';addCount(<%=Session["userid"] %>+'','1');"
                    class="news_list_item" style="background-image:url(images/4.gif); background-repeat:no-repeat;padding-left:45px; padding-top:14px; height:50px; font-size:14px;width:250px; float:left;display:block;">
                    <span >本校教材</span></li>
                    <li onclick="location.href='http://27.120.80.224/EasyMadl/uaspx_madl/Search_Common.aspx?sid=1&dcode=JNART13202';addCount(<%=Session["userid"] %>+'','2');"
                    class="news_list_item" style="background-image:url(images/4.gif); background-repeat:no-repeat;padding-left:45px; padding-top:14px; height:50px; font-size:14px;width:250px; float:left;display:block;">
                    <span>本校论文 </span> 
                    </li>
                    <li onclick="location.href='BookSearch2New.aspx?type=yj';addCount(<%=Session["userid"] %>+'','3');"
                    class="news_list_item" style="background-image:url(images/4.gif); background-repeat:no-repeat;padding-left:45px; padding-top:14px; height:50px; font-size:14px;width:250px; float:left;display:block;">
                    <span>教学研究资料 </span> 
                    </li>
                    <li onclick="location.href='BookSearch2New.aspx?type=xs';addCount(<%=Session["userid"] %>+'','4');"
                    class="news_list_item" style="background-image:url(images/4.gif); background-repeat:no-repeat;padding-left:45px; padding-top:14px; height:50px; font-size:14px;width:250px; float:left;display:block;">
                    <span>科研学术动态 </span> 
                    </li>
                    <li onclick="location.href='http://27.120.80.224/EasyMadl/uaspx_madl/Search_Common.aspx?sid=1&dcode=JNART13201';addCount(<%=Session["userid"] %>+'','5');"
                    class="news_list_item" style="background-image:url(images/4.gif); background-repeat:no-repeat;padding-left:45px; padding-top:14px; height:50px; font-size:14px;width:250px; float:left;display:block;">
                    <span>军械士官 </span> 
                    </li>
                    <li onclick="location.href='http://27.120.80.224/EasyMadl/uaspx_madl/Search_Book.aspx?sid=1&dcode=EBOOK13202';addCount(<%=Session["userid"] %>+'','6');"
                    class="news_list_item" style="background-image:url(images/4.gif); background-repeat:no-repeat;padding-left:45px; padding-top:14px; height:50px; font-size:14px;width:250px; float:left;display:block;">
                    <span>教学参考书全文库 </span> </li>
                    <li onclick="location.href='http://27.120.80.224/EasyMadl/uaspx_madl/Search_Common.aspx?sid=1&dcode=WXJS13201';addCount(<%=Session["userid"] %>+'','7');"
                    class="news_list_item" style="background-image:url(images/4.gif); background-repeat:no-repeat;padding-left:45px; padding-top:14px; height:50px; font-size:14px;width:250px; float:left;display:block;">
                    <span>维修技术信息资料汇编 </span> 
                    </li>
                    <li onclick="location.href='http://27.120.80.224/EasyMadl/uaspx_madl/Search_Book.aspx?sid=1&dcode=EBOOK13204';addCount(<%=Session["userid"] %>+'','8');"
                    class="news_list_item" style="background-image:url(images/4.gif); background-repeat:no-repeat;padding-left:45px; padding-top:14px; height:50px; font-size:14px;width:250px; float:left;display:block;">
                    <span>学科学会论文集库 </span> 
                    </li>
               </ul>

        </div>
</asp:Content>

