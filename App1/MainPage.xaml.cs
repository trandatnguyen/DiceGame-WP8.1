using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Net;
using System.Windows.Input;
using System.Windows;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Random rd = new Random();
        List<string> res = new List<string>();
        int scores = 0;
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            AddImage();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void btChange_Click(object sender, RoutedEventArgs e)
        {
            //if (scores < 0)
            //{
            //    txtKetqua.Text = "Điểm của bạn không đủ !";
            //    return;
            //}

            int ImageRandomIndex = rd.Next(0, res.Count);// tao bien chi so cua anh bang gia tri random dc
            string filename = res[ImageRandomIndex];
            Uri uri = new Uri("ms-appx:///" + filename, UriKind.Absolute);
            BitmapImage bm = new BitmapImage();
            bm.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bm.UriSource = uri;

            Img.Source = bm;

            txtBlobk.Text = ImageRandomIndex.ToString();

            if ((ImageRandomIndex + 1) % 2 == 0 && !btnChon.IsOn)
            {
                txtKetqua.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                txtKetqua.Text = "Chúc mừng bạn đoán đúng !";
                scores += 10;
                txtDiem.Text = scores.ToString();
                return;
            }


            if ((ImageRandomIndex + 1) % 2 != 0 && btnChon.IsOn)
            {
                txtKetqua.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                txtKetqua.Text = "Chúc mừng bạn đoán đúng !";                
                scores += 10;
                txtDiem.Text = scores.ToString();
                return;
            }
            else
            {
                txtKetqua.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                txtKetqua.Text = "Cơ hội sẽ đến lần sau !";                
                scores -= 10;
                txtDiem.Text = scores.ToString();
            }

            

        }

        void AddImage()
        {
            res.Add("Images/1.png");
            res.Add("Images/2.png");
            res.Add("Images/3.png");
            res.Add("Images/4.png");
            res.Add("Images/5.png");
            res.Add("Images/6.png");
        }
    }
}
