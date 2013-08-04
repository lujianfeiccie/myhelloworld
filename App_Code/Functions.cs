using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Text;
using System.Drawing;
using System.IO;
/// <summary>
/// Functions 的摘要说明
/// </summary>
public class Functions
{
    public Functions()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    #region 防止代碼注入
    /// <summary>
    /// 防止HTML代碼注入
    /// </summary>
    /// <param name="NoteContent"></param>
    /// <returns></returns>
    public string ExchangeNote(string NoteContent)
    {
        string afterReContent = "";
        afterReContent = NoteContent.Replace("<script>", "<xmp>").Replace("</script>", "</xmp>");
        return afterReContent;
    }
    /// <summary>
    /// 防止SQL注入
    /// </summary>
    /// <param name="inputStr">輸入的sql語句</param>
    /// <returns>過濾後的語句</returns>
    public string No_SqlHack(string inputStr)
    {
        //要過濾掉的關鍵字集合
        string NoSqlHack_AllStr = "|or|;|and|chr(|exec|insert|select|delete|from|update|mid(|master.|";
        string SqlHackGet = inputStr;
        string[] AllStr = NoSqlHack_AllStr.Split('|');

        //分離關鍵字
        string[] GetStr = SqlHackGet.Split(' ');
        if (SqlHackGet != "")
        {
            for (int j = 0; j < GetStr.Length; j++)
            {
                for (int i = 0; i < AllStr.Length; i++)
                {
                    if (GetStr[j].ToLower() == AllStr[i].ToLower())
                    {
                        GetStr[j] = "";
                        break;
                    }
                }
            }
            SqlHackGet = "";
            for (int i = 0; i < GetStr.Length; i++)
            {
                SqlHackGet += GetStr[i].ToString() + " ";
            }
            return SqlHackGet.TrimEnd(' ').Replace("'", "_").Replace(",", "_").Replace("<", "&lt").Replace(">", "&gt");
        }
        else
        {
            return "";
        }
    }
    #endregion
    public string ClearHTML(string str, int str_len, bool isadd)
    {
        string newstr = Regex.Replace(str, "<[^>]+>", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        return ShortString(newstr, str_len, isadd);

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str_value">输入字符串</param>
    /// <param name="str_len">截取长度</param>
    /// <param name="isadd">是不是需要加上...</param>
    /// <returns></returns>
    public string ShortString(string stringToSub, int length, bool isadd)
    {
        Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
        char[] stringChar = stringToSub.ToCharArray();
        StringBuilder sb = new StringBuilder();
        int nLength = 0;
        bool isCut = false;
        for (int i = 0; i < stringChar.Length; i++)
        {
            if (regex.IsMatch((stringChar[i]).ToString()))
            {
                sb.Append(stringChar[i]);
                nLength += 2;
            }
            else
            {
                sb.Append(stringChar[i]);
                nLength = nLength + 1;
            }

            if (nLength > length)
            {
                isCut = true;
                break;
            }
        }
        if (isCut && (isadd == true))
            return sb.ToString() + "..";
        else if (isCut && (isadd == false))
            return sb.ToString();
        else
            return sb.ToString();
    }
    /// <summary>
    /// 重载次函数
    /// </summary>
    /// <param name="stringToSub">字符串</param>
    /// <param name="length">长度</param>
    /// <param name="addchars">不够长度补齐的半个字节字符</param>
    /// <returns></returns>
    public string ShortString(string stringToSub, int length, string addchars)
    {
        Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
        char[] stringChar = stringToSub.ToCharArray();
        StringBuilder sb = new StringBuilder();
        int nLength = 0;
        bool isCut = false;
        for (int i = 0; i < stringChar.Length; i++)
        {
            if (regex.IsMatch((stringChar[i]).ToString()))
            {
                sb.Append(stringChar[i]);
                nLength += 2;
            }
            else
            {
                sb.Append(stringChar[i]);
                nLength = nLength + 1;
            }

            if (nLength > length)
            {
                isCut = true;
                break;
            }
        }
        if (isCut)//如果需要截取
            return sb.ToString();
        else
        {
            for (int j = nLength; j < length; j++)
            {
                sb.Append(addchars);
            }
            return sb.ToString();
        }
    }
    /// <summary>
    /// 返回时间格式
    /// </summary>
    /// <param name="thetime"></param>
    /// <param name="format">类型,YMD--2008-5-7,MD-08-31,YMDHM-2008-08-31 5:45,MDHM-08-31 3:45</param>
    /// <returns></returns>
    public string ShortDateTime(DateTime thetime, string format)
    {
        if (format == "YMD")
            return thetime.Year.ToString()+"-"+thetime.Month.ToString() + "-" + thetime.Day.ToString();
        else if (format == "MD")
            return thetime.Month.ToString() + "-" + thetime.Day.ToString();
        else if (format == "YMDHM")
            return thetime.Date.ToString() + " " + thetime.Hour.ToString() + ":" + thetime.Minute.ToString();
        else if (format == "MDHM")
            return thetime.Month.ToString() + "-" + thetime.Day.ToString() + " " + thetime.Hour.ToString() + ":" + thetime.Minute.ToString();
        else return thetime.ToString();
    }
    /// <summary>
    /// 提取str中的图像连接地址
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string GetImage(string str)
    {
        string pattern, restr;
        pattern = @"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>";
        Regex newreg = new Regex(pattern, RegexOptions.Compiled);
        Match mypic = newreg.Match(str.ToLower());
        while (mypic.Success)
        {

            restr = mypic.Result("${url}");
            string[] temp = restr.Split('\u0022');
            if (temp.Length >= 2)
                return temp[1];
            else
                return restr;

        }
        return "ad/download.jpg";//无图片的时候
    }
    /// <summary>
    /// 上传图片并生产缩略图
    /// </summary>
    /// <param name="ful">fileupload 控件</param>
    /// <param name="mode">生成缩略图方式:1,指定宽度比例生成/2,指定高度比例生成/3,指定宽和高度剪切/其他按照固定的高度和宽度生成</param>
    /// <returns>返回缩略图路径</returns>
    public string UploadImageThumbFile(System.Web.UI.WebControls.FileUpload ful,int mode)
    {

        try
        {
            string fileType = System.Configuration.ConfigurationManager.AppSettings["ImagesType"].ToString();
            string imagepath = System.Configuration.ConfigurationManager.AppSettings["ImageThumbnailPath"].ToString();

            if (ful.PostedFile.ContentLength == 0) { return""; }
            
            System.Random random = new Random();
            String modifyFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + random.Next(1000, 9999);
            String uploadFilePath = System.Web.HttpContext.Current.Server.MapPath("../") + imagepath;
            String sourcePath = ful.PostedFile.FileName;

            String tFileType = sourcePath.Substring(sourcePath.LastIndexOf(".") + 1);

            int strLen = ful.PostedFile.ContentLength;

            if (fileType.IndexOf(tFileType) == -1)
            {
                return "";
            }

            //目录是否存在
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(uploadFilePath);
            if (!dir.Exists)
            {
                dir.Create();
            }
            String filePath = uploadFilePath + modifyFileName + "." + tFileType;
            ful.SaveAs(filePath);
            MakeThumbnail(filePath, uploadFilePath  + modifyFileName + "_s." + tFileType,mode);
           
            filePath = imagepath + modifyFileName + "_s." + tFileType;
            return filePath.Replace("\\", "/");
        }
        catch (Exception ex)
        {
            return "";
        }
        

    }
    /// <summary>
    /// 上传缩略图
    /// </summary>
    /// <param name="originalImagePath">源文件大图路径</param>
    /// <param name="_mode">1,指定宽度比例生成/2,指定高度比例生成/3,指定宽和高度剪切/其他按照固定的高度和宽度生成</param>
    /// <returns>返回图片路径</returns>
    public string MakeThumbnail(string originalImagePath,string thumbnailpath,int _mode)
    {
       
        int toheight = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ImageThumbnailHeight"].ToString());
        int towidth = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ImageThumbnailWidth"].ToString());
       
        //////////////
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

        

        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;

        switch (_mode)
        {
            case 1://指定宽，高按比例                     
                toheight = originalImage.Height * towidth / originalImage.Width;
                break;
            case 2://指定高，宽按比例 
                towidth = originalImage.Width * toheight / originalImage.Height;
                break;
            case 3://指定高宽裁减（不变形）                 
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * toheight / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default://指定高宽缩放（可能变形）   
                break;
        }

        //新建一个bmp图片 
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

        //新建一个画板 
        Graphics g = System.Drawing.Graphics.FromImage(bitmap);

        //设置高质量插值法 
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        //设置高质量,低速度呈现平滑程度 
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //清空画布并以透明背景色填充 
        g.Clear(Color.Transparent);

        //在指定位置并且按指定大小绘制原图片的指定部分 
        g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
         new Rectangle(x, y, ow, oh),
         GraphicsUnit.Pixel);

        try
        {
            //以jpg格式保存缩略图 
            bitmap.Save(thumbnailpath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception ex)
        {
            return "成生缩略图错误：" + ex.Message;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
        return thumbnailpath;
        

    }

    public string GetFileSize(int filesize)
    { 
        double filetemp=filesize/1024.0;
        double filetemp2=filesize/(1024*1024.0);
        double filetemp3=filesize/(1024*1024*1024.0);
        if (filetemp <= 1)
        {
            return filesize.ToString() + "Byte";
        }
        else if (filetemp <= 1024 && filetemp > 1)
        {
            return filetemp.ToString("F2") + "K";
        }
        else if(filetemp2<= 1024 && filetemp2>1)
        {

            return filetemp2.ToString("F2") + "M";
        }
        else if(filetemp3<= 1024 && filetemp3>1)
        {
            return filetemp3.ToString("F2") + "G";
        }
        else
        {return filesize.ToString()+"Byte";}
    }
    public bool DownloadFile(HttpRequest _reqest, HttpResponse _response, string file_url, string filename)
    {
        Stream mystream = null;
        byte[] buffer = new Byte[10240];//buffer to read 10k bytes inchunk;
        int length;
        long datatoread;
        if (file_url.Length <= 0)
            return false;
        string filepath = HttpContext.Current.Request.MapPath("~/") + file_url;
        string file_extension = file_url.Substring(file_url.LastIndexOf('.'));
        //   string filename = FileName;
        try
        {
            mystream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
            _response.Clear();
            datatoread = mystream.Length;
            long p = 0;
            if (_reqest.Headers["Range"] != null)
            {
                _response.StatusCode = 206;
                p = long.Parse(_reqest.Headers["Range"].Replace("bytes=", "").Replace("-", ""));
            }
            if (p != 0)
            {
                _response.AddHeader("Content-Range", "bytes " + p.ToString() + "-" + ((long)(datatoread - 1)).ToString() + "/" + datatoread.ToString());
            }
            _response.AddHeader("Content-Length", ((long)(datatoread - p)).ToString());
            _response.ContentType = "application/octet-stream";
            _response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(filename + file_extension));
            mystream.Position = p;
            datatoread = datatoread - p;
            while (datatoread > 0)
            {
                if (_response.IsClientConnected)
                {
                    length = mystream.Read(buffer, 0, 10240);
                    _response.OutputStream.Write(buffer, 0, length);
                    _response.Flush();
                    buffer = new Byte[10240];
                    datatoread = datatoread - length;
                }
                else
                {
                    datatoread = -1;
                }
            }
            mystream.Close();
            // AddDownloadRecord(_reqest.UserHostAddress, user_id);
            return true;
        }
        catch { return false; }

    }

}
