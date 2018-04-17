using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GrocerEase
{
    public partial class LoginPage : ContentPage
    {
        void CustmerSignUp_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new CreateAccount());
        }

        void LogIn_Clicked(object sender, System.EventArgs e)
        {
            //Check password against matching password in database.
            if (EmailEntry.Text == "customer@example.net" && PasswordEntry.Text == "password")
            {
                Navigation.PushModalAsync(new NewList());
            }
            else if (EmailEntry.Text == "manager@example.net" && PasswordEntry.Text == "password")
            {
                Navigation.PushModalAsync(new Owner.OwnerStoreLayout());
            }
            else
                DisplayAlert("Error", "No account exists with those credentials. Please try again or click below to create an account.", "OK");
        }

        void OwnerSignUp_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new CreateAccountOwner());
        }

        public LoginPage()
        {
            InitializeComponent();
            CustmerSignUp.Clicked += CustmerSignUp_Clicked;
            LogIn.Clicked += LogIn_Clicked;
            OwnerSignUp.Clicked += OwnerSignUp_Clicked;
            var imgCartDark = new Image { Source = ImageSource.FromResource("GrocerEase.cart-dark.png") };
        }
    }
}
