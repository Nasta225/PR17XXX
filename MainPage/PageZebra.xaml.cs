﻿using PR_17.ApplicationData;
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

namespace PR_17.MainPage
{
    /// <summary>
    /// Логика взаимодействия для PageZebra.xaml
    /// </summary>
    public partial class PageZebra : Page
    {
        public PageZebra()
        {
            InitializeComponent();
            DtGridTovar.ItemsSource = Zebra1Entities.GetContext().Sklad.ToList();
        }


        private void btnRegistrazia_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageLogin());
        }
    }
}
