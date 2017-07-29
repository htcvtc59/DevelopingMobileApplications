using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ContractDemoWinphone
{
    [DataContract]
    public class Contact
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string phone { get; set; }
        [DataMember]
        public string group { get; set; }
        [DataMember]
        public string gender { get; set; }

        public override string ToString()
        {
            return name + "#" + phone + "#" + group + "#" + gender + "\n";
        }
    }
}
