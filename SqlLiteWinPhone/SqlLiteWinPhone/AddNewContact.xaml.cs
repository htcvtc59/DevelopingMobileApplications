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
    public partial class AddNewContact : PhoneApplicationPage
    {
        public AddNewContact()
        {
            InitializeComponent();
            ListContact();
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            FeetContact feed = new FeetContact();
            if (feed.CheckExist(name))
            {
                MessageBox.Show("this name is exist", "error", MessageBoxButton.OK);
            }
            else
            {
                string phone = txtPhone.Text;
                AddNewFunction add = new AddNewFunction();
                add.AddNew(name, phone);
                MessageBox.Show("add success", "error", MessageBoxButton.OK);

            }

        }
        void ListContact()
        {
            FeetContact feed = new FeetContact();
            if (feed.GetContact().Count!=0)
            {
                List<ContactDetail> list = feed.GetContact();
                listContact.ItemsSource = list;
                
            }

        }
        
        private void btnAddMes_Click(object sender, RoutedEventArgs e)
        {
            string id = (listContact.SelectedItem as ContactDetail).id;
            string mes = txtMes.Text;
            AddNewFunction add = new AddNewFunction();
            add.AddNewMessage(id, mes);
            MessageBox.Show("add mes success", "error", MessageBoxButton.OK);

        }
    }
}