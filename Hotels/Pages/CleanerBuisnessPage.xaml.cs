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
    /// Логика взаимодействия для CleanerBuisnessPage.xaml
    /// </summary>
    public partial class CleanerBuisnessPage : Page
    {
        public CleanerBuisnessPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Worker> cleaners = Utils.db.Workers.Where(w => w.WorkId == 2).ToList();
            List<Clean> cleans = Utils.db.Cleans.ToList();
            List<CleanerBuisness> buisnesses = new List<CleanerBuisness>();
            foreach (Worker worker in cleaners)
            {
                CleanerBuisness buisness = new CleanerBuisness(worker,
                    cleans.Where(c => c.CleanStateId == 1 && c.Worker == worker).Count().ToString(),
                    cleans.Where(c => c.CleanStateId == 2 && c.Worker == worker).Count().ToString(),
                    cleans.Where(c => c.CleanStateId == 3 && c.Worker == worker).Count().ToString());
                buisnesses.Add(buisness);
            }
            roomsDg.ItemsSource = buisnesses;
        }
    }
}
