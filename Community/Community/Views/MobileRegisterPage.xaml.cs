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
            await Navigation.PushModalAsync(new MainNavPage());
		}
    }
}
