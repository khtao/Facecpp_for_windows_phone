using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FaceCpp.Resources;
using System.Windows.Media.Imaging;
using FacePuls;
using Microsoft.Phone.Tasks;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows.Media;

namespace FaceCpp
{
    public partial class MainPage : PhoneApplicationPage
    {
        public FaceService fs = new FaceService("2affcadaeddd18f422375adc869f3991", "EsU9hmgweuz8U-nwv6s4JP-9AJt64vhz");
        // Constructor
        private PhotoChooserTask pic = new PhotoChooserTask();

        public MainPage()
        {
            InitializeComponent();
            pic.Completed += pic_Completed;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        private double max(double x, double y)
        {
            return (x > y) ? x : y;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            pic.ShowCamera = true;
            pic.Show();
        }

     async   void pic_Completed(object sender, PhotoResult e)
        {
            BitmapImage bitmapimage = new BitmapImage();
            bitmapimage.SetSource(e.ChosenPhoto);
            image1.Source = bitmapimage;
            using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (Stream sr = iso.CreateFile("temp.jpg"))
                {
                    WriteableBitmap image = new WriteableBitmap(bitmapimage);
                    image.SaveJpeg(sr, image.PixelWidth, image.PixelHeight, 0, 100);
                    bitmapimage = null;
                    image = null;
                }
            }
            DetectResult res =await fs.Detection_DetectImg("temp.jpg");
            canvas1.Children.Clear();
            for (int i = 0; i < res.face.Count; ++i)
            {
                RectangleGeometry rect = new RectangleGeometry();
                rect.Rect = new Rect(max(res.face[i].position.center.x * image1.Width / 100.0 - res.face[i].position.width * image1.Width / 200.0, 0),
                                     max(res.face[i].position.center.y * image1.Height / 100.0 - res.face[i].position.height * image1.Height / 200.0, 0),
                                     res.face[i].position.width * image1.Width / 100.0, res.face[i].position.height * image1.Height / 60.0);
                System.Windows.Shapes.Path myPath = new System.Windows.Shapes.Path();
                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                // Describes the brush's color using RGB values. 
                // Each value has a range of 0-255.
                mySolidColorBrush.Color = Color.FromArgb(255, 0, 0, 255);
                myPath.Stroke = mySolidColorBrush;
                myPath.StrokeThickness = 3 ;
                myPath.Data = rect;
                label1.Text = label1.Text + String.Format("({0:F2},{1:F2})", res.face[0].position.center.x, res.face[0].position.center.y);
                label2.Text = label2.Text + String.Format("({0:F2},{1:F2})", res.face[0].position.width, res.face[0].position.height);
                canvas1.Children.Add(myPath);
            }
        }
        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}