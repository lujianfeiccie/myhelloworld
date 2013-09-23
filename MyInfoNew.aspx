<%@ Page Language="C#" MasterPageFile="~/AllPage2.master" AutoEventWireup="true" CodeFile="MyInfoNew.aspx.cs" Inherits="MyInfoNew" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content_left_guid">
            <div id="content_left_guid_head"></div>
            
                <a href="MyLibNew.aspx"><div class="content_left_guid_item" >我的图书馆</div></a>     
                <a href="MySearch.aspx"><div class="content_left_guid_item" >图书查询</div> </a>   
                 <a href="Myhistory.aspx"><div class="content_left_guid_item" >借阅历史</div> </a>       
                  <a href="BookOrder.aspx"  style="display:none;"><div class="content_left_guid_item" >图书预约</div> </a>     
                <a href="MyFavorite.aspx"><div class="content_left_guid_item" >我的收藏</div> </a>  
                <a href="BooKBuy.aspx"><div class="content_left_guid_item" >图书荐购</div> </a>        
                 <a href="MyInfo.aspx"><div class="content_left_guid_item_on" >个人信息</div> </a>
                  <a href="MyMail.aspx"><div class="content_left_guid_item" >我的信件</div> </a>     
                  <a href="LoginNew.aspx?act=out"><div class="content_left_guid_item" >退出登录</div> </a>        
            
        </div>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">个人信息</span><span class="head_right" id="sitemap" >当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;<a href="MyLib.aspx">我的图书馆</a>&nbsp;<img src="images/next.jpg" />&nbsp;个人信息</span></div>
              <div class="user_info_list" style="background-color:#ececec;">姓名：<%=myuser.RealName %>,&nbsp;&nbsp;读者条码：<%=myuser.UserID %>,&nbsp;&nbsp;读者类型：<%=myuser.ReaderType %>,&nbsp;&nbsp;证件状态：<%=myuser.State %></div>
              <div class="user_info_list">办证时间：<%=myuser.CardTime %> </div>
              <div class="user_info_list"  style="background-color:#ececec;">单位：<%=myuser.UserDepartment %></div>
              <div class="user_info_list">累计借阅图书：<%=myuser.TotalRent %>,&nbsp;&nbsp;当前借出册数：<%=myuser.NowRent %></div>
              <div class="user_info_list"  style="background-color:#ececec;">欠款金额：<%=myuser.Money %></div>
              <div class="user_info_list"> &nbsp; </div>
              <div class="user_info_list"  style="background-color:#cccccc;">登陆账号信息:<%=myuser.UserName %></div>
              <div class="user_info_list">登陆次数：<%=myuser.LoginTimes %>,&nbsp;&nbsp;上次于&nbsp;&nbsp;<%=myuser.LastLoginTime %>&nbsp;&nbsp;在&nbsp;&nbsp;<%=myuser.LastLoginIP %>&nbsp;&nbsp;登陆</div>
               <div class="user_info_list"  style="background-color:#cccccc;">修改登录密码&nbsp;&nbsp;&nbsp;&nbsp;<span style="color:Red;"  id="result" runat="server"></span></div>
              
              <div class="user_info_list">
              <form id="changepsw"  action="MyInfo.aspx?act=psw" method="post" style="margin:5px 5px 6px 4px;">
                原始密码：<input type="password" style="width:120px;" name="oldpsw" id="oldpsw" />
               新设密码：<input type="password" style="width:120px;" name="newpsw" id="newpsw"/>
                确认新密码：<input type="password" style="width:120px;" name="newpsw2" id="newpsw2"/>
                &nbsp;&nbsp;<input onclick="checkit()" type="button" value="确认修改" />
              </form>
              
              </div>
              
              <div class="user_info_list">  </div>
              
        </div>
  <script language="javascript" type="text/javascript">
  
    function checkit()
    {
        if($("#oldpsw").val()=="")
           { alert("请输入原始密码！"); return false;}
        if($("#newpsw").val()=="")
            { alert("请输入新密码！"); return false;}
        if($("#newpsw2").val()==""||$("#newpsw2").val()!=$("#newpsw").val())
            { alert("两次密码确认不一致！"); return false;}
        else{ $("#changepsw").submit(); return true;}
    }
  </script>
</asp:Content>

