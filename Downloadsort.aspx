<%@ Page Language="C#" MasterPageFile="~/AllPage2.master" AutoEventWireup="true" CodeFile="Downloadsort.aspx.cs" Inherits="Downloadsort" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!--把下面代码加到<head>与</head>之间-->
    <style type="text/css">
        *
        {
            font-family: simsun;
            margin: 0px;
            padding: 0px;
        }
        body
        {
            font-size: 12px;
            text-align: center;
        }
        ul, li
        {
            list-style: none;
        }
        a
        {
            text-decoration: none;
            color: #3381BF;
        }
        a:hover
        {
            text-decoration: underline;
        }
        #movie_rank
        {
            height: 260px;
        }
        .box2
        {
            border: 1px solid #ADDFF2;
            text-align: left;
            overflow: hidden;
            color: #9C9C9C;
            text-align: left;
        }
        .box2
        {
            margin-bottom: 7px;
        }
        .box2 h2
        {
            background: #EEF7FE;
            height: 21px;
            line-height: 21px;
            overflow-y: hidden;
            border-bottom: 1px solid #ADDFF2;
            color: #1974C8;
            font-size: 12px;
            padding: 0px 8px;
        }
        .box2 h2 a.more
        {
            float: right;
            text-decoration: underline;
            background: url() no-repeat 100% -123px;
            padding-right: 8px;
            font-weight: normal;
        }
        .box2 h2 span
        {
            margin-left: 5px;
            font-weight: normal;
            color: #B9B7B8;
        }
        .box2 .inner
        {
            padding: 8px;
            line-height: 18px;
            overflow: hidden;
            color: #3083C7;
        }
        .box2 a
        {
            color: #3083C7;
            white-space: nowrap;
        }
        .rank_list
        {
            line-height: 24px;
            margin: auto;
            padding-top: 5px;
        }
        .rank_list li
        {
            height: 24px;
            margin-bottom: 8px;
            width: 290px;
            padding-left: 20px;
            white-space: nowrap;
            overflow: hidden;
            position: relative;
        }
        .rank_list li.top3 em
        {
            background: #FFE4B7;
            border: 1px solid #FFBB8B;
            color: #FF6800;
        }
        .rank_list em
        {
            position: absolute;
            left: 0;
            top: 0;
            width: 12px;
            height: 12px;
            border: 1px solid #B1E0F4;
            color: #6298CC;
            font-style: normal;
            font-size: 10px;
            font-family: Arial;
            background: #E6F0FD;
            text-align: center;
            line-height: 12px;
            overflow: hidden;
        }
        .rank_list span
        {
            position: absolute;
            width: 60px;
            color: #B7B7B7;
            text-align: right;
            height: 14px;
            background: #fff;
            left: 110px;
        }
        #movie_rank .rank_list span
        {
            position: absolute;
            width: 40px;
            color: #B7B7B7;
            text-align: right;
            height: 14px;
            background: #fff;
            left: 260px;
        }
    </style>
  <!--把下面代码加到<body>与</body>之间-->
    <div class="box2" id="movie_rank">
        <h2 style="text-align:left">
           下载排行</h2>
        <div class="inner">
            <ul class="rank_list">
                <asp:Repeater ID="download_sort" runat="server">
                <ItemTemplate>
                <%#Convert.ToInt16(DataBinder.Eval(Container.DataItem, "rownum").ToString())<=3 ? "<li class='top3'>" : "<li>"%>
                 <em><%# DataBinder.Eval(Container.DataItem,"rownum")%></em><a href="DownloadViewNew.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id")%>"><%# DataBinder.Eval(Container.DataItem,"title")%></a>
                 <span><%# DataBinder.Eval(Container.DataItem,"down_num")%></span>
                </li>
                </ItemTemplate>
                </asp:Repeater>                
            </ul>
        </div>
    </div>
</asp:Content>

