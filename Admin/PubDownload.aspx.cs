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

public partial class Admin_PubDownload : System.Web.UI.Page
{
    public Functions myfun = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["username"].ToString() != "" && Session["loginstate"] != null && Session["loginstate"].ToString() == "ok")
        {
            Functions myfun = new Functions();
            Admin myadmin = new Admin();
            
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            if (myadmin.DownloadOP)
            {
                rank.Items.Add(new ListItem("一星", "1"));
                rank.Items.Add(new ListItem("二星", "2"));
                rank.Items.Add(new ListItem("三星", "3"));
                rank.Items.Add(new ListItem("四星", "4"));
                rank.Items.Add(new ListItem("五星", "5"));
                SqlDataReader reader = myadmin.GetDownloadTypes();
                types.DataSource = reader;
                types.DataValueField = "typename";
                types.DataTextField = "typename";
                types.DataBind();
                reader.Close();
            }
            else
            { Response.Write("对不起，你没有此项目的管理权限！"); Response.End(); }
            myadmin.UserDataClose();
        }
        else
        {
            Response.Write("请登录后操作！");
            Response.End();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.DownloadFile.HasFile)
        {

            Functions myfun = new Functions();
            Admin myadmin = new Admin();
            string url2 = "DownloadList.aspx";
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            if (myadmin.DownloadOP)
            {
                Download mydown = new Download();
                
                string FileName = this.DownloadFile.FileName;//获取上传文件的文件名,包括后缀
                string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名        

                string url = "FileUpLoad/BigFiles/" + DateTime.Now.ToString("yyyyMMddhhmmss") + ExtenName;  //文件保存的路径  
                string SaveFileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath("~/"), url);//合并两个路径为上传到服务器上的全路径 

                this.DownloadFile.MoveTo(SaveFileName, Brettle.Web.NeatUpload.MoveToOptions.Overwrite);
                long FileSize = DownloadFile.ContentLength; //获取文件大小并保留小数点后一位,单位是M

                FileName = FileName.Substring(0, (FileName.LastIndexOf(".")));//除去扩展名
                ExtenName = ExtenName.Substring(1);//除去点

                mydown.Author = author.Text;
                mydown.CheckAdmin = Session["username"].ToString();
                mydown.DownloadTimes =int.Parse( num2.Text);
                mydown.FileEXT = ExtenName;
                mydown.FileName = FileName;
                mydown.FileSize =(int) FileSize;
                mydown.FileURL = url;
                if (headpic.HasFile)
                    mydown.HeadPic = myfun.UploadImageThumbFile(headpic, 1);
                else mydown.HeadPic = "Images/ad2.gif";
                mydown.Info = info.Value;
                mydown.Language=language.Text;
                mydown.PlatForm = platform.Text;
                mydown.PubIP = Request.UserHostAddress;
                mydown.PubTime = DateTime.Now;
                mydown.PubUser = Session["username"].ToString();
                mydown.Rank = rank.SelectedValue;
                mydown.Title = newstitle.Text;
                mydown.TypeName = typename.Text;
                mydown.VisitNum = int.Parse(num1.Text);
                mydown.XingZhi = xingzhi.Text;
                mydown.IsRecommend = false;
                mydown.IsNeedLogin = false;
                mydown.IsChecked = ischeck.Checked;
                mydown.UpdateTime = DateTime.Now;
                mydown.UpdateIP = Request.UserHostAddress;
                mydown.UpdateUser = Session["username"].ToString();
                string result=myadmin.AddDownload(mydown);
                if (result == "ok")
                    Response.Redirect("DownloadList.aspx");
                else { Response.Write(result); Response.End(); }
            }
            else
            { Response.Write("对不起，你没有此项目的管理权限！"); Response.End(); }
           
            myadmin.UserDataClose();
            

        }
        else
        {
            Response.Write("<div onclick=\"this.style.display='none'\" style='z-index:3;white-space:normal; position:absolute; top:300px; left:300px;padding:50px 50px 50px 50px; width:300px; height:100px; background-color:#f0f0f0;color:Red; border:solid 1px #f7f7f7;'>请正确上传文件！</div>");
           
        }
    }
}
