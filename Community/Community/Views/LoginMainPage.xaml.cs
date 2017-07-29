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

        async void loginHandler(object sender, System.EventArgs e){
            await Navigation.PushAsync(new MobileLoginPage());
		}

        async void registHandler(object sender, System.EventArgs e){
            await Navigation.PushAsync(new MobileRegisterPage());
        }
    }
}
