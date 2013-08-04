<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PubNews.aspx.cs" Inherits="Admin_PubNews" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
        <link href="Css/bodystyle.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>

</head>
<body>
<div align="center" style="height:100%;">
    
  <table width="100%"  style="height:100%;" align="center" cellpadding="0" cellspacing="0">
    <tr background="images/bg.gif">
      <td height="27" align="middle" background="images/bg.gif"><div align="center"><span class="title"><strong><label id="title" runat="server"></label></strong></span><br>
      </div></td>
    </tr>
    <tr>
      <td valign="top" align="left"> 
         <form action="" method="post" enctype="multipart/form-data" runat="server" id="slfslf">
            <div class="item">标&nbsp;&nbsp;&nbsp;&nbsp;题<asp:TextBox  Width="300px" ID="newstitle" runat="server"></asp:TextBox>置顶<asp:CheckBox   ID="istop" runat="server" /></div>
           <div class="item">序&nbsp;&nbsp;&nbsp;&nbsp;号<asp:TextBox  Width="50px" ID="orderlist" runat="server" Text="0"></asp:TextBox>数字序号，默认0，越大越靠前</div>
          <%if(newstypeh=="news"){ %>  <div class="item">缩略图<asp:FileUpload Width="300px"  runat="server" ID="headpic" /></div><%} %>
            <div class="item">内容：<FCKeditorV2:FCKeditor   ID="info" runat="server"   Height="400"  Value="文章内容" Width="800"></FCKeditorV2:FCKeditor>
                &nbsp;
            </div>
            <div class="item" style="padding-left:50px;">
                <input id="Submit1" type="submit" value="发布" style="margin-right:50px; width:40px;" />
                 <input id="Submit2" type="reset" value="重置" />
                </div>
            
         </form>
          
     </td>
    </tr>
  </table>

<br /><br />
</div></body>
</html>
