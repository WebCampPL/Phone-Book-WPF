using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoneBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Contact> contacts = new List<Contact>();
        public MainWindow()
        {
            InitializeComponent();
            ContactsListBox.ItemsSource = contacts;
        }

        private void DeleteContact(object sender, RoutedEventArgs e)
        {
            if (ContactsListBox.SelectedItem != null)
            {
                contacts.Remove((Contact)ContactsListBox.SelectedItem);
                AppRefresh();
            }
        }

        private void OpenAddContact(object sender, RoutedEventArgs e)
        {
            var addContactWindow = new AddContactWindow();
            if(addContactWindow.ShowDialog() == true)
            {
                contacts.Add(addContactWindow.NewContact);
                AppRefresh();
            }
        }

        private void SearchContact(object sender, RoutedEventArgs e)
        {
            var searchText = SearchTextBox.Text;
            var searchResult = contacts.Where(k => k.FirstName.ToLower().Contains(searchText.ToLower()) 
            || k.SecondName.ToLower().Contains(searchText.ToLower())
            || k.PhoneNumber.ToLower().Contains(searchText.ToLower())).ToList();
            ContactsListBox.ItemsSource = searchResult;
            ContactsListBox.Items.Refresh();
        }
        private void AppRefresh()
        {
            ContactsListBox.ItemsSource = contacts;
            ContactsListBox.Items.Refresh();
            SearchTextBox.Text = "";
        }
    }
}