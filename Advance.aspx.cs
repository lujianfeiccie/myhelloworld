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

public partial class Advance : System.Web.UI.Page
{
    private string connString = "";
    private string fromWhereKey = ""; //指示数据来源，本地或远程
    public string textid = "";//存储客服端id
   
    public string buttomid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBString"].ConnectionString;
        //BindData();
        if (!IsPostBack)
        {
            fillDataSource();
            // checkMyBookList();

        }
        textid = TextBox1.ClientID.ToString();
       
        buttomid = Button1.ClientID.ToString();
        GetTopSearch();
    }

    private void GetTopSearch()
    {

        Search mysearch = new Search();
        mysearch.SearchDataOpen();

        SqlDataReader reader = mysearch.GetHotSearch(50);
        top10.DataSource = reader;
        top10.DataBind();
        reader.Close();

        reader.Close();



        mysearch.SearchDataClose();
    }

    private void fillDataSource()
    {
        NameValueCollection config = (NameValueCollection)ConfigurationManager.GetSection("serviceSites/site");
        foreach (string key in config.AllKeys)
        {
            ListItem item = new ListItem();
            item.Text = config[key].ToString();
            item.Value = key;
            DropDownList4.Items.Add(item);
        }
        ListItem all = new ListItem();
        all.Text = "所有位置";
        all.Value = "all";
        DropDownList4.Items.Add(all);
    }

    //点击检索按钮
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Length > 0)
        {
            Search mysearch = new Search();
            mysearch.SearchDataOpen();
            mysearch.AddSearchWord(TextBox1.Text.ToString());
            mysearch.SearchDataClose();
            BindData();
        }
    }

    private void BindData()
    {
        string col_1 = item1.SelectedValue;
        string op_1 = op1.SelectedValue;
        string query_1 = TextBox1.Text.Trim();

        string col_2 = item2.SelectedValue;
        string op_2 = op2.SelectedValue;
        string query_2 = TextBox2.Text.Trim();

        string col_3 = item3.SelectedValue;
        string op_3 = op3.SelectedValue;
        string query_3 = TextBox3.Text.Trim();

        string col_4 = item4.SelectedValue;
        string op_4 = op4.SelectedValue;
        string query_4 = TextBox4.Text.Trim();

        string col_5 = item5.SelectedValue;
        string op_5 = op5.SelectedValue;
        string query_5 = TextBox5.Text.Trim();

        string logic_1 = logic1.SelectedValue;
        string logic_2 = logic2.SelectedValue;
        string logic_3 = logic3.SelectedValue;
        string logic_4 = logic4.SelectedValue;

        string part_1;
        string part_2;
        string part_3;
        string part_4;
        string part_5;

        //-------------------------------

        string sqlString = "";
        string mainpart = "select distinct recid, title, author, classno, bookno, isbn, pubdate, publisher, keyword, secret, createdate, availableNum from v_search where ";
        string orderby = DropDownList3.SelectedValue;
        string ODB = " ORDER BY ";
        string order = "";
        string BLANK = " ";
        int pageSize = Convert.ToInt16(DropDownList2.SelectedValue.ToString());

        //TODO 非法单词过滤
        if (query_1.Length == 0 &&
            query_2.Length == 0 &&
            query_3.Length == 0 &&
            query_4.Length == 0 &&
            query_5.Length == 0)
        {
            return;
        }

        if (RadioButton5.Checked) //降序
        {
            order = " DESC";
        }

        part_1 = makePart(col_1, op_1, query_1);
        part_2 = makePart(col_2, op_2, query_2);
        part_3 = makePart(col_3, op_3, query_3);
        part_4 = makePart(col_4, op_4, query_4);
        part_5 = makePart(col_5, op_5, query_5);

        if (query_1.Length == 0)
        {
            part_1 = string.Empty;
            logic_1 = string.Empty;
        }
        if (query_2.Length == 0)
        {
            logic_1 = string.Empty;
            part_2 = string.Empty;
        }
        if (query_3.Length == 0)
        {
            logic_2 = string.Empty;
            part_3 = string.Empty;
        }
        if (query_4.Length == 0)
        {
            logic_3 = string.Empty;
            part_4 = string.Empty;
        }
        if (query_5.Length == 0)
        {
            logic_4 = string.Empty;
            part_5 = string.Empty;
        }

        //构造检索式
        sqlString = mainpart +
                    part_1 + BLANK + logic_1 + BLANK +
                    part_2 + BLANK + logic_2 + BLANK +
                    part_3 + BLANK + logic_3 + BLANK +
                    part_4 + BLANK + logic_4 + BLANK +
                    part_5 + BLANK + ODB + orderby + order;

        GridView1.PageSize = pageSize;
        GetData(sqlString);
    }

    private static string makePart(string col, string op, string query)
    {
        string part = string.Empty;

        string LIKE = " LIKE ";
        string E = " = ";
        string NE = " <> ";
        string NL = " NOT LIKE ";
        string Q = "'";
        string P = "%";

        if (op.Equals("前方一致"))
        {
            part = col + LIKE + Q + query + P + Q;
        }
        else if (op.Equals("完全匹配"))
        {
            part = col + E + Q + query + Q;
        }
        else if (op.Equals("任意匹配"))
        {
            part = col + LIKE + Q + P + query + P + Q;
        }
        else if (op.Equals("不等于"))
        {
            part = col + NE + Q + query + Q;
        }
        else if (op.Equals("不相似于"))
        {
            part = col + NL + Q + P + query + P + Q;
        }

        return part;
    }

    private void GetData(string sqlString)
    {
        NameValueCollection urls = (NameValueCollection)ConfigurationManager.GetSection("serviceSites/siteUrl");
        NameValueCollection tokens = (NameValueCollection)ConfigurationManager.GetSection("serviceSites/siteToken");

        fromWhereKey = DropDownList4.SelectedItem.Value;
        string url = string.Empty;
        if (!fromWhereKey.Equals("all"))
        {
            url = urls[fromWhereKey].ToString();
        }

        //查询本地数据库
        if (url.Equals("local"))
        {
            DataSet dataSet = getBooks(sqlString);
            makeFromColumn(dataSet, fromWhereKey);
            fillGridView(dataSet);
        }
        else if (fromWhereKey.Equals("all")) //检索所有数据库，包括本地和远程的
        {
            DataSet tempDataSet;
            DataSet booksDataSet = new DataSet();
            foreach (string key in urls)
            {
                string[] args = new string[2];
                args[0] = sqlString;
                string token = tokens[key].ToString();
                args[1] = token;
                if (urls[key].Equals("local"))
                {
                    tempDataSet = getBooks(sqlString);
                }
                else
                {
                    tempDataSet = (DataSet)WebServiceHelper.InvokeWebService(urls[key], "getBooks", args);
                }
                makeFromColumn(tempDataSet, key); //添加 from 列，指示数据来源，构造 bookdetail 的 url
                booksDataSet.Merge(tempDataSet);
            }
            fillGridView(booksDataSet);
        }
        else //通过 web service 查询远程数据库
        {
            string[] args = new string[2];
            args[0] = sqlString;
            string token = tokens[fromWhereKey].ToString();
            args[1] = token;
            DataSet dataSet = (DataSet)WebServiceHelper.InvokeWebService(url, "getBooks", args);
            makeFromColumn(dataSet, fromWhereKey);
            fillGridView(dataSet);
        }
    }

    //创建 from 列，指示数据来源
    private void makeFromColumn(DataSet dataSet, string from)
    {
        DataTable dataTable = dataSet.Tables[0];
        dataTable.Columns.Add(new DataColumn("from", typeof(string)));
        foreach (DataRow row in dataTable.Rows)
        {
            row["from"] = from;
        }
    }

    //得到检索的图书
    private DataSet getBooks(string sqlString)
    {
        SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlString, connString);
        DataSet dataSet = new DataSet();
        dataAdapter.Fill(dataSet, "books");
        return dataSet;
    }

    private void fillGridView(DataSet dataSet)
    {
        DataTable dataTable = dataSet.Tables[0];

        int firstCount = dataTable.Rows.Count; //一次检索的结果数

        AspNetPager1.RecordCount = firstCount;

        GridView1.DataSource = dataTable;
        GridView1.DataBind();

        //显示检索结果
        Panel1.Visible = true; //显示检索结果

        string firstValue = dataTable.Rows.Count.ToString();
        Label2.Text = "检索命中：<font color='red'>" + firstCount + "</font>";

       
    }

    //分页索引改变
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData();
    }

    //AspNetPager 分页索引改变
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }

    //是否翻页
    private bool changed = false;

    //定义保存选择项主键集合属性
    protected List<string> SelectedItems
    {
        get { return ViewState["selecteditems"] != null ? (List<string>)ViewState["selecteditems"] : null; }
        set { ViewState["selecteditems"] = value; }
    }

    //定义保存选择项各列信息
    protected List<Book2> SelectedBooks
    {
        get { return ViewState["selectedbooks"] != null ? (List<Book2>)ViewState["selectedbooks"] : null; }
        set { ViewState["selectedbooks"] = value; }
    }

    //获取选择项 recid
    private void GetSelectedItem()
    {
        List<string> selecteditems = null;
        if (this.SelectedItems == null)
        {
            selecteditems = new List<string>();
        }
        else
        {
            selecteditems = SelectedItems;
        }

        //获取选择的记录
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            CheckBox cbx = (CheckBox)this.GridView1.Rows[i].FindControl("CheckBox1");

            string recid = GridView1.DataKeys[i].Values[0].ToString().Trim();
            //对于当前的选择，如果已选择项中有但新选择项中没有，则去掉
            if (selecteditems.Contains(recid) && !cbx.Checked)
                selecteditems.Remove(recid);
            //对于当前的选择，如果已选择项中没有但新选择项中有，则添加
            if (!selecteditems.Contains(recid) && cbx.Checked)
                selecteditems.Add(recid);
        }
        this.SelectedItems = selecteditems;
        GetSelectedBook();
    }

    //获取选择项各列信息
    private void GetSelectedBook()
    {
        List<Book2> selectedbooks = null;
        if (this.SelectedBooks == null)
        {
            selectedbooks = new List<Book2>();
        }
        else
        {
            selectedbooks = SelectedBooks;
        }

        List<string> ids = new List<string>();
        foreach (Book2 item in selectedbooks)
        {
            ids.Add(item.Id);
        }

        //获取选择的记录
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            CheckBox cbx = (CheckBox)this.GridView1.Rows[i].FindControl("CheckBox1");

            string recid = GridView1.DataKeys[i].Values[0].ToString().Trim();
            //对于当前的选择，如果已选择项中有但新选择项中没有，则去掉
            if (ids.Contains(recid) && !cbx.Checked)
            {
                foreach (Book2 item in selectedbooks)
                {
                    if (item.Id.Equals(recid))
                    {
                        selectedbooks.Remove(item);
                        break;
                    }
                }
            }
            //对于当前的选择，如果已选择项中没有但新选择项中有，则添加
            if (!ids.Contains(recid) && cbx.Checked)
            {
                Book2 b = new Book2();
                b.Id = recid;
                //b.From = DropDownList4.SelectedItem.Value;
                b.From = GridView1.DataKeys[i].Values["from"].ToString().Trim();
                b.Bookno = GridView1.DataKeys[i].Values["bookno"].ToString().Trim();
                b.Title = GridView1.DataKeys[i].Values["title"].ToString().Trim();
                b.Author = GridView1.DataKeys[i].Values["author"].ToString().Trim();
                b.Publisher = GridView1.DataKeys[i].Values["publisher"].ToString().Trim();
                b.Pubdate = GridView1.DataKeys[i].Values["pubdate"].ToString().Trim();
                //b.Secret = GridView1.DataKeys[i].Values["secret"].ToString().Trim();
                selectedbooks.Add(b);
            }
        }
        this.SelectedBooks = selectedbooks;
    }

    //在 DataBinding 事件中执行 GetSelectedItem()
    protected void GridView1_DataBinding(object sender, EventArgs e)
    {
        GetSelectedItem(); //收集所有选择项
        changed = true; //收集过了        
    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        //if (GridView1.Rows.Count > 0)
        //{
        //    displayPageNo();
        //}
    }

    private void displayPageNo()
    {
        GridViewRow bottomPagerRow = GridView1.BottomPagerRow;
        Label bottomPagerNo = new Label();
        bottomPagerNo.Text = "当前所在页：" + (GridView1.PageIndex + 1) + "/" + GridView1.PageCount;
        bottomPagerRow.Cells[0].Controls.Add(bottomPagerNo);
    }

    //在行绑定时确定 CheckBox 选中状态
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1 && this.SelectedItems != null)
        {
            CheckBox cbx = (CheckBox)e.Row.FindControl("CheckBox1");
            string id = this.GridView1.DataKeys[e.Row.RowIndex].Values[0].ToString().Trim();
            if (SelectedItems.Contains(id))
            {
                cbx.Checked = true;
                e.Row.BackColor = System.Drawing.Color.FromArgb(255, 255, 204);
            }
            else
                cbx.Checked = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string value = "";

            //处理题名，第 3 列
            //HyperLink title_link = (HyperLink)e.Row.Cells[3].Controls[0];
            //string value = "alert('" + title_link.Text.Trim() + "')";
            //title_link.Attributes.Add("onclick", value);

            //处理题名，第 3 列，添加 from 参数
            //指示数据来自本地，或来自远程数据库
            HyperLink title_link = (HyperLink)e.Row.Cells[3].Controls[0];
            title_link.NavigateUrl = title_link.NavigateUrl.Trim();
            //title_link.NavigateUrl += "&from=" + fromWhereKey;
            title_link.NavigateUrl += "&from=" + GridView1.DataKeys[e.Row.RowIndex].Values["from"].ToString().Trim();

            //处理作者，第 4 列
            HyperLink author_link = (HyperLink)e.Row.Cells[4].Controls[0];
            string author = author_link.Text.Trim();
            author = author.Replace("[等编著]", "");
            author = author.Replace("等[编著]", "");
            author = author.Replace("等编著", "");
            author = author.Replace("等主编", "");
            author = author.Replace("等[编]", "");
            author = author.Replace("等编", "");
            author = author.Replace("等[著]", "");
            author = author.Replace("等著", "");
            author = author.Replace("编著", "");
            author = author.Replace("主编", "");
            author = author.Replace("[著]", "");
            author = author.Replace("著", "");
            author = author.Replace("[编]", "");
            author = author.Replace("编", "");

            value = "dojo.byId('" + TextBox1.ClientID + "').value = '" + author + "';" +
                "dojo.byId('" + item1.ClientID + "').selectedIndex = 1;" +
                "dojo.byId('" + op1.ClientID + "').selectedIndex = 0;" +
                "dojo.byId('" + TextBox2.ClientID + "').value = '';" +
                "dojo.byId('" + TextBox3.ClientID + "').value = '';" +
                "dojo.byId('" + TextBox4.ClientID + "').value = '';" +
                "dojo.byId('" + TextBox5.ClientID + "').value = '';" +
                "dojo.byId('" + Button1.ClientID + "').click()";
            author_link.Attributes.Add("onclick", value);

            //处理出版社，第 5 列
            HyperLink pub_link = (HyperLink)e.Row.Cells[5].Controls[0];
            string pub = pub_link.Text.Trim();

            value = "dojo.byId('" + TextBox1.ClientID + "').value = '" + pub + "';" +
                "dojo.byId('" + item1.ClientID + "').selectedIndex = 3;" +
                "dojo.byId('" + TextBox2.ClientID + "').value = '';" +
                "dojo.byId('" + TextBox3.ClientID + "').value = '';" +
                "dojo.byId('" + TextBox4.ClientID + "').value = '';" +
                "dojo.byId('" + TextBox5.ClientID + "').value = '';" +
                "dojo.byId('" + Button1.ClientID + "').click()";
            pub_link.Attributes.Add("onclick", value);
        }
    }

    //根据 changed 确定是否再执行 GetSelectedItem(),否则不翻页时选择项获取不到.
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        if (!changed)
            GetSelectedItem();
        foreach (string id in (List<string>)this.SelectedItems)
        {
            //...
        }
    }
}
