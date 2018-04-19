using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GrocerEase.Owner
{
    public partial class PromotionPage : ContentPage
    {
        public PromotionPage()
        {
            InitializeComponent();
            datePick.MinimumDate = DateTime.Now.AddDays(-1);
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var item = promotionlistview.SelectedItem;
                search.Text = item.ToString();
            }
        }

        async void Handle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            while (search.IsFocused)
            {
                promotionlistview.ItemsSource = await App.DatabaseI.inInventory(search.Text);
            }
            promotionlistview.ItemsSource = null;
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var item = (PromotionList)BindingContext;
            await App.DatabaseP.SaveItemAsync(item);
            await Navigation.PopModalAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var item = (PromotionList)BindingContext;
            await App.DatabaseP.DeleteItemAsync(item);
            await Navigation.PopModalAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
