<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="LoanTop.aspx.cs" Inherits="LoanTop" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div id="content_left_guid">
            <div id="content_left_guid_head"></div>
            
                
                  
            
        </div>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1" style="width:150px;" runat="server">��������&nbsp;&nbsp;2009-9-1����</span><span class="head_right" id="sitemap" style="width:300px;" runat="server">��ǰλ�ã�<a href="Default.aspx">��ҳ</a>&nbsp;<img src="images/next.jpg" />&nbsp;<a href="LoanTop.aspx">��������</a></span></div>
               <ul class="news_list">
                    <asp:Repeater ID="loan_list_all" runat="server">
                    <ItemTemplate>
                    <li class="news_list_item" style="background-image:none; line-height:22px;"><%# DataBinder.Eval(Container.DataItem,"DEP")%> &nbsp;&nbsp&nbsp(<%# DataBinder.Eval(Container.DataItem,"num")%>��) </li></ItemTemplate>
                </asp:Repeater>
               </ul>
            
        </div>
</asp:Content>
