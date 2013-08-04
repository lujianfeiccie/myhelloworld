using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Search 的摘要说明
/// </summary>
public class Search
{
    private string searchid;
    private string keyword;
    private int totalnum;
    private int monthnum;
    private bool istop;
    private bool ischeck;
    private int pagenum;//总页数
    private int allnum;//总记录数量
    protected DataSystem dataconnection;//用于数据链接
    private string sql;
    private Functions myfun = new Functions();

    public string SearchID
    {
        get { return searchid; }
        set { searchid = value; }
    }
    public int PageNum
    {
        set { pagenum = value; }
        get { return pagenum; }
    }
    public int AllNum//记录条数
    {
        set { allnum = value; }
        get { return allnum; }
    }
    public string KeyWord
    {
        get { return keyword; }
        set { keyword = value; }
    }
    public int TotalNum
    {
        get { return totalnum; }
        set { totalnum = value; }
    }
    public int MonthNum
    {
        get { return monthnum; }
        set { monthnum = value; }
    }
    public bool IsTop
    {
        get { return istop; }
        set { istop = value; }
    }
    public bool IsCheck
    {
        get { return ischeck; }
        set { ischeck = value; }
    }
	public Search()
	{
        dataconnection = new DataSystem();
        dataconnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBString"].ToString();
        ischeck = true;
        istop = false;
        totalnum = 0;
        monthnum = 0;
        keyword = "";
        pagenum = 0;
        allnum = 0;
	}
    public void SearchDataOpen()
    {
        dataconnection.Open();
    }
    public void SearchDataClose()
    {
        dataconnection.Close();
    }
    public bool AddSearchWord(string keystring)
    {
        bool result=true;
        sql = "select id from [lib_search] where keyword=@KeyWord";
        SqlParameter[] mypara1 ={ new SqlParameter("@KeyWord",SqlDbType.VarChar) };
        mypara1[0].Value = keystring;
        SqlDataReader reader = dataconnection.GetDataReader(mypara1, sql);
        bool ishasrows = reader.HasRows;
        reader.Close();
        if (ishasrows)
        {
            string sql2;
            if (DateTime.Now.Day == 1)
                sql2 = "update [lib_search] set all_num=all_num+1,month_num=1 where keyword=@KeyWord";
            else
                sql2 = "update [lib_search] set all_num=all_num+1,month_num=month_num+1 where keyword=@KeyWord";
            SqlParameter[] mypara2 ={ 
                new SqlParameter("@KeyWord",SqlDbType.VarChar)             
            };
            mypara2[0].Value = keystring;

            try
            {
                dataconnection.ExecuteSql(mypara2, sql2);
                result = true;
            }
            catch { result = false; }
            
        }
        else
        {

            string sql2 = "insert into [lib_search] (keyword,all_num,month_num,istop,ischeck) values (@KeyWord,@AllNum,@MNum,@IsTop,@IsCheck)";
            SqlParameter[] mypara2 ={ 
                new SqlParameter("@KeyWord",SqlDbType.VarChar),
                new SqlParameter("@AllNum",SqlDbType.Int),
                new SqlParameter("@MNum",SqlDbType.Int),
                new SqlParameter("@IsTop",SqlDbType.Bit),
                new SqlParameter("@IsCheck",SqlDbType.Bit)
            };
            mypara2[0].Value = keystring;
            mypara2[1].Value = 1;
            mypara2[2].Value = 1;
            mypara2[3].Value = false;
            mypara2[4].Value = true;
           try
            {
                dataconnection.ExecuteSql(mypara2, sql2);
                result = true;
            }
            catch { result = false; }
           
        }
        
        return result;
    }
    /// <summary>
    /// 返回页数+记录条数
    /// </summary>
    /// <param name="tablename">表名，如lib_search</param>
    /// <param name="condition">基本格式为where 1=1 and 2=2</param>
    /// <param name="size"></param>
    /// <returns></returns>
    private int[] GetSearchNum(string tablename,string condition,int size)
    {
        int[] mynum=new int[2];
        sql = "select count(*) as num from ["+tablename+"] "+condition;
        try
        {
            SqlDataReader reader = dataconnection.GetDataReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    mynum[1] = int.Parse(reader["num"].ToString());
                    mynum[0] = mynum[1] / size;
                    if (mynum[1] % size > 0)
                        mynum[0] = mynum[0] + 1;
                }

            }
            else
            {
                mynum[0] = 1;
                mynum[1] = 0;
            }
            reader.Close();
        }
        catch {
            mynum[0] = 1;
            mynum[1] = 0;
        }
        return mynum;
    }
    /// <summary>
    /// 分页搜索返回了页码总数和记录总数，这个记录总数比较耗时间
    /// </summary>
    /// <param name="tablename">表名，可以为多个表</param>
    /// <param name="primarykey">主键</param>
    /// <param name="fieldlist">选取字段</param>
    /// <param name="condition">条件</param>
    /// <param name="order"> --排序 不含'order by'字符，如id asc,userid desc，必须指定asc或desc--注意当@SortType=3时生效，记住一定要在最后加上主键，否则会让你比较郁闷</param>
    /// <param name="SortType">排序规则 1:正序asc 2:倒序desc 3:多列排序方法</param>
    /// <param name="recordnum">记录总数：0--返回记录数，或者自己输入记录总数，这样就在第一页之后不再计算，提高效率</param>
    /// <param name="pagesize">每页显示数量</param>
    /// <param name="currentpage">当前页码</param>
    /// <returns></returns>
    public DataTable GetSearchList(string tablename,string primarykey, string fieldlist, string condition, string order, int SortType, int recordnum, int pagesize, int currentpage)
    {
        SqlParameter[] myparas ={ 
                    new SqlParameter("@TableName", SqlDbType.VarChar),
                    new SqlParameter("@FieldList", SqlDbType.VarChar),
                    new SqlParameter("@PrimaryKey", SqlDbType.VarChar),
                    new SqlParameter("@Where", SqlDbType.VarChar),
                    new SqlParameter("@Order", SqlDbType.VarChar),
                    new SqlParameter("@SortType", SqlDbType.Int),
                    new SqlParameter("@RecorderCount", SqlDbType.Int),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex",SqlDbType.Int),
                    new SqlParameter("@TotalCount", SqlDbType.Int),
                    new SqlParameter("@TotalPageCount", SqlDbType.Int)
        };
        myparas[0].Value = tablename;
        myparas[1].Value = fieldlist;
        myparas[2].Value = primarykey;//默认为id主键
        myparas[3].Value = condition;
        myparas[4].Value = order;
        myparas[5].Value = SortType;
        myparas[6].Value = recordnum;
        myparas[7].Value = pagesize;// newfun.No_SqlHack(condition);//过滤条件
        myparas[8].Value = currentpage;
        myparas[9].Direction = ParameterDirection.Output;
        myparas[10].Direction = ParameterDirection.Output;
        DataTable reader = dataconnection.StoredProcGetDataTable(myparas, "Lib_SearchPage");
        pagenum = int.Parse(myparas[10].Value.ToString());
        allnum =int.Parse( myparas[9].Value.ToString());
        return reader;
    }
    public SqlDataReader GetHotSearch(int num)
    {
        sql = "select top "+num+" * from [lib_search] where ischeck=1  order by istop desc, all_num desc";
        return dataconnection.GetDataReader(sql);
    }
    public SqlDataReader GetResult(string sql)
    {
        try { return dataconnection.GetDataReader(sql); }
        catch { return null; }
    }
    public int[] GetResultNum(string tablename,string condition,int pagesize)
    {
        sql="select count(*) as num from ["+tablename+"] where "+condition;
        int[] temp = new int[2];
        try
        {

           
                SqlDataReader reader = dataconnection.GetDataReader(sql);
                reader.Read();

                int nownums = int.Parse(reader["num"].ToString());
                int allpages = nownums / pagesize;
                if (nownums % pagesize > 0)
                    allpages = allpages + 1;
                reader.Close();
                
                temp[0]=allpages;
                temp[1]=nownums;
        }
         catch { temp[0]=1;temp[1]=0; }
         return temp;
           
        
    }
}
