using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GrocerEase
{
    public partial class itemPage : ContentPage
    {
        public itemPage()
        {
            InitializeComponent();
        }

    async void OnSaveClicked(object sender, EventArgs e)
        {
            var item = (ShoppingList)BindingContext;
            await App.Database.SaveItemAsync(item);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var item = (ShoppingList)BindingContext;
            await App.Database.DeleteItemAsync(item);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }

}
