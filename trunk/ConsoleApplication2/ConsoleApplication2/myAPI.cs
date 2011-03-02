using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

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

        static MySqlConnection connection;
        static MySqlCommand command;
        static MySqlDataAdapter myDataAdapter;
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

        private static MySqlConnection sqlconnect(string x)
        {
            MySqlConnection connection = new MySqlConnection(x);
            return connection;
        }

        private static void sqlcomm(String queryString)
        {
            command = new MySqlCommand(queryString, connection);
            myDataAdapter = new MySqlDataAdapter(command);
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