<%@ Page Language="C#" MasterPageFile="~/AllPage2.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index2" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="JS/tab.js"></script>
<div class="mid_m">
   <div class="newsa">
   <div class="news">
<ul>
<li><a href="#" onmouseover="easytabs('1', '1');" onfocus="easytabs('1', '1');" onclick="return false;"  title="" id="tablink1">新闻中心</a></li>
<li><a href="#" onmouseover="easytabs('1', '2');" onfocus="easytabs('1', '2');" onclick="return false;"  title="" id="tablink2">资源动态 </a></li>
<li><a href="#" onmouseover="easytabs('1', '3');" onfocus="easytabs('1', '3');" onclick="return false;"  title="" id="tablink3">新书通告 </a></li>
</ul>
</div>

<div id="tabcontent1">
<div class="nimag"><img src="images/index_22.gif" width="188" height="145" alt=""/></div>
<div class="news_n">
<ul class="mynews">
    <asp:Repeater ID="top2news" runat="server">
        <ItemTemplate>
            <li>
            <a href="NewsView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>"
                title="<%# DataBinder.Eval(Container.DataItem,"title")%>">
                <%# myfun.ShortString(DataBinder.Eval(Container.DataItem,"title").ToString(),36,false)%>
                </a>  <span>
                <%# IsNew( DataBinder.Eval(Container.DataItem,"pub_time").ToString())%>
            </span>
            </li>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Repeater ID="indexnews" runat="server">
        <ItemTemplate>
            <li>
            <a href="NewsView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>"
                title="<%# DataBinder.Eval(Container.DataItem,"title")%>" target="_blank">
                <%# myfun.ShortString(DataBinder.Eval(Container.DataItem,"title").ToString(),36,false)%>
            </a>
            <span>
                <%# IsNew( DataBinder.Eval(Container.DataItem,"pub_time").ToString())%>
            </span></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>

</div>

</div>

<div id="tabcontent2">
<div class="nimag"><img src="images/index_22.gif" width="188" height="145" /></div>
<div class="news_n">
<ul>
    <li>gdf方评估<span>2012-12-12</span></li>
    <li>252452452452<span>2012-12-12</span></li>
    <li>45<span>2012-12-12</span></li>
    <li>李克强邀院士谈城镇化 政策落实将第三方评估<span>2012-12-12</span></li>
    <li>李克强邀院士谈城镇化 政策落实将第三方评估<span>2012-12-12</span></li>
    <li>李克强邀院士谈城镇化 政策落实将第三方评估<span>2012-12-12</span></li>
    <div class="cl"></div>
    
</ul>

</div>


</div>

<div id="tabcontent3">
<div class="nimag"><img src="images/index_22.gif" width="188" height="145" /></div>
<div class="news_n">
<ul class="mynews">
    <asp:Repeater ID="newbook" runat="server">
    <ItemTemplate>
       <li>
          <a href="bookview.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>" title="<%# DataBinder.Eval(Container.DataItem,"title")%>"><%# DataBinder.Eval(Container.DataItem,"title")%>
          </a><span><%# DataBinder.Eval(Container.DataItem,"addtime")%></span>
        </li> 
     </ItemTemplate>
    </asp:Repeater>
</ul>

</div>


</div>
   
   
   </div>
   <div class="shousuo">
   <div class="news">
<ul>
<li><a href="#" onmouseover="easytabs2('1', '1');" onfocus="easytabs2('1', '1');"  onclick="return false;" title="" id="anotherlink1">全部</a></li>
<li><a href="#" onmouseover="easytabs2('1', '2');" onfocus="easytabs2('1', '2');"  onclick="return false;" title="" id="anotherlink2">馆藏图书 </a></li>
<li><a href="#" onmouseover="easytabs2('1', '3');" onfocus="easytabs2('1', '3');"  onclick="return false;" title="" id="anotherlink3"> 期刊 </a></li>
<li><a href="#" onmouseover="easytabs2('1', '4');" onfocus="easytabs2('1', '4');"  onclick="return false;" title="" id="anotherlink4"> 电子书</a></li>
<li><a href="#" onmouseover="easytabs2('1', '5');" onfocus="easytabs2('1', '5');"  onclick="return false;" title="" id="anotherlink5"> 视频 </a></li>
<li><a href="#" onmouseover="easytabs2('1', '6');" onfocus="easytabs2('1', '6');"  onclick="return false;" title="" id="anotherlink6">军工信息    </a></li>
<li><a href="#" onmouseover="easytabs2('1', '7');" onfocus="easytabs2('2', '7');"  onclick="return false;" title="" id="anotherlink7"> 我的图书馆</a></li>
</ul>
</div>

<div id="anothercontent1">
<div class="xlxk">
<select name="" >
  <option value="0">科技</option>
  <option value="1">人文</option>
</select>
<input name="" type="text"  value="--请输入关键字--"><span><img src="images/index_35.gif"  /></span>
</div>
<div class="cl"></div>
</div>

<div id="anothercontent2">
<div class="xlxk_l">
<input name="" type="text"  value="管藏图书书籍"><span><img src="images/index_35.gif"  /></span>
</div>

</div>

<div id="anothercontent3">
<div class="xlxk_l">

<input name="" type="text" /  value="1"><span><img src="images/index_35.gif"  /></span>
</div>
</div>

<div id="anothercontent4">
<div class="xlxk_l">

<input name="" type="text" /  value="2"><span><img src="images/index_35.gif"  /></span>
</div>

</div>

<div id="anothercontent5">
<div class="xlxk_l">

<input name="" type="text" / value="3"><span><img src="images/index_35.gif"  /></span>
</div>

</div>

<div id="anothercontent6">

<div class="xlxk_l">

<input name="" type="text" /  value="4"><span><img src="images/index_35.gif"  /></span>
</div>

</div>

<div id="anothercontent7">
<div class="xlxk_n">
    <form id="login" name="login" action="LoginNew.aspx?act=in" method="post">
    <% if (Session["username"] != null)
       { %>
       <a href="myInfoNew.aspx">个人信息</a>
       <a href="myLibNew.aspx">借阅信息</a>
       <a href="myhistory.aspx">借阅历史</a>
       <a href="MyFavorite.aspx">我的书单</a>
       <a href="LoginNew.aspx?act=out">退出登录</a>
    <%}
      else
      { %>
    <input id="username" name="username" type="text" /  value="">
    <input id="password" name="password" type="password" /  value="">
    <span onclick="javascript:login.submit();"><img src="images/denglu.gif"  /></span>
     <%} %>
    </form>
</div>

</div>
   </div>
   <div class="ht"><img src="images/index_39.gif" width="585" height="25" /></div>
   <div class="xinshu">
   <div class="xinshu_bt"><img src="images/index_42.gif" width="580" height="24" /></div>
   <div class="xinshu_nr">
      <ul>
        <li><img src="images/index_49.gif" width="71" height="88" /><span>书名</span></li>
        <li><img src="images/index_49.gif" width="71" height="88" /><span>书名</span></li>
        <li><img src="images/index_49.gif" width="71" height="88" /><span>书名</span></li>
        <li><img src="images/index_49.gif" width="71" height="88" /><span>书名</span></li>
        <li><img src="images/index_49.gif" width="71" height="88" /><span>书名</span></li>
        
      
      </ul>
   
   </div>
   
   </div>
 </div>
 <div class="mid_r">
   <div class="zn">
    <div class="zn_bt"><img src="images/index_13.gif" /></div>
    <div class="zn_nr">
    <ul class="my">
    <li><a href="BookListNew.aspx" >新书荐购</a></li>
    <li>新书订阅</li>
    <li><a href="CDSearchNew.aspx">随书光盘</a></li>
    <li><a href="">统计分析</a></li>
    <li><a href="">数字教育</a></li>
    <li><a href="DownloadListNew.aspx?type=download">软件下载</a></li>

    </ul></div>
   
   </div>
   <div class="jc">
     <ul class="my">
       <li><a href="ViewPagesNew.aspx"><img src="images/icon01.gif" width="34" height="36" />本馆简介 </a></li>
       <li><a href="ViewPagesNew.aspx?type=xz1"><img src="images/icon02.gif" width="34" height="36" />入馆须知 </a></li>
       <li><a href="ViewPagesNew.aspx?type=sj"><img src="images/icon03.gif" width="34" height="36" />开放时间 </a></li>
       <li><a href="ViewPagesNew.aspx?type=fb"><img src="images/icon04.gif" width="34" height="36" />馆藏分布 </a></li>
       <li><a href="ViewPagesNew.aspx?type=xz1"><img src="images/icon05.gif" width="34" height="36" />规章制度</a></li>
       <li><a href="DownloadListNew.aspx?type=wt"><img src="images/icon06.gif" width="34" height="36" />常见问题 </a></li>
       <li><a href="NoteListNew.aspx?type=zx"><img src="images/icon07.gif" width="34" height="36" />读者留言</a></li>
       <li><a href="research.aspx"><img src="images/icon08.gif" width="34" height="36" />在线调查</a></li>

     </ul>
   
   </div>
   <div class="gg"><img src="images/index_55.gif" width="147" height="79" /></div>
   </div>
</asp:Content>

