<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_left.aspx.cs" Inherits="Admin_Admin_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script type="text/javascript" language="javascript">
function showsubmenu(sid)
{
	whichEl =document.getElementById("submenu" + sid);
	menuTitle = document.getElementById("menuTitle" + sid);
	if (whichEl.style.display == "none")
	{
	whichEl.style.display = "block";
	menuTitle.style.backgroudImage="url(images/title_bg_hide.gif)";
	}
	else
	{
	whichEl.style.display = "none";
	menuTitle.style.backgroudImage="url(images/title_bg_show.gif)";
	}
}
</script>
<title></title>
<meta http-equiv="Content-Type" content="text/html; charset=GBK" />
<style type="text/css">
BODY {
	BACKGROUND:#799AE1; MARGIN: 0px; FONT: 9pt 宋体;
	SCROLLBAR-HIGHLIGHT-COLOR: ;
	SCROLLBAR-ARROW-COLOR:#215dc6;
	SCROLLBAR-TRACK-COLOR:#d6dff7;
	SCROLLBAR-BASE-COLOR:#AEC6F0;
}
TD { FONT: 12px 宋体}
A { FONT: 12px 宋体; COLOR: #000000; TEXT-DECORATION: none }
A:hover { COLOR: #428eff; TEXT-DECORATION: underline}

.sec_menu 
{
	BORDER-RIGHT: white 1px solid; BACKGROUND: #d6dff7; 
	OVERFLOW: hidden; BORDER-LEFT: white 1px solid; BORDER-BOTTOM: white 1px solid 
}

.menu_title SPAN { FONT-WEIGHT: bold; LEFT: 8px; COLOR: #215dc6; POSITION: relative; TOP: 2px }

.menu_title2 SPAN { FONT-WEIGHT: bold; LEFT: 8px; COLOR: #428eff; POSITION: relative; TOP: 2px }
</style>
<body>
   <table cellspacing="0" cellpadding="0" width="156" align="center">
<tr>
    <td valign="bottom" height="42"><img height="25" src="images/admin_left_9.gif" width="156" border="0"></td>
  </tr>
<tr>
    <td class="menu_title" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" background="images/title_bg_quit.gif" height="25"> 
      <span><a target="rightFrame" title="后台首页" href="Admin_right.aspx"><b><font color="215DC6">后台首页</font></b></a>|<a target="_parent" title="安全退出管理系统" href="Logout.aspx"><b><font color="215DC6">安全退出</font></b></a></span> 
  <tr>
    <td class="menu_title2" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" background="images/title_bg_quit.gif" height="25"> 
      <span class="menu_title"><b><font color="215DC6">登录用户：</font></b></span> 
        <%=Session["username"].ToString() %><br />
<tr><td>&nbsp;<br><br></td></tr>
</table>
<table cellspacing="0" cellpadding="0" width="156" align="center">
  <tr>
    <td class="menu_title" id="menuTitle0" onmouseover="this.className='menu_title2';" onclick="showsubmenu('0')" onmouseout="this.className='menu_title';" style="cursor:pointer; background-image:url(images/title_bg_show.gif);"  height="25"><span>个人信息</span></td>
  </tr>
  <tr>
    <td id="submenu0" style="DISPLAY: none">
      <div class="sec_menu" style="WIDTH: 156px">
       <table cellspacing="0" cellpadding="0" width="135" align="center">
           <tr>
            <td height="22"><a href="EditUser.aspx?act=self" target="rightFrame">信息修改</a></td>
          </tr>
        </table>
      </div>
      <div style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
            <td height="22"></td>
          </tr>
        </table>
    </div></td>
  </tr>
</table>

<table cellspacing="0" cellpadding="0" width="156" align="center">
  <tr>
    <td width="160" height="25" style="background-image:url(images/title_bg_show.gif);cursor:pointer;"  class="menu_title" id="menuTitle2"  onclick="showsubmenu('2');" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';"><span>新闻管理</span></td>
  </tr>
  <tr>
    <td id="submenu2" style="DISPLAY: none">
      <div class="sec_menu" style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
		  <td height="22"><a href="PubNews.aspx?type=news" target="rightFrame">添加新闻</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="NewsList.aspx?type=news" target="rightFrame">新闻列表</a></td>
          </tr>
               
        </table>
      </div>
      <div style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
            <td height="22"></td>
          </tr>
        </table>
    </div></td>
  </tr>
</table>

<table cellspacing="0" cellpadding="0" width="156" align="center">
  <tr>
    <td width="160" height="25" style="background-image:url(images/title_bg_show.gif);cursor:pointer;"  class="menu_title" id="menuTitle3"  onclick="showsubmenu('3');" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';"><span>公告管理</span></td>
  </tr>
  <tr>
    <td id="submenu3" style="DISPLAY: none">
      <div class="sec_menu" style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
		  <td height="22"><a href="PubNews.aspx?type=notice" target="rightFrame">添加公告</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="NewsList.aspx?type=notice" target="rightFrame">公告列表</a></td>
          </tr>
               
        </table>
      </div>
      <div style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
            <td height="22"></td>
          </tr>
        </table>
    </div></td>
  </tr>
</table>


<table cellspacing="0" cellpadding="0" width="156" align="center">
  <tr>
    <td width="160" height="25" style="background-image:url(images/title_bg_show.gif);cursor:pointer;"  class="menu_title" id="menuTitle12"  onclick="showsubmenu('12');" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';"><span>留言管理</span></td>
  </tr>
  <tr>
    <td id="submenu12" style="DISPLAY: none">
      <div class="sec_menu" style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
		  <td height="22"><a href="NoteList.aspx?type=zx" target="rightFrame">在线咨询</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="NoteList.aspx?type=mail" target="rightFrame">馆长信箱</a></td>
          </tr>
               
        </table>
      </div>
      <div style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
            <td height="22"></td>
          </tr>
        </table>
    </div></td>
  </tr>
</table>


<table cellspacing="0" cellpadding="0" width="156" align="center">
  <tr>
    <td width="160" height="25" style="background-image:url(images/title_bg_show.gif);cursor:pointer;"  class="menu_title" id="menuTitle9"  onclick="showsubmenu('9');" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';"><span>新书管理</span></td>
  </tr>
  <tr>
    <td id="submenu9" style="DISPLAY: none">
      <div class="sec_menu" style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
		  <td height="22"><a href="PubBook.aspx" target="rightFrame">添加新书</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="BookList.aspx" target="rightFrame">新书列表</a></td>
          </tr>
           <tr> 
		  <td height="22"><a href="Savebooks.aspx" target="rightFrame">备份列表</a></td>
          </tr>    
        </table>
      </div>
      <div style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
            <td height="22"></td>
          </tr>
        </table>
    </div></td>
  </tr>
</table>

<table cellspacing="0" cellpadding="0" width="156" align="center">
  <tr>
    <td width="160" height="25" style="background-image:url(images/title_bg_show.gif);cursor:pointer;"  class="menu_title" id="menuTitle20"  onclick="showsubmenu('20');" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';"><span>EXCEL数据导入</span></td>
  </tr>
  <tr>
    <td id="submenu20" style="DISPLAY: none">
      <div class="sec_menu" style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
		  <td height="22"><a href="ImportExcel.aspx?type=paper" target="rightFrame">论文数据导入</a></td>
          </tr>
          
          <tr> 
		  <td height="22"><a href="ImportExcel.aspx?type=cd" target="rightFrame">随书光盘导入</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="ImportExcel.aspx?type=teach" target="rightFrame">情报资源导入</a></td>
          </tr>
         
               
        </table>
      </div>
      <div style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
            <td height="22"></td>
          </tr>
        </table>
    </div></td>
  </tr>
</table>


<table cellspacing="0" cellpadding="0" width="156" align="center">
  <tr>
    <td width="160" height="25" style="background-image:url(images/title_bg_show.gif);cursor:pointer;"  class="menu_title" id="menuTitle10"  onclick="showsubmenu('10');" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';"><span>参考咨询</span></td>
  </tr>
  <tr>
    <td id="submenu10" style="DISPLAY: none">
      <div class="sec_menu" style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
		  <td height="22"><a href="LibInfoSet.aspx?type=wt" target="rightFrame">常见问题</a></td>
          </tr>
          
          <tr> 
		  <td height="22"><a href="PubNews.aspx?type=px" target="rightFrame">添加培训</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="NewsList.aspx?type=px" target="rightFrame">培训列表</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="PubDownload.aspx" target="rightFrame">添加下载</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="DownloadList.aspx" target="rightFrame">下载列表</a></td>
          </tr>
               
        </table>
      </div>
      <div style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
            <td height="22"></td>
          </tr>
        </table>
    </div></td>
  </tr>
</table>

<table cellspacing="0" cellpadding="0" width="156" align="center">
  <tr>
    <td width="160" height="25" style="background-image:url(images/title_bg_show.gif);cursor:pointer;"  class="menu_title" id="menuTitle4"  onclick="showsubmenu('4');" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';"><span>链接管理</span></td>
  </tr>
  <tr>
    <td id="submenu4" style="DISPLAY: none">
      <div class="sec_menu" style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          
          <tr> 
		  <td height="22"><a href="LinkList.aspx" target="rightFrame">链接列表</a></td>
          </tr>
               
        </table>
      </div>
      <div style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
            <td height="22"></td>
          </tr>
        </table>
    </div></td>
  </tr>
</table>

<table cellspacing="0" cellpadding="0" width="156" align="center">
  <tr>
    <td width="160" height="25" style="background-image:url(images/title_bg_show.gif);cursor:pointer;"  class="menu_title" id="menuTitle5"  onclick="showsubmenu('5');" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';"><span>搜索管理</span></td>
  </tr>
  <tr>
    <td id="submenu5" style="DISPLAY: none">
      <div class="sec_menu" style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
		  <td height="22"><a href="SearchList.aspx" target="rightFrame">搜索管理</a></td>
          </tr>
         
               
        </table>
      </div>
      <div style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
            <td height="22"></td>
          </tr>
        </table>
    </div></td>
  </tr>
</table>

<table cellspacing="0" cellpadding="0" width="156" align="center">
  <tr>
    <td width="160" height="25" style="background-image:url(images/title_bg_show.gif);cursor:pointer;"  class="menu_title" id="menuTitle6"  onclick="showsubmenu('6');" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';"><span>投票管理</span></td>
  </tr>
  <tr>
    <td id="submenu6" style="DISPLAY: none">
      <div class="sec_menu" style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
		  <td height="22"><a href="VoteList.aspx" target="rightFrame">投票管理</a></td>
          </tr>
          
               
        </table>
      </div>
      <div style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
            <td height="22"></td>
          </tr>
        </table>
    </div></td>
  </tr>
</table>


<table cellspacing="0" cellpadding="0" width="156" align="center">
  <tr>
    <td width="160" height="25" style="background-image:url(images/title_bg_show.gif);cursor:pointer;"  class="menu_title" id="menuTitle7"  onclick="showsubmenu('7');" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';"><span>用户管理</span></td>
  </tr>
  <tr>
    <td id="submenu7" style="DISPLAY: none">
      <div class="sec_menu" style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
        
         <!-- <tr> 
		  <td height="22"><a href="UserList.aspx?check=no" target="rightFrame">待审用户</a></td>
          </tr>-->
           <tr> 
		  <td height="22"><a href="UserList.aspx?check=yes" target="rightFrame">已审用户</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="AdminList.aspx" target="rightFrame">管理员设置</a></td>
          </tr>
               
        </table>
      </div>
      <div style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
            <td height="22"></td>
          </tr>
        </table>
    </div></td>
  </tr>
</table>



<table cellspacing="0" cellpadding="0" width="156" align="center">
  <tr>
    <td width="160" height="25" style="background-image:url(images/title_bg_show.gif);cursor:pointer;"  class="menu_title" id="menuTitle11"  onclick="showsubmenu('11');" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';"><span>数字资源管理</span></td>
  </tr>
  <tr>
    <td id="submenu11" style="DISPLAY: none">
      <div class="sec_menu" style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
        <tr> 
		  <td height="22"><a href="LibZyList.aspx" target="rightFrame">资源列表</a></td>
          </tr>
          
               
        </table>
      </div>
      <div style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
            <td height="22"></td>
          </tr>
        </table>
    </div></td>
  </tr>
</table>



<table cellspacing="0" cellpadding="0" width="156" align="center">
  <tr>
    <td width="160" height="25" style="background-image:url(images/title_bg_show.gif);cursor:pointer;"  class="menu_title" id="menuTitle8"  onclick="showsubmenu('8');" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';"><span>系统管理</span></td>
  </tr>
  <tr>
    <td id="submenu8" style="DISPLAY: none">
      <div class="sec_menu" style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
		  <td height="22"><a href="WebSet.aspx" target="rightFrame">系统设置</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="LibInfoSet.aspx?type=jj" target="rightFrame">图书馆概况</a></td>
          </tr>
           <tr> 
		  <td height="22"><a href="LibInfoSet.aspx?type=fb" target="rightFrame">馆藏分布</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="LibInfoSet.aspx?type=zn" target="rightFrame">部门指南</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="LibInfoSet.aspx?type=fc" target="rightFrame">图书馆风采</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="LibInfoSet.aspx?type=xz1" target="rightFrame">入馆须知</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="LibInfoSet.aspx?type=xz2" target="rightFrame">入室须知</a></td>
          </tr>  
          <tr> 
		  <td height="22"><a href="LibInfoSet.aspx?type=sj" target="rightFrame">服务时间</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="LibInfoSet.aspx?type=zd" target="rightFrame">借阅制度</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="LibInfoSet.aspx?type=lc" target="rightFrame">借阅流程</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="LibInfoSet.aspx?type=zd2" target="rightFrame">借书卡制度</a></td>
          </tr>
          <tr> 
		  <td height="22"><a href="LibInfoSet.aspx?type=sy" target="rightFrame">找书索引</a></td>
          </tr>
          
        </table>
      </div>
      <div style="WIDTH: 156px">
        <table cellspacing="0" cellpadding="0" width="135" align="center">
          <tr> 
            <td height="22"></td>
          </tr>
        </table>
    </div></td>
  </tr>
</table>
<br />
<br  />
</body>
</body>
</html>
