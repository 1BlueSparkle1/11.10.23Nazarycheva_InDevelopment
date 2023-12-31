﻿using StoreForTechnology.Components;
using StoreForTechnology.MyPages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StoreForTechnology
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static HardwareShopEntities db = new HardwareShopEntities();
        public static bool isAdmin = false;
        public static MainWindow mainWindow;
        public static AddEditProductPage productPage;
    }
}
