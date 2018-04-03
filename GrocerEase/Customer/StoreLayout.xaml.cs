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
            imgSavedLists.Source = ImageSource.FromResource("GrocerEase.lists.png");
            imgLogo.Source = ImageSource.FromResource("GrocerEase.store.png");
            imgNewList.Source = ImageSource.FromResource("GrocerEase.new-list.png");
            imgNotifs.Source = ImageSource.FromResource("GrocerEase.notifications.png");
            imgHome.Source = ImageSource.FromResource("GrocerEase.home.png");

            //Tap Gesture Recognizer  
            var SavedListsTap = new TapGestureRecognizer();
            SavedListsTap.Tapped += (sender, e) => {
                DefaultBackground();
                App.Current.MainPage = new NavigationPage(new SavedLists());
                stckSavedLists.BackgroundColor = Color.Teal;
            };
            stckSavedLists.GestureRecognizers.Add(SavedListsTap);
            var LayoutTap = new TapGestureRecognizer();
            LayoutTap.Tapped += (sender, e) => {
                DefaultBackground();
                App.Current.MainPage = new NavigationPage(new StoreLayout());
                stckLayout.BackgroundColor = Color.Teal;
            };
            stckLayout.GestureRecognizers.Add(LayoutTap);
            var NewListTap = new TapGestureRecognizer();
            NewListTap.Tapped += (sender, e) => {
                DefaultBackground();
                App.Current.MainPage = new NavigationPage(new NewList());
                stckNewList.BackgroundColor = Color.Teal;
            };
            stckNewList.GestureRecognizers.Add(NewListTap);
            var NotifsTap = new TapGestureRecognizer();
            NotifsTap.Tapped += (sender, e) => {
                DefaultBackground();
                App.Current.MainPage = new NavigationPage(new Reminders());
                stckNotifs.BackgroundColor = Color.Teal;
            };
            stckNotifs.GestureRecognizers.Add(NotifsTap);
            var HomeTap = new TapGestureRecognizer();
            HomeTap.Tapped += (sender, e) => {
                DefaultBackground();
                App.Current.MainPage = new NavigationPage(new CustomerHome());
                stckHome.BackgroundColor = Color.Teal;
            };
            stckHome.GestureRecognizers.Add(HomeTap);
        }
        public void DefaultBackground()
        {
            stckSavedLists.BackgroundColor = Color.White;
            stckLayout.BackgroundColor = Color.White;
            stckNewList.BackgroundColor = Color.White;
            stckNotifs.BackgroundColor = Color.White;
            stckHome.BackgroundColor = Color.White;
        }
    }
}
