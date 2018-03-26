using Xamarin.Forms;

namespace GrocerEase
{
    public partial class GrocerEasePage : ContentPage
    {
        void CustmerSignUp_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new CreateAccount());
        }

        void LogIn_Clicked(object sender, System.EventArgs e)
        {
            //Check password against matching password in database.
        }


        public GrocerEasePage()
        {
            InitializeComponent();
<<<<<<< HEAD
			string email = EmailEntry.Text;
			string password = PasswordEntry.Text;
			
=======
            CustmerSignUp.Clicked += CustmerSignUp_Clicked; 
            LogIn.Clicked += LogIn_Clicked;

>>>>>>> 50edc29a4ea86c131c87acd5e436b12290fe3434
        }
    }
}
