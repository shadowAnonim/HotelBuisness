using Hotels.Data;
using Microsoft.EntityFrameworkCore;
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

namespace Hotels.Pages
{
    /// <summary>
    /// Логика взаимодействия для CleansPage.xaml
    /// </summary>
    public partial class CleansPage : Page
    {
        public CleansPage()
        {
            InitializeComponent();
        }

        private void fillDataGrid()
        {
            List<Clean> cleans = Utils.db.Cleans.Include(c => c.Room).ThenInclude(r => r.Hotel).Include(c => c.Worker).Include(c => c.CleanState).ToList();
            cleansDg.ItemsSource = cleans;
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            fillDataGrid();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Clean selected = cleansDg.SelectedItem as Clean;
            if (selected == null)
            {
                Utils.Error("Выберите заявку");
                return;
            }
            NavigationService.Navigate(new CleanPage(selected));
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Clean selected = cleansDg.SelectedItem as Clean;
            if (selected == null)
            {
                Utils.Error("Выберите заявку");
                return;
            }
            if (MessageBox.Show("Вы точно хотите удалить эту заявку",
                "Подтвердите", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                Utils.db.Cleans.Remove(selected);
                Utils.db.SaveChanges();
                fillDataGrid();
            }
        }
    }
}
