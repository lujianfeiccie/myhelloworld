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

public partial class PaperSearch : System.Web.UI.Page
{
    private string connString = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBString"].ConnectionString;
        //BindData();
        //checkMyBookList();
    }

    //点击检索按钮
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindData();
    }

    private void BindData()
    {
        string sqlString = "";
        string colName = DropDownList1.SelectedValue;
        string value = TextBox1.Text.Trim();
        string LIKE = " LIKE ";
        string E = " = ";
        string Q = "'";
        string P = "%";
        string ODB = " ORDER BY ";
        //string mainpart = "select recid, _刊名 as title, " +
        //    "_ISSN as issn, _编辑者 as editor, _主办者 as entrepreneur, " +
        //    "_出版者 as publisher, _年期数 as num, _出版周期 as pub " +
        //    "from vj_bib where ";
        string mainpart = "select * from vj_bib where ";
        string orderby = DropDownList3.SelectedValue;
        string order = "";
        string mode = "前方一致";
        int pageSize = Convert.ToInt16(DropDownList2.SelectedValue.ToString());

        //TODO 非法单词过滤
        if (value.Length == 0)
        {
            //return;
        }

        /**
         * 如果选中在结果中检索，则恢复上一次检索选项，构造出上一次的检索式
         * 按照上一次检索式进行检索，之后再在 GetDate 中进行数据过滤，达到二次检索的效果
         */
        if (RadioButton7.Checked)
        {
            if (Session["JPO"] != null) //"JPO" is Journal Previous Options
            {
                //恢复上次检索选项
                Hashtable jpo = (Hashtable)Session["JPO"];

                colName = (string)jpo["colName"];
                value = (string)jpo["value"];
                mode = (string)jpo["mode"];

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

            if (RadioButton1.Checked) //mode, 前方一致
            {
                sqlString = mainpart + colName + LIKE + Q + value + P + Q + ODB + orderby + order;
            }
            else if (RadioButton3.Checked) //mode, 完全匹配
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
            Hashtable jpo;
            if (Session["JPO"] != null)
            {
                jpo = (Hashtable)Session["JPO"];
                jpo["colName"] = colName;
                jpo["value"] = value;
                jpo["mode"] = mode;
            }
            else
            {
                jpo = new Hashtable();
                jpo.Add("colName", colName);
                jpo.Add("value", value);
                jpo.Add("mode", mode);
            }
            Session["JPO"] = jpo;
        }

        GridView1.PageSize = pageSize;
        GetData(sqlString);
    }

    private void GetData(string sqlString)
    {
        //防止用户一来就选在结果中检索，此时 sqlString 未能构造
        if (sqlString.Length == 0) return;

        SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlString, connString);

        DataSet dataSet = new DataSet();

        dataAdapter.Fill(dataSet, "journals");

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

            if (RadioButton1.Checked) //mode, 前方一致
            {
                rowFilter = colName + LIKE + Q + value + P + Q;
            }
            else if (RadioButton3.Checked) //mode, 完全匹配
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

        string firstValue = (string)((Hashtable)Session["JPO"])["value"];
        Label2.Text = "检索【" + firstValue + "】命中：<font color='red'>" + firstCount + "</font>";

        //如果选中在结果中检索
        if (RadioButton7.Checked)
        {
            Label3.Text = "二次检索【" + TextBox1.Text.Trim() + "】命中：<font color='red'>" + secondCount + "</font>";
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
    }

    //在 DataBinding 事件中执行 GetSelectedItem()
    protected void GridView1_DataBinding(object sender, EventArgs e)
    {
        //GetSelectedItem(); //收集所有选择项
        //changed = true; //收集过了        
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
                cbx.Checked = true;
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

            //处理主办单位，第 2 列
            HyperLink entrepreneur_link = (HyperLink)e.Row.Cells[2].Controls[0];
            string entrepreneur = entrepreneur_link.Text.Trim();
            entrepreneur = entrepreneur.Replace("主办", "");
            entrepreneur = entrepreneur.Replace("[主办]", "");

            value = "dojo.byId('" + TextBox1.ClientID + "').value = '" + entrepreneur + "';" +
                "dojo.byId('" + DropDownList1.ClientID + "').selectedIndex = 2;" +
                "dojo.byId('" + Button1.ClientID + "').click()";
            entrepreneur_link.Attributes.Add("onclick", value);

            //处理出版单位，第 3 列
            HyperLink pub_link = (HyperLink)e.Row.Cells[3].Controls[0];
            string pub = pub_link.Text.Trim();
            pub = pub.Replace("出版", "");
            pub = pub.Replace("[出版]", "");

            value = "dojo.byId('" + TextBox1.ClientID + "').value = '" + pub + "';" +
                "dojo.byId('" + DropDownList1.ClientID + "').selectedIndex = 3;" +
                "dojo.byId('" + Button1.ClientID + "').click()";
            pub_link.Attributes.Add("onclick", value);

            //处理出版周期，第 4 列
            HyperLink period_link = (HyperLink)e.Row.Cells[4].Controls[0];
            string period = period_link.Text.Trim();
            value = "dojo.byId('" + TextBox1.ClientID + "').value = '" + period + "';" +
                "dojo.byId('" + DropDownList1.ClientID + "').selectedIndex = 4;" +
                "dojo.byId('" + Button1.ClientID + "').click()";
            period_link.Attributes.Add("onclick", value);

            //处理年期数，第 5 列
            HyperLink num_link = (HyperLink)e.Row.Cells[5].Controls[0];
            string num = num_link.Text.Trim();
            value = "dojo.byId('" + TextBox1.ClientID + "').value = '" + num + "';" +
                "dojo.byId('" + DropDownList1.ClientID + "').selectedIndex = 5;" +
                "dojo.byId('" + Button1.ClientID + "').click()";
            num_link.Attributes.Add("onclick", value);
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
