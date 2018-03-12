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
            CreateButton.Clicked += CreateButton_Click;
        }
        void CreateButton_Click(Object sender, EventArgs e)
        {
            if (PasswordBox.Text == PassConfirmBox.Text)
            {
                //Also check if E-mail is unique?
                //Send Confirmation email and show confirmation page
            }
            else
            {
                //Alert user to reenter passwords and/or use an email that isn't 
                //already in system
            }
        }
    }
}