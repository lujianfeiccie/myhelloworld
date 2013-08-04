<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="Admin_UserList" %>
<%@ Register Src="~/Contrl/PageNum.ascx" TagName="pagelist" TagPrefix="ucl" %>

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
      <td style="background-image:url(images/bg.gif); height:27px; text-align:center;"><span class="title" id="list_title"><strong>用户列表</strong></span><br /></td>
    </tr>
    <tr>
      <td valign="top" style=" height:auto;" > 
        <div id="allinfo" style="text-align:left;"><form id="userinfo" action="" method="post" enctype="multipart/form-data" target="_self" runat="server">
        <div class="item">
          标题：<input size="50" name="title" id="title" type="text" runat="server" />
           
            &nbsp;<input id="Submit1" type="submit"  value="查询" />&nbsp;<input type="hidden" runat="server" name="horder" id="horder" />
           <label style="display:none;"  runat="server" id="hcon"></label>
           </div>
       
            <asp:Repeater ID="news_list_all" runat="server">
            <HeaderTemplate><table id="sort" style="padding:10px 0px 5px 20px;" width="100%" border="0" cellpadding="0" cellspacing="0">
            <thead><tr><th title="单击按标签名排序" style="width:80px;">用户名</th><th title="类别" style="width:80px;">读者条码</th><th title="文件名" style="width:60px;">密码</th><th title="文件名" style="width:60px;">注册时间</th><th title="文件名" style="width:60px;">登陆次数</th><th title="发布时间排序" style="width:120px;">上次登录</th><th style="width:80px;">审核操作</th><th style="width:80px;">更改</th><th style="width:50px;">删除</th></tr>
            </thead><tbody></HeaderTemplate>
            <ItemTemplate> 
          <tr style="line-height:15px;" id="tr<%# DataBinder.Eval(Container.DataItem,"username") %>"><td id="title<%# DataBinder.Eval(Container.DataItem,"username") %>"><input type="checkbox" value="<%# DataBinder.Eval(Container.DataItem,"username") %>" name="choosecheck" /><span><%# DataBinder.Eval(Container.DataItem,"username") %> </span></td>
           <td id="type<%# DataBinder.Eval(Container.DataItem,"username") %>"><%# DataBinder.Eval(Container.DataItem,"userid") %></td>
           <td id="use<%# DataBinder.Eval(Container.DataItem,"username") %>"><%# DataBinder.Eval(Container.DataItem,"password") %></td>
           
           <td id="reg<%# DataBinder.Eval(Container.DataItem,"username") %>"><%# DataBinder.Eval(Container.DataItem,"reg_time") %></td>
           <td id="times<%# DataBinder.Eval(Container.DataItem,"username") %>"><%# DataBinder.Eval(Container.DataItem,"login_times") %></td>
           <td id="last<%# DataBinder.Eval(Container.DataItem,"username") %>"><%# DataBinder.Eval(Container.DataItem,"last_time") %>/<%# DataBinder.Eval(Container.DataItem,"last_ip") %></td>
          
          
          
              <td id="check<%# DataBinder.Eval(Container.DataItem,"username") %>"><a href="#"  style="cursor:pointer;" onclick="checkbox('<%# DataBinder.Eval(Container.DataItem,"username") %>','<%# DataBinder.Eval(Container.DataItem,"ischeck") %>','check');"><img   title="点击进行审核操作" style="border:none;" src="images/check<%# DataBinder.Eval(Container.DataItem,"ischeck") %>.gif" /></a></td>
              <td id="change<%# DataBinder.Eval(Container.DataItem,"username") %>"><a  href="EditUser.aspx?user=<%# DataBinder.Eval(Container.DataItem,"username") %>"   style="cursor:pointer;" >更改</a></td>
              <td><a href="#" onclick="deletebox('<%# DataBinder.Eval(Container.DataItem,"username") %>');" >删除</a></td></tr>
            </ItemTemplate>
            <FooterTemplate><tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr></tbody></table></FooterTemplate>
            </asp:Repeater>
         </form>   
        </div>
     </td>
    </tr>
  </table>
<ucl:pagelist ID="mypagenum" runat="server" />

<div>操作：选择/反选（所有）<input type="checkbox" onclick="chooseit();" />
&nbsp;更改成状态<select style="width:80px;" id="shenhe" name="shenhe"><option value="1">审核</option>
             <option value="0">反审</option></select>
    &nbsp;&nbsp;<input type="button" onclick="checkall('check');" value="审核/反审" />&nbsp;&nbsp;
   <input onclick="delall();" type="button" value="执行删除" />
  <%if (isadmin)
    { %> <input onclick="setadmin();" type="button" value="设为管理员" /><%} %>
    <input type="hidden" id="jumpurl" value="<%=jumpurl %>" />
      </div>
</div>

<script type="text/javascript" language="javascript">
$(function() {
		$("table #sort").tablesorter();
		
	});

var isallchoose=0;
function chooseit()
{
        
        if(isallchoose==0)
             {$(":checkbox").attr("checked","checked");isallchoose=1;}
        else 
            {$(":checkbox").attr("checked","");isallchoose=0;}
}



function deletebox(id)
{
    $("#title"+id+" [name='choosecheck']").attr("checked","checked");
   delall();
    
}

function setadmin()
{
    var str="";

    $("[name='choosecheck'][checked]").each(function()
    {
        str+=$(this).val()+",";
    //alert($(this).val());
    });
    str=str.substr(0,str.length-1);
    if(str=="")
    {
        alert("请选择！");
        return;
    }
    else
    {
     if(confirm("你确认要 将他们设为管理员 吗？")==true)
     {
             $.ajax({ type:"Get",
               url: "DoUser.aspx",
               cache: false,
               data:"ids="+str+"&act=settype&usertype=gly",
               success: function(data){
                      if(data=="ok")
                      {                     
                        alert("已成功设置！"); 
                        $("[name='choosecheck'][checked]").each(function()
                        {
                             //str+=$(this).val()+",";
                             $("#tr"+$(this).val()).remove(); 
                        });
                        
                      }
                       else
                       {
                        alert("设置记录失败，请重试！/n 错误类型："+data); 
                       }    
               }
            }); 
        }
      }
}
function delall() //删除所有
{
    var str="";

    $("[name='choosecheck'][checked]").each(function()
    {
        str+=$(this).val()+",";
    //alert($(this).val());
    });
    str=str.substr(0,str.length-1);
    if(str=="")
    {
        alert("请选择！");
        return;
    }
    else
    {
         $.ajax({ type:"Get",
           url: "DoUser.aspx",
           cache: false,
           data:"ids="+str+"&act=del",
           success: function(data){
                  if(data=="ok")
                  {                     
                    alert("已成功删除记录！"); 
                    $("[name='choosecheck'][checked]").each(function()
                    {
                         //str+=$(this).val()+",";
                         $("#tr"+$(this).val()).remove(); 
                    });
                    
                  }
                   else
                   {
                    alert("删除记录失败，请重试！/n 错误类型："+data); 
                   }    
           }
        }); 
      }
}
function checkbox(id,type,caozuo)
{
    var jumpurl=$("#jumpurl").val();
 
    var change;
    var ischeck;
    var versa;
    if(type=="True")
        {
            change="反审";
            ischeck=0;
            
        }
    else
    {
        change="审核";
        ischeck=1;
       
    }
    if(confirm("你确认要 "+change+" ID为 "+id+" 的  记录吗？")==true)
    {
         $.ajax({ type:"Get",
           url: "DoUser.aspx",
           cache: false,
           data:"ids="+id+"&act="+caozuo+"&state="+ischeck,
           success: function(data){
                  if(data=="ok")
                  {                     
                    alert("已成功 "+change+" ID为 "+id+" 的  记录！"); 
                     location.href=jumpurl;
                  }
                   else
                   {
                   alert(change+" ID为 "+id+" 的  记录失败，请重试！/n 错误类型："+data); 
                   }    
           }
        }); 
    }
}	
function checkall(type) //审核或反审所有
{
    var jumpurl=$("#jumpurl").val();
    var str="";
    var checkstate="";
    var act="check";
    
     if(type=="top")
        {
            checkstate=$("#zhiding").val();
            act="top";
        }
    else
    {
        checkstate=$("#shenhe").val();
        act="check";
       
    }
   
      
   
    $("[name='choosecheck'][checked]").each(function()
    {
        str+=$(this).val()+",";
    //alert($(this).val());
    });
    str=str.substr(0,str.length-1);
    if(str=="")
    {
        alert("请选择！");
        return;
    }
    else
    {
         $.ajax({ type:"Get",
           url: "DoUser.aspx",
           cache: false,
           data:"ids="+str+"&act="+act+"&state="+checkstate,
           success: function(data){
                  if(data=="ok")
                  {   
                       
                    alert("已成功操作记录！"); 
                    location.href=jumpurl;
                    
                   
                    
                  }
                   else
                   {
                    alert("操作记录失败，请重试！/n 错误类型："+data); 
                   }    
           }
        }); 
      }
}

</script>
</body>

</html>