using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class AllPage : System.Web.UI.MasterPage
{
    public LibWeb mylib = new LibWeb();
    protected void Page_Load(object sender, EventArgs e)
    {
        mylib.WebDataOpen();
        mylib.GetInfo();
        mylib.WebDataClose();
        Page.Title = mylib.Title;
        HtmlHead pagehead = (HtmlHead)Page.Header;//首先把Page.Header转换成HtmlHead
        HtmlMeta PageMeta1 = new HtmlMeta();
        HtmlMeta PageMeta2 = new HtmlMeta();
        PageMeta1.Name = "keywords";
        PageMeta1.Content=mylib.KeyWord;
        PageMeta2.Name = "description";
        PageMeta2.Content = mylib.Description;
        pagehead.Controls.Add(PageMeta1);
        pagehead.Controls.Add(PageMeta2);
       
    }
}
