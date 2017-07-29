using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Community.Views
{
    public partial class WelcomePage : CarouselPage
    {
        public WelcomePage()
        {
			InitializeComponent();

		}

		//使用PushModalAsync没有上导航的返回，使用PushAsync会有上导航的返回

		async void gotoLoginHandler1(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new LoginMainPage());
        }

		async void gotoLoginHandler2(object sender, System.EventArgs e)
		{
            await Navigation.PushModalAsync(new NavigationPage(new LoginMainPage()));
		}
    }

}
