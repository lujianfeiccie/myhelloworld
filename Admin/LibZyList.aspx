<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LibZyList.aspx.cs" Inherits="Admin_LibZyList" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=GBK" />
<title>������ҳ</title>
<link href="css/bodystyle.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript" src="../Js/jquery.js"></script>
<script type="text/javascript" language="javascript" src="../Js/jquery.tablesorter.js"></script>
</head>
<body>
<div style="height:100%; text-align:center;">
  <table width="100%"  style="height:100%; text-align:center;" cellpadding="0" cellspacing="0">
    <tr style="background-image:url(images/bg.gif); height:27px;">
      <td style="background-image:url(images/bg.gif); height:27px; text-align:center;"><span class="title"><strong>������Դ����</strong></span><br /></td>
    </tr>
    <tr>
      <td valign="top" style=" height:auto;" > 
        <div id="allinfo" style="text-align:left;"><form id="userinfo" action="" method="post" enctype="multipart/form-data" target="_self" runat="server">
        <div class="item" >
          ���⣺<input size="25" name="addtitle" id="add_title" type="text"  value="" />
           ��ַ��<input size="30" name="addurl" id="add_url" type="text"  value="" />
           ��ţ�<input size="5" name="orderlist" id="add_orderlist" type="text"  value="0" />
           ��ҳ��ʾ��<input  id="is_index" type="checkbox" checked="checked" value="1"/>
         
           ���£�<input  id="is_new" type="checkbox" value="1"/>
               &nbsp;���<select id="add_type" name="ischeck">
             <option value="�ݲ���Դ" selected="selected">�ݲ���Դ</option>
             <option value="��ɫ��Դ">��ɫ��Դ</option>
             <option value="���µ�����Դ">���µ�����Դ</option>
             <option value="������Դ">������Դ</option>
             
             </select>
            &nbsp;<input id="fsfsf" type="button" onclick="addnew();"  value="���" />&nbsp;
           
           </div>
       
            <asp:Repeater ID="link_list_all" runat="server">
            <HeaderTemplate><table id="sort" style="padding:10px 0px 5px 20px;" width="100%" border="0" cellpadding="0" cellspacing="0">
            <thead><tr><th title="��������" style="width:120px;">����</th><th title="��ַ����" style="width:200px;">��ַ</th><th title="�������"  style="width:80px;">���</th><th  title="��ʾ�������" style="width:80px;">���</th><th>��ҳ��ʾ</th><th>����</th><th style="width:40px;">����</th><th style="width:50px;">ɾ��</th></tr>
            </thead><tbody></HeaderTemplate>
            <ItemTemplate> 
          <tr style="line-height:15px;" id="tr<%# DataBinder.Eval(Container.DataItem,"id") %>"><td id="title<%# DataBinder.Eval(Container.DataItem,"id") %>"><a href="../<%# DataBinder.Eval(Container.DataItem,"url") %>" target="_blank"><%# DataBinder.Eval(Container.DataItem,"title") %></a>  </td>
          
          <td id="url<%# DataBinder.Eval(Container.DataItem,"id") %>"><%# DataBinder.Eval(Container.DataItem,"url") %></td>
          <td id="type<%# DataBinder.Eval(Container.DataItem,"id") %>"><%# GetLinkType(DataBinder.Eval(Container.DataItem, "typename").ToString(), DataBinder.Eval(Container.DataItem, "id").ToString())%></td>
              <td id="order<%# DataBinder.Eval(Container.DataItem,"id") %>"><%# DataBinder.Eval(Container.DataItem,"orderlist") %></td>
              <td><input type="checkbox" id="check<%# DataBinder.Eval(Container.DataItem,"id") %>"  <%# IsCheck(DataBinder.Eval(Container.DataItem,"is_index").ToString()) %> /></td><td><input type="checkbox" <%# IsCheck(DataBinder.Eval(Container.DataItem,"is_new").ToString()) %> id="new<%# DataBinder.Eval(Container.DataItem,"id") %>" /></td>
              <td id="change<%# DataBinder.Eval(Container.DataItem,"id") %>"><a href="javascript:change(<%# DataBinder.Eval(Container.DataItem,"id") %>);" onclick="" style="cursor:pointer;" >����</a></td>
              <td><a href="javascript:deleteitem(<%# DataBinder.Eval(Container.DataItem,"id") %>);" onclick="" >ɾ��</a></td></tr>
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
	$("td #change"+id).html("<a href='javascript:update("+id+");' style='cursor:pointer;color:red;'>�ύ</a>&nbsp;&nbsp;<a href='javascript:cancel("+id+");' style='cursor:pointer;color:red;' >ȡ��</a>");
	//�����صļ�¼��ʼֵ 
}
function update(id)
{
 if(confirm("��ȷ��Ҫ���Ĵ� ��¼��")==true)
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
                     
                    alert("�ѳɹ�����IDΪ "+id+" ��  ��¼��"); 
                    $("td #title"+id).html(td1);
	                $("td #url"+id).html(td2);
	                $("td #order"+id).html(td3);
	               
	               $("td #change"+id).html("<a href='javascript:change("+id+");' style='cursor:pointer;' >����</a>");
                   }
                   else
                   {
                   alert("����IDΪ "+id+" ��  ��¼ʧ�ܣ������ԣ�/n �������ͣ�"+data); 
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
	$("td #change"+id).html("<a href='javascript:change("+id+");' style='cursor:pointer;' >����</a>");
}
function deleteitem(id)
{
if(confirm("��ȷ��Ҫɾ��  ��¼��")==true)
    {
         $.ajax({ type:"Get",
           url: "DoLibZy.aspx",
           cache: false,
           data:"id="+id+"&act=del",
           success: function(data){
                  if(data=="ok")
                  {                     
                    alert("�ѳɹ�ɾ��IDΪ "+id+" ��  ��¼��"); 
                    $("#tr"+id).remove(); 
                  }
                   else
                   {
                   alert("ɾ��IDΪ "+id+" ��  ��¼ʧ�ܣ������ԣ�/n �������ͣ�"+data); 
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
                    alert("�ѳɹ����  ��¼��"); 
                    location.href="LibZyList.aspx";
                  }
                   else
                   {
                    alert("���ID  ��¼ʧ�ܣ������ԣ�/n �������ͣ�"+data); 
                   }    
           }
        }); 
}
</script>
</div>
</body>
</html>