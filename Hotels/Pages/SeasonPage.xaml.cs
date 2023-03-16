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
    /// Логика взаимодействия для SeasonPage.xaml
    /// </summary>
    public partial class SeasonPage : Page
    {
        DeadSeason season;
        bool edit = false;
        public SeasonPage(DeadSeason season = null)
        {
            InitializeComponent();
            if (season != null)
            {
                edit = true;
                this.season = season;
                hotelCb.SelectedItem = season.Hotel;
            }
            else
            {
                this.season = new DeadSeason();
                hotelCb.SelectedIndex = 0;
                this.season.StartDate = DateTime.Now;
                this.season.EndDate = DateTime.Now.AddDays(1);
            }

            main.DataContext = this.season;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            hotelCb.ItemsSource = Utils.db.Hotels.ToList();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!edit)
            {
                Utils.db.DeadSeasons.Add(season);
            }
            Utils.db.SaveChanges();
            NavigationService.GoBack();
        }
    }
}
