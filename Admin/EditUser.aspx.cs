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

public partial class Admin_EditUser : System.Web.UI.Page
{
    public string result = "";
    public bool isself = false;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] != null && Session["username"].ToString() != "")
        {
            Admin myadmin = new Admin();
            myadmin.UserName = Session["username"].ToString();
           
            myadmin.UserDataOpen();
            myadmin.GetAdminInfo();
            myadmin.UserDataClose();
            if (Request.QueryString["act"] != null && Request.QueryString["act"].ToString() == "self")
            {
                isself = true;
                User myuser = new User();
                myuser.UserName = Session["username"].ToString();
                myuser.UserDataOpen();
                myuser.GetUserInfo();
                if (IsPostBack)
                {
                    myuser.UserName = username.Text.Trim();
                    myuser.PassWord = password.Text;
                    myuser.FindPswQuestion = question.Text;
                    myuser.FindPswAnswer = answer.Text;
                    result = myuser.UpdateInfo();
                        

                }
                username.Text = myuser.UserName;
                username.ReadOnly = true;
                password.Text = myuser.PassWord;
                question.Text = myuser.FindPswQuestion;
                answer.Text = myuser.FindPswAnswer;
               
            }
            else
            {
                if (myadmin.UserOP)
                {
                    if (Request.QueryString["user"] != null && Request.QueryString["user"].ToString() != "")
                    {

                        User myuser = new User();
                        myuser.UserName = Request.QueryString["user"].ToString();
                        myuser.UserDataOpen();
                        myuser.GetUserInfo();
                        if (IsPostBack)
                        {
                            myuser.UserName = username.Text.Trim();
                            myuser.PassWord = password.Text;
                            myuser.FindPswQuestion = question.Text;
                            myuser.FindPswAnswer = answer.Text;

                            result = myuser.UserCheck(userid.Text, true);
                            if (result != "非法的卡号！")
                            {
                                result = myuser.UpdateInfo();
                                Response.Redirect("UserList.aspx?keyword=" + username.Text);
                            }


                        }
                        username.Text = myuser.UserName;
                        username.ReadOnly = true;
                        password.Text = myuser.PassWord;
                        question.Text = myuser.FindPswQuestion;
                        answer.Text = myuser.FindPswAnswer;
                        userid.Text = myuser.UserID;
                        userid.ReadOnly = true;
                        realname.Text = myuser.RealName;
                        depart.Text = myuser.UserDepartment;
                        banzheng.Text = myuser.CardTime.ToString();
                        allnum.Text = myuser.TotalRent.ToString();
                        nownum.Text = myuser.NowRent.ToString();
                        money.Text = myuser.Money.ToString();
                        logintimes.Text = myuser.LoginTimes.ToString();
                        lastip.Text = myuser.LastLoginIP;
                        lasttime.Text = myuser.LastLoginTime.ToString();
                        type.Text = myuser.ReaderType;
                        gender.Text = myuser.Gender;
                        myuser.UserDataClose();


                    }

                }
                else
                {
                    Response.Write("对不起，您没有操作此项目的权限！");
                    Response.End();
                }

            }

        }
        else { Response.Write("请登录后操作！"); Response.End(); }

    }

}
