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
/// DataManager 的摘要说明
/// </summary>
public class DataManager
{
    private DataManager()
    {
    }

    public static DataSet getPagedData(int startRowIndex, int maximumRows,
        string query, string orderby, string sequence, string field, string title_or_subject)
    {
        if (query.Length == 0) return null;

        string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connString))
        using (SqlCommand command = new SqlCommand("sp_search_paging", connection))
        {
            try
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = command.Parameters.Add("@startRowIndex", SqlDbType.Int);
                p1.Value = startRowIndex;

                SqlParameter p2 = command.Parameters.Add("@maximumRows", SqlDbType.Int);
                p2.Value = maximumRows;

                SqlParameter p3 = command.Parameters.Add("@query", SqlDbType.VarChar);
                p3.Value = query;

                SqlParameter p4 = command.Parameters.Add("@orderby", SqlDbType.Char);
                p4.Value = orderby;

                SqlParameter p5 = command.Parameters.Add("@sequence", SqlDbType.Char);
                p5.Value = sequence;

                SqlParameter p6 = command.Parameters.Add("@field", SqlDbType.Char);
                if (field == null || field.Length == 0)
                {
                    p6.Value = System.DBNull.Value;
                }
                else
                {
                    p6.Value = field;
                }

                SqlParameter p7 = command.Parameters.Add("@title_or_subject", SqlDbType.VarChar);
                if (title_or_subject == null || title_or_subject.Length == 0)
                {
                    p7.Value = System.DBNull.Value;
                }
                else
                {
                    p7.Value = title_or_subject;
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "books");
                return dataSet;
            }
            finally
            {
                connection.Close();
            }
        }
    }

    public static int getCounts(string query, string field, string title_or_subject)
    {
        if (query.Length == 0) return 0;

        string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connString))
        using (SqlCommand command = new SqlCommand("sp_search_paging_counts", connection))
        {
            try
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = command.Parameters.Add("@query", SqlDbType.VarChar);
                p1.Value = query;

                SqlParameter p2 = command.Parameters.Add("@field", SqlDbType.VarChar);
                if (field == null || field.Length == 0)
                {
                    p2.Value = System.DBNull.Value;
                }
                else
                {
                    p2.Value = field;
                }

                SqlParameter p3 = command.Parameters.Add("@title_or_subject", SqlDbType.VarChar);
                if (title_or_subject == null || title_or_subject.Length == 0)
                {
                    p3.Value = System.DBNull.Value;
                }
                else
                {
                    p3.Value = title_or_subject;
                }

                int count = 0;
                count = Convert.ToInt32(command.ExecuteScalar().ToString());
                return count;
            }
            finally
            {
                connection.Close();
            }
        }
    }

    /**
     * 注意 field 和 title_or_subject 不可同时提供，二者只能提供其一。
     * 注意 fieldSecond 和 title_or_subject_second 不可同时提供，二者只能提供其一。
     * 
     * @startRowIndex int, -- 起始行数，如果每页 10 行，从第 2 页开始，则起始行数为 11。
     * @maximumRows int, -- 需要多少行，如果每页 10 行，则为 10。
     * @query varchar(30), -- 一次检索条件
     * @querySecond varchar(30), -- 二次检索条件
     * @orderby char(11), -- 排序条件
     * @sequence char(4), -- 排列顺序，升序或降序。
     * @field char(7), -- 检索字段
     * @fieldSecond char(7), -- 二次检索字段
     * @title_or_subject char(11), -- bib_title 或 bib_subject，用题名或主题词检索时才用。
     * @title_or_subject_second char(11) -- 二次检索用 bib_title 或 bib_subject
     */
    public static DataSet getPagedDataInResults(int startRowIndex, int maximumRows,
        string query, string querySecond, string orderby, string sequence, string field, string fieldSecond,
        string title_or_subject, string title_or_subject_second)
    {
        if (query.Length == 0 || querySecond.Length == 0) return null;

        string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connString))
        using (SqlCommand command = new SqlCommand("sp_search_paging_second", connection))
        {
            try
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = command.Parameters.Add("@startRowIndex", SqlDbType.Int);
                p1.Value = startRowIndex;

                SqlParameter p2 = command.Parameters.Add("@maximumRows", SqlDbType.Int);
                p2.Value = maximumRows;

                SqlParameter p3 = command.Parameters.Add("@query", SqlDbType.VarChar);
                p3.Value = query;

                SqlParameter p4 = command.Parameters.Add("@querySecond", SqlDbType.VarChar);
                p4.Value = querySecond;

                SqlParameter p5 = command.Parameters.Add("@orderby", SqlDbType.Char);
                p5.Value = orderby;

                SqlParameter p6 = command.Parameters.Add("@sequence", SqlDbType.Char);
                p6.Value = sequence;

                SqlParameter p7 = command.Parameters.Add("@field", SqlDbType.Char);
                if (field == null)
                {
                    p7.Value = System.DBNull.Value;
                }
                else
                {
                    p7.Value = field;
                }

                SqlParameter p8 = command.Parameters.Add("@fieldSecond", SqlDbType.Char);
                if (fieldSecond == null || fieldSecond.Length == 0)
                {
                    p8.Value = System.DBNull.Value;
                }
                else
                {
                    p8.Value = fieldSecond;
                }

                SqlParameter p9 = command.Parameters.Add("@title_or_subject", SqlDbType.VarChar);
                if (title_or_subject == null || title_or_subject.Length == 0)
                {
                    p9.Value = System.DBNull.Value;
                }
                else
                {
                    p9.Value = title_or_subject;
                }

                SqlParameter p10 = command.Parameters.Add("@title_or_subject_second", SqlDbType.VarChar);
                if (title_or_subject_second == null || title_or_subject_second.Length == 0)
                {
                    p10.Value = System.DBNull.Value;
                }
                else
                {
                    p10.Value = title_or_subject_second;
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "booksInResults");
                return dataSet;
            }
            finally
            {
                connection.Close();
            }
        }
    }

    //二次检索总页数
    public static int getCountsInResults(string query, string querySecond,
        string field, string fieldSecond, string title_or_subject, string title_or_subject_second)
    {
        if (query.Length == 0 || querySecond.Length == 0) return 0;

        string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connString))
        using (SqlCommand command = new SqlCommand("sp_search_paging_counts_second", connection))
        {
            try
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = command.Parameters.Add("@query", SqlDbType.VarChar);
                p1.Value = query;

                SqlParameter p2 = command.Parameters.Add("@querySecond", SqlDbType.VarChar);
                p2.Value = querySecond;

                SqlParameter p3 = command.Parameters.Add("@field", SqlDbType.Char);
                if (field == null || field.Length == 0)
                {
                    p3.Value = System.DBNull.Value;
                }
                else
                {
                    p3.Value = field;
                }

                SqlParameter p4 = command.Parameters.Add("@fieldSecond", SqlDbType.Char);
                if (fieldSecond == null || fieldSecond.Length == 0)
                {
                    p4.Value = System.DBNull.Value;
                }
                else
                {
                    p4.Value = fieldSecond;
                }

                SqlParameter p5 = command.Parameters.Add("@title_or_subject", SqlDbType.VarChar);
                if (title_or_subject == null || title_or_subject.Length == 0)
                {
                    p5.Value = System.DBNull.Value;
                }
                else
                {
                    p5.Value = title_or_subject;
                }

                SqlParameter p6 = command.Parameters.Add("@title_or_subject_second", SqlDbType.VarChar);
                if (title_or_subject_second == null || title_or_subject_second.Length == 0)
                {
                    p6.Value = System.DBNull.Value;
                }
                else
                {
                    p6.Value = title_or_subject_second;
                }

                int count = 0;
                count = Convert.ToInt32(command.ExecuteScalar().ToString());
                return count;
            }
            finally
            {
                connection.Close();
            }
        }
    }

    //验证是否为有效读者
    public static bool isValidReader(string readerCodebar)
    {
        string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBString"].ConnectionString;

        SqlConnection conn = new SqlConnection(connString);
        SqlCommand command = new SqlCommand("sp_search_isValidReader", conn);
        command.CommandType = CommandType.StoredProcedure;
        SqlParameter parameter1 = command.Parameters.Add("@readerCodebar", SqlDbType.Char);
        SqlParameter parameter_result = command.Parameters.Add("result", SqlDbType.Int);
        parameter_result.Direction = ParameterDirection.ReturnValue;

        parameter1.Value = readerCodebar; //读者条码

        try
        {
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
            int result = (int)command.Parameters["result"].Value;
            if (result == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch { return false; }
    }

    //目前仅预约时使用
    public static Reader getReader(string readerCodebar)
    {
        string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBString"].ConnectionString;

        string query = "SELECT _读者姓名, _单位名称 FROM l_reader WHERE _读者条码 = '" + readerCodebar + "'";

        Reader reader = new Reader();
        reader.ReaderCodebar = readerCodebar;

        using (SqlConnection connection = new SqlConnection(connString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            try
            {
                connection.Open();
                SqlDataReader r = command.ExecuteReader();
                while (r.Read())
                {
                    reader.Name = r[0].ToString().Trim();
                    reader.Unit = r[1].ToString().Trim();
                }
                r.Close();
                return reader;
            }
            finally
            {
                connection.Close();
            }
        }
    }

    //目前仅预约时使用
    public static Book2 getBook(string recid)
    {
        string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBString"].ConnectionString;

        string query = "SELECT _题名, _责任者, rtrim(_分类)+'/'+rtrim(_书次) FROM bib WHERE recid = '" + recid + "'";

        Book2 book = new Book2();
        book.Id = recid;

        using (SqlConnection connection = new SqlConnection(connString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            try
            {
                connection.Open();
                SqlDataReader r = command.ExecuteReader();
                while (r.Read())
                {
                    book.Title = r[0].ToString().Trim();
                    book.Author = r[1].ToString().Trim();
                    book.Bookno = r[2].ToString().Trim();
                }
                r.Close();
                return book;
            }
            finally
            {
                connection.Close();
            }
        }
    }


}
