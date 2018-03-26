using System;
using System.Collections.Generic;
using Xamarin.Forms;
namespace GrocerEase
{
    public partial class CreateAccount : ContentPage
    {
        class userInfo
        {
            public string email;
            public string password;
            public bool storeManager;
            public int userId;
        }
        public CreateAccount()
        {
            InitializeComponent();
            CreateButton.Clicked += CreateButton_Click;
            LoginPage.Clicked += LoginPage_Clicked;
            OwnerPage.Clicked += OwnerPage_Clicked;
        }
        void CreateButton_Click(Object sender, EventArgs e)
        {
            Dictionary<string, userInfo> users = new Dictionary<string, userInfo>();
            Random rnd = new Random();

            if (PasswordBox.Text == PassConfirmBox.Text)
            {
                //Send Confirmation email and show confirmation page
                try
                {
                    users.Add(EmailBox.Text, new userInfo { email = EmailBox.Text, password = PasswordBox.Text, storeManager = false, userId = rnd.Next(9999) });
                }
                catch (ArgumentException)
                {
                    DisplayAlert("Error", "That email is already linked to an account.", "OK");
                }
            }
        }

        void LoginPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new GrocerEasePage());
        }

        void OwnerPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CreateAccountOwner());
        }

    }
}