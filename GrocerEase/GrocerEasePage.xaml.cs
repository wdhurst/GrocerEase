using Xamarin.Forms;

namespace GrocerEase
{
    public partial class GrocerEasePage : ContentPage
    {
        void CustmerSignUp_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new CreateAccount());
        }

        void LogIn_Clicked(object sender, System.EventArgs e)
        {
            //Check password against matching password in database.
            Navigation.PushModalAsync(new LoginPage());
        }

        void OwnerSignUp_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new CreateAccountOwner());
        }


        public GrocerEasePage()
        {
            InitializeComponent();
            CustmerSignUp.Clicked += CustmerSignUp_Clicked; 
            LogIn.Clicked += LogIn_Clicked;
            OwnerSignUp.Clicked += OwnerSignUp_Clicked;
            imgDark.Source = ImageSource.FromResource("GrocerEase.cart-dark.png");

        }
    }
}
