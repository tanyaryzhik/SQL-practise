using _01._04_practise.Model;
using _01._04_practise.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _01._04_practise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public ObservableCollection<Author> AuthorList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.AuthorList = new ObservableCollection<Author>();
            this.AuthorList.Add(new Author
            {
                FirstName = "Mark",
                LastName = "Twain",
                BirthDate = new DateTime(1835, 11, 30),
                Country = Country.USA,
                Language = Model.Language.English,
                PlaceOfBirth = "Florida, Missouri",
                IsNew = false,
                BooksList = new ObservableCollection<Book>()
            });
            this.AuthorList[0].BooksList.Add(new Book { Title = "Tom Soyer", Date = new DateTime(2019, 05, 21),
                Cost = 52.62m, IsNew = false, Language = Model.Language.English, IsRead = true });

            this.AuthorLV.DataContext = this.AuthorList;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FrameworkElement fe = e.Source as FrameworkElement;
            if (fe.Name == "NewAuthorButton" || fe.Name == "AuthorLV")
            {
                Author author = new Author();
                var authorWindow = new AuthorWindow() { DataContext = author };
                authorWindow.Owner = this;
                authorWindow.ShowDialog();
                if (!authorWindow.DialogResult.Value)
                    return;
                author.IsNew = false;
                author.BooksList = new ObservableCollection<Book>();
                this.AuthorList.Add(author);
            }
            else if (fe.Name == "NewBookButton" || fe.Name == "BooksDG")
            {
                Book book = new Book();
                var bookWindow = new BookWindow() { DataContext = book };
                bookWindow.Owner = this;
                bookWindow.ShowDialog();
                if (!bookWindow.DialogResult.Value)
                    return;

                var selectedAuthor = this.AuthorLV.SelectedItem as Author;
                book.IsNew = false;
                selectedAuthor.BooksList.Add(book);
                this.BooksDG.Items.Refresh();
            }
        }

        private void DeleteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FrameworkElement fe = e.Source as FrameworkElement;
            if (this.AuthorLV.SelectedItem != null && (fe.Name == "DeleteAuthorButton" || fe.Name == "AuthorLV"))
            {
                this.AuthorList.Remove(this.AuthorLV.SelectedItem as Author);
            }
            else if (this.BooksDG.SelectedItem != null && (fe.Name == "DeleteBookButton" || fe.Name == "BooksDG"))
            {
                var selectedAuthor = this.AuthorLV.SelectedItem as Author;
                selectedAuthor.BooksList.Remove(this.BooksDG.SelectedItem as Book);
            }
        }

        private void ChangeCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FrameworkElement fe = e.Source as FrameworkElement;
            if (fe.Name == "ChangeAuthorButton" || fe.Name == "AuthorLV")
            {
                Author author = this.AuthorLV.SelectedItem as Author;
                Author tempAuthor = new Author
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    BirthDate = author.BirthDate,
                    Country = author.Country,
                    Language = author.Language,
                    PlaceOfBirth = author.PlaceOfBirth
                };
                var authorWindow = new AuthorWindow() { DataContext = author };
                authorWindow.Owner = this;
                authorWindow.ShowDialog();
                if (authorWindow.DialogResult.Value)
                    return;
                author.FirstName = tempAuthor.FirstName;
                author.LastName = tempAuthor.LastName;
                author.BirthDate = tempAuthor.BirthDate;
                author.Country = tempAuthor.Country;
                author.Language = tempAuthor.Language;
                author.PlaceOfBirth = tempAuthor.PlaceOfBirth;
            }
            else if (fe.Name == "ChangeBookButton" || fe.Name == "BooksDG")
            {
                Book book = this.BooksDG.SelectedItem as Book;
                Book tempBook = new Book { Title = book.Title, Cost = book.Cost, Date = book.Date };
                var bookWindow = new BookWindow() { DataContext = book };
                bookWindow.Owner = this;
                bookWindow.ShowDialog();
                if (bookWindow.DialogResult.Value)
                    return;
                book.Title = tempBook.Title;
                book.Cost = tempBook.Cost;
                book.Date = tempBook.Date;
                this.BooksDG.Items.Refresh();
            }
        }

        private void GeneralCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.AuthorLV.SelectedItem != null || this.BooksDG.SelectedItem != null)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }
    }
}
