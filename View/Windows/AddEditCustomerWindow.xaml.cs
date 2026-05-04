using Bookmaster34.AppData;
using Bookmaster34.Models;
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
using System.Windows.Shapes;

namespace Bookmaster34.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditCustomerWindow.xaml
    /// </summary>
    public partial class AddEditCustomerWindow : Window
    {
        private List<City> _cities;
        public AddEditCustomerWindow()
        {
            InitializeComponent();
            _cities = App.GetContext().Cities.ToList();

            LoadCities();

            Title = "Добавление читателя";
            AddBtn.Visibility = Visibility.Visible;
            EditBtn.Visibility = Visibility.Collapsed;

            IDclientTb.Text = GenerateId();
        }
        public AddEditCustomerWindow(Customer selectedCustomer)
        {
            InitializeComponent();

            _cities = App.GetContext().Cities.ToList();

            LoadCities();

            Title = "Редактирование читателя";
            AddBtn.Visibility = Visibility.Collapsed;
            EditBtn.Visibility = Visibility.Visible;

            DataContext = selectedCustomer;
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer();
        }



        private void AddCustomer()
        {
            try
            {
                // Проверяем заполнение всех полей
                if (string.IsNullOrWhiteSpace(ClientNameTb.Text) ||
                string.IsNullOrWhiteSpace(IDclientTb.Text) ||
                string.IsNullOrWhiteSpace(AddressClientTb.Text) ||
                string.IsNullOrWhiteSpace(EmailCustomerTb.Text) ||
                string.IsNullOrWhiteSpace(PhoneCustomerTb.Text))

                {
                    FeedbackService.Warning("Заполните все поля!");
                }

                else
                {
                    // При заполнении всех полей реализуем добавление.
                    Customer newCustomer = new Customer()
                    {
                        Id = IDclientTb.Text,
                        Name = ClientNameTb.Text,
                        Address = AddressClientTb.Text,
                        CityId = (int)ZipCityCb.SelectedValue,
                        Phone = PhoneCustomerTb.Text,
                        Email = EmailCustomerTb.Text,
                        Zip = ZipCityTb.Text
                    };
                    App.GetContext().Customers.Add(newCustomer);

                    App.GetContext().SaveChanges();
                    FeedbackService.Information("Читатель успешно добавлен!");
                    DialogResult = true;
                }
            }
            catch (Exception exception)
            {
                FeedbackService.Error(exception);
            }
        }

        private void LoadCities()
        {
            ZipCityCb.ItemsSource = _cities;
        }

        private void ZipCityTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ZipCityCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EditCustomer()
        {
            try
            {
                App.GetContext().SaveChanges();
                FeedbackService.Information("Данные читателя успешно изменены!");

            }
            catch (Exception ex)
            {
                FeedbackService.Error(ex);
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            EditCustomer();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer();
        }

        private string GenerateId()
        {
            int lastId = Convert.ToInt32(App.GetContext().Customers.Max(x => x.Id).Substring(1));
            ++lastId;
            return $"C{lastId}";
        }
    }
}
