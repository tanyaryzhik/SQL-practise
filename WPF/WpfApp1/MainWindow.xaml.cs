﻿using System;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CommandBinding commandBinding = new CommandBinding(MyCommands.Write);           
            commandBinding.Executed += commandBinding_Executed;
            this.CommandBindings.Add(commandBinding);

            //var bind = new CommandBinding(ApplicationCommands.Open);
            //bind.Executed += Bind_Executed;
            //bind.CanExecute += Bind_CanExecute;
            //this.CommandBindings.Add(bind);
            //var checkBoxBind = new CommandBinding(MyCommands.ChangeButtonStatus);
            //checkBoxBind.Executed += CheckBox_Executed;
            //this.CommandBindings.Add(checkBoxBind);
        }

        private void commandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Button feSource = e.Source as Button;
            txtBx.Text = e.Source.c;
        }
    }

    public static class MyCommands
    {
        public static RoutedCommand Write { get; set; }

        static MyCommands()
        {
            Write = new RoutedCommand(nameof(Write), typeof(Grid));
        }
    }
}
