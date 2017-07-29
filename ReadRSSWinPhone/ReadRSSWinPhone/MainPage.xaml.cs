using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ReadRSSWinPhone.Resources;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace ReadRSSWinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            loadxml();

        }
        void loadxml()
        {
            ObservableCollection<NewYorkTime> lstNYT = NewYorkTime.listNewYT;
            gridviewNYT.ItemsSource = lstNYT;
            imgHomePage.Source = new BitmapImage(new Uri(NewYorkTime.GetImaggeHome().imgHome));
        }

        private void btnBackHome_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<NewYorkTime> lstNYT = NewYorkTime.listNewYT;
            gridviewNYT.ItemsSource = lstNYT;
            gridHomePage.Visibility = Visibility.Visible;
            gridPageItem.Visibility = Visibility.Collapsed;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<NewYorkTime> lstNYT = NewYorkTime.listNewYT;
            gridviewNYT.ItemsSource = lstNYT;
            gridHomePage.Visibility = Visibility.Visible;
            gridPageItem.Visibility = Visibility.Collapsed;
        }

        private void gridviewNYT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var myItem = ((LongListSelector)sender).SelectedItem as NewYorkTime;
            gridHomePage.Visibility = Visibility.Collapsed;
            gridPageItem.Visibility = Visibility.Visible;
            webviewItem.Source = new Uri(myItem.itemlink);
        }

        
    }
}