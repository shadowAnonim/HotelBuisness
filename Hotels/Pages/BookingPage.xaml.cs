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
                this.booking.Room = Utils.db.Rooms.First();
                roomCb.SelectedIndex = 0;
                this.booking.BookingDate = DateTime.Now;
                this.booking.Accept = false;
                this.booking.ArrivalDate = DateTime.Now;
                this.booking.DepartureDate = DateTime.Now.AddDays(1);

                clientCb.SelectedIndex = 0;
            }

            main.DataContext = this.booking;
        }

        private bool DateValidation()
        {
            if (endDp.SelectedDate.Value.Date <= startDp.SelectedDate.Value.Date)
            {
                return false;
            }
            return true;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!DateValidation())
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
            hotelCb.ItemsSource = Utils.db.Hotels.Include(h => h.Direction).ToList();
            Hotel currHotel = hotelCb.SelectedItem as Hotel;
            roomCb.ItemsSource = Utils.db.Rooms.Include(r => r.Categoty).Where(r => r.Hotel == currHotel).ToList();
            roomCb.SelectedIndex = 0;
            endDp.SelectedDateChanged += Dp_SelectionChanged;
            startDp.SelectedDateChanged += Dp_SelectionChanged;
            sumDp.SelectionChanged += sumDp_SelectionChanged;
        }

        private long CalculateDiscount()
        {
            Hotel current = hotelCb.SelectedItem as Hotel;
            List<DeadSeason> seasons = Utils.db.DeadSeasons.Include(s => s.Hotel).ToList();
            foreach (DeadSeason season in seasons)
            {
                if (season.StartDate.Value >= startDp.SelectedDate.Value && season.EndDate.Value
                    <= endDp.SelectedDate.Value && season.Hotel == current)
                {
                    return 20;
                }
            }
            return current.Direction.Discount;
        }

        private void hotelCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!DateValidation())
            {
                Utils.Error("Дата выезда должна быть позже даты заезда");
                return;
            }
            Hotel current = hotelCb.SelectedItem as Hotel;
            List<Room> rooms = Utils.db.Rooms.Where(r => r.Hotel == current).ToList();
            roomCb.ItemsSource = rooms;
            roomCb.SelectedIndex = 0;
            try
            {
                TimeSpan days = endDp.SelectedDate.Value - startDp.SelectedDate.Value;
                Room category = (roomCb.SelectedItem as Room);
                long? category1 = category.CategotyId;
                Hotel hotel = hotelCb.SelectedItem as Hotel;
                RoomPrice prices = Aboba().FirstOrDefault(p => p.Hotel == hotel && p.CategoryId == category1);
                if (prices == null)
                {
                    sumDp.Text = "0";
                    MessageBox.Show("Нет цен для выбранной даты", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    sumDp.Text = prices.Price.ToString();
                }
                if (decimal.TryParse(sumDp.Text, out decimal x))
                {
                    totalDp.Content = ((days.Days * decimal.Parse(sumDp.Text)) * (1 - decimal.Parse(discountLbl.Content.ToString().Split(' ')[1]) / 100)).ToString();
                }
                else
                {
                    Utils.Error("Неверный формат цены");
                }
                discountLbl.Content = $"Скидка: {CalculateDiscount()}";
            }
            catch (Exception ex)
            {
                Utils.Error(ex.Message);
            }
        }

        private void Dp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!DateValidation())
            {
                Utils.Error("Дата выезда должна быть позже даты заезда");
                return;
            }
            try
            {
                TimeSpan days = endDp.SelectedDate.Value - startDp.SelectedDate.Value;
                Room category = (roomCb.SelectedItem as Room);
                long? category1 = category.CategotyId;
                Hotel hotel = hotelCb.SelectedItem as Hotel;
                RoomPrice prices = Aboba().FirstOrDefault(p => p.Hotel == hotel && p.CategoryId == category1);
                if (prices == null)
                {
                    sumDp.Text = "0";
                    MessageBox.Show("Нет цен для выбранной даты", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    sumDp.Text = prices.Price.ToString();
                }
                if (decimal.TryParse(sumDp.Text, out decimal x))
                {
                    totalDp.Content = ((days.Days * decimal.Parse(sumDp.Text)) * (1 - decimal.Parse(discountLbl.Content.ToString().Split(' ')[1]) / 100)).ToString();
                }
                else
                {
                    Utils.Error("Неверный формат цены");
                }
                discountLbl.Content = $"Скидка: {CalculateDiscount()}";
            }
            catch (Exception ex)
            {
                Utils.Error(ex.Message);
            }
        }

        private void sumDp_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!DateValidation())
            {
                Utils.Error("Дата выезда должна быть позже даты заезда");
                return;
            }
            if (sumDp.Text == "")
            {
                sumDp.Text = "0";
            }
            try
            {
                TimeSpan days = endDp.SelectedDate.Value - startDp.SelectedDate.Value;
                Room category = (roomCb.SelectedItem as Room);
                long? category1 = category.CategotyId;
                Hotel hotel = hotelCb.SelectedItem as Hotel;
                RoomPrice prices = Aboba().FirstOrDefault(p => p.Hotel == hotel && p.CategoryId == category1);
                totalDp.Content = ((days.Days * decimal.Parse(sumDp.Text)) * (1 - decimal.Parse(discountLbl.Content.ToString().Split(' ')[1]) / 100)).ToString();
            }
            catch (FormatException)
            {
                Utils.Error("Неверный формат цены");
            }
            catch (Exception ex)
            {
                Utils.Error(ex.Message);
            }
        }

        private List<RoomPrice> Aboba()
        {
            List<RoomPrice> prices = Utils.db.RoomPrices.Include(p => p.Hotel).ToList();
            List<RoomPrice> toRemove = new List<RoomPrice>();
            foreach(RoomPrice price in prices)
            {
                if (price.Date.Value.Date > endDp.SelectedDate.Value)
                {
                    toRemove.Add(price);
                }
            }
            foreach (RoomPrice price in toRemove)
            {
                prices.Remove(price);
            }
            return prices;
        }
    }
}
