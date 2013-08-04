<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchBookAjax.aspx.cs" Inherits="SearchBookAjax" %>
<%@ Register Src="~/Contrl/PageNum.ascx" TagName="pagelist" TagPrefix="ucl" %>

<table>
    <tr><th><input type="checkbox" onclick="chooseall();" />全选</th><th>索书号</th><th>可借本</th><th>题名</th><th>责任者</th><th>出版社</th><th>出版日期</th></tr>

<asp:Repeater ID="list_all" runat="server">
    
   <ItemTemplate>
      <tr class="list_item"><td><input type="checkbox" value="<%# DataBinder.Eval(Container.DataItem,"recid")%>"/></td>
            <td><%# DataBinder.Eval(Container.DataItem,"bookno")%></td><td><%# DataBinder.Eval(Container.DataItem,"availablenum")%></td>
            <td><a href="BookDetail.aspx?id=<%# DataBinder.Eval(Container.DataItem,"recid")%>" target="_blank"><%# DataBinder.Eval(Container.DataItem,"title")%></a> </td>
            <td><%# DataBinder.Eval(Container.DataItem,"author")%></td><td><%# DataBinder.Eval(Container.DataItem,"publisher")%></td><td><%# DataBinder.Eval(Container.DataItem,"pubdate")%></td>
            </tr>
   </ItemTemplate>
   
</asp:Repeater>
</table>
               <ucl:pagelist ID="mypage" runat="server"  />
<% if(Session["username"]!=null){ %>               <div style="padding-left:80px;"><input type="button" value="加入收藏" onclick="addfavorite();"/></div><%} %>