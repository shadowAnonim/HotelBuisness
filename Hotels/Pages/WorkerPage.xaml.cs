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
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        Worker worker;
        bool edit = false;
        public WorkerPage(Worker worker = null)
        {
            InitializeComponent();
            if (worker != null)
            {
                edit = true;
                this.worker = worker;
                workCb.SelectedItem = worker.Work;
            }
            else
            {
                this.worker = new Worker();
                workCb.SelectedIndex = 0;
            }

            main.DataContext = this.worker;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {

            if (!edit)
            {
                Utils.db.Workers.Add(worker);
            }
            Utils.db.SaveChanges();
            NavigationService.GoBack();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            workCb.ItemsSource = Utils.db.WorkTypes.ToList();
        }
    }
}
