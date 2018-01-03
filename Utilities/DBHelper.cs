using DharamshalaServices.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DharamshalaServices.Utilities
{
    public class DBHelper
    {
        private DBHelper() { }

        public static readonly DBHelper Instance = new DBHelper();

        public string Insert(string  sql)
        {
            string error = string.Empty;
            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DharamshalaDB_ConnectionString"].ConnectionString;
                try
                {
                    conn.Open();
                    using (MySqlCommand command = new MySqlCommand(sql, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    error = ex.Message + ex.StackTrace;
                }
                finally
                {
                    conn.Close();
                }
            }
            return error;
        }
    }
}