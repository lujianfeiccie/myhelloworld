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
public partial class Downloadteach : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Functions myfun = new Functions();
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
        {
            string url="",filename="";
            
                DataSystem dataconnection=new DataSystem();//用于数据链接
                string sql="select * from [lib_teach] where sid=@Uid";
                dataconnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBString"].ToString();
                SqlParameter[] mypara ={ new SqlParameter("@Uid",SqlDbType.VarChar) };
                mypara[0].Value = Request.QueryString["id"].ToString();
                dataconnection.Open();
                SqlDataReader reader= dataconnection.GetDataReader(mypara, sql);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        url = reader["vfilename"].ToString();
                        filename = reader["title"].ToString();
                    }
                }
                dataconnection.Close();
            
            if (!myfun.DownloadFile(Page.Request, Page.Response, url, filename))
                Response.Write("对不起没有找到文件！");
           
        }
        else { Response.Write("对不起，非法访问！"); }
    }
}
