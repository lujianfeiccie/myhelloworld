<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="MyFavorite.aspx.cs" Inherits="MyFavorite" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="content_left_guid">
            <div id="content_left_guid_head"></div>
            
                <a href="MyLib.aspx"><div class="content_left_guid_item" >我的图书馆</div></a> 
                <a href="MySearch.aspx"><div class="content_left_guid_item" >图书查询</div> </a>       
                 <a href="Myhistory.aspx"><div class="content_left_guid_item" >借阅历史</div> </a>       
                  <a href="BookOrder.aspx"  style="display:none;"><div class="content_left_guid_item" >图书预约</div> </a>     
                <a href="MyFavorite.aspx"><div class="content_left_guid_item_on" >我的收藏</div> </a>  
                <a href="BooKBuy.aspx"><div class="content_left_guid_item" >图书荐购</div> </a>        
                 <a href="MyInfo.aspx"><div class="content_left_guid_item" >个人信息</div> </a> 
                  <a href="MyMail.aspx"><div class="content_left_guid_item" >我的信件</div> </a>       
                  <a href="Login.aspx?act=out"><div class="content_left_guid_item" >退出登录</div> </a>     
            
        </div>
        <div id="content_center_info">
        
               <div id="content_center_info_head"><span class="head_title" id="title1" runat="server">我的书单</span><span class="head_right" id="sitemap" >当前位置：<a href="Default.aspx">主页</a>&nbsp;<img src="images/next.jpg" />&nbsp;<a href="MyLib.aspx">我的图书馆</a>&nbsp;<img src="images/next.jpg" />&nbsp;我的书单</span></div>

              <table style="width:100%;" id="myborrow">
              
             <tr style="background-color:#ececec;"><th><input type="checkbox" onclick="chooseall();" />全选</th><th>索书号</th><th>可借本</th><th>题名</th><th>责任者</th><th>出版社</th><th>出版日期</th></tr>
                  <asp:Repeater ID="myfavoritelist" runat="server">
                  <ItemTemplate>
                  <tr style="background-color:#ffffff;">
                        <td><input type="checkbox" value="<%# DataBinder.Eval(Container.DataItem,"id")%>"/></td>
                         <td><%# DataBinder.Eval(Container.DataItem,"_分类")%></td><td><%# DataBinder.Eval(Container.DataItem,"_复本")%></td>
                        <td><a href="BookDetail.aspx?id=<%# DataBinder.Eval(Container.DataItem,"recid")%>" target="_blank"><%# DataBinder.Eval(Container.DataItem,"_题名")%></a> </td>
                     <td><%# DataBinder.Eval(Container.DataItem,"_责任者")%></td><td><%# DataBinder.Eval(Container.DataItem,"_出版者")%></td><td><%# DataBinder.Eval(Container.DataItem,"_出版日期")%></td>
                   </tr>
                  </ItemTemplate>
                  <AlternatingItemTemplate>
                   <tr style="background-color:#eeeeee;">
                            <td><input type="checkbox" value="<%# DataBinder.Eval(Container.DataItem,"id")%>"/></td>
                         <td><%# DataBinder.Eval(Container.DataItem,"_分类")%></td><td><%# DataBinder.Eval(Container.DataItem,"_复本")%></td>
                        <td><a href="BookDetail.aspx?id=<%# DataBinder.Eval(Container.DataItem,"recid")%>" target="_blank"><%# DataBinder.Eval(Container.DataItem,"_题名")%></a> </td>
                     <td><%# DataBinder.Eval(Container.DataItem,"_责任者")%></td><td><%# DataBinder.Eval(Container.DataItem,"_出版者")%></td><td><%# DataBinder.Eval(Container.DataItem,"_出版日期")%></td>
                   
                   
                   </tr>
                  
                  </AlternatingItemTemplate>
                  </asp:Repeater>
                  
              </table>
             <input type="button" value="删除选中的收藏" onclick="deleteall();" />
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
function deleteall()
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
           data:"act=delete&ids="+str,
           success: function(data){
                if(data=="ok")
                {
                    alert("成功删除");
                    location.href="Myfavorite.aspx";
                }
                else{alert(data);}
                
            }}); 
    
    
    }
}
</script>
</asp:Content>

