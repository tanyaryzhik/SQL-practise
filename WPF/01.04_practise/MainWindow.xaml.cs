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
            this.AuthorList[0].BooksList.Add(new Book { Title = "Tom Soyer", Date = new DateTime(2019, 05, 21), Cost = 52.62m });

            this.AuthorLV.DataContext = this.AuthorList;




        }



        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FrameworkElement fe = e.Source as FrameworkElement;
            if (fe.Name == "NewAuthorButton" || fe.Name == "NewAuthorMenu")
            {
                Author author = new Author();
                var authorWindow = new AuthorWindow() { DataContext = author };
                authorWindow.Owner = this;
                authorWindow.ShowDialog();
                if (!authorWindow.DialogResult.Value)
                    return;

                this.AuthorList.Add(author);
            }
            else if (fe.Name == "NewBookButton" || fe.Name == "NewBookMenu")
            {
                Book book = new Book();
                var bookWindow = new BookWindow() { DataContext = book };
                bookWindow.Owner = this;
                bookWindow.ShowDialog();
                if (!bookWindow.DialogResult.Value)
                    return;

                var selectedAuthor = this.AuthorLV.SelectedItem as Author;
                if (selectedAuthor.BooksList == null)
                    selectedAuthor.BooksList = new ObservableCollection<Book>();
                selectedAuthor.BooksList.Add(book);
                this.BooksDG.Items.Refresh();
            }
        }

        private void DeleteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FrameworkElement fe = e.Source as FrameworkElement;
            if (this.AuthorLV.SelectedItem != null && (fe.Name == "DeleteAuthorButton" || fe.Name == "DeleteAuthorMenu"))
            {
                this.AuthorList.Remove(this.AuthorLV.SelectedItem as Author);
            }
            else if (this.BooksDG.SelectedItem != null && (fe.Name == "DeleteBookButton" || fe.Name == "DeleteBookMenu"))
            {
                var selectedAuthor = this.AuthorLV.SelectedItem as Author;
                selectedAuthor.BooksList.Remove(this.BooksDG.SelectedItem as Book);
            }
        }

        private void ChangeCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FrameworkElement fe = e.Source as FrameworkElement;
            if (fe.Name == "ChangeAuthorButton" || fe.Name == "ChangeAuthorMenu")
            {
                Author author = new Author();
                var authorWindow = new AuthorWindow() { DataContext = author };
                authorWindow.Owner = this;
                authorWindow.ShowDialog();
            }
            else if (fe.Name == "ChangeBookButton" || fe.Name == "ChangeBookMenu")
            {
                Book book = new Book();
                var bookWindow = new BookWindow() { DataContext = book };
                bookWindow.Owner = this;
                bookWindow.ShowDialog();
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
