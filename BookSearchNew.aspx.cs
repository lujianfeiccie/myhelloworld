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

public partial class BookSearchNew : System.Web.UI.Page
{
    private string connString = "";
    private string fromWhereKey = ""; //指示数据来源，本地或远程
    public string textid = "";//存储客服端id
    public string downlistid = "";//存储客服端id
    public string buttomid = "";
    protected void Page_Load(object sender, EventArgs e)
    {        
        connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBString"].ConnectionString;
        //BindData();
        if (!IsPostBack)
        {
            fillDataSource(); //给DropDownList4填充数据来源(请选择数据来源:)
           // checkMyBookList();
            
        }
        textid = TextBox1.ClientID.ToString(); //检索框
        downlistid = DropDownList1.ClientID.ToString();//请选择检索方式
        buttomid = Button1.ClientID.ToString();//检索按钮
        GetTopSearch();


        string keyword = ""+Request["keyword"];
        if (keyword == null)
        {
            return;
        }
        if (keyword.Equals(""))
        {
            return;
        }
        TextBox1.Text = keyword;
        Button1_Click(null,null);
    }

    private void GetTopSearch()
    {

        Search mysearch = new Search();
        mysearch.SearchDataOpen();

        SqlDataReader reader = mysearch.GetHotSearch(50);
        top10.DataSource = reader;//热门搜索
        top10.DataBind();
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
            DropDownList4.Items.Add(item); //请选择数据来源右边那个
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
        string sqlString = "";
        string colName = DropDownList1.SelectedValue; //检索方式下拉框
        string value = TextBox1.Text.Trim(); //检索条件文本
        string LIKE = " LIKE ";
        string E = " = ";
        string Q = "'";
        string P = "%";
        string ODB = " ORDER BY ";
        string mainpart = "select distinct recid, title, author, classno, bookno, isbn, pubdate, publisher, keyword, secret, createdate, availableNum from v_search where ";
        string orderby = DropDownList3.SelectedValue; //结果排序下拉框
        string order = "";
        string mode = "前方一致";
        int pageSize = Convert.ToInt16(DropDownList2.SelectedValue.ToString());

        //TODO 非法单词过滤
        if (value.Length == 0)
        {
            return;
        }

        /**
         * 如果选中在结果中检索，则恢复上一次检索选项，构造出上一次的检索式
         * 按照上一次检索式进行检索，之后再在 GetDate 中进行数据过滤，达到二次检索的效果
         */
        if (RadioButton7.Checked)
        {
            if (Session["PO"] != null) //"PO" is Previous Options
            {
                //恢复上次检索选项
                Hashtable po = (Hashtable)Session["PO"];

                colName = (string)po["colName"];
                value = (string)po["value"];
                mode = (string)po["mode"];

                //构造检索式
                if (mode.Equals("前方一致")) //mode, 前方一致
                {
                    sqlString = mainpart + colName + LIKE + Q + value + P + Q + ODB + orderby + order;
                }
                else if (mode.Equals("完全匹配")) //mode, 完全匹配
                {
                    sqlString = mainpart + colName + E + Q + value + Q + ODB + orderby + order;
                }
                else //mode, 任意匹配
                {
                    sqlString = mainpart + colName + LIKE + Q + P + value + P + Q + ODB + orderby + order;
                }
            }
        }
        else //选择全新检索
        {
            if (RadioButton5.Checked) //降序
            {
                order = " DESC";
            }
            if (DropDownListSearchMode.SelectedValue.Equals("0")) //mode, 前方一致
            {
                sqlString = mainpart + colName + LIKE + Q + value + P + Q + ODB + orderby + order;
            }
            else if (DropDownListSearchMode.SelectedValue.Equals("1")) //mode, 完全匹配
            {
                sqlString = mainpart + colName + E + Q + value + Q + ODB + orderby + order;
            }
            else //mode, 任意匹配
            {
                sqlString = mainpart + colName + LIKE + Q + P + value + P + Q + ODB + orderby + order;
            }

            /**
             * 把检索选项放入 Session
             * 三个选项：colName(列名), value(检索词), mode(匹配模式)
             */
            Hashtable po;
            if (Session["PO"] != null)
            {
                po = (Hashtable)Session["PO"];
                po["colName"] = colName;
                po["value"] = value;
                po["mode"] = mode;
            }
            else
            {
                po = new Hashtable();
                po.Add("colName", colName);
                po.Add("value", value);
                po.Add("mode", mode);
            }
            Session["PO"] = po;
        }

        GridView1.PageSize = pageSize;
        GetData(sqlString);
    }

    private void GetData(string sqlString)
    {
        //防止用户一来就选在结果中检索，此时 sqlString 未能构造
        if (sqlString.Length == 0) return;

        NameValueCollection urls = (NameValueCollection)ConfigurationManager.GetSection("serviceSites/siteUrl");
        NameValueCollection tokens = (NameValueCollection)ConfigurationManager.GetSection("serviceSites/siteToken");

        fromWhereKey = DropDownList4.SelectedItem.Value;//请选择数据来源
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
            //for (int i = 0; i < urls.Count; i++)
            //{
            //    string[] args = new string[2];
            //    args[0] = sqlString;
            //    string token = tokens[i].ToString();
            //    args[1] = token;
            //    if (urls[i].Equals("local"))
            //    {
            //        tempDataSet = getBooks(sqlString);
            //    }
            //    else
            //    {
            //        tempDataSet = (DataSet)WebServiceHelper.InvokeWebService(urls[i], "getBooks", args);
            //    }
            //    makeFromColumn(tempDataSet);
            //    booksDataSet.Merge(tempDataSet);
            //}
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
        int secondCount = 0; //二次检索结果数

        //如果选中在结果中检索，则进行数据过滤
        if (RadioButton7.Checked)
        {
            string LIKE = " LIKE ";
            string E = " = ";
            string Q = "'";
            string P = "%";

            string colName = DropDownList1.SelectedValue;
            string value = TextBox1.Text.Trim();
            string orderby = DropDownList3.SelectedValue;
            string order = "";
            string rowFilter = "";

            if (RadioButton5.Checked) //降序
            {
                order = " DESC";
            }

            //首次检索结果集中不包括 pinyin 列
            //因此要把 pinyin 转成 title
            if (colName.Equals("pinyin"))
            {
                colName = "title";
            }
            if (DropDownListSearchMode.SelectedValue.Equals("0")) //mode, 前方一致
            {
                rowFilter = colName + LIKE + Q + value + P + Q;
            }
            else if (DropDownListSearchMode.SelectedValue.Equals("1")) //mode, 完全匹配
            {
                rowFilter = colName + E + Q + value + Q;
            }
            else //mode, 任意匹配
            {
                rowFilter = colName + LIKE + Q + P + value + P + Q;
            }

            DataView view = dataTable.DefaultView;
            view.RowFilter = rowFilter;
            view.Sort = orderby + order;
            secondCount = view.Count;
        }

        GridView1.DataSource = dataTable;
        GridView1.DataBind();

        //显示检索结果
        Panel1.Visible = true; //显示检索结果
        Label3.Text = ""; //二次检索结果设为空

        string firstValue = (string)((Hashtable)Session["PO"])["value"];
        Label2.Text = "检索【" + firstValue + "】命中：<font color='red'>" + firstCount + "</font>";

        //如果选中在结果中检索
        if (RadioButton7.Checked)
        {
            Label3.Text = "二次检索【" + TextBox1.Text.Trim() + "】命中：<font color='red'>" + secondCount + "</font>";
        }

        //显示加入书单按钮
        if (GridView1.Rows.Count > 0)
        {
           // Button3.Visible = true;
        }
        else
        {
           // Button3.Visible = false;
        }
    }

    //分页索引改变
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
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
                b.Secret = GridView1.DataKeys[i].Values["secret"].ToString().Trim();
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
            //value = "alert('" + title_link.Text.Trim() + "')";
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
            author = author.Replace("[等撰]", "");
            author = author.Replace("等撰", "");
            author = author.Replace("撰", "");
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
                "dojo.byId('" + DropDownList1.ClientID + "').selectedIndex = 1;" +
                "dojo.byId('" + Button1.ClientID + "').click()";
            author_link.Attributes.Add("onclick", value);

            //处理出版社，第 5 列
            HyperLink pub_link = (HyperLink)e.Row.Cells[5].Controls[0];
            string pub = pub_link.Text.Trim();
            value = "dojo.byId('" + TextBox1.ClientID + "').value = '" + pub + "';" +
                "dojo.byId('" + DropDownList1.ClientID + "').selectedIndex = 3;" +
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

    ////点击加入书单按钮，把书单放到 session 中
    //protected void Button3_Click(object sender, EventArgs e)
    //{
    //    if (!changed) //没有翻页操作
    //    {
    //        GetSelectedItem();
    //    }

    //    //string fromWhereKey = DropDownList4.SelectedItem.Value;

    //    //把书单放到 session 中
    //    if (Session["IDS"] != null)
    //    {
    //        List<Book2> items = (List<Book2>)Session["IDS"];
    //        List<string> ids = new List<string>();

    //        foreach (Book2 item in items)
    //        {
    //            ids.Add(item.Id);
    //        }

    //        foreach (Book2 b in SelectedBooks)
    //        {
    //            if (!ids.Contains(b.Id)) //如果不重复
    //            {
    //                items.Add(b); //把新的选择加入
    //            }
    //        }
    //        Session["IDS"] = items;
    //    }
    //    else
    //    {
    //        List<Book2> items = new List<Book2>();
    //        foreach (Book2 b in SelectedBooks)
    //        {
    //            items.Add(b);
    //        }
    //        Session["IDS"] = items;
    //    }

    //    ////把书单放到 session 中
    //    //if (Session["IDS"] != null)
    //    //{
    //    //    List<string> ids = (List<string>)Session["IDS"]; //得到已有的 session
    //    //    //注意不能迭代 ids，因为 ids 在迭代中要改变
    //    //    foreach (string id in (List<string>)this.SelectedItems)
    //    //    {
    //    //        if (!ids.Contains(id)) //如果不重复
    //    //        {
    //    //            ids.Add(id); //把新的选择加入已有 session
    //    //        }
    //    //    }
    //    //    Session["IDS"] = ids;
    //    //}
    //    //else
    //    //{
    //    //    Session["IDS"] = SelectedItems;
    //    //}

    //    checkMyBookList();
    //}

    //private void checkMyBookList()
    //{
    //    if (Session["IDS"] != null && ((List<Book2>)Session["IDS"]).Count > 0)
    //    {
    //        Label1.Text = "(" + ((List<Book2>)Session["IDS"]).Count.ToString() + ")";
    //        //ClientScript.RegisterStartupScript(this.GetType(), @"startup", "<script>highlight();</script>");
    //        string script = "dojo.require(\"dojo.lfx.*\");" +
    //            "function highlight() { dojo.lfx.html.highlight(dojo.byId('" + Label1.ClientID +
    //            "'), [255,255,0], 2000, 1500).play(); }";
    //        //"var b = dojo.byId('ctl00_ContentPlaceHolder1_Button3');" +
    //        //"dojo.event.connect(b, \"onclick\", \"highlight\");" +
    //        //ClientScript.RegisterStartupScript(this.GetType(), @"startup", "<script>highlight();</script>");
    //        //Button3.OnClientClick = script;
    //        //ClientScript.RegisterClientScriptBlock(GetType(), "highlight", script);

    //        //把 javascript 添加到页面开头
    //        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.GetType(), "highlight", script, true);
    //        //执行 highlight()
    //        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.GetType(), "highlight1", "highlight();", true);
    //    }
    //}
}
