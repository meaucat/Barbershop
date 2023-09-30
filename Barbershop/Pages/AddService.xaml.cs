using Barbershop.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Barbershop.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddService.xaml
    /// </summary>
    public partial class AddService : Page
    {
        public static List<Service> services { get; set; }
        public AddService()
        {
            InitializeComponent();
            services = new List<Service>(DBConnection.barberShopEnt.Service.ToList());
            this.DataContext = this;
        }

        private void AddServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            string serviceName = NameServiceTextBox.Text.Trim();
            string cost = CostTextBox.Text.Trim();
            if (serviceName != null && cost != null)
            {
                MessageBox.Show("Успешно добавлена услуга, обновите страницу");
                Service service = new Service();
                service.NameService = serviceName;
                service.Cost = decimal.Parse(cost);
                DBConnection.barberShopEnt.Service.Add(service);
                DBConnection.barberShopEnt.SaveChanges();
                //this.ServiceList.Items.Refresh();
            }
            else
                MessageBox.Show("Вы ввели что-то неправильно");
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Main());
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddService());
        }
    }
}
