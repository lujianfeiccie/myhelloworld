<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="UserReg.aspx.cs" Inherits="UserReg" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width:100%; text-align:left; margin:0px 0px 0px 0px;">
        <tr>
            <td style="width:50%;border:1px solid #F36525; height: 274px;" valign="top">
             <div id="title2" style=" color:#F36525; padding-top:5px; padding-left:5px; font-size:18px;"><strong>注册新用户</strong></div>
             <form id="User" method="post" action="register.aspx?act=reg" style=" padding-left:20px;">
             <table width="100%" border="0" cellpadding="0" cellspacing="o">
			 	<tr class="item1">
				<td width="20%">用户名:</td>
				<td width="30%"><input name="username" type="text"  style="width:150px;"  maxlength="20" id="username" onblur="CheckUsername();" /></td>
				<td width="50%"><div id="usernamemsg"><span class="alert">*</span><span style="font-size:12px;">用户名为4-16位字符串</span></div></td>
				</tr>
				<tr class="item1">
				<td width="20%">密&nbsp;&nbsp;码:</td>
				<td width="30%"><input name="password" type="password"  style="width:150px;"  maxlength="20" id="password" onblur="checkpsw();" /></td>
				<td width="50%"><div id="passwordmsg"><span class="alert">*</span><span style="font-size:12px;">密码为6-16位字符的字符串</span></div></td>
				</tr>
				<tr class="item1">
				<td width="20%">重复密码:</td>
				<td width="30%"><input name="password2" type="password" style="width:150px;"  maxlength="20" id="password2" onblur="checkpsw2();" /></td>
				<td width="50%"><div id="password2msg"><span class="alert">*</span></div></td>
				</tr>
				<tr class="item1">
				<td width="20%" style="height: 24px">一卡通卡号:</td>
				<td width="30%" style="height: 24px"><input name="card" type="text"  style="width:150px;"  maxlength="18" id="card"  onblur="CheckCardNO();" /></td>
				<td width="50%" style="height: 24px"><div id="cardmsg"><span class="alert">*</span><span style="font-size:12px;">卡号可到图书馆阅览室查询</span></div></td>
				</tr>
				<tr class="item1">
				<td width="20%">密码提示问题:</td>
				<td width="30%"><input name="tishi" type="text"  style="width:150px;"  id="tishi" onblur="CheckTiShi();" /></td>
				<td width="50%"> <div id="tishimsg"><span class="alert">*</span></div> </td>
				</tr>
				<tr class="item1">
				<td width="20%">密码提示答案:</td>
				<td width="30%"><input name="answer" type="text" style="width:150px;" id="answer" onblur="CheckAnswer();" /></td>
				<td width="50%"><div id="answermsg"><span class="alert">*</span></div></td>
				</tr>
				
				<td width="20%" align="right"><input value="yes" name="agree" type="checkbox" id="agree" checked="checked" /></td>
				<td colspan="2">我已阅读注册协议，并完全同意。</td>
				</tr>
				<tr class="item1">
				<td width="20%">&nbsp;</td>
				<td colspan="2"><div id="checkall"></div></td>
				</tr>
				<tr class="item1">
				<td width="20%">&nbsp;</td>
				<td width="30%"><input type="button" name="tijiao" value="提交注册信息" id="tijiao" onclick="checkpost();" /></td>
				<td width="50%">
				  <input type="reset" name="Submit2" value="重新填写信息" />
				</td>
				</tr>
			 </table>
             </form>          </td>
            <td style="width: 50%; height: 274px;" valign="top"><div id="title" style=" color:#F36525;padding-left:5px; text-align:center; font-size:18px;"><strong>注册协议</strong></div>
			<textarea  name="xieyi" readonly="readonly" class="item" id="xieyi" style="width:98%; overflow-x:hidden; overflow-y:scroll; height: 303px;">
			总则

欢迎使用“我的图书馆”为您提供的各项服务。以下所述条款和条件即构成您访问和使用服务时所达成的协议，一旦您访问和使用“我的图书馆”，即表示您已接受了以下所述的条款和条件。

一、注册义务

您必须按照申请注册用户的表格，真实、准确、完整的填写您的资料；维持并及时更新资料，使其保持真实、准确、完整和反应当前情况。倘若您提供的资料不真实、准确和完整或有合理理由怀疑该资料不真实、准确、完整的，网站管理人员有权暂停或终止您的注册身份，并拒绝您在目前和将来对服务以任何形式使用。
二、注册名、密码和保密

在登记过程中，您将选择注册名和密码。注册名的选择应遵守法律法规及社会公德。您必须对您的密码保密，您将对您注册名和密码下发生的所有活动承担责任。如发现任何人未经您同意使用您的注册名跟密码，请立即通知网站管理人员（电话77273）。

三、您的权利和义务

   1、您有权根据本协议的相关规则发布信息、评价、参与活动等其他无特殊限制的服务；
   2、您发表的言论、评价应当真实，不得侮辱、诽谤和恶意评价他人；
   3、您发布的信息不得侵犯他人的知识产权或其他合法利益；
   
四、网站管理人员的权利和义务

   1、网站管理人员有义务在现有技术上维护整个平台的正常运行，并努力提升和改进技术；
   2、网站管理人员有权对您的注册资料及在网站中的行为进行查阅，发现注册资料存在问题或有合理理由怀疑相关行为不当的，有权向您发出询问及要求修正；
   3、在您使用本网站相关服务时，网站有权接收并记录您的个人信息，包括但不限于IP地址、网站Cookie中的资料及您要求取用的网页记录等。

			</textarea>
			</td>
        </tr>
</table>
<div id="waiting" style="z-index: 3; left:18%;display:none;width:300px;position: absolute; top: 65%; height:40px">
<img src="Images/progress.gif" />正在处理，请耐心等待。。。
 </div>
</asp:Content>

