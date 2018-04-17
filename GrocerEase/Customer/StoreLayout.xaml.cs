using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GrocerEase
{
    public partial class StoreLayout : ContentPage
    {
        public StoreLayout()
        {
            InitializeComponent();
            imgStoreLayout.Source = ImageSource.FromResource("GrocerEase.layout.jpg");
            imgDirectory.Source = ImageSource.FromResource("GrocerEase.directory.jpg");

            imgLogo.Source = ImageSource.FromResource("GrocerEase.store.png");
            imgLists.Source = ImageSource.FromResource("GrocerEase.lists.png");
            imgNotifs.Source = ImageSource.FromResource("GrocerEase.notifications.png");
            imgHome.Source = ImageSource.FromResource("GrocerEase.home.png");

            var ListsTap = new TapGestureRecognizer();
            ListsTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new NewList());
            };
            stckLists.GestureRecognizers.Add(ListsTap);
            var NotifsTap = new TapGestureRecognizer();
            NotifsTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new Reminders());
            };
            stckNotifs.GestureRecognizers.Add(NotifsTap);
            var HomeTap = new TapGestureRecognizer();
            HomeTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new CustomerHome());
            };
            stckHome.GestureRecognizers.Add(HomeTap);
        }
    }
}
