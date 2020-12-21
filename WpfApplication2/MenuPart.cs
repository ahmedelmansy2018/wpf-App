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
        ItshareDataContext db = new ItshareDataContext();
        private void ViewCategories_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            //var query = from c in db.Categories
            //            //where c.Name.Contains("c#")
            //            orderby c.Name
            //            select c;

            //Categories_List.ItemsSource = query;
            //Categories_List.DisplayMemberPath = "Name";
            //Categories_List.SelectedValuePath = "CategoryID";



            Categories_List.ItemsSource = db.GetAllCategories();
            Categories_List.DisplayMemberPath = "Name";
            Categories_List.SelectedValuePath = "CategoryID";


            Animate(opened, CategoriesCn);
        }

        private void ViewCourses_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            DataTable dt = DataAccess.ExReader("GetAllCategories");
            

            //foreach (DataRow item in dt.Rows)
            //{
            //    TextBlock tx = new TextBlock();
            //    tx.Width = 130;
            //    tx.Text = item["Name"].ToString();
            //    tx.Tag = item["CategoryID"];

            //    CategoriesList.Items.Add(tx);
            //}
            CategoriesList.ItemsSource = dt.DefaultView;
            CategoriesList.SelectedValuePath = dt.Columns["CategoryID"].ToString();
            CategoriesList.DisplayMemberPath = dt.Columns["Name"].ToString();
            Animate(opened, CoursesCn);
        }

        private void ViewInstructors_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            Animate(opened, InstructorsCn);
        }

        private void ViewStudents_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
