<%@ Page Language="C#" MasterPageFile="~/AllPage2.master" AutoEventWireup="true" CodeFile="BookListNew.aspx.cs" Inherits="BookListNew" Title="Untitled Page" %>
<%@ Register Src="~/Contrl/PageNum.ascx" TagName="pagelist" TagPrefix="ucl" %>
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
        
               <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">新书推荐</span><span class="head_right" id="sitemap" >当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;<a href="BookList.aspx">新书推荐</a>&nbsp;<img src="images/next.jpg" />&nbsp;新书列表</span></div>
               <ul id="books_list">
                  
                   
                   <asp:Repeater ID="books_list_all" runat="server">
                    <ItemTemplate>
                        <li>
                        <div class="li_left">
                            <div><a title="<%# DataBinder.Eval(Container.DataItem,"title")%>" href="BookView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>"><img src="<%# DataBinder.Eval(Container.DataItem,"picurl").ToString().Substring(1) %>" width="100" height="110"/></a></div>
                            <div class="bookname"><%# DataBinder.Eval(Container.DataItem,"title")%></div>
                        </div>
                        <div class="li_right">
                            <div class="bookinfo">作者:<%# DataBinder.Eval(Container.DataItem,"author")%></div>
                            <div class="bookinfo">出版社:<%# DataBinder.Eval(Container.DataItem,"publisher")%></div>
                            <div class="bookinfo">ISBN:<%# DataBinder.Eval(Container.DataItem,"isbn")%></div>
                            <div class="bookinfo">馆藏本:<%# DataBinder.Eval(Container.DataItem,"num1")%></div>
                            <div class="bookinfo">可借本:<%# DataBinder.Eval(Container.DataItem,"num2")%></div>
                        </div>
                        </li>
                   </ItemTemplate>
                </asp:Repeater>
               </ul>
               <div style="clear:both;"><ucl:pagelist ID="mypage" runat="server"  /></div>
        </div>
</asp:Content>
