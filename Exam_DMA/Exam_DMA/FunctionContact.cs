using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exam_DMA.ContactDataContext;

namespace Exam_DMA
{
    public class FunctionContact
    {
        public void AddContact(string name, int number, string group)
        {
            using (ContactDataContext context = new
                ContactDataContext(ContactDataContext.DBConnectionString))
            {
                Contact c = new Contact();
                c.name = name;
                c.number = number;
                c.group = group;
                context.Contacts.InsertOnSubmit(c);
                context.SubmitChanges();
            }
        }
        private IList<Contact> GetAllContact(string name)
        {
            using (ContactDataContext context = new ContactDataContext(ContactDataContext.DBConnectionString))
            {
                IQueryable<Contact> query = null;
                if (name.Length == 0)
                {
                    query = from c in context.Contacts orderby c.name ascending select c;

                }
                else
                {
                    query = from c in context.Contacts orderby c.name ascending where c.name.Contains(name) select c;
                }
                return query.ToList();
            }
        }
        public bool CheckExist(string name)
        {
            ObservableCollection<ContactDetail> list =  GetContact();
            ContactDetail c = list.SingleOrDefault(x => x.name.Equals(name));
            return c != null;
        }

        public ObservableCollection<ContactDetail> GetContact()
        {
            IList<Contact> list = this.GetAllContact("");
            ObservableCollection<ContactDetail> result = new ObservableCollection<ContactDetail>();
            foreach (Contact item in list)
            {
                ContactDetail c = new ContactDetail();
                c.id = item.ID.ToString();
                c.name = item.name;
                c.number = item.number;
                c.group = item.group;
                result.Add(c);
            }
            return result;

        }




    }
    public class ContactDetail
    {
        public string id { get; set; }
        public string name { get; set; }
        public int number { get; set; }
        public string group { get; set; }

    }
}
