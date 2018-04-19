using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GrocerEase
{
    public partial class addReminder : ContentPage
    {
        public addReminder()
        {
            InitializeComponent();
            datePick.MinimumDate = DateTime.Now.AddDays(-1);
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var item = reminderlistview.SelectedItem;
                search.Text = item.ToString();
            }
        }

        async void Handle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            while (search.IsFocused)
            {
                reminderlistview.ItemsSource = await App.DatabaseI.inInventory(search.Text);
            }
            reminderlistview.ItemsSource = null;
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var item = (ReminderList)BindingContext;
            await App.DatabaseR.SaveItemAsync(item);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var item = (ReminderList)BindingContext;
            await App.DatabaseR.DeleteItemAsync(item);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }

}