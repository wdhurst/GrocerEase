using System;
using System.Collections.Generic;

using Xamarin.Forms;
namespace GrocerEase.Owner
{
    public partial class Inventory : ContentPage
    {

        public Inventory()
        {
            brand.IsVisible = false;
            cat.IsVisible = false;
            aisle.IsVisible = false;
            NumberOfItems.IsVisible = false;
            Price.IsVisible = false;
            addButton.IsVisible = false;

            Title = "Category";
            Padding = new Thickness(0, 20, 0, 0);
            var listView = new ListView();
            //###listView.ItemsSource = Data.CategoryList;
            Content = listView; 
            InitializeComponent();
            imgLogo.Source = ImageSource.FromResource("GrocerEase.store.png");
            imgInventory.Source = ImageSource.FromResource("GrocerEase.inventory.png");
            imgPromos.Source = ImageSource.FromResource("GrocerEase.notifications.png");

            //Tap Gesture Recognizer  
            var LayoutTap = new TapGestureRecognizer();
            LayoutTap.Tapped += (sender, e) => {
                DefaultBackground();
                App.Current.MainPage = new NavigationPage(new OwnerStoreLayout());
                stckLayout.BackgroundColor = Color.Teal;
            };
            //###NewIn.GestureReconizers.Add(NewTap);
            var NewInventory = new TapGestureRecognizer();
            NewInventory.Tapped += (sender, e) =>
            {

                //Make the brand category aisle number of items price and the add to inventory to appear and hide the load button
                brand.IsVisible = true;
                cat.IsVisible = true;
                aisle.IsVisible = true;
                NumberOfItems.IsVisible = true;
                Price.IsVisible = true;
                addButton.IsVisible = true;
                LoadIn.IsVisible =false;

            };
            //###LoadIn.GestureReconizers.Add(LoadTap);
            //###var LoadInvent = new TapGestureRecongnizer();
            //###LoadInvent.Tapped += (sender, e) =>
            {
                //Load Inventory
            };
            //###addButton.GestureReconizer.Add(addInvent);
            //###var addInventory = new TapGestureReconizer();
            //###addInventory.Tapped += (sender, e) =>
            {
                brand.IsVisible = false;
                cat.IsVisible = false;
                aisle.IsVisible = false;
                NumberOfItems.IsVisible = false;
                Price.IsVisible = false;
                addButton.IsVisible = false;
                LoadIn.IsVisible = true;
                //still need to add to inventory
                async void addButton_Clicked(object sender, EventArgs e)
                {
                    await Navigation.PushAsync(new itemPage()
                    {
                        BindingContext = new ShoppingList()
                    });
                }

            };
            stckLayout.GestureRecognizers.Add(LayoutTap);
            var NewListTap = new TapGestureRecognizer();
            NewListTap.Tapped += (sender, e) => {
                DefaultBackground();
                App.Current.MainPage = new NavigationPage(new Inventory());
                stckInventory.BackgroundColor = Color.Teal;
            };
            stckInventory.GestureRecognizers.Add(NewListTap);
            var NotifsTap = new TapGestureRecognizer();
            NotifsTap.Tapped += (sender, e) => {
                DefaultBackground();
                App.Current.MainPage = new NavigationPage(new Promotions());
                stckPromos.BackgroundColor = Color.Teal;
            };
            stckPromos.GestureRecognizers.Add(NotifsTap);
        }
        public void DefaultBackground()
        {
            stckLayout.BackgroundColor = Color.White;
            stckInventory.BackgroundColor = Color.White;
            stckPromos.BackgroundColor = Color.White;
        }
    }
}
