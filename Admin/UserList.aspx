<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="Admin_UserList" %>
<%@ Register Src="~/Contrl/PageNum.ascx" TagName="pagelist" TagPrefix="ucl" %>

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
      <td style="background-image:url(images/bg.gif); height:27px; text-align:center;"><span class="title" id="list_title"><strong>�û��б�</strong></span><br /></td>
    </tr>
    <tr>
      <td valign="top" style=" height:auto;" > 
        <div id="allinfo" style="text-align:left;"><form id="userinfo" action="" method="post" enctype="multipart/form-data" target="_self" runat="server">
        <div class="item">
          ���⣺<input size="50" name="title" id="title" type="text" runat="server" />
           
            &nbsp;<input id="Submit1" type="submit"  value="��ѯ" />&nbsp;<input type="hidden" runat="server" name="horder" id="horder" />
           <label style="display:none;"  runat="server" id="hcon"></label>
           </div>
       
            <asp:Repeater ID="news_list_all" runat="server">
            <HeaderTemplate><table id="sort" style="padding:10px 0px 5px 20px;" width="100%" border="0" cellpadding="0" cellspacing="0">
            <thead><tr><th title="��������ǩ������" style="width:80px;">�û���</th><th title="���" style="width:80px;">��������</th><th title="�ļ���" style="width:60px;">����</th><th title="�ļ���" style="width:60px;">ע��ʱ��</th><th title="�ļ���" style="width:60px;">��½����</th><th title="����ʱ������" style="width:120px;">�ϴε�¼</th><th style="width:80px;">��˲���</th><th style="width:80px;">����</th><th style="width:50px;">ɾ��</th></tr>
            </thead><tbody></HeaderTemplate>
            <ItemTemplate> 
          <tr style="line-height:15px;" id="tr<%# DataBinder.Eval(Container.DataItem,"username") %>"><td id="title<%# DataBinder.Eval(Container.DataItem,"username") %>"><input type="checkbox" value="<%# DataBinder.Eval(Container.DataItem,"username") %>" name="choosecheck" /><span><%# DataBinder.Eval(Container.DataItem,"username") %> </span></td>
           <td id="type<%# DataBinder.Eval(Container.DataItem,"username") %>"><%# DataBinder.Eval(Container.DataItem,"userid") %></td>
           <td id="use<%# DataBinder.Eval(Container.DataItem,"username") %>"><%# DataBinder.Eval(Container.DataItem,"password") %></td>
           
           <td id="reg<%# DataBinder.Eval(Container.DataItem,"username") %>"><%# DataBinder.Eval(Container.DataItem,"reg_time") %></td>
           <td id="times<%# DataBinder.Eval(Container.DataItem,"username") %>"><%# DataBinder.Eval(Container.DataItem,"login_times") %></td>
           <td id="last<%# DataBinder.Eval(Container.DataItem,"username") %>"><%# DataBinder.Eval(Container.DataItem,"last_time") %>/<%# DataBinder.Eval(Container.DataItem,"last_ip") %></td>
          
          
          
              <td id="check<%# DataBinder.Eval(Container.DataItem,"username") %>"><a href="#"  style="cursor:pointer;" onclick="checkbox('<%# DataBinder.Eval(Container.DataItem,"username") %>','<%# DataBinder.Eval(Container.DataItem,"ischeck") %>','check');"><img   title="���������˲���" style="border:none;" src="images/check<%# DataBinder.Eval(Container.DataItem,"ischeck") %>.gif" /></a></td>
              <td id="change<%# DataBinder.Eval(Container.DataItem,"username") %>"><a  href="EditUser.aspx?user=<%# DataBinder.Eval(Container.DataItem,"username") %>"   style="cursor:pointer;" >����</a></td>
              <td><a href="#" onclick="deletebox('<%# DataBinder.Eval(Container.DataItem,"username") %>');" >ɾ��</a></td></tr>
            </ItemTemplate>
            <FooterTemplate><tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr></tbody></table></FooterTemplate>
            </asp:Repeater>
         </form>   
        </div>
     </td>
    </tr>
  </table>
<ucl:pagelist ID="mypagenum" runat="server" />

<div>������ѡ��/��ѡ�����У�<input type="checkbox" onclick="chooseit();" />
&nbsp;���ĳ�״̬<select style="width:80px;" id="shenhe" name="shenhe"><option value="1">���</option>
             <option value="0">����</option></select>
    &nbsp;&nbsp;<input type="button" onclick="checkall('check');" value="���/����" />&nbsp;&nbsp;
   <input onclick="delall();" type="button" value="ִ��ɾ��" />
  <%if (isadmin)
    { %> <input onclick="setadmin();" type="button" value="��Ϊ����Ա" /><%} %>
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
        alert("��ѡ��");
        return;
    }
    else
    {
     if(confirm("��ȷ��Ҫ ��������Ϊ����Ա ��")==true)
     {
             $.ajax({ type:"Get",
               url: "DoUser.aspx",
               cache: false,
               data:"ids="+str+"&act=settype&usertype=gly",
               success: function(data){
                      if(data=="ok")
                      {                     
                        alert("�ѳɹ����ã�"); 
                        $("[name='choosecheck'][checked]").each(function()
                        {
                             //str+=$(this).val()+",";
                             $("#tr"+$(this).val()).remove(); 
                        });
                        
                      }
                       else
                       {
                        alert("���ü�¼ʧ�ܣ������ԣ�/n �������ͣ�"+data); 
                       }    
               }
            }); 
        }
      }
}
function delall() //ɾ������
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
        alert("��ѡ��");
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
                    alert("�ѳɹ�ɾ����¼��"); 
                    $("[name='choosecheck'][checked]").each(function()
                    {
                         //str+=$(this).val()+",";
                         $("#tr"+$(this).val()).remove(); 
                    });
                    
                  }
                   else
                   {
                    alert("ɾ����¼ʧ�ܣ������ԣ�/n �������ͣ�"+data); 
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
            change="����";
            ischeck=0;
            
        }
    else
    {
        change="���";
        ischeck=1;
       
    }
    if(confirm("��ȷ��Ҫ "+change+" IDΪ "+id+" ��  ��¼��")==true)
    {
         $.ajax({ type:"Get",
           url: "DoUser.aspx",
           cache: false,
           data:"ids="+id+"&act="+caozuo+"&state="+ischeck,
           success: function(data){
                  if(data=="ok")
                  {                     
                    alert("�ѳɹ� "+change+" IDΪ "+id+" ��  ��¼��"); 
                     location.href=jumpurl;
                  }
                   else
                   {
                   alert(change+" IDΪ "+id+" ��  ��¼ʧ�ܣ������ԣ�/n �������ͣ�"+data); 
                   }    
           }
        }); 
    }
}	
function checkall(type) //��˻�������
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
        alert("��ѡ��");
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
                       
                    alert("�ѳɹ�������¼��"); 
                    location.href=jumpurl;
                    
                   
                    
                  }
                   else
                   {
                    alert("������¼ʧ�ܣ������ԣ�/n �������ͣ�"+data); 
                   }    
           }
        }); 
      }
}

</script>
</body>

</html>