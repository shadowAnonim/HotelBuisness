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
    /// Логика взаимодействия для GuestPage.xaml
    /// </summary>
    public partial class GuestPage : Page
    {
        Guest guest;
        bool edit = false;
        public GuestPage(Guest guest = null)
        {
            InitializeComponent();
            if (guest != null)
            {
                edit = true;
                this.guest = guest;
            }
            else
            {
                this.guest = new Guest();
            }
            main.DataContext = this.guest;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Utils.checkPhone(phoneTb.Text))
                {
                    Utils.Error("Неверный формат телефона");
                    return;
                }
                if (!edit)
                {
                    Utils.db.Guests.Add(guest);
                }
                Utils.db.SaveChanges();
            }
            catch(Exception ex)
            {
                Utils.Error(ex.Message);
            }
            NavigationService.GoBack();
        }
    }
}
