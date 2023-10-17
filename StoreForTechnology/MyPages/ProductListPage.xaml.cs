using StoreForTechnology.Components;
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

namespace StoreForTechnology.MyPages
{
    /// <summary>
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        public ProductListPage()
        {
            InitializeComponent();

            var products = App.db.Product.ToList();
            foreach (var product in products)
            {
                ProductWp.Children.Add(new ProductUserControl(new Image(), product.Title, product.Cost, product.CostTime, product.Testimonials, product.Reviews, product.CostVisibility));
            }
        }
    }
}
