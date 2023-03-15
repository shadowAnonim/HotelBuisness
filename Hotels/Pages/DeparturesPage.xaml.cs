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
    /// Логика взаимодействия для DeparturesPage.xaml
    /// </summary>
    public partial class DeparturesPage : Page
    {
        public DeparturesPage()
        {
            InitializeComponent();
        }

        private void fillDataGrid()
        {
            List<Departure> departures = Utils.db.Departures.Include(d => d.Room).ThenInclude(r => r.Hotel).Include(d => d.Booking).ToList();

            roomsDg.ItemsSource = departures;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            fillDataGrid();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
