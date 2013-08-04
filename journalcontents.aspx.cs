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
using System.Collections.Generic;

public partial class journalcontents : System.Web.UI.Page
{
    private string connString = "";
    private string sbid = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBString"].ConnectionString;
        //TODO 合法性验证，用户可能手动更改 URL
        if (Request.QueryString["id"] == null || Request.QueryString["id"].Trim().Length == 0)
        {
            Response.Redirect("PaperSearch.aspx");
        }
        else
        {
            sbid = Request.QueryString["id"];
        }
        BindData();
        checkMyBookList();
        showImage();
    }

    private void BindData()
    {
        string Q = "'";
        string sqlContents = "SELECT * FROM j_ContentText WHERE SignBoxID = " + Q + sbid + Q;
        string sqlImage = "SELECT * FROM j_ContentImage WHERE SignBoxID = " + Q + sbid + Q;
        string sqlNotAvailable = "SELECT * FROM vj_urge WHERE SignBoxID = " + Q + sbid + Q;

        GetData(sqlContents, sqlImage, sqlNotAvailable);
    }

    private void GetData(string sqlContents, string sqlImage, string sqlNotAvailable)
    {
        SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlContents, connString);
        SqlDataAdapter dataAdapter1 = new SqlDataAdapter(sqlImage, connString);
        SqlDataAdapter dataAdapter2 = new SqlDataAdapter(sqlNotAvailable, connString);

        DataSet dataSet = new DataSet();

        dataAdapter.Fill(dataSet, "contents");
        dataAdapter1.Fill(dataSet, "available");
        dataAdapter2.Fill(dataSet, "notavailable");

        DataTable dataTableContents = dataSet.Tables["contents"];
        DataTable dataTableAvailable = dataSet.Tables["available"];
        DataTable dataTableNotAvailable = dataSet.Tables["notavailable"];

        GridView1.DataSource = dataTableContents;
        GridView1.DataBind();
    }

    private void checkMyBookList()
    {
        if (Session["IDS"] != null && ((List<Book>)Session["IDS"]).Count > 0)
        {
            Label1.Text = "(" + ((List<Book>)Session["IDS"]).Count.ToString() + ")";
        }
    }

    private void showImage()
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string queryString = "SELECT * FROM j_ContentImage WHERE SignBoxID = '" + sbid + "'";
                SqlCommand command = new SqlCommand(queryString, conn);
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                Table table = new Table();
                TableRow row = new TableRow();
                table.CssClass = "imagetable";
                int i = 0;

                // Call Read before accessing data.
                while (reader.Read())
                {
                    string id = reader["ID"].ToString();

                    Image image = new Image();
                    image.CssClass = "imagecontents";
                    //image.ID = "image" + id;
                    image.BorderWidth = 2; //必须在这里指定，否则会自动生成 width: 0，覆盖 css 的设定
                    image.Width = 250;
                    image.Height = 180;
                    image.ImageUrl = "imagehandler.ashx?id=" + id;

                    image.Attributes.Add("onmouseover", "javascript:this.className='imageMouseOver'");
                    image.Attributes.Add("onmouseout", "javascript:this.className='imagecontents'");

                    HyperLink imageLink = new HyperLink();
                    imageLink.NavigateUrl = "showimage.aspx?id=" + id;
                    imageLink.Controls.Add(image);
                    //imageLink.CssClass = "imagelink";

                    Label description = new Label();
                    description.Text = reader["_说明"].ToString();

                    TableCell cell = new TableCell();
                    cell.Controls.Add(imageLink);
                    cell.Controls.Add(new LiteralControl("&nbsp;&nbsp;<br /><br />"));
                    cell.Controls.Add(description);

                    if (i > 2) // 3 个 image 组成一行
                    {
                        i = 0;
                        row = new TableRow();
                    }

                    row.Controls.Add(cell);

                    table.Controls.Add(row);
                    i++;
                }

                PlaceHolder1.Controls.Add(table);

                // Call Close when done reading.
                reader.Close();
            }
        }
        catch (SqlException ex)
        {
            Response.Write(ex.Message);
        }
    }
}
