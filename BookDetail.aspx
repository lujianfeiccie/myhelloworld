<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="BookDetail.aspx.cs" Inherits="BookDetail" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="fsfsfs" runat="server" style="padding:4px 12px 4px 20px;">
<script language="javascript" type="text/javascript" src="JS/dojo.js"></script>
<script language="javascript" type="text/javascript" src="JS/my.js"></script>

 <script type="text/javascript" language="javascript">	
		
		//dojo.require("dojo.event.*");
		//dojo.require("dojo.lfx.*");		
		dojo.require("dojo.widget.Dialog");
	
        var dlg0;
        function init(e) {
	        dlg0 = dojo.widget.byId("dialog0");
        }
        
        function showInfo()
        {
            
        }
        function reserbook()
        {
            var str="";
            str=$(":radio[checked]").val();
            
             
            if(str==""||str==null)
            {
                alert("请选择！");
                return;
            }
            else
            {
               // alert("act=reserv&ids="+str);
                 $.ajax({ type:"Get",
                   url: "DoMyFavorite.aspx",
                   cache: false,
                   data:"act=reserv&ids="+str,
                   success: function(data){
                        alert(data);
                        
                    }}); 
            }
    
        }
        dojo.addOnLoad(init);
    </script>
    
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>    
            <asp:Panel ID="Panel2" runat="server" Height="50px" Width="80%" Visible="False">
            <div class="results">
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </div>
        </asp:Panel>
        <br /><strong>书目信息</strong><span style="display:none;">（数据来源：<asp:Label ID="Label5" runat="server" Text="不明"></asp:Label>）</span><br /><br />
<asp:DataList ID="bookall" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None"  CellPadding="3" CellSpacing="2" GridLines="Both">
            <ItemTemplate>
                <div class="otheroption"></div>
                <table id="bookdetail" cellpadding="1" cellspacing="1" style="line-height:24px; width:400px;">
                    <tr>
                        <td>
                            题名：<%# Eval("title") %></td>
                        <td>
                            索书号：<%# Eval("bookno") %></td>
                    </tr>
                    <tr>
                        <td>
                            责任者：<%# Eval("author") %></td>
                        <td>
                            出版者：<%# Eval("publisher") %></td>
                    </tr>
                </table>
                <table cellpadding="1" cellspacing="1" style="line-height:24px;">
                    <tr>
                        <td style="width: 331px">
                            ISBN：<%# Eval("isbn") %></td>
                        <td style="width: 330px">
                            出版日期：<%# Eval("pubdate") %></td>
                        <td style="width: 330px">
                            入藏日期：<%# Eval("createdate") %></td>
                    </tr>
                    <tr>
                        <td style="width: 331px">
                            密级：<%# Eval("secret") %></td>
                        <td style="width: 330px">
                            价格：<%# Eval("price") %></td>
                        <td style="width: 330px">
                            页数：<%# Eval("pages") %></td>
                    </tr>
                    <tr>
                        <td style="width: 331px">
                            版次：<%# Eval("version") %></td>
                        <td style="width: 330px">
                            装订：<%# Eval("bind") %></td>
                        <td style="width: 330px">
                            尺寸开本：<%# Eval("format") %></td>
                    </tr>
                </table>
            </ItemTemplate>
    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
    <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
    <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
        
        <strong><br />馆藏信息</strong><br />
            <br />
            
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
            <Columns>
                 <asp:TemplateField HeaderText="选择"  Visible="False"    HeaderStyle-HorizontalAlign="Left">
                                                
                                                <itemstyle wrap="False" />
                                                <itemtemplate>
                                                <input type="radio" name="choosemy"  value="<%# DataBinder.Eval(Container.DataItem,"codebar") %>" <%# viewradio(DataBinder.Eval(Container.DataItem,"status").ToString())%> />
                                                 
                                                </itemtemplate>
                                            </asp:TemplateField>
                <asp:BoundField DataField="codebar" HeaderText="图书条码" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="location" HeaderText="馆藏位置"  HeaderStyle-HorizontalAlign="Left"/>
                <asp:BoundField DataField="status" HeaderText="图书状态"  HeaderStyle-HorizontalAlign="Left"/>
                <asp:BoundField DataField="createdate" HeaderText="入藏日期"  HeaderStyle-HorizontalAlign="Left"/>
               
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" Height="1.8em" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#F36525" Font-Bold="True" ForeColor="White" Height="1.8em" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
       
        <asp:Panel ID="Panel1" runat="server" Height="50px" Visible="False" Width="646px">
                <input type="button" style="display:none;" value="预约图书" onclick="reserbook();" />
                 
        </asp:Panel>
        
                <div dojotype="dialog" id="dialog0" bgcolor="white" bgopacity="0.5" toggle="fade"      toggleduration="200">
    </div>
</form>



</asp:Content>

