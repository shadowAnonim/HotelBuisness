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
    /// Логика взаимодействия для CleaningRequestPage.xaml
    /// </summary>
    public partial class CleaningRequestPage : Page
    {
        public CleaningRequestPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Room room = (((sender as Button).Parent as StackPanel).Parent as StackPanel).DataContext as Room;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            roomsList.ItemsSource = Utils.db.Rooms.ToList();
        }
    }
}
