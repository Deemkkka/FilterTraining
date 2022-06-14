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

namespace FilterTraining
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        User[] Users = new User[]
            {
                new User("Petr", "Russia", "1"),
                new User("Petr2", "Russia", "2"),
                new User("Petr3", "Russia", "1"),
                new User("Petr4", "Russia", "3"),
                new User("Petr5", "Russia", "1"),
                new User("Petr6", "Russia", "2"),
                new User("Petr7", "Russia", "1"),
                new User("Petr8", "Russia", "1"),
                new User("Petr9", "Russia", "5"),
                new User("Petr10", "Russia", "1"),
                new User("Petr11", "Russia", "4"),
                new User("Petr12", "Russia", "1")
            };

        public MainWindow()
        {
            InitializeComponent();

            myListView.ItemsSource = Users;

            FilterComboBox.ItemsSource = new string[] { "Name", "Country", "Status" };
        }
    }
}
