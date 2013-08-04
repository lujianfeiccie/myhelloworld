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

public partial class Admin_PubBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null && Session["username"].ToString() != "" && Session["loginstate"] != null && Session["loginstate"].ToString() == "ok")
        {
            Functions myfun = new Functions();
            Admin myadmin = new Admin();
            string url = "BookList.aspx";
            myadmin.UserName = Session["username"].ToString();
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();

            if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "edit" && Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
            {
                Book mybook = new Book();
                mybook.ID= Request.QueryString["id"].ToString();
                mybook.BookDataOpen();
                mybook.GetInfo();
                string headpicstring = mybook.PicURL;
                if (myadmin.BookOP)
                {
                   
                    title.InnerText = "图书修改";
                }
                else { Response.Write("非法访问，请联系超级管理员授权此项目！"); Response.End(); }

                if (IsPostBack)
                {
                    
                    mybook.Title = newstitle.Text;
                    mybook.IsTop = istop.Checked;
                    mybook.Infos = info.Value;
                    mybook.TypeName = typename.Text;
                    mybook.ISBN = ISBN.Text;
                    mybook.Author = author.Text;
                    mybook.Publisher = publisher.Text;
		    if(pubtime.Text!=null&&pubtime.Text.ToString()!="")
                    	mybook.PubTime =DateTime.Parse( pubtime.Text);
                    else
 			mybook.PubTime=DateTime.Now;
                    mybook.TotalNum = int.Parse(num1.Text);
                    mybook.NowNum = int.Parse(num2.Text);
                    
                    if (headpic.HasFile)
                       mybook.PicURL = myfun.UploadImageThumbFile(headpic, 1);
                    else
                       mybook.PicURL = headpicstring;
                    
                  myadmin.EditBook(mybook);
                  Response.Redirect(url);

                }
                newstitle.Text = mybook.Title;
                info.Value = mybook.Infos;
                istop.Checked = mybook.IsTop;
                author.Text = mybook.Author;
                publisher.Text = mybook.Publisher;
                pubtime.Text = mybook.PubTime.ToString();
                typename.Text = mybook.TypeName;
                ISBN.Text = mybook.ISBN;
                num2.Text = mybook.NowNum.ToString();
                num1.Text = mybook.TotalNum.ToString();
                SqlDataReader reader = myadmin.GetNewBookTypes();
                types.DataSource = reader;
                types.DataValueField = "typename";
                types.DataTextField = "typename";
                types.DataBind();
                reader.Close();



                mybook.BookDataClose();


            }
            else if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "delete" && Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
            {
                if (myadmin.BookOP)
                {
                    string result = "";
                    result = myadmin.DeleteBook(Request.QueryString["id"].ToString());
                    if (result == "ok") Response.Redirect(url);
                    else { Response.Write(result); Response.End(); }
                }
                else { Response.Write("非法访问，请联系超级管理员授权此项目！"); Response.End(); }
               

            }
            else
            {
                if (myadmin.BookOP)
                {
                    Book mybook = new Book();
                    SqlDataReader reader = myadmin.GetNewBookTypes();
                    types.DataSource = reader;
                    types.DataValueField = "typename";
                    types.DataTextField = "typename";
                    types.DataBind();
                    reader.Close();
                    this.title.InnerText = "新书发布";
                    if (IsPostBack)
                    {
                        
                        mybook.Title = newstitle.Text;
                        mybook.IsTop = istop.Checked;
                        mybook.Infos = info.Value;
                        mybook.TypeName = typename.Text;
                        mybook.ISBN = ISBN.Text;
                        mybook.Author = author.Text;
                        mybook.Publisher = publisher.Text;
                        if(pubtime.Text!=null&&pubtime.Text.ToString()!="")
                    		mybook.PubTime =DateTime.Parse( pubtime.Text);
                    	else
 				mybook.PubTime=DateTime.Now;
                        mybook.AddIP = Request.UserHostAddress;
                        mybook.AddTime = DateTime.Now;
                        mybook.AddUser = Session["username"].ToString();
                        mybook.GoodNum = 0;
                        mybook.BadNum = 0;
                        mybook.VisitNum = 0;
                        mybook.NowNum =int.Parse( num2.Text);
                        mybook.TotalNum = int.Parse(num1.Text);
                        mybook.PicURL = myfun.UploadImageThumbFile(headpic, 1);
                        myadmin.AddBook(mybook);
                        Response.Redirect(url);

                    }
                }
                else { Response.Write("非法访问，请联系超级管理员授权此项目！"); Response.End(); }
                


            }



            myadmin.UserDataClose();
        }
        else
        {
            Response.Write("请登录后操作！");
            Response.End();
        }
    }

 
}
