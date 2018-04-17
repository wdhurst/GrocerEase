using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GrocerEase
{
    public partial class inventoryPage : ContentPage
    {
        public inventoryPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var item = (InventoryList)BindingContext;
            await App.DatabaseI.SaveItemAsync(item);
            await Navigation.PopModalAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var item = (InventoryList)BindingContext;
            await App.DatabaseI.DeleteItemAsync(item);
            await Navigation.PopModalAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }

}