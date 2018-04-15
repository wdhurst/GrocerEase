using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

namespace GrocerEase
{
    public partial class NewList : ContentPage
    {
        public NewList()
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
            var NotifsTap = new TapGestureRecognizer();
            NotifsTap.Tapped += (sender, e) =>
            {
                App.Current.MainPage = new NavigationPage(new Reminders());
            };
            stckNotifs.GestureRecognizers.Add(NotifsTap);
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
            ((App)App.Current).ResumeAtShoppingListId = -1;
            listView.ItemsSource = await App.DatabaseS.GetItemsAsync();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new itemPage()
            {
                BindingContext = new ShoppingList()
            });
        }

        async void DeleteList_Clicked(object sender, EventArgs e)
        {
            //if (App.Database.allInCart())
                listView.ItemsSource = await App.DatabaseS.DeleteAllAsync();
            //else
              //  await DisplayAlert("Error", "Not all items in cart, clear list anyways?", "Yes", "No");
                    
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new itemPage()
                {
                    BindingContext = e.SelectedItem as ShoppingList
                });
            }

        }
    }
}
