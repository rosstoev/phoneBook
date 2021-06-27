using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Demo2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {

            this.InitializeComponent();
            MainFrame.Navigate(typeof(ContactList));
        }

        private void NavInvokeItem(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            TextBlock textContent = args.InvokedItem as TextBlock;

            if (textContent != null)
            {
                switch (textContent.Tag)
                {
                    case "Nav_List":
                        MainFrame.Navigate(typeof(ContactList));
                        break;
                    case "Nav_Add":
                        MainFrame.Navigate(typeof(AddContact));
                        break;
                    
                }
            }
        }
    }
}
