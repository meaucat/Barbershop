using Barbershop.DB;
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

namespace Barbershop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public static List<Client> clients { get; set; }
        public static List<Room> rooms { get; set; }
        public static List<Employee> employees { get; set; }
        public static List<Report> reports { get; set; }
        public static List<Service> services { get; set; }
        public Main()
        {
            InitializeComponent();
            clients = new List<Client>(DBConnection.barberShopEnt.Client.ToList());
            employees = new List<Employee>(DBConnection.barberShopEnt.Employee.ToList());
            reports = new List<Report>(DBConnection.barberShopEnt.Report.ToList());
            this.DataContext = this;
        }

        private void AddClientActionButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddClient());
        }

        private void LogoutActionButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        private void AddServiceActionButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddService());
        }
    }
}
