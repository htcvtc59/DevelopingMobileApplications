using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SqlLiteWinPhone.ContactDataContext;

namespace SqlLiteWinPhone
{
    class AddNewFunction
    {
        public void AddNew(string name, string phone)
        {
            using (ContactDataContext context = new
                ContactDataContext(ContactDataContext.DBConnectionString))
            {
                Contact c = new Contact();
                c.name = name;
                c.phone = phone;
                context.Contacts.InsertOnSubmit(c);
                context.SubmitChanges();
            }
        }


        public void AddNewMessage(string idcontact, string message)
        {
            using (ContactDataContext context = new
               ContactDataContext(ContactDataContext.DBConnectionString))
            {
                ContactMessage c = new ContactMessage();
                c.contactid = idcontact;
                c.message = message;
                context.ContactMessages.InsertOnSubmit(c);
                context.SubmitChanges();
            }
        }

        public bool UpdateContact(string id,string name,string phone)
        {
            int i = 0;
            using (ContactDataContext context = new
              ContactDataContext(ContactDataContext.DBConnectionString))
            {
                Contact c = context.Contacts.SingleOrDefault(x => x.ID.ToString().Equals(id));
                c.name = name;
                c.phone = phone;
                context.SubmitChanges();
                i = 1;
            }
            return i == 1;
        }

        public bool DeleteContact(string id)
        {
            int i = 0;
            using (ContactDataContext context = new
              ContactDataContext(ContactDataContext.DBConnectionString))
            {
                ContactMessage cm = context.ContactMessages.FirstOrDefault(x => x.contactid.Equals(id));
                Contact c = context.Contacts.FirstOrDefault(x => x.ID.ToString().Equals(id));
                context.ContactMessages.DeleteOnSubmit(cm);
                context.Contacts.DeleteOnSubmit(c);
                context.SubmitChanges();
                i = 1;
            }
            return i == 1;
        }

    }
}
