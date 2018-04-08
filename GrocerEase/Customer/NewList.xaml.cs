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
            imgLogo.Source = ImageSource.FromResource("GrocerEase.store.png");
            imgNewList.Source = ImageSource.FromResource("GrocerEase.new-list.png");
            imgNotifs.Source = ImageSource.FromResource("GrocerEase.notifications.png");
            imgHome.Source = ImageSource.FromResource("GrocerEase.home.png");
            //Tap Gesture Recognizer  
            var LayoutTap = new TapGestureRecognizer();
            LayoutTap.Tapped += (sender, e) =>
            {
                DefaultBackground();
                App.Current.MainPage = new NavigationPage(new StoreLayout());
                stckLayout.BackgroundColor = Color.Teal;
            };
            stckLayout.GestureRecognizers.Add(LayoutTap);
            var NewListTap = new TapGestureRecognizer();
            NewListTap.Tapped += (sender, e) =>
            {
                DefaultBackground();
                App.Current.MainPage = new NavigationPage(new NewList());
                stckNewList.BackgroundColor = Color.Teal;
            };
            stckNewList.GestureRecognizers.Add(NewListTap);
            var NotifsTap = new TapGestureRecognizer();
            NotifsTap.Tapped += (sender, e) =>
            {
                DefaultBackground();
                App.Current.MainPage = new NavigationPage(new Reminders());
                stckNotifs.BackgroundColor = Color.Teal;
            };
            stckNotifs.GestureRecognizers.Add(NotifsTap);
            var HomeTap = new TapGestureRecognizer();
            HomeTap.Tapped += (sender, e) =>
            {
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
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var listView = new ListView();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtShoppingListId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new itemPage());
            {
                BindingContext = new ShoppingList();
            };
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new itemPage());
                {
                    BindingContext = e.SelectedItem as ShoppingList;
                }
            }
        }
    }
}
