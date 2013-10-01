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

        
        //1.本校教材月统计
        where = string.Format("(invite_time between '2013-{0}-01' and '2013-{1}-01')", DateTime.Now.Month, DateTime.Now.Month + 1);
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount(where,"1");
        if (mSqlDataReader == null)
        {
             return;
        }
        if (mSqlDataReader.Read())
        {
            month1_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //1.本校教材总计
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount("","1");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            total1_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();



        //2.本校论文月统计        
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount(where, "2");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            month2_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //2.本校论文总计
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount("", "2");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            total2_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();


        //3.教学研究资料月统计       
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount(where, "3");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            month3_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //3.教学研究资料总计
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount("", "3");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            total3_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();


        //4.科研学术动态月统计       
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount(where, "4");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            month4_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //4.科研学术动态总计
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount("", "4");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            total4_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();


        //5.军械士官月统计       
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount(where, "5");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            month5_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //5.军械士官总计
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount("", "5");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            total5_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();


        //6.教学参考书全文库月统计       
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount(where, "6");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            month6_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //6.教学参考书全文库总计
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount("", "6");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            total6_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();


        //7.维修技术信息资料汇编月统计       
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount(where, "7");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            month7_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //7.维修技术信息资料汇编总统计
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount("", "7");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            total7_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();


        //8.学科学会论文集库        
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount(where, "8");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            month8_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //8.学科学会论文集库总统计 
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount("", "8");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            total8_digital.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();
    }
    

    private void doSearch()
    {
        string starttime = txt_starttime.Value;
        string endtime = txt_endtime.Value;
        string cardno = txt_cardno.Value;
        if (starttime.Equals("") || endtime.Equals("") || cardno.Equals(""))
        {
            Response.Write("<script>alert('卡号或日期不能为空!');</script>");
            return;
        }
        table2.Visible = true;
        lbl_starttime.Text = starttime;
        lbl_endtime.Text = endtime;
        where = string.Format(" (_借书日期 between '{0}' and '{1}') and [bib].recid ='{2}'", starttime, endtime, cardno);
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

        where = string.Format("(invite_time between '{0}' and '{1}') and user_id ='{2}'", starttime, endtime, cardno);
        //1. 本校教材
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount(where, "1");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            digital1_search.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //2.本校论文 
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount(where, "2");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            digital2_search.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //3. 教学研究资料
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount(where, "3");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            digital3_search.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //4. 科研学术动态
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount(where, "4");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            digital4_search.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //5. 军械士官
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount(where, "5");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            digital5_search.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //6. 教学参考书全文库
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount(where, "6");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            digital6_search.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //7. 维修技术信息资料汇编
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount(where, "7");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            digital7_search.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();

        //8. 教学参考书全文库 
        mStatistics.StatisticsDataOpen();
        mSqlDataReader = mStatistics.GetDigitalInfoCount(where, "8");
        if (mSqlDataReader == null)
        {
            return;
        }
        if (mSqlDataReader.Read())
        {
            digital8_search.Text = mSqlDataReader["num"].ToString();
        }
        mStatistics.StatisticsDataClose();
    }

    protected void btn_Search_ServerClick(object sender, EventArgs e)
    {
        doSearch();
    }
}
