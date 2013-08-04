<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>

    <title>管理登陆</title>
<style type="text/css">
body{ width:450px;
    height:550px;
     margin-left:auto;
     margin-right:auto;
    FONT-SIZE: 12px; FONT-FAMILY: Tahoma;	
}
TD {
	FONT-SIZE: 12px; FONT-FAMILY: Tahoma
}
A:link {
	COLOR: #636363; TEXT-DECORATION: none
}
A:visited {
	COLOR: #838383; TEXT-DECORATION: none
}
A:hover {
	COLOR: #a3a3a3; TEXT-DECORATION: underline
}
BODY {
	BACKGROUND-COLOR: #cccccc
}
  .code  
        {  
            background-image:url(images/search_info_guid_off.gif);  
            font-family:Arial;  
            font-style:italic;  
            color:Red;  
            border:0;  
            padding:2px 3px;  
            letter-spacing:3px;  
            font-weight:bolder;  
        }  
        .unchanged  
        {  
            border:0;  
        }  
</style>
<script type="text/javascript" language="javascript">
//判断输入是否合法
<!--
function check()
{
//判断用户名
	if(window.document.myform1.username.value=="")
		{
			alert("请输入你的用户名！");
			document.myform1.username.focus();
			return false;
		}
	
	//判断密码
	if(window.document.myform1.userpsw.value=="")
		{
			alert("请输入你的密码！");
			document.myform1.userpsw.focus();
			return false;
		}
	if(!validate())
	    return false;
	
	return true;
		
	}
	var code ; //在全局 定义验证码  
     function createCode()  
     {   
       code = "";  
       var codeLength = 5;//验证码的长度  
       var checkCode = document.getElementById("checkCode");  
       var selectChar = new Array(0,1,2,3,4,5,6,7,8,9,'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z');// 所有候选组成验证码的字符，当然也可以用中文的     
       for(var i=0;i<codeLength;i++)  
       {  
        var charIndex = Math.floor(Math.random()*36);  
        code +=selectChar[charIndex];  
       }   
       if(checkCode)  
       {  
         checkCode.className="code";  
         checkCode.value = code;
         checkCode.blur();  
       }       
     }    
     function validate ()   {  
       var inputCode = document.getElementById("validCode").value;  
       if(inputCode.length <=0)  
       {  
           alert("请输入验证码！");  
           return false;
       }  
       else if(inputCode.toUpperCase() != code )  
       {  
          alert("验证码输入错误！");  
          createCode();//刷新验证码  
          return false;
       }  
       else  
       {  
            return true;
       } 
       } 
//-->	
</script>
</head>
<body style="TABLE-LAYOUT: fixed; WORD-BREAK: break-all" topMargin=10 
marginwidth="10" marginheight="10" onload="createCode()">
<TABLE height="95%" cellSpacing=0 cellPadding=0 width="100%" align=center 
border=0>
  <TBODY>
  <TR vAlign=center align=middle>
    <TD>
      <TABLE cellSpacing=0 cellPadding=0 width=468 bgColor=#ffffff border=0>
        <TBODY>
        <TR>
          <TD width=20 background="images/rbox_1.gif" 
height=20></TD>
          <TD width=108 background="images/rbox_2.gif" 
          height=20></TD>
          <TD width=56><IMG height=20 src="images/rbox_ring.gif" 
            width=56></TD>
          <TD width=100 background="images/rbox_2.gif"></TD>
          <TD width=56><IMG height=20 src="images/rbox_ring.gif" 
            width=56></TD>
          <TD width=108 background="images/rbox_2.gif"></TD>
          <TD width=20 background="images/rbox_3.gif" 
        height=20></TD></TR>
        <TR>
          <TD align=left background="images/rbox_4.gif" 
          rowSpan=2></TD>
          <TD align=middle bgColor=#eeeeee colSpan=5 height=50>
            <P><strong>&nbsp;&nbsp;<% =loginfo %>
                <br>
              <br>
            </strong></P></TD>
          <TD align=left background="images/rbox_6.gif" 
          rowSpan=2></TD></TR>
        <TR valign="middle">
          <TD colSpan=5 align=left valign="center" style="height: 129px">
           <form action="Default.aspx?action=login" method="post"  id="myform1" name="myform1" target="_self">
              <table width="426" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="145" align="right">用户名：</td>
                  <td colspan="2"><input name="username" type="text" id="username" style="width:140px;" maxlength="28"></td>
                </tr>
                <tr>
                  <td align="right">密码：</td>
                  <td colspan="2"><input name="userpsw" type="password" id="userpsw" style="width:140px;" maxlength="28"></td>
                  </tr>
                <tr>
                <tr>
                  <td align="right">验证码：</td>
                  <td colspan="2"><input  type="text"   id="validCode" style="width:70px;" /> 
    <input type="text" onclick="createCode()" readonly="readonly" id="checkCode" class="unchanged" style="width:60px;cursor:pointer"  /></td>
                  </tr>
                <tr>
                  <td>&nbsp;</td>
                  <td width="62"><input type="submit" name="Submit" value="登录" size="10" onClick="return check();"></td>
                  <td width="219"><input type="reset" name="reset" value="重置" size="10" ></td>
                </tr>
                <tr>
                  <td colspan="3">&nbsp;</td>
                </tr>
                <tr>
                  <td colspan="3" style="height: 14px">&nbsp;</td>
                </tr>
              </table>
                </form>
           <DIV align=right><BR>
            All copyright reserved. </DIV></TD></TR>
        <TR>
          <TD align=left background="images/rbox_7.gif" 
          height=20></TD>
          <TD align=left background="images/rbox_8.gif" colSpan=5 
          height=20></TD>
          <TD align=left background="images/rbox_9.gif" 
          height=20></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></body>
</html>
