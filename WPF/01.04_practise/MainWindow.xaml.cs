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
            this.AuthorList.Add(new Author {  FirstName = "Mark", LastName = "Twain",
                BirthDate = new DateTime(1835, 11, 30), Country = "USA", Language = "English", PlaceOfBirth = "Florida, Missouri",
                IsNew = false, BooksList = new ObservableCollection<Book>()});
            this.AuthorList[0].BooksList.Add(new Book {Title="Tom Soyer", Date = new DateTime(2019,05,21), Cost = 52.62m });

            this.AuthorLV.DataContext = this.AuthorList;
            
           
        }
    }
}
