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
    /// Логика взаимодействия для CleanPage.xaml
    /// </summary>
    public partial class CleanPage : Page
    {
        Clean clean;
        public CleanPage(Clean clean)
        {
            InitializeComponent();
            this.clean = clean;


            main.DataContext = this.clean;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Utils.db.SaveChanges();
            NavigationService.GoBack();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            nameTb.ItemsSource = Utils.db.Workers.ToList();
            if (clean.CleanStateId > 1)
            {

            }
            stateCb.ItemsSource = Utils.db.CleanStates.Skip((int)clean.CleanStateId - 1).ToList();
        }
    }
}
