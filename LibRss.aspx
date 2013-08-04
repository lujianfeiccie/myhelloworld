<%@ Page Language="C#" MasterPageFile="~/AllPage.master" AutoEventWireup="true" CodeFile="LibRss.aspx.cs" Inherits="LibRss" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-size:15px; background-color:#efefef; height:30px; padding-top:10px; padding-left:30px; font-weight:bold;">RSS 订阅</div>
    <div class="feature" style="padding-left:40px;font-size:14px;">
        <strong >
            
            <br />        
            <img src="images/search_rss.gif" alt="rss icon" />
            <a href="rssbooks.ashx">订阅最近上架新书</a><br />
            <br />
            <img src="images/search_rss.gif" alt="rss icon" />
            <a href="rssjournals.ashx">订阅期刊信息</a><br />
            <br />
            <img src="images/search_rss.gif" alt="rss icon" />
            <a href="rssprediction.ashx">订阅超期预警</a><br />
            <br />
            <img src="images/search_rss.gif" alt="rss icon" />
            <a href="rssordered.ashx">订阅新订购图书</a><br />
            <br />
            <img src="images/search_rss.gif" alt="rss icon" />
            <a href="rssbibing.ashx">订阅正在编目图书</a><br />
        </strong>
        <br />
    </div>
</asp:Content>

