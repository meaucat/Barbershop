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
using System.Xml.Linq;

namespace Barbershop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public static List<Employee> employees { get; set; }
        public Registration()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();
            string name = NameTextBox.Text.Trim();
            string surname = SurnameTextBox.Text.Trim();
            string patronymic = PatronymicTextBox.Text.Trim();

            Employee employee = new Employee();
            employee.Login = login;
            employee.Password = password;
            employee.FirstName = name;
            employee.LastName = surname;
            employee.Patronymic = patronymic;
            DBConnection.barberShopEnt.Employee.Add(employee);
            DBConnection.barberShopEnt.SaveChanges();

            employees = new List<Employee>(DBConnection.barberShopEnt.Employee.ToList());
            Employee currentUser = employees.FirstOrDefault(x => x.Login == login && x.Password == password);

            NavigationService.Navigate(new Authorization());
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/Authorization.xaml", UriKind.Relative));
        }
    }
}
