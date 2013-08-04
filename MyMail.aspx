<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="MyMail.aspx.cs" Inherits="MyMail" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content_left_guid">
            <div id="content_left_guid_head"></div>
            
                <a href="MyLib.aspx"><div class="content_left_guid_item" >我的图书馆</div></a>   
                <a href="MySearch.aspx"><div class="content_left_guid_item" >图书查询</div> </a>     
                 <a href="Myhistory.aspx"><div class="content_left_guid_item" >借阅历史</div> </a>       
                  <a href="BookOrder.aspx"  style="display:none;"><div class="content_left_guid_item" >图书预约</div> </a>     
                <a href="MyFavorite.aspx"><div class="content_left_guid_item" >我的收藏</div> </a>  
                <a href="BooKBuy.aspx"><div class="content_left_guid_item" >图书荐购</div> </a>        
                 <a href="MyInfo.aspx"><div class="content_left_guid_item" >个人信息</div> </a> 
                 <a href="MyMail.aspx"><div class="content_left_guid_item_on" >我的信件</div> </a>   
                 <a href="Login.aspx?act=out"><div class="content_left_guid_item" >退出登录</div> </a>     
            
        </div>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">馆长信箱</span><span class="head_right" id="sitemap" >当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;<a href="MyLib.aspx">我的图书馆</a>&nbsp;<img src="images/next.jpg" />&nbsp;馆长信箱</span></div>
                <div style="line-height:20px;" id="myrenew"></div>
              <ul class="news_list">
                    <asp:Repeater ID="note_list" runat="server">
                    <ItemTemplate>
                    <li class="news_list_item" style="line-height:22px;"><span class="datetime"><%# myfun.ShortDateTime(DateTime.Parse(DataBinder.Eval(Container.DataItem,"pub_time").ToString()),"YMD") %></span><a id="title<%# DataBinder.Eval(Container.DataItem,"id")%>"  href="NoteView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>" title="<%# DataBinder.Eval(Container.DataItem,"title")%>" target="_blank"><%# DataBinder.Eval(Container.DataItem,"title")%></a> <a href="#" style="padding-left:40px;display:none;" ><%# DataBinder.Eval(Container.DataItem,"typename")%></a></li></ItemTemplate>
                </asp:Repeater>
               </ul>
              
        </div>
        
  
</asp:Content>

