<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="NewsList" Title="Untitled Page" %>
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
      <td style="background-image:url(images/bg.gif); height:27px; text-align:center;"><span class="title" id="list_title" runat="server"></span><br /></td>
    </tr>
    <tr>
      <td valign="top" style=" height:auto;" > 
        <div id="allinfo" style="text-align:left;"><form id="userinfo" action="" method="post" enctype="multipart/form-data" target="_self" runat="server">
        <div class="item" style="display:none;">
          标题：<input size="50" name="title" id="title" type="text"  value="" />
           
               &nbsp;审核状态：<select id="ischeck" name="ischeck">
             <option value="" selected="selected">所有</option>
             <option value="1">已审</option>
             <option value="0">待审</option>
             </select>
            &nbsp;<input id="Submit1" type="submit"  value="查询" />&nbsp;<input type="hidden" runat="server" name="horder" id="horder" />
           <label style="display:none;"  runat="server" id="hcon"></label>
           </div>
       
            <asp:Repeater ID="news_list_all" runat="server">
            <HeaderTemplate><table id="sort" style="padding:10px 0px 5px 20px;" width="100%" border="0" cellpadding="0" cellspacing="0">
            <thead><tr><th title="单击按标签名排序" style="width:120px;">标题</th><th title="单击按使用次数排序" style="width:60px;">发布时间</th><th title="单击按访问次数排序"  style="width:60px;">发布人</th><th style="width:80px;">审核/反审</th><th style="width:80px;">更改</th><th style="width:50px;">删除</th></tr>
            </thead><tbody></HeaderTemplate>
            <ItemTemplate> 
          <tr style="line-height:15px;" id="tr<%# DataBinder.Eval(Container.DataItem,"id") %>"><td id="title<%# DataBinder.Eval(Container.DataItem,"id") %>"><input type="checkbox" value="<%# DataBinder.Eval(Container.DataItem,"id") %>" name="choosecheck" /><a href="../NewsView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id") %>" target="_blank"><%# DataBinder.Eval(Container.DataItem,"title") %></a>  </td>
          
          <td id="times<%# DataBinder.Eval(Container.DataItem,"id") %>"><%# DataBinder.Eval(Container.DataItem,"pub_time") %></td>
          <td id="use<%# DataBinder.Eval(Container.DataItem,"id") %>"><%# DataBinder.Eval(Container.DataItem,"pub_user") %></td>
              <td id="check<%# DataBinder.Eval(Container.DataItem,"id") %>"><a href="#"  style="cursor:pointer;" onclick="checkbox('<%# DataBinder.Eval(Container.DataItem,"id") %>','<%# DataBinder.Eval(Container.DataItem,"ischeck") %>');"><img height="18" title="点击进行审核/反审操作" style="border:none;" src="images/check<%# DataBinder.Eval(Container.DataItem,"ischeck") %>.gif" /></a></td>
              <td id="change<%# DataBinder.Eval(Container.DataItem,"id") %>"><a href="pubnews.aspx?act=edit&type=<%# DataBinder.Eval(Container.DataItem,"news_type") %>&id=<%# DataBinder.Eval(Container.DataItem,"id") %>"  style="cursor:pointer;" >更改</a></td>
              <td><a href="pubnews.aspx?act=delete&type=<%# DataBinder.Eval(Container.DataItem,"news_type") %>&id=<%# DataBinder.Eval(Container.DataItem,"id") %>" >删除</a></td></tr>
            </ItemTemplate>
            <FooterTemplate><tr><td></td><td></td><td></td><td></td><td></td><td></td></tr></tbody></table></FooterTemplate>
            </asp:Repeater>
         </form>   
        </div>
     </td>
    </tr>
  </table>
<ucl:pagelist ID="mypagenum" runat="server" />

<div>操作：选择/反选（所有）<input type="checkbox" onclick="chooseit();" />
&nbsp;更改成状态<select style="width:80px;" id="shenhe" name="shenhe"><option value="1">已审</option>
             <option value="0">待审</option></select>
    &nbsp;&nbsp;<input type="button" onclick="checkall();" value="审核/反审" />&nbsp;&nbsp;<input onclick="delall();" type="button" value="执行删除" />
    <input type="hidden" id="news_type" value="<%=showtype %>" />
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
function delall() //删除所有
{
    var str="";
    var news_type=$("#news_type").val();

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
           url: "EditNews.aspx",
           cache: false,
           data:"ids="+str+"&act=del&newstype="+news_type,
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
function checkbox(id,type)
{
    var jumpurl=$("#jumpurl").val();
    var news_type=$("#news_type").val();
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
    if(confirm("你确认要 "+change+" ID为 "+id+" 的 标签 记录吗？")==true)
    {
         $.ajax({ type:"Get",
           url: "EditNews.aspx",
           cache: false,
           data:"ids="+id+"&act=check&state="+ischeck+"&newstype="+news_type,
           success: function(data){
                  if(data=="ok")
                  {                     
                    alert("已成功 "+change+" ID为 "+id+" 的 标签 记录！"); 
                     location.href=jumpurl;
                  }
                   else
                   {
                   alert(change+" ID为 "+id+" 的 标签 记录失败，请重试！/n 错误类型："+data); 
                   }    
           }
        }); 
    }
}	
function checkall() //审核或反审所有
{
    var jumpurl=$("#jumpurl").val();
    var str="";
    var checkstate="";
    var news_type=$("#news_type").val();
    checkstate=$("#shenhe").val();
      
   
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
           url: "EditNews.aspx",
           cache: false,
           data:"ids="+str+"&act=check&state="+checkstate+"&newstype="+news_type,
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