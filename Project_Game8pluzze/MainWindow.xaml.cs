using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Configuration;
using System.IO;

namespace Eight_Puzzle
{
    public partial class MainWindow : Window
    {
        public bool _isopen { get; set; } = false;
        public string ImageDir { get; set; } = "";
        List<Image> images;
        List<Image> imagesRandom;
        public int minutes { get; set; } = 3;
        public int seconds { get; set; } = 0;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            string exePath = AppDomain.CurrentDomain.BaseDirectory;
            string background = System.IO.Path.Combine(exePath, "wood_background.jpg");
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri(background, UriKind.Absolute));
            this.Background = myBrush;
            board.Visibility = Visibility.Hidden;
            moveGroupBox.Visibility = Visibility.Hidden;
            originalImage.Visibility = Visibility.Hidden;
            TextBlockTime.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string lastfile = ConfigurationManager.AppSettings["last_filename"];
            StreamReader sr;
            try
            {
                images = new List<Image>();
                sr = new StreamReader("save.dat");
                ImageDir = sr.ReadLine();
                var image = new BitmapImage(new Uri(ImageDir));
                //Cắt hình 

                //Thêm hình vào mảng random

            }
            catch (Exception)
            {
                //Không có file save.dat
            }

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            string phut = $"0{minutes}", giay = "";
            if (seconds == 0)
            {
                seconds = 60;
                minutes--;
                if (minutes < 10) phut = "0" + minutes.ToString();
                else phut = minutes.ToString();
            }
            seconds--;
            if (seconds < 10)
                giay = "0" + seconds.ToString();
            else giay = seconds.ToString();

            TextBlockTime.Text = phut + ":" + giay;

            if (minutes == 0 && seconds == 0)
            {
                MessageBox.Show("You lose");
                dispatcherTimer.Stop();
                this.Close();
                
                //Kết thúc trò chơi.
            }
        }

        private void BtnExpander_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (!_isopen)
            {
                btn.ContextMenu.IsEnabled = true;
                btn.ContextMenu.PlacementTarget = btn;
                btn.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                btn.ContextMenu.IsOpen = true;
                _isopen = true;
            }
            else
            {
                btn.ContextMenu.IsOpen = false;
                _isopen = false;
            }
        }

        public void SaveConfig(string key, string value)
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            var writer = new StreamWriter("save.dat");
            SaveConfig("last_filename", ImageDir);
            writer.WriteLine(minutes);
            writer.WriteLine(seconds);
            int length = imagesRandom.Count - 1;
            for (int i = 0; i < length; i++)
                writer.WriteLine(imagesRandom[i].Tag.ToString());
            writer.Write(imagesRandom[length].Tag.ToString());
            writer.Close();
            var ask = MessageBox.Show("Game đã lưu.Bạn có muốn chơi tiếp ?", "Thông báo lưu", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (ask == MessageBoxResult.No)
            {
                this.Close();
            }
            else
            {
                dispatcherTimer.Start();
            }
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            tutorial frm = new tutorial();
            frm.Show();
        }

        private void MiNewGame_Click(object sender, RoutedEventArgs e)
        {
            string exePath = AppDomain.CurrentDomain.BaseDirectory;
            OpenFileDialog file = new OpenFileDialog
            {
                Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png|All file(*.*) | *.*"
            };
            if (file.ShowDialog() == true)
            {
                ImageDir = file.FileName;
                SaveConfig("last_filename", ImageDir);
                images = new List<Image>();
                imagesRandom = new List<Image>();
                var image = new BitmapImage(new Uri(file.FileName));

                var width = image.PixelWidth / 3;
                var height = image.PixelHeight / 3;

                var imgHeight = 100 * height / width;
                for (var i = 0; i < 3; i++)
                {
                    for (var j = 0; j < 3; j++)
                    {
                        var cropped = new CroppedBitmap(image,
                            new Int32Rect(width * j, height * i, width, height));
                        var img = new Image();
                        img.Source = cropped;
                        img.Width = 100;
                        img.Height = 100;
                        img.Tag = i * 3 + j * 1;
                        images.Add(img);
                    }
                }

                var ra = new Random();
                var indences = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };

                for (var i = 0; i < 8; i++)
                {

                    var ra1_indences = ra.Next(indences.Count);
                    var ra1 = indences[ra1_indences];
                    indences.RemoveAt(ra1_indences);
                    imagesRandom.Add(images[ra1]);
                }
                images[8].Tag = 8;
                imagesRandom.Add(images[8]);
                img1.Source = imagesRandom[0].Source;
                img2.Source = imagesRandom[1].Source;
                img3.Source = imagesRandom[2].Source;
                img4.Source = imagesRandom[3].Source;
                img5.Source = imagesRandom[4].Source;
                img6.Source = imagesRandom[5].Source;
                img7.Source = imagesRandom[6].Source;
                img8.Source = imagesRandom[7].Source;
                originalImage.Source = image;
                board.Visibility = Visibility.Visible;
                moveGroupBox.Visibility = Visibility.Visible;
                originalImage.Visibility = Visibility.Visible;
                TextBlockTime.Visibility = Visibility.Visible;
                miRestart.IsEnabled = true;
                miRestart.Foreground = Brushes.Purple;
                miPause.IsEnabled = true;
                miPause.Foreground = Brushes.Purple;
                loadGame.IsEnabled = true;
                loadGame.Foreground = Brushes.Purple;
                dispatcherTimer.Start();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn hình",
                "Thông tin", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            _isopen = false;//Đóng dropdown button
        }

        private void MiRestart_Click(object sender, RoutedEventArgs e)
        {
            _isopen = false;//Đóng dropdown button

            images = new List<Image>();
            imagesRandom = new List<Image>();
            var image = new BitmapImage(new Uri(ImageDir));

            var width = image.PixelWidth / 3;
            var height = image.PixelHeight / 3;

            var imgHeight = 100 * height / width;
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var cropped = new CroppedBitmap(image,
                        new Int32Rect(width * j, height * i, width, height));
                    var img = new Image();
                    img.Source = cropped;
                    img.Width = 100;
                    img.Height = 100;
                    img.Tag = i * 3 + j * 1;
                    images.Add(img);

                }
            }

            var ra = new Random();
            var indences = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };

            for (var i = 0; i < 8; i++)
            {

                var ra1_indences = ra.Next(indences.Count);
                var ra1 = indences[ra1_indences];
                indences.RemoveAt(ra1_indences);
                imagesRandom.Add(images[ra1]);
            }
            images[8].Tag = 8;
            imagesRandom.Add(images[8]);
            img1.Source = imagesRandom[0].Source;
            img2.Source = imagesRandom[1].Source;
            img3.Source = imagesRandom[2].Source;
            img4.Source = imagesRandom[3].Source;
            img5.Source = imagesRandom[4].Source;
            img6.Source = imagesRandom[5].Source;
            img7.Source = imagesRandom[6].Source;
            img8.Source = imagesRandom[7].Source;
            originalImage.Source = image;

            board.Visibility = Visibility.Visible;
            moveGroupBox.Visibility = Visibility.Visible;
            originalImage.Visibility = Visibility.Visible;
            TextBlockTime.Visibility = Visibility.Visible;
            minutes = 3;
            seconds = 1;
            miPause.IsEnabled = true;
            miContinue.IsEnabled = false;
            miPause.Foreground = Brushes.Purple;
            miContinue.Foreground = Brushes.Thistle;
            dispatcherTimer.Start();
        }

        private void MiPause_Click(object sender, RoutedEventArgs e)
        {
            miPause.IsEnabled = false;
            miPause.Foreground = Brushes.Thistle;
            miContinue.IsEnabled = true;
            miContinue.Foreground = Brushes.Purple;
            //Thời gian dừng lại
            dispatcherTimer.Stop();
            board.IsEnabled = false;
            moveGroupBox.IsEnabled = false;
            _isopen = false;//Đóng dropdown button
        }

        private void MiContinue_Click(object sender, RoutedEventArgs e)
        {
            miContinue.IsEnabled = false;
            miContinue.Foreground = Brushes.Thistle;
            miPause.IsEnabled = true;
            miPause.Foreground = Brushes.Purple;

            //Thời gian tiếp tục
            dispatcherTimer.Start();
            board.IsEnabled = true;
            moveGroupBox.IsEnabled = true;
            _isopen = false;//Đóng dropdown button
        }

        //bool isDragging = false;
        //Point lastPos;
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //HitTest
           

        }

        //private bool hitTest(Image myCropped, Point point)
        //{
        //    int w = (int)myCropped.Width;
        //    int h = (int)myCropped.Height;
        //    var oldLeft = Canvas.GetLeft(myCropped);
        //    var oldTop = Canvas.GetTop(myCropped);
        //    if ((oldLeft <= point.X && point.X <= oldLeft + w) &&
        //        (oldTop <= point.Y && point.Y <= oldTop + h))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void MoveUp_Click(object sender, RoutedEventArgs e)
        {
            if (image1.Background.ToString() == "#FFFFFFFF")
            {
                img1.Source = img4.Source;
                img4.Source = null;
                image1.Background = Brushes.Gray;
                image4.Background = Brushes.White;
                var tag = imagesRandom[0].Tag;
                imagesRandom[0].Tag = imagesRandom[3].Tag;
                imagesRandom[3].Tag = tag;
            }
            else if (image2.Background.ToString() == "#FFFFFFFF")
            {
                img2.Source = img5.Source;
                img5.Source = null;
                image2.Background = Brushes.Gray;
                image5.Background = Brushes.White;
                var tag = imagesRandom[1].Tag;
                imagesRandom[1].Tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = tag;
            }
            else if (image3.Background.ToString() == "#FFFFFFFF")
            {
                img3.Source = img6.Source;
                img6.Source = null;
                image3.Background = Brushes.Gray;
                image6.Background = Brushes.White;
                var tag = imagesRandom[2].Tag;
                imagesRandom[2].Tag = imagesRandom[5].Tag;
                imagesRandom[5].Tag = tag;
            }
            else if (image4.Background.ToString() == "#FFFFFFFF")
            {
                img4.Source = img7.Source;
                img7.Source = null;
                image4.Background = Brushes.Gray;
                image7.Background = Brushes.White;
                var tag = imagesRandom[3].Tag;
                imagesRandom[3].Tag = imagesRandom[6].Tag;
                imagesRandom[6].Tag = tag;
            }
            else if (image5.Background.ToString() == "#FFFFFFFF")
            {
                img5.Source = img8.Source;
                img8.Source = null;
                image5.Background = Brushes.Gray;
                image8.Background = Brushes.White;
                var tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = imagesRandom[7].Tag;
                imagesRandom[7].Tag = tag;
            }

            else if (image6.Background.ToString() == "#FFFFFFFF")
            {
                img6.Source = img9.Source;
                img9.Source = null;
                image6.Background = Brushes.Gray;
                image9.Background = Brushes.White;
                var tag = imagesRandom[5].Tag;
                imagesRandom[5].Tag = imagesRandom[8].Tag;
                imagesRandom[8].Tag = tag;
            }
            string chuoi_ran = "";
            for (int i = 0; i < imagesRandom.Count; i++)
            {
                chuoi_ran += imagesRandom[i].Tag.ToString();
            }
            if (String.Compare(chuoi_ran, "012345678") == 0)
            {
                MessageBox.Show("I am win");
                this.Close();
            }
        }

        private void MoveDown_Click(object sender, RoutedEventArgs e)
        {
            if (image7.Background.ToString() == "#FFFFFFFF")
            {
                img7.Source = img4.Source;
                img4.Source = null;
                image7.Background = Brushes.Gray;
                image4.Background = Brushes.White;
                var tag = imagesRandom[6].Tag;
                imagesRandom[6].Tag = imagesRandom[3].Tag;
                imagesRandom[3].Tag = tag;
            }
            else if (image8.Background.ToString() == "#FFFFFFFF")
            {
                img8.Source = img5.Source;
                img5.Source = null;
                image8.Background = Brushes.Gray;
                image5.Background = Brushes.White;
                var tag = imagesRandom[7].Tag;
                imagesRandom[7].Tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = tag;
            }
            else if (image9.Background.ToString() == "#FFFFFFFF")
            {
                img9.Source = img6.Source;
                img6.Source = null;
                image9.Background = Brushes.Gray;
                image6.Background = Brushes.White;
                var tag = imagesRandom[8].Tag;
                imagesRandom[8].Tag = imagesRandom[5].Tag;
                imagesRandom[5].Tag = tag;
            }
            else if (image4.Background.ToString() == "#FFFFFFFF")
            {
                img4.Source = img1.Source;
                img1.Source = null;
                image4.Background = Brushes.Gray;
                image1.Background = Brushes.White;
                var tag = imagesRandom[1].Tag;
                imagesRandom[1].Tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = tag;
            }
            else if (image5.Background.ToString() == "#FFFFFFFF")
            {
                img5.Source = img2.Source;
                img2.Source = null;
                image5.Background = Brushes.Gray;
                image2.Background = Brushes.White;
                var tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = imagesRandom[1].Tag;
                imagesRandom[1].Tag = tag;
            }
            else if (image6.Background.ToString() == "#FFFFFFFF")
            {

                img6.Source = img3.Source;
                img3.Source = null;
                image6.Background = Brushes.Gray;
                image3.Background = Brushes.White;
                var tag = imagesRandom[5].Tag;
                imagesRandom[5].Tag = imagesRandom[2].Tag;
                imagesRandom[2].Tag = tag;
            }
            else if (image7.Background.ToString() == "#FFFFFFFF")
            {
                img7.Source = img4.Source;
                img4.Source = null;
                image7.Background = Brushes.Gray;
                image4.Background = Brushes.White;
                var tag = imagesRandom[6].Tag;
                imagesRandom[6].Tag = imagesRandom[3].Tag;
                imagesRandom[3].Tag = tag;
            }
            else if (image8.Background.ToString() == "#FFFFFFFF")
            {
                img8.Source = img5.Source;
                img5.Source = null;
                image8.Background = Brushes.Gray;
                image5.Background = Brushes.White;
                var tag = imagesRandom[7].Tag;
                imagesRandom[7].Tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = tag;
            }
            else if (image9.Background.ToString() == "#FFFFFFFF")
            {
                img9.Source = img6.Source;
                img6.Source = null;
                image9.Background = Brushes.Gray;
                image6.Background = Brushes.White;
                var tag = imagesRandom[8].Tag;
                imagesRandom[8].Tag = imagesRandom[5].Tag;
                imagesRandom[5].Tag = tag;
            }
            else if (image4.Background.ToString() == "#FFFFFFFF")
            {
                img4.Source = img1.Source;
                img1.Source = null;
                image4.Background = Brushes.Gray;
                image1.Background = Brushes.White;
                var tag = imagesRandom[1].Tag;
                imagesRandom[1].Tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = tag;
            }
            else if (image5.Background.ToString() == "#FFFFFFFF")
            {
                img5.Source = img2.Source;
                img2.Source = null;
                image5.Background = Brushes.Gray;
                image2.Background = Brushes.White;
                var tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = imagesRandom[1].Tag;
                imagesRandom[1].Tag = tag;
            }
            else if (image6.Background.ToString() == "#FFFFFFFF")
            {

                img6.Source = img3.Source;
                img3.Source = null;
                image6.Background = Brushes.Gray;
                image3.Background = Brushes.White;
                var tag = imagesRandom[5].Tag;
                imagesRandom[5].Tag = imagesRandom[2].Tag;
                imagesRandom[2].Tag = tag;
            }
            string chuoi_ran = "";
            for (int i = 0; i < imagesRandom.Count; i++)
            {
                chuoi_ran += imagesRandom[i].Tag.ToString();
            }
            if (String.Compare(chuoi_ran, "012345678") == 0)
            {
                MessageBox.Show("I am win");
                this.Close();
            }
        }

        private void MoveLeft_Click(object sender, RoutedEventArgs e)
        {
            if (image1.Background.ToString() == "#FFFFFFFF")
            {
                img1.Source = img2.Source;
                img2.Source = null;
                image1.Background = Brushes.Gray;
                image2.Background = Brushes.White;
                var tag = imagesRandom[0].Tag;
                imagesRandom[0].Tag = imagesRandom[1].Tag;
                imagesRandom[1].Tag = tag;
            }
            else if (image4.Background.ToString() == "#FFFFFFFF")
            {
                img4.Source = img5.Source;
                img5.Source = null;
                image4.Background = Brushes.Gray;
                image5.Background = Brushes.White;
                var tag = imagesRandom[3].Tag;
                imagesRandom[3].Tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = tag;
            }
            else if (image7.Background.ToString() == "#FFFFFFFF")
            {
                img7.Source = img8.Source;
                img8.Source = null;
                image7.Background = Brushes.Gray;
                image8.Background = Brushes.White;
                var tag = imagesRandom[6].Tag;
                imagesRandom[6].Tag = imagesRandom[7].Tag;
                imagesRandom[7].Tag = tag;
            }
            else if (image2.Background.ToString() == "#FFFFFFFF")
            {
                img2.Source = img3.Source;
                img3.Source = null;
                image2.Background = Brushes.Gray;
                image3.Background = Brushes.White;
                var tag = imagesRandom[1].Tag;
                imagesRandom[1].Tag = imagesRandom[2].Tag;
                imagesRandom[2].Tag = tag;
            }
            else if (image5.Background.ToString() == "#FFFFFFFF")
            {
                img5.Source = img6.Source;
                img6.Source = null;
                image5.Background = Brushes.Gray;
                image6.Background = Brushes.White;
                var tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = imagesRandom[5].Tag;
                imagesRandom[5].Tag = tag;
            }
            else if (image8.Background.ToString() == "#FFFFFFFF")
            {
                img8.Source = img9.Source;
                img9.Source = null;
                image8.Background = Brushes.Gray;
                image9.Background = Brushes.White;
                var tag = imagesRandom[8].Tag;
                imagesRandom[8].Tag = imagesRandom[7].Tag;
                imagesRandom[7].Tag = tag;
            }
            string chuoi_ran = "";
            for (int i = 0; i < imagesRandom.Count; i++)
            {
                chuoi_ran += imagesRandom[i].Tag.ToString();
            }
            if (String.Compare(chuoi_ran, "012345678") == 0)
            {
                MessageBox.Show("I am win");
                this.Close();
            }
        }

        private void MoveRight_Click(object sender, RoutedEventArgs e)
        {
            if (image6.Background.ToString() == "#FFFFFFFF")
            {
                img6.Source = img5.Source;
                img5.Source = null;
                image6.Background = Brushes.Gray;
                image5.Background = Brushes.White;
                var tag = imagesRandom[5].Tag;
                imagesRandom[5].Tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = tag;
            }
            else if (image9.Background.ToString() == "#FFFFFFFF")
            {
                img9.Source = img8.Source;
                img8.Source = null;
                image9.Background = Brushes.Gray;
                image8.Background = Brushes.White;
                var tag = imagesRandom[8].Tag;
                imagesRandom[8].Tag = imagesRandom[7].Tag;
                imagesRandom[7].Tag = tag;

            }
            else if (image3.Background.ToString() == "#FFFFFFFF")
            {
                img3.Source = img2.Source;
                img2.Source = null;
                image3.Background = Brushes.Gray;
                image2.Background = Brushes.White;
                var tag = imagesRandom[2].Tag;
                imagesRandom[2].Tag = imagesRandom[3].Tag;
                imagesRandom[3].Tag = tag;
            }
            else if (image2.Background.ToString() == "#FFFFFFFF")
            {
                img2.Source = img1.Source;
                img1.Source = null;
                image2.Background = Brushes.Gray;
                image1.Background = Brushes.White;
                var tag = imagesRandom[1].Tag;
                imagesRandom[1].Tag = imagesRandom[0].Tag;
                imagesRandom[0].Tag = tag;
            }
            else if (image5.Background.ToString() == "#FFFFFFFF")
            {
                img5.Source = img4.Source;
                img4.Source = null;
                image5.Background = Brushes.Gray;
                image4.Background = Brushes.White;
                var tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = imagesRandom[3].Tag;
                imagesRandom[3].Tag = tag;
            }

            else if (image8.Background.ToString() == "#FFFFFFFF")
            {
                img8.Source = img7.Source;
                img7.Source = null;
                image8.Background = Brushes.Gray;
                image7.Background = Brushes.White;
                var tag = imagesRandom[7].Tag;
                imagesRandom[7].Tag = imagesRandom[6].Tag;
                imagesRandom[6].Tag = tag;
            }
            string chuoi_ran = "";
            for (int i = 0; i < imagesRandom.Count; i++)
            {
                chuoi_ran += imagesRandom[i].Tag.ToString();
            }
            if (String.Compare(chuoi_ran, "012345678") == 0)
            {
                MessageBox.Show("I am win");
                this.Close();
            }
        }
        private void image1_click(object sender, RoutedEventArgs e)
        {
            if (image2.Background.ToString() == "#FFFFFFFF")
            {
                img2.Source = img1.Source;
                img1.Source = null;
                image2.Background = Brushes.Gray;
                image1.Background = Brushes.White;
                // imagesRandom[1].Tag = imagesRandom[0].Tag;
                //imagesRandom[1].Tag = 2;
                var tag = imagesRandom[1].Tag;
                imagesRandom[1].Tag = imagesRandom[0].Tag;
                imagesRandom[0].Tag = tag;
            }
            else if (image4.Background.ToString() == "#FFFFFFFF")
            {
                img4.Source = img1.Source;
                img1.Source = null;
                image4.Background = Brushes.Gray;
                image1.Background = Brushes.White;
                // imagesRandom[3].Tag = imagesRandom[0].Tag;
                // imagesRandom[1].Tag = 4;
                var tag = imagesRandom[1].Tag;
                imagesRandom[1].Tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = tag;
            }
            string chuoi_ran = "";
            for (int i = 0; i < imagesRandom.Count; i++)
            {
                chuoi_ran += imagesRandom[i].Tag.ToString();
            }
            if (String.Compare(chuoi_ran, "012345678") == 0)
            {
                MessageBox.Show("I am win");
            }
        }

        private void image2_click(object sender, RoutedEventArgs e)
        {
            if (image1.Background.ToString() == "#FFFFFFFF")
            {
                img1.Source = img2.Source;
                img2.Source = null;
                image1.Background = Brushes.Gray;
                image2.Background = Brushes.White;
                //imagesRandom[2].Tag = 1;
                // imagesRandom[0].Tag = imagesRandom[1].Tag;
                var tag = imagesRandom[0].Tag;
                imagesRandom[0].Tag = imagesRandom[1].Tag;
                imagesRandom[1].Tag = tag;
            }
            else if (image3.Background.ToString() == "#FFFFFFFF")
            {
                img3.Source = img2.Source;
                img2.Source = null;
                image3.Background = Brushes.Gray;
                image2.Background = Brushes.White;
                //imagesRandom[2].Tag = imagesRandom[1].Tag;
                //imagesRandom[2].Tag = 3;
                var tag = imagesRandom[2].Tag;
                imagesRandom[2].Tag = imagesRandom[3].Tag;
                imagesRandom[3].Tag = tag;
            }

            else if (image5.Background.ToString() == "#FFFFFFFF")
            {
                img5.Source = img2.Source;
                img2.Source = null;
                image5.Background = Brushes.Gray;
                image2.Background = Brushes.White;
                // imagesRandom[2].Tag = 5;
                // imagesRandom[4].Tag = imagesRandom[1].Tag;
                var tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = imagesRandom[1].Tag;
                imagesRandom[1].Tag = tag;
            }

            string chuoi_ran = "";
            for (int i = 0; i < imagesRandom.Count; i++)
            {
                chuoi_ran += imagesRandom[i].Tag.ToString();
            }
            if (String.Compare(chuoi_ran, "012345678") == 0)
            {
                MessageBox.Show("I am win");
            }

        }

        private void image3_click(object sender, RoutedEventArgs e)
        {
            if (image2.Background.ToString() == "#FFFFFFFF")
            {
                img2.Source = img3.Source;
                img3.Source = null;
                image2.Background = Brushes.Gray;
                image3.Background = Brushes.White;
                //imagesRandom[1].Tag = imagesRandom[2].Tag;
                //imagesRandom[3].Tag = 2;
                var tag = imagesRandom[1].Tag;
                imagesRandom[1].Tag = imagesRandom[2].Tag;
                imagesRandom[2].Tag = tag;
            }
            else if (image6.Background.ToString() == "#FFFFFFFF")
            {
                img6.Source = img3.Source;
                img3.Source = null;
                image6.Background = Brushes.Gray;
                image3.Background = Brushes.White;
                // imagesRandom[5].Tag = imagesRandom[2].Tag;
                // imagesRandom[6].Tag = 3;
                var tag = imagesRandom[5].Tag;
                imagesRandom[5].Tag = imagesRandom[2].Tag;
                imagesRandom[2].Tag = tag;
            }

            string chuoi_ran = "";
            for (int i = 0; i < imagesRandom.Count; i++)
            {
                chuoi_ran += imagesRandom[i].Tag.ToString();
            }
            if (String.Compare(chuoi_ran, "012345678") == 0)
            {
                MessageBox.Show("I am win");
            }
        }

        private void image4_click(object sender, RoutedEventArgs e)
        {
            if (image1.Background.ToString() == "#FFFFFFFF")
            {
                img1.Source = img4.Source;
                img4.Source = null;
                image1.Background = Brushes.Gray;
                image4.Background = Brushes.White;
                //imagesRandom[0].Tag = imagesRandom[3].Tag;
                //imagesRandom[1].Tag = 4;
                var tag = imagesRandom[0].Tag;
                imagesRandom[0].Tag = imagesRandom[3].Tag;
                imagesRandom[3].Tag = tag;
            }
            else if (image5.Background.ToString() == "#FFFFFFFF")
            {
                img5.Source = img4.Source;
                img4.Source = null;
                image5.Background = Brushes.Gray;
                image4.Background = Brushes.White;
                // imagesRandom[4].Tag = imagesRandom[3].Tag;
                //imagesRandom[5].Tag = 4;
                var tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = imagesRandom[3].Tag;
                imagesRandom[3].Tag = tag;
            }

            else if (image7.Background.ToString() == "#FFFFFFFF")
            {
                img7.Source = img4.Source;
                img4.Source = null;
                image7.Background = Brushes.Gray;
                image4.Background = Brushes.White;
                // imagesRandom[6].Tag = imagesRandom[3].Tag;
                //imagesRandom[7].Tag = 4;
                var tag = imagesRandom[6].Tag;
                imagesRandom[6].Tag = imagesRandom[3].Tag;
                imagesRandom[3].Tag = tag;
            }
            string chuoi_ran = "";
            for (int i = 0; i < imagesRandom.Count; i++)
            {
                chuoi_ran += imagesRandom[i].Tag.ToString();
            }
            if (String.Compare(chuoi_ran, "012345678") == 0)
            {
                MessageBox.Show("I am win");
            }
        }

        private void image5_click(object sender, RoutedEventArgs e)
        {
            if (image2.Background.ToString() == "#FFFFFFFF")
            {
                img2.Source = img5.Source;
                img5.Source = null;
                image2.Background = Brushes.Gray;
                image5.Background = Brushes.White;
                //imagesRandom[1].Tag = imagesRandom[4].Tag;
                //imagesRandom[2].Tag = 5;
                var tag = imagesRandom[1].Tag;
                imagesRandom[1].Tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = tag;
            }
            else if (image4.Background.ToString() == "#FFFFFFFF")
            {
                img4.Source = img5.Source;
                img5.Source = null;
                image4.Background = Brushes.Gray;
                image5.Background = Brushes.White;
                //imagesRandom[3].Tag = imagesRandom[4].Tag;
                //imagesRandom[4].Tag = 5;
                var tag = imagesRandom[3].Tag;
                imagesRandom[3].Tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = tag;
            }

            else if (image8.Background.ToString() == "#FFFFFFFF")
            {
                img8.Source = img5.Source;
                img5.Source = null;
                image8.Background = Brushes.Gray;
                image5.Background = Brushes.White;
                //imagesRandom[7].Tag = imagesRandom[4].Tag;
                //imagesRandom[8].Tag = 5;
                var tag = imagesRandom[7].Tag;
                imagesRandom[7].Tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = tag;
            }

            else if (image6.Background.ToString() == "#FFFFFFFF")
            {
                img6.Source = img5.Source;
                img5.Source = null;
                image6.Background = Brushes.Gray;
                image5.Background = Brushes.White;
                //imagesRandom[5].Tag = imagesRandom[4].Tag;
                // imagesRandom[6].Tag = 5;
                var tag = imagesRandom[5].Tag;
                imagesRandom[5].Tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = tag;
            }
            string chuoi_ran = "";
            for (int i = 0; i < imagesRandom.Count; i++)
            {
                chuoi_ran += imagesRandom[i].Tag.ToString();
            }
            if (String.Compare(chuoi_ran, "0123456789") == 0)
            {
                MessageBox.Show("I am win");
            }
        }

        private void image6_click(object sender, RoutedEventArgs e)
        {
            if (image3.Background.ToString() == "#FFFFFFFF")
            {
                img3.Source = img6.Source;
                img6.Source = null;
                image3.Background = Brushes.Gray;
                image6.Background = Brushes.White;
                //[2].Tag = imagesRandom[5].Tag;
                //imagesRandom[3].Tag = 6;
                var tag = imagesRandom[2].Tag;
                imagesRandom[2].Tag = imagesRandom[5].Tag;
                imagesRandom[5].Tag = tag;
            }
            else if (image5.Background.ToString() == "#FFFFFFFF")
            {
                img5.Source = img6.Source;
                img6.Source = null;
                image5.Background = Brushes.Gray;
                image6.Background = Brushes.White;
                //imagesRandom[4].Tag = imagesRandom[5].Tag;
                // imagesRandom[5].Tag = 6;
                var tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = imagesRandom[5].Tag;
                imagesRandom[5].Tag = tag;
            }

            else if (image9.Background.ToString() == "#FFFFFFFF")
            {
                img9.Source = img6.Source;
                img6.Source = null;
                image9.Background = Brushes.Gray;
                image6.Background = Brushes.White;
                //imagesRandom[8].Tag = imagesRandom[5].Tag;
                //imagesRandom[9].Tag = 6;
                var tag = imagesRandom[8].Tag;
                imagesRandom[8].Tag = imagesRandom[5].Tag;
                imagesRandom[5].Tag = tag;
            }
            string chuoi_ran = "";
            for (int i = 0; i < imagesRandom.Count; i++)
            {
                chuoi_ran += imagesRandom[i].Tag.ToString();
            }
            if (String.Compare(chuoi_ran, "012345678") == 0)
            {
                MessageBox.Show("I am win");
            }
        }

        private void image7_click(object sender, RoutedEventArgs e)
        {
            if (image4.Background.ToString() == "#FFFFFFFF")
            {
                img4.Source = img7.Source;
                img7.Source = null;
                image4.Background = Brushes.Gray;
                image7.Background = Brushes.White;
                //imagesRandom[3].Tag = imagesRandom[6].Tag;
                // imagesRandom[4].Tag = 7;

                var tag = imagesRandom[3].Tag;
                imagesRandom[3].Tag = imagesRandom[6].Tag;
                imagesRandom[6].Tag = tag;

            }
            else if (image8.Background.ToString() == "#FFFFFFFF")
            {
                img8.Source = img7.Source;
                img7.Source = null;
                image8.Background = Brushes.Gray;
                image7.Background = Brushes.White;
                //imagesRandom[7].Tag = imagesRandom[6].Tag;
                //imagesRandom[8].Tag = 7;

                var tag = imagesRandom[7].Tag;
                imagesRandom[7].Tag = imagesRandom[6].Tag;
                imagesRandom[6].Tag = tag;
            }

            string chuoi_ran = "";
            for (int i = 0; i < imagesRandom.Count; i++)
            {
                chuoi_ran += imagesRandom[i].Tag.ToString();
            }
            if (String.Compare(chuoi_ran, "012345678") == 0)
            {
                MessageBox.Show("I am win");
            }
        }

        private void image8_click(object sender, RoutedEventArgs e)
        {


            if (image9.Background.ToString() == "#FFFFFFFF")
            {
                img9.Source = img8.Source;
                img8.Source = null;
                image9.Background = Brushes.Gray;
                image8.Background = Brushes.White;

                var tag = imagesRandom[8].Tag;
                imagesRandom[8].Tag = imagesRandom[7].Tag;
                imagesRandom[7].Tag = tag;
            }

            else if (image7.Background.ToString() == "#FFFFFFFF")
            {
                img7.Source = img8.Source;
                img8.Source = null;
                image7.Background = Brushes.Gray;
                image8.Background = Brushes.White;
                // imagesRandom[8].Tag = 6;
                // imagesRandom[6].Tag = imagesRandom[7].Tag;

                var tag = imagesRandom[6].Tag;
                imagesRandom[6].Tag = imagesRandom[7].Tag;
                imagesRandom[7].Tag = tag;
            }

            else if (image5.Background.ToString() == "#FFFFFFFF")
            {
                img5.Source = img8.Source;
                img8.Source = null;
                image5.Background = Brushes.Gray;
                image8.Background = Brushes.White;
                // imagesRandom[8].Tag = 4;
                //imagesRandom[4].Tag = imagesRandom[7].Tag;

                var tag = imagesRandom[4].Tag;
                imagesRandom[4].Tag = imagesRandom[7].Tag;
                imagesRandom[7].Tag = tag;
            }

            string chuoi_ran = "";
            for (int i = 0; i < imagesRandom.Count; i++)
            {
                chuoi_ran += imagesRandom[i].Tag.ToString();
            }
            if (String.Compare(chuoi_ran, "012345678") == 0)
            {
                MessageBox.Show("I am win");
            }

        }

        private void image9_click(object sender, RoutedEventArgs e)
        {
            if (image6.Background.ToString() == "#FFFFFFFF")
            {
                img6.Source = img9.Source;
                img9.Source = null;
                image6.Background = Brushes.Gray;
                image9.Background = Brushes.White;
                //imagesRandom[7].Tag = 6;
                //imagesRandom[5].Tag = imagesRandom[8].Tag;

                var tag = imagesRandom[5].Tag;
                imagesRandom[5].Tag = imagesRandom[8].Tag;
                imagesRandom[8].Tag = tag;
            }
            else if (image8.Background.ToString() == "#FFFFFFFF")
            {
                img8.Source = img9.Source;
                img9.Source = null;
                image8.Background = Brushes.Gray;
                image9.Background = Brushes.White;
                //imagesRandom[9].Tag = 8;

                var tag = imagesRandom[8].Tag;
                imagesRandom[8].Tag = imagesRandom[7].Tag;
                imagesRandom[7].Tag = tag;
            }

            string chuoi_ran = "";
            for (int i = 0; i < imagesRandom.Count; i++)
            {
                chuoi_ran += imagesRandom[i].Tag.ToString();
            }
            if (String.Compare(chuoi_ran, "012345678") == 0)
            {
                MessageBox.Show("I am win");
            }



        }
        private void LoadGame_Click(object sender, RoutedEventArgs e)
        {
            List<int> Load = new List<int>();
            int vt = -1;
            StreamReader sr = new StreamReader("save.dat");
            for (int i = 0; i < imagesRandom.Count + 2; i++)
            {
                String line = sr.ReadLine();
                var x = Int32.Parse(line);
                Load.Add(x);
            }
            minutes = Load[0];
            seconds = Load[1];
            dispatcherTimer.Start();
            if (Load[2] == 8)
            {
                img1.Source = null;
                image1.Tag = Load[2];
                image1.Background = Brushes.White;
            }
            else
            {
                img1.Source = images[Load[2]].Source;
                image1.Tag = Load[2];
                image1.Background = Brushes.Gray;
            }

            if(Load[3] == 8)
            {
                img2.Source = null;
                image2.Tag = Load[3];
                image2.Background = Brushes.White;
            }
            else
            {
                img2.Source = images[Load[3]].Source;
                image2.Tag = Load[3];
                image2.Background = Brushes.Gray;
            }


            if (Load[4] == 8)
            {
                img3.Source = null;
                image3.Tag = Load[4];
                image3.Background = Brushes.White;
            }

            else
            {
                img3.Source = images[Load[4]].Source;
                image3.Tag = Load[4];
                image3.Background = Brushes.Gray;
            }

            if (Load[5] == 8)
            {
                img4.Source = null;
                image4.Tag = Load[5];
                image4.Background = Brushes.White;
            }
            else
            {
                img4.Source = images[Load[5]].Source;
                image4.Tag = Load[5];
                image4.Background = Brushes.Gray;
            }

            if(Load[6] == 8)
            {
                img5.Source = null;
                image5.Tag = Load[6];
                image5.Background = Brushes.White;
            }
            else
            {
                img5.Source = images[Load[6]].Source;
                image5.Tag = Load[6];
                image5.Background = Brushes.Gray;
            }

            if (Load[7] == 8)
            {
                img6.Source = null;
                image6.Tag = Load[7];
                image6.Background = Brushes.White;
            }
            else
            {
                img6.Source = images[Load[7]].Source;
                image6.Tag = Load[7];
                image6.Background = Brushes.Gray;
            }

            if (Load[8] == 8)
            {
                img7.Source = null;
                image7.Tag = Load[8];
                image7.Background = Brushes.White;
            }
            else
            {
                img7.Source = images[Load[8]].Source;
                image7.Tag = Load[8];
                image7.Background = Brushes.Gray;
            }

            if (Load[9] == 8)
            {
                img8.Source = null;
                image8.Tag = Load[9];
                image8.Background = Brushes.White;
            }
            else
            {
                img8.Source = images[Load[9]].Source;
                image8.Tag = Load[9];
                image8.Background = Brushes.Gray;
            }

            if (Load[10] == 8)
            {
                img9.Source = null;
                image9.Tag = Load[10];
                image9.Background = Brushes.White;
            }

            else
            {
                img9.Source = images[Load[10]].Source;
                image9.Tag = Load[10];
                image9.Background = Brushes.Gray;
            }

           
           
            
        }
    }
}
