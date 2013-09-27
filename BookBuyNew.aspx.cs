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
using System.Collections.Generic;

public partial class BookBuyNew : System.Web.UI.Page
{
    private string connString = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null && Session["username"] != null)
        {
            connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBString"].ConnectionString;

            if (!IsPostBack)
            {
                string value = "dojo.byId('" + TextBox1.ClientID + "').value = '';" +
                    "dojo.byId('" + TextBox2.ClientID + "').value = '';" +
                    "dojo.byId('" + TextBox3.ClientID + "').value = '';" +
                    "dojo.byId('" + TextBox4.ClientID + "').value = '';" +
                    "dojo.byId('" + TextBox5.ClientID + "').value = '';" +
                    "dojo.byId('" + TextBox6.ClientID + "').value = '';" +
                    "dojo.byId('" + TextBox7.ClientID + "').value = '';";
                Button2.Attributes.Add("onclick", value);
            }
        }
        else { Response.Write("请登录后操作！"); Response.End(); }

    }

    //点击提交按钮
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand command = new SqlCommand("sp_search_recommend", conn);
        command.CommandType = CommandType.StoredProcedure;
        SqlParameter parameter_title = command.Parameters.Add("@title", SqlDbType.Char);
        SqlParameter parameter_author = command.Parameters.Add("@author", SqlDbType.Char);
        SqlParameter parameter_isbn = command.Parameters.Add("@isbn", SqlDbType.Char);
        SqlParameter parameter_publisher = command.Parameters.Add("@publisher", SqlDbType.Char);
        SqlParameter parameter_pubyear = command.Parameters.Add("@pubyear", SqlDbType.Char);
        SqlParameter parameter_price = command.Parameters.Add("@price", SqlDbType.Decimal);
        SqlParameter parameter_memo = command.Parameters.Add("@memo", SqlDbType.NText);
        SqlParameter parameter_result = command.Parameters.Add("result", SqlDbType.Int);
        parameter_result.Direction = ParameterDirection.ReturnValue;

        if (TextBox1.Text.Trim().Equals(string.Empty)
            || TextBox2.Text.Trim().Equals(string.Empty))
        {
            return;
        }
        parameter_title.Value = TextBox1.Text.Trim();
        parameter_author.Value = TextBox2.Text.Trim();
        parameter_isbn.Value = TextBox3.Text.Trim();
        parameter_publisher.Value = TextBox4.Text.Trim();
        if (TextBox5.Text.Trim().Equals(string.Empty) || TextBox5.Text.Trim().Length < 4)
        {
            parameter_pubyear.Value = "2008";
        }
        else
        {
            parameter_pubyear.Value = TextBox5.Text.Trim().Substring(0, 4);
        }
        if (TextBox6.Text.Trim().Equals(string.Empty))
        {
            parameter_price.Value = 0;
        }
        else
        {
            parameter_price.Value = Convert.ToDecimal(TextBox6.Text.Trim());
        }
        parameter_memo.Value = TextBox7.Text.Trim();

        try
        {
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
            int result = (int)command.Parameters["result"].Value;
            Panel1.Visible = true;
            if (result == 1)
            {
                Label2.Text = "此书已在流通中，谢谢。";
            }
            else if (result == 2)
            {
                Label2.Text = "此书正在编目，请稍等。";
            }
            else if (result == 3)
            {
                Label2.Text = "此书已经订购，谢谢。";
            }
            else
            {
                Label2.Text = "您的推荐已成功提交，谢谢。";
            }
        }
        catch (SqlException ex)
        {
            Panel1.Visible = true;
            Label2.Text = "推荐失败：" + ex.Message + "请稍后再试。";
            //Response.Write("<script type=\"text/javascript\">alert(\"" + ex.Message + "\");</script>");
        }
    }

   
}
