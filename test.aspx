<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="result" runat="server">
        <ItemTemplate>
            <%# DataBinder.Eval(Container.DataItem,"_页面名称") %>
        </ItemTemplate>
        </asp:Repeater>
      
    </div>
        <asp:Repeater ID="result2" runat="server">
        <ItemTemplate>
            <%# DataBinder.Eval(Container.DataItem,"username") %>
        </ItemTemplate>
        </asp:Repeater>
          <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged" OnPageChanging="AspNetPager1_PageChanging">
        </webdiyer:AspNetPager>
     <%=mModel_LibWeb.Title%>
    </form>
</body>
</html>
