<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="FindPsw.aspx.cs" Inherits="FindPsw" Title="找回密码" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <form id="dsfs" runat="server">
 
 <div style="font-size:15px; background-color:#efefef; height:30px; padding-top:10px; padding-left:30px; font-weight:bold;">找回密码</div>
    <div class="feature" style="padding-left:200px; padding-top:150px; height:300px; line-height:24px; font-size:14px;">
        <strong >&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:Label ID="alter" ForeColor="red" runat="server" Text=""></asp:Label><br />
        用户账号：<asp:TextBox ID="username" runat="server" Width="200px"></asp:TextBox><br />
            读者条码：<asp:TextBox ID="userid" runat="server"    Width="200px"></asp:TextBox>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="Button1" runat="server" Text="下一步" OnClick="Button1_Click" />&nbsp;
            <br />
            <asp:Panel ID="Panel1" runat="server" Width="462px" Visible="false">
            密码提示：<asp:Label ID="pswquestion" ForeColor="red" runat="server" Text=""></asp:Label><br />
            密码答案：<asp:TextBox ID="pswanswer" runat="server" Width="200px"></asp:TextBox>
                &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Button ID="Button2" runat="server" Text="找回密码" OnClick="Button2_Click" /><br /><br />
                <asp:Label ID="psw" runat="server" ForeColor="red" Text=""></asp:Label><br />
            </asp:Panel>
            
            
            <br />

        </strong>
        <br />
    </div>
    </form>
</asp:Content>
