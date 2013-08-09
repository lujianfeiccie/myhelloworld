<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="DefaultTest.aspx.cs"
    Inherits="DefaultTest" Title="Untitled Page" %>
<%@ OutputCache Duration="1" VaryByParam="none"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <div id="web_notice" class="left_block" style="width:250px">
        <div class="left_block_head"><span class="head_title">网站公告</span><span class="more" onclick="javascript:location.href='NewsList.aspx?type=notice'"></span></div>
        <div class="left_block_info" >
            <ul>
                 <asp:Repeater ID="top2notice" runat="server">
                    <ItemTemplate>
                        <li><span class="lefttitle" style="width: 150px;">
                        <a href="BookView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>"
                            title="<%# DataBinder.Eval(Container.DataItem,"title")%>" target="_blank">
                            <%# myfun.ShortString(DataBinder.Eval(Container.DataItem, "title").ToString(), 20, "&nbsp;")%>
                        </a></span><span class="rightdate">
                            <%# IsNew( DataBinder.Eval(Container.DataItem,"pub_time").ToString())%>
                        </span></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
</asp:Content>
