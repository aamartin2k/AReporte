using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace AReport.DAL.SQL
{
    class Connection
    {
        private static string _connectionString = @"Data Source=APP;Initial Catalog=relojapp;Integrated Security=True";
        //private static string _connectionString = @"Data Source=localhost;Initial Catalog=relojapp;Integrated Security=True";


        public static string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        } 
        public static System.Data.IDbConnection GetConnection()
        {
            // update to get your connection here

            IDbConnection connection = new SqlConnection(ConnectionString);
            return connection;
        }
    }
}
