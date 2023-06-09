﻿using Hotels.Data;
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
                this.arrive.Date = DateTime.Now;
                this.arrive.Room = Utils.db.Bookings.ToList().First().Room;
                this.arrive.DepartureDate = Utils.db.Bookings.ToList().First().DepartureDate;
                this.arrive.Booking = Utils.db.Bookings.ToList().First();
                bookingCb.SelectedIndex = 0;
                hotelCb.SelectedIndex = 0;
                roomCb.SelectedIndex = 0;
            }

            main.DataContext = this.arrive;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            bookingCb.ItemsSource = Utils.db.Bookings.Include(b => b.Room).ThenInclude(r => r.Hotel).ToList();
            hotelCb.ItemsSource = Utils.db.Hotels.ToList();
            Hotel currHotel = hotelCb.SelectedItem as Hotel;
            roomCb.ItemsSource = Utils.db.Rooms.Where(r => r.Hotel == currHotel).ToList();
        }

        private void hotelCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            roomCb.ItemsSource = Utils.db.Rooms.Include(r => r.Hotel).Where(r => r.Hotel == hotelCb.SelectedItem as Hotel).ToList();
            roomCb.SelectedIndex = 0;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!edit) Utils.db.Arrives.Add(arrive);
            Utils.db.SaveChanges();
            NavigationService.GoBack();
        }

        private void bookingCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Booking b = bookingCb.SelectedItem as Booking;
            this.arrive.Room = b.Room;
            this.arrive.DepartureDate = b.DepartureDate;
        }
    }
}
