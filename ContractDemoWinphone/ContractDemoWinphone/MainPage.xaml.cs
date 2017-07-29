using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ContractDemoWinphone.Resources;
using Windows.Storage;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace ContractDemoWinphone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (txtName.Text.Length != 0
                && txtPhone.Text.Length != 0
                && ((ListPickerItem)ListPicker.SelectedItem).Content.ToString().Length != 0
                && radMale.IsChecked == true || radFemale.IsChecked == true
                )
            {
                var content = ((ListPickerItem)ListPicker.SelectedItem).Content.ToString();
                string name = txtName.Text;
                string phone = txtPhone.Text;
                string gender = (radMale.IsChecked == true) ? "Male" : "Female";

                Contact cont = new Contact() { name = name, phone = phone, gender = gender, group = content };
                //var local = Windows.Storage.ApplicationData.Current.LocalFolder;
                //var file = await local.CreateFileAsync("data.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);
                //await FileIO.AppendTextAsync(file, cont.ToString());


                //Wirte file json
                await writefileJson(cont);

                MessageBox.Show("Write Data Success");

            }
            else
            {
                MessageBox.Show("Not Empty");
            }


        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
        }


        private const string JSONFILENAME = "contact.json";
        //write file json
        private async Task writefileJson(Contact contact)
        {
            //List Buy Car
            List<Contact> myContact = new List<Contact>();
            myContact.Add(contact);
            //add more than car
            string content = String.Empty;
            var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(JSONFILENAME);
            using (StreamReader reader = new StreamReader(myStream))
            {
                content = await reader.ReadToEndAsync();
                if (content.Length != 0)
                {
                    DataContractJsonSerializer seri = new DataContractJsonSerializer(typeof(List<Contact>));
                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(content));

                    List<Contact> buy = (List<Contact>)seri.ReadObject(ms);
                    myContact.AddRange(buy);
                    await ms.FlushAsync();
                }


            }
            //write
            var serializer = new DataContractJsonSerializer(typeof(List<Contact>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(
                JSONFILENAME,
                CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, myContact);
            }

        }






    }
}