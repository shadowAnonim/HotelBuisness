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
    /// Логика взаимодействия для SellingsPage.xaml
    /// </summary>
    public partial class SellingsPage : Page
    {
        public SellingsPage()
        {
            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            datePk.SelectedDate = DateTime.Now;
            hotelsCb.ItemsSource = Utils.db.Hotels.ToList();
            hotelsCb.SelectedIndex = 0;
            Change(hotelsCb.SelectedItem as Hotel);
            hotelsCb.SelectionChanged += hotelsCb_SelectionChanged;
            datePk.SelectedDateChanged += datePk_SelectedDateChanged;
        }

        private void hotelsCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Change(hotelsCb.SelectedItem as Hotel);
        }

        private void Change(Hotel current)
        {
            List<Booking> bookings = Utils.db.Bookings.Include(b => b.Room).ThenInclude(r => r.Hotel).ToList();
            try
            {
                int days = 0;
                decimal? total = 0;
                foreach (Booking booking in bookings)
                {
                    if (booking.Room.Hotel == current && booking.ArrivalDate <= datePk.SelectedDate.Value && booking.Accept.Value)
                    {
                        if (booking.DepartureDate > datePk.SelectedDate.Value)
                        {
                            days += (datePk.SelectedDate.Value - booking.ArrivalDate).Value.Days;
                            total += booking.Total / (booking.DepartureDate - booking.ArrivalDate).Value.Days * (datePk.SelectedDate.Value - booking.ArrivalDate).Value.Days;
                        }
                        else
                        {
                            days += (booking.DepartureDate - booking.ArrivalDate).Value.Days;
                            total += booking.Total;
                        }
                    }
                }
                total = Math.Round(total.Value, 2);
                nightsLb.Content = days;
                totalLb.Content = total;
                decimal rooms = Math.Round((decimal.Parse(days.ToString()) / current.Rooms.Count()), 2) * 100;
                zagruzLb.Content = rooms;
                adrLb.Content = Math.Round((total / decimal.Parse(days.ToString())).Value, 2);
                revLb.Content = Math.Round((total / decimal.Parse(days.ToString()) * rooms).Value, 2);
            }
            catch (DivideByZeroException)
            {
                Utils.Error("Нет подходящих данных");
                totalLb.Content = "0";
                nightsLb.Content = "0";
                zagruzLb.Content = "0";
                adrLb.Content = "0";
                revLb.Content = "0";
            }
            catch (Exception ex)
            {
                Utils.Error(ex.Message);
            }
        }

        private void datePk_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            hotelsCb_SelectionChanged(null, null);
        }
    }
}
