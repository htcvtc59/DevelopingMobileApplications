using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using static ASM_DMA.ContactDataContext;

namespace ASM_DMA
{
    public class FunctionContact
    {
        public void AddContact(string name, string phone, string group, string avatar)
        {
            using (ContactDataContext context = new
                ContactDataContext(ContactDataContext.DBConnectionString))
            {
                Contact c = new Contact();
                c.name = name;
                c.phone = phone;
                c.group = group;
                c.avatar = avatar;
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
                    query = from c in context.Contacts select c;

                }
                else
                {
                    query = from c in context.Contacts where c.name.Contains(name) select c;
                }
                return query.ToList();
            }
        }

        public async Task<List<ContactDetail>> GetContact()
        {
            IList<Contact> list = this.GetAllContact("");
            List<ContactDetail> result = new List<ContactDetail>();
            foreach (Contact item in list)
            {
                ContactDetail c = new ContactDetail();
                c.id = item.ID.ToString();
                c.name = item.name;
                c.phone = item.phone;
                c.group = item.group;
                c.avatar = await bitmap(item.avatar);
                result.Add(c);
            }
            return result;

        }

        public async Task<List<ContactDetail>> SearchContact(string name)
        {
            IList<Contact> list = GetAllContact(name);
            List<ContactDetail> result = new List<ContactDetail>();
            foreach (Contact item in list)
            {
                ContactDetail c = new ContactDetail();
                c.id = item.ID.ToString();
                c.name = item.name;
                c.phone = item.phone;
                c.group = item.group;
                c.avatar = await bitmap(item.avatar);
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

        public async Task<bool> CheckExist(string name)
        {
            List<ContactDetail> list = await GetContact();
            ContactDetail c = list.SingleOrDefault(x => x.name.Equals(name));
            return c != null;
        }


        public async Task<BitmapImage> bitmap(string file)
        {
            StorageFile files = await StorageFile.GetFileFromPathAsync(file);
            BitmapImage bit;
            IRandomAccessStream fileStream = await files.OpenAsync(FileAccessMode.Read);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.SetSource(fileStream.AsStream());
            bit = bitmapImage;

            return bit;

        }

    }

    public class ContactDetail
    {
        public string id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string group { get; set; }
        public BitmapImage avatar { get; set; }

    }
}



