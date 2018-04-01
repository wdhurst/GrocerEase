using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GrocerEase
{
    public partial class NewList : ContentPage
    {
        public NewList()
        {
            InitializeComponent();
            imgSavedLists.Source = ImageSource.FromResource("XamarinForms_BottomNBar.home.png");
            imgLogo.Source = ImageSource.FromResource("XamarinForms_BottomNBar.alarm.png");
            imgNewList.Source = ImageSource.FromResource("XamarinForms_BottomNBar.camera.png");
            imgNotifs.Source = ImageSource.FromResource("XamarinForms_BottomNBar.settings.png");
            imgHome.Source = ImageSource.FromResource("XamarinForms_BottomNBar.logout.png");

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
        
