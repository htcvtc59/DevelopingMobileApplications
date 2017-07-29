using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ASM_DMA.Resources;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Foundation;
using Windows.ApplicationModel.Activation;
using Windows.Storage.Streams;
using System.Windows.Media.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using Windows.ApplicationModel.Core;

namespace ASM_DMA
{
    public partial class MainPage : PhoneApplicationPage
    {

        CoreApplicationView view;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            view = CoreApplication.GetCurrentView();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            FunctionContact func = new FunctionContact();

            string txtname = txtName.Text;
            string txtphone = txtPhone.Text;
            string txtgroup = (cbbGroup.SelectedItem as ListPickerItem).Content.ToString();
            string txtavatar = (txtAvatar.Text.Length != 0) ? txtAvatar.Text : "";

            func.AddContact(txtname, txtphone, txtgroup, txtavatar);
            MessageBox.Show("Add success", "error", MessageBoxButton.OK);

        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewContact.xaml", UriKind.Relative));
        }

        private void btnAvatar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileOpenPicker openPicker = new FileOpenPicker();
                openPicker.FileTypeFilter.Add(".jpg");
                openPicker.FileTypeFilter.Add(".jpeg");
                openPicker.FileTypeFilter.Add(".png");
                openPicker.ContinuationData["Operation"] = "UpdateProfilePicture";
                openPicker.PickSingleFileAndContinue();
                view.Activated += View_Activated;

            }
            catch (Exception)
            {

                throw;
            }

        }

        private async void View_Activated(CoreApplicationView sender, IActivatedEventArgs args1)
        {
            try
            {
                FileOpenPickerContinuationEventArgs args = args1 as FileOpenPickerContinuationEventArgs;
                if ((args.ContinuationData["Operation"] as string) == "UpdateProfilePicture" &&
                    args.Files != null &&
                    args.Files.Count > 0)
                {
                    StorageFile file = args.Files[0];

                    if (file.Name.EndsWith("jpg") || file.Name.EndsWith("png") || file.Name.EndsWith("jpeg"))
                    {
                        IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                        BitmapImage bitmapImage = new BitmapImage();

                        bitmapImage.SetSource(fileStream.AsStream());
                        image.Source = bitmapImage;

                        txtAvatar.Text = file.Path;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }



    }
}