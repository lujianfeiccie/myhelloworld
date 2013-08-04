<%@ WebHandler Language="C#" Class="rssprediction" %>

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

public class rssprediction : IHttpHandler {
    
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
        xmlTextWriter.WriteElementString("title", "图书馆超期预警");
        xmlTextWriter.WriteElementString("link", fullUrl);
        xmlTextWriter.WriteElementString("description", "将在 7 天后到期的图书");
        xmlTextWriter.WriteElementString("copyright", "(c) 2007, 图书馆. All rights reserved.");
        xmlTextWriter.WriteElementString("ttl", "60");

        string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBString"].ConnectionString;

        SqlConnection conn = new SqlConnection(connString);
        SqlCommand command = new SqlCommand("sp_search_prediction", conn);

        command.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
        DataSet dataSet = new DataSet();

        dataAdapter.Fill(dataSet, "exceedReaders");

        DataTable dataTable = dataSet.Tables["exceedReaders"];
        
        string BR = "<br />";

        foreach (DataRow row in dataTable.Rows)
        {
            xmlTextWriter.WriteStartElement("item");
            xmlTextWriter.WriteElementString("title", row[2].ToString());
            string description = "读者姓名：<b>" + row[0].ToString() + "</b>" + BR +
                "单位：" + row[1].ToString() + BR +
                "借出日期：" + row[4].ToString() + BR +
                "应还日期：" + row[5].ToString();

            xmlTextWriter.WriteElementString("description", description);
            xmlTextWriter.WriteElementString("link", url + "bookdetail.aspx?id=" + row[6]);
            //xmlTextWriter.WriteElementString("pubDate", reader.GetString(16));
            xmlTextWriter.WriteEndElement();
        }

        xmlTextWriter.WriteEndElement();
        xmlTextWriter.WriteEndElement();
        xmlTextWriter.WriteEndDocument();
        xmlTextWriter.Flush();
        xmlTextWriter.Close();
    }

}