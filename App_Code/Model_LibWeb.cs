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
/// Model_LibWeb 的摘要说明
/// </summary>
public class Model_LibWeb
{
    private string title;
    private string type;
    private string content;
	public Model_LibWeb()
	{
		 
	}
    public string Title
    {
        set { title = value; }
        get { return title; }
    }
    public string Type
    {
        set { type = value; }
        get { return type; }
    }
    public string Content
    {
        set { content = value; }
        get { return content; }
    }
}
