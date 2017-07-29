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
    public partial class ViewJoinTable : PhoneApplicationPage
    {
        public ViewJoinTable()
        {
            InitializeComponent();
            viewT();
        }




        void viewT()
        {
            List<TableJoin> list = getList();
            listJoin.ItemsSource = list;
        }

        List<TableJoin> getList()
        {
            List<TableJoin> list = new List<TableJoin>();
            using (ContactDataContext context = new ContactDataContext(ContactDataContext.DBConnectionString))
            {
              var  model = from c in context.Contacts.ToList()
                        orderby c.ID
                        join m in context.ContactMessages.ToList()
                        on c.ID.ToString() equals m.contactid into mgroup
                        select new 
                        {
                            Contact = new Contact()
                            {
                                ID = c.ID,
                                name = c.name,
                                phone = c.phone
                            },
                            ContactMessage = from mes in mgroup orderby mes.ID select mes
                        };

                foreach (var item in model)
                {
                    TableJoin t = new TableJoin();
                    t.id = item.Contact.ID.ToString();
                    t.name = item.Contact.name;
                    t.phone = item.Contact.phone;
                    foreach (var item1 in item.ContactMessage)
                    {
                        t.message += item1.message+" ";
                    }
                    list.Add(t);
                }

                return list;
            }
        }
    }

  class TableJoin
    {
        public string id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string message { get; set; }
    }
}