using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StoreForTechnology.Components
{
    /// <summary>
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        private Product product;
        public ProductUserControl( Product _product)
        {
            InitializeComponent();
            product = _product;
            TitleTB.Text = product.Title;
            PriceTB.Text = product.Cost.ToString("0");
            NewPriceTB.Text = product.CostTime;
            OtzTB.Text = " " + product.Testimonials.ToString() + " отзывов";
            NumOtzTB.Text = product.Reviews;
            PriceTB.Visibility = product.CostVisibility;
            TitleImg.Source = GetImageSourse(product.MainImage);
        }

        private BitmapImage GetImageSourse(byte[] byteImage)
        {
            BitmapImage bitmapImage = new BitmapImage();
            try
            {
                if (product.MainImage != null)
                {
                    MemoryStream byteStream = new MemoryStream(byteImage);
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = byteStream;
                    bitmapImage.EndInit();
                }
                else
                    bitmapImage = new BitmapImage(new Uri(@"\Resources\logo.png", UriKind.Relative));
            }
            catch
            {
                MessageBox.Show("Error");
            }
            return bitmapImage;
        }

    }
}
