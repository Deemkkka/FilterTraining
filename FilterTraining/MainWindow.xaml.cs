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

            //FilterComboBox.ItemsSource = new string[] { "Name", "Country", "Status" };

            FilterComboBox.ItemsSource = typeof(User).GetProperties().Select((o) => o.Name);

        }


        public Predicate<object> GetFilter()
        {
            switch (FilterComboBox.SelectedItem as string)
            {
                case "Name":
                    return NameFilter;
                case "Country":
                    return CountryFilter;
                case "Status":
                    return StatusName;                    
            }
            return NameFilter;
        }

        private bool NameFilter(object obj)
        {
            var FilterObj = obj as User;

            return FilterObj.Name.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private bool CountryFilter(object obj)
        {
            var FilterObj = obj as User;
            return FilterObj.Country.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private bool StatusName(object obj)
        {
            var FilterObj = obj as User;

            return FilterObj.Status.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FilterTextBox.Text == null)
            {
                myListView.Items.Filter = null;
            }
            else
            {
                myListView.Items.Filter = GetFilter();
            }
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myListView.Items.Filter = GetFilter();
        }
    }
}
