<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="journalcontents.aspx.cs" Inherits="journalcontents" Title="Untitled Page" %>
<%@ Register Assembly="MyGridView" Namespace="milnets.search" TagPrefix="cc1" %>

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
         <div  style="font-size:14px; margin:20px 20px 20px 10px; border-bottom:dotted 1px #cccccc; padding-bottom:10px;"><strong>期刊文字目录</strong></div> 
     
        <asp:Panel ID="Panel2" runat="server" Height="50px" Width="80%" Visible="False">
            <div class="results">
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </div>
        </asp:Panel>
        <br />
        <cc1:MyGridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            Width="80%" ForeColor="#333333" GridLines="None" AllowPaging="True">
            <PagerSettings FirstPageText="首页" LastPageText="尾页" NextPageText="后页" PreviousPageText="前页" />
            <Columns>
                <asp:BoundField DataField="_专题" HeaderText="专题"  HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="_篇名" HeaderText="篇名"  HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="_作者" HeaderText="作者"  HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="_页码" HeaderText="页码"  HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="_日期" HeaderText="日期"  HeaderStyle-HorizontalAlign="Left" />
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
    
    <br />
    
    <div class="feature">
         <div  style="font-size:14px; margin:20px 20px 20px 10px; border-bottom:dotted 1px #cccccc; padding-bottom:10px;"><strong>期刊图片目录</strong></div> 
     
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </div>
    <br />
    <br />
    <br />
    
    <div dojotype="dialog" id="dialog0" bgcolor="white" bgopacity="0.5" toggle="fade"
        toggleduration="200">
    </div>
    </form>
</asp:Content>

