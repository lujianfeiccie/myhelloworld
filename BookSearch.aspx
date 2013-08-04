<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="BookSearch.aspx.cs" Inherits="BookSearch" Title="Untitled Page" %>

<%@ Register Assembly="MyGridView" Namespace="milnets.search" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script language="javascript" type="text/javascript" src="JS/dojo.js"></script>
<script language="javascript" type="text/javascript" src="JS/my.js"></script>
<form id="fsfsfsdfs" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    
    <div id="content_left_guid">
            <div id="content_left_guid_head" style=" padding-left:30px; padding-top:10px; font-size:13px; color:White; font-weight:bold;">书目检索</div>
            <div style="height:26px; margin:12px 0px 2px 0px; text-align:center;"><span style="background-color:yellow; padding:4px 5px 4px 5px; font-weight:bold;">热门搜索</span></div>
            <div class="hot_search"  style="line-height:24px;">
             <asp:Repeater ID="top10" runat="server">
                    <ItemTemplate>
                        <span class="search_hot_word"  onclick="dojo.byId('<%=textid %>').value = '<%# DataBinder.Eval(Container.DataItem,"keyword")%>'; dojo.byId('<%=downlistid %>').selectedIndex = 0; dojo.byId('<%=buttomid %>').click()"><%# DataBinder.Eval(Container.DataItem,"keyword")%>&nbsp;(<%# DataBinder.Eval(Container.DataItem,"all_num")%>)</span>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
             
            
        </div>
        <div id="content_center_info">
               <div class="search_control_head" id="change_head"><span class="change_head_on" id="change_head1">简单检索</span><span onclick="javascript:location.href='Advance.aspx'" id="change_head2"  class="change_head">多字段检索</span></div>
                    <div class="change_info" style="display:block;" id="change_info1">
                        <div style=" font-weight:bold;">馆藏书目检索</div>
                        <div>
                             <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                            FilterMode="InvalidChars" InvalidChars="`~!@#$%^&*()_+{}[]|\:&quot;;'<>?,./"
                            TargetControlID="TextBox1">
                        </ajaxToolkit:FilteredTextBoxExtender>
                        <asp:TextBox ID="TextBox1" runat="server" Width="315px"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" Text="检索" OnClick="Button1_Click" />
                        
                        
                        </div>
                       
                        <div class="other_option">
                            <div>请选择检索方式：
                            
                                 <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem Value="pinyin" Selected="True">题名</asp:ListItem>
                                    <asp:ListItem Value="author">责任者</asp:ListItem>
                                    <asp:ListItem Value="classno">索书号</asp:ListItem>
                                    <asp:ListItem Value="publisher">出版社</asp:ListItem>
                                    <asp:ListItem Value="keyword">主题词</asp:ListItem>
                                    <asp:ListItem>ISBN</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div style="display:none;">请选择数据来源：<asp:DropDownList ID="DropDownList4" runat="server" Visible="false"/></div>
                            <div>请选择检索模式：
                                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="mode" Text="前方一致" Checked="True" />&nbsp;
                                    <asp:RadioButton ID="RadioButton3" runat="server" Text="完全匹配" GroupName="mode" />
                                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="mode" Text="任意匹配" />
                            
                            </div>
                            
                            <div>每页显示记录数：
                                    <asp:DropDownList ID="DropDownList2" runat="server">
                                        <asp:ListItem Selected="True">15</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                        <asp:ListItem>30</asp:ListItem>
                                        <asp:ListItem>50</asp:ListItem>
                                        <asp:ListItem>100</asp:ListItem>
                                    </asp:DropDownList>
                            
                            </div>
                            <div>结果排序方式以：
                                        <asp:DropDownList ID="DropDownList3" runat="server">
                                            <asp:ListItem Selected="True" Value="title">题名</asp:ListItem>
                                            <asp:ListItem Value="author">责任者</asp:ListItem>
                                            <asp:ListItem Value="pubdate">出版日期</asp:ListItem>
                                            <asp:ListItem Value="createdate">入藏日期</asp:ListItem>
                                            <asp:ListItem Value="classno">分类号</asp:ListItem>
                                            <asp:ListItem Value="bookno">索书号</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RadioButton ID="RadioButton4" runat="server" GroupName="order" Text="升序" />
                                        <asp:RadioButton ID="RadioButton5" runat="server" GroupName="order" Text="降序" Checked="True" />
                            
                            </div>
                            <div>请选择检索范围：
                                    <asp:RadioButton ID="RadioButton6" runat="server" Checked="True" GroupName="range" Text="不限" />
                                    <asp:RadioButton ID="RadioButton7" runat="server" GroupName="range" Text="在结果中" /></div>
                            
                            </div>
                            <div> <asp:Panel ID="Panel1" runat="server" Height="2em" Width="100%" Visible="False">
                                        <div class="results">
                                            <asp:Label ID="Label2" runat="server"></asp:Label>&nbsp;
                                            <asp:Label ID="Label3" runat="server"></asp:Label>
                                            
                                        </div>
                                    </asp:Panel>
                            </div>
                            <div id="result1">
                               <asp:UpdatePanel id="UpdatePanel2" runat="server">
                                        <contenttemplate>
                                    <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CellPadding="2" DataKeyNames="recid,bookno,title,author,publisher,pubdate,secret,from"
                                        ForeColor="#333333" GridLines="None" OnDataBinding="GridView1_DataBinding" OnDataBound="GridView1_DataBound"
                                        OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound"
                                        PagerType="CustomNumeric" Width="100%">
                                        <PagerSettings FirstPageText="首页" LastPageText="尾页" NextPageText="后页" PreviousPageText="前页" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="全选"  HeaderStyle-HorizontalAlign="Left">
                                                <headertemplate>
                                                    <input id="CheckAll" type="checkbox" onclick="javascript:CheckAll(this);" runat="server" title="选择全部" />
                                                </headertemplate>
                                                <itemstyle wrap="False" />
                                                <itemtemplate>
                                                    <input type="checkbox" value="<%# DataBinder.Eval(Container.DataItem,"recid")%>" />
                                                    <asp:CheckBox ID="CheckBox1"  Visible="False"  onclick="javascript:hilightRow(this);" runat="server" />
                                                </itemtemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="bookno" HeaderText="索书号"  HeaderStyle-HorizontalAlign="Left"/>
                                            <asp:BoundField DataField="availableNum" HeaderText="可借" NullDisplayText="0"  HeaderStyle-HorizontalAlign="Left"/>
                                            <asp:HyperLinkField DataNavigateUrlFields="recid" DataNavigateUrlFormatString="bookdetail.aspx?id={0}"
                                                DataTextField="title" HeaderText="题名"  HeaderStyle-HorizontalAlign="Left"/>
                                            <asp:HyperLinkField DataNavigateUrlFormatString="javascript:" DataTextField="author"
                                                HeaderText="责任者"  HeaderStyle-HorizontalAlign="Left">
                                                <controlstyle cssclass="handCursor" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField DataTextField="publisher" HeaderText="出版者"  HeaderStyle-HorizontalAlign="Left">
                                                <itemstyle cssclass="handCursor" />
                                            </asp:HyperLinkField>
                                            <asp:BoundField DataField="pubdate" HeaderText="出版日期"  HeaderStyle-HorizontalAlign="Left"/>
                                            <asp:BoundField DataField="secret" HeaderText="密级"  HeaderStyle-HorizontalAlign="Left"/>
                                        </Columns>
                                        <FooterStyle BackColor="#F36525" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#000333" Height="1.8em" />
                                        <EditRowStyle BackColor="#999999" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="White" ForeColor="Blue" />
                                        <HeaderStyle BackColor="#F36525" Font-Bold="True" ForeColor="White" Height="1.8em" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    </cc1:MyGridView></contenttemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdateProgress id="UpdateProgress1" runat="server" DisplayAfter="100">
                                        <progresstemplate>
                                            <div id="loading">正在获取数据...</div>
                                        </progresstemplate>
                                    </asp:UpdateProgress>
                                    <div><% if (Session["userid"] != null)
                                            { %><input style="margin-left:10px;" type="button" value="加入收藏" onclick="addfavorite();" /><%} %></div>
                            </div>
                        </div>
                        
                  
   
            </div>
    
   
   <script language="javascript" type="text/javascript">
 
 var isallchoose=0;
function chooseall()
{
        
        if(isallchoose==0)
             {$(":checkbox").attr("checked","checked");isallchoose=1;}
        else 
            {$(":checkbox").attr("checked","");isallchoose=0;}
}

function addfavorite()
{
    var str="";
   

    $(":checkbox[checked]").each(function()
    {
        str+=$(this).val()+",";
    //alert($(this).val());
    });
    str=str.substr(0,str.length-1);
    if(str=="")
    {
        alert("请选择！");
        return;
    }
    else{
    
            $.ajax({ type:"Get",
           url: "DoMyFavorite.aspx",
           cache: false,
           data:"act=add&ids="+str,
           success: function(data){
                if(data=="ok")
                {
                    alert("成功添加");
                }
                else{alert(data);}
                
            }}); 
    
    
    }
}
   </script>
    </form>
</asp:Content>

