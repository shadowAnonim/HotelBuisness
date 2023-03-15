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
    /// Логика взаимодействия для ArrivalPage.xaml
    /// </summary>
    public partial class ArrivalPage : Page
    {
        Arrive arrive;
        bool edit = false;
        public ArrivalPage(Arrive arrive = null)
        {
            InitializeComponent();
            if (arrive != null)
            {
                edit = true;
                this.arrive = arrive;
                hotelCb.SelectedItem = this.arrive.Room.Hotel;
            }
            else
            {
                this.arrive = new Arrive();
                hotelCb.SelectedIndex = 0;
            }

            main.DataContext = this.arrive;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            bookingCb.ItemsSource = Utils.db.Bookings.Include(b => b.Room).ThenInclude(r => r.Hotel).ToList();
        }

        private void hotelCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            hotelCb.ItemsSource = Utils.db.Hotels.ToList();
            Hotel currHotel = hotelCb.SelectedItem as Hotel;
            roomCb.ItemsSource = Utils.db.Rooms.Where(r => r.Hotel == currHotel).ToList();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
