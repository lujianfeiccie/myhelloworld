<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="NewsList" Title="Untitled Page" %>
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
      <td style="background-image:url(images/bg.gif); height:27px; text-align:center;"><span class="title" id="list_title" runat="server"></span><br /></td>
    </tr>
    <tr>
      <td valign="top" style=" height:auto;" > 
        <div id="allinfo" style="text-align:left;"><form id="userinfo" action="" method="post" enctype="multipart/form-data" target="_self" runat="server">
        <div class="item" style="display:none;">
          ���⣺<input size="50" name="title" id="title" type="text"  value="" />
           
               &nbsp;���״̬��<select id="ischeck" name="ischeck">
             <option value="" selected="selected">����</option>
             <option value="1">����</option>
             <option value="0">����</option>
             </select>
            &nbsp;<input id="Submit1" type="submit"  value="��ѯ" />&nbsp;<input type="hidden" runat="server" name="horder" id="horder" />
           <label style="display:none;"  runat="server" id="hcon"></label>
           </div>
       
            <asp:Repeater ID="news_list_all" runat="server">
            <HeaderTemplate><table id="sort" style="padding:10px 0px 5px 20px;" width="100%" border="0" cellpadding="0" cellspacing="0">
            <thead><tr><th title="��������ǩ������" style="width:120px;">����</th><th title="������ʹ�ô�������" style="width:60px;">����ʱ��</th><th title="���������ʴ�������"  style="width:60px;">������</th><th style="width:80px;">���/����</th><th style="width:80px;">����</th><th style="width:50px;">ɾ��</th></tr>
            </thead><tbody></HeaderTemplate>
            <ItemTemplate> 
          <tr style="line-height:15px;" id="tr<%# DataBinder.Eval(Container.DataItem,"id") %>"><td id="title<%# DataBinder.Eval(Container.DataItem,"id") %>"><input type="checkbox" value="<%# DataBinder.Eval(Container.DataItem,"id") %>" name="choosecheck" /><a href="../NewsView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id") %>" target="_blank"><%# DataBinder.Eval(Container.DataItem,"title") %></a>  </td>
          
          <td id="times<%# DataBinder.Eval(Container.DataItem,"id") %>"><%# DataBinder.Eval(Container.DataItem,"pub_time") %></td>
          <td id="use<%# DataBinder.Eval(Container.DataItem,"id") %>"><%# DataBinder.Eval(Container.DataItem,"pub_user") %></td>
              <td id="check<%# DataBinder.Eval(Container.DataItem,"id") %>"><a href="#"  style="cursor:pointer;" onclick="checkbox('<%# DataBinder.Eval(Container.DataItem,"id") %>','<%# DataBinder.Eval(Container.DataItem,"ischeck") %>');"><img height="18" title="����������/�������" style="border:none;" src="images/check<%# DataBinder.Eval(Container.DataItem,"ischeck") %>.gif" /></a></td>
              <td id="change<%# DataBinder.Eval(Container.DataItem,"id") %>"><a href="pubnews.aspx?act=edit&type=<%# DataBinder.Eval(Container.DataItem,"news_type") %>&id=<%# DataBinder.Eval(Container.DataItem,"id") %>"  style="cursor:pointer;" >����</a></td>
              <td><a href="pubnews.aspx?act=delete&type=<%# DataBinder.Eval(Container.DataItem,"news_type") %>&id=<%# DataBinder.Eval(Container.DataItem,"id") %>" >ɾ��</a></td></tr>
            </ItemTemplate>
            <FooterTemplate><tr><td></td><td></td><td></td><td></td><td></td><td></td></tr></tbody></table></FooterTemplate>
            </asp:Repeater>
         </form>   
        </div>
     </td>
    </tr>
  </table>
<ucl:pagelist ID="mypagenum" runat="server" />

<div>������ѡ��/��ѡ�����У�<input type="checkbox" onclick="chooseit();" />
&nbsp;���ĳ�״̬<select style="width:80px;" id="shenhe" name="shenhe"><option value="1">����</option>
             <option value="0">����</option></select>
    &nbsp;&nbsp;<input type="button" onclick="checkall();" value="���/����" />&nbsp;&nbsp;<input onclick="delall();" type="button" value="ִ��ɾ��" />
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
function delall() //ɾ������
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
        alert("��ѡ��");
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
function checkbox(id,type)
{
    var jumpurl=$("#jumpurl").val();
    var news_type=$("#news_type").val();
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
    if(confirm("��ȷ��Ҫ "+change+" IDΪ "+id+" �� ��ǩ ��¼��")==true)
    {
         $.ajax({ type:"Get",
           url: "EditNews.aspx",
           cache: false,
           data:"ids="+id+"&act=check&state="+ischeck+"&newstype="+news_type,
           success: function(data){
                  if(data=="ok")
                  {                     
                    alert("�ѳɹ� "+change+" IDΪ "+id+" �� ��ǩ ��¼��"); 
                     location.href=jumpurl;
                  }
                   else
                   {
                   alert(change+" IDΪ "+id+" �� ��ǩ ��¼ʧ�ܣ������ԣ�/n �������ͣ�"+data); 
                   }    
           }
        }); 
    }
}	
function checkall() //��˻�������
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
        alert("��ѡ��");
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