using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;

/// <summary>
/// Input: Connection String and Query
/// Output: specified XML file.
/// </summary>
namespace imp
{
    public static class myAPI
    {
        //
        // TODO: Add constructor logic here
        //

        static String connectionStr;
        static String queryString;
        static String file;

        static SqlConnection connection;
        static SqlCommand command;
        static SqlDataAdapter myDataAdapter;
        static DataSet myDataSet;


        public static bool go(String con, String query, String f)
        {
            while (initialize(con, query, f) == false) ;
            connection = sqlconnect(connectionStr);
            sqlcomm(queryString);
            sqltoxml();
            return true;
        }

        private static bool initialize(String con, String query, String f)
        {
            connectionStr = con;
            queryString = query;
            file = f;
            connection = null;
            command = null;
            myDataAdapter = null;
            myDataSet = null;
            return true;
        }

        private static SqlConnection sqlconnect(string x)
        {
            SqlConnection connection = new SqlConnection(x);
            return connection;
        }

        private static void sqlcomm(String queryString)
        {
            command = new SqlCommand(queryString, connection);
            myDataAdapter = new SqlDataAdapter(command);
            myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet);
        }

        private static void sqltoxml()
        {
            try
            {
                myDataSet.WriteXml(file);
            }
            catch (NullReferenceException e)
            {

            }
        }
    }
}