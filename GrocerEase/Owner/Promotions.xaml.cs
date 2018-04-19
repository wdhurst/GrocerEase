﻿using System;
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
            imgHome.Source = ImageSource.FromResource("GrocerEase.home.png");

            //Tap Gesture Recognizer  
            var OwnerLayoutTap = new TapGestureRecognizer();
            OwnerLayoutTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new OwnerStoreLayout());
            };
            stckOwnerLayout.GestureRecognizers.Add(OwnerLayoutTap);
            var InventoryTap = new TapGestureRecognizer();
            InventoryTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new Inventory());
            };
            stckInventory.GestureRecognizers.Add(InventoryTap);
            var HomeTap = new TapGestureRecognizer();
            HomeTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new OwnerHome());
            };
            stckHome.GestureRecognizers.Add(HomeTap);
        }
    }
}
