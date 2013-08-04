using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Links 的摘要说明
/// </summary>
public class Links
{
    private string title;
    private string id;
    private string url;
    private string pic;//链接图片的网络地址
    private string link_type;
    private int orderlist;

    public string LinkTitle
    {
        get { return title; }
        set { title = value; }
    }
    public string LinkID
    {
        get { return id; }
        set { id = value; }
    }
    public string LinkType
    {
        get { return link_type; }
        set { link_type = value; }
    }
    public int OrderList
    {
        get { return orderlist; }
        set { orderlist = value; }
    }
    public string LinkURL
    {
        set { url = value; }
        get { return url; }
    }
    public string LinkPIC
    {
        get { return pic; }
        set { pic = value; }
    }
	public Links()
	{
        title = "";
        url = "";
        pic = "";
        link_type = "xnzy";
        orderlist = 0;
        //
		// TODO: 在此处添加构造函数逻辑
		//
	}

}
