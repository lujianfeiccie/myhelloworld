<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PDFShow.aspx.cs" Inherits="PDFShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <script language="javascript" type="text/javascript">
        function isAcrobatPluginInstall() { 
             var flag = false; 
             // 如果是firefox浏览器 
             if (navigator.plugins && navigator.plugins.length) { 
                 for (x = 0; x < navigator.plugins.length; x++) {
                     if (navigator.plugins[x].name == 'Adobe Acrobat') 
                     flag = true; 
                 } 
             } 
             // 下面代码都是处理IE浏览器的情况 
             else if (window.ActiveXObject) { 
                 for (x = 2; x < 10; x++) 
                 { 
                     try 
                     { 
                         oAcro = eval("new ActiveXObject('PDF.PdfCtrl." + x + "');"); 
                         if (oAcro) { 
                         flag = true; 
                         } 
                     } catch (e) 
                     { 
                     flag = false; 
                     } 
                 } 
             try 
             { 
                 oAcro4 = new ActiveXObject('PDF.PdfCtrl.1'); 
                 if (oAcro4) 
                 flag = true; 
                 } catch (e) { 
                 flag = false; 
                 } 
                 try { 
                 oAcro7 = new ActiveXObject('AcroPDF.PDF.1'); 
                 if (oAcro7) 
                     flag = true; 
              }catch (e) { 
                 flag = false; 
                } 
             } 
             if (flag) { 
                return true;

             } else { 
                // alert("对不起,您还没有安装PDF阅读器软件呢,为了方便预览PDF文档,请选择安装！"); 
                // location = 'http://ardownload.adobe.com/pub/adobe/reader/win/9.x/9.3/chs/AdbeRdr930_zh_CN.exe'; 
                 document.write("<div style='width:100%;text-align:center;margin-top:25px;'><font style='color:red;font-size:14px;font-weight:bold;'>您还没有安装Adobe Acrobat Reader, 无法在线阅读PDF！</font><br/><span>[<a href='http://202.114.34.9/UploadFiles/AdbeRdr70.exe'>点击下载Adobe Acrobat Reader</a>]</span></div>");
             } 
         return flag; 
         }
    </script>
</head>
<body onload="isAcrobatPluginInstall()">
    <form id="form1" runat="server">
    </form>
</body>
</html>
