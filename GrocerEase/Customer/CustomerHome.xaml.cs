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
    public partial class CustomerHome : ContentPage
	{
		public CustomerHome ()
		{
            InitializeComponent();
            imgLogo.Source = ImageSource.FromResource("GrocerEase.store.png");
            imgLists.Source = ImageSource.FromResource("GrocerEase.lists.png");
            imgNotifs.Source = ImageSource.FromResource("GrocerEase.notifications.png");
            imgHome.Source = ImageSource.FromResource("GrocerEase.home.png");

            //Tap Gesture Recognizer
            var LayoutTap = new TapGestureRecognizer();
            LayoutTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new StoreLayout());
            };
            stckLayout.GestureRecognizers.Add(LayoutTap);
            var ListsTap = new TapGestureRecognizer();
            ListsTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new NewList());
            };
            stckLists.GestureRecognizers.Add(ListsTap);
            var NotifsTap = new TapGestureRecognizer();
            NotifsTap.Tapped += (sender, e) => {
                App.Current.MainPage = new NavigationPage(new Reminders());
            };
            stckNotifs.GestureRecognizers.Add(NotifsTap);
        }

        void LogOut_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new GrocerEasePage());
        }
	}
}
