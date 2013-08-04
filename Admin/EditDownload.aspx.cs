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

public partial class Admin_EditDownload : System.Web.UI.Page
{
    public Functions myfun = new Functions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["username"].ToString() != "" && Session["loginstate"] != null && Session["loginstate"].ToString() == "ok"&&Request.QueryString["id"]!=null&&Request.QueryString["id"].ToString()!="")
        {
            string downloadid = Request.QueryString["id"].ToString();
            downloadidvalue.Value = downloadid;

            Admin myadmin = new Admin();

            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            if (myadmin.DownloadOP)
            {
                Download mydown = new Download();
                mydown.ID = downloadid;
                mydown.DownloadDataOpen();
               
                mydown.GetDownloadInfo();
                mydown.DownloadDataClose();
                if (IsPostBack)//如果是提交
                {
                    if (DownloadFile.HasFile)
                    {
                        string FileName = this.DownloadFile.FileName;//获取上传文件的文件名,包括后缀
                        string ExtenName = System.IO.Path.GetExtension(FileName);//获取扩展名        

                        string url = "FileUpLoad/BigFiles/" + DateTime.Now.ToString("yyyyMMddhhmmss") + ExtenName;  //文件保存的路径  
                        string SaveFileName = System.IO.Path.Combine(System.Web.HttpContext.Current.Request.MapPath("~/"), url);//合并两个路径为上传到服务器上的全路径 

                        this.DownloadFile.MoveTo(SaveFileName, Brettle.Web.NeatUpload.MoveToOptions.Overwrite);
                        long FileSize = DownloadFile.ContentLength; //获取文件大小并保留小数点后一位,单位是M

                        FileName = FileName.Substring(0, (FileName.LastIndexOf(".") - 1));//除去扩展名
                        ExtenName = ExtenName.Substring(1);//除去点
                        mydown.FileEXT = ExtenName;
                        mydown.FileName = FileName;
                        mydown.FileSize = (int)FileSize;
                        mydown.FileURL = url;
                    }

                    if (headpic.HasFile)
                        mydown.HeadPic = myfun.UploadImageThumbFile(headpic, 1);

                    mydown.Author = author.Text;
                    mydown.CheckAdmin = Session["username"].ToString();
                    mydown.DownloadTimes = int.Parse(num2.Text);
                    mydown.Info = info.Value;
                    mydown.Language = language.Text;
                    mydown.PlatForm = platform.Text;
                    mydown.UpdateTime = DateTime.Now;
                    mydown.UpdateIP = Request.UserHostAddress;
                    mydown.UpdateUser = Session["username"].ToString();
                    mydown.Rank = rank.SelectedValue;
                    mydown.Title = newstitle.Text;
                    mydown.TypeName = typename.Text;
                    mydown.VisitNum = int.Parse(num1.Text);
                    mydown.XingZhi = xingzhi.Text;
                    mydown.IsRecommend = false;
                    mydown.IsNeedLogin = false;
                    mydown.IsChecked = ischeck.Checked;
                    string result = myadmin.EditDownload(mydown);
                    if (result == "ok")
                        Response.Redirect("DownloadList.aspx");
                    else { Response.Write(result); Response.End(); }


                }
                else
                {

                    newstitle.Text = mydown.Title;
                    ischeck.Checked = mydown.IsChecked;
                    author.Text = mydown.Author;
                    xingzhi.Text = mydown.XingZhi;
                    language.Text = mydown.Language;
                    platform.Text = mydown.PlatForm;
                    typename.Text = mydown.TypeName;
                    num1.Text = mydown.VisitNum.ToString();
                    num2.Text = mydown.DownloadTimes.ToString();
                    info.Value = mydown.Info;



                    rank.Items.Add(new ListItem("一星", "1"));
                    rank.Items.Add(new ListItem("二星", "2"));
                    rank.Items.Add(new ListItem("三星", "3"));
                    rank.Items.Add(new ListItem("四星", "4"));
                    rank.Items.Add(new ListItem("五星", "5"));
                    rank.SelectedValue = mydown.Rank;

                    SqlDataReader reader = myadmin.GetDownloadTypes();
                    types.DataSource = reader;
                    types.DataValueField = "typename";
                    types.DataTextField = "typename";
                    types.DataBind();
                    reader.Close();
                }
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

}
