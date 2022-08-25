using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
namespace DemoDotNet.Webform.Models.Db
{
    public class ConnectDB
    {
        MySqlConnection conn =null;
        public ConnectDB()
        {
            conn = new MySqlConnection("server=localhost; user id=root;database=demodotnet");
        }
        public DataTable GetData(string sql)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int Execute(string sql, MySqlParameter[] parameters = null)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            if (parameters!=null)
                foreach (var param in parameters)
                    cmd.Parameters.Add(param);
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }
    }
}