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
using System.IO;

public partial class Admin_ImportExcel : System.Web.UI.Page
{
    private string type = "paper";
    private string[] tablename = { "lib_paper", "lunwen"};
    public string result1 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["username"] != null)
        {
            Admin myadmin = new Admin();
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            myadmin.UserDataClose();
            if (myadmin.PaperOP)
            {
                if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() != "")
                    type = Request.QueryString["type"].ToString();
                switch (type)
                {
                    case "cd":
                        title.InnerText = "随书光盘数据导入";
                        tablename[0] = "lib_cd";//必须将光盘这个增加列，路径和介绍/下载次数
                        tablename[1] = "Sheet1";
                        break;
                    case "teach":
                        title.InnerText = "情报资料数据导入";
                        tablename[0] = "lib_teach";
                        tablename[1] = "Sheet1";
                        break;
                    default:
                        title.InnerText = "论文数据导入";
                        tablename[0] = "lib_paper";
                        tablename[1] = "lunwen";
                        break;
                }
            }
            else { Response.Write("请联系管理员开通此项权限！"); Response.End(); }

        }
        else
        { Response.Write("请正确登陆后操作！"); Response.End(); }
        
        //dTable.Clear();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        
        if (FileUpload1.HasFile&&FileUpload1.PostedFile.ContentLength!=0)
        {
            string realfilepath = HttpContext.Current.Request.MapPath("~/") + "temp.xls";
            if (File.Exists(realfilepath))
            {
                File.Delete(realfilepath);
                if (File.Exists(realfilepath))
                           result1 = "对不起系统错误！";

             }
             if (result1 == "")
             {
                 FileUpload1.SaveAs(realfilepath);
                 ExcelSystem myexcel = new ExcelSystem();
                 myexcel.filepath = "temp.xls";
                 if (myexcel.Insert2SQL(tablename[0], tablename[1]))
                     result1 = "成功导入数据！";
                
             }
             result.InnerText = result1;
           
        }
        return;

    }
}
