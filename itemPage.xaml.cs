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

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var item = listview.SelectedItem;
                search.Text=item.ToString();
            }
        }

        async void Handle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            while (search.IsFocused)
            {
                    listview.ItemsSource = await App.DatabaseI.inInventory(search.Text);
            }
            listview.ItemsSource = null;
        }

    async void OnSaveClicked(object sender, EventArgs e)
        {
            var item = (ShoppingList)BindingContext;
            await App.DatabaseS.SaveItemAsync(item);
            await Navigation.PopAsync();
        
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var item = (ShoppingList)BindingContext;
            await App.DatabaseS.DeleteItemAsync(item);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }

}
