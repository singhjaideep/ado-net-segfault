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

using Microsoft.Modeling;

/// <summary>
/// Input: Connection String and Query
/// Output: specified XML file.
/// </summary>
namespace imp.prj
{
    public static class myAPI
    {
        //
        // TODO: Add constructor logic here
        //

        static String connectionStr;
        static String queryString;
        static String file;
        static int errorFlag = 0;
        static int type = 0;
        static MySqlConnection connection;
        static MySqlCommand command;
        static MySqlDataAdapter myDataAdapter;
        static DataSet myDataSet, readDataSet;
        static String query;
        static int flag2;
        static int connectflag=0;

        public static bool testconnect()
        {
           // if (connectflag == 0)
           // {
                connection = new MySqlConnection("Data Source= 'ensembldb.ensembl.org';Database='aedes_aegypti_core_40_1';User ID='anonymous';Password=''");
           // }
                return true;
        }

        public static void setV(int t)
        {
            type = t;
            //return true;
        }
        public static bool go()
        {
            /*String host = "ensembldb.ensembl.org";
            String database = "aedes_aegypti_core_40_1";
            String user = "anonymous";
            String password = "";
            String con = "Data Source=" + host + ";Database=" + database + ";User ID=" + user + ";Password=" + password;
            //String str1 = "Data Source=web.ankitbuti.com; Initial Catalog=Northwind;Persist Security Info=True;User ID=segfault;Password=jd";
            String query = "SELECT analysis_id FROM analysis";
            String f = "Order.xml";
            /*int flag = 0;
            while (initialize(con, query, f) == false && flag < 5)
            {
                flag++;
            }
            try
            {
                connection = new MySqlConnection(connectionStr);
            }
            catch (Exception e)
            {
              //  errorReport();
                return false;*/
            //return true;
            //}
           // sqlcomm(queryString);
           //// sqltoxml();
           // updateData();
           // sqltoxml();
            return true;
        }
       
        public static bool initialize()
        {
            
            String host = "ensembldb.ensembl.org";
            String database = "aedes_aegypti_core_40_1";
            String user = "anonymous";
            String password = "";
            String con = "Data Source=" + host + ";Database=" + database + ";User ID=" + user + ";Password=" + password;
            //String str1 = "Data Source=web.ankitbuti.com; Initial Catalog=Northwind;Persist Security Info=True;User ID=segfault;Password=jd";
            query = "SELECT analysis_id FROM analysis";
            String f = "Order.xml";
            //testconnect();
            int initflag = 0;
            try
            {
                connectionStr = con;
                queryString = query;
                file = f;
                //connection = null;
                command = null;
                myDataAdapter = null;
                myDataSet = null;
                initflag = 1;
                //connection = sqlcomm();
               // sqlcomm();
                //Console.WriteLine("pass"); Console.ReadKey(); 
                return true;
            }
            catch (Exception e)
            {
                //errorReport();
                //Console.WriteLine("fail"); Console.ReadKey(); 
                return false;
            }
        }

        public static DataSet getDataSet()
        {
            try
            {
                if (!myDataSet.Equals(null))
                {
                    return myDataSet;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
            //return myDataSet;
        }
        public static bool sqlcomm()
        {
            DataSet nullSet = null;
            //DataSet tmpSet;
            String queryString = query;
            try
            {
              //  if (connectflag == 0)
              //  { //connection = new MySqlConnection("Data Source= ensembldb.ensembl.org;Database=aedes_aegypti_core_40_1;User ID=anonymous;Password=");
                    command = new MySqlCommand(queryString, connection);
                    myDataAdapter = new MySqlDataAdapter(command);
                    myDataSet = new DataSet();
                    myDataAdapter.Fill(myDataSet);
                    connectflag = 1;
               // }

                return true;
            }
            catch (Exception e)
            {
                myDataSet = null;
                //errorReport();
                return false;
            }
        }
        
      
        public static bool updateData()
        {
            int j = 0;

            for (int i = 10; i >= 0; i--)
            {
                myDataSet.Tables[0].Rows[j]["analysis_id"] = i;
                j++;
            }
            return true;
        }

       
        public static bool sqltoxml()
        {
            try
            {
                if (type == 1)
                {
                    myDataSet.WriteXml(file, XmlWriteMode.DiffGram);
                }
                else if (type == 2)
                {
                    myDataSet.WriteXml(file, XmlWriteMode.IgnoreSchema);
                }
                else if (type == 3)
                {
                    myDataSet.WriteXml(file, XmlWriteMode.WriteSchema);
                }
                else
                {
                    type = 3;
                    myDataSet.WriteXml(file, XmlWriteMode.WriteSchema);
                }
                //connection.Clone();
                return true;
            }
            catch (NullReferenceException e)
            {
                //errorReport();
                //connection.Clone();
                return false;
            }
        }
       
        public static void errorReport()
        {
            errorFlag = 1;
        }

        public static bool testWrite()
        {
            try
            {

                if (type == 1)
                {
                    readDataSet.ReadXml(file, XmlReadMode.DiffGram);
                    // myDataSet.WriteXml(file);
                }
                else if (type == 2)
                {
                    readDataSet.ReadXml(file, XmlReadMode.IgnoreSchema);
                    //myDataSet.WriteXml(file);
                }
                else if (type == 3)
                {
                    readDataSet.ReadXml(file, XmlReadMode.ReadSchema);
                    //myDataSet.WriteXml(file);
                }
                else
                {
                    readDataSet.ReadXml(file);
                }
                //return true;
            }
            catch(Exception e)
            {
                return false;
            }
            /*if (readDataSet.Equals(myDataSet))
            {
                return true;
            }
            return false;
            try
            {
                myAPI.updateData();
            }
            catch (Exception e)
            {
                return false;
            }
            sqltoxml();
            */
            return true;
            
        }
        
       /*

        [Rule(Action = "initialize(con, query, f)/result")]
        static bool initialize1(string con, string query, string f)
        {
            throw new NotImplementedException();
        }

        [Rule(Action = "sqlconnect(x)/result")]
        static ModelMySqlConnection sqlconnect(string x)
        {
            throw new NotImplementedException();
        }

        [Rule(Action = "sqlcomm(queryString)")]
        static void sqlcomm1(string queryString)
        {
            throw new NotImplementedException();
        }

        [Rule(Action = "sqltoxml()")]
        static void sqltoxml1()
        {
            throw new NotImplementedException();
        }
        * */
    }

     
}
