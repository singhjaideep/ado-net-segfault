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
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SqlConnection connection = new SqlConnection("Data Source=web.ankitbuti.com; Initial Catalog=Northwind;Persist Security Info=True;User ID=segfault;Password=jd");
            SqlCommand command = new SqlCommand("SELECT * FROM [Order Details]", connection);
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(command);
            Console.WriteLine("Importing...\n");
            DataSet myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet);
            myDataSet.WriteXml("Order.xml");
            Console.WriteLine("Done!\n");
            Console.ReadKey();
        }
    }
}
