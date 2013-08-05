<%@ Page Language="C#" EnableEventValidation="false" ViewStateEncryptionMode="Never" EnableViewStateMac="false" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="CDSearch.aspx.cs" Inherits="CDSearch" Title="Untitled Page" %>
<%@ Register Assembly="MyGridView" Namespace="milnets.search" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <script language="javascript" type="text/javascript" src="js/my.js"></script>
    <script type="text/javascript" src="js/dojo.js"></script> 
<form id="fsfsdfd" runat="server">
    <div style="font-size:15px; background-color:#efefef; height:30px; padding-top:10px; padding-left:20px; font-weight:bold;">随书光盘检索<asp:Label ID="Label1" runat="server" Text=""></asp:Label></div>

    <div class="feature" style="padding-left:20px; line-height:24px; margin:12px 0px 20px 0px; font-size:13px;">

        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
            FilterMode="InvalidChars" InvalidChars="`~!@#$%^&*()_+{}[]|\:&quot;;'<>?,./"
            TargetControlID="TextBox1">
        </ajaxToolkit:FilteredTextBoxExtender>
        <span style="font-size:13px;">【检索途径】
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="题名" Selected="True">题名</asp:ListItem>
            <asp:ListItem Value="索书号">索书号</asp:ListItem>
            <asp:ListItem Value="出版社">出版单位</asp:ListItem>
            <asp:ListItem Value="介绍">介绍</asp:ListItem>
            
        </asp:DropDownList>
        </span>
        <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="检索" OnClick="Button1_Click" />
        <div style="margin-left:200px">
        【检索模式】
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
        【排序方式】
        <asp:DropDownList ID="DropDownList3" runat="server">
            <asp:ListItem Value="题名" Selected="True">题名</asp:ListItem>
            <asp:ListItem Value="索书号">索书号</asp:ListItem>
            <asp:ListItem Value="出版社">出版单位</asp:ListItem>
            <asp:ListItem Value="上传时间">上传时间</asp:ListItem>
            <asp:ListItem Value="下载次数">下载次数</asp:ListItem>
           
        </asp:DropDownList>
        <asp:RadioButton ID="RadioButton4" runat="server" GroupName="order" Text="升序" />
        <asp:RadioButton ID="RadioButton5" runat="server" GroupName="order" Text="降序" Checked="True" />
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
            AutoGenerateColumns="False" DataKeyNames="id" OnDataBinding="GridView1_DataBinding"
            OnRowDataBound="GridView1_RowDataBound" OnDataBound="GridView1_DataBound" CellPadding="4"
            ForeColor="#333333" GridLines="None" PagerType="CustomNumeric">
            <PagerSettings FirstPageText="首页" LastPageText="尾页" NextPageText="后页" PreviousPageText="前页" />
            <Columns>
                <asp:BoundField DataField="索书号" HeaderText="索书号"  HeaderStyle-HorizontalAlign="Left"/>
                 <asp:TemplateField HeaderText="题名"  HeaderStyle-HorizontalAlign="Left">
                                                <headertemplate>
                                                    题名
                                                </headertemplate>
                                                <itemstyle wrap="False" />
                                                <itemtemplate>
                                                  <!--  <a href="#" onmouseover="showToolTip('光盘介绍','<%# DataBinder.Eval(Container.DataItem,"介绍")%>');" onmouseout="hideToolTip();"><%# DataBinder.Eval(Container.DataItem,"题名")%></a>-->
                                                   <%# DataBinder.Eval(Container.DataItem,"题名")%>
                                                </itemtemplate>
                                            </asp:TemplateField>
                
                <asp:HyperLinkField DataTextField="出版社" HeaderText="出版单位"  HeaderStyle-HorizontalAlign="Left">
                    <ItemStyle CssClass="handCursor" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="上传时间" HeaderText="上传时间"  HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="光盘大小" HeaderText="光盘大小"   HeaderStyle-HorizontalAlign="Left"/>
               
                <asp:BoundField DataField="下载次数" HeaderText="下载次数"  HeaderStyle-HorizontalAlign="Left"/>
                 <asp:TemplateField HeaderText="下载"  HeaderStyle-HorizontalAlign="Left">
                                                <headertemplate>
                                                    点击下载
                                                </headertemplate>
                                                <itemstyle wrap="False" />
                                                <itemtemplate>
                                                    <a href="downloadcd.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>"  target="_blank">点击下载</a>
                                                   
                                                </itemtemplate>
                                            </asp:TemplateField>
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
        <div id="toolTip" style="left:200px;"> </div>
        </form>   
</asp:Content>

