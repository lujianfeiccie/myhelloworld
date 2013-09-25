<%@ Page Language="C#" MasterPageFile="~/AllPage2.master" AutoEventWireup="true" CodeFile="Statistic.aspx.cs" Inherits="Statistic" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="Calendar/WdatePicker.js"></script>
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
  <td>123</td>
  <td>123</td>
</tr>
<tr>
  <td>数字资源月点击率</td>
  <td>123</td>
  <td>123</td>
</tr>
</table>

<table class="table2">
<tr>
<th colspan="2" class="header">
按时间段查询
</th>
</tr>
<tr>
<td>开始:<input type="text" value="" onClick="WdatePicker()"/></td> <td>结束:<input type="text" value="" onClick="WdatePicker()"> &nbsp;<button>查询</button></td>
</tr>
</table>

<table border="1" class="table2">
<tr>
<th class="header" colspan= "2">查询结果 (2013-5-26 至 2013-5-28)</th>
</tr>
<tr>
  <th>栏目</th>
  <th>总访问量</th>
</tr>
<tr>
  <td>纸质图书借阅</td>
  <td>123</td>
</tr>
<tr>
  <td>数字资源月点击率</td>
  <td>123</td>
</tr>
</table>
</asp:Content>

