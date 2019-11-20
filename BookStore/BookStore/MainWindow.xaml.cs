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

namespace BookStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int count = 0;
        public ObservableCollection<Book> BooksList { get; set; }
        public MainWindow()
        {
            this.BooksList = new ObservableCollection<Book>();
            InitializeComponent();
        }

        private void OnAddButton_Click(object sender, RoutedEventArgs e)
        {
            //this.BooksList.Add(DecodeStringToBook(this.EnteredBook.Text));
            this.BooksData.Items.Add(DecodeStringToBook(this.EnteredBook.Text));
        }

        private Book DecodeStringToBook(string enteredBook)
        {
            string[] stringArr = new string[4];
            stringArr = enteredBook.Split(';');
            Book book = new Book { Id = count
                , Author = stringArr[0]
                ,Title = stringArr[1]
                , Genre = stringArr[2]
                , Price = Convert.ToDecimal(stringArr[3])};
            count++;
            return book;
        }

        private void BooksData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            this.BooksData.Items.Remove(this.BooksData.SelectedItem);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            this.BooksData.Items.Clear();
        }
    }
}
