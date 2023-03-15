using Hotels.Data;
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
    /// Логика взаимодействия для BookingPage.xaml
    /// </summary>
    public partial class BookingPage : Page
    {
        Booking booking;
        bool edit = false;
        public BookingPage(Booking booking = null)
        {
            InitializeComponent();
            if (booking != null)
            {
                edit = true;
                this.booking = booking;
                clientCb.SelectedItem = this.booking.Client;
                hotelCb.SelectedItem = this.booking.Room.Hotel;
            }
            else
            {
                this.booking = new Booking();
                this.booking.BookingDate = DateTime.Now;
                this.booking.Accept = false;
                this.booking.ArrivalDate = DateTime.Now;
                this.booking.DepartureDate = DateTime.Now.AddDays(1);
                this.booking.Room = Utils.db.Rooms.First();
                clientCb.SelectedIndex = 0;
                roomCb.SelectedIndex = 0;
            }

            main.DataContext = this.booking;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        { 
            if (endDp.SelectedDate.Value.Date <= startDp.SelectedDate.Value.Date)
            {
                Utils.Error("Дата выезда должна быть позже даты заезда");
                return;
            }
            if (!edit)
            {
                Utils.db.Bookings.Add(booking);
            }
            Utils.db.SaveChanges();
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            clientCb.ItemsSource = Utils.db.Clients.ToList();
            hotelCb.ItemsSource = Utils.db.Hotels.ToList();
            Hotel currHotel = hotelCb.SelectedItem as Hotel;
            roomCb.ItemsSource = Utils.db.Rooms.Where(r => r.Hotel == currHotel).ToList();
        }

        private void hotelCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            roomCb.ItemsSource = Utils.db.Rooms.Where(r => r.Hotel == hotelCb.SelectedItem as Hotel).ToList();
            roomCb.SelectedIndex = 0;
        }
    }
}
