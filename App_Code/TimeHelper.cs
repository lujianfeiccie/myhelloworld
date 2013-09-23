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
/// TimeHelper 的摘要说明
/// </summary>
public class TimeHelper
{
	public static string getStringTime()
	{
        return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
	}
}
