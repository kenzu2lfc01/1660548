using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Eight_Puzzle
{
    /// <summary>
    /// Interaction logic for tutorial.xaml
    /// </summary>
    public partial class tutorial : Window
    {
        public tutorial()
        {
            InitializeComponent();
        }
        int dem = 0;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var image = new BitmapImage(new Uri("/Icons/step1.jpg", UriKind.Relative));
            imgTutorial.Source = image;
            if (dem == 0)
            {
                btnLeft.IsEnabled = false;
            }
        }

        private void BtnRight_Click(object sender, RoutedEventArgs e)
        {
            dem++;
            if (dem == 1)
            {
                var image = new BitmapImage(new Uri("/Icons/step2.jpg", UriKind.Relative));
                imgTutorial.Source = image;
                btnLeft.IsEnabled = true;
            }
            else if(dem == 2)
            {
                var image = new BitmapImage(new Uri("/Icons/step3.jpg", UriKind.Relative));
                imgTutorial.Source = image;
            }
            else if (dem == 3)
            {
                var image = new BitmapImage(new Uri("/Icons/step4.jpg", UriKind.Relative));
                imgTutorial.Source = image;
            }
            else if (dem == 4)
            {
                var image = new BitmapImage(new Uri("/Icons/step5.jpg", UriKind.Relative));
                imgTutorial.Source = image;
                btnRight.IsEnabled = false;
            }

        }

        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {
            dem--;
            if (dem == 1)
            {
                var image = new BitmapImage(new Uri("/Icons/step2.jpg", UriKind.Relative));
                imgTutorial.Source = image;
                btnLeft.IsEnabled = true;
            }
            else if (dem == 2)
            {
                var image = new BitmapImage(new Uri("/Icons/step3.jpg", UriKind.Relative));
                imgTutorial.Source = image;
            }
            else if (dem == 3)
            {
                var image = new BitmapImage(new Uri("/Icons/step4.jpg", UriKind.Relative));
                imgTutorial.Source = image;
            }
            else if (dem == 4)
            {
                var image = new BitmapImage(new Uri("/Icons/step5.jpg", UriKind.Relative));
                imgTutorial.Source = image;
            }
            else
            {
                var image = new BitmapImage(new Uri("/Icons/step1.jpg", UriKind.Relative));
                imgTutorial.Source = image;
                btnLeft.IsEnabled = false;
            }
        }
    }
}
