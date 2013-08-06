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

public partial class PDFShow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FileInfo fileinfo = new FileInfo(MapPath("cdsearch/Acrobat.pdf"));
            if (fileinfo.Exists)
            {
                Response.ContentType = GetContentType(fileinfo.FullName); //获得说明书读写类型
                  System.IO.FileStream reader = System.IO.File.OpenRead(fileinfo.FullName);
                  byte[] data = new byte[reader.Length];
                  reader.Read(data, 0, (int)reader.Length);
                  reader.Close();
                  Response.OutputStream.Write(data, 0, data.Length);
                  Response.End();
            }
            else
            {
                Response.Write("<div style='width:100%;text-align:center;margin-top:25px;'><font style='color:red;font-size:14px;font-weight:bold;'>无法获得相关专利说明书信息！</font><br/><span>[<a href='javascript:history.go(-1)'>返 回</a>]</span></div>");
            }
        }

    }
   
     

    public string GetContentType(string Path)
    {
        int FileType = GetTYpe(Path);
        string strContentType = "";
        //根据文件后缀名判断文件格式
        if (FileType == 1)
        {
            strContentType = "application/pdf";
        }
        else if (FileType == 2)
        {
            strContentType = "image/tiff";
        }
        else if (FileType == 3)
        {
            strContentType = "image/jpeg";
        }
        else if (FileType == 4)
        {
            strContentType = "text/html";
        }
        return strContentType;
    }

    //获得相应文件的类型
    public int GetTYpe(string strType)
    {

        if (strType.Substring(strType.LastIndexOf(".") + 1).Equals("PDF",
StringComparison.CurrentCultureIgnoreCase))
        {
            return 1;
        }
        else if (strType.Substring(strType.LastIndexOf(".") + 1).Equals("tif",
StringComparison.CurrentCultureIgnoreCase))
        {
            return 2;
        }
        else if (strType.Substring(strType.LastIndexOf(".") + 1).Equals("jpg",
StringComparison.CurrentCultureIgnoreCase))
        {
            return 3;
        }
        else
        {
            return 4;
        }
    }
}
