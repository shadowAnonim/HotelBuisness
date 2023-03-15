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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void hotelsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HotelsPage());
        }

        private void roomsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RoomsPage());
        }

        private void bookingsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BookingsPage());
        }

        private void guestsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GuestsPage());
        }
    }
}
