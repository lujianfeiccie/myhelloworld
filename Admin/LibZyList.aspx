<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LibZyList.aspx.cs" Inherits="Admin_LibZyList" %>


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
      <td style="background-image:url(images/bg.gif); height:27px; text-align:center;"><span class="title"><strong>数字资源管理</strong></span><br /></td>
    </tr>
    <tr>
      <td valign="top" style=" height:auto;" > 
        <div id="allinfo" style="text-align:left;"><form id="userinfo" action="" method="post" enctype="multipart/form-data" target="_self" runat="server">
        <div class="item" >
          标题：<input size="25" name="addtitle" id="add_title" type="text"  value="" />
           地址：<input size="30" name="addurl" id="add_url" type="text"  value="" />
           序号：<input size="5" name="orderlist" id="add_orderlist" type="text"  value="0" />
           首页显示：<input  id="is_index" type="checkbox" checked="checked" value="1"/>
         
           最新：<input  id="is_new" type="checkbox" value="1"/>
               &nbsp;类别：<select id="add_type" name="ischeck">
             <option value="馆藏资源" selected="selected">馆藏资源</option>
             <option value="特色资源">特色资源</option>
             <option value="军事电子资源">军事电子资源</option>
             <option value="公共资源">公共资源</option>
             
             </select>
            &nbsp;<input id="fsfsf" type="button" onclick="addnew();"  value="添加" />&nbsp;
           
           </div>
       
            <asp:Repeater ID="link_list_all" runat="server">
            <HeaderTemplate><table id="sort" style="padding:10px 0px 5px 20px;" width="100%" border="0" cellpadding="0" cellspacing="0">
            <thead><tr><th title="标题排序" style="width:120px;">标题</th><th title="地址排序" style="width:200px;">地址</th><th title="类别排序"  style="width:80px;">类别</th><th  title="显示序号排序" style="width:80px;">序号</th><th>首页显示</th><th>最新</th><th style="width:40px;">更改</th><th style="width:50px;">删除</th></tr>
            </thead><tbody></HeaderTemplate>
            <ItemTemplate> 
          <tr style="line-height:15px;" id="tr<%# DataBinder.Eval(Container.DataItem,"id") %>"><td id="title<%# DataBinder.Eval(Container.DataItem,"id") %>"><a href="../<%# DataBinder.Eval(Container.DataItem,"url") %>" target="_blank"><%# DataBinder.Eval(Container.DataItem,"title") %></a>  </td>
          
          <td id="url<%# DataBinder.Eval(Container.DataItem,"id") %>"><%# DataBinder.Eval(Container.DataItem,"url") %></td>
          <td id="type<%# DataBinder.Eval(Container.DataItem,"id") %>"><%# GetLinkType(DataBinder.Eval(Container.DataItem, "typename").ToString(), DataBinder.Eval(Container.DataItem, "id").ToString())%></td>
              <td id="order<%# DataBinder.Eval(Container.DataItem,"id") %>"><%# DataBinder.Eval(Container.DataItem,"orderlist") %></td>
              <td><input type="checkbox" id="check<%# DataBinder.Eval(Container.DataItem,"id") %>"  <%# IsCheck(DataBinder.Eval(Container.DataItem,"is_index").ToString()) %> /></td><td><input type="checkbox" <%# IsCheck(DataBinder.Eval(Container.DataItem,"is_new").ToString()) %> id="new<%# DataBinder.Eval(Container.DataItem,"id") %>" /></td>
              <td id="change<%# DataBinder.Eval(Container.DataItem,"id") %>"><a href="javascript:change(<%# DataBinder.Eval(Container.DataItem,"id") %>);" onclick="" style="cursor:pointer;" >更改</a></td>
              <td><a href="javascript:deleteitem(<%# DataBinder.Eval(Container.DataItem,"id") %>);" onclick="" >删除</a></td></tr>
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
function change(id)	
{
    var td1=$("td #title"+id).text();
	 var td2=$("td #url"+id).text();
	 var td4=$("td #order"+id).text();
	 var td5=$("#type_"+id).val();
	// alert(td5);
	 $("td #title"+id).html("<input size='30' id='ititle"+id+"' value='"+td1+"' type='text'/><input style='size:0;display:none;' id='htitle"+id+"' value='"+td1+"' type='hidden'/><input style='size:0;display:none;' id='htype"+id+"' value='"+td5+"' type='hidden'/>");
	 $("td #url"+id).html("<input size='40' id='iurl"+id+"' value='"+td2+"' type='text'/><input style='size:0;display:none;' id='hurl"+id+"' value='"+td2+"' type='hidden'/>");
    $("td #order"+id).html("<input size='3' id='iorder"+id+"' value='"+td4+"' type='text'/><input style='size:0;display:none;' id='horder"+id+"' value='"+td4+"' type='hidden'/>");
	$("td #change"+id).html("<a href='javascript:update("+id+");' style='cursor:pointer;color:red;'>提交</a>&nbsp;&nbsp;<a href='javascript:cancel("+id+");' style='cursor:pointer;color:red;' >取消</a>");
	//用隐藏的记录初始值 
}
function update(id)
{
 if(confirm("你确认要更改此 记录吗？")==true)
    {
        var td1=$("#ititle"+id).val();
	   var td2=$("#iurl"+id).val();
	   var td3=$("#iorder"+id).val();
	    var td5=$("#type_"+id).val();
        var isindex=$("#check"+id).attr("checked");
        var isnew=$("#new"+id).attr("checked");
        alert(td5);
        $.ajax({ type:"Get",
           url: "DoLibZy.aspx",
           cache: false,
           data:"id="+id+"&title="+escape(td1)+"&url="+escape(td2)+"&orderlist="+escape(td3)+"&type="+escape(td5)+"&act=update&index="+isindex+"&new="+isnew,
           success: function(data){
                  if(data=="ok")
                  {
                     
                    alert("已成功更新ID为 "+id+" 的  记录！"); 
                    $("td #title"+id).html(td1);
	                $("td #url"+id).html(td2);
	                $("td #order"+id).html(td3);
	               
	               $("td #change"+id).html("<a href='javascript:change("+id+");' style='cursor:pointer;' >更改</a>");
                   }
                   else
                   {
                   alert("更新ID为 "+id+" 的  记录失败，请重试！/n 错误类型："+data); 
                   }    
           }
        }); 
    }

}
function cancel(id)
{
    var td1=$("#htitle"+id).val();
	   var td2=$("#hurl"+id).val();
	   var td3=$("#horder"+id).val();
	   var td5=$("#htype"+id).val();
	   $("#type_"+id).val(td5);
	   $("td #title"+id).html(td1);
	 $("td #url"+id).html(td2);
	  $("td #order"+id).html(td3);
	$("td #change"+id).html("<a href='javascript:change("+id+");' style='cursor:pointer;' >更改</a>");
}
function deleteitem(id)
{
if(confirm("你确认要删除  记录吗？")==true)
    {
         $.ajax({ type:"Get",
           url: "DoLibZy.aspx",
           cache: false,
           data:"id="+id+"&act=del",
           success: function(data){
                  if(data=="ok")
                  {                     
                    alert("已成功删除ID为 "+id+" 的  记录！"); 
                    $("#tr"+id).remove(); 
                  }
                   else
                   {
                   alert("删除ID为 "+id+" 的  记录失败，请重试！/n 错误类型："+data); 
                   }    
           }
        }); 
    }
}
function addnew()
{
var title=$("#add_title").val();
var url=$("#add_url").val();
var orderlist=$("#add_orderlist").val();
var type=$("#add_type").val();
var isindex=$("#is_index").attr("checked");
var isnew=$("#is_new").attr("checked");
alert(isindex);
     $.ajax({ type:"Get",
           url: "DoLibZy.aspx",
           cache: false,
           data:"title="+escape(title)+"&url="+escape(url)+"&orderlist="+escape(orderlist)+"&type="+escape(type)+"&act=add&index="+isindex+"&new="+isnew,
           success: function(data){
                  if(data=="ok")
                  {                     
                    alert("已成功添加  记录！"); 
                    location.href="LibZyList.aspx";
                  }
                   else
                   {
                    alert("添加ID  记录失败，请重试！/n 错误类型："+data); 
                   }    
           }
        }); 
}
</script>
</div>
</body>
</html>