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
    public partial class SearchContact : PhoneApplicationPage
    {
        public SearchContact()
        {
            InitializeComponent();
        }

        private void btnS_Click(object sender, RoutedEventArgs e)
        {
            FeetContact f = new FeetContact();
            lstContactsS.ItemsSource = f.SearchContact(txtS.Text);

        }
    }
}