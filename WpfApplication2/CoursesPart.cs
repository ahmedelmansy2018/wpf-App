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
using System.Windows.Controls;

namespace WpfApplication2
{
    public partial class MainWindow : Window
    {
        private void SaveCourse_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            if (CourseNametxt.Tag == null)
            {

                if (CourseNametxt.Text == "")
                {
                    MessageBox.Show("Course Name Required");
                    CourseNametxt.Focus();
                }

                else if (Pricetxt.Text == "")
                {
                    MessageBox.Show("Price Required");
                    Pricetxt.Focus();
                }
                else if (decimal.Parse(Pricetxt.Text) < 100 || decimal.Parse(Pricetxt.Text) > 5000)
                {
                    MessageBox.Show("Price must be between 100 and 5000");
                    Pricetxt.Focus();
                    Pricetxt.SelectAll();
                }
                else if (PeriodTxt.Text == "")
                {
                    MessageBox.Show("Period Name Required");
                    PeriodTxt.Focus();
                }
                else if (CategoriesList.SelectedIndex == -1)
                {
                    MessageBox.Show("Select Category");
                    CategoriesList.Focus();
                }
                else
                {

                    SqlParameter[] p = new SqlParameter[5];
                    p[0] = new SqlParameter("@Title", SqlDbType.NVarChar, 50);
                    p[0].Value = CourseNametxt.Text;


                    p[1] = new SqlParameter("@Price", SqlDbType.Float);
                    p[1].Value = float.Parse(Pricetxt.Text);

                    p[2] = new SqlParameter("@Period", SqlDbType.NVarChar, 50);
                    p[2].Value = PeriodTxt.Text;

                    p[3] = new SqlParameter("@CategoryID", SqlDbType.Int);
                    p[3].Value = int.Parse(CategoriesList.SelectedValue.ToString());

                    p[4] = new SqlParameter("@Description", SqlDbType.NVarChar, 50);
                    p[4].Value = Descriptiontxt.Text;


                    DataAccess.InsUpDel("InsertCourse", p);

                    MessageBox.Show("Added");



                    CourseNametxt.Text = string.Empty;
                    Pricetxt.Text = "";
                    PeriodTxt.Text = "";
                    CategoriesList.SelectedIndex = -1;
                    Descriptiontxt.Text = "";

                    CourseNametxt.Focus();
                }
            }
            else {
                SqlParameter[] p = new SqlParameter[6];

                p[0] = new SqlParameter("@CourseID", SqlDbType .Int);
                p[0].Value = int.Parse(CourseNametxt.Tag.ToString());

                p[1] = new SqlParameter("@Title", SqlDbType.NVarChar, 50);
                p[1].Value = CourseNametxt.Text;


                p[2] = new SqlParameter("@Price", SqlDbType.Float);
                p[2].Value = float.Parse(Pricetxt.Text);

                p[3] = new SqlParameter("@Period", SqlDbType.NVarChar, 50);
                p[3].Value = PeriodTxt.Text;

                p[4] = new SqlParameter("@CategoryID", SqlDbType.Int);
                p[4].Value = int.Parse(CategoriesList.SelectedValue.ToString());

                p[5] = new SqlParameter("@Description", SqlDbType.NVarChar, 50);
                p[5].Value = Descriptiontxt.Text;


                DataAccess.InsUpDel("EditCourse", p);

                MessageBox.Show("Edited");

            
            }

        }


        private void CourseNametxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            CourseNametxt.Tag = null;

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@KeyWord", SqlDbType.NVarChar, 50);
            p[0].Value = CourseNametxt.Text;

            DataTable dt =DataAccess.ExReader("SearchCourse", p);

            if (dt.Rows.Count > 0)
            {
                CoursesList.Items.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    TextBlock Course_tx = new TextBlock();
                    Course_tx.Width = 147;

                    Course_tx.Text = item["Title"].ToString();
                    Course_tx.Tag = item["CourseID"];
                    Course_tx.MouseLeftButtonUp += Course_tx_MouseLeftButtonUp;

                    CoursesList.Items.Add(Course_tx);

                    CoursesList.Visibility = System.Windows.Visibility.Visible;
                }
            }

            else
            {
                CoursesList.Items.Clear();
                CoursesList.Visibility = System.Windows.Visibility.Hidden;
               
                Pricetxt.Text = "";
                PeriodTxt.Text = "";
                CategoriesList.SelectedIndex = -1;
                Descriptiontxt.Text = "";
            }
        }

        void Course_tx_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock tx =(TextBlock) sender;
            int courseID = int.Parse(tx.Tag.ToString());

            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@CourseID", SqlDbType.Int);
            p[0].Value = courseID;

            DataTable dt = DataAccess.ExReader("GetCourseData", p);

           
            CourseNametxt.Text = dt.Rows[0]["Title"].ToString();
            CourseNametxt.Tag = courseID;
            Pricetxt.Text = dt.Rows[0]["Price"].ToString();
            PeriodTxt.Text = dt.Rows[0]["Period"].ToString();
            Descriptiontxt.Text = dt.Rows[0]["Description"].ToString();

            CategoriesList.SelectedValue = dt.Rows[0]["CategoryID"];

            CoursesList.Items.Clear();
            CoursesList.Visibility = System.Windows.Visibility.Hidden;

         
        }


        private void CourseNametxt_KeyUp_1(object sender, KeyEventArgs e)
        {

            switch(e.Key)
            {
                case Key.Up:
                    if(CoursesList.SelectedIndex>0)
                    CoursesList.SelectedIndex--;
                    break;

                case Key.Down :
                    CoursesList.SelectedIndex++;
                    break;

                case Key.Enter:
                    Course_tx_MouseLeftButtonUp(CoursesList.SelectedItem, null); 
                    break;


                default : 
                    break;

            }
       

        }

    




    }
}
