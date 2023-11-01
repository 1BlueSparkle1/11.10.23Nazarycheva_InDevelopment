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
            if (App.isAdmin == false)
            {
                AddBt.Visibility = Visibility.Hidden;
            }

            Refresh();

            var products = App.db.Product.ToList();
            foreach (var product in products)
            {
                ProductWp.Children.Add(new ProductUserControl(product));
            }
        }
        private void Refresh()
        {
            IEnumerable<Product> products = App.db.Product;
            if (CostCb.SelectedIndex != 0)
            {
                if (CostCb.SelectedIndex == 1)
                {
                    products = products.OrderBy(x => x.TotalCost);
                }
                else
                {
                    products = products.OrderByDescending(x => x.TotalCost);
                }
            }
            if (RatingCb.SelectedIndex != 0)
            {
                if (RatingCb.SelectedIndex == 1)
                {
                    products = products.OrderBy(x => x.Reviews);
                }
                else
                {
                    products = products.OrderByDescending(x => x.Reviews);
                }
            }
            if (TestimonialsCb.SelectedIndex != 0)
            {
                if (TestimonialsCb.SelectedIndex == 1)
                {
                    products = products.Where(x => x.Testimonials <= 5);
                }
                else if (TestimonialsCb.SelectedIndex == 2)
                {
                    products = products.Where(x => x.Testimonials >=5  && x.Testimonials <= 20);
                }
                else if (TestimonialsCb.SelectedIndex == 3)
                {
                    products = products.Where(x => x.Testimonials >= 20 && x.Testimonials <= 100);
                }
                else if (TestimonialsCb.SelectedIndex == 4)
                {
                    products = products.Where(x => x.Testimonials >= 100);
                }
            }
            products = products.Where(x => x.Title.ToLower().Contains(TitleTb.Text.ToLower()) || x.Description.ToLower().Contains(TitleTb.Text.ToLower()));
            ProductWp.Children.Clear();
            foreach (var product in products)
            {
                ProductWp.Children.Add(new ProductUserControl(product));
            }
            
            CountDataTb.Text = products.Count().ToString() + " из 29";
        }

        private void CostCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void RatingCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void TestimonialsCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void TitleTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //navigation.NextPage(new PageComponent(new ))
        }
    }
}
