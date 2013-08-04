<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="Myhistory.aspx.cs" Inherits="Myhistory" Title="Untitled Page" %>
<%@ Register Src="~/Contrl/PageNum.ascx" TagName="pagelist" TagPrefix="ucl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="Calendar/WdatePicker.js"></script>
<div id="content_left_guid">
            <div id="content_left_guid_head"></div>
            
                <a href="MyLib.aspx"><div class="content_left_guid_item" >我的图书馆</div></a>    、
                <a href="MySearch.aspx"><div class="content_left_guid_item" >图书查询</div> </a>    
                 <a href="Myhistory.aspx"><div class="content_left_guid_item_on" >借阅历史</div> </a>       
                  <a href="BookOrder.aspx"><div class="content_left_guid_item" >图书预约</div> </a>     
                <a href="MyFavorite.aspx"><div class="content_left_guid_item" >我的收藏</div> </a>  
                <a href="BooKBuy.aspx"><div class="content_left_guid_item" >图书荐购</div> </a>        
                 <a href="MyInfo.aspx"><div class="content_left_guid_item" >个人信息</div> </a>
                  <a href="MyMail.aspx"><div class="content_left_guid_item" >我的信件</div> </a>    
                  <a href="Login.aspx?act=out"><div class="content_left_guid_item" >退出登录</div> </a>         
            
        </div>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">借阅信息</span><span class="head_right" id="sitemap" >当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;<a href="MyLib.aspx">我的图书馆</a>&nbsp;<img src="images/next.jpg" />&nbsp;借阅信息</span></div>
              <form id="dsdfs"  action="Myhistory.aspx?act=query" method="post" style="margin:4px 4px 4px 8px;">
              
              开始时间：<input value="<%=time1 %>" id="starttime" onfocus="WdatePicker({el:$dp.$('starttime'),skin:'blue',minDate:'1900-09-10',maxDate:'%y-%M-%d'})" name="starttime" /> 截止时间： <input value="<%=time2 %>" name="endtime" id="endtime" onfocus="WdatePicker({el:$dp.$('endtime'),skin:'blue',minDate:'1900-09-10',maxDate:'%y-%M-%d'})" /> &nbsp;&nbsp;<input type="submit" value="查询" />
              
              </form>
              <table style="width:100%;" id="myborrow">
              
              <tr style="background-color:#ececec;"><th>图书名称</th><th>图书条码</th><th>索书号</th><th>借阅时间</th></tr>
                  <asp:Repeater ID="myhistorylist" runat="server">
                  <ItemTemplate>
                  <tr style="background-color:#ffffff;"><td><%# DataBinder.Eval(Container.DataItem,"_题名")%></td><td><%# DataBinder.Eval(Container.DataItem, "_图书条码")%></td><td><%# DataBinder.Eval(Container.DataItem, "_分类")%></td><td><%# myfun.ShortDateTime(DateTime.Parse( DataBinder.Eval(Container.DataItem, "_日期").ToString()),"YMD")%></td></tr>
                  </ItemTemplate>
                  <AlternatingItemTemplate>
                   <tr style="background-color:#eeeeee;"><td><%# DataBinder.Eval(Container.DataItem,"_题名")%></td><td><%# DataBinder.Eval(Container.DataItem, "_图书条码")%></td><td><%# DataBinder.Eval(Container.DataItem, "_分类")%></td><td><%# myfun.ShortDateTime(DateTime.Parse( DataBinder.Eval(Container.DataItem, "_日期").ToString()),"YMD")%></td></tr>
                  
                  </AlternatingItemTemplate>
                  </asp:Repeater>
                  
              </table>
               <ucl:pagelist ID="mypage" runat="server"  />
        </div>
</asp:Content>

