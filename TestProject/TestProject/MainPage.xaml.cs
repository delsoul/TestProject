using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnCamera_Clicked(object sender, EventArgs e)
        {
            await Plugin.Media.CrossMedia.Current.Initialize();

            if (!Plugin.Media.CrossMedia.Current.IsCameraAvailable || !Plugin.Media.CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions());

            if (photo != null)
                PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });

            ////how to use camera in Xamarin
            ////https://xamarinhelp.com/use-camera-take-photo-xamarin-forms/

            ////clear all elements in scroll view
            //ctlImages.Children.Clear();

            ////loop for insert images
            //for (int i = 0; i < 5; i++)
            //{
            //    Image image = new Image();
            //    //image.Source = ImageSource.FromFile(); 
            //    string writePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //    string file = "/folder/myfile.png";
            //    image.HeightRequest = 100;
            //    image.WidthRequest = 150;

            //    image.BackgroundColor = Color.Green;
            //    image.Margin = new Thickness(5);

            //    ctlImages.Children.Add(image);
        }
    }
}

