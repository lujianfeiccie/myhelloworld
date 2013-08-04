<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="LibZYPage2.aspx.cs" Inherits="LibZYPage2" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-size:15px; background-color:#efefef; height:30px; padding-top:10px; padding-left:30px; font-weight:bold;">特色资源</div>
        <div class="feature" style="padding-left:40px; font-size:14px;">
        
               <ul class="news_list">
                    <asp:Repeater ID="link_list_all" runat="server">
                    <ItemTemplate>
                    <li class="news_list_item" style="background-image:url(images/4.gif); background-repeat:no-repeat;padding-left:45px; padding-top:14px; height:50px; font-size:14px;width:550px; float:left;display:block;"><a href="<%# DataBinder.Eval(Container.DataItem,"url")%>" title="<%# DataBinder.Eval(Container.DataItem,"title")%>" target="_blank"><%# DataBinder.Eval(Container.DataItem,"title")%></a> </li></ItemTemplate>
                </asp:Repeater>
               </ul>
            
        </div>
    
</asp:Content>


