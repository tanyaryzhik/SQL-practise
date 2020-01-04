using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _01._04_practise
{
    public static class MyCommands
    {
        public static RoutedCommand Show { get; set; }

        static MyCommands()
        {
            MyCommands.Show = new RoutedCommand(nameof(Show), typeof(MainWindow));
        }

    }
}
