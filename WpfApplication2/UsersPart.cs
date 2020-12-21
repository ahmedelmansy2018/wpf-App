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

        private void Loginbtn_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {

            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@Name", System.Data.SqlDbType.NVarChar, 50);
            p[0].Value = usernametxt.Text;


            p[1] = new SqlParameter("@Password", System.Data.SqlDbType.NVarChar, 50);
            p[1].Value = Passtxt.Password;


          DataTable dt = DataAccess.ExReader("Login" , p);
           
           
          
            
            if (dt.Rows.Count > 0)
            {
                if (Passtxt.Password == dt.Rows[0]["Password"].ToString())
                {
                    Animate(opened, HomeCN);
                    //opened.Visibility = System.Windows.Visibility.Hidden;
                    //HomeCN.Visibility = System.Windows.Visibility.Visible;
                    //opened = HomeCN;

                    OpenedCanvases.Add(opened);

                }
                else
                {
                    MessageBox.Show("User name or Password incorrect");
                }
            }
            else
            {
                MessageBox.Show("Please Check You Data");
            }




            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //     MessageBox.Show(dt.Rows[i][0].ToString() + " : " + dt.Rows[i][1].ToString());

            //}
            //foreach (DataRow row in dt.Rows)
            //{
            //    MessageBox.Show(row[0].ToString() + " : " + row[1].ToString());
            //}


            //string name="", pass="";
            //while (r.Read())
            //{
            //     name = r[0].ToString();
            //     pass = r[1].ToString();
            //}
          


            //if (Passtxt.Password == pass)
            //{

            //}
            //else
            //{
            //    MessageBox.Show("Incorrect");
            //}
        
        }
    }
}
