using SocksNStuff.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SocksNStuff
{
    [DataObject(true)]
    public class CustomerDOC
    {
        public CustomerDOC() { }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataSet GetCustomers()
        {
            string cs = ConfigurationManager.ConnectionStrings["SocksNStuffConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            DataSet ds = new DataSet();
            try
            {

                conn.Open();
                string select = "select * from Customer";
                SqlCommand command = new SqlCommand(select, conn);


                
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                conn.Close();
            }
            catch (Exception ) { 
                conn.Close();
            }
            
            return ds;
        }


    }
}