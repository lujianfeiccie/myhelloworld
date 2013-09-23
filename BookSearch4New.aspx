<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="BookSearch4New.aspx.cs" Inherits="BookSearch4New" Title="Untitled Page" %>
<%@ Register Assembly="MyGridView" Namespace="milnets.search" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <script language="javascript" type="text/javascript" src="js/my.js"></script>
    <script type="text/javascript" src="js/dojo.js"></script> 
<form id="fsfsdfd" runat="server">
    <div style="font-size:15px; background-color:#efefef; height:30px; padding-top:10px; padding-left:20px; font-weight:bold;">新书检索<asp:Label ID="Label1" runat="server" Text=""></asp:Label></div>

    <div class="feature" style="padding-left:20px; line-height:24px; margin:12px 0px 20px 0px; font-size:13px;">

        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
            FilterMode="InvalidChars" InvalidChars="`~!@#$%^&*()_+{}[]|\:&quot;;'<>?,./"
            TargetControlID="TextBox1">
        </ajaxToolkit:FilteredTextBoxExtender>
        <span style="font-size:13px;">
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="_题名" Selected="True">题名</asp:ListItem>
            <asp:ListItem Value="_出版者">出版者</asp:ListItem>
            <asp:ListItem Value="_责任者">责任者</asp:ListItem>
            <asp:ListItem Value="_分类">分类号</asp:ListItem>
            <asp:ListItem Value="_出版地">出版地</asp:ListItem>
            <asp:ListItem>ISBN</asp:ListItem>
        </asp:DropDownList>
        </span>
        <asp:DropDownList ID="DropDownList4" runat="server">
            <asp:ListItem Value="1">今日上架</asp:ListItem>
            <asp:ListItem Value="2">本周上架</asp:ListItem>
            <asp:ListItem Value="3">本月上架</asp:ListItem>
            <asp:ListItem Value="4">最近两个月上架</asp:ListItem>
            <asp:ListItem Value="5">最近三个月上架</asp:ListItem>
            <asp:ListItem Value="0"  Selected="True">所有新书</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
        
        <asp:Button ID="Button1" runat="server" Text="检索" OnClick="Button1_Click" />
        <br />
        <div style="margin-left:200px">
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="mode" Text="前方一致" Checked="True" />&nbsp;
        <asp:RadioButton ID="RadioButton3" runat="server" Text="完全匹配" GroupName="mode" />
        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="mode" Text="任意匹配" />
        </div>
    </div>
    
    <div class="search_control"  style="padding-left:20px; padding-top:20px; line-height:24px; background-color:#F9F9EB; font-size:13px;">
        <div style=" margin:12px 0px 10px 0px;">
        
        【每页显示记录数】
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem Selected="True">15</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
            <asp:ListItem>100</asp:ListItem>
        </asp:DropDownList>
            <br />
        【排序方式】
        <asp:DropDownList ID="DropDownList3" runat="server">
             <asp:ListItem Value="_题名" Selected="True">题名</asp:ListItem>
            <asp:ListItem Value="_出版者">出版者</asp:ListItem>
            <asp:ListItem Value="_责任者">责任者</asp:ListItem>
            <asp:ListItem Value="_分类">分类号</asp:ListItem>    
            <asp:ListItem Value="_入档日期">入档日期</asp:ListItem>    
        </asp:DropDownList>
        <asp:RadioButton ID="RadioButton4" runat="server" GroupName="order" Text="升序" />
        <asp:RadioButton ID="RadioButton5" runat="server" GroupName="order" Text="降序" Checked="True" />
            <br />
        【检索范围】<asp:RadioButton ID="RadioButton6" runat="server" Checked="True" GroupName="range"
            Text="不限" />
        <asp:RadioButton ID="RadioButton7" runat="server" GroupName="range" Text="在结果中" />
        </div>
          <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="False">
                    <div class="results" style="margin-bottom:10px; font-size:13px;">
                        <asp:Label ID="Label2" runat="server"></asp:Label>&nbsp;
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    </div>
        </asp:Panel>
    </div>
    <div class="feature">
        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging"
            AutoGenerateColumns="False" DataKeyNames="recid" OnDataBinding="GridView1_DataBinding"
            OnRowDataBound="GridView1_RowDataBound" OnDataBound="GridView1_DataBound" CellPadding="4"
            ForeColor="#333333" GridLines="None" PagerType="CustomNumeric">
            <PagerSettings FirstPageText="首页" LastPageText="尾页" NextPageText="后页" PreviousPageText="前页" />
            <Columns>
            <asp:HyperLinkField DataTextField="_分类" HeaderText="索书号" HeaderStyle-HorizontalAlign="Left">
                    <ItemStyle CssClass="handCursor" />
                </asp:HyperLinkField>
                  <asp:HyperLinkField DataNavigateUrlFields="recid" DataNavigateUrlFormatString="bookdetail.aspx?id={0}"
                                                DataTextField="_题名" HeaderText="题名"  HeaderStyle-HorizontalAlign="Left"/>
                                
                <asp:HyperLinkField DataTextField="_责任者" HeaderText="责任者" HeaderStyle-HorizontalAlign="Left">
                    <ItemStyle CssClass="handCursor" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField="_出版者" HeaderText="出版者" HeaderStyle-HorizontalAlign="Left">
                    <ItemStyle CssClass="handCursor" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="_入档日期" HeaderText="入档日期"  HeaderStyle-HorizontalAlign="Left"/>
                
               
               
            </Columns>
            <FooterStyle BackColor="#F36525" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#000333" Height="1.8em" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="White" ForeColor="Blue" />
            <HeaderStyle BackColor="#F36525" Font-Bold="True" ForeColor="White" Height="1.8em" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </cc1:MyGridView>
        </div>  
        
        </form>   
</asp:Content>

