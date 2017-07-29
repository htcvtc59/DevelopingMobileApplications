using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SqlLiteWinPhone.ContactDataContext;

namespace SqlLiteWinPhone
{
    class FeetContact
    {
        private IList<Contact> GetAllContact(string name)
        {
            using (ContactDataContext context = new ContactDataContext(ContactDataContext.DBConnectionString))
            {
                IQueryable<Contact> query = null;
                if (name.Length == 0)
                {
                    query = from c in context.Contacts select c;

                }
                else
                {
                    query = from c in context.Contacts where c.name.Contains(name) select c;
                }
                return query.ToList();
            }
        }

        public bool CheckExist(string name)
        {
            List<ContactDetail> list = GetContact();
            ContactDetail c = list.SingleOrDefault(x => x.name.Equals(name));
            return c != null;
        }

        public List<ContactDetail> GetContact()
        {
            IList<Contact> list = this.GetAllContact("");
            List<ContactDetail> result = new List<ContactDetail>();
            foreach (Contact item in list)
            {
                ContactDetail c = new ContactDetail();
                c.id = item.ID.ToString();
                c.name = item.name;
                c.phone = item.phone;
                result.Add(c);
            }
            return result;

        }

        public List<ContactDetail> SearchContact(string name)
        {
            IList<Contact> list = GetAllContact(name);
            List<ContactDetail> result = new List<ContactDetail>();
            foreach (Contact item in list)
            {
                ContactDetail c = new ContactDetail();
                c.id = item.ID.ToString();
                c.name = item.name;
                c.phone = item.phone;
                result.Add(c);

            }
            return result;
        }

        public Contact ViewContact(string id)
        {
            using (ContactDataContext context = new ContactDataContext(DBConnectionString))
            {
                Contact c = context.Contacts.SingleOrDefault(x => x.ID.ToString().Equals(id));
                return c;
            }
        }

    }
    class ContactDetail
    {
        public string id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
    }
}
