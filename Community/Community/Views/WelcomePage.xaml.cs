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

	    void gotoLoginHandler2(object sender, System.EventArgs e)
		{
            App.Current.MainPage = new NavigationPage(new LoginMainPage());
        }

    }

}
