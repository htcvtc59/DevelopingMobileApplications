using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_DMA
{
    public class ContactDataContext : DataContext
    {
        public static string DBConnectionString = @"isostore:/Contacts.sdf";
        public ContactDataContext(string strconnection) : base(strconnection)
        {
            if (false == this.DatabaseExists())
                this.CreateDatabase();
        }
        public Table<Contact> Contacts
        {
            get { return this.GetTable<Contact>(); }
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
            [Column]
            public string group
            {
                set;
                get;
            }
            [Column]
            public string avatar
            {
                set;
                get;
            }
        }
    }
}
