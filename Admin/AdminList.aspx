<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminList.aspx.cs" Inherits="Admin_AdminList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=GBK" />
<title>管理首页</title>
<link href="css/bodystyle.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="../Js/jquery.js"></script>
<script type="text/javascript" language="javascript" src="../Js/jquery.tablesorter.js"></script>
</head>
<body>
<div style="height:100%; text-align:center;">
  <table width="100%"  style="height:100%; text-align:center;" cellpadding="0" cellspacing="0">
    <tr style="background-image:url(images/bg.gif); height:27px;">
      <td style="background-image:url(images/bg.gif); height:27px; text-align:center;"><span class="title"><strong>管理员管理</strong></span><br /></td>
    </tr>
    <tr>
      <td valign="top" style=" height:auto;" > 
        <div id="allinfo" style="text-align:left;"><form id="userinfo" action="" method="post" enctype="multipart/form-data" target="_self" runat="server">
        
       
            <asp:Repeater ID="admin_list" runat="server">
            <HeaderTemplate><table id="sort" style="padding:10px 0px 5px 20px;" width="100%" border="0" cellpadding="0" cellspacing="0">
            <thead><tr><th title="标题排序" style="width:50px;">用户名</th><th title="地址排序" style="width:50px;">密码</th><th>新闻</th><th>通知</th><th>投票</th><th>链接</th><th>用户</th><th>下载</th><th>搜索</th><th>新书</th><th>论文</th><th>咨询</th><th>资源</th><th>系统</th><th>更改</th><th >删除/设为普通</th></tr>
            </thead><tbody>
            <tr>
            <td><input style="width:50px;"   id="name0" type="text" /></td>
            <td><input style="width:60px;"  id="psw0" type="text" /></td>
            <td><input id="news0" type="checkbox" /></td>
            <td><input id="notice0" type="checkbox" /></td>
            <td><input id="vote0" type="checkbox" /></td>
            <td><input id="links0" type="checkbox" /></td>
            <td><input id="user0" type="checkbox" /></td>
            <td><input id="download0" type="checkbox" /></td>
            <td><input id="search0" type="checkbox" /></td>
            <td><input id="book0" type="checkbox" /></td>
            <td><input id="paper0" type="checkbox" /></td>
            <td><input id="note0" type="checkbox" /></td>
            <td><input id="zy0" type="checkbox" /></td>
            <td><input id="web0" type="checkbox" /></td>
            <td><input id="adddfdfs" type="button" value="增加" onclick="addadmin('0');" /></td>
            
            </tr>
            
            </HeaderTemplate>
            <ItemTemplate> 
          <tr style="line-height:15px;" id="tr<%# DataBinder.Eval(Container.DataItem,"username") %>"><td><%# DataBinder.Eval(Container.DataItem,"username") %></td>
          
          <td><input style="width:60px;"  id="psw<%# DataBinder.Eval(Container.DataItem,"username") %>" type="text" value="<%# DataBinder.Eval(Container.DataItem,"password") %>" /></td>
                <td><input type="checkbox" id="news<%# DataBinder.Eval(Container.DataItem,"username") %>"  <%# IsCheck(DataBinder.Eval(Container.DataItem,"news_op").ToString()) %> /></td>
                <td><input type="checkbox" id="notice<%# DataBinder.Eval(Container.DataItem,"username") %>"  <%# IsCheck(DataBinder.Eval(Container.DataItem,"notice_op").ToString()) %> /></td>
                <td><input type="checkbox" id="vote<%# DataBinder.Eval(Container.DataItem,"username") %>"  <%# IsCheck(DataBinder.Eval(Container.DataItem,"vote_op").ToString()) %> /></td>
                <td><input type="checkbox" id="links<%# DataBinder.Eval(Container.DataItem,"username") %>"  <%# IsCheck(DataBinder.Eval(Container.DataItem,"links_op").ToString()) %> /></td>
                <td><input type="checkbox" id="user<%# DataBinder.Eval(Container.DataItem,"username") %>"  <%# IsCheck(DataBinder.Eval(Container.DataItem,"user_op").ToString()) %> /></td>
                <td><input type="checkbox" id="download<%# DataBinder.Eval(Container.DataItem,"username") %>"  <%# IsCheck(DataBinder.Eval(Container.DataItem,"download_op").ToString()) %> /></td>
                <td><input type="checkbox" id="search<%# DataBinder.Eval(Container.DataItem,"username") %>"  <%# IsCheck(DataBinder.Eval(Container.DataItem,"search_op").ToString()) %> /></td>
                <td><input type="checkbox" id="book<%# DataBinder.Eval(Container.DataItem,"username") %>"  <%# IsCheck(DataBinder.Eval(Container.DataItem,"book_op").ToString()) %> /></td>
                <td><input type="checkbox" id="paper<%# DataBinder.Eval(Container.DataItem,"username") %>"  <%# IsCheck(DataBinder.Eval(Container.DataItem,"paper_op").ToString()) %> /></td>
                <td><input type="checkbox" id="note<%# DataBinder.Eval(Container.DataItem,"username") %>"  <%# IsCheck(DataBinder.Eval(Container.DataItem,"note_op").ToString()) %> /></td>
                <td><input type="checkbox" id="zy<%# DataBinder.Eval(Container.DataItem,"username") %>"  <%# IsCheck(DataBinder.Eval(Container.DataItem,"zy_op").ToString()) %> /></td>
                <td><input type="checkbox" id="web<%# DataBinder.Eval(Container.DataItem,"username") %>"  <%# IsCheck(DataBinder.Eval(Container.DataItem,"web_op").ToString()) %> /></td>
                
              <td><a href="javascript:update('<%# DataBinder.Eval(Container.DataItem,"username") %>');" onclick="" style="cursor:pointer;" >更改</a></td>
              <td><a href="javascript:deleteitem('<%# DataBinder.Eval(Container.DataItem,"username") %>');" onclick="" >删除</a>&nbsp;&nbsp;<a href="javascript:deleteitem2('<%# DataBinder.Eval(Container.DataItem,"username") %>');" onclick="" >设为普通</a></td></tr>
            </ItemTemplate>
            <FooterTemplate><tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr></tbody></table></FooterTemplate>
            </asp:Repeater>
         </form>   
        </div>
     </td>
    </tr>
  </table>
<script type="text/javascript" language="javascript">
$(function() {
		$("table #sort").tablesorter();
		
	});

function update(id)
{
 if(confirm("你确认要更改 "+id+" 此用户的权限吗？")==true)
    {
        var psw=$("#psw"+id).val();
	     var news=$("#news"+id).attr("checked");
        var notice=$("#notice"+id).attr("checked");
        var links=$("#links"+id).attr("checked");
        var user=$("#user"+id).attr("checked");
        var zy=$("#zy"+id).attr("checked");
        var web=$("#web"+id).attr("checked");
        var note=$("#note"+id).attr("checked");
        var paper=$("#paper"+id).attr("checked");
        var download=$("#download"+id).attr("checked");
        var search=$("#search"+id).attr("checked");
        var book=$("#book"+id).attr("checked");
        var vote=$("#vote"+id).attr("checked");
       
        

        $.ajax({ type:"Get",
           url: "DoUser.aspx",
           cache: false,
           data:"type=manage&username="+id+"&psw="+escape(psw)+"&vote="+vote+"&book="+book+"&news="+news+"&act=update&notice="+notice+"&links="+links+"&user="+user+"&zy="+zy+"&web="+web+"&note="+note+"&download="+download+"&search="+search+"&paper="+paper,
           success: function(data){
                  if(data=="ok")
                  {
                     
                    alert("已成功更新 "+id+" 用户的  记录！"); 
                    
                   }
                   else
                   {
                   alert("更新 "+id+" 用户的  记录失败，请重试！/n 错误类型："+data); 
                   }    
           }
        }); 
    }

}

function deleteitem(id)
{
if(confirm("你确认要彻底删除 "+id+" 用户的记录(包括普通用户也删除)吗？此操作将不可恢复！")==true)
    {
        
         $.ajax({ type:"Get",
           url: "DoUser.aspx",
           cache: false,
           data:"ids="+id+"&act=del",
           success: function(data){
                  if(data=="ok")
                  {                     
                    alert("已成功删除 "+id+" 用户的  记录！"); 
                    $("#tr"+id).remove(); 
                  }
                   else
                   {
                   alert("删除 "+id+" 用户的  记录失败，请重试！/n 错误类型："+data); 
                   }    
           }
        }); 
    }
}
function deleteitem2(id)
{
        if(confirm("你确认要将用户 "+id+" 设为普通用户吗？")==true)
    {
        
         $.ajax({ type:"Get",
           url: "DoUser.aspx",
           cache: false,
           data:"ids="+id+"&act=settype&usertype=putong",
           success: function(data){
                  if(data=="ok")
                  {                     
                    alert("已成功更改 "+id+" 用户的  记录！"); 
                    $("#tr"+id).remove(); 
                  }
                   else
                   {
                   alert("更改 "+id+" 用户的  记录失败，请重试！/n 错误类型："+data); 
                   }    
           }
        }); 
    }

}
function addadmin(id)
{
 var username=$("#name"+id).val();
 var psw=$("#psw"+id).val();
if(psw!=""&&username!=""&&confirm("你确认要增加该管理员？")==true)
    {
       
        
	     var news=$("#news"+id).attr("checked");
        var notice=$("#notice"+id).attr("checked");
        var links=$("#links"+id).attr("checked");
        var user=$("#user"+id).attr("checked");
        var zy=$("#zy"+id).attr("checked");
        var web=$("#web"+id).attr("checked");
        var note=$("#note"+id).attr("checked");
        var paper=$("#paper"+id).attr("checked");
        var download=$("#download"+id).attr("checked");
        var search=$("#search"+id).attr("checked");
        var book=$("#book"+id).attr("checked");
        var vote=$("#vote"+id).attr("checked");
       
        

        $.ajax({ type:"Get",
           url: "DoUser.aspx",
           cache: false,
           data:"type=manage&username="+escape(username)+"&psw="+escape(psw)+"&vote="+vote+"&book="+book+"&news="+news+"&act=add&notice="+notice+"&links="+links+"&user="+user+"&zy="+zy+"&web="+web+"&note="+note+"&download="+download+"&search="+search+"&paper="+paper,
           success: function(data){
                  if(data=="ok")
                  {
                     
                    alert("已成功增加管理员 记录！"); 
                    location.href="AdminList.aspx";
                    
                   }
                   else
                   {
                   alert("增加管理员 记录失败，请重试！/n 错误类型："+data); 
                   }    
           }
        }); 
    }
}
</script>
</div>
</body>
</html>