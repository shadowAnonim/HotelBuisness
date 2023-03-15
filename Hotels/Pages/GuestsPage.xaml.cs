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
    /// Логика взаимодействия для GuestsPage.xaml
    /// </summary>
    public partial class GuestsPage : Page
    {
        public GuestsPage()
        {
            InitializeComponent();
        }

        private void fillDataGrid()
        {
            List<Guest> gests = Utils.db.Guests.ToList();
            guestsDg.ItemsSource = gests;

        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GuestPage());
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Guest selected = guestsDg.SelectedItem as Guest;
            if (selected == null)
            {
                Utils.Error("Выберите гостя");
                return;
            }
            NavigationService.Navigate(new GuestPage(selected));
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Guest selected = guestsDg.SelectedItem as Guest;
            if (selected == null)
            {
                Utils.Error("Выберите гостя");
                return;
            }
            if (MessageBox.Show("Вы точно хотите удалить этого гостя",
                "Подтвердите", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                Utils.db.Guests.Remove(selected);
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
