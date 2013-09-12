<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<%@ OutputCache Duration="1" VaryByParam="none"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="left">
    <div id="web_notice" class="left_block">
        <div class="left_block_head"><span class="head_title">网站公告</span><span class="more" onclick="javascript:location.href='NewsList.aspx?type=notice'"></span></div>
        <div class="left_block_info" >
            <ul>
                 <asp:Repeater ID="top2notice" runat="server">
                    <ItemTemplate>
                    <li><span class="lefttitle" style="width:150px;"><a href="NewsView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>" title="<%# DataBinder.Eval(Container.DataItem,"title")%>" target="_blank"><%# myfun.ShortString(DataBinder.Eval(Container.DataItem, "title").ToString(), 20, "&nbsp;")%></a></span> <span class="rightdate"> <%# IsNew( DataBinder.Eval(Container.DataItem,"pub_time").ToString())%>  </span>  </li></ItemTemplate>
                </asp:Repeater>
                 <asp:Repeater ID="indexnotice" runat="server">
                    <ItemTemplate>
                    <li><span class="lefttitle" style="width:150px;"><a href="NewsView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>" title="<%# DataBinder.Eval(Container.DataItem,"title")%>" target="_blank"><%# myfun.ShortString(DataBinder.Eval(Container.DataItem, "title").ToString(), 20, "&nbsp;")%></a></span><span class="rightdate"> <%# IsNew( DataBinder.Eval(Container.DataItem,"pub_time").ToString())%> </span>   </li></ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    
    <div id="left_2">
        
        <ul>
              <li><a href="BookSearch4.aspx" target="_blank">新书检索</a></li><li><a href="BookSearch.aspx" target="_blank">馆藏书目检索</a></li><li><a href="BookSearch2.aspx" target="_blank">情报资料检索</a></li><li><a href="BookSearch3.aspx" target="_blank">本校论文检索</a></li></ul>
       
        <div id="re_book">
           <div style="background-image:url(images/web_left_dot2.gif); background-position:left top; padding-left:24px; background-repeat:no-repeat; "><a href="BooKBuy.aspx" target="_blank" >图书荐购</a>&nbsp;&nbsp;<img alt="" src="Images/web_left_dot1.gif" /></div>
        </div>
    </div>
    
    <div id="left_3" class="left_block">
        <div class="left_block_head"><span class="head_title">学科专业网站</span><span onclick="javascript:location.href='LinkList.aspx?type=xkzywz'" class="more"></span></div>
        <div class="left_block_info" >
            <ul>
                <asp:Repeater ID="xkzywz" runat="server">
                    <ItemTemplate><li><a href="<%# DataBinder.Eval(Container.DataItem,"url")%>" target="_blank"><%# DataBinder.Eval(Container.DataItem,"title")%></a></li></ItemTemplate>
                </asp:Repeater>
                
                              
            </ul>
        </div>
    </div>
    
    
       <div id="left_4" class="left_block">
        <div class="left_block_head"><span class="head_title">软件下载</span><span class="more" onclick="javascript:location.href='DownloadList.aspx?type=download'" ></span></div>
        <div class="left_block_info" >
            <ul>
             <asp:Repeater ID="downloadtop" runat="server">
                    <ItemTemplate><li><a title="<%# DataBinder.Eval(Container.DataItem,"title")%>&#10;&#10;下载次数：<%# DataBinder.Eval(Container.DataItem,"down_num")%>" href="DownloadView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>" target="_blank"><%# myfun.ShortString( DataBinder.Eval(Container.DataItem,"title").ToString(),30,false)%></a></li></ItemTemplate>
                </asp:Repeater>
                </ul>
        </div>
    </div>
    
    <div id="links">
        <select name="xnzy" onchange="javascript:window.open(this.options[this.selectedIndex].value)">
            <option>&nbsp;&nbsp;&nbsp;&nbsp;====&nbsp;校内资源&nbsp;====&nbsp;&nbsp;&nbsp;&nbsp;</option>
            <asp:Repeater ID="xnzy" runat="server">
                    <ItemTemplate><option value="<%# DataBinder.Eval(Container.DataItem, "url")%>">&nbsp;&nbsp;&nbsp;&nbsp;====&nbsp;<%# DataBinder.Eval(Container.DataItem, "title")%>&nbsp;====&nbsp;&nbsp;&nbsp;&nbsp;</option></ItemTemplate>
                </asp:Repeater>
        </select>
        <select name="xwzy" onchange="javascript:window.open(this.options[this.selectedIndex].value)">
            <option>&nbsp;&nbsp;&nbsp;&nbsp;====&nbsp;校外资源&nbsp;====&nbsp;&nbsp;&nbsp;&nbsp;</option>
            <asp:Repeater ID="xwzy" runat="server">
                    <ItemTemplate><option value="<%# DataBinder.Eval(Container.DataItem, "url")%>">&nbsp;&nbsp;&nbsp;&nbsp;====&nbsp;<%# DataBinder.Eval(Container.DataItem, "title")%>&nbsp;====&nbsp;&nbsp;&nbsp;&nbsp;</option></ItemTemplate>
                </asp:Repeater>
        </select>
        <select name="xnlj" onchange="javascript:window.open(this.options[this.selectedIndex].value)">
            <option>&nbsp;&nbsp;&nbsp;&nbsp;====&nbsp;校内链接&nbsp;====&nbsp;&nbsp;&nbsp;&nbsp;</option>
            <asp:Repeater ID="xnlj" runat="server">
                    <ItemTemplate><option value="<%# DataBinder.Eval(Container.DataItem, "url")%>">&nbsp;&nbsp;&nbsp;&nbsp;====&nbsp;<%# DataBinder.Eval(Container.DataItem, "title")%>&nbsp;====&nbsp;&nbsp;&nbsp;&nbsp;</option></ItemTemplate>
                </asp:Repeater>
        </select>
        <select name="xwlj" onchange="javascript:window.open(this.options[this.selectedIndex].value)">
            <option>&nbsp;&nbsp;&nbsp;&nbsp;====&nbsp;校外链接&nbsp;====&nbsp;&nbsp;&nbsp;&nbsp;</option>
            <asp:Repeater ID="xwlj" runat="server">
                    <ItemTemplate><option value="<%# DataBinder.Eval(Container.DataItem, "url")%>">&nbsp;&nbsp;&nbsp;&nbsp;====&nbsp;<%# DataBinder.Eval(Container.DataItem, "title")%>&nbsp;====&nbsp;&nbsp;&nbsp;&nbsp;</option></ItemTemplate>
                </asp:Repeater>
        </select>
    </div>
</div>

<div id="center">

    <div id="web_news">
        <div id="web_news_head"><span class="head_title">网站新闻</span><span class="more" onclick="javascript:location.href='NewsList.aspx?type=news'"></span></div>
        <div id="web_news_info">
            <div id="web_news_info_pics">
                             <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" id="scriptmain" name="scriptmain" codebase="http://download.macromedia.com/pub/shockwave/cabs/
                flash/swflash.cab#version=6,0,29,0" width="180" height="135">
                    <param name="movie" value="JS/headpic.swf?bcastr_xml_url=IndexPicNews.aspx" />
                    <param name="quality" value="high" />
                    <param name="scale" value="noscale" />
                    <param name="LOOP" value="false" />
                    <param name="menu" value="false" />
                    <param name="wmode" value="transparent" />
                    <embed src="JS/headpic.swf?bcastr_xml_url=IndexPicNews.aspx" width="180" height="140" loop="false" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" salign="T" name="scriptmain" menu="false" wmode="transparent" /> 
                  </object>
            </div>
            <div id="web_news_info_items">
                <ul>
                    <asp:Repeater ID="top2news" runat="server">
                        <ItemTemplate>
                            <li><span class="lefttitle"><a href="NewsView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>"
                                title="<%# DataBinder.Eval(Container.DataItem,"title")%>" target="_blank">
                                <%# myfun.ShortString(DataBinder.Eval(Container.DataItem,"title").ToString(),36,false)%>
                            </a></span><span class="rightdate">
                                <%# IsNew( DataBinder.Eval(Container.DataItem,"pub_time").ToString())%>
                            </span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="indexnews" runat="server">
                        <ItemTemplate>
                            <li><span class="lefttitle"><a href="NewsView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>"
                                title="<%# DataBinder.Eval(Container.DataItem,"title")%>" target="_blank">
                                <%# myfun.ShortString(DataBinder.Eval(Container.DataItem,"title").ToString(),36,false)%>
                            </a></span><span class="rightdate">
                                <%# IsNew( DataBinder.Eval(Container.DataItem,"pub_time").ToString())%>
                            </span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        
        </div>
    </div>
    
    <div id="center_2">
        <div id="center_2_head"><span class="head_title">数字资源</span></div>
        <div id="center_2_info">
            <div class="center_2_block">
                <div class="center_2_block_head">馆藏资源</div>
                    <div class="center_2_block_info">
                            <asp:Repeater ID="gczy" runat="server">
                            <ItemTemplate>
                                 <a  target="_blank" href="<%# DataBinder.Eval(Container.DataItem,"url")%>"><%# DataBinder.Eval(Container.DataItem,"title")%><%# IsNewView(DataBinder.Eval(Container.DataItem, "is_new").ToString()) %></a>
                             </ItemTemplate>
                            </asp:Repeater>
                    </div>
            </div>
            <div class="center_2_block">
                <div class="center_2_block_head">特色资源</div>
                <div class="center_2_block_info">
                    <asp:Repeater ID="tszy" runat="server">
                            <ItemTemplate>
                                 <a  target="_blank"  href="<%# DataBinder.Eval(Container.DataItem,"url")%>"><%# DataBinder.Eval(Container.DataItem,"title")%><%# IsNewView(DataBinder.Eval(Container.DataItem, "is_new").ToString()) %></a>
                             </ItemTemplate>
                            </asp:Repeater>
                </div>
            </div>
            <div class="center_2_block">
                <div class="center_2_block_head">军事电子资源</div>
                <div class="center_2_block_info">
                    <asp:Repeater ID="jszy" runat="server">
                            <ItemTemplate>
                                 <a  target="_blank"  href="<%# DataBinder.Eval(Container.DataItem,"url")%>"><%# DataBinder.Eval(Container.DataItem,"title")%><%# IsNewView(DataBinder.Eval(Container.DataItem, "is_new").ToString()) %></a>
                             </ItemTemplate>
                            </asp:Repeater>
                </div>
            </div>
            <div class="center_2_block">
                <div class="center_2_block_head">公共资源</div>
                <div class="center_2_block_info">
                        <asp:Repeater ID="ggzy" runat="server">
                            <ItemTemplate>
                                 <a  target="_blank"  href="<%# DataBinder.Eval(Container.DataItem,"url")%>"><%# DataBinder.Eval(Container.DataItem,"title")%><%# IsNewView(DataBinder.Eval(Container.DataItem, "is_new").ToString()) %></a>
                             </ItemTemplate>
                            </asp:Repeater>
                </div>
            </div>
        
        </div>
    
    </div>
    
    <div id="center_3">
        <div id="center_3_head"><span class="head_title">新书推荐</span><a href="BookList.aspx"><span style="width:50px; cursor:pointer; float:right;margin-top:7px; margin-right:2px; color:#ffffff;">更多..</span></a></div>
        <div class="rollBox">
            <div class="LeftBotton" onmousedown="ISL_GoDown()" onmouseup="ISL_StopDown()" onmouseout="ISL_StopDown()"></div>
            
            <div class="Cont" id="ISL_Cont"> 
                <div class="ScrCont"> 
                    <div id="List1"> 
                    <asp:Repeater ID="newbook" runat="server">
                    <ItemTemplate>
                    <div class="pic"> 
                            <a href="bookview.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>" title="<%# DataBinder.Eval(Container.DataItem,"title")%>"><img alt="" src='<%# DataBinder.Eval(Container.DataItem,"picurl").ToString().Substring(1)%>' border="0" width="100"  height="110"/></a>
                            <p><%# DataBinder.Eval(Container.DataItem,"title")%></p>
                        </div> 

                     </ItemTemplate>
                    </asp:Repeater>
                    
                        
                
                    </div>
                    <div id="List2"></div>   
                </div>
            </div>
            
            <div class="RightBotton" onmousedown="ISL_GoUp()" onmouseup="ISL_StopUp()" onmouseout="ISL_StopUp()"></div>
        </div>
    </div>
    
 <script language="javascript" type="text/javascript"> 
<!--//--><![CDATA[//><!-- 
//图片滚动列表 mengjia 070816 
var Speed = 10; //速度(毫秒) 
var Space = 5; //每次移动(px) 
var PageWidth = 97; //翻页宽度 
var fill = 0; //整体移位 
var MoveLock = false; 
var MoveTimeObj; 
var Comp = 0; 
var AutoPlayObj = null; 
GetObj("List2").innerHTML = GetObj("List1").innerHTML; 
GetObj('ISL_Cont').scrollLeft = fill; 
GetObj("ISL_Cont").onmouseover = function(){clearInterval(AutoPlayObj);} 
GetObj("ISL_Cont").onmouseout = function(){AutoPlay();} 
AutoPlay(); 
function GetObj(objName){if(document.getElementById){return eval('document.getElementById("'+objName+'")')}else{return eval('document.all.'+objName)}} 
function AutoPlay(){ //自动滚动 
 clearInterval(AutoPlayObj); 
 AutoPlayObj = setInterval('ISL_GoDown();ISL_StopDown();',5000); //间隔时间 
} 
function ISL_GoUp(){ //上翻开始 
 if(MoveLock) return; 
 clearInterval(AutoPlayObj); 
 MoveLock = true; 
 MoveTimeObj = setInterval('ISL_ScrUp();',Speed); 
} 
function ISL_StopUp(){ //上翻停止 
 clearInterval(MoveTimeObj); 
 if(GetObj('ISL_Cont').scrollLeft % PageWidth - fill != 0){ 
  Comp = fill - (GetObj('ISL_Cont').scrollLeft % PageWidth); 
  CompScr(); 
 }else{ 
  MoveLock = false; 
 } 
 AutoPlay(); 
} 
function ISL_ScrUp(){ //上翻动作 
 if(GetObj('ISL_Cont').scrollLeft <= 0){GetObj('ISL_Cont').scrollLeft = GetObj('ISL_Cont').scrollLeft + GetObj('List1').offsetWidth} 
 GetObj('ISL_Cont').scrollLeft -= Space ; 
} 
function ISL_GoDown(){ //下翻 
 clearInterval(MoveTimeObj); 
 if(MoveLock) return; 
 clearInterval(AutoPlayObj); 
 MoveLock = true; 
 ISL_ScrDown(); 
 MoveTimeObj = setInterval('ISL_ScrDown()',Speed); 
} 
function ISL_StopDown(){ //下翻停止 
 clearInterval(MoveTimeObj); 
 if(GetObj('ISL_Cont').scrollLeft % PageWidth - fill != 0 ){ 
  Comp = PageWidth - GetObj('ISL_Cont').scrollLeft % PageWidth + fill; 
  CompScr(); 
 }else{ 
  MoveLock = false; 
 } 
 AutoPlay(); 
} 
function ISL_ScrDown(){ //下翻动作 
 if(GetObj('ISL_Cont').scrollLeft >= GetObj('List1').scrollWidth){GetObj('ISL_Cont').scrollLeft = GetObj('ISL_Cont').scrollLeft - GetObj('List1').scrollWidth;} 
 GetObj('ISL_Cont').scrollLeft += Space ; 
} 
function CompScr(){ 
 var num; 
 if(Comp == 0){MoveLock = false;return;} 
 if(Comp < 0){ //上翻 
  if(Comp < -Space){ 
   Comp += Space; 
   num = Space; 
  }else{ 
   num = -Comp; 
   Comp = 0; 
  } 
  GetObj('ISL_Cont').scrollLeft -= num; 
  setTimeout('CompScr()',Speed); 
 }else{ //下翻 
  if(Comp > Space){ 
   Comp -= Space; 
   num = Space; 
  }else{ 
   num = Comp; 
   Comp = 0; 
  } 
  GetObj('ISL_Cont').scrollLeft += num; 
  setTimeout('CompScr()',Speed); 
 } 
} 
//--><!]]> 
              </script>
</div>

<div id="right">
    <div id="login_intro">
        <div id="login_head">我的图书馆</div>
        
        <form id="login" action="Login.aspx?act=in" method="post">
            <% if(Session["username"]!=null){ %>
            <div style="line-height:18px; padding-left:30px;font-size:13px;">
            <div class="login_item" style="background:url(images/favorite2.gif); background-repeat:no-repeat; background-position:left center; padding-left:24px;"><a href="myInfo.aspx">个人信息</a></div>
            <div class="login_item" style="background:url(images/favorite2.gif); background-repeat:no-repeat; background-position:left center; padding-left:24px;"><a href="myLib.aspx">借阅信息</a></div>
            <div class="login_item" style="background:url(images/favorite2.gif); background-repeat:no-repeat; background-position:left center; padding-left:24px;"><a href="myhistory.aspx">借阅历史</a></div>
            <div class="login_item" style="background:url(images/favorite2.gif); background-repeat:no-repeat; background-position:left center; padding-left:24px;"><a href="MyFavorite.aspx">我的书单</a></div>
            <div class="login_item" style="background:url(images/favorite2.gif); background-repeat:no-repeat; background-position:left center; padding-left:24px;"><a href="Login.aspx?act=out">退出登录</a></div>
            </div>
            <%} else{ %>
            <div class="login_item">用户名：<input type="text" id="username"  name="username"/></div>
            <div class="login_item">密&nbsp;&nbsp;&nbsp;&nbsp;码：<input type="password" id="password"  name="password"/></div>
            <div class="login_item">验证码：<input type="text" id="validCode"  name="checknum"/>&nbsp;&nbsp;<input type="text" onclick="createCode()" readonly="readonly" id="checkCode" class="unchanged" style="width:56px;cursor:pointer; height:20px;"  /><!--<img src="images/checknum.gif" />--></div>
            <div class="login_item"><input  type="button" id="login_sub" onclick="validate();" value="登录" />&nbsp;&nbsp;<span  onclick="showToolTip2();"  style="width:30px; cursor:pointer; background:url(images/user_reg_2.gif); background-repeat:no-repeat;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;<span id="user_link"><a href="UserReg.aspx">[注册]</a>&nbsp;&nbsp;<a href="FindPsw.aspx">[忘记密码]</a></span></div>
            <%} %>
        </form>
        
        <div id="intro_head"><a href="ViewPages.aspx?type=lc"  target="_blank">服务指南</a></div>
        <div class="intro_item"><a href="ViewPages.aspx?type=sj"  target="_blank">开放时间</a></div>
        <div class="intro_item"><a href="ViewPages.aspx?type=xz1"  target="_blank">管理规定</a></div>
        <div class="intro_item"><a href="DownloadList.aspx?type=wt"  target="_blank">常见问题</a></div>
        <div class="intro_item"><a href="NoteList.aspx?type=zx"  target="_blank">读者问答</a></div>
    </div>
    
    <div class="right_block">
        <div class="right_block_head"><span class="head_title">借阅量排行</span><span class="more"  onclick="javascript:location.href='LoanTop.aspx'"></span></div>
        <div class="right_block_info">
             <ul>
                <asp:Repeater ID="departmenttop" runat="server">
                    <ItemTemplate>
                    <li><span class="lefttitle" style="width:120px; overflow:hidden;"><%# DataBinder.Eval(Container.DataItem,"DEP")%> </span><span  class="rightdate"><%# DataBinder.Eval(Container.DataItem,"num")%>册</span> </li></ItemTemplate>
                </asp:Repeater>
                
                              
            </ul>
        </div>
    </div>
    <div class="right_block" id="vote">
        <div class="right_block_head"><span class="head_title">在线调查</span></div>
        <div class="right_block_info" id="myvote">
             <ul id="lib_vote" runat="server">
                
                              
            </ul>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
jQuery(function($) {
  createCode();
}); 
var indexoriginhtml=$("#myvote").html(); //获取最原始的投票代码 
function showToolTip2(evt)
{
     if (evt) {
        var url = evt.target;
    }
    else {
        evt = window.event;
        var url = evt.srcElement;
    }
    xPos = evt.clientX;
    yPos = evt.clientY;

   var toolTip = document.getElementById("toolTip");
   
  toolTip.style.top = parseInt(yPos)+2 + "px";
 //  toolTip.style.left = parseInt(xPos)+2 + "px";
   toolTip.style.visibility = "visible";
   
}
</script>
<div id="toolTip" style="left:400px; ">
<div id="toolTiphead" style="height:16px;"><span style="float:right;cursor:pointer;"  onclick="hideToolTip();">关闭</span> <span style="float:left;">我的图书馆&nbsp;&nbsp;使用说明</span></div>
<div id="toolTipinfo">
<p>&nbsp;&nbsp;&nbsp;&nbsp; 图书馆网站上&ldquo;我的图书馆&rdquo;功能主要面向已在我校图书馆办理过图书借阅卡（以下简称&ldquo;一卡通&rdquo;）的读者。本馆持证用户注册后，除了可以查询图书馆的数字资源外，还提供读者信息查询、读者借阅信息查询、借阅历史、图书续借、Rss订阅等自助服务项目。以下介绍首次使用&ldquo;我的图书馆&rdquo;的具体操作：<br />
<span>&nbsp;&nbsp;&nbsp; </span>第一步、填入注册信息<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;在&ldquo;用户登录&rdquo;页面的输入框输入您的用户名（注册名用于我的图书馆登录）用户名可以是中文，如北京；可以是字母，如beijing；可以是字母开头与数字组合，如beijing2008。如果我们认为某用户名存在不良意图、不良影响，有权作停用处理。注册信息还需输入您的一卡通卡号（卡号可到图书馆阅览室查询）、密码、密码答案（用户忘记密码时使用）等信息。填写完毕后点击</span>&ldquo;确认增加&rdquo;，成功增加后系统会提示&ldquo;用户某某某注册成功，请返回去登录&rdquo;。<br />
<span>&nbsp;&nbsp;&nbsp; </span>第二步：登录系统正式使用<br />
&nbsp;&nbsp;&nbsp;&nbsp;注册成功后直接返回，或重新登录图书馆主页，输入用户名、密码进行登录，登录后就可以使用了。</p>
<div style="text-indent: 21pt">&nbsp;</div>
<div style="margin: 0cm 0cm 0pt 22.9pt; text-indent: -21pt">『提示』1、一个一卡通帐号仅限注册一个用户名，请用户牢记自己的用户名和密码。</div>
<div style="margin: 0cm 0cm 0pt 43.9pt">2、欢迎使用&ldquo;我的图书馆&rdquo;，请您记住您的密码及密码问题答案。如果忘记登录密码，请登录图书馆主页，在&ldquo;我的图书馆&rdquo;输入证号后，点击&ldquo;忘记密码&rdquo;。 进入到&ldquo;忘记密码&rdquo;界面，请您根据提示填写即可找回您的密码。<br />
3、在使用过程中遇到问题可与图书馆技术组联系，联系电话77273。</div>
</div>
 </div>
</asp:Content>

