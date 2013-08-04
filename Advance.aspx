<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="Advance.aspx.cs" Inherits="Advance" Title="Untitled Page" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
    
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
                        <span class="search_hot_word"  onclick="dojo.byId('<%=textid %>').value = '<%# DataBinder.Eval(Container.DataItem,"keyword")%>';  dojo.byId('<%=buttomid %>').click()"><%# DataBinder.Eval(Container.DataItem,"keyword")%>&nbsp;(<%# DataBinder.Eval(Container.DataItem,"all_num")%>)</span>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
             
            
        </div>
        <div id="content_center_info">
               <div class="search_control_head" id="change_head"><span class="change_head" id="change_head1"  onclick="javascript:location.href='BookSearch.aspx'" >简单检索</span><span id="change_head2"  class="change_head_on">多字段检索</span></div>
                    
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                FilterMode="InvalidChars" InvalidChars="`~!@#$%^&*()_+{}[]|\:&quot;;'<>?,./"
                                TargetControlID="TextBox1">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                FilterMode="InvalidChars" InvalidChars="`~!@#$%^&*()_+{}[]|\:&quot;;'<>?,./"
                                TargetControlID="TextBox2">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                FilterMode="InvalidChars" InvalidChars="`~!@#$%^&*()_+{}[]|\:&quot;;'<>?,./"
                                TargetControlID="TextBox3">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                FilterMode="InvalidChars" InvalidChars="`~!@#$%^&*()_+{}[]|\:&quot;;'<>?,./"
                                TargetControlID="TextBox4">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                FilterMode="InvalidChars" InvalidChars="`~!@#$%^&*()_+{}[]|\:&quot;;'<>?,./"
                                TargetControlID="TextBox5">
                            </ajaxToolkit:FilteredTextBoxExtender>
                   
                    <div class="change_info" id="change_info2" style="display:block;">
                             <div style=" font-weight:bold;">馆藏多字段检索</div>
                             
                             <div class="other_option">
                                            
                                            <div> <table style=" line-height:23px; text-align:left;" cellpadding="4">
                                                    <tr>
                                                        <td>逻辑</td>
                                                        <td>检索项</td>
                                                        <td>操作符</td>
                                                        <td>检索词</td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td>
                                                            <asp:DropDownList ID="item1" runat="server">
                                                                <asp:ListItem Selected="True" Value="pinyin">题名</asp:ListItem>
                                                                <asp:ListItem Value="author">责任者</asp:ListItem>
                                                                <asp:ListItem Value="classno">分类号</asp:ListItem>
                                                                <asp:ListItem Value="publisher">出版社</asp:ListItem>
                                                                <asp:ListItem Value="keyword">主题词</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="op1" runat="server">
                                                                <asp:ListItem Selected="True">前方一致</asp:ListItem>
                                                                <asp:ListItem>完全匹配</asp:ListItem>
                                                                <asp:ListItem>任意匹配</asp:ListItem>
                                                                <asp:ListItem>不等于</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td><asp:TextBox ID="TextBox1" runat="server" Width="250px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="logic1" runat="server">
                                                                <asp:ListItem Value="AND">与</asp:ListItem>
                                                                <asp:ListItem Value="OR">或</asp:ListItem>
                                                                <asp:ListItem Value="AND NOT">非</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="item2" runat="server">
                                                                <asp:ListItem Value="pinyin">题名</asp:ListItem>
                                                                <asp:ListItem Selected="True" Value="author">责任者</asp:ListItem>
                                                                <asp:ListItem Value="classno">分类号</asp:ListItem>
                                                                <asp:ListItem Value="publisher">出版社</asp:ListItem>
                                                                <asp:ListItem Value="keyword">主题词</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="op2" runat="server">
                                                                <asp:ListItem Selected="True">前方一致</asp:ListItem>
                                                                <asp:ListItem>完全匹配</asp:ListItem>
                                                                <asp:ListItem>任意匹配</asp:ListItem>
                                                                <asp:ListItem>不等于</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox2" runat="server" Width="250px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="logic2" runat="server">
                                                                <asp:ListItem Value="AND">与</asp:ListItem>
                                                                <asp:ListItem Value="OR">或</asp:ListItem>
                                                                <asp:ListItem Value="AND NOT">非</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="item3" runat="server">
                                                                <asp:ListItem Value="pinyin">题名</asp:ListItem>
                                                                <asp:ListItem Value="author">责任者</asp:ListItem>
                                                                <asp:ListItem Value="classno">分类号</asp:ListItem>
                                                                <asp:ListItem Selected="True" Value="publisher">出版社</asp:ListItem>
                                                                <asp:ListItem Value="keyword">主题词</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="op3" runat="server">
                                                                <asp:ListItem Selected="True">前方一致</asp:ListItem>
                                                                <asp:ListItem>完全匹配</asp:ListItem>
                                                                <asp:ListItem>任意匹配</asp:ListItem>
                                                                <asp:ListItem>不等于</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox3" runat="server" Width="250px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="logic3" runat="server">
                                                                <asp:ListItem Value="AND">与</asp:ListItem>
                                                                <asp:ListItem Value="OR">或</asp:ListItem>
                                                                <asp:ListItem Value="AND NOT">非</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="item4" runat="server">
                                                                <asp:ListItem Value="pinyin">题名</asp:ListItem>
                                                                <asp:ListItem Value="author">责任者</asp:ListItem>
                                                                <asp:ListItem Selected="True" Value="classno">分类号</asp:ListItem>
                                                                <asp:ListItem Value="publisher">出版社</asp:ListItem>
                                                                <asp:ListItem Value="keyword">主题词</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="op4" runat="server">
                                                                <asp:ListItem Selected="True">前方一致</asp:ListItem>
                                                                <asp:ListItem>完全匹配</asp:ListItem>
                                                                <asp:ListItem>任意匹配</asp:ListItem>
                                                                <asp:ListItem>不等于</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox4" runat="server" Width="250px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="logic4" runat="server">
                                                                <asp:ListItem Value="AND">与</asp:ListItem>
                                                                <asp:ListItem Value="OR">或</asp:ListItem>
                                                                <asp:ListItem Value="AND NOT">非</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="item5" runat="server">
                                                                <asp:ListItem Value="pinyin">题名</asp:ListItem>
                                                                <asp:ListItem Value="author">责任者</asp:ListItem>
                                                                <asp:ListItem Value="classno">分类号</asp:ListItem>
                                                                <asp:ListItem Value="publisher">出版社</asp:ListItem>
                                                                <asp:ListItem Selected="True" Value="keyword">主题词</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="op5" runat="server">
                                                                <asp:ListItem Selected="True">前方一致</asp:ListItem>
                                                                <asp:ListItem>完全匹配</asp:ListItem>
                                                                <asp:ListItem>任意匹配</asp:ListItem>
                                                                <asp:ListItem>不等于</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox5" runat="server" Width="250px"></asp:TextBox>
                                                            <asp:Button ID="Button1" runat="server" Text="检索" OnClick="Button1_Click" /></td>
                                                    </tr>
                                                </table></div>
                                            <div>
                                        每页显示记录数：
                                            <asp:DropDownList ID="DropDownList2" runat="server">
                                                <asp:ListItem Selected="True">15</asp:ListItem>
                                                <asp:ListItem>20</asp:ListItem>
                                                <asp:ListItem>30</asp:ListItem>
                                                <asp:ListItem>50</asp:ListItem>
                                                <asp:ListItem>100</asp:ListItem>
                                            </asp:DropDownList>
                                            排序方式：
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
                                            <span style="display:none;">数据来源：<asp:DropDownList ID="DropDownList4" runat="server" Visible="false" /></span>
                                            </div>  
                             </div>
                            <div id="result2" style="display:block;">
                           
                            
                                         <asp:Panel ID="Panel1" runat="server" Height="2em" Width="100%" Visible="False">
                                                    <div class="results">
                                                        <asp:Label ID="Label2" runat="server"></asp:Label>&nbsp;
                                                    </div>
                                                </asp:Panel>
                                                <asp:UpdatePanel id="UpdatePanel2"  runat="server">
                                                    <contenttemplate>
                                        &nbsp;<cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                    AutoGenerateColumns="False" DataKeyNames="recid,bookno,title,author,publisher,pubdate,from" OnDataBinding="GridView1_DataBinding"
                                                    OnRowDataBound="GridView1_RowDataBound" OnDataBound="GridView1_DataBound" CellPadding="4"
                                                    ForeColor="#333333" GridLines="None" PagerType="CustomNumeric">
                                                    <PagerSettings FirstPageText="首页" LastPageText="尾页" NextPageText="后页" PreviousPageText="前页" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="全选"  HeaderStyle-HorizontalAlign="Left">
                                                            <HeaderTemplate>
                                                                <input id="CheckAll" type="checkbox" onclick="javascript:CheckAll(this);" title="选择全部" runat="server" HeaderStyle-HorizontalAlign="Left" />
                                                            
                                        </HeaderTemplate>
                                                            <ItemStyle Wrap="False" />
                                                            <ItemTemplate>
                                                             <input type="checkbox" value="<%# DataBinder.Eval(Container.DataItem,"recid")%>" />
                                                                <asp:CheckBox ID="CheckBox1"  Visible="False" onclick="javascript:hilightRow(this);" runat="server" />
                                                            
                                        </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="bookno" HeaderText="索书号"   HeaderStyle-HorizontalAlign="Left"/>
                                                        <asp:BoundField DataField="availableNum" HeaderText="可借" NullDisplayText="0"   HeaderStyle-HorizontalAlign="Left"/>
                                                        <asp:HyperLinkField DataTextField="title" HeaderText="题名" DataNavigateUrlFields="recid"
                                                            DataNavigateUrlFormatString="bookdetail.aspx?id={0}"   HeaderStyle-HorizontalAlign="Left"/>
                                                        <asp:HyperLinkField DataTextField="author" HeaderText="责任者" DataNavigateUrlFormatString="javascript:"   HeaderStyle-HorizontalAlign="Left">
                                                            <ControlStyle CssClass="handCursor" />
                                                        </asp:HyperLinkField>
                                                        <asp:HyperLinkField DataTextField="publisher" HeaderText="出版者"   HeaderStyle-HorizontalAlign="Left">
                                                            <ItemStyle CssClass="handCursor" />
                                                        </asp:HyperLinkField>
                                                        <asp:BoundField DataField="pubdate" HeaderText="出版日期"   HeaderStyle-HorizontalAlign="Left"/>
                                                        
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
                                                <asp:UpdateProgress id="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel2">
                                                    <progresstemplate>
                                                        <div id="loading">正在获取数据...</div>            
                                                    </progresstemplate>
                                                </asp:UpdateProgress>
                                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="尾页"
                                                    NextPageText="后页" OnPageChanged="AspNetPager1_PageChanged" PrevPageText="前页" Visible="False">
                                                </webdiyer:AspNetPager>
                                                <br />
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

