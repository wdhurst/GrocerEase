using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GrocerEase
{
    public partial class CreateAccount : ContentPage
    {
        public CreateAccount()
        {
            InitializeComponent();
            string email = EmailBox.Text;
            string password = PasswordBox.Text;
            string confirm = PassConfirmBox.Text;
            Button create = CreateButton;
        }
    }
}
