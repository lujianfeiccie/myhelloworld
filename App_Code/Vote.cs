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
/// Vote 的摘要说明
/// </summary>
public class Vote
{
    private string title;
    private string[] options=new string[10];//最多不超过十个选项吧
    private string[] optionids = new string[10];
    private int[] num=new int[10];
    private bool isneedlogin;
    private string voteid;
    protected DataSystem dataconnection;//用于数据链接
    private string sql;
    public bool IsNeedLogin
    {
        set { isneedlogin = value; }
        get { return isneedlogin; }
    }
    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    public string[] Options
    {
        get { return options; }
        set { options = value; }
    }
    public string[] OptionsID
    {
        get { return optionids; }
        set { optionids = value; }
    }
    public int[] VoteNum
    {
        get { return num; }
        set { num = value; }
    }
    public string VoteID
    {
        get { return voteid; }
        set { voteid = value; }
    }
	public Vote()
	{
        for (int ii = 0; ii < 10; ii++)
        {
            num[ii] = 0;
            options[ii] = "";
            optionids[ii] = "";
        }
        dataconnection = new DataSystem();
        dataconnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBString"].ToString();
	}
    #region 数据链接操作
    public void VoteDataOpen()
    {
        dataconnection.Open();
    }
    public void VoteDataClose()
    {
        dataconnection.Close();
    }
    #endregion
    public void GetVoteTitle()
    {
        sql = "select * from [lib_vote_title] where id=@VoteID";
        SqlParameter[] mypara ={ new SqlParameter("@VoteID",SqlDbType.VarChar) };
        mypara[0].Value = voteid;
        SqlDataReader reader = dataconnection.GetDataReader(mypara, sql);
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                isneedlogin = bool.Parse(reader["is_need_login"].ToString());
                title = reader["title"].ToString();

            }
        }
        reader.Close();
    }
    public void GetVoteOptions()
    {
        sql = "select * from [lib_vote_option] where vote_id=@VoteID order by orderlist desc";
        SqlParameter[] mypara ={ new SqlParameter("@VoteID", SqlDbType.VarChar) };
        mypara[0].Value = voteid;
        SqlDataReader reader = dataconnection.GetDataReader(mypara, sql);
        if (reader.HasRows)
        {
            int ii = 0;
            while (reader.Read())
            {
                optionids[ii] = reader["id"].ToString();
                options[ii] = reader["title"].ToString();
                num[ii] = int.Parse(reader["real_num"].ToString());
                ii++;

            }
        }
        reader.Close();
    }
    public SqlDataReader GetVoteOptions_reader()
    {
        sql = "select * from [lib_vote_option] where vote_id=@VoteID order by orderlist desc";
        SqlParameter[] mypara ={ new SqlParameter("@VoteID", SqlDbType.VarChar) };
        mypara[0].Value = voteid;
        try
        {
            SqlDataReader reader = dataconnection.GetDataReader(mypara, sql);
            return reader;
        }
        catch { return null; }
        
    }
    public string ShowResult()
    {
        string output = "";
        //显示投票结果
        GetVoteTitle();
        GetVoteOptions();
        output = "<ul onclick='showoptions();'><li><strong>" + Title + "</strong></li>";
        double bigestnum = 0, allvotenum = 0;
        int optionsnum = 0;
        int width;
        for (int i = 0; i < Options.Length; i++)
        {
            if (Options[i] != "" && OptionsID[i] != "")
            {
                allvotenum += VoteNum[i];
                optionsnum++;
                if (VoteNum[i] > bigestnum)
                    bigestnum = VoteNum[i];

            }
        }
        for (int k = 0; k < optionsnum; k++)
        {
            width = (int)(100 * VoteNum[k] / bigestnum);
            output += "<li><img src=\"images/page_num_on.jpg\" height=\"18\" width=\"" + width.ToString() + "\" />" + Options[k] + "(" + VoteNum[k].ToString() + ")</li>";
        }
        output += "</ul>";
        return output;
    }
}
