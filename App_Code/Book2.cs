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
/// 保存 recid 和 from 参数
/// 用于我的书单保存到 session 中
/// </summary>
[Serializable]
public class Book2
{
	private string id;
    private string from;

    private string bookno;
    private string title;
    private string author;
    private string publisher;
    private string pubdate;
    private string secret;

    public Book2()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public string From
    {
        get { return from; }
        set { from = value; }
    }

    public string Bookno
    {
        get { return bookno; }
        set { bookno = value; }
    }

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    public string Publisher
    {
        get { return publisher; }
        set { publisher = value; }
    }

    public string Pubdate
    {
        get { return pubdate; }
        set { pubdate = value; }
    }

    public string Secret
    {
        get { return secret; }
        set { secret = value; }
    }
}
