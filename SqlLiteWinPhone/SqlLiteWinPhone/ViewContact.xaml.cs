using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace SqlLiteWinPhone
{
    public partial class ViewContact : PhoneApplicationPage
    {
        public ViewContact()
        {
            InitializeComponent();
            FeetContact f = new FeetContact();
            lstContacts.ItemsSource = f.GetContact();
        }

        private void lstContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string id = (lstContacts.SelectedItem as ContactDetail).id;
            NavigationService.Navigate(new Uri("/UpdateDelete.xaml?idmsg="+id, UriKind.Relative));
        }

       
    }
}