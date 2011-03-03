using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using System.IO;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

using Microsoft.Modeling;

namespace imp
{
    /// <summary>
    /// An example model program.
    /// </summary>
    static class sampler
    {
        static int val;
        static String str1 = "ensembldb.ensembl.org";

        [Rule]
        static void setVal(int t)
        {
            
            imp.prj.myAPI.setV(t);
            //val = t;
            //return true;
        }

        [Rule]
        static bool initialize()
        {
            //bool tmp = imp.prj.myAPI.initialize();
            //if (tmp == true) { return true; }
            if (imp.prj.myAPI.initialize())
            {
                
                //MySqlConnection connect = new MySqlConnection("Data Source= 'ensembldb.ensembl.org';Database='aedes_aegypti_core_40_1';User ID='anonymous';Password=''");
               // if (imp.prj.myAPI.sqlcomm())
                //{
                   // if (imp.prj.myAPI.sqltoxml())
                    //{
                        return true;
                
                  //  }
               // }
            }

            return false;
            

           // return true;
        }

      /*  [Rule]
        static ModelMySqlConnection sqlconnect(string x)
        {
            throw new NotImplementedException();
        }*/

        [Rule]
        static bool sqlcomm()
        {
            //imp.prj.myAPI.sqlcomm();
            try
            {
                //imp.prj.myAPI.sqltoxml();
                DataSet tmp = imp.prj.myAPI.getDataSet();
                if (tmp == null) { return false; }

                return true;
            }
            catch (Exception e)
            {
                return true;
            }
        }
        /*[Rule]
        static bool testconnect()
        {
            imp.prj.myAPI.testconnect();
            return true;
        }*/
        [Rule]
        static bool sqltoxml()
        {
            imp.prj.myAPI.sqltoxml();
            return imp.prj.myAPI.testWrite();
        }
    }
}