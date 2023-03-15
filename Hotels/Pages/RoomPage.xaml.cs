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
    /// Логика взаимодействия для RoomPage.xaml
    /// </summary>
    public partial class RoomPage : Page
    {
        Hotel hotel;
        Room room;
        bool edit = false;
        public RoomPage(Room room = null, Hotel hotel = null)
        {
            InitializeComponent();
            if (room != null)
            {
                edit = true;
                this.room = room;
                hotelCb.SelectedItem = room.Hotel;
                stateCb.SelectedItem = room.State;
                categoryCb.SelectedItem = room.Categoty;
            }
            else
            {
                this.room = new Room();
                hotelCb.SelectedIndex = 0;
                stateCb.SelectedIndex = 0;
                categoryCb.SelectedIndex = 0;
            }

            main.DataContext = this.room;
            this.hotel = hotel;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {

            if (!edit)
            {
                if (Utils.db.Rooms.Select(a => a.Name).Contains(nameTb.Text))
                {
                    Utils.Error("Такой номер уже существует");
                    return;
                }
                Utils.db.Rooms.Add(room);
            }
            Utils.db.SaveChanges();
            NavigationService.GoBack();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            hotelCb.ItemsSource = Utils.db.Hotels.ToList();
            stateCb.ItemsSource = Utils.db.States.ToList();
            categoryCb.ItemsSource = Utils.db.Categories.ToList();
        }
    }
}
