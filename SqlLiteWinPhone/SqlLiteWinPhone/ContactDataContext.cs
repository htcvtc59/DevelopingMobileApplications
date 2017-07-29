using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteWinPhone
{
    public class ContactDataContext : DataContext
    {
        public static string DBConnectionString = @"isostore:/Contact.sdf";
        public ContactDataContext(string strconnection) : base(strconnection)
        {

        }

        public Table<Contact> Contacts
        {
            get { return this.GetTable<Contact>(); }
        }

        public Table<ContactMessage> ContactMessages
        {
            get { return this.GetTable<ContactMessage>(); }
        }

        [Table]
        public class ContactMessage
        {
            [Column(IsDbGenerated = true, IsPrimaryKey = true)]
            public int ID
            {
                get;
                set;
            }
            [Column]
            public string contactid
            {
                set;
                get;
            }
            [Column]
            public string message
            {
                set;
                get;
            }
        }



        [Table]
        public class Contact
        {
            [Column(IsDbGenerated = true, IsPrimaryKey = true)]
            public int ID
            {
                get;
                set;
            }
            [Column]
            public string name
            {
                set;
                get;
            }
            [Column]
            public string phone
            {
                set;
                get;
            }
        }
    }
}
