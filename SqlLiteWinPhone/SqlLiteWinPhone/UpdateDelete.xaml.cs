using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using static SqlLiteWinPhone.ContactDataContext;

namespace SqlLiteWinPhone
{
    public partial class UpdateDelete : PhoneApplicationPage
    {
        public UpdateDelete()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (new AddNewFunction().UpdateContact(txtName.Tag.ToString(), txtName.Text, txtPhone.Text))
            {
                MessageBox.Show("Update");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (new AddNewFunction().DeleteContact(txtName.Tag.ToString()))
            {
                MessageBox.Show("Delete");
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string idmsg = "";
            if (NavigationContext.QueryString.TryGetValue("idmsg", out idmsg))
            {
                FeetContact f = new FeetContact();
                Contact c = f.ViewContact(idmsg);
                txtName.Tag = c.ID;
                txtName.Text = c.name;
                txtPhone.Text = c.phone;
            }
        }
    }
}