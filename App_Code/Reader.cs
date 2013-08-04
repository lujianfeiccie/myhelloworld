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
/// 
/// </summary>
[Serializable]
public class Reader
{
    private string codebar;
    private string name;
    private string unit;

    public Reader()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public string ReaderCodebar
    {
        get { return codebar; }
        set { codebar = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Unit
    {
        get { return unit; }
        set { unit = value; }
    }

}
