using PR_17.ApplicationData;
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
    /// Логика взаимодействия для PageZebraAdd.xaml
    /// </summary>
    public partial class PageZebraAdd : Page
    {
        private Sklad _currenttovar = new Sklad();
        public PageZebraAdd(Sklad selectedtovar)
        {
            InitializeComponent();
            if (selectedtovar != null)
                _currenttovar = selectedtovar;

            DataContext = _currenttovar;
            ComboZakaz.ItemsSource = Zebra1Entities.GetContext().Zakaz.ToList();
            ComboStatus.ItemsSource = Zebra1Entities.GetContext().Status.ToList();
            ComboSotrudniki.ItemsSource = Zebra1Entities.GetContext().Sotrudniki.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currenttovar.naimenov))
                errors.AppendLine("Укажите название товара");
            if (_currenttovar.kolichestvo <= 0)
                errors.AppendLine("Количество товара не можеть быть больше или ровно 0");
            if (_currenttovar.cena <= 0)
                errors.AppendLine("Количество товара не можеть быть меньше или ровно 0");
            if (_currenttovar.Status == null)
                errors.AppendLine("Выберете статус");
            if (_currenttovar.Zakaz == null)
                errors.AppendLine("Выберете заказ"); 
            if (_currenttovar.Sotrudniki == null)
                errors.AppendLine("Выберете сотрудника");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            //Добавление
            if (_currenttovar.id == 0)
                Zebra1Entities.GetContext().Sklad.Add(_currenttovar);

            try
            {
                Zebra1Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnNazad_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.GoBack();        
        }
    }
}
