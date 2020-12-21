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
       
        private void SaveCategory_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            //SqlParameter[] p = new SqlParameter[1];
            //p[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            //p[0].Value = CategoryNametxt.Text;
            //DataAccess.InsUpDel("AddCategory", p);
            //MessageBox.Show("Category Added Successfully!");


            ////Category c = new Category();
            ////c.Name = CategoryNametxt.Text;
            ////c.Created_at = DateTime.Now;
           
            ////db.Categories.InsertOnSubmit(c);
            ////db.SubmitChanges();
            //MessageBox.Show("Category Added Successfully!");


            db.AddCategory(CategoryNametxt.Text);
            MessageBox.Show("Category Added Successfully!");


           

        }


        private void UpdateCategory_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
                var category = from c in db.Categories
                               where c.CategoryID == 9
                               select c;


                category.SingleOrDefault().Name = "Updated Category";
                db.SubmitChanges();
            MessageBox.Show("Category Updated Successfully!");


          
        }


        private void DelCat_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            var category = from c in db.Categories
                           where c.CategoryID == 9
                           select c;

            db.Categories.DeleteOnSubmit(category.SingleOrDefault());
            db.SubmitChanges();
            MessageBox.Show("Category Deleted Successfully!");


        }

    }
}
