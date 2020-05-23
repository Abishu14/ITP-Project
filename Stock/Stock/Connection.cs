using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Stock
{
    public class connection
    {

        public static SqlConnection NewCon;
        public static string connetionStr = "Data Source=DESKTOP-NP8RR3O;Initial Catalog=KSL;Integrated Security=True";
        public static SqlConnection Activecon()
        {
            NewCon = new SqlConnection(connetionStr);
            return NewCon;

        }
       // SqlConnection con = new SqlConnection("Data Source=DESKTOP-9VHNMB2;Initial Catalog=KSL;Integrated Security=True");

        //public  static SqlConnection Activecon()
        //{
        //    if (con.State == ConnectionState.Closed)
        //    {
        //        con.Open();

        //    }
        //    return con;
        //}
    //     <connectionStrings>
    //    <add name = "Stock.Properties.Settings.KSLConnectionString" connectionString="Data Source=DESKTOP-NP8RR3O;Initial Catalog=KSL;Integrated Security=True"
    //        providerName="System.Data.SqlClient" />
    //</connectionStrings>

    }
}
