using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Demo2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContactList : Page
    {
        public List<Contact> Contacts { get; private set;} = new List<Contact>();
        public DataManager DataManager = new DataManager();

        public ContactList()
        {
            
            Contacts = DataManager.GetAllContacts();

            this.InitializeComponent();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            string contactId = ((Button)sender).Tag.ToString();
            DataManager.DeleteContact(contactId);
            this.Frame.Navigate(typeof(ContactList));

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            string contactId = ((Button)sender).Tag.ToString();
            this.Frame.Navigate(typeof(AddContact), contactId);
        }
    }
}
