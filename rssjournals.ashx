<%@ WebHandler Language="C#" Class="rssjournals" %>


using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Xml;
using System.Data.SqlClient;
using System.Text;

public class rssjournals : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/xml";
        context.Response.ContentEncoding = System.Text.Encoding.UTF8;
        buildRss(context.Response);
        //context.Response.Write("Hello World");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    
    private void buildRss(HttpResponse response)
    {
        string fullUrl = HttpContext.Current.Request.Url.ToString();
        string url = fullUrl.Remove(fullUrl.LastIndexOf('/') + 1);
        
        XmlTextWriter xmlTextWriter = new XmlTextWriter(response.OutputStream, Encoding.UTF8);
        xmlTextWriter.WriteStartDocument();
        xmlTextWriter.WriteStartElement("rss");
        xmlTextWriter.WriteAttributeString("version", "2.0");
        xmlTextWriter.WriteStartElement("channel");
        xmlTextWriter.WriteElementString("title", "图书馆期刊信息");
        xmlTextWriter.WriteElementString("link", fullUrl);
        xmlTextWriter.WriteElementString("description", "图书馆收录的期刊");
        xmlTextWriter.WriteElementString("copyright", "(c) 2007, 图书馆. All rights reserved.");
        xmlTextWriter.WriteElementString("ttl", "60");

        Rss myrss = new Rss();
        myrss.RssDataOpen();
        SqlDataReader reader = myrss.GetNewPapers();
        while (reader.Read())
        {            
            xmlTextWriter.WriteStartElement("item");
            xmlTextWriter.WriteElementString("title", reader.GetString(1));
            string description = getDescription(reader);

            xmlTextWriter.WriteElementString("description", description);
            xmlTextWriter.WriteElementString("link", url + "journaldetail.aspx?id=" + reader.GetString(0));
            //xmlTextWriter.WriteElementString("pubDate", reader.GetString(16));
            xmlTextWriter.WriteEndElement();
        }
        reader.Close();
        myrss.RssDataClose();

        xmlTextWriter.WriteEndElement();
        xmlTextWriter.WriteEndElement();
        xmlTextWriter.WriteEndDocument();
        xmlTextWriter.Flush();
        xmlTextWriter.Close();
    }

    private string getDescription(SqlDataReader reader)
    {
        string description = "";
        int[] a = { 3, 5, 6 };

        foreach (int i in a)
        {
            try
            {
                if (reader.GetString(i).Trim().Length > 0)
                {
                    description += reader.GetString(i).Trim() + ", ";
                }
            }
            catch (Exception e)
            {
            }
        }
        return description;
    }

}