<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PubBook.aspx.cs" Inherits="Admin_PubBook" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>


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
    
  <table width="100%"  style="height:100%;" align="center" cellpadding="0" cellspacing="0">
    <tr background="images/bg.gif">
      <td height="27" align="middle" background="images/bg.gif"><div align="center"><span class="title"><strong><label id="title" runat="server"></label></strong></span><br>
      </div></td>
    </tr>
    <tr>
      <td valign="top" align="left"> 
         <form action="" method="post" enctype="multipart/form-data" runat="server" id="slfslf">
            <div class="item">书&nbsp;&nbsp;&nbsp;&nbsp;名<asp:TextBox  Width="438px" ID="newstitle" runat="server"></asp:TextBox>推荐<asp:CheckBox   ID="istop" runat="server" /></div>
           <div class="item">作&nbsp;&nbsp;&nbsp;&nbsp;者<asp:TextBox  Width="105px" ID="author" runat="server"></asp:TextBox>出版社<asp:TextBox
               ID="publisher" runat="server" Width="149px"></asp:TextBox>
               出版时间<asp:TextBox ID="pubtime"  runat="server" Width="162px"></asp:TextBox></div>
               <div class="item">&nbsp;&nbsp;&nbsp;&nbsp;ISBN<asp:TextBox  Width="162px" ID="ISBN" runat="server"></asp:TextBox>类别<asp:TextBox
               ID="typename" runat="server" Width="243px"></asp:TextBox><asp:DropDownList ID="types" runat="server">
               </asp:DropDownList>(快速选择)</div>
              <div class="item">馆藏数量<asp:TextBox  Width="105px" ID="num1" runat="server" Text="0"></asp:TextBox>可借数量<asp:TextBox
               ID="num2" runat="server" Width="149px" Text="0"></asp:TextBox></div>
            <div class="item">缩略图<asp:FileUpload Width="300px"  runat="server" ID="headpic" /></div>
            <div class="item">内容：<FCKeditorV2:FCKeditor   ID="info" runat="server"   Height="400"  Value="图书描述" Width="800"></FCKeditorV2:FCKeditor>
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
<script language="javascript" type="text/javascript">
$("#types").click(
function() {
  $("#typename").val($(this).val());
  
  } );

$("#pubtime").click(
    function(){
    WdatePicker({el:$dp.$('pubtime'),skin:'blue',minDate:'1900-09-10',maxDate:'%y-%M-%d'});
    }
);
</script>
<br /><br />
</div></body>
</html>