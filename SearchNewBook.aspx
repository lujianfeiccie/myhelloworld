<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="SearchNewBook.aspx.cs" Inherits="SearchNewBook" Title="Untitled Page" %>
<%@ Register Src="~/Contrl/PageNum.ascx" TagName="pagelist" TagPrefix="ucl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="Calendar/WdatePicker.js"></script>
<div id="content_left_guid">
            <div id="content_left_guid_head"></div>
            <div style="height:26px; margin:12px 0px 2px 0px; text-align:center;"><span style="background-color:yellow; padding:4px 5px 4px 5px; font-weight:bold;">热门搜索</span></div>
            <div class="hot_search" >
             <asp:Repeater ID="top10" runat="server">
                    <ItemTemplate>
                        <span class="search_hot_word" onclick="$('#inputtext').val('<%# DataBinder.Eval(Container.DataItem,"keyword")%>');search();"><%# DataBinder.Eval(Container.DataItem,"keyword")%>&nbsp;(<%# DataBinder.Eval(Container.DataItem,"all_num")%>)</span>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
             
            
        </div>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">新书检索</span><span class="head_right" id="sitemap" >当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;<a href="BookList.aspx">新书推荐</a>&nbsp;<img src="images/next.jpg" />&nbsp;新书检索</span></div>
               <div id="newbook_search" style="height:26px; padding:5px 8px 4px 7px;">
               <select id="searchtype">
                    <option value="title">书名</option>
                    <option value="author">作者</option>
                    <option value="typename">类别</option>
               </select><input id="inputtext" value="<%=thekeytag %>" type="text" style="width:140px;" />&nbsp;&nbsp;开始时间:<input style="width:80px;" value="<%=myfun.ShortDateTime(DateTime.Parse(date1),"YMD") %>"  onfocus="WdatePicker({el:$dp.$('starttime'),skin:'blue',minDate:'1900-09-10',maxDate:'%y-%M-%d'})"  type="text" id="date1" />&nbsp;&nbsp;截止时间:<input value="<%=myfun.ShortDateTime(DateTime.Parse(date2),"YMD") %>" onfocus="WdatePicker({el:$dp.$('starttime'),skin:'blue',minDate:'1900-09-10',maxDate:'%y-%M-%d'})"  type="text" id="date2" style="width:80px;" />&nbsp;&nbsp;<input onclick="search();" type="button" value="查询" />&nbsp;&nbsp;<a href="LibRss.aspx" >订阅Rss</a>
               </div>
               <div style=" height:24px;" id="condition1" runat="server" ></div>
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
 <script language="javascript" type="text/javascript">
 
    function search()
    {
        var url="SearchNewBook.aspx?";
        var searchtype=$("#searchtype").val();
        var keyword=$("#inputtext").val();
        var date1=$("#date1").val();
        var date2=$("#date2").val();
        url =url+searchtype+"="+escape(keyword)+"&date1="+date1+"&date2="+date2;
        location.href=url;
        
    }
 </script>
</asp:Content>
