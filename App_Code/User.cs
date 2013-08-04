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
using System.Collections.Generic;
using System.Collections.Specialized;
/// <summary>
/// User 用户类
/// </summary>
public class User
{//请加入以下两个方法到user这个类中  
  public int GetHistoryNum(DateTime datetime1, DateTime datetime2, int size)
    {
        string condition = "[l_loanlog]._图书条码=[l_codebar]._图书条码  and [l_codebar].recid=[bib].recid and [l_loanlog]._读者条码=@UserID and ([l_loanlog]._日期 between @DateTime1 and @DateTime2)";

        sql = "select count(*) as allnum  from [bib],[l_loanlog],[l_codebar] where "+condition;
        SqlParameter[] myparas ={
            new SqlParameter("@UserID", SqlDbType.VarChar),
            new SqlParameter("@DateTime1",SqlDbType.DateTime),
            new SqlParameter("@DateTime2",SqlDbType.DateTime)
        };
        myparas[0].Value = userid;
        myparas[1].Value = datetime1;
        myparas[2].Value = datetime2;
        try
        {
            SqlDataReader reader = dataconnection.GetDataReader(myparas, sql);
            reader.Read();

            int nownums = int.Parse(reader["allnum"].ToString());
            int allpages = nownums / size;
            if (nownums % size > 0)
                allpages = allpages + 1;
            reader.Close();
            return allpages;
       }
       catch { return 1; }
    }
public SqlDataReader GetMyHistory(DateTime datetime1,DateTime datetime2,int pagesize, int nowpage)
    {
        int topbefore = (nowpage - 1) * pagesize;
        string condition = "_读者条码=@UserID and (_日期 between @DateTime1 and @DateTime2) order by _日期 desc";
        sql = "select top "+pagesize+" * from [lib_reader_history] where id not in(select top "+topbefore+" id from [lib_reader_history] where "+condition+") and "+condition;
        SqlParameter[] myparas ={ 
            new SqlParameter("@UserID", SqlDbType.VarChar),
            new SqlParameter("@DateTime1",SqlDbType.DateTime),
            new SqlParameter("@DateTime2",SqlDbType.DateTime)  
        };
        myparas[0].Value = userid;
        myparas[1].Value = datetime1;
        myparas[2].Value = datetime2;
        //try
        //{
            return dataconnection.GetDataReader(myparas, sql);
        //}
       // catch { return null; }    
    }
    public User()
	{
        username = "";
        dataconnection = new DataSystem();
        dataconnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBString"].ToString();
	}
    public User(string un)
    {
        username = un;
        dataconnection = new DataSystem();
        dataconnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBString"].ToString();
    }
    public User(int uid)
    {
        userid = uid.ToString();
        username = "";
        dataconnection = new DataSystem();
        dataconnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBString"].ToString();
    }
    private string username;
    private string userid;
    private string password;
    private string usertype;//在网站的类型，如管理员，普通用户，高级用户
    private bool ischecked;
    private string userdepartment;
    private string gender;
    private string realname;
    private string zhengjian;
    private int nowrent;//已经借出书目
    private int allrent;//总借出书目
    private string state;//证件状态
    private DateTime cardtime;//办证时间
    private double money;//欠款金额
    private string readertype;//读者类型
    private string lastip;
    private DateTime lasttime;
    private string loginip;
    private DateTime logintime;
    private int logintimes;
    private string password_question;
    private string password_answer;
    protected DataSystem dataconnection;//用于数据链接
    private string sql;

    public string RealName
    {
        get { return realname; }
        set { realname = value; }
    }
    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }
    public string State
    {
        get { return state; }
        set { state = value; }
    }
    public double Money
    {
        get { return money; }
        set { money = value; }
    }
    public DateTime CardTime
    {
        set { cardtime = value; }
        get { return cardtime; }
    }
    public int TotalRent
    {
        get { return allrent; }
        set { allrent = value; }
    }
    public int NowRent
    {
        get { return nowrent; }
        set { nowrent = value; }
    }
    public string ZhengJian
    {
        get { return zhengjian; }
        set { zhengjian = value; }
    }

    public string UserName
    {
        get { return username; }
        set { username = value; }

    }
    public string UserID
    {
        get { return userid; }
        set { userid = value; }
    }
    public bool IsChecked
    {
        get { return ischecked; }
        set { ischecked = value; }
    }
    /// <summary>
    /// 在网站的类型，如管理员什么的
    /// </summary>
    public string UserType
    {
        get { return usertype; }
        set { usertype = value; }
    }
    public string UserDepartment
    {
        set { userdepartment = value; }
        get { return userdepartment; }
    }
    /// <summary>
    /// 根据图书证号得到的读者类型
    /// </summary>
    public string ReaderType
    {
        set { readertype = value; }
        get { return readertype; }
    }
    public string PassWord
    {
        set { password = value; }
        get { return password; }
    }
    public string FindPswQuestion
    {
        set { password_question = value; }
        get { return password_question; }
    }
    public string FindPswAnswer
    {
        get { return password_answer; }
        set { password_answer = value; }
    }
    public DateTime LastLoginTime
    {
        get { return lasttime; }
        set { lasttime = value; }
    }
    public string LastLoginIP
    {
        get { return lastip; }
        set { lastip = value; }
    }
    public int LoginTimes
    {
        get { return logintimes; }
        set { logintimes = value; }
    }
    public DateTime LoginTime
    {
        set { logintime = value; }
        get { return logintime; }
    }
    public string LoginIP
    {
        set { loginip = value; }
        get { return loginip; }
    }

    #region 数据链接操作
    public void UserDataOpen()
    {
        dataconnection.Open();
    }
    public void UserDataClose()
    {
        dataconnection.Close();
    }
    #endregion
    #region
 /// <summary>
 /// 
 /// </summary>
 /// <param name="card"></param>
 /// <param name="dfsjf"></param>
 /// <returns></returns>
    public string UserCheck(string card,bool dfsjf)
    {
        string result = "";
        sql = "select _读者条码 from [l_reader] where _读者条码=@UserID";
        SqlParameter[] mypara ={ new SqlParameter("@UserID", SqlDbType.NVarChar,12) };
        mypara[0].Value = card;
        SqlDataReader reader = dataconnection.GetDataReader(mypara, sql);
        if (reader.HasRows)
        {
            reader.Close();
            sql = "select userid from [lib_user] where userid=@UserCard";
            SqlParameter[] myparas ={ new SqlParameter("@UserCard",SqlDbType.VarChar)};
            myparas[0].Value = card;
            reader = dataconnection.GetDataReader(myparas, sql);
            if (reader.HasRows)
            {
                result = "已经被注册了！";
            }
            else {
                result = "可用的卡号！";
            }
            reader.Close();
        }
        else
        {
            reader.Close();
            result = "非法的卡号！";
        }
        return result;
    }
    /// <summary>
    /// 检查用户名是否重合存在的重构
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool UserCheck(string name)
    {
        sql = "select username from [lib_user] where username=@UserName";
        SqlParameter[] mypara = { new SqlParameter("@UserName", SqlDbType.VarChar, 50) };
        mypara[0].Value = name;
        SqlDataReader reader = dataconnection.GetDataReader(mypara, sql);
        if (reader.HasRows)
        {
            reader.Close();
            return true;
        }
        else
        {
            reader.Close();
            return false;
        }
    }
    #endregion

    /// <summary>
    /// 用户注册
    /// </summary>
    /// <returns></returns>
    public string UserRegister()
    {
        if (UserCheck(this.username) || (UserCheck(this.userid, true) != "可用的卡号！")) //如果已经注册
        {
            return "isused";
        }
        else
        {
            sql = "insert into [lib_user] (username,userid,password,reg_time,login_time,login_ip,login_times,psw_question,psw_answer) values (@UserName,@UserID,@PassWord,@RegTime,@LoginTime,@LoginIP,'1',@PswQuestion,@PswAnswer) ";
            SqlParameter[] myparas ={ 
                    new SqlParameter("@UserName", SqlDbType.VarChar),
                    new SqlParameter("@UserID", SqlDbType.VarChar),
                    new SqlParameter("@PassWord", SqlDbType.VarChar),
                    new SqlParameter("@RegTime", SqlDbType.DateTime),
                    new SqlParameter("@LoginTime", SqlDbType.DateTime),
                    new SqlParameter("@LoginIP", SqlDbType.VarChar),
                    new SqlParameter("@PswQuestion", SqlDbType.VarChar),
                    new SqlParameter("@PswAnswer", SqlDbType.VarChar)
                   
                   
        };

            myparas[0].Value = username;
            myparas[1].Value = userid;
            myparas[2].Value = password;
            myparas[3].Value = DateTime.Now;
            myparas[4].Value = DateTime.Now ;
            myparas[5].Value = loginip;
            myparas[6].Value = password_question;
            myparas[7].Value = password_answer;
            try 
            {
                if (dataconnection.ExecuteSql(myparas, sql) > 0)
                    return "ok";
                else return "failed!";
            }
            catch { return "failed!"; }
           
        }

    }
    public bool UserLogin()
    {
        sql = "update  [lib_user] set last_time=login_time,last_ip=login_ip,login_times=login_times+1,login_time=@LoginTime,login_ip=@LoginIP where username=@UserName and password=@Password and ischeck=1";
        SqlParameter[] myparas ={ 
                    new SqlParameter("@UserName", SqlDbType.VarChar),
                    new SqlParameter("@PassWord", SqlDbType.VarChar),
                   
                    new SqlParameter("@LoginTime", SqlDbType.DateTime),
                    new SqlParameter("@LoginIP", SqlDbType.VarChar)
                    
                   
                   
        };

        myparas[0].Value = username;
        myparas[1].Value = password;
        myparas[2].Value = DateTime.Now;
        myparas[3].Value = loginip;
        
        try
        {
            if (dataconnection.ExecuteSql(myparas, sql) > 0)
                return true;
            else return false;
        }
        catch { return false; }
    }
    #region
    
    public bool GetUserInfo()
    {

        sql = "select l_reader.*,lib_user.* from [l_reader],[lib_user] where [l_reader]._读者条码=[lib_user].userid and [lib_user].username=@UserID";
        SqlParameter[] mypara ={ new SqlParameter("@UserID",SqlDbType.VarChar) };
        mypara[0].Value = username;
        try
        {
            SqlDataReader reader = dataconnection.GetDataReader(mypara, sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    password = reader["password"].ToString();
                    password_question = reader["psw_question"].ToString();
                    password_answer = reader["psw_answer"].ToString();
                    userdepartment = reader["_单位名称"].ToString();
                    realname = reader["_读者姓名"].ToString();
                    gender = reader["_性别"].ToString();
                    cardtime = DateTime.Parse(reader["_办证日期"].ToString());
                    nowrent = int.Parse(reader["_已借册数"].ToString());
                    allrent = int.Parse(reader["_累借册次"].ToString());
                    money = double.Parse(reader["_欠款金额"].ToString());
                    state = reader["_证件状态"].ToString();
                    readertype = reader["_读者类型"].ToString();
                    userid = reader["userid"].ToString();
                    lastip = reader["last_ip"].ToString();
                    ischecked = bool.Parse(reader["ischeck"].ToString());
                    lasttime = DateTime.Parse(reader["last_time"].ToString());
                    logintimes = int.Parse(reader["login_times"].ToString());
                    

                   

                }
                reader.Close();
                return true;

            }
            else { reader.Close(); return false; }
        }
        catch { return false; }
    }
    public string ChangePassword(string newpsw)
    {
        sql = "update [lib_user] set password=@NewPassword where username=@UserName and password=@PassWord";
        SqlParameter[] mypara ={ 
            new SqlParameter("@NewPassword",SqlDbType.VarChar),
            new SqlParameter("@UserName",SqlDbType.VarChar),
            new SqlParameter("@PassWord",SqlDbType.VarChar)

        };
        mypara[0].Value = newpsw;
        mypara[1].Value = username;
        mypara[2].Value = password;
        try {
            if (dataconnection.ExecuteSql(mypara, sql) > 0)
                return "修改成功！";
            else
                return "修改失败！";
            }
        catch { return "对不起，系统错误！"; }
    }
    public string UpdateInfo()
    {
        sql = "update [lib_user] set password=@NewPassword,psw_question=@Question,psw_answer=@Answer where username=@UserName";
        SqlParameter[] mypara ={ 
            new SqlParameter("@NewPassword",SqlDbType.VarChar),
            new SqlParameter("@Question",SqlDbType.VarChar),
            new SqlParameter("@Answer",SqlDbType.VarChar),
            new SqlParameter("@UserName",SqlDbType.VarChar)

        };
        mypara[0].Value = password;
        mypara[1].Value = password_question;
        mypara[2].Value = password_answer;
        mypara[3].Value=username;
        try
        {
            if (dataconnection.ExecuteSql(mypara, sql) > 0)
                return "修改成功！";
            else
                return "修改失败！";
        }
        catch { return "对不起，系统错误！"; }
        
    }

    public bool VistVote(string optionid, string ip)
    {
        sql = "update [lib_vote_option] set real_num=real_num+1 where id=@OptionID";
        
        SqlParameter[] mypara ={ new SqlParameter("@OptionID",SqlDbType.VarChar) };
        mypara[0].Value = optionid;
        try
        {
            dataconnection.ExecuteSql(mypara, sql);
            AddVoteLog(optionid, ip);
            return true;

        }
        catch { return false; }
    }
    private bool AddVoteLog(string optionid, string ip)
    {
        sql = "insert into [lib_vote_log] (ip,vote_time,option_id,username) values (@IP,@VoteTime,@OptionID,@UserName)";

        SqlParameter[] mypara ={ 
            new SqlParameter("@OptionID", SqlDbType.VarChar),
            new SqlParameter("@IP",SqlDbType.VarChar),
            new SqlParameter("@VoteTime",SqlDbType.DateTime),
            new SqlParameter("@UserName",SqlDbType.VarChar)
        };
        mypara[0].Value = optionid;
        mypara[1].Value = ip;
        mypara[2].Value = DateTime.Now;
        mypara[3].Value = username;
        try
        {
            dataconnection.ExecuteSql(mypara, sql);
            return true;
        }
        catch { return false; }
    }
    #endregion
    /// <summary>
    /// 得到预约的列表
    /// </summary>
    /// <returns></returns>
    public SqlDataReader GetResever()
    {
        sql = "select * from [l_reserve] where _读者条码=@UserID";
        SqlParameter[] myparas ={ new SqlParameter("@UserID", SqlDbType.VarChar) };
        myparas[0].Value = userid;
        try
        {
            return dataconnection.GetDataReader(myparas, sql);
        }
        catch { return null; }
    
    }
    /// <summary>
    /// 删除预约信息
    /// </summary>
    /// <returns></returns>
    public string DeleteResever(string faid)
    {
        sql = "delete from [l_reserve] where id=@Fid";
        SqlParameter[] myparas ={ 
            new SqlParameter("@Fid",SqlDbType.VarChar)
           
        };
        myparas[0].Value = faid;

        try
        {
            if (dataconnection.ExecuteSql(myparas, sql) > 0)
                return "ok";
            else
                return "对不起，系统错误";
        }
        catch { return "对不起，系统错误"; }
    }
    public SqlDataReader GetMyMail()
    {
        sql = "select * from [lib_note] where ismail='1' and  pub_user=@UserID order by pub_time desc";
        SqlParameter[] myparas ={ new SqlParameter("@UserID", SqlDbType.VarChar) };
        myparas[0].Value = username;
        try
        {
            return dataconnection.GetDataReader(myparas, sql);
        }
        catch { return null; }
    }
    public SqlDataReader GetBorrowInfo()
    {
        sql = "select [bib]._题名,[l_loan]._图书条码,[l_loan]._应还日期,[l_loan]._续借标识,[bib].recid,RTRIM(bib._分类) + '/' + RTRIM(bib._书次) AS [_分类] from [bib],[l_loan] where [l_loan].recid=[bib].recid and [l_loan]._读者条码=@UserID";
        SqlParameter[] myparas ={ new SqlParameter("@UserID",SqlDbType.VarChar) };
        myparas[0].Value = userid;
      try
       {
            return dataconnection.GetDataReader(myparas, sql);
       }
      catch { return null; }
    }
    public SqlDataReader GetMyHistory(DateTime datetime1,DateTime datetime2)
    {
        sql = "select [bib]._题名,[l_loanlog]._图书条码,[l_loanlog]._日期,[bib].recid,[bib]._分类 from [bib],[l_loanlog],[l_codebar] where [l_loanlog]._图书条码=[l_codebar]._图书条码  and [l_codebar].recid=[bib].recid and [l_loanlog]._读者条码=@UserID and ([l_loanlog]._日期 between @DateTime1 and @DateTime2) order by [l_loanlog]._日期 desc";
        SqlParameter[] myparas ={ 
            new SqlParameter("@UserID", SqlDbType.VarChar),
            new SqlParameter("@DateTime1",SqlDbType.DateTime),
            new SqlParameter("@DateTime2",SqlDbType.DateTime)
           
        };

        myparas[0].Value = userid;
        myparas[1].Value = datetime1;
        myparas[2].Value = datetime2;
        //try
        //{
            return dataconnection.GetDataReader(myparas, sql);
        //}
       // catch { return null; }
        
    }
    /// <summary>
    /// 得到读者续借天数
    /// </summary>
    ///
    /// <returns></returns>

    private int getRenewDay()
    {
        SqlParameter[] myparas ={ 
        
            new SqlParameter("@readerCodebar", SqlDbType.Char),
            new SqlParameter("result", SqlDbType.Int),
            new SqlParameter("@renewDay", SqlDbType.Int)
        };
        myparas[0].Value = userid;
        myparas[1].Direction = ParameterDirection.ReturnValue;
        myparas[2].Direction = ParameterDirection.Output;
        

        int renewDay = 0;

        try
        {
            dataconnection.StoredProcExecute(myparas, "sp_search_getRenewDay");
            int result = (int)myparas[1].Value;
            if (result != -1) //读者存在
            {
                renewDay = (int)myparas[2].Value;
            }

            
        }
        catch (SqlException ex)
        {
           return 0;
        }
        return renewDay;
    }
    /// <summary>
    /// 执行本地续借
    /// </summary>
    /// <param name="codebar">图书条码</param>
    /// <param name="renewDay">续借天数</param>
    private string doRenew(string codebar, int renewDay)
    {
        SqlParameter[] myparas ={ 
        
            new SqlParameter("@readerCodebar", SqlDbType.Char),
            new SqlParameter("@codebar", SqlDbType.Char),
            new SqlParameter("@renewDay", SqlDbType.Int),

            new SqlParameter("result", SqlDbType.Int),
            new SqlParameter("@returnDate", SqlDbType.DateTime)
        };
        myparas[0].Value = userid;
        myparas[1].Value = codebar;
        myparas[2].Value = renewDay;
        myparas[3].Direction = ParameterDirection.ReturnValue;
        myparas[4].Direction = ParameterDirection.Output;

        try
        {
            dataconnection.StoredProcExecute(myparas, "sp_search_renew3");
            int result = (int)myparas[3].Value;
            string returnDate = (string)myparas[4].Value.ToString();
            if (result == 1)
            {
                return "<font color='blue'>编号为"+codebar+"的图书续借成功</font>" +
                    "您的续借将于 <font color='red'>" + returnDate + "</font> 到期，" +
                    "请按时归还，谢谢。";
            }
            else if (result == 2)
            {
                return "您已经续借过编号为" + codebar + "的图书，您不能再次续借，请按时归还，谢谢合作！";
            }
            else if (result == 3)
            {
                return "编号为" + codebar + "的图书已经超期，您不能续借，请按时归还，谢谢合作！";
            
            }
            else if (result == -1)
            {
                return "续借失败，请正确登陆。";
            }
            else { return ""; }
        }
        catch (SqlException ex)
        {
            return ex.ToString();
        }
    }
    public string DelayBook(string bookid,int days)
    {
        /**
         * 1. 根据读者条码到本地或远程获得该读者可以续借的天数
         * 2. 到图书所在位置（本地或远程）执行续借
         * 用到的存储过程为：sp_search_getRenewDay, sp_search_renew2
         */
        #region 用 sp_search_renew2。执行本地或远程续借

        NameValueCollection urls = (NameValueCollection)ConfigurationManager.GetSection("serviceSites/siteUrl");
        NameValueCollection tokens = (NameValueCollection)ConfigurationManager.GetSection("serviceSites/siteToken");

        string readerFromWhereKey = "601";
        string bookFromWhereKey = "601";

        string readerUrl = urls[readerFromWhereKey].ToString(); //读者所在位置
        string bookUrl = urls[bookFromWhereKey].ToString(); //图书所在位置

        string readerCodebar = userid; //读者条码
        string codebar = bookid; //图书条码

        int renewDay = 0; //续借天数

        //在本地数据库查询读者续借天数
        if (readerUrl.Equals("local"))
        {
            renewDay = getRenewDay();
        }
        else //通过 web service 查询远程数据库
        {
            string[] args = new string[2];
            args[0] = readerCodebar;
            string token = tokens[readerFromWhereKey].ToString();
            args[1] = token;
            renewDay = (int)WebServiceHelper.InvokeWebService(readerUrl, "getRenewDay", args);
        }

        //在本地数据库进行续借
        if (bookUrl.Equals("local"))
        {
          return  doRenew(codebar, renewDay);
        }
        else //通过 web service 在远程数据库进行续借
        {
            object[] args = new object[4];
            args[0] = readerCodebar;
            args[1] = codebar;
            args[2] = renewDay;
            string token = tokens[bookFromWhereKey].ToString();
            args[3] = token;
            object[] obj = (object[])WebServiceHelper.InvokeWebService(bookUrl, "doRenew", args);
            int ddddd = Convert.ToInt16(obj[0]);
            string fffff = obj[1].ToString();
            if (ddddd == 1)
            {
                return "<font color='blue'>编号为" + codebar + "的图书续借成功</font><br/>" +
                    "您的续借将于 <font color='red'>" + fffff + "</font> 到期，" +
                    "请按时归还，谢谢。";
            }
            else if (ddddd == 2)
            {
                return "您已经续借过编号为" + codebar + "的图书，您不能再次续借，请按时归还，谢谢合作！";
            }
            else if (ddddd == -1)
            {
                return "续借失败，请正确登陆。";
            }
            else { return ""; }
        }

        #endregion





        //以前自己写的好像不行喔
      //  sql = "update [l_loan] set _应还日期=dateadd(day,@Day,_应还日期),_续借标识=1 where _读者条码=@UserID and _图书条码=@BookID and _续借标识=0";
      //  SqlParameter[] mypara ={ 
      //      new SqlParameter("@Day",SqlDbType.Int),
      //      new SqlParameter("@UserID",SqlDbType.VarChar),
      //      new SqlParameter("@BookID",SqlDbType.VarChar)
      //  };
      //  mypara[0].Value = days;
      //  mypara[1].Value = userid;
      //  mypara[2].Value = bookid;

      //try
      // {
      //      dataconnection.ExecuteSql(mypara, sql);
      //      return true;
      // }
      //catch { return false; }
    }
    public string UpdateNoteOver(string noteid,string replyinfo)
    {
        sql = "update [lib_note] set isover=1,replytime=@RTime,replyuser=@UserName,replyinfo=@ReplyInfo where id=@NoteID";
        SqlParameter[] mypara ={ new SqlParameter("@NoteID",SqlDbType.VarChar),
            new SqlParameter("@UserName",SqlDbType.VarChar),
            new SqlParameter("@ReplyInfo",SqlDbType.Text),
            new SqlParameter("@RTime",SqlDbType.DateTime)
        };
        mypara[0].Value = noteid;
        mypara[1].Value = username;
        mypara[2].Value = replyinfo;
        mypara[3].Value = DateTime.Now;
        try
        {
            if (dataconnection.ExecuteSql(mypara, sql) > 0)
                return "ok";
            else
                return "对不起，系统错误";
        }
        catch { return "对不起，系统错误"; }
    }
    public string AddLibNote(LibNote mynote)
    {
        sql = "insert into [lib_note] (title,info,pub_time,pub_user,pub_ip,ischeck,check_admin,isover,ismail,replytime,istop,typename,visit_num)"
             +"values (@Title,@Info,@PubTime,@PubUser,@PubIP,@IsCheck,@CheckAdmin,@IsOver,@IsMail,@ReplyTime,@IsTop,@TypeName,@VisitNum)";
        SqlParameter[] mypara ={ 
            new SqlParameter("@Title",SqlDbType.VarChar),
            new SqlParameter("@Info",SqlDbType.VarChar),
            new SqlParameter("@PubTime",SqlDbType.DateTime),
            new SqlParameter("@PubUser",SqlDbType.VarChar),
             new SqlParameter("@PubIP",SqlDbType.VarChar),
             new SqlParameter("@IsCheck",SqlDbType.Bit),
             new SqlParameter("@CheckAdmin",SqlDbType.VarChar),
             new SqlParameter("@IsOver",SqlDbType.Bit),
             new SqlParameter("@IsMail",SqlDbType.Bit),
             new SqlParameter("@ReplyTime",SqlDbType.DateTime),
             new SqlParameter("@IsTop",SqlDbType.Bit),
             new SqlParameter("@TypeName",SqlDbType.VarChar),
            new SqlParameter("@VisitNum",SqlDbType.Int)
        };
        mypara[0].Value = mynote.Title;
        mypara[1].Value = mynote.Info;
        mypara[2].Value = DateTime.Now;
        mypara[3].Value = mynote.PubUser;
        mypara[4].Value = mynote.PubIP;
        mypara[5].Value = mynote.IsCheck;
        mypara[6].Value = mynote.CheckAdmin;
        mypara[7].Value = mynote.IsOver;
        mypara[8].Value = mynote.IsMail;
        mypara[9].Value = DateTime.Now ;
        mypara[10].Value = mynote.IsTop;
        mypara[11].Value = mynote.TypeName;
        mypara[12].Value = mynote.VisitNum;
       try
        {
            if (dataconnection.ExecuteSql(mypara, sql) > 0)
                return "ok";
            else
                return "对不起，系统错误";
        }
        catch { return "对不起，系统错误"; }
    }
    public string AddRerveBook(string bookid)
    {
        SqlParameter[] myparas ={ 
            new SqlParameter("@BookID",SqlDbType.VarChar),
            new SqlParameter("@UserID",SqlDbType.VarChar),
            new SqlParameter("result",SqlDbType.Int)
        };
        myparas[0].Value = bookid;
        myparas[1].Value = userid;
        myparas[2].Direction = ParameterDirection.ReturnValue;
        //try
       // {
        dataconnection.StoredProcExecute(myparas, "sp_search_reserve2");
            int result = (int)myparas[2].Value;
            if (result ==1)
                return "成功预约了编号为" + bookid + "的图书";
            else if (result == 2)
                return "您有超期的图书没有归还，不能预约！";
            else if (result==3)
                return "对不起，有人已经预约了编号为" + bookid + "的图书";
            else return "系统错误，请稍后重试！";
      //  }
       // catch { return "系统错误，稍后请重试！"; }
    }
    public string AddFavorite(string recid)
    {
        string sql1 = "select id from [lib_user_favorite] where username=@UserName and recid=@Recid";
        sql = "insert into [lib_user_favorite] (username,recid) values (@UserName,@Recid)";
        SqlParameter[] myparas ={ 
            new SqlParameter("@UserName",SqlDbType.VarChar),
            new SqlParameter("@Recid",SqlDbType.VarChar)
        };
        myparas[0].Value = username;
        myparas[1].Value = recid;
        SqlParameter[] mypara ={ 
            new SqlParameter("@UserName",SqlDbType.VarChar),
            new SqlParameter("@Recid",SqlDbType.VarChar)
        };
        mypara[0].Value = username;
        mypara[1].Value = recid;
        SqlDataReader reader = dataconnection.GetDataReader(myparas, sql1);
        bool ishasrow = reader.HasRows;
        reader.Close();
        if (!ishasrow)
        {
            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "ok";
                else
                    return "对不起，系统错误";
            }
            catch { return "对不起，系统错误"; }
        }
        else
        { return ""; }
    }
    public SqlDataReader GetFavoriteList()
    {
        sql = "select bib._题名,bib._出版者,bib._出版日期,bib._分类,bib.recid,bib._责任者,bib._复本,lib_user_favorite.id from bib,lib_user_favorite where lib_user_favorite.username=@Username and bib.recid=lib_user_favorite.recid order by id desc";
        SqlParameter[] myparas ={ 
            new SqlParameter("@UserName",SqlDbType.VarChar)
           
        };
        myparas[0].Value = username;
       
        try
        {
            return dataconnection.GetDataReader(myparas, sql);
        }
        catch { return null; }
    }
    public string DeleteFavorite(string faid)
    {
        sql = "delete from [lib_user_favorite] where id=@Fid";
        SqlParameter[] myparas ={ 
            new SqlParameter("@Fid",SqlDbType.VarChar)
           
        };
        myparas[0].Value = faid;
       
        try
        {
            if (dataconnection.ExecuteSql(myparas, sql) > 0)
                return "ok";
            else
                return "对不起，系统错误";
        }
        catch { return "对不起，系统错误"; }
    }
}
