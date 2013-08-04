<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LibInfoSet.aspx.cs" Inherits="Admin_LibInfoSet" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="Css/bodystyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div align="center" style="height:100%;">
    
  <table width="100%"  style="" align="center" cellpadding="0" cellspacing="0">
    <tr background="images/bg.gif">
      <td height="27" align="middle" background="images/bg.gif"><div align="center"><span class="title"><strong><%=result[0] %>----信息设置</strong></span><br>
      </div></td>
    </tr>
    <tr>
      <td valign="top" align="left" style="height: 43px"> 
          <form id="webinfo" runat="server" method="post" action="" style="padding-left:30px; padding-top:20px;">
              <div >标题：<asp:TextBox ID="title" runat="server" Width="700px"></asp:TextBox></div>
              <FCKeditorV2:FCKeditor ID="FCKeditor1" Width="750" Height="500" runat="server">
              </FCKeditorV2:FCKeditor><br />
              &nbsp;<input type="submit" value="更改" />
          </form>
     </td>
    </tr>
  </table>

<br /><br />
</div>
</body>
</html>

