<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="BookView.aspx.cs" Inherits="Admin_BookView" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content_left_guid">
            <div id="content_left_guid_head"></div>
            
             <asp:Repeater ID="top10" runat="server">
                    <ItemTemplate>
                        <a href="BookView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>"><div class="content_left_top_item" ><img style="border:none;" src="<%# DataBinder.Eval(Container.DataItem,"picurl").ToString().Substring(1) %>" height="12" />&nbsp;<%# myfun.ShortString( DataBinder.Eval(Container.DataItem,"title").ToString(),26,false) %></div></a>       
                    </ItemTemplate>
                </asp:Repeater>
    
             
            
        </div>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">新书推荐</span><span class="head_right" id="sitemap">当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;<a href="BookList.aspx">新书推荐</a>&nbsp;<img src="images/next.jpg" />&nbsp;<%=mybook.Title %></span></div>
               <div id="book_info">
                    <div class="book_intro">
                         <div class="bookinfo" style="height: 25px">
                             &nbsp; 作者：&nbsp;&nbsp;<%=mybook.Author %></div>
                            <div class="bookinfo" style="height: 25px">
                                &nbsp; 出版社：&nbsp;&nbsp;<%=mybook.Publisher %></div>
                            <div class="bookinfo" style="height: 25px">
                                &nbsp; 出版日期：&nbsp;&nbsp;<%=myfun.ShortDateTime(mybook.PubTime, "YMD")%></div>
                            <div class="bookinfo" style="height: 25px">
                                &nbsp; ISBN：&nbsp;&nbsp;<%=mybook.ISBN %></div>
                            <div class="bookinfo" style="height: 25px">
                                &nbsp; 分类号：&nbsp;&nbsp;<%=mybook.TypeName %></div>
                            <div class="bookinfo" style="height: 25px">
                                &nbsp; 馆藏本：&nbsp;&nbsp;<%=mybook.TotalNum %></div>
                            <div class="bookinfo" style="height: 25px">
                                &nbsp; 可借本：&nbsp;&nbsp;<%=mybook.NowNum %></div>
                            <div class="bookinfo" style="height: 25px">
                                &nbsp; 入档时间：&nbsp;&nbsp;<%=myfun.ShortDateTime(mybook.AddTime,"YMD") %></div>
                            <div class="bookinfo" style="height: 25px">
                                &nbsp; 浏览量：&nbsp;&nbsp;<%=mybook.VisitNum %></div>
                    </div>
                    <div class="book_pic">
                        <img src="<%=mybook.PicURL.Substring(1)  %>" style="width: 192px; height: 238px" />
                    </div>
                    <div class="book_detail"><%=mybook.Infos %></div>
               
               </div>
                  
                   
        </div>
</asp:Content>

