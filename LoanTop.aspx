<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="LoanTop.aspx.cs" Inherits="LoanTop" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div id="content_left_guid">
            <div id="content_left_guid_head"></div>
            
                
                  
            
        </div>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1" style="width:150px;" runat="server">借阅排行&nbsp;&nbsp;2009-9-1至今</span><span class="head_right" id="sitemap" style="width:300px;" runat="server">当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;<a href="LoanTop.aspx">借阅排行</a></span></div>
               <ul class="news_list">
                    <asp:Repeater ID="loan_list_all" runat="server">
                    <ItemTemplate>
                    <li class="news_list_item" style="background-image:none; line-height:22px;"><%# DataBinder.Eval(Container.DataItem,"DEP")%> &nbsp;&nbsp&nbsp(<%# DataBinder.Eval(Container.DataItem,"num")%>册) </li></ItemTemplate>
                </asp:Repeater>
               </ul>
            
        </div>
</asp:Content>
