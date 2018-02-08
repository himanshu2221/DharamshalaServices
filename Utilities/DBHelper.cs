using DharamshalaServices.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DharamshalaServices.Utilities
{
    public class DBHelper : IDisposable
    {
        public DBHelper() {
            conn = new MySqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DharamshalaDB_ConnectionString"].ConnectionString;
            conn.Open();
        }

        public void Dispose()
        {
            if(conn != null)
            {
                conn.Close();
                conn = null;
            }
        }

        MySqlConnection conn;

        public MySqlDataReader Select(string sql)
        {
            MySqlDataReader reader = null;
            try
            {
                using (MySqlCommand command = new MySqlCommand(sql, conn))
                {
                    reader = command.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
            return reader;
        }

        public int Insert(string sql)
        {
            int newRecordId;
            try
            {
                using (MySqlCommand command = new MySqlCommand(sql, conn))
                {
                    command.ExecuteNonQuery();
                    newRecordId = (int)command.LastInsertedId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
            return newRecordId;
        }
    }
}