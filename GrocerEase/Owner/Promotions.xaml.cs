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
                DefaultBackground();
                App.Current.MainPage = new NavigationPage(new OwnerStoreLayout());
                stckLayout.BackgroundColor = Color.Teal;
            };
            stckLayout.GestureRecognizers.Add(LayoutTap);
            var NewListTap = new TapGestureRecognizer();
            NewListTap.Tapped += (sender, e) => {
                DefaultBackground();
                App.Current.MainPage = new NavigationPage(new Inventory());
                stckInventory.BackgroundColor = Color.Teal;
            };
            stckInventory.GestureRecognizers.Add(NewListTap);
            var NotifsTap = new TapGestureRecognizer();
            NotifsTap.Tapped += (sender, e) => {
                DefaultBackground();
                App.Current.MainPage = new NavigationPage(new Promotions());
                stckPromos.BackgroundColor = Color.Teal;
            };
            stckPromos.GestureRecognizers.Add(NotifsTap);
        }
        public void DefaultBackground()
        {
            stckLayout.BackgroundColor = Color.White;
            stckInventory.BackgroundColor = Color.White;
            stckPromos.BackgroundColor = Color.White;
        }
    }
}
