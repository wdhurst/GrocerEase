﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GrocerEase
{
    public partial class HomeCustomer : TabbedPage
    {
        public HomeCustomer()
        {
            InitializeComponent();
			imgSavedLists.Source = ImageSource.FromResource("");
			imgLogo.Source = ImageSource.FromResource("");
			imgNewList.Source = ImageSource.FromResource("");
			imgNotifs.Source = ImageSource.FromResource("");
			imgHome.Source = ImageSource.FromResource("");

			//Tap Gesture Recognizer  
			var SavedListsTap = new TapGestureRecognizer();
			SavedListsTap.Tapped += (sender, e) => {
				DefaultBackground();
				stckSavedLists.BackgroundColor = Color.Teal;
			};
			//Navigation.PushAsync(new nameofpage());
			stckSavedLists.GestureRecognizers.Add(SavedListsTap);

			var LayoutTap = new TapGestureRecognizer();
			LayoutTap.Tapped += (sender, e) => {
				DefaultBackground();
				stckLayout.BackgroundColor = Color.Teal;
			};
			stckLayout.GestureRecognizers.Add(LayoutTap);

			var NewListTap = new TapGestureRecognizer();
			NewListTap.Tapped += (sender, e) => {
				DefaultBackground();
				stckNewList.BackgroundColor = Color.Teal;
			};
			stckNewList.GestureRecognizers.Add(NewListTap);

			var NotifsTap = new TapGestureRecognizer();
			NotifsTap.Tapped += (sender, e) => {
				DefaultBackground();
				stckNotifs.BackgroundColor = Color.Teal;
			};
			stckNotifs.GestureRecognizers.Add(NotifsTap);

			var HomeTap = new TapGestureRecognizer();
			HomeTap.Tapped += (sender, e) => {
				DefaultBackground();
				stckHome.BackgroundColor = Color.Teal;
			};
			stckHome.GestureRecognizers.Add(HomeTap);
		}
		public void DefaultBackground()
		{
			stckSavedLists.BackgroundColor = Color.White;
			stckLayout.BackgroundColor = Color.White;
			stckNewList.BackgroundColor = Color.White;
			stckNotifs.BackgroundColor = Color.White;
			stckHome.BackgroundColor = Color.White;
		}
    }
}