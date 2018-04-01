using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
namespace GrocerEase
{
    public partial class CreateAccount : ContentPage
    {
        /*class userInfo
        {
            public string email;
            public string password;
            public bool storeManager;
            public int userId;
        }*/
        public CreateAccount()
        {
            InitializeComponent();
            CreateButton.Clicked += CreateButton_Click;
            LoginPage.Clicked += LoginPage_Clicked;
            OwnerPage.Clicked += OwnerPage_Clicked;
        }
        void CreateButton_Click(Object sender, EventArgs e)
        {
            if (PasswordBox.Text == PassConfirmBox.Text)
            {
                Navigation.PushModalAsync(new CustomerHome());
            }
            else
                DisplayAlert("Alert", "Your Passwords do not match.", "OK");
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
