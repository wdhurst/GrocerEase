using System;
using System.Collections.Generic;

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

            //Tap Gesture Recognizer  
            var InventoryTap = new TapGestureRecognizer();
            InventoryTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new Inventory());
            };
            stckInventory.GestureRecognizers.Add(InventoryTap);
            var PromosTap = new TapGestureRecognizer();
            PromosTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new Promotions());
            };
            stckPromos.GestureRecognizers.Add(PromosTap);
            var HomeTap = new TapGestureRecognizer();
            HomeTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new OwnerHome());
            };
            stckHome.GestureRecognizers.Add(HomeTap);

        }
    }
}
