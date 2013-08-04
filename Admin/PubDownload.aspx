<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PubDownload.aspx.cs" Inherits="Admin_PubDownload" %>
<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload"    TagPrefix="Upload" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
        <link href="Css/bodystyle.css" rel="stylesheet" type="text/css" />

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
         <form action="" method="post" enctype="multipart/form-data" runat="server" id="start">
            <div class="item">软件名称<asp:TextBox  Width="438px" ID="newstitle" runat="server"></asp:TextBox>审核<asp:CheckBox   ID="ischeck" runat="server" /></div>
           <div class="item">
               &nbsp;&nbsp;发布商<asp:TextBox  Width="161px" ID="author" runat="server"></asp:TextBox>软件性质<asp:TextBox
               ID="xingzhi" runat="server" Width="217px"></asp:TextBox>
               软件语言<asp:TextBox ID="language" runat="server" Width="162px"></asp:TextBox></div>
               <div class="item">运行平台<asp:TextBox  Width="162px" ID="platform" runat="server"></asp:TextBox>类别<asp:TextBox
               ID="typename" runat="server" Width="238px"></asp:TextBox><asp:DropDownList ID="types" runat="server">
               </asp:DropDownList>(快速选择)</div>
              <div class="item">
                  &nbsp;&nbsp;访问量<asp:TextBox  Width="56px" ID="num1" runat="server" Text="0"></asp:TextBox>下载量<asp:TextBox
               ID="num2" runat="server" Width="64px" Text="0"></asp:TextBox>软件等级<asp:DropDownList
                   ID="rank" runat="server">
               </asp:DropDownList></div>
            <div class="item">
                &nbsp;&nbsp;缩略图<asp:FileUpload Width="444px"  runat="server" ID="headpic" /></div>
                 <div class="item">
                &nbsp; &nbsp; 文件<Upload:InputFile ID="DownloadFile" runat="server" Width="442px" /><asp:RegularExpressionValidator Enabled="false" id="RegularExpressionValidator1" 
				ControlToValidate="DownloadFile"
				ValidationExpression=".*([^e]|[^x]e|[^e]xe|[^.]exe)$"
				Display="Static"
				ErrorMessage="不要上传非法格式"
				EnableClientScript="True" 
				runat="server"/>
                 </div>
            <div class="item">内容： &nbsp;<FCKeditorV2:FCKeditor   ID="info" runat="server"   Height="400"  Value="图书描述" Width="800"></FCKeditorV2:FCKeditor>
                &nbsp;
            </div>
            <div class="item" style="padding-left:50px;">
                 &nbsp; &nbsp;  &nbsp; &nbsp; <asp:Button ID="Button1" runat="server" Text="提交资源信息"  OnClientClick="uploadmyfile2()" OnClick="Button1_Click" />
                 <input id="Submit2" type="reset" value="重置" />
                </div>
            
         </form>
                <div id="waiting" style="z-index:3; left:6%;display:none;width:550px;position: absolute; top:250px;">
                        <img src="Images/progress.gif" />正在上传，请稍后.....<br />
                    <Upload:ProgressBar ID="ProgressBar1" runat='server' Triggers="Button1" Inline="true">
                    </Upload:ProgressBar>
                </div>
          
     </td>
    </tr>
  </table>
<script language="javascript" type="text/javascript">
$("#types").click(
function() {
  $("#typename").val($(this).val());
  
  } );
 function uploadmyfile2(){
        $('#waiting').fadeIn('slow');
      $("#start").hide();
}
</script>
<br /><br />
</div></body>
</html>