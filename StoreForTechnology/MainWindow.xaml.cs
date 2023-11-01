using StoreForTechnology.MyPages;
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
using StoreForTechnology.Components;


namespace StoreForTechnology
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            navigation.mainWindow = this;
            navigation.NextPage(new PageComponent("Магазин Техники", new ProductListPage()));

            var path = @"C:\Users\Acer\Desktop\РПМ\Задание магазин техники\";
            foreach (var item in App.db.Product.ToArray())
            {
                var fullPath = path + item.MainImagePath.Trim();
                var imageByte = File.ReadAllBytes(fullPath);
                item.MainImage = imageByte;
            }
            App.db.SaveChanges();

            MainFrame.Navigate(new ProductListPage());
        }

        private void OnAdmBt_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordPb.Password == "0000")
            {
                App.isAdmin = true;
                navigation.ClearHistory();
                navigation.NextPage(new PageComponent("Режим админа", new ProductListPage()));
                PasswordPb.Clear();
            }
        }

        private void OffAdmBt_Click(object sender, RoutedEventArgs e)
        {
            App.isAdmin = false;
            navigation.ClearHistory();
            navigation.NextPage(new PageComponent("Список услуг", new ProductListPage()));
        }

        private void BackBt_Click(object sender, RoutedEventArgs e)
        {
            navigation.BackPage();
        }
    }
}
