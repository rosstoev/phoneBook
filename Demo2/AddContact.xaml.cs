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
    public sealed partial class AddContact : Page
    {
        public DataManager DataManager { get; private set; } = new DataManager();
        public AddContact()
        {
            this.InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            string phoneNumber = PhoneNumber.Text;
            string contactId;
            if (!string.IsNullOrEmpty(ContactId.Text))
            {
                contactId = ContactId.Text;
                DataManager.EditContact(contactId, name, phoneNumber);

            } else
            {
                DataManager.SaveContact(name, phoneNumber);
            }

            ContactId.Text = string.Empty;
            Name.Text = string.Empty;
            PhoneNumber.Text = string.Empty;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!string.IsNullOrEmpty((string)e.Parameter))
            {
                string contactId = (string)e.Parameter;
                Contact contact = DataManager.GetContactById(contactId);
                ContactId.Text = contact.Id.ToString();
                Name.Text = contact.Name;
                PhoneNumber.Text = contact.Phone;

            }
        }

    }
}
