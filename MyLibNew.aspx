<%@ Page Language="C#" MasterPageFile="~/AllPage2.master" AutoEventWireup="true" CodeFile="MyLibNew.aspx.cs" Inherits="MyLibNew" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="content_left_guid">
            <div id="content_left_guid_head"></div>
            
                <a href="MyLib.aspx"><div class="content_left_guid_item_on" >借阅信息</div></a>    
                <a href="MySearch.aspx"><div class="content_left_guid_item" >图书查询</div> </a>   
                 <a href="Myhistory.aspx"><div class="content_left_guid_item" >借阅历史</div> </a>       
                  <a href="BookOrder.aspx"  style="display:none;"><div class="content_left_guid_item" >图书预约</div> </a>     
                <a href="MyFavorite.aspx"><div class="content_left_guid_item" >我的收藏</div> </a>  
                <a href="BooKBuy.aspx"><div class="content_left_guid_item" >图书荐购</div> </a>        
                 <a href="MyInfo.aspx"><div class="content_left_guid_item" >个人信息</div> </a> 
                 <a href="MyMail.aspx"><div class="content_left_guid_item" >我的信件</div> </a>   
                 <a href="LoginNew.aspx?act=out"><div class="content_left_guid_item" >退出登录</div> </a>     
            
        </div>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">借阅信息</span><span class="head_right" id="sitemap" >当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;<a href="MyLib.aspx">我的图书馆</a>&nbsp;<img src="images/next.jpg" />&nbsp;借阅信息</span></div>
                <div style="line-height:20px;" id="myrenew"></div>
              <table style="width:100%;" id="myborrow2">
              <tr style="background-color:#ececec;"><th>选择</th><th>图书名称</th><th>图书条码</th><th>索书号</th><th>到期时间</th><th>续借状态</th></tr>
                  <asp:Repeater ID="myborrow" runat="server">
                  <ItemTemplate>
                  <tr style="background-color:#ffffff;"><td><input name="choosecheck" value="<%# DataBinder.Eval(Container.DataItem, "_图书条码")%>" type="checkbox"/><td><%# DataBinder.Eval(Container.DataItem,"_题名")%></td><td><%# DataBinder.Eval(Container.DataItem, "_图书条码")%></td><td><%# DataBinder.Eval(Container.DataItem, "_分类")%></td><td><%# ColorDate(DateTime.Parse( DataBinder.Eval(Container.DataItem, "_应还日期").ToString()))%></td><td><%# DataBinder.Eval(Container.DataItem, "_续借标识")%></td></tr>
                  </ItemTemplate>
                  <AlternatingItemTemplate>
                   <tr style="background-color:#eeeeee;"><td><input name="choosecheck"  value="<%# DataBinder.Eval(Container.DataItem, "_图书条码")%>" type="checkbox"/><td><%# DataBinder.Eval(Container.DataItem,"_题名")%></td><td><%# DataBinder.Eval(Container.DataItem, "_图书条码")%></td><td><%# DataBinder.Eval(Container.DataItem, "_分类")%></td><td><%# ColorDate(DateTime.Parse( DataBinder.Eval(Container.DataItem, "_应还日期").ToString()))%></td></td><td><%# DataBinder.Eval(Container.DataItem, "_续借标识")%></td></tr>
                  
                  </AlternatingItemTemplate>
                  </asp:Repeater>
                  <tr><td><input type="checkbox" onclick="chooseall();" /></td><td><input onclick="delaybook();" type="button" value="续借选中图书" /></td></tr>
              </table>
              
        </div>
        
  <script type="text/javascript" language="javascript">
  var userborrowchooseall=0;
  function chooseall()
  {
        if(userborrowchooseall==0)
             {$(":checkbox").attr("checked","checked");userborrowchooseall=1;}
        else 
            {$(":checkbox").attr("checked","");userborrowchooseall=0;}
  }
  
  function delaybook()
  {
    var str="";

    $("[name='choosecheck'][checked]").each(function()
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
    else
    {
         $.ajax({ type:"Get",
           url: "DelayBook.aspx",
           cache: false,
           data:"ids="+str+"&act=delay",
           success: function(data){
                  $("#myrenew").html(data);
           }
        }); 
      }
    
  }
  
  
  </script>
</asp:Content>

