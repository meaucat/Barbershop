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
using Barbershop.DB;

namespace Barbershop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public static List<Employee> employees { get; set; }
        public Authorization()
        {
            InitializeComponent();
        }

        private void SwitchRegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/Registration.xaml", UriKind.Relative));
        }

        private void AuthActionBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();

            employees = new List<Employee>(DBConnection.barberShopEnt.Employee.ToList());
            Employee currentUser = employees.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (currentUser != null)
                NavigationService.Navigate(new Main());
            else
                MessageBox.Show("Что-то введено неверно. Попробуйте снова");
        }
    }
}
