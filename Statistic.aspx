﻿<%@ Page Language="C#" MasterPageFile="~/AllPage2.master" AutoEventWireup="true" CodeFile="Statistic.aspx.cs" Inherits="Statistic" Title="Untitled Page" %>
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
		td.search{
		    text-align:left;
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
  <td>本校教材</td>
  <td><asp:Label ID="month1_digital" runat="server"/></td>
  <td><asp:Label ID="total1_digital" runat="server"/></td>
</tr>
<tr>
  <td>本校论文</td>
  <td><asp:Label ID="month2_digital" runat="server"/></td>
  <td><asp:Label ID="total2_digital" runat="server"/></td>
</tr>
<tr>
  <td>教学研究资料</td>
  <td><asp:Label ID="month3_digital" runat="server"/></td>
  <td><asp:Label ID="total3_digital" runat="server"/></td>
</tr>
<tr>
  <td>科研学术动态</td>
  <td><asp:Label ID="month4_digital" runat="server"/></td>
  <td><asp:Label ID="total4_digital" runat="server"/></td>
</tr>
<tr>
  <td>军械士官</td>
  <td><asp:Label ID="month5_digital" runat="server"/></td>
  <td><asp:Label ID="total5_digital" runat="server"/></td>
</tr>
<tr>
  <td>教学参考书全文库</td>
  <td><asp:Label ID="month6_digital" runat="server"/></td>
  <td><asp:Label ID="total6_digital" runat="server"/></td>
</tr>
<tr>
  <td>维修技术信息资料汇编</td>
  <td><asp:Label ID="month7_digital" runat="server"/></td>
  <td><asp:Label ID="total7_digital" runat="server"/></td>
</tr>
<tr>
  <td>学科学会论文集库</td>
  <td><asp:Label ID="month8_digital" runat="server"/></td>
  <td><asp:Label ID="total8_digital" runat="server"/></td>
</tr>
</table>

<table class="table2">
<tr>
<th class="header">
按条件查询
</th>
</tr>
<tr>
<td class ="search">
卡号:<input id="txt_cardno" type="text" value="" runat="server" /><br>
开始:<input id="txt_starttime" type="text" value="" onclick="WdatePicker()" runat="server"/>
结束:<input id="txt_endtime" type="text" value="" onclick="WdatePicker()" runat="server"/> 
<input id="btn_Search" type="button" runat="server" value="查询" onserverclick="btn_Search_ServerClick" />
</td>
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
  <td>本校教材</td>
  <td><asp:Label ID="digital1_search" runat="server"/></td>
</tr>
<tr>
  <td>本校论文</td>
  <td><asp:Label ID="digital2_search" runat="server"/></td>
</tr>
<tr>
  <td>教学研究资料</td>
  <td><asp:Label ID="digital3_search" runat="server"/></td>
</tr>
<tr>
  <td>科研学术动态</td>
  <td><asp:Label ID="digital4_search" runat="server"/></td>
</tr>
<tr>
  <td>军械士官</td>
  <td><asp:Label ID="digital5_search" runat="server"/></td>
</tr>
<tr>
  <td>教学参考书全文库</td>
  <td><asp:Label ID="digital6_search" runat="server"/></td>
</tr>
<tr>
  <td>维修技术信息资料汇编</td>
  <td><asp:Label ID="digital7_search" runat="server"/></td>
</tr>
<tr>
  <td>学科学会论文集库</td>
  <td><asp:Label ID="digital8_search" runat="server"/></td>
</tr>
</table>
</form>

</asp:Content>

