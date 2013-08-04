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
using System.IO;

/// <summary>
/// Admin 的摘要说明
/// </summary>
public class Admin:User
{
    private string sql;
    private bool news_op;
    private bool notice_op;
    private bool links_op;
    private bool vote_op;
    private bool user_op;
    private bool web_op;
    private bool download_op;
    private bool search_op;
    private bool book_op;
    private bool paper_op;
    private bool note_op;
    private bool zy_op;

    public bool ZyOP
    {
        get { return zy_op; }
        set { zy_op = value; }
    }
    public bool BookOP
    {
        get { return book_op; }
        set { book_op = value; }
    }
    public bool PaperOP
    {
        get { return paper_op; }
        set { paper_op = value; }
    }
    public bool NoteOP//网站留言管理
    {
        get { return note_op; }
        set { note_op = value; }
    }
    public bool NewsOP//操作新闻权限
    {
        get { return news_op; }
        set { news_op = value; }
    }
    public bool NoticeOP
    {
        get { return notice_op; }
        set { notice_op = value; }
    }
    public bool LinkOP
    {
        get { return links_op; }
        set { links_op = value; }
    }
    public bool VoteOP
    {
        get { return vote_op; }
        set { vote_op = value; }
    }
    public bool UserOP
    {
        get { return user_op; }
        set { user_op = value; }
    }
    public bool WebOP
    {
        get { return web_op; }
        set { web_op = value; }
    }
    public bool DownloadOP
    {
        get { return download_op; }
        set { download_op = value; }
    }
    public bool SearchOP
    {
        set { search_op = value; }
        get { return search_op; }
    }
	public Admin()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}


    public string WebSet(LibWeb myweb)
    {
        if (web_op)
        {
            string sql = "update [lib_config] set title=@Title,keyword=@KeyWords,descript=@Descript,counter=@Counter,online=@OnlineNum";
            SqlParameter[] mypara = { 
            new SqlParameter("@Title", SqlDbType.VarChar),
            new SqlParameter("@KeyWords",SqlDbType.Text),
            new SqlParameter("@Descript",SqlDbType.Text),
            new SqlParameter("@Counter",SqlDbType.Int),
            new SqlParameter("@OnlineNum",SqlDbType.Int)
            
        };
            mypara[0].Value = myweb.Title;
            mypara[1].Value = myweb.KeyWord;
            mypara[2].Value = myweb.Description;
            mypara[3].Value = myweb.VisitNum;
            mypara[4].Value = myweb.OnlineNum;

            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "ok";
                else return "对不起更新错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else
        {
            return "对不起，您没有操作此项目的权限！";
        }
    }
    public string PageInfoSet(string typename, string title, string info)
    {
        if (web_op)
        {
            string sql = "update [lib_pages] set _页面名称=@Title,_详细介绍=@KeyWords where _标识字符=@TypeName";
            SqlParameter[] mypara = { 
            new SqlParameter("@Title", SqlDbType.VarChar),
            new SqlParameter("@KeyWords",SqlDbType.Text),
            new SqlParameter("@TypeName",SqlDbType.VarChar)
            
        };
            mypara[0].Value = title;
            mypara[1].Value =info;
            mypara[2].Value = typename;

            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "ok";
                else return "对不起更新错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else
        {
            return "对不起，您没有操作此项目的权限！";
        }
        
    }


    public bool AdminLogin()
    {
        sql = "update  [lib_user] set last_time=login_time,last_ip=login_ip,login_times=login_times+1,login_time=@LoginTime,login_ip=@LoginIP where username=@UserName and password=@Password and ischeck=1 and user_type like '%管理员'";
        SqlParameter[] myparas ={ 
                    new SqlParameter("@UserName", SqlDbType.VarChar),
                    new SqlParameter("@PassWord", SqlDbType.VarChar),
                   
                    new SqlParameter("@LoginTime", SqlDbType.DateTime),
                    new SqlParameter("@LoginIP", SqlDbType.VarChar)
                    
                   
                   
        };

        myparas[0].Value = UserName;
        myparas[1].Value = PassWord;
        myparas[2].Value = DateTime.Now;
        myparas[3].Value = LoginIP;

        try
        {
            if (dataconnection.ExecuteSql(myparas, sql) > 0)
                return true;
            else return false;
        }
        catch { return false; }
        
    }
    public bool GetAdminInfo()
    {
        bool result=false;
        sql = "select * from [lib_user] where username=@UserName";
        SqlParameter[] mypara ={ new SqlParameter("@UserName",SqlDbType.VarChar)};
        mypara[0].Value = UserName;
        try
        { 
            SqlDataReader reader=dataconnection.GetDataReader(mypara,sql);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UserID = reader["userid"].ToString();
                    UserType = reader["user_type"].ToString();
                    LastLoginIP = reader["last_ip"].ToString();
                    LastLoginTime = DateTime.Parse(reader["last_time"].ToString());
                    LoginTimes = int.Parse(reader["login_times"].ToString());
                    IsChecked = bool.Parse(reader["ischeck"].ToString());
                    news_op = bool.Parse(reader["news_op"].ToString());
                    notice_op = bool.Parse(reader["notice_op"].ToString());
                    links_op = bool.Parse(reader["links_op"].ToString());
                    vote_op = bool.Parse(reader["vote_op"].ToString());
                    web_op = bool.Parse(reader["web_op"].ToString());
                    user_op = bool.Parse(reader["user_op"].ToString());
                    search_op = bool.Parse(reader["search_op"].ToString());
                    download_op = bool.Parse(reader["download_op"].ToString());
                    book_op = bool.Parse(reader["book_op"].ToString());
                    paper_op = bool.Parse(reader["paper_op"].ToString());
                    note_op = bool.Parse(reader["note_op"].ToString());
                    zy_op = bool.Parse(reader["zy_op"].ToString());

                }
                result = true;
            }
            else
            { result = false; }
            reader.Close();
        }
        catch { result = false; }
        return result;
    }
    /// <summary>
    /// 这个是添加自己所以要重新定义一个实例才行
    /// </summary>
    /// <returns></returns>
    public string AddAdmin()
    {
        if (!UserCheck(UserName))
        {
            sql = "insert into [lib_user] (username,password,reg_time,news_op,notice_op,links_op,vote_op,user_op,web_op,download_op,search_op,book_op,paper_op,note_op,zy_op,user_type,ischeck,check_admin)"
                + "values (@UserName,@PassWord,@RegTime,@NewsOP,@NoticeOP,@LinksOP,@VoteOP,@UserOP,@WebOP,@DownloadOP,@SearchOP,@BookOP,@PaperOP,@NoteOP,@ZyOP,'管理员','1','admin') ";
            SqlParameter[] myparas ={ 
                    new SqlParameter("@UserName", SqlDbType.VarChar),
                    new SqlParameter("@PassWord", SqlDbType.VarChar),
                    new SqlParameter("@RegTime", SqlDbType.DateTime),
                     new SqlParameter("@NewsOP",SqlDbType.Bit),
                    new SqlParameter("@NoticeOP",SqlDbType.Bit),
                    new SqlParameter("@LinksOP",SqlDbType.Bit),
                    new SqlParameter("@VoteOP",SqlDbType.Bit),
                    new SqlParameter("@UserOP",SqlDbType.Bit),
                    new SqlParameter("@WebOP",SqlDbType.Bit),
                    new SqlParameter("@DownloadOP",SqlDbType.Bit),
                    new SqlParameter("@SearchOP",SqlDbType.Bit),
                    new SqlParameter("@BookOP",SqlDbType.Bit),
                    new SqlParameter("@PaperOP",SqlDbType.Bit),
                    new SqlParameter("@NoteOP",SqlDbType.Bit),
                    new SqlParameter("@ZyOP",SqlDbType.Bit)
                   
                   
                   
        };
            myparas[0].Value = UserName;
            myparas[1].Value = PassWord;
            myparas[2].Value = DateTime.Now;
            myparas[3].Value = news_op;
            myparas[4].Value = notice_op;
            myparas[5].Value = links_op;
            myparas[6].Value = vote_op;
            myparas[7].Value = user_op;
            myparas[8].Value = web_op;
            myparas[9].Value = download_op;
            myparas[10].Value = search_op;
            myparas[11].Value = book_op;
            myparas[12].Value = paper_op;
            myparas[13].Value = note_op;
            myparas[14].Value = zy_op;

            try
            {
                if (dataconnection.ExecuteSql(myparas, sql) > 0)
                    return "ok";
                else return "增加失败!";
            }
            catch { return "系统错误!"; }
        }
        else
        { return "该用户名已经被占用了！请重新输入。"; }
    }
    public string SetAdminInfo()
    {
        sql = "update [lib_user] set password=@Password,news_op=@News,notice_op=@Notice,links_op=@Links,vote_op=@Vote,user_op=@UserOP,web_op=@Web,download_op=@Download,search_op=@Search,book_op=@Book,paper_op=@Paper,note_op=@Note,zy_op=@ZY where username=@UserName";
        SqlParameter[] myparas ={ 
            new SqlParameter("@Password",SqlDbType.VarChar),
            new SqlParameter("@News",SqlDbType.Bit),
            new SqlParameter("@Notice",SqlDbType.Bit),
            new SqlParameter("@Links",SqlDbType.Bit),
            new SqlParameter("@Vote",SqlDbType.Bit),
            new SqlParameter("@UserOP",SqlDbType.Bit),
            new SqlParameter("@Web",SqlDbType.Bit),
            new SqlParameter("@Download",SqlDbType.Bit),
            new SqlParameter("@Search",SqlDbType.Bit),
            new SqlParameter("@Book",SqlDbType.Bit),
            new SqlParameter("@Paper",SqlDbType.Bit),
            new SqlParameter("@Note",SqlDbType.Bit),
            new SqlParameter("@ZY",SqlDbType.Bit),
            new SqlParameter("@UserName",SqlDbType.VarChar)
        };
        myparas[0].Value = PassWord;
        myparas[1].Value = news_op;
        myparas[2].Value=notice_op;
        myparas[3].Value=links_op;
        myparas[4].Value=vote_op;
        myparas[5].Value=user_op;
        myparas[6].Value=web_op;
        myparas[7].Value=download_op;
        myparas[8].Value=search_op;
        myparas[9].Value=book_op;
        myparas[10].Value=paper_op;
        myparas[11].Value=note_op;
        myparas[12].Value=zy_op;
        myparas[13].Value=UserName;
        try
        {
            if(dataconnection.ExecuteSql(myparas,sql)>0)
            {
                return "ok";
            }
            else{return "无此记录！";}
        }
        catch{return "系统错误！";}
    }
    public string SetUserType(string usernameh, string usertypeh)
    {
        sql = "update [lib_user] set user_type=@UserType where username=@UserName";
        SqlParameter[] mypara ={ new SqlParameter("@UserType", SqlDbType.VarChar), new SqlParameter("@UserName", SqlDbType.VarChar) };
        mypara[0].Value = usertypeh;
        mypara[1].Value = usernameh;
        try
        {
            if (dataconnection.ExecuteSql(mypara, sql) > 0)
            {
                return "ok";
            }
            else { return "无此记录！"; }
        }
        catch { return "系统错误！"; }
    }
    public string AddNews(News mynews)
    {
        if ((mynews.NewsType == "news" && NewsOP) || (mynews.NewsType == "notice" && NoticeOP)||(mynews.NewsType=="px"&&DownloadOP))
        {
            sql = "insert into [lib_news] (title,info,news_type,head_pic,ischeck,check_admin,pub_time,pub_user,pub_ip,istop,visit_num,orderlist) values(@Title,@Info,@NewsType,@HeadPic,@IsCheck,@CheckAdmin,@PubTime,@PubUser,@PubIP,@IsTop,@VisitNum,@OrderList)";
            SqlParameter[] myparas ={
                new SqlParameter("@Title",SqlDbType.VarChar),
                new SqlParameter("@Info",SqlDbType.Text),
                new SqlParameter("@NewsType",SqlDbType.VarChar),
                new SqlParameter("@HeadPic",SqlDbType.VarChar),
                new SqlParameter("@IsCheck",SqlDbType.Bit),
                new SqlParameter("@CheckAdmin",SqlDbType.VarChar),
                new SqlParameter("@PubTime",SqlDbType.DateTime),
                new SqlParameter("@PubUser",SqlDbType.VarChar),
                new SqlParameter("@PubIP",SqlDbType.VarChar),
                new SqlParameter("@IsTop",SqlDbType.Bit),
                new SqlParameter("@VisitNum",SqlDbType.Int),
                new SqlParameter("@OrderList",SqlDbType.Int)
             };
            myparas[0].Value = mynews.Title;
            myparas[1].Value = mynews.Info;
            myparas[2].Value = mynews.NewsType;
            myparas[3].Value = mynews.HeadPicUrl;
            myparas[4].Value = mynews.IsChecked;
            myparas[5].Value = mynews.CheckAdmin;
            myparas[6].Value = mynews.PubTime;
            myparas[7].Value = mynews.PubUser;
            myparas[8].Value = mynews.PubIP;
            myparas[9].Value = mynews.IsTop;
            myparas[10].Value = mynews.VisitNum;
            myparas[11].Value = mynews.OrderList;
            try
            {
                if (dataconnection.ExecuteSql(myparas, sql) > 0)
                    return "添加成功！";
                else return "添加失败1";
            }
            catch { return "添加失败2"; }
        }
        else { return "对不起，您没有操作权限"; }
    }
    /// <summary>
    /// 删除新闻
    /// </summary>
    /// <param name="newsid"></param>
    /// <param name="newstype">哪种新闻，notice,news,px</param>
    /// <returns></returns>
    public string DeleteNews(string newsid,string newstype)
    {
        if ((newstype == "news" && NewsOP) || (newstype == "notice" && NoticeOP) || (newstype == "px" && DownloadOP))
        {
            sql = "delete from [lib_news] where id=@NewsID";
            SqlParameter[] myparas ={ new SqlParameter("@NewsID", SqlDbType.Int) };
            myparas[0].Value = int.Parse(newsid);
            try
            {
                if (dataconnection.ExecuteSql(myparas, sql) > 0)
                    return "删除成功";
                else return "删除失败";
            }
            catch { return "删除失败"; }
        }
        else { return "对不起，你没有操作权限"; }
    }
    /// <summary>
    /// 审核新闻
    /// </summary>
    /// <param name="newsid"></param>
    /// <param name="newstype">类型，news/notice/px</param>
    /// <param name="ischeck">true/false</param>
    /// <returns></returns>
    public string CheckNews(string newsid, string newstype,bool ischeck)
    {
        if ((newstype == "news" && NewsOP) || (newstype == "notice" && NoticeOP) || (newstype == "px" && DownloadOP))
        {
            sql = "update [lib_news] set ischeck=@IsChecked,check_admin=@UserName where id=@NewsID";
            SqlParameter[] mypara ={ 
            new SqlParameter("@NewsID", SqlDbType.Int),
            new SqlParameter("@UserName",SqlDbType.VarChar),
            new SqlParameter("@IsChecked",SqlDbType.Bit)
        };
            mypara[0].Value = int.Parse(newsid);
            mypara[1].Value = UserName;
            mypara[2].Value = ischeck;
            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "审核成功";
                else return "审核失败";
            }
            catch { return "审核失败"; }
        }
        else { return "对不起，你没有操作权限"; }
    }
    public string EditNews(News mynews)
    {
        if ((mynews.NewsType == "news" && NewsOP) || (mynews.NewsType == "notice" && NoticeOP) || (mynews.NewsType == "px" && DownloadOP))
        {
            //发布者还是以前的，反正哪个管理员修改就认为是他审核的
            sql = "update [lib_news] set ischeck=@IsChecked,check_admin=@UserName,title=@Title,head_pic=@HeadPic,info=@Info,orderlist=@OrderList,istop=@IsTop,visit_num=@VistiNum,news_type=@NewsType where id=@NewsID";
            SqlParameter[] mypara ={ 
                new SqlParameter("@NewsID", SqlDbType.Int),
                new SqlParameter("@UserName",SqlDbType.VarChar),
                new SqlParameter("@IsChecked",SqlDbType.Bit),
                new SqlParameter("@Title",SqlDbType.VarChar),
                new SqlParameter("@HeadPic",SqlDbType.VarChar),
                new SqlParameter("@Info",SqlDbType.Text),
                new SqlParameter("@OrderList",SqlDbType.Int),
                new SqlParameter("@IsTop",SqlDbType.Bit),
                new SqlParameter("@VistiNum",SqlDbType.Int),
                new SqlParameter("@NewsType",SqlDbType.VarChar)
        };
            mypara[0].Value = int.Parse(mynews.NewsID);
            mypara[1].Value = UserName;
            mypara[2].Value = mynews.IsChecked;
            mypara[3].Value = mynews.Title;
            mypara[4].Value = mynews.HeadPicUrl;
            mypara[5].Value = mynews.Info;
            mypara[6].Value = mynews.OrderList;
            mypara[7].Value = mynews.IsTop;
            mypara[8].Value = mynews.VisitNum;
            mypara[9].Value = mynews.NewsType;
            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "修改成功！";
                else return "修改失败！";
            }
            catch { return "修改失败！"; }
        }
        else { return "对不起，你没有操作权限！"; }
    }
    #region
    //链接操作
    public string AddLink(Links mylink)
    {
        if (links_op)
        {
            sql = "insert into [lib_links] (title,url,pic,type,orderlist) values (@Title,@URL,@PIC,@Type,@OrderList)";
            SqlParameter[] myparas ={
                new SqlParameter("@Title",SqlDbType.VarChar),
                new SqlParameter("@URL",SqlDbType.VarChar),
                new SqlParameter("@PIC",SqlDbType.VarChar),
                new SqlParameter("@Type",SqlDbType.VarChar),
                new SqlParameter("@OrderList",SqlDbType.Int)
                
             };
            myparas[0].Value = mylink.LinkTitle;
            myparas[1].Value = mylink.LinkURL;
            myparas[2].Value = mylink.LinkPIC;
            myparas[3].Value = mylink.LinkType;
            myparas[4].Value = mylink.OrderList;
            try {
                if (dataconnection.ExecuteSql(myparas, sql) > 0)
                    return "ok";
                else return "对不起添加错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else
        {
            return "对不起，您没有操作此项目的权限！";
        }
    }
    public string DeleteLink(string linkid)
    {
        if (links_op)
        {
            sql = "delete from [lib_links] where id=@LinkID";
            SqlParameter[] mypara ={ new SqlParameter("@LinkID",SqlDbType.VarChar)};
            mypara[0].Value = linkid;
            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "ok";
                else return "对不起删除错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else { return "对不起，您没有操作此项目的权限！"; }
    }
    public string UpdateLink(Links mylink)
    {
        if (links_op)
        {
            sql = "update [lib_links] set title=@Title,url=@URL,pic=@PIC,type=@Type,orderlist=@OrderList where id=@LinkID";
            SqlParameter[] myparas ={
                new SqlParameter("@Title",SqlDbType.VarChar),
                new SqlParameter("@URL",SqlDbType.VarChar),
                new SqlParameter("@PIC",SqlDbType.VarChar),
                new SqlParameter("@Type",SqlDbType.VarChar),
                new SqlParameter("@OrderList",SqlDbType.Int),
                new SqlParameter("@LinkID",SqlDbType.VarChar)
                
             };
            myparas[0].Value = mylink.LinkTitle;
            myparas[1].Value = mylink.LinkURL;
            myparas[2].Value = mylink.LinkPIC;
            myparas[3].Value = mylink.LinkType;
            myparas[4].Value = mylink.OrderList;
            myparas[5].Value = mylink.LinkID;
            try
            {
                if (dataconnection.ExecuteSql(myparas, sql) > 0)
                    return "ok";
                else return "对不起更新错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else
        {
            return "对不起，您没有操作此项目的权限！";
        }
    }
    public SqlDataReader GetWebLinks(string type)
    {
        switch (type)
        {
            case "xnlj":
                sql = "select * from [lib_links] where type='xnlj' order by orderlist desc";
                break;
            case "xwlj":
                sql = "select * from [lib_links] where type='xwlj' order by orderlist desc";
                break;
            case "xnzy":
                sql = "select * from [lib_links] where type='xnzy' order by orderlist desc";
                break;
            case "xwzy":
                sql = "select * from [lib_links] where type='xwzy' order by orderlist desc";
                break;
            case "xkzywz":
                sql = "select * from [lib_links] where type='xkzywz' order by orderlist desc";
                break;
            default:
                sql = "select * from [lib_links]  order by type asc, orderlist desc";
                break;
        };
        try
        {
            return dataconnection.GetDataReader(sql);
        }
        catch { return null; }
    }
    #endregion

    #region

    public string AddVoteOption(string title,int real_num,int orderlist)
    {
        if (vote_op)
        {
            sql = "insert into [lib_vote_option] (real_num,title,orderlist) values (@RealNum,@Title,@OrderList)";
            SqlParameter[] myparas ={ 
                new SqlParameter("@RealNum",SqlDbType.Int),
                new SqlParameter("@Title",SqlDbType.VarChar),
                new SqlParameter("@OrderList",SqlDbType.Int)
            };
            myparas[0].Value = real_num;
            myparas[1].Value = title;
            myparas[2].Value = orderlist;
            try
            {
                if (dataconnection.ExecuteSql(myparas, sql) > 0)
                    return "ok";
                else return "对不起添加错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else
        {
            return "对不起，您没有此操作权限！";
        }
    }
    public string UpdateVoteOption(string optionid, string optiontitle, int optionnum, int optionorder)
    {
        if (vote_op)
        {
            sql = "update [lib_vote_option] set real_num=@RealNum,title=@Title,orderlist=@OrderList where id=@OptionID";
            SqlParameter[] myparas ={ 
                new SqlParameter("@RealNum",SqlDbType.Int),
                new SqlParameter("@Title",SqlDbType.VarChar),
                new SqlParameter("@OrderList",SqlDbType.Int),
                new SqlParameter("@OptionID",SqlDbType.VarChar)
            };
            myparas[0].Value = optionnum;
            myparas[1].Value = optiontitle;
            myparas[2].Value = optionorder;
            myparas[3].Value = optionid;
            try
            {
                if (dataconnection.ExecuteSql(myparas, sql) > 0)
                    return "ok";
                else return "对不起修改错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else
        {
            return "对不起，您没有此操作权限！";
        }
    }
    public string DeleteVoteOption(string optionid)
    {
        if (vote_op)
        {
            sql = "delete from [lib_vote_option] where id=@OptionID";
            SqlParameter[] myparas ={                 
                new SqlParameter("@OptionID",SqlDbType.VarChar)                
            };
            myparas[0].Value = optionid;
           
            try
            {
                if (dataconnection.ExecuteSql(myparas, sql) > 0)
                    return "ok";
                else return "对不起删除错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else
        {
            return "对不起，您没有此操作权限！";
        }
    }
    public string UpdateVoteTitle(string voteid,string title)
    {
        if (vote_op)
        {
            sql = "update [lib_vote_title] set title=@Title where id=@OptionID";
            SqlParameter[] myparas ={                 
                new SqlParameter("@OptionID",SqlDbType.VarChar),
                new SqlParameter("@Title",SqlDbType.VarChar)
            };
            myparas[0].Value = voteid;
            myparas[1].Value = title;

            try
            {
                if (dataconnection.ExecuteSql(myparas, sql) > 0)
                    return "ok";
                else return "对不起更改错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else
        {
            return "对不起，您没有此操作权限！";
        }
    }
    #endregion


    #region 下载记录操作
    
    /// <summary>
    /// 添加下载记录
    /// </summary>
    /// <param name="mydownload"></param>
    /// <returns></returns>
    public string AddDownload(Download mydownload)
    {
        if (download_op)
        {
            sql = "insert into [lib_download] (title,typename,info,is_recommend,ischeck,check_admin,pub_user,pub_time,pub_ip,down_num,visit_num,file_url,file_size,file_name,file_extension,xingzhi,down_language,platform,rank,author,head_pic,is_need_login,update_time,update_user,update_ip)"
                + "values (@Title,@TypeName,@Info,@IsRecommend,@IsCheck,@CheckAdmin,@PubUser,@PubTime,@PubIP,@DownNum,@VisitNum,@FileURL,@FileSize,@FileName,@FileEXT,@XingZhi,@Language,@PlatForm,@Rank,@Author,@HeadPIC,@IsNeenLogin,@UpdateTime,@UpdateUser,@UpdateIP)";
            SqlParameter[] myparas ={ 
            new SqlParameter("@Title",SqlDbType.VarChar),
            new SqlParameter("@TypeName",SqlDbType.VarChar),
            new SqlParameter("@Info",SqlDbType.Text),
            new SqlParameter("@IsRecommend",SqlDbType.Bit),
            new SqlParameter("@IsCheck",SqlDbType.Bit),
            new SqlParameter("@CheckAdmin",SqlDbType.VarChar),
            new SqlParameter("@PubUser",SqlDbType.VarChar),
            new SqlParameter("@PubTime",SqlDbType.DateTime),
            new SqlParameter("@PubIP",SqlDbType.VarChar),
            new SqlParameter("@DownNum",SqlDbType.Int),
            new SqlParameter("@VisitNum",SqlDbType.Int),
            new SqlParameter("@FileURL",SqlDbType.VarChar),
            new SqlParameter("@FileSize",SqlDbType.Int),
            new SqlParameter("@FileName",SqlDbType.VarChar),
            new SqlParameter("@FileEXT",SqlDbType.VarChar),
            new SqlParameter("@XingZhi",SqlDbType.VarChar),
            new SqlParameter("@Language",SqlDbType.VarChar),
            new SqlParameter("@PlatForm",SqlDbType.VarChar),
            new SqlParameter("@Rank",SqlDbType.VarChar),
            new SqlParameter("@Author",SqlDbType.VarChar),
            new SqlParameter("@HeadPIC",SqlDbType.VarChar),
            new SqlParameter("@IsNeenLogin",SqlDbType.Bit),
            new SqlParameter("@UpdateTime",SqlDbType.DateTime),
            new SqlParameter("@UpdateUser",SqlDbType.VarChar),
            new SqlParameter("@UpdateIP",SqlDbType.VarChar)


        };
            myparas[0].Value = mydownload.Title;
            myparas[1].Value = mydownload.TypeName;
            myparas[2].Value = mydownload.Info;
            myparas[3].Value = mydownload.IsRecommend;
            myparas[4].Value = mydownload.IsChecked;
            myparas[5].Value = mydownload.CheckAdmin;
            myparas[6].Value = mydownload.PubUser;
            myparas[7].Value = mydownload.PubTime;
            myparas[8].Value = mydownload.PubIP;
            myparas[9].Value = mydownload.DownloadTimes;
            myparas[10].Value = mydownload.VisitNum;
            myparas[11].Value = mydownload.FileURL;
            myparas[12].Value = mydownload.FileSize;
            myparas[13].Value = mydownload.FileName;
            myparas[14].Value = mydownload.FileEXT;
            myparas[15].Value = mydownload.XingZhi;
            myparas[16].Value = mydownload.Language;
            myparas[17].Value = mydownload.PlatForm;
            myparas[18].Value = mydownload.Rank;
            myparas[19].Value = mydownload.Author;
            myparas[20].Value = mydownload.HeadPic;
            myparas[21].Value = mydownload.IsNeedLogin;
            myparas[22].Value = mydownload.UpdateTime;
            myparas[23].Value = mydownload.UpdateUser;
            myparas[24].Value = mydownload.UpdateIP;
            try
            {
                dataconnection.ExecuteSql(myparas, sql);
                return "ok";
            }
            catch { return "对不起，系统错误！"; }
        }
        else { return "对不起，你没有此项目管理权限"; }
    }
    public string EditDownload(Download mydownload)
    {
        if (download_op)
        {
            sql = "update [lib_download] set title=@Title,typename=@TypeName,info=@Info,is_recommend=@IsRecommend,ischeck=@IsCheck,check_admin=@CheckAdmin,pub_user=@PubUser,pub_time=@PubTime,pub_ip=@PubIP,down_num=@DownNum,visit_num=@VisitNum,file_url=@FileURL,"
                + " file_size=@FileSize,file_name=@FileName,file_extension=@FileEXT,xingzhi=@XingZhi,down_language=@Language,platform=@PlatForm,rank=@Rank,author=@Author,head_pic=@HeadPIC,is_need_login=@IsNeenLogin,update_time=@UpdateTime,update_user=@UpdateUser,update_ip=@UpdateIP where id=@DownloadID";
               
            SqlParameter[] myparas ={ 
            new SqlParameter("@Title",SqlDbType.VarChar),
            new SqlParameter("@TypeName",SqlDbType.VarChar),
            new SqlParameter("@Info",SqlDbType.Text),
            new SqlParameter("@IsRecommend",SqlDbType.Bit),
            new SqlParameter("@IsCheck",SqlDbType.Bit),
            new SqlParameter("@CheckAdmin",SqlDbType.VarChar),
            new SqlParameter("@PubUser",SqlDbType.VarChar),
            new SqlParameter("@PubTime",SqlDbType.DateTime),
            new SqlParameter("@PubIP",SqlDbType.VarChar),
            new SqlParameter("@DownNum",SqlDbType.Int),
            new SqlParameter("@VisitNum",SqlDbType.Int),
            new SqlParameter("@FileURL",SqlDbType.VarChar),
            new SqlParameter("@FileSize",SqlDbType.Int),
            new SqlParameter("@FileName",SqlDbType.VarChar),
            new SqlParameter("@FileEXT",SqlDbType.VarChar),
            new SqlParameter("@XingZhi",SqlDbType.VarChar),
            new SqlParameter("@Language",SqlDbType.VarChar),
            new SqlParameter("@PlatForm",SqlDbType.VarChar),
            new SqlParameter("@Rank",SqlDbType.VarChar),
            new SqlParameter("@Author",SqlDbType.VarChar),
            new SqlParameter("@HeadPIC",SqlDbType.VarChar),
            new SqlParameter("@IsNeenLogin",SqlDbType.Bit),
            new SqlParameter("@DownloadID",SqlDbType.VarChar),
            new SqlParameter("@UpdateUser",SqlDbType.VarChar),
            new SqlParameter("@UpdateTime",SqlDbType.DateTime),
            new SqlParameter("@UpdateIP",SqlDbType.VarChar)


        };
            myparas[0].Value = mydownload.Title;
            myparas[1].Value = mydownload.TypeName;
            myparas[2].Value = mydownload.Info;
            myparas[3].Value = mydownload.IsRecommend;
            myparas[4].Value = mydownload.IsChecked;
            myparas[5].Value = mydownload.CheckAdmin;
            myparas[6].Value = mydownload.PubUser;
            myparas[7].Value = mydownload.PubTime;
            myparas[8].Value = mydownload.PubIP;
            myparas[9].Value = mydownload.DownloadTimes;
            myparas[10].Value = mydownload.VisitNum;
            myparas[11].Value = mydownload.FileURL;
            myparas[12].Value = mydownload.FileSize;
            myparas[13].Value = mydownload.FileName;
            myparas[14].Value = mydownload.FileEXT;
            myparas[15].Value = mydownload.XingZhi;
            myparas[16].Value = mydownload.Language;
            myparas[17].Value = mydownload.PlatForm;
            myparas[18].Value = mydownload.Rank;
            myparas[19].Value = mydownload.Author;
            myparas[20].Value = mydownload.HeadPic;
            myparas[21].Value = mydownload.IsNeedLogin;
            myparas[22].Value = mydownload.ID;
            myparas[23].Value = mydownload.UpdateUser;
            myparas[24].Value = mydownload.UpdateTime;
            myparas[25].Value = mydownload.UpdateIP;
            try
              {
                dataconnection.ExecuteSql(myparas, sql);
                return "ok";
            }
            catch { return "对不起，系统错误！"; }
        }
        else { return "对不起，你没有此项目管理权限"; }
    }
    public string DeleteDownload(string downloadid)
    {

        if (download_op)
        {
            sql = "delete from [lib_download] where id=@LinkID";
            SqlParameter[] mypara ={ new SqlParameter("@LinkID", SqlDbType.VarChar) };
            mypara[0].Value = downloadid;
            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "ok";
                else return "对不起删除错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else { return "对不起，您没有操作此项目的权限！"; }
    }
    public string DelteFile(string filepath)
    {
        if (download_op)
        {
            string realfilepath = HttpContext.Current.Request.MapPath("~/") + filepath;
            if (File.Exists(realfilepath))
            {
                File.Delete(realfilepath);
                if (File.Exists(realfilepath))
                { return "删除失败"; }
                else { return "ok"; }
            }
            else return "删除成功";
        }
        else { return "对不起，您没有此项目操作权限！"; }
    }
    public string CheckDownload(string downloadid, bool isitchecked)
    {
        if (download_op)
        {
            sql = "update [lib_download] set ischeck=@IsChecked,check_admin=@UserName where id=@NewsID";
            SqlParameter[] mypara ={ 
                new SqlParameter("@NewsID", SqlDbType.Int),
                new SqlParameter("@UserName",SqlDbType.VarChar),
                new SqlParameter("@IsChecked",SqlDbType.Bit)
            };
            mypara[0].Value = int.Parse(downloadid);
            mypara[1].Value = UserName;
            mypara[2].Value = isitchecked;
            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "审核成功";
                else return "审核失败";
            }
            catch { return "审核失败"; }
        }
        else { return "对不起，你没有操作权限"; }
    }
    public SqlDataReader GetDownloadTypes()
    {
        sql = "select distinct typename from [lib_download] ";
        try
        {
            SqlDataReader reader = dataconnection.GetDataReader(sql);
            return reader;
        }
        catch { return null; }
    }

    #endregion

    public string AddBook(Book mybook)
    {
        if (book_op)
        {
            sql = "insert into [lib_newbook] (title,picurl,author,publisher,pub_time,isbn,num1,num2,typename,infos,addtime,adduser,istop,addip,visit_num,good_num,bad_num) values"
                + "(@Title,@PicURL,@Author,@Publisher,@PubTime,@ISBN,@Num1,@Num2,@TypeName,@Infos,@AddTime,@AddUser,@IsTop,@AddIP,@VisitNum,@GoodNum,@BadNum)";
            SqlParameter[] myparas ={ 
            new SqlParameter("@Title",SqlDbType.VarChar),
            new SqlParameter("@PicURL",SqlDbType.VarChar),
            new SqlParameter("@Author",SqlDbType.VarChar),
            new SqlParameter("@Publisher",SqlDbType.VarChar),
            new SqlParameter("@PubTime",SqlDbType.DateTime),
            new SqlParameter("@ISBN",SqlDbType.VarChar),
            new SqlParameter("@Num1",SqlDbType.Int),
            new SqlParameter("@Num2",SqlDbType.Int),
            new SqlParameter("@TypeName",SqlDbType.VarChar),
            new SqlParameter("@Infos",SqlDbType.Text),
            new SqlParameter("@AddTime",SqlDbType.DateTime),
            new SqlParameter("@AddUser",SqlDbType.VarChar),
            new SqlParameter("@IsTop",SqlDbType.Bit),
            new SqlParameter("@AddIP",SqlDbType.VarChar),
            new SqlParameter("@VisitNum",SqlDbType.Int),
            new SqlParameter("@GoodNum",SqlDbType.Int),
            new SqlParameter("@BadNum",SqlDbType.Int)


        };
            myparas[0].Value = mybook.Title;
            myparas[1].Value = mybook.PicURL;
            myparas[2].Value = mybook.Author;
            myparas[3].Value = mybook.Publisher;
            myparas[4].Value = mybook.PubTime;
            myparas[5].Value = mybook.ISBN;
            myparas[6].Value = mybook.TotalNum;
            myparas[7].Value = mybook.NowNum;
            myparas[8].Value = mybook.TypeName;
            myparas[9].Value = mybook.Infos;
            myparas[10].Value = mybook.AddTime;
            myparas[11].Value = mybook.AddUser;
            myparas[12].Value = mybook.IsTop;
            myparas[13].Value = mybook.AddIP;
            myparas[14].Value = mybook.VisitNum;
            myparas[15].Value = mybook.GoodNum;
            myparas[16].Value = mybook.BadNum;
            try
            {
                dataconnection.ExecuteSql(myparas, sql);
                return "ok";
            }
            catch { return "对不起，系统错误！"; }
        }
        else { return "对不起，你没有此项目管理权限"; }
    }
    public string EditBook(Book mybook)
    {
        if (book_op)
        {
            sql = "update [lib_newbook] set title=@Title,picurl=@PicURL,author=@Author,publisher=@Publisher,pub_time=@PubTime,isbn=@ISBN,num1=@Num1,num2=@Num2,typename=@TypeName,infos=@Infos,addtime=@AddTime,adduser=@AddUser,istop=@IsTop,addip=@AddIP,visit_num=@VisitNum,good_num=@GoodNum,bad_num=@BadNum where id=@BookID";

            SqlParameter[] myparas ={ 
            new SqlParameter("@Title",SqlDbType.VarChar),
            new SqlParameter("@PicURL",SqlDbType.VarChar),
            new SqlParameter("@Author",SqlDbType.VarChar),
            new SqlParameter("@Publisher",SqlDbType.VarChar),
            new SqlParameter("@PubTime",SqlDbType.DateTime),
            new SqlParameter("@ISBN",SqlDbType.VarChar),
            new SqlParameter("@Num1",SqlDbType.Int),
            new SqlParameter("@Num2",SqlDbType.Int),
            new SqlParameter("@TypeName",SqlDbType.VarChar),
            new SqlParameter("@Infos",SqlDbType.Text),
            new SqlParameter("@AddTime",SqlDbType.DateTime),
            new SqlParameter("@AddUser",SqlDbType.VarChar),
            new SqlParameter("@IsTop",SqlDbType.Bit),
            new SqlParameter("@AddIP",SqlDbType.VarChar),
            new SqlParameter("@VisitNum",SqlDbType.Int),
            new SqlParameter("@GoodNum",SqlDbType.Int),
            new SqlParameter("@BadNum",SqlDbType.Int),
            new SqlParameter("@BookID",SqlDbType.VarChar)


        };
            myparas[0].Value = mybook.Title;
            myparas[1].Value = mybook.PicURL;
            myparas[2].Value = mybook.Author;
            myparas[3].Value = mybook.Publisher;
            myparas[4].Value = mybook.PubTime;
            myparas[5].Value = mybook.ISBN;
            myparas[6].Value = mybook.TotalNum;
            myparas[7].Value = mybook.NowNum;
            myparas[8].Value = mybook.TypeName;
            myparas[9].Value = mybook.Infos;
            myparas[10].Value = mybook.AddTime;
            myparas[11].Value = mybook.AddUser;
            myparas[12].Value = mybook.IsTop;
            myparas[13].Value = mybook.AddIP;
            myparas[14].Value = mybook.VisitNum;
            myparas[15].Value = mybook.GoodNum;
            myparas[16].Value = mybook.BadNum;
            myparas[17].Value = mybook.ID;
            try
            {
                if (dataconnection.ExecuteSql(myparas, sql) > 0)
                    return "ok";
                else return "对不起，系统错误";
            }
            catch { return "对不起，系统错误！"; }
        }
        else { return "对不起，你没有此项目管理权限"; }
    
    }
    public string TopSetBook(string bookid, bool istopit)
    {
        if(book_op)
        {
            sql = "update [lib_newbook] set istop=@IsTop where id=@BookID";
            SqlParameter[] mypara ={ 
                new SqlParameter("@IsTop",SqlDbType.Bit),
                new SqlParameter("@BookID", SqlDbType.VarChar) };
            mypara[0].Value = istopit;
            mypara[1].Value = bookid;
            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "ok";
                else return "对不起，系统错误";
            }
            catch { return "对不起，系统错误！"; }
        }
        else { return "对不起，你没有此项目管理权限"; }
    }
    public string DeleteBook(string bookid)
    {
        if (book_op)
        {
            sql = "delete from [lib_newbook] where id=@BookID";
            SqlParameter[] mypara ={ new SqlParameter("@BookID", SqlDbType.VarChar) };
            mypara[0].Value = bookid;
            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "ok";
                else return "对不起，系统错误";
            }
            catch { return "对不起，系统错误！"; }
        }
        else { return "对不起，你没有此项目管理权限"; }
        
    }
    public SqlDataReader GetNewBookTypes()
    {
        sql = "select distinct typename from [lib_newbook] ";
        try
        {
            SqlDataReader reader = dataconnection.GetDataReader(sql);
            return reader;
        }
        catch { return null; }
    }

    public string BackUpBooks()
    {
        sql = " insert into [lib_booksreport] select * from [c_booksreport]";
        if (dataconnection.ExecuteSql(sql) > 0)
        {
            return "成功执行！";
        }
        else return "没有记录操作！";
    }

    public string CheckWebNote(string noteid, bool isitchecked)
    {
        if (note_op)
        {
            sql = "update [lib_note] set ischeck=@IsChecked,check_admin=@UserName where id=@NewsID";
            SqlParameter[] mypara ={ 
                new SqlParameter("@NewsID", SqlDbType.Int),
                new SqlParameter("@UserName",SqlDbType.VarChar),
                new SqlParameter("@IsChecked",SqlDbType.Bit)
            };
            mypara[0].Value = int.Parse(noteid);
            mypara[1].Value = UserName;
            mypara[2].Value = isitchecked;
            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "ok";
                else return "审核失败";
            }
            catch { return "审核失败"; }
        }
        else { return "对不起，你没有操作权限"; }
    }
    public string DeleteWebNote(string noteid)
    {
        if (note_op)
        {
            sql = "delete from [lib_note] where id=@BookID or reply_id=@BookID";
            SqlParameter[] mypara ={ new SqlParameter("@BookID", SqlDbType.VarChar) };
            mypara[0].Value = noteid;
            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "ok";
                else return "对不起，系统错误";
            }
            catch { return "对不起，系统错误！"; }
        }
        else { return "对不起，你没有此项目管理权限"; }
    }
    public string EditWebNote(LibNote mynote)
    {
        if (note_op)
        {
            sql = "update [lib_note] set title=@Title,info=@Info,ischeck=1,check_admin=@CheckAdmin,typename=@TypeName where id=@NoteID ";

            SqlParameter[] myparas ={ 
            new SqlParameter("@Title",SqlDbType.VarChar),
            new SqlParameter("@Info",SqlDbType.VarChar),
            new SqlParameter("@CheckAdmin",SqlDbType.VarChar),
            new SqlParameter("@TypeName",SqlDbType.VarChar),
            new SqlParameter("@NoteID",SqlDbType.VarChar)


        };
            myparas[0].Value = mynote.Title;
            myparas[1].Value = mynote.Info;
            myparas[2].Value = UserName;
            myparas[3].Value = mynote.TypeName;
            myparas[4].Value = mynote.NoteID;
           
            try
            {
                if (dataconnection.ExecuteSql(myparas, sql) > 0)
                    return "ok";
                else return "对不起，系统错误";
            }
            catch { return "对不起，系统错误！"; }
        }
        else { return "对不起，你没有此项目管理权限"; }
    }
    /// <summary>
    /// 设置某个bool变量的值
    /// </summary>
    /// <param name="noteid">留言的id</param>
    /// <param name="theresult">true/false</param>
    /// <param name="type">1--isover是否结束了，2--ismail是否设为校长信箱，3--是否置顶，默认是否置顶</param>
    /// <returns></returns>
    public string SetWebNoteBool(string noteid, bool theresult, int typeint)
    {
        if(note_op)
        {
            sql = "update [lib_note] set istop=@TheR where id=@NoteID ";
            switch (typeint)
            {
                case 1:
                    sql = "update [lib_note] set isover=@TheR where id=@NoteID";
                    break;
                case 2:
                    sql = "update [lib_note] set ismail=@TheR where id=@NoteID";
                    break;
                case 3:
                    sql = "update [lib_note] set istop=@TheR where id=@NoteID";
                    break;
                default:
                    sql = "update [lib_note] set istop=@TheR where id=@NoteID";
                    break;
            };
              SqlParameter[] mypara ={ 
                    new SqlParameter("@NoteID", SqlDbType.Int),
                    new SqlParameter("@TheR",SqlDbType.Bit)
                };
                mypara[0].Value = int.Parse(noteid);
                mypara[1].Value = theresult;
                
                try
                {
                    if (dataconnection.ExecuteSql(mypara, sql) > 0)
                        return "ok";
                    else return "审核失败";
                }
                catch { return "审核失败"; }
        }
        else { return "对不起，你没有操作权限"; }
    }


    public string AddLibZy(LibZy myzy)
    {
        if (zy_op)
        {
            sql = "insert into [lib_zy] (title,url,info,typename,orderlist,is_index,is_new,is_hot) values (@Title,@URL,@Info,@TypeName,@OrderList,@IsIndex,@IsNew,@IsHot)";
            SqlParameter[] myparas ={
                new SqlParameter("@Title",SqlDbType.VarChar),
                new SqlParameter("@URL",SqlDbType.VarChar),
                new SqlParameter("@Info",SqlDbType.Text),
                new SqlParameter("@TypeName",SqlDbType.VarChar),
                 new SqlParameter("@OrderList",SqlDbType.Int),
                 new SqlParameter("@IsIndex",SqlDbType.Bit),
                 new SqlParameter("@IsNew",SqlDbType.Bit),
                 new SqlParameter("@IsHot",SqlDbType.Bit)
               
                
             };
            myparas[0].Value = myzy.Title;
            myparas[1].Value = myzy.Url;
            myparas[2].Value = myzy.Description;

            myparas[3].Value = myzy.TypeName;
            myparas[4].Value = myzy.OrderList;
            myparas[5].Value = myzy.IsIndex;
            myparas[6].Value = myzy.IsNew;
            myparas[7].Value = myzy.IsHot;
            try
            {
                if (dataconnection.ExecuteSql(myparas, sql) > 0)
                    return "ok";
                else return "对不起添加错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else
        {
            return "对不起，您没有操作此项目的权限！";
        }
    }
    public string DeleteLibZy(string linkid)
    {
        if (zy_op)
        {
            sql = "delete from [lib_zy] where id=@LinkID";
            SqlParameter[] mypara ={ new SqlParameter("@LinkID", SqlDbType.VarChar) };
            mypara[0].Value = linkid;
            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "ok";
                else return "对不起删除错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else { return "对不起，您没有操作此项目的权限！"; }
    }
    public string UpdateLibZy(LibZy mylink)
    {
        if (zy_op)
        {
            sql = "update [lib_zy] set title=@Title,url=@URL,info=@Info,typename=@Type,orderlist=@OrderList,is_index=@IsIndex,is_new=@IsNew,is_hot=@IsHot where id=@LinkID";
            SqlParameter[] myparas ={
                new SqlParameter("@Title",SqlDbType.VarChar),
                new SqlParameter("@URL",SqlDbType.VarChar),
                new SqlParameter("@Info",SqlDbType.VarChar),
                new SqlParameter("@Type",SqlDbType.VarChar),
                new SqlParameter("@OrderList",SqlDbType.Int),
                new SqlParameter("@LinkID",SqlDbType.VarChar),
                 new SqlParameter("@IsIndex",SqlDbType.Bit),
                 new SqlParameter("@IsNew",SqlDbType.Bit),
                 new SqlParameter("@IsHot",SqlDbType.Bit)
                
             };
            myparas[0].Value = mylink.Title;
            myparas[1].Value = mylink.Url;
            myparas[2].Value = mylink.Description;
            myparas[3].Value = mylink.TypeName;
            myparas[4].Value = mylink.OrderList;
            myparas[5].Value = mylink.ID;
            myparas[6].Value = mylink.IsIndex;
            myparas[7].Value = mylink.IsNew;
            myparas[8].Value = mylink.IsHot;

            try
            {
                if (dataconnection.ExecuteSql(myparas, sql) > 0)
                    return "ok";
                else return "对不起更新错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else
        {
            return "对不起，您没有操作此项目的权限！";
        }
    }
    public SqlDataReader GetLibZy()
    {
        sql = "select  * from [lib_zy] order by typename desc, orderlist desc";
        
        try
        {
            return dataconnection.GetDataReader(sql);
        }
        catch { return null; }
    }
    #region
    public string DeleteSearch(string searchid)
    {
        if (search_op)
        {
            sql = "delete from [lib_search] where id=@LinkID";
            SqlParameter[] mypara ={ new SqlParameter("@LinkID", SqlDbType.VarChar) };
            mypara[0].Value = searchid;
            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "ok";
                else return "对不起删除错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else { return "对不起，您没有操作此项目的权限！"; }
    }
    /// <summary>
    /// 操作变量
    /// </summary>
    /// <param name="field">更改变量ischeck,istop</param>
    /// <param name="ischeckit"></param>
    /// <param name="searchid"></param>
    /// <returns></returns>
    public string CheckSearch(string field, bool ischeckit,string searchid)
    {

        if (search_op)
        {
            sql = "update [lib_search] set "+field+"=@IsCheck where id=@LinkID";
            SqlParameter[] mypara ={ new SqlParameter("@LinkID", SqlDbType.VarChar),new SqlParameter("@IsCheck",SqlDbType.Bit) };
            mypara[0].Value = searchid;
            mypara[1].Value = ischeckit;
            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "ok";
                else return "对不起,更改错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else { return "对不起，您没有操作此项目的权限！"; }
    }
    public string UpdateSearch(Search mysearch)
    {

        if (search_op)
        {
            sql = "update [lib_search] set keyword=@KeyWord,all_num=@AllNum,month_num=@MonthNum where id=@LinkID";
            SqlParameter[] mypara ={ 
                new SqlParameter("@KeyWord",SqlDbType.VarChar),
                new SqlParameter("@AllNum",SqlDbType.Int),
                new SqlParameter("MonthNum",SqlDbType.Int),
                new SqlParameter("@LinkID", SqlDbType.VarChar)
            };
            mypara[0].Value = mysearch.KeyWord;
            mypara[1].Value = mysearch.AllNum;
            mypara[2].Value = mysearch.MonthNum;
            mypara[3].Value = mysearch.SearchID;
            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "ok";
                else return "对不起,更改错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else { return "对不起，您没有操作此项目的权限！"; }
    }

    #endregion

    public string DeleteUser(string user_name)
    {
        if (user_op)
        {
            sql = "delete from [lib_user] where username=@LinkID";
            SqlParameter[] mypara ={ new SqlParameter("@LinkID", SqlDbType.VarChar) };
            mypara[0].Value = user_name;
            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "ok";
                else return "对不起删除错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else { return "对不起，您没有操作此项目的权限！"; }
    }

    public string CheckUser(string user_name, bool ischekedit)
    {
        if (user_op)
        {
            sql = "update [lib_user] set ischeck=@IsCheck,check_admin=@AdminName where username=@LinkID";
            SqlParameter[] mypara ={ new SqlParameter("@LinkID", SqlDbType.VarChar), new SqlParameter("@IsCheck", SqlDbType.Bit),new SqlParameter("@AdminName",SqlDbType.VarChar) };
            mypara[0].Value = user_name;
            mypara[1].Value = ischekedit;
            mypara[2].Value = UserName;
            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "ok";
                else return "对不起,更改错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else { return "对不起，您没有操作此项目的权限！"; }
    }
    public SqlDataReader GetAdminList()
    {
       
        sql = "select  * from [lib_user] where user_type='管理员' order by username desc";

        try
        {
            return dataconnection.GetDataReader(sql);
        }
        catch { return null; }
    }
    /// <summary>
    /// 权限和book新书发布一样的
    /// </summary>
    /// <param name="mycd"></param>
    /// <returns></returns>
    public string AddCD(LibCD mycd)
    {
        if(book_op)
        {
            sql = "insert into [lib_cd] (光盘名称,题名,索书号,出版社,光盘大小,上传时间,上传者,路径,下载次数) values (@Title,@KeyWord,@BookNO,@Publisher,@Size,@AddTime,@AddUser,@URL,'0')";
            SqlParameter[] myparas ={ 
            
                new SqlParameter("@Title",SqlDbType.VarChar),
                new SqlParameter("@KeyWord",SqlDbType.VarChar),
                new SqlParameter("@BookNO",SqlDbType.VarChar),
                new SqlParameter("@Publisher",SqlDbType.VarChar),
                new SqlParameter("@Size",SqlDbType.VarChar),
                new SqlParameter("@AddTime",SqlDbType.VarChar),
                new SqlParameter("@AddUser",SqlDbType.VarChar),
                new SqlParameter("@URL",SqlDbType.VarChar),
            };
            myparas[0].Value = mycd.Title;
            myparas[1].Value = mycd.KeyWord;
            myparas[2].Value = mycd.BookNo;
            myparas[3].Value = mycd.Publisher;
            myparas[4].Value = mycd.CDSize;
            myparas[5].Value = mycd.AddTime;
            myparas[6].Value = mycd.AddUser;
            myparas[7].Value = mycd.CDURL;

            try
                {
                    if (dataconnection.ExecuteSql(myparas, sql) > 0)
                        return "ok";
                    else return "对不起添加错误！";
                }
                catch { return "对不起，系统错误！"; }
        }
        else
        {
            return "对不起，您没有操作此项目的权限！";
        }
    }
    public string DeleteCD(string CDID)
    {
        if (book_op)
        {
            sql = "delete from [lib_cd] where id=@LinkID";
            SqlParameter[] mypara ={ new SqlParameter("@LinkID", SqlDbType.VarChar) };
            mypara[0].Value = CDID;
            try
            {
                if (dataconnection.ExecuteSql(mypara, sql) > 0)
                    return "ok";
                else return "对不起删除错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else { return "对不起，您没有操作此项目的权限！"; }
    }
    public string EditCD(LibCD mycd)
    {
        if (book_op)
        {
            sql = "update [lib_cd] set 光盘名称=@Title,题名=@KeyWord,索书号=@BookNO,出版社=@Publisher,光盘大小=@Size,上传时间=@AddTime,上传者=@AddUser,路径=@URL,下载次数=@Times where id=@CDID";
            SqlParameter[] myparas ={ 
            
                new SqlParameter("@Title",SqlDbType.VarChar),
                new SqlParameter("@KeyWord",SqlDbType.VarChar),
                new SqlParameter("@BookNO",SqlDbType.VarChar),
                new SqlParameter("@Publisher",SqlDbType.VarChar),
                new SqlParameter("@Size",SqlDbType.VarChar),
                new SqlParameter("@AddTime",SqlDbType.VarChar),
                new SqlParameter("@AddUser",SqlDbType.VarChar),
                new SqlParameter("@URL",SqlDbType.VarChar),
                new SqlParameter("@Times",SqlDbType.Int),
                new SqlParameter("@CDID",SqlDbType.VarChar)
            };
            myparas[0].Value = mycd.Title;
            myparas[1].Value = mycd.KeyWord;
            myparas[2].Value = mycd.BookNo;
            myparas[3].Value = mycd.Publisher;
            myparas[4].Value = mycd.CDSize;
            myparas[5].Value = mycd.AddTime;
            myparas[6].Value = mycd.AddUser;
            myparas[7].Value = mycd.CDURL;
            myparas[8].Value = mycd.DownloadTimes;
            myparas[9].Value = mycd.CDID;

            try
            {
                if (dataconnection.ExecuteSql(myparas, sql) > 0)
                    return "ok";
                else return "对不起修改错误！";
            }
            catch { return "对不起，系统错误！"; }
        }
        else
        {
            return "对不起，您没有操作此项目的权限！";
        }
    }

}
