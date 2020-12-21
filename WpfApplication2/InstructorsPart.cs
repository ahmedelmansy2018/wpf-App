using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Data;
using WpfApplication2.DA;


namespace WpfApplication2
{
    public partial class MainWindow : Window
    {


        private void SaveInstbtn_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            //SqlParameter[] p = new SqlParameter[1];
            //p[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            //p[0].Value = instnametxt.Text;

            //DataAccess.InsUpDel("AddInstructor", p);

           
            //MessageBox.Show("Success");

            SqlConnection conn = new SqlConnection();
            // conn.ConnectionString = @"Data Source=DESKTOP-SKKR1NP\SQLEXPRESS;Initial Catalog=ItshareCenter;Integrated Security=true";
            conn.ConnectionString = WpfApplication2.Properties.Settings.Default.cnn;

            SqlCommand Selectcmd = new SqlCommand();
            Selectcmd.CommandText = "Select * From Instructors";
            Selectcmd.Connection = conn;



            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "AddInstructor";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = instnametxt.Text;


            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = Selectcmd;
            adapter.InsertCommand = cmd;

            adapter.Fill(ds, "inst");

            SqlCommandBuilder sb = new SqlCommandBuilder(adapter);


          
            DataRow row = ds.Tables["inst"].NewRow();
            row["Name"] = instnametxt.Text;


            ds.Tables["inst"].Rows.Add(row);


            adapter.Update(ds, "inst");

            MessageBox.Show("Done");

         

        }

    }
}
