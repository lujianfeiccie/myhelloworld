<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="journaldetail.aspx.cs" Inherits="journaldetail" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script language="javascript" type="text/javascript" src="js/my.js"></script>
    <script type="text/javascript" src="js/dojo.js"></script> 
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
            dojo.byId('dialog0').innerHTML = "正在执行预约，请稍等...";
            dlg0.show();
        }
        dojo.addOnLoad(init);
    </script>
 <form id="fsfsdfd" runat="server" style="padding-left:4px; padding-right:4px;">
    <div style="font-size:15px; background-color:#efefef; height:30px; padding-top:10px; padding-left:20px; font-weight:bold;">期刊检索<asp:Label ID="Label1" runat="server" Text=""></asp:Label></div>

    
    <div class="feature">
       <div  style="font-size:14px; margin:20px 20px 20px 10px; border-bottom:dotted 1px #cccccc; padding-bottom:10px;"><strong>期刊基本信息</strong></div> 
        
        <asp:Panel ID="Panel2" runat="server" Height="50px" Width="80%" Visible="False">
            <div class="results">
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </div>
        </asp:Panel>
        <br />
        <asp:DataList ID="DataList1" runat="server" Width="100%" ItemStyle-BackColor="#F9F9EB">
            <ItemTemplate>
                <table class="detail1" style="width: 100%; margin-left:18px; margin-right:15px; font-size:13px; line-height:24px;">
                    <tr>
                        <td style="width: 331px">
                            刊名：<%# Eval("_刊名") %></td>
                        <td>
                            ISSN：<%# Eval("_ISSN") %></td>
                    </tr>
                    <tr>
                        <td style="width: 331px">
                            联系地址：<%# Eval("_联系地址")%></td>
                        <td>
                            编辑者：<%# Eval("_编辑者")%></td>
                    </tr>
                </table>
                <table class="detail2" style="width: 100%;margin-left:18px; margin-right:15px; font-size:13px; line-height:24px;">
                    <tr>
                        <td style="width: 331px">
                            主办者：<%# Eval("_主办者")%></td>
                        <td style="width: 330px">
                            出版者：<%# Eval("_出版者")%></td>
                        <td style="width: 330px">
                            发行单位：<%# Eval("_发行单位")%></td>
                    </tr>
                    <tr>
                        <td style="width: 331px">
                            单价：<%# Eval("_单价")%></td>
                        <td style="width: 330px">
                            年价：<%# Eval("_年价")%></td>
                        <td style="width: 330px">
                            分类号：<%# Eval("_分类号")%></td>
                    </tr>
                    <tr>
                        <td style="width: 331px">
                            正文语种：<%# Eval("_正文语种")%></td>
                        <td style="width: 330px">
                            装订：<%# Eval("_装订")%></td>
                        <td style="width: 330px">
                            变更历史：<%# Eval("_变更历史")%></td>
                    </tr>
                    <tr>
                        <td style="width: 331px">
                            年期数：<%# Eval("_年期数")%></td>
                        <td style="width: 330px">
                            出版周期：<%# Eval("_出版周期")%></td>
                        <td style="width: 330px">
                            出版国别：<%# Eval("_出版国别")%></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        
        <br /><br />
        <strong><span style="color:green; font-size:14px;">已到刊期信息</span></strong>
        <br /><br />
            
        <asp:GridView  ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%" ForeColor="#333333" GridLines="None">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="SignBoxID" DataNavigateUrlFormatString="journalcontents.aspx?id={0}"
                    DataTextField="_卷期信息" HeaderText="卷期信息" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="_馆藏地" HeaderText="馆藏位置" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="_总期" HeaderText="总期" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="_单价" HeaderText="单价" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="_出版日期" HeaderText="出版日期" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="_出版周期" HeaderText="出版周期" HeaderStyle-HorizontalAlign="Left" />
            </Columns>
            <FooterStyle BackColor="#F36525" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Height="1.8em" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#F36525" Font-Bold="True" ForeColor="White" Height="1.8em" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <br /><br />
        
        <strong><span style="color:red; font-size:14px;">未到刊期信息</span></strong><br /><br />
            
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%" ForeColor="#333333" GridLines="None">
            <Columns>
                <asp:BoundField DataField="_卷期信息" HeaderText="卷期信息" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="_订购复本" HeaderText="订购复本" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="_已签复本" HeaderText="总期" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="_单价" HeaderText="单价" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="_出版日期" HeaderText="出版日期" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="_催缺日期" HeaderText="催缺日期" HeaderStyle-HorizontalAlign="Left" />
            </Columns>
            <FooterStyle BackColor="#F36525" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Height="1.8em" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#F36525" Font-Bold="True" ForeColor="White" Height="1.8em" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>

        </div>
        
        <br /><br /><br />
                
    <div dojotype="dialog" id="dialog0" bgcolor="white" bgopacity="0.5" toggle="fade"
        toggleduration="200">
    </div>
    </form>
</asp:Content>

