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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Page
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void AddServiceButton_Click(object sender, RoutedEventArgs e)
        {
            string clientName = NameClientTextBox.Text.Trim();
            string clientSurname = LastNameTextBox.Text.Trim();
            string clientPatronymic = PatronymicTextBox.Text.Trim();
            string room = RoomTextBox.Text.Trim();

            if (clientName != null && clientSurname != null && clientPatronymic != null && room != null)
            {
                MessageBox.Show("Успешно добавлен клиент");

                Client client = new Client();
                client.NameClient = clientName;
                client.LastName = clientSurname;
                client.Patronymic = clientPatronymic;
                client.IDRoom = int.Parse(room);
                DBConnection.barberShopEnt.Client.Add(client);
                DBConnection.barberShopEnt.SaveChanges();
            }
            else
                MessageBox.Show("Вы ввели что-то неверно");
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Main());
        }
    }
}
