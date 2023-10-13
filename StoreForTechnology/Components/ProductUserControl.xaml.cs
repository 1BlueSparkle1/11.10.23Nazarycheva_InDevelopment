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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StoreForTechnology.Components
{
    /// <summary>
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        public ProductUserControl( Image image, string title, decimal cost, string costTime, string testimonials)
        {
            InitializeComponent();
            TitleTB.Text = title;
            PriceTB.Text = cost.ToString();
            NewPriceTB.Text = costTime;
            OtzTB.Text = testimonials;
        }

    }
}
