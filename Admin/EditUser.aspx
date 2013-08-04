<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="Admin_EditUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="Css/bodystyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div align="center" style="height:100%;">
  <table width="100%" align="center" cellpadding="0" cellspacing="0">
    <tr background="images/bg.gif">
      <td height="27" align="middle" background="images/bg.gif"><div align="center"><span class="title"><strong>用户编辑/--<%=result %></strong></span><br>
      </div></td>
    </tr>
    <tr>
      <td valign="top" align="left"> 
      <form id="fsfd" runat="server">
            <table style="font-size:14px; line-height:22px;">
                <tr><td style="text-align:right; width:80px;">用户名：</td><td style="text-align:left;"> <asp:TextBox ID="username" runat="server" Width="227px"></asp:TextBox></td></tr>
                 
                 <tr><td style="text-align:right; width:80px;">密&nbsp;&nbsp;码：</td><td style="text-align:left;"> <asp:TextBox ID="password" runat="server" Width="227px"></asp:TextBox></td></tr>

                 <tr><td style="text-align:right; width:80px;">密码提示：</td><td style="text-align:left;"> <asp:TextBox ID="question" runat="server" Width="227px"></asp:TextBox></td></tr>

                <tr><td style="text-align:right; width:80px;">提示答案：</td><td style="text-align:left;"> <asp:TextBox ID="answer" runat="server" Width="227px"></asp:TextBox></td></tr>

                <%if (!isself)
                  { %>
                <tr><td style="text-align:right; width:80px;">读者条码：</td><td style="text-align:left;"> <asp:TextBox ID="userid" runat="server" Width="227px"></asp:TextBox></td></tr>

                <tr><td style="text-align:right; width:80px;">读者姓名：</td><td style="text-align:left;"> <asp:Label ID="realname"
                            runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;/&nbsp;&nbsp;性别：<asp:Label ID="gender"
                            runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;/&nbsp;&nbsp;读者类型：<asp:Label ID="type"
                            runat="server" Text="Label"></asp:Label></td></tr>

                <tr><td style="text-align:right; width:80px;">读者单位：</td><td style="text-align:left;"> <asp:Label ID="depart"
                            runat="server" Text="Label"></asp:Label></td></tr>

                <tr><td style="text-align:right; width:80px;">办证时间：</td><td style="text-align:left;"> 
                    <asp:Label ID="banzheng"
                            runat="server" Text="Label"></asp:Label></td></tr>

                <tr><td style="text-align:right; width:80px;">借阅信息：</td><td style="text-align:left;"> 累计借阅图书<asp:Label ID="allnum" runat="server" Text="Label"></asp:Label>册，当前借出<asp:Label
                        ID="nownum" runat="server" Text="Label"></asp:Label>册，欠款金额为<asp:Label ID="money"
                            runat="server" Text="Label"></asp:Label>元</td></tr>

                <tr><td style="text-align:right; width:80px;">登陆信息：</td><td style="text-align:left;">登陆次数<asp:Label ID="logintimes" runat="server" Text="Label"></asp:Label>：，上次于&nbsp;<asp:Label
                        ID="lasttime" runat="server" Text="Label"></asp:Label>&nbsp在&nbsp;<asp:Label ID="lastip"
                            runat="server" Text="Label"></asp:Label>&nbsp;登录</td></tr>
                <%} %>
               
                <tr><td style="text-align:right; width:80px;"></td><td style="text-align:left;"> <asp:Button ID="Button1" runat="server" Text="确认修改"/></td></tr>

            </table>
            
        
              
          
        </form>
     </td>
    </tr>
  </table>

<br /><br />
</div>
</body>
</html>
