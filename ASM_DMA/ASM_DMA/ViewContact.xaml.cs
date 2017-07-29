using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ASM_DMA
{
    public partial class ViewContact : PhoneApplicationPage
    {
        public ViewContact()
        {
            InitializeComponent();
            loadForm();
        }

        async void loadForm()
        {
            FunctionContact func = new FunctionContact();
            lstContacts.ItemsSource = await func.GetContact();
        }

        private async void btnS_Click(object sender, RoutedEventArgs e)
        {
            string search = txtS.Text;
            FunctionContact func = new FunctionContact();
            lstContacts.ItemsSource = await func.SearchContact(search);

        }

        private async void lstContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string id = (lstContacts.SelectedItem as ContactDetail).id;

            FunctionContact func = new FunctionContact();
            BitmapImage img = await func.bitmap(func.ViewContact(id).avatar);
            imgAvatar.Source = img;

        }
    }
}