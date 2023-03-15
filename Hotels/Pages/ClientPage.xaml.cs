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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        Client client;
        bool edit = false;

        public ClientPage(Client client = null)
        {
            InitializeComponent();
            if (client != null)
            {
                edit = true;
                this.client = client;
                typeCb.SelectedItem = client.Type;
            }
            else
            {
                this.client = new Client();
                typeCb.SelectedIndex = 0;
            }

            main.DataContext = this.client;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!edit)
            {
                Utils.db.Clients.Add(client);
            }
            Utils.db.SaveChanges();
            NavigationService.GoBack();
        }
        
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            typeCb.ItemsSource = Utils.db.ClientTypes.ToList();
        }
    }
}
