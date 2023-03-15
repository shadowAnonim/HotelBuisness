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
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
        }

        private void fillDataGrid()
        {
            List<Client> clients = Utils.db.Clients.Include(r => r.Type).ToList();
            clientsDg.ItemsSource = clients;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientPage());
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Client selected = clientsDg.SelectedItem as Client;
            if (selected == null)
            {
                Utils.Error("Выберите клиента");
                return;
            }
            NavigationService.Navigate(new ClientPage(selected));
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Client selected = clientsDg.SelectedItem as Client;
            if (selected == null)
            {
                Utils.Error("Выберите клиента");
                return;
            }
            if (MessageBox.Show("Вы точно хотите удалить этого клиента",
                "Подтвердите", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                Utils.db.Clients.Remove(selected);
                Utils.db.SaveChanges();
                fillDataGrid();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            fillDataGrid();
        }
    }
}
