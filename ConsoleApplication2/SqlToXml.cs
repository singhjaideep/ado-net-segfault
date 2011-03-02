//Reading from a Table into an XML file
//Jaideep Singh

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


namespace SQLtoXML
{
    class Program
    {
        static void Main(string[] args)
        {
            String host = "ensembldb.ensembl.org";
            String database = "aedes_aegypti_core_40_1";
            String user = "anonymous";
            String password = "";
            String str1 = "Data Source=" + host + ";Database=" + database + ";User ID=" + user + ";Password=" + password;
            //String str1 = "Data Source=web.ankitbuti.com; Initial Catalog=Northwind;Persist Security Info=True;User ID=segfault;Password=jd";
            String str2 = "SELECT analysis_id FROM analysis";
            String str3 = "Order.xml";
            if (imp.myAPI.go(str1, str2, str3))
            {
                Console.WriteLine("Done!");
                Console.ReadKey();
            }

        }
    }
}
