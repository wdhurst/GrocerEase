﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

namespace GrocerEase
{
    public partial class Inventory : ContentPage
    {
        public Inventory()
        {
            InitializeComponent();
            addItem.Clicked += AddItem_Clicked;
            deleteList.Clicked += DeleteList_Clicked;
            imgLogo.Source = ImageSource.FromResource("GrocerEase.store.png");
            imgInventory.Source = ImageSource.FromResource("GrocerEase.inventory.png");
            imgPromos.Source = ImageSource.FromResource("GrocerEase.notifications.png");
            imgHome.Source = ImageSource.FromResource("GrocerEase.home.png");
            //imgItem.Source = ImageSource.FromResource("GrocerEase.new-list.png");
            //checkImg.Source = ImageSource.FromResource("GrocerEase.check.png");


            //Tap Gesture Recognizer  
            var OwnerLayoutTap = new TapGestureRecognizer();
            OwnerLayoutTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new Owner.OwnerStoreLayout());
            };
            stckOwnerLayout.GestureRecognizers.Add(OwnerLayoutTap);
            var PromosTap = new TapGestureRecognizer();
            PromosTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new Owner.Promotions());
            };
            stckPromos.GestureRecognizers.Add(PromosTap);
            var HomeTap = new TapGestureRecognizer();
            HomeTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new Owner.OwnerHome());
            };
            stckHome.GestureRecognizers.Add(HomeTap);

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtShoppingListId = -1;
            listView.ItemsSource = await App.DatabaseI.GetItemsAsync();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new inventoryPage()
            {
                BindingContext = new InventoryList()
            });
        }

        async void DeleteList_Clicked(object sender, EventArgs e)
        {
            //if (App.Database.allInCart())
            listView.ItemsSource = await App.DatabaseI.DeleteAllAsync();
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
                    BindingContext = e.SelectedItem as InventoryList
                });
            }

        }
    }
}
