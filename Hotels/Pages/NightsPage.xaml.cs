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
    /// Логика взаимодействия для NightsPage.xaml
    /// </summary>
    public partial class NightsPage : Page
    {
        public NightsPage()
        {
            InitializeComponent();
            datePicker.SelectedDate = DateTime.Now;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            fillDataGrid();
        }

        private void fillDataGrid()
        {
            List<Night> nights = new List<Night>();
            foreach (Hotel hotel in Utils.db.Hotels)
            {
                foreach (Category category in Utils.db.Categories)
                {
                    List<Booking> correctBookings = Utils.db.Bookings.Include(b => b.Room).ThenInclude(b => b.Hotel)
                        .Include(b => b.Room).ThenInclude(b => b.Categoty)
                        .Where(b => b.Room.Hotel == hotel &&
                        b.Accept.Value && b.ArrivalDate.Value <= datePicker.SelectedDate.Value &&
                        b.Room.Categoty == category).ToList();
                    nights.Add(new Night(hotel, category, 
                        correctBookings.Sum(b => (b.DepartureDate - b.ArrivalDate).Value.Days), 
                        correctBookings.Sum(b => b.Total.Value)));
                }
            }
            roomsDg.ItemsSource = nights;
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDataGrid();
        }
    }
}
