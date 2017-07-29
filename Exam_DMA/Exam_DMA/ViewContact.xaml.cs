using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Exam_DMA
{
    public partial class ViewContact : PhoneApplicationPage
    {
        public ViewContact()
        {
            InitializeComponent();
            LoadContact();
        }

        void LoadContact()
        {
            FunctionContact func = new FunctionContact();
            lstContacts.ItemsSource = func.GetContact();
        }
    }
}