<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebSet.aspx.cs" Inherits="Admin_WebSet" %>
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
      <td height="27" align="middle" background="images/bg.gif"><div align="center"><span class="title"><strong>网站功能设置</strong></span><br>
      </div></td>
    </tr>
    <tr>
      <td valign="top" align="left" style="height: 43px"> 
          <form id="webinfo" runat="server" method="post" action="" style="padding-left:30px; padding-top:20px;">
            网站名称：<asp:TextBox ID="title"  runat="server" Width="500px"></asp:TextBox><br />
            &nbsp;&nbsp;&nbsp;&nbsp;关键词：<asp:TextBox ID="keyword"  runat="server" Width="500px"></asp:TextBox><br />
            网站描述：<asp:TextBox ID="description" runat="server" Height="183px" Width="500px"></asp:TextBox><br />
            访问总量：<asp:TextBox ID="count"  runat="server" Width="235px"></asp:TextBox>
            当前在线：<asp:TextBox ID="online"  runat="server" Width="145px"></asp:TextBox>
              <input type="submit" value="更改" />
          </form>
     </td>
    </tr>
  </table>

<br /><br />
</div>
</body>
</html>
