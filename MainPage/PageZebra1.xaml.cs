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
    /// Логика взаимодействия для PageZebra1.xaml
    /// </summary>
    public partial class PageZebra1 : Page
    {
        public PageZebra1()
        {
            InitializeComponent();
            DtGridTovar.ItemsSource = Zebra1Entities.GetContext().Sklad.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageZebraAdd(null));
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var tovarForRemoving = DtGridTovar.SelectedItems.Cast<Sklad>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить текущее {tovarForRemoving.Count()} Элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Zebra1Entities.GetContext().Sklad.RemoveRange(tovarForRemoving);
                    Zebra1Entities.GetContext().SaveChanges();

                    DtGridTovar.ItemsSource = Zebra1Entities.GetContext().Sklad.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageZebraAdd((sender as Button).DataContext as Sklad));
        }
    }
}
