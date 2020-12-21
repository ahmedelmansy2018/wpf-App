using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication2.DA;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Canvas opened = new Canvas();
        List<Canvas> OpenedCanvases = new List<Canvas>();
        public MainWindow()
        {
            InitializeComponent();
            opened = LoginCn;
            OpenedCanvases.Add(opened);
            opened.Visibility = System.Windows.Visibility.Visible;
        }

        private void Canvas_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        Canvas oldc = new Canvas(), newc = new Canvas();
        public void Animate(Canvas oldCanvas , Canvas newCanvas)
        {
            oldc = oldCanvas;
            newc = newCanvas;

            DoubleAnimation da = new DoubleAnimation(1, 0, Duration.Automatic);
            da.Completed += da_Completed;
            oldCanvas.BeginAnimation(Canvas.OpacityProperty, da);


        }

        void da_Completed(object sender, EventArgs e)
        {
            oldc.Visibility = System.Windows.Visibility.Hidden;
            newc.Opacity = 0;

            DoubleAnimation da2 = new DoubleAnimation(0, 1, Duration.Automatic);
            newc.BeginAnimation(Canvas.OpacityProperty, da2);

            newc.Visibility = System.Windows.Visibility.Visible;

            opened = newc;
            OpenedCanvases.Add(opened);

            
        }

        private void homebtn_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            Animate(opened, HomeCN);
        }

        private void CloseBtn_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Are You Sure", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Close();
            }
        }

     

   

     

        

  
     

   
    
       

    

      
       
    }
}
