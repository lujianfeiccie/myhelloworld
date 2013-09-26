<%@ Page Language="C#" MasterPageFile="~/AllPage2.master" AutoEventWireup="true" CodeFile="Statistic.aspx.cs" Inherits="Statistic" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="Calendar/WdatePicker.js" type="text/javascript"></script>

<style type="text/css">  
           table {  
            border: 1px solid #B1CDE3;  
            background: #fff;    
            padding:0;   
            margin:0 auto;  
            border-collapse: collapse;  
			
        }  
        th {
			font-size:20px;  
			text-align:center;
				 border: 1px solid #B1CDE3;  
		}
		.header{
			 background: #246cd2; 
			 color:#fff
		}
        td {  
			text-align:center;
            border: 1px solid #B1CDE3;  
            background: #fff;  
            font-size:20px;  
            padding: 3px 3px 3px 3px;  
            color: #4f6b72;  
			width:200px;
			
        } 
		.divclass{
			width:620px;
			text-align:center;
			padding: 3px 3px 3px 3px; 
			height:30px;
			background: #fff; 
		}
		.divclass_header{
			font-size:20px;  
			font-weight:700;
			color:#fff;
		    width:620px;
			text-align:center;
			padding: 3px 3px 3px 3px; 
			height:30px;
			margin-top:20px;
			background: #246cd2; 
			
		}
		.table2{
		    width:620px;
		    margin-top:20px;
		}
		.table2 td{
		  font-size:20px;  
		  width:690px;
		}
</style>

<form id="form1" runat="server">
<table border="1">
<tr>
<th class="header" colspan= "3">访问使用统计</th>
</tr>
<tr>
  <th>栏目</th>
  <th>当月</th>
  <th>总访问量</th>
</tr>
<tr>
  <td>纸质图书借阅</td>
  <td><asp:Label ID="month_paper" runat="server"/></td>
  <td><asp:Label ID="total_paper" runat="server"/></td>
</tr>
<tr>
  <td>数字资源月点击率</td>
  <td><asp:Label ID="month_digital" runat="server"/></td>
  <td><asp:Label ID="total_digital" runat="server"/></td>
</tr>
</table>

<table class="table2">
<tr>
<th colspan="2" class="header">
按时间段查询
</th>
</tr>
<tr>
<td>开始:<input id="txt_starttime" type="text" value="" onclick="WdatePicker()" runat="server"/></td> <td>结束:<input id="txt_endtime" type="text" value="" onclick="WdatePicker()" runat="server"/> &nbsp;<asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" /></td>
</tr>
</table>

<table id="table2" border="1" class="table2" runat="server" visible="false">
<tr>
<th class="header" colspan= "2">查询结果 (<asp:Label ID="lbl_starttime" runat="server"/> 至 <asp:Label ID="lbl_endtime" runat="server"/>)</th>
</tr>
<tr>
  <th>栏目</th>
  <th>总访问量</th>
</tr>
<tr>
  <td>纸质图书借阅</td>
  <td><asp:Label ID="paper_search" runat="server"/></td>
</tr>
<tr>
  <td>数字资源月点击率</td>
  <td><asp:Label ID="digitial_search" runat="server"/></td>
</tr>
</table>
</form>
</asp:Content>

