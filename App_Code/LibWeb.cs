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
/// LibWeb 的摘要说明
/// </summary>
public class LibWeb
{
    private string title;
    private string keywords;
    private string descript;
    private int onlinenum;
    private int visitnum;
    private DataSystem dataconnection;//用于数据链接
    private string sql;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    public string KeyWord
    {
        get { return keywords; }
        set { keywords = value; }
    }
    public string Description
    {
        get { return descript; }
        set { descript = value; }
    }
    public int OnlineNum
    {
        get { return onlinenum; }
        set { onlinenum = value; }
    }
    public int VisitNum
    {
        get { return visitnum; }
        set { visitnum = value; }
    }
	public LibWeb()
    {
        dataconnection = new DataSystem();
        dataconnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBString"].ToString();
    }
    public void WebDataOpen()
    {
        dataconnection.Open();
    }
    public void WebDataClose()
    {
        dataconnection.Close();
    }
    public bool GetInfo()
    {
        sql = "select * from [lib_config]";
        try
        {
            SqlDataReader reader = dataconnection.GetDataReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    title = reader["title"].ToString();
                    keywords = reader["keyword"].ToString();
                    descript = reader["descript"].ToString();
                    onlinenum = int.Parse(reader["online"].ToString());
                    visitnum = int.Parse(reader["counter"].ToString());

                }
                reader.Close();
                return true;
            }
            else { reader.Close(); return false; }
        }
        catch { return false; }
    }
   
    public bool WebLogin()
    {
        sql = "update [lib_config] set counter=counter+1,online=online+1";

        try
        {
            if (dataconnection.ExecuteSql(sql) > 0)
                return true;
            else return false;
        }
        catch { return false; }

    }
    public bool WebLogout()
    {
        sql = "update [lib_config] set online=online-1";

        try
        {
            if (dataconnection.ExecuteSql(sql) > 0)
                return true;
            else return false;
        }
        catch { return false; }
    }
    /// <summary>
    /// 得到显示的计数效果
    /// </summary>
    /// <param name="thenum">计数数值</param>
    /// <param name="numlong">显示位数</param>
    /// <returns></returns>
    public string GetVisitNumView(int thenum,int numlong)
    {
        string temp = thenum.ToString();
       
        string output="";      
        for (int ii = numlong; ii > 0; ii--)
        {
            if(ii>temp.Length)
                output += "<span class=\"counter\">0</span>";
            else output += "<span class=\"counter\">" + temp.Substring(temp.Length-ii,1) + "</span>";
            
            
        }
        return output;
    }
    public SqlDataReader GetWebLinks(string type,int toupnum)
    {
        string addtop = " top "+toupnum.ToString();
        if (toupnum == 0)
            addtop = "";
        switch(type){
            case "xnlj":
                sql = "select "+addtop+"  * from [lib_links] where type='xnlj' order by orderlist desc";
                break;
            case "xwlj":
                sql = "select  " + addtop + "  * from [lib_links] where type='xwlj' order by orderlist desc";
                break;
            case "xnzy":
                sql = "select  " + addtop + "  * from [lib_links] where type='xnzy' order by orderlist desc";
                break;
            case "xwzy":
                sql = "select  " + addtop + "  * from [lib_links] where type='xwzy' order by orderlist desc";
                break;
            case "xkzywz":
                sql = "select  " + addtop + "  * from [lib_links] where type='xkzywz' order by orderlist desc";
                break;
            default:
                sql = "select  " + addtop + "  * from [lib_links] where type='xnlj' order by orderlist desc";
                break;
        };
        try
        {
          return  dataconnection.GetDataReader(sql);
        }
        catch { return null; }
    }
    public SqlDataReader GetLibZy(string typename, int topnum)
    {
        string addtop = " top " + topnum.ToString();
	sql = "select " + addtop + "  * from [lib_zy] where typename=@TypeName and is_index=1 order by orderlist desc";
        if (topnum == 0)
            sql = "select  * from [lib_zy] where typename=@TypeName and title<>'更多...'  order by orderlist desc";
       
        
        SqlParameter[] mypara ={ 
            new SqlParameter("@TypeName",SqlDbType.VarChar)
        };
        mypara[0].Value = typename;
        try
        {
            return dataconnection.GetDataReader(mypara,sql);
        }
        catch { return null; }
    }
    public Vote GetVoteOptions(string voteid)
    {
        Vote myvote = new Vote();
        myvote.VoteID = voteid;
        myvote.VoteDataOpen();
        myvote.GetVoteTitle();
        myvote.GetVoteOptions();
        myvote.VoteDataClose();
        return myvote;
    }
    //
    public SqlDataReader GetDepLoanTop(int num, DateTime starttime, DateTime endtime)
    {
        sql = "SELECT TOP " + num + "   COUNT_BIG (*) AS num, [lib_dep]._所属院系 as dep from [l_loanlog],[l_reader],[lib_dep] where [lib_dep]._所属院系<>'' and [lib_dep]._单位名称=[l_reader]._单位名称 and [l_loanlog]._读者条码 = [l_reader]._读者条码 AND [l_loanlog]._操作说明='借阅' AND [l_loanlog]._日期 BETWEEN  @StartTime and @EndTime GROUP BY [lib_dep]._所属院系 ORDER BY COUNT_BIG (*) DESC";
        if (num == 0)
            sql = "select COUNT_BIG (*) AS num, [lib_dep]._所属院系 as dep from [l_loanlog],[l_reader],[lib_dep] where [lib_dep]._所属院系<>'' and [lib_dep]._单位名称=[l_reader]._单位名称 and [l_loanlog]._读者条码 = [l_reader]._读者条码 AND [l_loanlog]._操作说明='借阅'  AND [l_loanlog]._日期 BETWEEN  @StartTime and @EndTime GROUP BY [lib_dep]._所属院系 ORDER BY COUNT_BIG (*) DESC";
        SqlParameter[] mypara = { 
            new SqlParameter("@StartTime", SqlDbType.DateTime),
            new SqlParameter("@EndTime",SqlDbType.DateTime)
           
            
        };
        mypara[0].Value = starttime;
        mypara[1].Value = endtime;
       
        try
        {
            SqlDataReader reader=dataconnection.GetDataReader(mypara,sql);
            return reader;
              
        }
        catch { return null; }
    }
    public SqlDataReader GetDownloadTop(int num)
    {
        sql = "select top " + num + " id,title,down_num from [lib_download] order by down_num desc,rank desc";
        try
        {
            return dataconnection.GetDataReader(sql);
        }
        catch { return null; }
    }
    public string[] GetPageInfo(string typename)
    {
        //读取内容
        sql = "select * from [lib_pages] where _标识字符='"+typename+"'";
        string[] result = new string[4];
        string temptype = "";
        try
        {
            SqlDataReader reader = dataconnection.GetDataReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result[0]=reader["_页面名称"].ToString(); //result[0]用于存放标题
                    result[1] = reader["_详细介绍"].ToString();//result[1]用于存放正文内容
                    temptype = reader["_所属类别"].ToString();
                    result[3] = reader["_所属类别"].ToString();
                }
            }
            else
            {
                result[0]= "暂无记录"; 
                result[1]= "暂无记录";
                result[3] = "";
            }
            reader.Close();
        }
        catch
        {
            result[0] = "读取错误";
            result[1] = "读取错误";
            result[3] = "读取错误";
        }
        //读取列表
        sql = "select _页面名称,_标识字符 from [lib_pages] where _所属类别='"+temptype+"'";
        try
        {
            SqlDataReader reader = dataconnection.GetDataReader(sql);
            if (reader.HasRows)
            {
                
                while (reader.Read())
                {
                    //result[2]用于存放左侧列表
                    if (reader["_标识字符"].ToString() == typename)
                        result[2] += " <a href=\"ViewPages.aspx?type=" + reader["_标识字符"].ToString() + "\"><div class=\"content_left_guid_item_on\" >" + reader["_页面名称"].ToString() + "</div> </a>";
                    else
                        result[2] += " <a href=\"ViewPages.aspx?type=" + reader["_标识字符"].ToString() + "\"><div class=\"content_left_guid_item\" >" + reader["_页面名称"].ToString() + "</div> </a>";
                }
            }
            else
            { result[2] = "暂无记录"; }
            reader.Close();
        }
        catch { result[2] = "读取错误"; }
        return result;
    }

    public SqlDataReader GetTypeList(string typename)
    {
        //读取内容
        sql = "select * from [lib_pages] where _标识字符='" + typename + "'";
        SqlDataReader reader = null;
        //_所属类别
        string temptype = "";
        try
        {
            reader = dataconnection.GetDataReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    temptype = reader["_所属类别"].ToString();
                }
            }
            else
            {
                /* result[0] = "暂无记录";
                 result[1] = "暂无记录";
                 result[3] = "";*/
            }
            reader.Close();
        }
        catch
        {
            /*result[0] = "读取错误";
            result[1] = "读取错误";
            result[3] = "读取错误";*/
        }
        //读取列表
        sql = "select _页面名称,_标识字符,_详细介绍 from [lib_pages] where _所属类别='" + temptype + "'";
        try
        {
            reader = dataconnection.GetDataReader(sql);
            return reader;
        }
        catch
        {
        }
        return reader;
    }
    public Model_LibWeb GetContent(string typename)
    {
        Model_LibWeb mModel_LibWeb = new Model_LibWeb();
        //读取内容
        sql = "select * from [lib_pages] where _标识字符='" + typename + "'";
        SqlDataReader reader = null;
      

        try
        {
            reader = dataconnection.GetDataReader(sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    mModel_LibWeb.Title = reader["_页面名称"].ToString();
                    mModel_LibWeb.Type = reader["_所属类别"].ToString();
                    mModel_LibWeb.Content = reader["_详细介绍"].ToString();
                }
            }
             
            reader.Close();
        }
        catch
        {
            /*result[0] = "读取错误";
            result[1] = "读取错误";
            result[3] = "读取错误";*/
        }

        return mModel_LibWeb;
    }
}
