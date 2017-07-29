using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SqlLiteWinPhone.Resources;

namespace SqlLiteWinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            using (ContactDataContext context = new
                ContactDataContext(ContactDataContext.DBConnectionString))
            {
                if (!context.DatabaseExists())
                    context.CreateDatabase();

            }


        }

        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddNewContact.xaml", UriKind.Relative));

        }

        private void ViewContact_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewContact.xaml", UriKind.Relative));
        }

        private void SearchContact_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SearchContact.xaml", UriKind.Relative));
        }

        private void ViewJoin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewJoinTable.xaml", UriKind.Relative));
        }
    }
}