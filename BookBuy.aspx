<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="BookBuy.aspx.cs" Inherits="BookBuy" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<form id="fsfsfdds" runat="server">
<script language="javascript" type="text/javascript" src="JS/dojo.js"></script>
<script language="javascript" type="text/javascript" src="JS/my.js"></script>
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</ajaxToolkit:ToolkitScriptManager>
<div id="content_left_guid">
            <div id="content_left_guid_head"></div>
            
                 <a href="Myhistory.aspx"><div class="content_left_guid_item" >借阅历史</div> </a>       
                  <a href="BookOrder.aspx"  style="display:none;"><div class="content_left_guid_item" >图书预约</div> </a>     
                <a href="MyFavorite.aspx"><div class="content_left_guid_item" >我的收藏</div> </a>  
                <a href="MyLib.aspx"><div class="content_left_guid_item" >我的图书馆</div></a>     
                <a href="BooKBuy.aspx"><div class="content_left_guid_item_on" >图书荐购</div> </a>        
                 <a href="MyInfo.aspx"><div class="content_left_guid_item" >个人信息</div> </a> 
                 <a href="MyMail.aspx"><div class="content_left_guid_item" >我的信件</div> </a>   
                 <a href="Login.aspx?act=out"><div class="content_left_guid_item" >退出登录</div> </a>     
            
        </div>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">图书荐购</span><span class="head_right" id="sitemap" >当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;<a href="MyLib.aspx">我的图书馆</a>&nbsp;<img src="images/next.jpg" />&nbsp;图书荐购</span></div>
             <asp:Panel ID="Panel2" runat="server" Width="100%">
    
    <div class="feature">
            <asp:Panel ID="Panel1" runat="server"  Height="50px" Visible="False" Width="100%">
                <div class="results" style="color:Red;">
                    <asp:Label ID="Label2" runat="server" ></asp:Label>
                </div>
            </asp:Panel>
            <table style="width: 100%; height: 479px">
                <tr>
                    <td style="width: 69px">
                        题名</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <span style="color: red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" ControlToValidate="TextBox1" Display="None" ErrorMessage="题名不能为空"></asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                                TargetControlID="RequiredFieldValidator1">
                            </ajaxToolkit:ValidatorCalloutExtender>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 69px">
                        责任者</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        <span style="color: red">*<asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server" ControlToValidate="TextBox2" Display="None" ErrorMessage="责任者不能为空"></asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
                                TargetControlID="RequiredFieldValidator2">
                            </ajaxToolkit:ValidatorCalloutExtender>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 69px">
                        ISBN/ISSN</td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>&nbsp;
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                            FilterType="Numbers" TargetControlID="TextBox3">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 69px; height: 29px;">
                        出版社</td>
                    <td style="height: 29px">
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 69px">
                        出版年</td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><asp:RangeValidator ID="RangeValidator1"
                            runat="server" ControlToValidate="TextBox5" Display="None" ErrorMessage="请输入正确的出版年"
                            MaximumValue="3000" MinimumValue="1000"></asp:RangeValidator>
                        &nbsp;
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                            FilterType="Numbers" TargetControlID="TextBox5">
                        </ajaxToolkit:FilteredTextBoxExtender>
                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server"
                            TargetControlID="RangeValidator1">
                        </ajaxToolkit:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 69px">
                        价格</td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                            FilterType="Numbers" TargetControlID="TextBox6">
                        </ajaxToolkit:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 69px">
                        备注</td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server" Height="301px" Width="583px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 69px">
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />&nbsp;
                        <asp:Button ID="Button2" runat="server" Text="重置" /></td>
                </tr>
            </table>
    </div>
    <br />
    <br />
    <br />
    </asp:Panel>
              
        </div>
        
  </form>      
</asp:Content>

