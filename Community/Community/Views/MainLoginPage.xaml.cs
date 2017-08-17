using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Community.Views
{
    public partial class MainLoginPage : ContentPage
    {
        public MainLoginPage()
        {
            InitializeComponent();
        }

		void onLoginHandler(object sender, System.EventArgs e)
		{
			App.Current.MainPage = new NavigationPage(new MainNavPage());
		}

        async void gotoLoginHandler(object sender, System.EventArgs e){
            await Navigation.PushAsync(new MobileLoginPage());
		}

        async void gotoRegistHandler(object sender, System.EventArgs e){
            await Navigation.PushAsync(new MobileRegisterPage());
        }
    }

}
