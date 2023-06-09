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
    /// Логика взаимодействия для PricesPage.xaml
    /// </summary>
    public partial class PricesPage : Page
    {
        public PricesPage()
        {
            InitializeComponent();
        }

        private void fillDataGrid()
        {
            List<RoomPrice> hotels = Utils.db.RoomPrices.Include(p => p.Hotel).Include(p => p.Category).OrderBy(p => p.Date).ToList();
            hotelsDg.ItemsSource = hotels;
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Hotel selected = hotelsDg.SelectedItem as Hotel;
            if (selected == null)
            {
                Utils.Error("Выберите цену");
                return;
            }
            if (MessageBox.Show("Вы точно хотите удалить этот отель",
                "Подтвердите", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                Utils.db.Hotels.Remove(selected);
                Utils.db.SaveChanges();
                fillDataGrid();
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HotelPage());
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Hotel selected = hotelsDg.SelectedItem as Hotel;
            if (selected == null)
            {
                Utils.Error("Выберите отель");
                return;
            }
            NavigationService.Navigate(new HotelPage(selected));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            fillDataGrid();
        }
    }
}
