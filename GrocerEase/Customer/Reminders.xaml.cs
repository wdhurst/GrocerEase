using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

namespace GrocerEase
{
    public partial class Reminders : ContentPage
    {
        public Reminders()
        {
            InitializeComponent();
            addItem.Clicked += AddItem_Clicked;
            deleteList.Clicked += DeleteList_Clicked;
            imgLogo.Source = ImageSource.FromResource("GrocerEase.store.png");
            imgNewList.Source = ImageSource.FromResource("GrocerEase.new-list.png");
            imgNotifs.Source = ImageSource.FromResource("GrocerEase.notifications.png");
            imgHome.Source = ImageSource.FromResource("GrocerEase.home.png");
            //checkImg.Source = ImageSource.FromResource("GrocerEase.check.png");


            //Tap Gesture Recognizer  
            var LayoutTap = new TapGestureRecognizer();
            LayoutTap.Tapped += (sender, e) =>
            {
                App.Current.MainPage = new NavigationPage(new StoreLayout());
            };
            stckLayout.GestureRecognizers.Add(LayoutTap);
            var NewListTap = new TapGestureRecognizer();
            NewListTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new NewList());
            };
            stckNewList.GestureRecognizers.Add(NewListTap);
            var HomeTap = new TapGestureRecognizer();
            HomeTap.Tapped += (sender, e) =>
            {
                App.Current.MainPage = new NavigationPage(new CustomerHome());
            };
            stckHome.GestureRecognizers.Add(HomeTap);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).current = DateTime.Today.ToString();
            listView.ItemsSource = await App.DatabaseR.GetItemsAsync();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new addReminder()
            {
                BindingContext = new ReminderList()
            });
        }

        async void DeleteList_Clicked(object sender, EventArgs e)
        {
            //if (App.Database.allInCart())
            listView.ItemsSource = await App.DatabaseR.DeleteAllAsync();
            //else
            //  await DisplayAlert("Error", "Not all items in cart, clear list anyways?", "Yes", "No");

        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new addReminder()
                {
                    BindingContext = e.SelectedItem as ReminderList
                });
            }

        }
    }
}
