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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bookmaster34.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BrowseCatalogPage.xaml
    /// </summary>
    public partial class BrowseCatalogPage : Page
    {
        // Создаем локальный список для единого разового вытягивания данных из таблицы БД
        private void readonly List<BookAuthor> _bookAuthors;
        public BrowseCatalogPage()
        {
            InitializeComponent();

            _bookAuthors = App.GetContext().BookAuthors.ToList();
            LoadData();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PreviousPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadData()
        {
            BookAuthorLv.ItemsSource = _bookAuthors;
        }
    }
}
