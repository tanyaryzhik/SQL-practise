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
        public ObservableCollection<Book> BooksList { get; set; }
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
            }
            else if (fe.Name == "NewBookButton" || fe.Name == "NewBookMenu")
            {
                Book book = new Book();
                var bookWindow = new BookWindow() { DataContext = book };
                bookWindow.Owner = this;
                bookWindow.ShowDialog();
            }
        }

        private void DeleteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FrameworkElement fe = e.Source as FrameworkElement;
            if (this.AuthorLV.SelectedItem != null && (fe.Name == "DeleteAuthorButton" || fe.Name == "DeleteAuthorMenu"))
            {
                //this.AuthorList.Remove(Author author, author => author = this.AuthorLV.SelectedItem);
            }
            else if (this.BooksDG.SelectedItem != null)
            {

            }
        }

        private void ChangeCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

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
