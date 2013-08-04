<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="SearchBooks.aspx.cs" Inherits="SearchBooks" Title="Untitled Page" %>

<%@ Register Assembly="MyGridView" Namespace="milnets.search" TagPrefix="cc1" %>
<%@ Register Src="~/Contrl/PageNum.ascx" TagName="pagelist" TagPrefix="ucl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="Calendar/WdatePicker.js"></script>
<div id="content_left_guid">
            <div id="content_left_guid_head" style=" padding-left:30px; padding-top:10px; font-size:13px; color:White; font-weight:bold;">书目检索</div>
            <div style="height:26px; margin:12px 0px 2px 0px; text-align:center;"><span style="background-color:yellow; padding:4px 5px 4px 5px; font-weight:bold;">热门搜索</span></div>
            <div class="hot_search" >
             <asp:Repeater ID="top10" runat="server">
                    <ItemTemplate>
                        <span class="search_hot_word"  onclick="$('#keyword1').val('<%# DataBinder.Eval(Container.DataItem,"keyword")%>');SearchAjax(1,'<%# DataBinder.Eval(Container.DataItem,"keyword")%>','type=simple&orderlist=title&ordertype=desc&mode=0&jsfs=title&pagesize=20');"><%# DataBinder.Eval(Container.DataItem,"keyword")%>&nbsp;(<%# DataBinder.Eval(Container.DataItem,"all_num")%>)</span>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
             
            
        </div>
        <div id="content_center_info">
        
             
               <div class="search_control">
                    <div class="search_control_head" id="change_head"><span class="change_head_on" onclick="changeblockhead('change_head',1,'change_head_on');changeblock('content_center_info',1,'change_info');" id="change_head1">简单检索</span><span onclick="changeblockhead('change_head',2,'change_head_on');changeblock('content_center_info',2,'change_info');" id="change_head2"  class="change_head">多字段检索</span></div>
                    <div class="change_info" style="display:block;" id="change_info1">
                        <div style=" font-weight:bold;">馆藏书目检索</div>
                        <div><input type="text" id="keyword1" style="width: 315px" /> <input id="Button1" onclick="Search1();" type="button" value="检索" /></div>
                        <div>热门检索：
                                 <asp:Repeater ID="all_hot_search" runat="server">
                                <ItemTemplate>
                                    <span class="all_hot_word" onclick="$('#keyword1').val('<%# DataBinder.Eval(Container.DataItem,"keyword")%>');SearchAjax(1,'<%# DataBinder.Eval(Container.DataItem,"keyword")%>','type=simple&orderlist=title&ordertype=desc&mode=0&jsfs=title&pagesize=20');"><%# DataBinder.Eval(Container.DataItem,"keyword")%>&nbsp;(<%# DataBinder.Eval(Container.DataItem,"all_num")%>)</span>
                                </ItemTemplate>
                                </asp:Repeater>
                        </div>
                        <div class="other_option">
                            <div>请选择检索方式：<select name="jsfs1"><option value="title" selected="selected">题名</option><option value="author">责任者</option><option value="classno">分类号</option><option value="publisher">出版社</option><option value="keyword">主题词</option></select></div>
                            <div>请选择检索模式：<input name="search_mode1" type="radio" value="1"/>完全匹配<input name="search_mode1" type="radio" value="0"  checked="checked" />任意匹配</div>
                            <div>每页显示记录数：<select name="displaynum1"><option value="10">10</option><option value="20" selected="selected">20</option><option value="30">30</option><option value="40">40</option><option value="50">50</option></select></div>
                            <div>结果排序方式以：<select name="orderlist1"><option value="createdate" selected="selected">入藏日期</option><option value="title">题名</option><option value="author">责任者</option><option value="pubdate">出版日期</option><option value="classno">分类号</option><option value="bookno">索书号</option></select><input type="radio" name="downup1" value="asc" />升序排列<input type="radio" value="desc" name="downup1" checked="checked" />降序排列</div>
                        </div>
                        <div id="result1">
                            <cc1:MyGridView ID="MyGridView1" runat='server'>
                            
                            </cc1:MyGridView>
                        </div>
                    </div>
                    <div class="change_info" id="change_info2">
                             <div style=" font-weight:bold;">馆藏多字段检索</div>
                             <div> <table style="border:0px;" cellpadding="0" cellspacing="0" >
                                    <tr><td style="width:274px; text-align:left;">题&nbsp;&nbsp;&nbsp;&nbsp;名：<input style="width:200px;" id="title2" type="text" name="title" /></td><td style="width: 83px; text-align:right;">出版社：</td><td><input type="text" id="publisher2" style="width:200px;" /></td></tr>
                                    <tr><td style="text-align:left;">责任者：<input style="width:200px;" type="text" id="author2" /></td><td style="text-align:right;">分类号：</td><td><input type="text" id="classno2" style="width:200px;" /></td></tr>
                                    <tr><td style="text-align:left;">主题词：<input style="width:200px;" type="text" id="keyword2" /></td><td style="text-align:right;"></td><td style="text-align:right;"><input type="button" name="searcit" onclick="Search2();" value="检索" /><input style="margin-left:20px;" type="reset" value="重置" /></td></tr>
                                </table></div>
                             <div class="other_option">
                                <div>请选择检索模式：<input name="search_mode2" type="radio" value="1" checked="checked"/>全部一致<input name="search_mode2" type="radio" value="0" />任意匹配</div>
                                <div>每页显示记录数：<select name="displaynum2"><option value="10">10</option><option value="20" selected="selected">20</option><option value="30">30</option><option value="40">40</option><option value="50">50</option></select></div>
                                <div>结果排序方式以：<select name="orderlist2"><option value="addtime" selected="selected">入藏日期</option><option value="title">题名</option><option value="author">责任者</option><option value="pubtime">出版日期</option><option value="classno">分类号</option><option value="bookno">索书号</option></select><input type="radio" name="downup2" value="up" />升序排列<input type="radio" value="down" name="downup2" checked="checked" />降序排列</div>
                            </div>
                            <div id="result2">
                            
                            </div>
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
    function Search1()
    {
         var keyword=$("#keyword1").val();
         var jsfs=$("[name=jsfs1]").val();
         var mode=$("[name=search_mode1]:checked").val();
         var displynum=$("[name=displaynum1]").val();
         var orderlist=$("[name=orderlist1]").val();
         var ordertype=$("[name=downup1]:checked").val();
         if(keyword=="")
            {
                alert("请输入关键词");
                $("#keyword1").focus();
            }
         else
         {
           $.ajax({ type:"Get",
           url: "SearchBookAjax.aspx",
           cache: false,
           data:"type=simple&jsfs="+jsfs+"&keyword="+escape(keyword)+"&mode="+mode+"&pagesize="+displynum+"&orderlist="+orderlist+"&ordertype="+ordertype,
           beforeSend:function(){ $("#result1").html("<img src='Images/progress.gif' width='18' height='18' />正在链接服务器..."); },
           success: function(data){ $("#result1").html(data); }}); 
         }
        
    }
    
    
     function Search2()
    {
         var title=$("#title2").val();
         var author=$("#author2").val();
         var publisher=$("#publisher2").val();
         var keyword=$("#keyword2").val();
         var classno=$("#classno2").val();
         
         
         var mode=$("[name=search_mode2]:checked").val();
         var displynum=$("[name=displaynum2]").val();
         var orderlist=$("[name=orderlist2]").val();
         var ordertype=$("[name=downup2]:checked").val();
         if(title==""&&author==""&&publisher==""&&keyword==""&classno=="")
            {
                alert("请输入至少一个条件关键词");
                $("#title2").focus();
            }
         else
         {
           $.ajax({ type:"Get",
           url: "SearchBookAjax.aspx",
           cache: false,
           data:"type=complex&keyword="+escape(keyword)+"&title="+escape(title)+"&author="+escape(author)+"&publisher="+escape(publisher)+"&classno="+escape(classno)+"&mode="+mode+"&pagesize="+displynum+"&orderlist="+orderlist+"&ordertype="+ordertype,
           beforeSend:function(){ $("#result2").html("<img src='Images/progress.gif' width='18' height='18' />正在链接服务器..."); },
           success: function(data){ $("#result2").html(data); }}); 
         }
        
    }
    function SearchAjax(pagenum,keyword,paras)
    {
        var myparas=paras.replace("&amp;","&");
       // alert(myparas);
        $.ajax({ type:"Get",
           url: "SearchBookAjax.aspx",
           cache: false,
           data:"keyword="+escape(keyword)+"&nowpage="+pagenum+"&"+myparas,
           beforeSend:function(){ $("#result1").html("<img src='Images/progress.gif' width='18' height='18' />正在链接服务器..."); },
           success: function(data){ $("#result1").html(data); }}); 
    }
    function SearchAjax2(pagenum,keyword,title,author,publisher,paras)
    {
        var myparas=paras.replace("&amp;","&");
       // alert(myparas);
        $.ajax({ type:"Get",
           url: "SearchBookAjax.aspx",
           cache: false,
           data:"keyword="+escape(keyword)+"&nowpage="+pagenum+"&"+myparas+"&title="+escape(title)+"&author="+escape(author)+"&publisher="+escape(publisher),
           beforeSend:function(){ $("#result2").html("<img src='Images/progress.gif' width='18' height='18' />正在链接服务器..."); },
           success: function(data){ $("#result2").html(data); }}); 
    }
 </script>
</asp:Content>
