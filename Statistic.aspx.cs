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

public partial class Statistic : System.Web.UI.Page
{
    Statistics mStatistics = new Statistics();
    SqlDataReader mSqlDataReader = null;
    string where = "";
    protected void Page_Load(object sender, EventArgs e)
    {
      
        mStatistics.StatisticsDataOpen();
         where = string.Format("(_借书日期 between '2013-{0}-01' and '2013-{1}-01')",DateTime.Now.Month,DateTime.Now.Month+1);
         mSqlDataReader = mStatistics.GetBorrowInfoCount(where);
         if (mSqlDataReader == null)
         {
             return;
         }
        //纸质月统计
        if (mSqlDataReader.Read())
        {
            month_paper.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //纸质总统计
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetBorrowInfoCount("");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            total_paper.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //数字月统计
        where = string.Format("(invite_time between '2013-{0}-01' and '2013-{1}-01')", DateTime.Now.Month, DateTime.Now.Month + 1);
         mStatistics.StatisticsDataOpen();
         mSqlDataReader = mStatistics.GetDigitalInfoCount(where);
         if (mSqlDataReader == null)
         {
             return;
         }
        if (mSqlDataReader.Read())
        {
            month_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //数字总计
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount("");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            total_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();
    }
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        
        string starttime = txt_starttime.Value;
        string endtime = txt_endtime.Value;
        if (starttime.Equals("") || endtime.Equals(""))
        {
            Response.Write("<script>alert('日期不能为空!');</script>");
            return;
        }
        table2.Visible = true;
        lbl_starttime.Text = starttime;
        lbl_endtime.Text = endtime;
        where = string.Format("(_借书日期 between '{0}' and '{1}')", starttime, endtime);
        //纸质总计
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetBorrowInfoCount(where);
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            paper_search.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        where = string.Format("(invite_time between '{0}' and '{1}')", starttime, endtime);
        //纸质总计
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount(where);
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            digitial_search.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();
    }
}
