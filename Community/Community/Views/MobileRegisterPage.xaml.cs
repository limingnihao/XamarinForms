using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Community.Views
{
    public partial class MobileRegisterPage : ContentPage
    {
        public MobileRegisterPage()
        {
            InitializeComponent();
        }

        async void onRegisterHandler(object sender, System.EventArgs e)
        {
			App.Current.MainPage = new NavigationPage(new MainNavPage());
		}
    }
}
