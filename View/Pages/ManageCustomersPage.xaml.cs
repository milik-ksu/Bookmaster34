using Bookmaster34.AppData;
using Bookmaster34.Models;
using Bookmaster34.View.Windows;
using Castle.Core.Resource;
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

namespace Bookmaster34.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManageCustomersPage.xaml
    /// </summary>
    public partial class ManageCustomersPage : Page
    {
        private  List<Customer> _Customers;

        private Customer _selectedCustomer;
        public ManageCustomersPage()
        {
            InitializeComponent();

           
            _Customers = App.GetContext().Customers.ToList();

            LoadData();

            // Привязка списка к ListView в XAML (CustomersLv)
            CustomerLv.ItemsSource = _Customers;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerLv.ItemsSource = _Customers.Where(customer => customer.Id.ToLower().Contains(CustomerIdTb.Text.ToLower()) &&
                                     customer.Name.Contains(CustomerNameTb.Text.ToLower())).ToList();

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Customer? selectedCustomer = CustomerLv.SelectedItem as Customer;

            if (selectedCustomer != null)
            {
                AddEditCustomerWindow addEditCustomerWindow = new AddEditCustomerWindow(selectedCustomer);
                addEditCustomerWindow.ShowDialog();
                CustomerLv.ItemsSource = _Customers = App.GetContext().Customers.ToList();
            }
            else
            {
                FeedbackService.Error("Невозможно открыть окно для редактирования читателя. Сначала выберите его из списка.");

                
            }

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditCustomerWindow addEditCustomerWindow = new AddEditCustomerWindow();
            if(addEditCustomerWindow.ShowDialog()== true)
            {
                CustomerLv.ItemsSource = _Customers = App.GetContext().Customers.ToList();
            }
        }

        private void CustomerLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedCustomer = (Customer)CustomerLv.SelectedItem;


        }
        private void LoadData()
        {
           
        }
    }
}