using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GrocerEase.Owner
{
    public partial class Promotions : ContentPage
    {
        public Promotions()
        {
            InitializeComponent();
            imgLogo.Source = ImageSource.FromResource("GrocerEase.store.png");
            imgInventory.Source = ImageSource.FromResource("GrocerEase.inventory.png");
            imgPromos.Source = ImageSource.FromResource("GrocerEase.notifications.png");
            imgHome.Source = ImageSource.FromResource("GrocerEase.home.png");
            addItem.Clicked += AddItem_Clicked;

            //Tap Gesture Recognizer  
            var OwnerLayoutTap = new TapGestureRecognizer();
            OwnerLayoutTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new OwnerStoreLayout());
            };
            stckOwnerLayout.GestureRecognizers.Add(OwnerLayoutTap);
            var InventoryTap = new TapGestureRecognizer();
            InventoryTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new Inventory());
            };
            stckInventory.GestureRecognizers.Add(InventoryTap);
            var HomeTap = new TapGestureRecognizer();
            HomeTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new OwnerHome());
            };
            stckHome.GestureRecognizers.Add(HomeTap);
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtPromotionId = -1;
            DateTime checkPastDue = DateTime.Today;
            App.DatabaseP.checkDate(checkPastDue);
            listView.ItemsSource = await App.DatabaseP.GetItemsAsync();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PromotionPage()
            {
                BindingContext = new PromotionList()
            });
        }

        async void DeleteList_Clicked(object sender, EventArgs e)
        {
            //if (App.Database.allInCart())
            listView.ItemsSource = await App.DatabaseP.DeleteAllAsync();
            //else
            //  await DisplayAlert("Error", "Not all items in cart, clear list anyways?", "Yes", "No");

        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
            if (e.SelectedItem != null)
            {
                await Navigation.PushModalAsync(new PromotionPage()
                {
                    BindingContext = e.SelectedItem as PromotionList
                });
            }

        }
    }
}
