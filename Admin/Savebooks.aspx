<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Savebooks.aspx.cs" Inherits="Admin_Savebooks" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
        <link href="Css/bodystyle.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="../Calendar/WdatePicker.js"></script>
        <script type="text/javascript" language="javascript" src="../JS/jquery.js"></script>

</head>
<body>
<div align="center" style="height:100%;">
    
  <table width="100%" align="center" cellpadding="0" cellspacing="0">
    <tr background="images/bg.gif">
      <td height="27" align="middle" background="images/bg.gif"><div align="center"><span class="title"><strong><label id="title" runat="server"></label></strong></span><br>
      </div></td>
    </tr>
    <tr>
      <td valign="top" align="left" style="height: 341px"> 
         <form action="" method="post"  runat="server" id="slfslf">
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <div style=" padding-left:50px; color:Red;">
               <asp:Label ID="Label1" runat="server" Text=" 确定要备份所有的新书列表么？"></asp:Label>
                 <asp:Button ID="Button1" runat="server" Text="我要备份" OnClick="Button1_Click" />
             </div>
             
             
             
             
             
             &nbsp;</form>
          
     </td>
    </tr>
  </table>

<br /><br />
</div></body>
</html>