﻿using Hotels.Data;
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
            }
            else
            {
                this.booking = new Booking();
                this.booking.ArrivalDate = Utils.DateToBytes(DateTime.Now);
                this.booking.DepartureDate = Utils.DateToBytes(DateTime.Now.AddDays(1));
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
            booking.ArrivalDate = Utils.DateToBytes(startDp.SelectedDate.Value);
            booking.DepartureDate = Utils.DateToBytes(endDp.SelectedDate.Value);
            if (!edit)
            {
                Utils.db.Bookings.Add(booking);
            }
            Utils.db.SaveChanges();
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            startDp.SelectedDate = Utils.BytesToDate(booking.ArrivalDate);
            endDp.SelectedDate = Utils.BytesToDate(booking.DepartureDate);
        }
    }
}