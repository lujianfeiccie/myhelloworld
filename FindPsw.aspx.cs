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

public partial class FindPsw : System.Web.UI.Page
{
    public User myuser=new User();
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (username.Text == "" || userid.Text == "")
        {
            this.alter.Text = "请输入用户账号和读者条码";
        }
        else
        {
            myuser.UserName = username.Text;
            
            myuser.UserDataOpen();
            if (!myuser.UserCheck(username.Text))
            {
                alter.Text = "对不起，你的账号不存在";
            }
            else
            {
                myuser.GetUserInfo();
                if (myuser.UserID == userid.Text.Trim())
                {
                    Panel1.Visible = true;
                    alter.Visible = false;
                    username.ReadOnly = true;
                    userid.ReadOnly = true;
                    Button1.Visible = false;
                    pswquestion.Text = myuser.FindPswQuestion;
                }
                else
                { alter.Text = "对不起，账号和读者条码不一致"; }

            }
            myuser.UserDataClose();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        myuser.UserName = username.Text;
        myuser.UserDataOpen();
        myuser.GetUserInfo();
        if (myuser.UserID == userid.Text.Trim() && myuser.FindPswAnswer == pswanswer.Text.Trim())
        {
            psw.Text = "请牢记您的密码：&nbsp;&nbsp;" + myuser.PassWord;
        }
        else { psw.Text = "对不起密码提示答案错误，请重试！或者到图书馆联系馆员。"; }
        myuser.UserDataClose();
    }
}
