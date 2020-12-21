using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WpfApplication2.DA
{
    class DataAccess
    {
        public static DataTable ExReader(string sqlcmd, SqlParameter[] p = null)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = WpfApplication2.Properties.Settings.Default.cnn;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlcmd;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = connection;

            if(p!=null)
            {
                for (int i = 0; i < p.Length; i++)
                {
                    cmd.Parameters.Add(p[i]);
                }
            
            }

            connection.Open();

            SqlDataReader r = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(r);

            connection.Close();

            return dt;
        }



        public static void InsUpDel(string sqlcmd, SqlParameter[] p = null)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = WpfApplication2.Properties.Settings.Default.cnn;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlcmd;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = connection;

            if (p != null)
            {
                for (int i = 0; i < p.Length; i++)
                {
                    cmd.Parameters.Add(p[i]);
                }

            }

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }


        public static string ExScalar(string sqlcmd, SqlParameter[] p)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = WpfApplication2.Properties.Settings.Default.cnn;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlcmd;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = connection;

            if (p != null)
            {
                for (int i = 0; i < p.Length; i++)
                {
                    cmd.Parameters.Add(p[i]);
                }

            }

            connection.Open();

            string result = cmd.ExecuteScalar().ToString();

      
            connection.Close();

            return result;
        }
    }
}
