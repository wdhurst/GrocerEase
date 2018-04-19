using System;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace GrocerEase.Owner
{
    public partial class OwnerStoreLayout : ContentPage
    {
        public OwnerStoreLayout()
        {
            InitializeComponent();
            imgStoreLayout.Source = ImageSource.FromResource("GrocerEase.layout.jpg");
            imgDirectory.Source = ImageSource.FromResource("GrocerEase.directory.jpg");
            imgLogo.Source = ImageSource.FromResource("GrocerEase.store.png");
            imgInventory.Source = ImageSource.FromResource("GrocerEase.inventory.png");
            imgPromos.Source = ImageSource.FromResource("GrocerEase.notifications.png");
            imgHome.Source = ImageSource.FromResource("GrocerEase.home.png");
            UploadButton.Clicked += UploadButton_Clicked;

            //Tap Gesture Recognizer  
            var InventoryTap = new TapGestureRecognizer();
            InventoryTap.Tapped += (sender, e) =>
            {
                App.Current.MainPage = new NavigationPage(new Inventory());
            };
            stckInventory.GestureRecognizers.Add(InventoryTap);
            var PromosTap = new TapGestureRecognizer();
            PromosTap.Tapped += (sender, e) =>
            {
                App.Current.MainPage = new NavigationPage(new Promotions());
            };
            stckPromos.GestureRecognizers.Add(PromosTap);
            var HomeTap = new TapGestureRecognizer();
            HomeTap.Tapped += (sender, e) =>
            {
                App.Current.MainPage = new NavigationPage(new OwnerHome());
            };
            stckHome.GestureRecognizers.Add(HomeTap);
        }
        async void permission()
        {
            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
            }

            if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg"
                });
            }
            else
            {
                await DisplayAlert("Permissions Denied", "Unable to take photos.", "OK");
                //On iOS you may want to send your user to the settings screen.
                //CrossPermissions.Current.OpenAppSettings();
            }
        }

        async void UploadButton_Clicked(object sender, EventArgs e)
        {
            if (CrossMedia.Current.IsPickPhotoSupported)
                await CrossMedia.Current.PickPhotoAsync();
        }
    }
}
