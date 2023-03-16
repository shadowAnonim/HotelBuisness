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
    /// Логика взаимодействия для SeasonsPage.xaml
    /// </summary>
    public partial class SeasonsPage : Page
    {
        public SeasonsPage()
        {
            InitializeComponent();
        }

        private void fillDataGrid()
        {
            List<DeadSeason> rooms = Utils.db.DeadSeasons.Include(s => s.Hotel).ToList(); ;
            roomsDg.ItemsSource = rooms;
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DeadSeason selected = roomsDg.SelectedItem as DeadSeason;
            if (selected == null)
            {
                Utils.Error("Выберите сезон");
                return;
            }
            if (MessageBox.Show("Вы точно хотите удалить этот сезон",
                "Подтвердите", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                Utils.db.Rooms.Remove(selected);
                Utils.db.SaveChanges();
                fillDataGrid();
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RoomPage());
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Room selected = roomsDg.SelectedItem as Room;
            if (selected == null)
            {
                Utils.Error("Выберите комнату");
                return;
            }
            NavigationService.Navigate(new RoomPage(selected));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            fillDataGrid();
        }
    }
}
