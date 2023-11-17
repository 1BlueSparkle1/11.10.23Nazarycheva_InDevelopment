using Microsoft.Win32;
using StoreForTechnology.Components;
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

namespace StoreForTechnology.MyPages
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductPage.xaml
    /// </summary>
    public partial class AddEditProductPage : Page
    {
        private Product product;
        public AddEditProductPage(Product _product)
        {
            InitializeComponent();
            App.productPage = this;
            product = _product;
            this.DataContext = product;
        }

        private void EditImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                product.MainImage = File.ReadAllBytes(openFile.FileName);
                MainImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (product.Id == 0)
            {
                if (App.db.Product.Any(x => x.Title == product.Title))
                {
                    errors.AppendLine("Такая услуга уже существует!");
                }
                else
                {
                    App.db.Product.Add(product);
                }

            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
            }
            else
            {
                App.db.SaveChanges();
                MessageBox.Show("Сохранено");
                navigation.NextPage(new PageComponent("Список услуг", new ProductListPage()));
            }
        }

        private void CostTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(char.IsDigit(e.Text[0])))
            {
                e.Handled = true;
            }
        }
    }
}
