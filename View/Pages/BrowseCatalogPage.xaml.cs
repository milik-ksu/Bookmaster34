using Bookmaster34.Models;
using System.Windows;
using System.Windows.Controls;
using static Azure.Core.HttpHeader;

namespace Bookmaster34.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BrowseCatalogPage.xaml
    /// </summary>
    public partial class BrowseCatalogPage : Page
    {

        //Создадим список для вытягивания данных из таблиц
        private readonly List<Book> _bookAuthors;

        private Book _selectedBook;
        public BrowseCatalogPage()
        {
            InitializeComponent();

            //Заполняем локальный список
            _bookAuthors = App.GetContext().Books.ToList();

            LoadData();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorsLv.ItemsSource = _bookAuthors.Where(book => book.Title.ToLower().Contains(NameTb.Text.ToLower()) &&
                                               book.Authors.ToLower().Contains(AuthorsTb.Text.ToLower()) &&
                                               book.Subtitle.ToLower().Contains(SubjectTb.Text.ToLower()))
                                               .ToList();
        }

        private void PriviousPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadData()
        {
            BookAuthorsLv.ItemsSource = _bookAuthors;
        }

        private void PreviousPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BookAutorsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedBook = (Book)BookAuthorsLv.SelectedItem;

            BookDetailsGrid.DataContext = _selectedBook;
        }

        private void BookAutorsDetailisHl_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}