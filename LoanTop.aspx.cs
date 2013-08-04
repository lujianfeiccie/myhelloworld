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

public partial class LoanTop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LibWeb mylib = new LibWeb();
        mylib.WebDataOpen();
        SqlDataReader reader = mylib.GetDepLoanTop(0, DateTime.Parse("2009-9-1"), DateTime.Now);
        loan_list_all.DataSource = reader;
        loan_list_all.DataBind();
        reader.Close();
        mylib.WebDataClose();
    }
}
