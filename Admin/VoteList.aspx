<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VoteList.aspx.cs" Inherits="Admin_VoteList" %>

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
      <td style="background-image:url(images/bg.gif); height:27px; text-align:center;"><span class="title" id="vote_title_head" runat="server"></span><br /></td>
    </tr>
    <tr>
      <td valign="top" style=" height:auto;" > 
        <div id="allinfo" style="text-align:left;"><form id="userinfo" action="" method="post" enctype="multipart/form-data" target="_self" runat="server">
        <div class="item">ͶƱ�����޸ģ�<input size="35" name="addtitle" id="myvotetitle" type="text"  value="" />  &nbsp;<input id="Button1" type="button" onclick="changetitle();"  value="�޸�" />&nbsp;</div>
        <div class="item" >
          �����ӵ�ѡ�<input size="35" name="addtitle" id="add_title" type="text"  value="" />
           Ʊ����<input size="5" name="addurl" id="add_url" type="text"  value="" />
           ��ţ�<input size="5" name="orderlist" id="add_orderlist" type="text"  value="0" />
              
            &nbsp;<input id="fsfsf" type="button" onclick="addnew();"  value="���" />&nbsp;
           
           </div>
       
            <asp:Repeater ID="link_list_all" runat="server">
            <HeaderTemplate><table id="sort" style="padding:10px 0px 5px 20px;" width="100%" border="0" cellpadding="0" cellspacing="0">
            <thead><tr><th title="��������" style="width:100px;">ѡ������</th><th title="Ʊ������" style="width:30px;">Ʊ��</th><th title="��ʾ�������"  style="width:30px;">���</th><th style="width:40px;">����</th><th style="width:50px;">ɾ��</th></tr>
            </thead><tbody></HeaderTemplate>
            <ItemTemplate> 
          <tr style="line-height:15px;" id="tr<%# DataBinder.Eval(Container.DataItem,"id") %>"><td id="title<%# DataBinder.Eval(Container.DataItem,"id") %>"><%# DataBinder.Eval(Container.DataItem,"title") %></td>
          
          <td id="url<%# DataBinder.Eval(Container.DataItem,"id") %>"><%# DataBinder.Eval(Container.DataItem,"real_num") %></td>
          
              <td id="order<%# DataBinder.Eval(Container.DataItem,"id") %>"><%# DataBinder.Eval(Container.DataItem,"orderlist") %></td>
              <td id="change<%# DataBinder.Eval(Container.DataItem,"id") %>"><a href="javascript:change(<%# DataBinder.Eval(Container.DataItem,"id") %>);" onclick="" style="cursor:pointer;" >����</a></td>
              <td><a href="javascript:deleteitem(<%# DataBinder.Eval(Container.DataItem,"id") %>);" onclick="" >ɾ��</a></td></tr>
            </ItemTemplate>
            <FooterTemplate><tr><td></td><td></td><td></td><td></td><td></td></tr></tbody></table></FooterTemplate>
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
function changetitle()
{
    if(confirm("��ȷ��Ҫ���Ĵ�ͶƱ������")==true)
    {
        var td1=$("#myvotetitle").val();
	   
      
        $.ajax({ type:"Get",
           url: "DoVote.aspx",
           cache: false,
           data:"title="+escape(td1)+"&act=updatetitle",
           success: function(data){
                  if(data=="ok")
                  {
                     
                    alert("�ѳɹ�����ͶƱ���⣡"); 
                     location.href="VoteList.aspx";
                   }
                   else
                   {
                   alert("����IDΪ ͶƱ���� ʧ�ܣ������ԣ�/n �������ͣ�"+data); 
                   }    
           }
        }); 
    }
}
function change(id)	
{
    var td1=$("td #title"+id).text();
	 var td2=$("td #url"+id).text();
	 var td4=$("td #order"+id).text();
	// alert(td5);
	 $("td #title"+id).html("<input size='30' id='ititle"+id+"' value='"+td1+"' type='text'/><input style='size:0;display:none;' id='htitle"+id+"' value='"+td1+"' type='hidden'/>");
	 $("td #url"+id).html("<input size='5' id='iurl"+id+"' value='"+td2+"' type='text'/><input style='size:0;display:none;' id='hurl"+id+"' value='"+td2+"' type='hidden'/>");
    $("td #order"+id).html("<input size='3' id='iorder"+id+"' value='"+td4+"' type='text'/><input style='size:0;display:none;' id='horder"+id+"' value='"+td4+"' type='hidden'/>");
	$("td #change"+id).html("<a href='javascript:update("+id+");' style='cursor:pointer;color:red;'>�ύ</a>&nbsp;&nbsp;<a href='javascript:cancel("+id+");' style='cursor:pointer;color:red;' >ȡ��</a>");
	//�����صļ�¼��ʼֵ 
}
function update(id)
{
 if(confirm("��ȷ��Ҫ���Ĵ� ѡ�� ��¼��")==true)
    {
        var td1=$("#ititle"+id).val();
	   var td2=$("#iurl"+id).val();
	   var td3=$("#iorder"+id).val();
      
        $.ajax({ type:"Get",
           url: "DoVote.aspx",
           cache: false,
           data:"id="+id+"&title="+escape(td1)+"&num="+escape(td2)+"&orderlist="+escape(td3)+"&act=update",
           success: function(data){
                  if(data=="ok")
                  {
                     
                    alert("�ѳɹ�����IDΪ "+id+" �� ѡ�� ��¼��"); 
                    location.href="VoteList.aspx";
                   }
                   else
                   {
                   alert("����IDΪ "+id+" �� ѡ�� ��¼ʧ�ܣ������ԣ�/n �������ͣ�"+data); 
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
	   $("td #title"+id).html(td1);
	 $("td #url"+id).html(td2);
	  $("td #order"+id).html(td3);
	$("td #change"+id).html("<a href='javascript:change("+id+");' style='cursor:pointer;' >����</a>");
}
function deleteitem(id)
{
if(confirm("��ȷ��Ҫɾ�� ѡ�� ��¼��")==true)
    {
         $.ajax({ type:"Get",
           url: "DoVote.aspx",
           cache: false,
           data:"id="+id+"&act=del",
           success: function(data){
                  if(data=="ok")
                  {                     
                    alert("�ѳɹ�ɾ��IDΪ "+id+" �� ѡ�� ��¼��"); 
                    $("#tr"+id).remove(); 
                  }
                   else
                   {
                   alert("ɾ��IDΪ "+id+" �� ѡ�� ��¼ʧ�ܣ������ԣ�/n �������ͣ�"+data); 
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

     $.ajax({ type:"Get",
           url: "DoVote.aspx",
           cache: false,
           data:"title="+escape(title)+"&num="+escape(url)+"&orderlist="+escape(orderlist)+"&act=add",
           success: function(data){
                  if(data=="ok")
                  {                     
                    alert("�ѳɹ���� ѡ�� ��¼��"); 
                    location.href="VoteList.aspx";
                  }
                   else
                   {
                    alert("���ID ѡ�� ��¼ʧ�ܣ������ԣ�/n �������ͣ�"+data); 
                   }    
           }
        }); 
}
</script>
</div>
</body>
</html>