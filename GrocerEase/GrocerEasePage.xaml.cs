using Xamarin.Forms;

namespace GrocerEase
{
    public partial class GrocerEasePage : ContentPage
    {
        public GrocerEasePage()
        {
            InitializeComponent();
			string email = EmailEntry.Text;
			string password = PasswordEntry.Text;
			
        }
    }
}
