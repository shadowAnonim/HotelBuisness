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
    /// Логика взаимодействия для BookingsPage.xaml
    /// </summary>
    public partial class BookingsPage : Page
    {
        Hotel hotel;
        public BookingsPage(Hotel hotel = null)
        {
            InitializeComponent();
            this.hotel = hotel;
        }

        private void fillDataGrid()
        {
            List<Booking> hotels = Utils.db.Bookings.Include(b => b.Room)
                .ThenInclude(b => b.Hotel)
                .Include(b => b.Client).ToList();
            if(hotel != null)
            {
                hotels = hotels.Where(b => b.Room.Hotel == hotel).ToList();
            }            
            hotelsDg.ItemsSource = hotels;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BookingPage());
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Booking selected = hotelsDg.SelectedItem as Booking;
            if (selected == null)
            {
                Utils.Error("Выберите элемент");
                return;
            }
            NavigationService.Navigate(new BookingPage(selected));
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Booking selected = hotelsDg.SelectedItem as Booking;
            if (selected == null)
            {
                Utils.Error("Выберите запись");
                return;
            }
            if (MessageBox.Show("Вы точно хотите удалить эту запись?",
                "Подтвердите", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                Utils.db.Bookings.Remove(selected);
                Utils.db.SaveChanges();
                fillDataGrid();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            fillDataGrid();
        }

        private void acceptBtn_Click(object sender, RoutedEventArgs e)
        {
            Booking selected = hotelsDg.SelectedItem as Booking;
            if (selected == null)
            {
                Utils.Error("Выберите запись");
                return;
            }
            if (selected.Accept.Value)
            {
                Utils.Error("Уже подтверждено");
                return;
            }
            selected.Accept = true;
            Utils.db.SaveChanges();
            fillDataGrid();
        }
    }
}
