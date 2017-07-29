using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WPRSSReader
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Rss _rss;
        public Rss Rss
        {
            get { return this._rss; }
            set
            {
                this._rss = value;
                NotifyPropertyChanged("Rss");
            }
        }
        public bool IsLoaded { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public async void LoadRss(string url)
        {
            HttpClient client = new HttpClient();
            using (var stream = await client.GetStreamAsync(url))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Rss));
                this.Rss = serializer.Deserialize(stream) as Rss;
                IsLoaded = true;
            }

        }
    }
}
