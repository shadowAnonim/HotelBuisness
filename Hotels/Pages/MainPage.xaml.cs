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

        private void clientsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientsPage());
        }

        private void departuresBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeparturesPage());
        }
        private void arrivalBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ArrivalPage());
        }
        private void departureBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeparturePage());
        }
        private void vdepartureBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeparturesPage());
        }
        private void ArrivesBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ArrivalsPage());
        }

        private void priceBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PricePage());
        }

        private void historyBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PricesPage());
        }

        private void discountBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SeasonsPage());
        }

        private void sellingsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SellingsPage());
        }

        private void nightsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NightsPage());
        }

        private void cleaningBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CleaningRequestPage());
        }

        private void buisnessBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CleanerBuisnessPage());
        }

        private void cleansBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CleansPage());
        }

        private void workersBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WorkersPage());
        }
    }
}
