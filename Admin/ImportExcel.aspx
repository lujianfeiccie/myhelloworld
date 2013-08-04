<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportExcel.aspx.cs" Inherits="Admin_ImportExcel" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
        <link href="Css/bodystyle.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>

</head>
<body>
<div align="center" style="height:100%;">
    
  <table width="100%" align="center" cellpadding="0" cellspacing="0">
    <tr background="images/bg.gif">
      <td height="27" align="middle" background="images/bg.gif"><div align="center"><span class="title"><strong><label id="title" runat="server"></label></strong></span><br>
      </div></td>
    </tr>
    <tr><td><div id="result" runat="server" style="color:Red;"></div></td></tr>
    <tr>
      <td valign="top" align="left"> 
         <form action="" method="post" enctype="multipart/form-data" runat="server" id="slfslf">
             <asp:FileUpload ID="FileUpload1" runat="server" Width="533px" />
             <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="导入数据" /></form>
          
     </td>
    </tr>
  </table>

<br /><br />
</div></body>
</html>