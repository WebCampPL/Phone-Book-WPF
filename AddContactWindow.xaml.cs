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
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace PhoneBook
{
    /// <summary>
    /// Logika interakcji dla klasy AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        public Contact NewContact { get; set; }
        public AddContactWindow()
        {
            InitializeComponent();
        }
        private void AddContact(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FirstNameTextBox.Text)
                || string.IsNullOrWhiteSpace(FirstNameTextBox.Text)
                || string.IsNullOrEmpty(SecondNameTextBox.Text)
                || string.IsNullOrWhiteSpace(SecondNameTextBox.Text)
                || string.IsNullOrEmpty(PhoneNumberTextBox.Text)
                || string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text))
            {
                MessageBox.Show("Wypełnij wszystkie pola");
                return;
            }
            else
            { 
                NewContact = new Contact
                {
                    FirstName = FirstNameTextBox.Text,
                    SecondName = SecondNameTextBox.Text,
                    PhoneNumber = PhoneNumberTextBox.Text
                };
                DialogResult = true;
            }
        }
    }
}
