using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GrocerEase.Owner
{
    public partial class Promotions : ContentPage
    {
        public Promotions()
        {
            InitializeComponent();
            imgLogo.Source = ImageSource.FromResource("GrocerEase.store.png");
            imgInventory.Source = ImageSource.FromResource("GrocerEase.inventory.png");
            imgPromos.Source = ImageSource.FromResource("GrocerEase.notifications.png");

            //Tap Gesture Recognizer  
            var LayoutTap = new TapGestureRecognizer();
            LayoutTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new OwnerStoreLayout());
            };
            //stckOwnerLayout.GestureRecognizers.Add(OwnerLayoutTap);
            var NewListTap = new TapGestureRecognizer();
            NewListTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new Inventory());
            };
            stckInventory.GestureRecognizers.Add(NewListTap);
            var NotifsTap = new TapGestureRecognizer();
            NotifsTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new Promotions());
            };
            stckPromos.GestureRecognizers.Add(NotifsTap);
        }
    }
}
