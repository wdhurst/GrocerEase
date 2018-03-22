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
            CustmerSignUp.Clicked += CustmerSignUp_Clicked; 
            LogIn.Clicked += LogIn_Clicked;

        }
    }
}
