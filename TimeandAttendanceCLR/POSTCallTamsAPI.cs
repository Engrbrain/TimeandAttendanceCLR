using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Net;
using System.IO;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void POSTCallTamsAPI(SqlString weburl, out SqlString returnval)
    {
        string url = Convert.ToString(weburl);

        string feedData = string.Empty;

        try

        {

            HttpWebRequest request = null;

            HttpWebResponse response = null;

            Stream stream = null;

            StreamReader streamReader = null;



            request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "POST";

            response = (HttpWebResponse)request.GetResponse();

            stream = response.GetResponseStream();

            streamReader = new StreamReader(stream);

            feedData = streamReader.ReadToEnd();

            response.Close();

            stream.Dispose();

            streamReader.Dispose();
        }

        catch (Exception ex)

        {

            SqlContext.Pipe.Send(ex.Message.ToString());

        }

        returnval = feedData;

    }
};


