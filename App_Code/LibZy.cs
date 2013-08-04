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
/// LibZy 用于各种资源链接
/// </summary>
public class LibZy
{
    private string title;
    private string id;
    private string info;
    private string typname;
    private int order;
    private string url;
    private bool isindex;//首页是否显示
    private bool isnew;
    private bool ishot;

    public string Title
    {
        get{return title;}
        set{title=value;}
    }
    public string ID
    {
        get{return id;}
        set{id=value;}
    }

    public string Description
    {
        get{return info;}
        set{info=value;}
    }

    public string TypeName
    {
        get { return typname; }
        set { typname = value; }
    }
    public int OrderList
    {
        get { return order; }
        set { order = value; }
    }
    public string Url
    {
        get { return url; }
        set { url = value; }
    }
    public bool IsIndex
    {
        get { return isindex; }
        set { isindex = value; }
    }
    public bool IsNew
    {
        set { isnew = value; }
        get { return isnew; }
    }
    public bool IsHot
    {
        set { ishot = value; }
        get { return ishot; }
    }
	public LibZy()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
}
