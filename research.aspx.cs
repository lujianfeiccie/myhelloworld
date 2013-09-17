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
using System.Data.SqlClient;
public partial class research : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       LibWeb mylib = new LibWeb();
        mylib.WebDataOpen();
        //投票
        Vote libvote = mylib.GetVoteOptions("1");
        lib_vote.InnerHtml = "<li><strong>" + libvote.Title + "</strong></li>";
        for (int i = 0; i < libvote.Options.Length; i++)
        {
            if (libvote.Options[i] != "")
                lib_vote.InnerHtml += "<li><input type=\"radio\" name=\"web_vote_value\" value=\"" + libvote.OptionsID[i] + "\" />" + libvote.Options[i] + "</li>";
        }
        lib_vote.InnerHtml += "<li><img onclick=\"vote();\" src=\"Images/vote.gif\" />&nbsp;&nbsp;<img onclick=\"viewvote();\" src=\"images/view.gif\" /></li>";
        mylib.WebDataClose();
    }
}
