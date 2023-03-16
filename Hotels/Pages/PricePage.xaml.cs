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
    /// Логика взаимодействия для PricePage.xaml
    /// </summary>
    public partial class PricePage : Page
    {
        public PricePage()
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
            List<RoomPrice> prices = Utils.db.RoomPrices.ToList();
            List<RoomPrice> toRemove = new List<RoomPrice>();
            foreach(RoomPrice price in prices)
            {
                if (price.Date.Value.Date > datePicker.SelectedDate.Value.Date)
                {
                    toRemove.Add(price);
                }
            }
            foreach (RoomPrice price in toRemove)
            {
                prices.Remove(price);
            }
            List<PriceList> priceList = new List<PriceList>();
            foreach (Hotel hotel in Utils.db.Hotels.ToList())
            {
                priceList.Add(new PriceList() { Name = hotel.Name });
            }
            foreach (RoomPrice price in prices)
            {
                PriceList curr = priceList.FirstOrDefault(p => p.Name == price.Hotel.Name);
                switch (price.CategoryId)
                {
                    case 1:
                        curr.StandartPrice = price.Price.Value.ToString() + "руб./сут";
                        break;
                    case 2:
                        curr.LuxPrice = price.Price.Value.ToString() + "руб./сут";
                        break;
                    case 3:
                        curr.ApartmentPrice = price.Price.Value.ToString() + "руб./сут";
                        break;
                }
            }
            priceDg.ItemsSource = priceList;
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDataGrid();
        }
    }
}
