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
            activeRems.Clicked += ActiveRems_Clicked;
            allRems.Clicked += AllRems_Clicked;
            imgLogo.Source = ImageSource.FromResource("GrocerEase.store.png");
            imgLists.Source = ImageSource.FromResource("GrocerEase.lists.png");
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
            var ListsTap = new TapGestureRecognizer();
            ListsTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new NewList());
            };
            stckLists.GestureRecognizers.Add(ListsTap);
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
            SaleListView.ItemsSource = null;
            ((App)App.Current).ResumeAtReminderListId = -1;
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
            ((App)App.Current).ResumeAtPromotionId = -1;
            listView.ItemsSource = null;
            SaleListView.ItemsSource = await App.DatabaseP.GetItemsAsync();
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

        void OnSaleListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                BindingContext = e.SelectedItem as PromotionList;
                var item = (PromotionList)BindingContext;
                var message = item.ToString();
                DisplayAlert("SALE", message, "OK");
            }

        }

       async void ActiveRems_Clicked(object sender, EventArgs e)
        {
            ((App)App.Current).current = DateTime.Today;
            SaleListView.ItemsSource = null;
            listView.ItemsSource = await App.DatabaseR.timetoBuy(((App)App.Current).current);
        }

        async void AllRems_Clicked(object sender, EventArgs e)
        {
            ((App)App.Current).ResumeAtReminderListId = -1;
            SaleListView.ItemsSource = null;
            listView.ItemsSource = await App.DatabaseR.GetItemsAsync();

        }
    }
}
