using Practise_25._01.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise_25._01.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }
        public Customer SelectedCustomer { get; set; }

        public MainWindowViewModel()
        {
            this.Customers = new ObservableCollection<Customer> {
                new Customer {FirstName = "Ivan", LastName = "Ivanoff", Country = "Russia" },
            new Customer {FirstName = "Jason", LastName = "Smith", Country = "USA"  }};

        }
    }
}
