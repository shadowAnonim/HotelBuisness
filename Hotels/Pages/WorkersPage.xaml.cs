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
    /// Логика взаимодействия для WrokersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {
        public WorkersPage()
        {
            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            fillDataGrid();
        }

        private void fillDataGrid()
        {
            List<Worker> workers = Utils.db.Workers.Include(w => w.Work).ToList();
            workersDg.ItemsSource = workers;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WorkerPage());
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Worker selected = workersDg.SelectedItem as Worker;
            if (selected == null)
            {
                Utils.Error("Выберите работника");
                return;
            }
            NavigationService.Navigate(new WorkerPage(selected));
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Worker selected = workersDg.SelectedItem as Worker;
            if (selected == null)
            {
                Utils.Error("Выберите работника");
                return;
            }
            if (MessageBox.Show("Вы точно хотите удалить эого работника",
                "Подтвердите", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                Utils.db.Workers.Remove(selected);
                Utils.db.SaveChanges();
                fillDataGrid();
            }
        }
    }
}
