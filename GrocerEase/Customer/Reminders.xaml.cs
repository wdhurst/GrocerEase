﻿using System;
using System.Threading;
using System.Windows;
using System.Collections.Generic;
using Xamarin;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;



public struct Reminder
{
    public int ID { get; set; }
    public string date { get; set; }
    public bool recurring { get; set; }
    public string itemName { get; set; }
};


namespace GrocerEase
{
    public partial class Reminders : ContentPage
    {
        public Reminders()
        {
            InitializeComponent();
            imgLogo.Source = ImageSource.FromResource("GrocerEase.store.png");
            imgNewList.Source = ImageSource.FromResource("GrocerEase.new-list.png");
            imgNotifs.Source = ImageSource.FromResource("GrocerEase.notifications.png");
            imgHome.Source = ImageSource.FromResource("GrocerEase.home.png");

            //Tap Gesture Recognizer  
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
            stckLayout.BackgroundColor = Color.White;
            stckNewList.BackgroundColor = Color.White;
            stckNotifs.BackgroundColor = Color.White;
            stckHome.BackgroundColor = Color.White;
        }

        void AddButton_Clicked(object sender, EventArgs e)
        {
            DateTime current = DateTime.Today;
            DateTime timetoBuy = DateTime.Today;
            if (LengthType.SelectedIndex == 0)
            {
                double numDays = LengthPick.SelectedIndex + 1;
                timetoBuy.AddDays(numDays);
            }
            else
            {
                double numWeeks = LengthPick.SelectedIndex + 1;
                timetoBuy.AddDays(numWeeks * 7);
            }

              DisplayAlert("Reminder ", "You need to buy" + itemBox.Text + " ", "OK");
              item.Text = "we made it!";
#if __ANDROID__
           
#endif

        }
        public bool checkTime(DateTime current, DateTime timetoBuy)
        {
            if (current > timetoBuy)
                return true;
            else
                return false;
        }
    }
}
