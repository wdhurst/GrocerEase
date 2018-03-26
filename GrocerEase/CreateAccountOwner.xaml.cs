using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrocerEase
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateAccountOwner : ContentPage
	{
		public CreateAccountOwner ()
		{
			InitializeComponent ();
            CreateButton.Clicked += CreateButton_Clicked;
            LoginPage.Clicked += LoginPage_Clicked;
            Customer.Clicked += CustomerPage_Clicked;
		}

        void CreateButton_Clicked(object sender, EventArgs e)
        {
            // Check if email is unique
            // Send info into database
        }

        void LoginPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new GrocerEasePage());
        }

        void CustomerPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CreateAccount());
        }

	}
}
