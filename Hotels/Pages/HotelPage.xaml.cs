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
    /// Логика взаимодействия для HotelPage.xaml
    /// </summary>
    public partial class HotelPage : Page
    {
        Hotel hotel;
        bool edit = false;
        public HotelPage(Hotel hotel = null)
        {
            InitializeComponent();
            if (hotel != null)
            {
                edit = true;
                this.hotel = hotel;
                regionCb.SelectedItem = hotel.Region;
                directionCb.SelectedItem = hotel.Direction;
            }
            else
            {
                this.hotel = new Hotel();
                regionCb.SelectedIndex = 0;
                directionCb.SelectedIndex = 0;
            }

            main.DataContext = this.hotel;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!edit)
            {
                Utils.db.Hotels.Add(hotel);
            }
            Utils.db.SaveChanges();
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            regionCb.ItemsSource = Utils.db.Regions.ToList();
            directionCb.ItemsSource = Utils.db.Directions.ToList();
        }
    }
}
