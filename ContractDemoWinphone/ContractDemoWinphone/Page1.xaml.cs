using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Storage;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace ContractDemoWinphone
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();

            //loadasyncfile();

            loadjsonfile();

        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //if (loaddatafile() != null)
            //{
            //    List<Contact> listcon = await loaddatafile();
            //    List<Contact> list = listcon.FindAll(x => x.name.Contains(txtNameS.Text));
            //    listlong.ItemsSource = list;
            //}
            //jspon
            if (readJson() != null)
            {
                List<Contact> listcon = await readJson();
                List<Contact> list = listcon.FindAll(x => x.name.Contains(txtNameS.Text));
                listlong.ItemsSource = list;
            }

        }

        async void loadasyncfile()
        {
            if (loaddatafile() != null)
            {
                List<Contact> list = await loaddatafile();
                listlong.ItemsSource = list;
            }

        }
        private async Task<List<Contact>> loaddatafile()
        {
            var local = Windows.Storage.ApplicationData.Current.LocalFolder;
            List<Contact> lstst = new List<Contact>();
            var file = await local.GetFileAsync("data.txt");
            IList<string> lines = await FileIO.ReadLinesAsync(file);
            foreach (var item in lines)
            {
                string[] d = item.Split('#');
                Contact std = new Contact();
                std.name = d[0];
                std.phone = d[1];
                std.group = d[2];
                std.gender = d[3];
                lstst.Add(std);

            }
            return lstst;
        }

        //doc file json
        async void loadjsonfile()
        {
            if (readJson() != null)
            {
                List<Contact> list = await readJson();
                listlong.ItemsSource = list;
            }

        }
        private const string JSONFILENAME = "contact.json";

        public async Task<List<Contact>> readJson()
        {
            List<Contact> myContact = null;
            string content = String.Empty;
            var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(JSONFILENAME);
            using (StreamReader reader = new StreamReader(myStream))
            {
                content = await reader.ReadToEndAsync();
                if (content.Length != 0)
                {
                    DataContractJsonSerializer seri = new DataContractJsonSerializer(typeof(List<Contact>));
                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(content));
                    myContact = (List<Contact>)seri.ReadObject(ms);
                }
                return myContact;
            }
        }





    }
}