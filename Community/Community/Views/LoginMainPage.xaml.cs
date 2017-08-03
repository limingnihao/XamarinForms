using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Community.Views
{
    public partial class LoginMainPage : ContentPage
    {
        public LoginMainPage()
        {
            InitializeComponent();
        }

		protected async void onLoginHandler(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new MainNavPage());
		}

        async void gotoLoginHandler(object sender, System.EventArgs e){
            await Navigation.PushAsync(new MobileLoginPage());
		}

        async void gotoRegistHandler(object sender, System.EventArgs e){
            await Navigation.PushAsync(new MobileRegisterPage());
        }
    }

}
