<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminList.aspx.cs" Inherits="Admin_AdminList" %>

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
      <td style="background-image:url(images/bg.gif); height:27px; text-align:center;"><span class="title"><strong>����Ա����</strong></span><br /></td>
    </tr>
    <tr>
      <td valign="top" style=" height:auto;" > 
        <div id="allinfo" style="text-align:left;"><form id="userinfo" action="" method="post" enctype="multipart/form-data" target="_self" runat="server">
        
       
            <asp:Repeater ID="admin_list" runat="server">
            <HeaderTemplate><table id="sort" style="padding:10px 0px 5px 20px;" width="100%" border="0" cellpadding="0" cellspacing="0">
            <thead><tr><th title="��������" style="width:50px;">�û���</th><th title="��ַ����" style="width:50px;">����</th><th>����</th><th>֪ͨ</th><th>ͶƱ</th><th>����</th><th>�û�</th><th>����</th><th>����</th><th>����</th><th>����</th><th>��ѯ</th><th>��Դ</th><th>ϵͳ</th><th>����</th><th >ɾ��/��Ϊ��ͨ</th></tr>
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
            <td><input id="adddfdfs" type="button" value="����" onclick="addadmin('0');" /></td>
            
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
                
              <td><a href="javascript:update('<%# DataBinder.Eval(Container.DataItem,"username") %>');" onclick="" style="cursor:pointer;" >����</a></td>
              <td><a href="javascript:deleteitem('<%# DataBinder.Eval(Container.DataItem,"username") %>');" onclick="" >ɾ��</a>&nbsp;&nbsp;<a href="javascript:deleteitem2('<%# DataBinder.Eval(Container.DataItem,"username") %>');" onclick="" >��Ϊ��ͨ</a></td></tr>
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
 if(confirm("��ȷ��Ҫ���� "+id+" ���û���Ȩ����")==true)
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
                     
                    alert("�ѳɹ����� "+id+" �û���  ��¼��"); 
                    
                   }
                   else
                   {
                   alert("���� "+id+" �û���  ��¼ʧ�ܣ������ԣ�/n �������ͣ�"+data); 
                   }    
           }
        }); 
    }

}

function deleteitem(id)
{
if(confirm("��ȷ��Ҫ����ɾ�� "+id+" �û��ļ�¼(������ͨ�û�Ҳɾ��)�𣿴˲��������ɻָ���")==true)
    {
        
         $.ajax({ type:"Get",
           url: "DoUser.aspx",
           cache: false,
           data:"ids="+id+"&act=del",
           success: function(data){
                  if(data=="ok")
                  {                     
                    alert("�ѳɹ�ɾ�� "+id+" �û���  ��¼��"); 
                    $("#tr"+id).remove(); 
                  }
                   else
                   {
                   alert("ɾ�� "+id+" �û���  ��¼ʧ�ܣ������ԣ�/n �������ͣ�"+data); 
                   }    
           }
        }); 
    }
}
function deleteitem2(id)
{
        if(confirm("��ȷ��Ҫ���û� "+id+" ��Ϊ��ͨ�û���")==true)
    {
        
         $.ajax({ type:"Get",
           url: "DoUser.aspx",
           cache: false,
           data:"ids="+id+"&act=settype&usertype=putong",
           success: function(data){
                  if(data=="ok")
                  {                     
                    alert("�ѳɹ����� "+id+" �û���  ��¼��"); 
                    $("#tr"+id).remove(); 
                  }
                   else
                   {
                   alert("���� "+id+" �û���  ��¼ʧ�ܣ������ԣ�/n �������ͣ�"+data); 
                   }    
           }
        }); 
    }

}
function addadmin(id)
{
 var username=$("#name"+id).val();
 var psw=$("#psw"+id).val();
if(psw!=""&&username!=""&&confirm("��ȷ��Ҫ���Ӹù���Ա��")==true)
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
                     
                    alert("�ѳɹ����ӹ���Ա ��¼��"); 
                    location.href="AdminList.aspx";
                    
                   }
                   else
                   {
                   alert("���ӹ���Ա ��¼ʧ�ܣ������ԣ�/n �������ͣ�"+data); 
                   }    
           }
        }); 
    }
}
</script>
</div>
</body>
</html>