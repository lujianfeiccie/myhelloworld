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

public partial class Contrl_PageNum : System.Web.UI.UserControl
{
    private int nowpage=1;
    private int nextpage;
    private int lastpage;
    private int allpage=1;
    private string url="#";
    private string output;
    private int startpage=1;//显示的起始页
    private int endpage;//显示的末页号
    private int previousPageCount = 5;//当前页之前可以显示的最多条目数，大于此条目的将被隐藏
    private int afterPageCount = 4; //当前页之后可以显示的最多条目数，大于此条目的将被隐藏
    private string onclickaction="";//用于js方法名称
    private string actionparas;//js方法参数

    public string OnClikAction
    {
        get { return onclickaction; }
        set { onclickaction = value; }
    }
    public string ActionParas
    {
        get { return actionparas; }
        set { actionparas = value; }
    }
    public int NowPage
    {
        get { return nowpage; }
        set { nowpage = value; }
    }
    public int AllPage
    {
        get { return allpage; }
        set { allpage = value; }
    }
    public string PageURL
    {
        get { return url; }
        set { url = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (nowpage < 1)
            nowpage = 1;
        if (allpage < 1)
            allpage = 1;
        if (nowpage > allpage)
            nowpage = allpage;
        lastpage=nowpage-1;
        nextpage=nowpage+1;
        if (lastpage < 1)
            lastpage = 1;
        if (nextpage > allpage)
            nextpage = allpage;
        SetStartPage();
        SetEndPage();
        if (onclickaction != "")
        {
            output = "<span><a href=\"#\" onclick=\"" + onclickaction + "(1," + actionparas + ")\">首页</a></span>";
            output += "<span><a href=\"#\" onclick=\"" + onclickaction + "(" + lastpage + "," + actionparas + ")\">上一页</a></span>";
            for (int ii = startpage - 1; ii < endpage; ii++)
            {
                int numpage = ii + 1;
                if (nowpage == numpage)
                    output += "<span class=\"page_num_on\"><a href=\"#\" onclick=\"" + onclickaction + "(" + numpage + "," + actionparas + ")\">" + numpage + "</a></span>";
                else
                    output += "<span><a href=\"#\" onclick=\"" + onclickaction + "(" + numpage + "," + actionparas + ")\">" + numpage + "</a></span>";
            }

            output += "<span><a href=\"#\" onclick=\"" + onclickaction + "(" + nextpage + "," + actionparas + ")\">下一页</a></span>";
            output += "<span><a href=\"#\" onclick=\"" + onclickaction + "(" + allpage + "," + actionparas + ")\">末页</a></span>";
        
        
        
        }
        else
        {
            output = "<span><a href=\"" + url + "&pagenum=1&allpage=" + allpage + "\" >首页</a></span>";
            output += "<span><a href=\"" + url + "&pagenum=" + lastpage + "&allpage=" + allpage + "\">上一页</a></span>";
            for (int ii = startpage - 1; ii < endpage; ii++)
            {
                int numpage = ii + 1;
                if (nowpage == numpage)
                    output += "<span class=\"page_num_on\"><a href=\"" + url + "&pagenum=" + numpage + "&allpage=" + allpage + "\" >" + numpage + "</a></span>";
                else
                    output += "<span><a href=\"" + url + "&pagenum=" + numpage + "&allpage=" + allpage + "\" >" + numpage + "</a></span>";
            }

            output += "<span><a href=\"" + url + "&pagenum=" + nextpage + "&allpage=" + allpage + "\">下一页</a></span>";
            output += "<span><a href=\"" + url + "&pagenum=" + allpage + "&allpage=" + allpage + "\" >末页</a></span>";
        
        }
       
        page_list.InnerHtml = output;
    }
    // 根据当前页，当前页之前可以显示的页数，算得从第几页开始进行显示
    private void SetStartPage()
    {
           // 如果当前页小于 它前面所可以显示的条目数，那么显示第一页就是实际的第一页
           if (nowpage <= previousPageCount)
           {
            startpage = 1;
           }
           else // 这种情况下 currentPage 前面总是能显示完，要根据后面的长短确定是不        是前面应该多显示
           {
              int linkLength = (allpage - nowpage + 1) + previousPageCount;

              startpage = nowpage - previousPageCount;

               while (linkLength < previousPageCount + afterPageCount + 1 && startpage > 1)
            {
                linkLength++;
                startpage--;
            }

            this.startpage = startpage;
           }
    }

    // 根据CurrentPage、总页数、当前页之后长度 算得显示的最末页是 第几页
    private void SetEndPage()
    {
       // 如果当前页加上它之后可以显示的页数 大于 总页数，那么显示的最末页就是实际的最末页
       if (nowpage + afterPageCount >= allpage)
       {
        endpage = allpage;
       } 
       else // 这种情况下 currentPage后面的总是可以显示完，要根据前面的长短确定 是不是后面应该多显示
       {

        int linkLength = (nowpage - startpage + 1) + afterPageCount;
      
        endpage = nowpage + afterPageCount;

        while (linkLength < previousPageCount + afterPageCount + 1 &&  endpage < allpage)
        {
         linkLength++;
         endpage++;
        }

        this.endpage = endpage;
       }
    } 
}
