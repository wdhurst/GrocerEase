﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GrocerEase.Owner
{
    public partial class OwnerStoreLayout : ContentPage
    {
        public OwnerStoreLayout()
        {
            InitializeComponent();
            imgLogo.Source = ImageSource.FromResource("GrocerEase.store.png");
            imgInventory.Source = ImageSource.FromResource("GrocerEase.inventory.png");
            imgNotifs.Source = ImageSource.FromResource("GrocerEase.notifications.png");

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
                App.Current.MainPage = new NavigationPage(new Reminders());
                stckNotifs.BackgroundColor = Color.Teal;
            };
            stckNotifs.GestureRecognizers.Add(NotifsTap);
        }
        public void DefaultBackground()
        {
            stckLayout.BackgroundColor = Color.White;
            stckInventory.BackgroundColor = Color.White;
            stckNotifs.BackgroundColor = Color.White;
        }
    }
}