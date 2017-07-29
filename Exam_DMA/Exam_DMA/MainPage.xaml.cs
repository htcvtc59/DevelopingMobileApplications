using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Exam_DMA.Resources;

namespace Exam_DMA
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void btnAddContact_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FunctionContact func = new FunctionContact();
                string name = txtName.Text;
                if (func.CheckExist(name))
                {
                    MessageBox.Show("Contact Name duplicate", "Warning", MessageBoxButton.OK);

                }
                else
                {
                    int number = Convert.ToInt32(txtNumber.Text);
                    string group = (cbbGroup.SelectedItem as ListPickerItem).Content.ToString();
                    func.AddContact(name, number, group);
                    MessageBox.Show("Add success", "Warning", MessageBoxButton.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Add Fail", "Error", MessageBoxButton.OK);
            }


        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewContact.xaml", UriKind.Relative));
        }


    }
}