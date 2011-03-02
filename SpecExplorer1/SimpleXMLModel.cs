using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;
using Microsoft.Modeling;

namespace SpecExplorer1
{
    
    static class SimpleXMLModel
    {
        //[TypeBinding("SpecExplorer1")]
        static int accumulator;

        /// <summary>
        /// 3317
        /// </summary>

        static String connectionStr;
        static String queryString;
        static String file;

        static SqlConnection connection;
        static SqlCommand command;
        static SqlDataAdapter myDataAdapter;
        static DataSet myDataSet;

        //[Rule(Action = "myAPI.sqlconnect()")]
        static SqlConnection sqlconnect(string x)
        {
            connection
        }

        /// <summary>
        /// Method PerformStep contains the rule to start the query
        /// This should be done asyncronously
        /// </summary>
        //[Rule(Action = "this.writetoxml()")]
       

    }
}
