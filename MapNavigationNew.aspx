<%@ Page Language="C#" MasterPageFile="~/AllPage2.master" AutoEventWireup="true" CodeFile="MapNavigationNew.aspx.cs"
    Inherits="MapNavigationNew" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <table cellspacing="0" cellpadding="0" width="1000" align="center" border="0">
        <tr>
            <td valign="top" align="right" width="175" bgcolor="#ffffff" height="362">
            </td>
            <td align="left" width="825" bgcolor="#ffffff">
                <table cellspacing="0" cellpadding="0" width="716" border="0">
                    <tr>
                        <td class="head_title" valign="top"  style="text-align:center" width="716" height="47">
                            <span class="left_block_head head_title">本站地图</span>
                        </td>
                    </tr>
                     
                    <tr>
                        <td style="text-align:center" align="left" height="145">
                            <div align="left">
                                &nbsp;&nbsp;&nbsp;&nbsp;<table height="474" cellspacing="0" cellpadding="0" width="70%"
                                    border="0">
                                    <tr>
                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" valign="top">
                                            <div align="center">
                                                <table  height="487" cellspacing="0" cellpadding="0" width="778" border="0">
                                                    <tr>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" width="52"
                                                            height="121">
                                                        </td>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" valign="top"
                                                            align="left" width="84" height="121">
                                                            <font size="2">[本馆概况]</font></td>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" valign="top"
                                                            align="left" width="214" height="121">
                                                            <span id="ChannelList1" title="馆藏分布"><a href="ViewPages.aspx?type=jj"
                                                                target="_self">图书馆简介</a></span>
                                                            <p>
                                                                <span id="ChannelList4"><a href="ViewPages.aspx?type=zn" target="_self"><span
                                                                    title="本人借阅查询">部门指南</span></a></span></p>
                                                            <p>
                                                                <span id="ChannelList5"><a href="ViewPages.aspx?type=fc"
                                                                    target="_self"><span title="借阅规则">图书馆风采</span></a></span></p>
                                                            
                                                        </td>
                                                         
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" width="52"
                                                            height="122">
                                                        </td>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" valign="top"
                                                            align="left" width="84" height="122">
                                                            <font size="2">[读者服务]</font></td>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" valign="top"
                                                            align="left" width="214" height="122">
                                                            <span id="ChannelList7"><a href="ViewPages.aspx?type=xz1"
                                                                target="_self"><span title="入馆须知">入馆须知</span></a></span>
                                                            <p>
                                                                <span id="ChannelList9"><a href="ViewPages.aspx?type=xz2"
                                                                    target="_self"><span title="入室须知">入室须知</span></a></span></p>
                                                            <p>
                                                                <span id="ChannelList12"><a href="ViewPages.aspx?type=sj"
                                                                    target="_self"><span title="服务时间">服务时间</span></a><br/>
                                                                    <br/>
                                                                </span>
                                                            </p>
                                                        </td>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" valign="top"
                                                            align="left" width="214" height="122">
                                                            <span id="ChannelList8"><a href="ViewPages.aspx?type=zd"
                                                                target="_self"><span title="借阅制度">借阅制度</span></a></span>
                                                            <p>
                                                                <span id="ChannelList10"><a href="ViewPages.aspx?type=lc"
                                                                    target="_self"><span title="借阅流程">借阅流程</span></a></span></p>
                                                        </td>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" valign="top"
                                                            align="left" width="214" height="122">
                                                            <a href="ViewPages.aspx?type=zd2">借书卡发放制度</a>
                                                            <p>
                                                                <span id="ChannelList11"><a href="ViewPages.aspx?type=sy"
                                                                    target="_self"><span title="特种资源">服务项目</span></a></span></p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" width="52"
                                                            height="122">
                                                        </td>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" valign="top"
                                                            align="left" width="84" height="122">
                                                            <font size="2">[书目查询]</font></td>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" valign="top"
                                                            align="left" width="214" height="122">
                                                            <span id="ChannelList13"><a href="BookSearch.aspx"
                                                                target="_self"><span title="馆藏书目检索">馆藏书目检索</span></a></span>
                                                            <p>
                                                                <span id="ChannelList16"><a href="BookList.aspx" target="_self">
                                                                    <span title="新书发布">新书发布</span></a></span></p>
                                                            <p>
                                                                <span id="ChannelList18"><a href="PaperSearch.aspx"
                                                                    target="_self"><span title="馆藏期刊检索">馆藏期刊检索</span></a><br/>
                                                                    <br/>
                                                                </span>
                                                            </p>
                                                        </td>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" valign="top"
                                                            align="left" width="214" height="122">
                                                            <span id="ChannelList14"><a href="CDSearch.aspx" target="_self"><span title="科技查新">
                                                                随书光盘</span></a></span> <span id="ChannelList17" title="随书光盘"><a href="../../../xxfw/Document/365/365.html">
                                                          </td>
                                                       </tr> 
                                                    <tr>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" width="52"
                                                            height="122">
                                                        </td>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" valign="top"
                                                            align="left" width="84" height="122">
                                                            <font size="2">[电子资源]</font></td>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" valign="top"
                                                            align="left" width="214" height="122">
                                                            <font size="2"><a href="LibZYPage.aspx?type=ts">本校特色资源</a></font>
                                                            <p>
                                                                <span id="ChannelList21"><a href="LibZYPage.aspx?type=js"
                                                                    target="_self"><span title="开馆时间">军事电子资源</span></a></span></p>
                                                            <p>
                                                                <span id="ChannelList23"><a href="LibZYPage.aspx?type=gg"
                                                                    target="_self"><span title="联系我们">公共电子资源</span></a></span></p>
                                                        </td>
                                                    </tr>
												  <tr>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" width="52"
                                                            height="122">
                                                        </td>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" valign="top"
                                                            align="left" width="84" height="122">
                                                            <font size="2">[互动专区]</font></td>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" valign="top"
                                                            align="left" width="214" height="122">
                                                            <font size="2"><a href="NoteList.aspx?type=zx">在线咨询</a></font>
                                                            <p>
                                                                <span id="Span1"><a href="NoteList.aspx?type=mail"
                                                                    target="_self"><span title="馆长信箱">馆长信箱</span></a></span></p>
                                                            <p>
                                                                <span id="Span2"><a href="NoteList.aspx?type=dc"
                                                                    target="_self"><span title="在线调查">在线调查</span></a></span></p>
                                                        </td>
                                                    </tr>
													 <tr>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" width="52"
                                                            height="122">
                                                        </td>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" valign="top"
                                                            align="left" width="84" height="122">
                                                            <font size="2">[参考咨询]</font></td>
                                                        <td style="font-size: 12px; color: #494848; line-height: 22px; font-family: 宋体" valign="top"
                                                            align="left" width="214" height="122">
                                                            <font size="2"><a href="DownloadList.aspx">常见问题</a></font>
                                                            <p>
                                                                <span id="Span3"><a href="NewsList.aspx?type=px"
                                                                    target="_self"><span title="读者培训">读者培训</span></a></span></p>
                                                            <p>
                                                                <span id="Span4"><a href="DownloadList.aspx?type=download"
                                                                    target="_self"><span title="软件下载">软件下载</span></a></span></p>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </asp:Content>
