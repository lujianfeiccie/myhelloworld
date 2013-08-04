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
using System.Collections.Specialized;

public partial class BookDetail : System.Web.UI.Page
{
    private string connString = "";
    private string recid = "";
    private Book2 currentBook;
    public Functions myfun = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBString"].ConnectionString;
        //TODO 合法性验证，用户可能手动更改 URL
        if (Request.QueryString["id"] == null || Request.QueryString["id"].Trim().Length == 0)
        {
            Response.Redirect("LibSearch.aspx");
        }
        else
        {
            recid = Request.QueryString["id"];
        }
        
        BindData();
        
    }

   private void BindData()
    {
        string Q = "'";
        string ODB = " ORDER BY status";
        string mainpart = "SELECT bib.recid, ISBN, _题名 AS title, _责任者 AS author, rtrim(_分类)+'/'+rtrim(_书次) AS bookno, " +
            "(SELECT CASE _密级 WHEN '0' THEN '公开' WHEN '1' THEN '国内' WHEN '2' THEN '内部' WHEN '3' THEN '秘密' WHEN '4' THEN '机密' WHEN '5' THEN '绝密' ELSE '不明确' END) AS secret, " +
            "_出版日期 as pubdate, _出版者 AS publisher, _入档日期 as createdate, _价格 as price, " +
            "_页数 as pages, _版次 as version, _装订 as bind, _尺寸开本 as format " +
            "FROM bib WHERE recid = ";

        string sqlDetail = mainpart + Q + recid + Q;
        string sqlBookNo = "SELECT [v_search_codebar].* FROM [v_search_codebar] WHERE [v_search_codebar].recid = " + Q + recid + Q + ODB;

        GetData(sqlDetail, sqlBookNo);
    }

    private void GetData(string sqlDetail, string sqlBookNo)
    {
        string fromWhereKey="601";
        if(Request.QueryString["from"]!=null)
            fromWhereKey= Request.QueryString["from"];
        string from = string.Empty;
        try
        {
            NameValueCollection config = (NameValueCollection)ConfigurationManager.GetSection("serviceSites/siteUrl");
            from = config[fromWhereKey].ToString();
        }
        catch { }
        if (from.Equals("local"))
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlDetail, connString);
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(sqlBookNo, connString);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "bookdetail");
            dataAdapter1.Fill(dataSet, "bookno");

            fillGridView(dataSet);
        }
        else
        {
            string url = from;
            string[] args = new string[3];
            args[0] = sqlDetail;
            args[1] = sqlBookNo;
            try
            {
                NameValueCollection tokens = (NameValueCollection)ConfigurationManager.GetSection("serviceSites/siteToken");
                string token = tokens[fromWhereKey].ToString();
                args[2] = token;
                DataSet dataSet = (DataSet)WebServiceHelper.InvokeWebService(url, "getBookDetail", args);
                fillGridView(dataSet);
            }
            catch { }
        }
        //显示数据来源
        try
        {
            NameValueCollection names = (NameValueCollection)ConfigurationManager.GetSection("serviceSites/site");
            string fromName = names[fromWhereKey].ToString();
            Label5.Text = fromName;
        }
        catch { }
    }

    private void fillGridView(DataSet dataSet)
    {
        DataTable dataTableDetail = dataSet.Tables["bookdetail"];
        DataTable dataTableBookNo = dataSet.Tables["bookno"];

        bookall.DataSource = dataTableDetail;
        bookall.DataBind();

        GridView1.DataSource = dataTableBookNo;
        GridView1.DataBind();

        makeCurrentBook(dataTableDetail); //构造新的 Book，便于放入 session 中

        /**
         * 判断是否可以预约
         * 
         * 可以预约的条件是：1. 有可借类型的书 并且 2. 已全部借出
         * 
         * 图书状态可分为两种类型：
         * 
         * 不可借类型：不可借 0
         *             可阅览 1
         * 
         * 可借类型：可借 2
         *           借出 3
         *           预约 4
         *           修补 5
         *         未典藏 6
         * 
         * 可借类型全部借出是指：所有"借出"状态书的数量 = 所有"可借类型"书的数量
         * 
         */
        if (dataTableBookNo.Rows.Count > 0) //如果查询有数据
        {
            string status;
            int lendableTypeBookNum = 0; //可借类型书的数量
            int lendOutNum = 0;

            foreach (DataRow row in dataTableBookNo.Rows)
            {
                status = row["status"].ToString();

                if (status.Equals("可借") || status.Equals("借出"))
                {
                    lendableTypeBookNum++;

                    if (status.Equals("借出"))
                    {
                        lendOutNum++;
                    }
                }
            }
            //有可借类型的书，并且已全部借出，就认为可以预约
            if (lendableTypeBookNum > 0 && lendableTypeBookNum == lendOutNum&&Session["userid"]!=null&&Session["userid"].ToString()!="")
            {
                
                Panel1.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
            }
        }
    }

    private void makeCurrentBook(DataTable dataTableDetail)
    {
        if (dataTableDetail != null && dataTableDetail.Rows.Count >= 1)
        {
            currentBook = new Book2();
            currentBook.Id = recid;
            currentBook.From = Request.QueryString["from"];
            currentBook.Bookno = dataTableDetail.Rows[0]["bookno"].ToString().Trim();
            currentBook.Title = dataTableDetail.Rows[0]["title"].ToString().Trim();
            currentBook.Author = dataTableDetail.Rows[0]["author"].ToString().Trim();
            currentBook.Publisher = dataTableDetail.Rows[0]["publisher"].ToString().Trim();
            currentBook.Pubdate = dataTableDetail.Rows[0]["pubdate"].ToString().Trim();
            currentBook.Secret = dataTableDetail.Rows[0]["secret"].ToString().Trim();
        }
    }

    private Book2 getCurrentBook()
    {
        return currentBook;
    }

  

    //点击执行预约
    protected void Button2_Click(object sender, EventArgs e)
    {
        //reserve();

        //-----------------------------------------------------

        NameValueCollection urls = (NameValueCollection)ConfigurationManager.GetSection("serviceSites/siteUrl");
        NameValueCollection tokens = (NameValueCollection)ConfigurationManager.GetSection("serviceSites/siteToken");

        string readerCodebar = Session["userid"].ToString(); //读者条码
        string bookFromWhereKey = Request.QueryString["from"];

        //进行读者验证
        //根据 book 的 from 属性到本地或远程服务器进行预约
        int result = -1;
        if (isValidReader(readerCodebar)) //有效读者
        {
            string url = urls[bookFromWhereKey].ToString();
            Book2 book = getCurrentBook();
            Reader reader = getReader(readerCodebar);
            if (url.Equals("local")) //图书在本地，执行本地预约
            {
                result = reserve(book, reader);
            }
            else //图书在远程，执行远程预约
            {
                string[] args = new string[8];
                args[0] = readerCodebar;
                args[1] = recid;
                args[2] = book.Title;
                args[3] = book.Author;
                args[4] = book.Bookno;
                args[5] = reader.Name;
                args[6] = reader.Unit;
                string token = tokens[bookFromWhereKey].ToString();
                args[7] = token;
                result = (int)WebServiceHelper.InvokeWebService(url, "reserve", args);
            }
        }
        else
        {
            result = -1;
        }

        Panel2.Visible = true;
        if (result == -1)
        {
            Label4.Text = "预约失败，请检查条码是否正确。";
        }
        else
        {
            Label4.Text = "您的预约已经成功提交，请及时检查预约到书，谢谢。";
        }
    }

    public string viewradio(string type)
    {
        if (type == "借出")
            return " style=\"display:;\"";
        else return " style=\"display:none;\""; ;
    }
    //执行预约
    private int reserve(Book2 book, Reader reader)
    {
        //_读者条码, recid
        //_题名, _责任者, _索书号, _读者姓名, _读者单位
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand command = new SqlCommand("sp_search_reserve", conn);
        command.CommandType = CommandType.StoredProcedure;
        SqlParameter parameter1 = command.Parameters.Add("@readerCodebar", SqlDbType.Char);
        SqlParameter parameter2 = command.Parameters.Add("@recid", SqlDbType.Char);
        SqlParameter parameter3 = command.Parameters.Add("@title", SqlDbType.VarChar);
        SqlParameter parameter4 = command.Parameters.Add("@author", SqlDbType.VarChar);
        SqlParameter parameter5 = command.Parameters.Add("@bookno", SqlDbType.Char);
        SqlParameter parameter6 = command.Parameters.Add("@name", SqlDbType.NVarChar);
        SqlParameter parameter7 = command.Parameters.Add("@unit", SqlDbType.NVarChar);

        SqlParameter parameter8 = command.Parameters.Add("result", SqlDbType.Int);
        parameter8.Direction = ParameterDirection.ReturnValue;

        parameter1.Value = reader.ReaderCodebar; //读者条码
        parameter2.Value = recid;
        parameter3.Value = book.Title;
        parameter4.Value = book.Author;
        parameter5.Value = book.Bookno;
        parameter6.Value = reader.Name;
        parameter7.Value = reader.Unit;

        int result = -1;

        try
        {
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
            result = (int)command.Parameters["result"].Value;
        }
        catch (SqlException ex)
        {
            Response.Write(ex.ToString());
        }
        return result;
    }

    private Reader getReader(string readerCodebar)
    {
        NameValueCollection urls = (NameValueCollection)ConfigurationManager.GetSection("serviceSites/siteUrl");
        NameValueCollection tokens = (NameValueCollection)ConfigurationManager.GetSection("serviceSites/siteToken");
        string readerFromWhereKey = "601";// DropDownList1.SelectedItem.Value;
        string readerUrl = urls[readerFromWhereKey].ToString();
        Reader reader;

        if (readerUrl.Equals("local")) //读者在本地
        {
            reader = DataManager.getReader(readerCodebar);
        }
        else //读者在远程
        {
            string[] args = new string[2];
            args[0] = readerCodebar;
            string token = tokens[readerFromWhereKey].ToString();
            args[1] = token;
            string[] nameAndUnit = (string[])WebServiceHelper.InvokeWebService(readerUrl, "getReaderNameAndUnit", args);
            reader = new Reader();
            reader.ReaderCodebar = readerCodebar;
            reader.Name = nameAndUnit[0];
            reader.Unit = nameAndUnit[1];
        }
        return reader;
    }

    private bool isValidReader(string readerCodebar)
    {
        NameValueCollection urls = (NameValueCollection)ConfigurationManager.GetSection("serviceSites/siteUrl");
        NameValueCollection tokens = (NameValueCollection)ConfigurationManager.GetSection("serviceSites/siteToken");
        string readerFromWhereKey = "601";//DropDownList1.SelectedItem.Value;暂时只支持本地的
        string readerUrl = urls[readerFromWhereKey].ToString();

        if (readerUrl.Equals("local")) //本地验证
        {
            if (DataManager.isValidReader(readerCodebar)) //读者验证通过
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else //远程验证
        {
            string[] args = new string[2];
            args[0] = readerCodebar;
            string token = tokens[readerFromWhereKey].ToString();
            args[1] = token;
            bool validReader = (bool)WebServiceHelper.InvokeWebService(readerUrl, "isValidReader", args);
            if (validReader) //读者验证通过
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

   
}
