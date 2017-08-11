using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Community.Helps;
using Community.Models;
using Xamarin.Forms;

namespace Community.Views
{
    public partial class WelcomePage : CarouselPage
    {
        private LogHelp logger = DependencyService.Get<LogHelp>().setName("WelcomePage");

		public WelcomePage()
        {
			InitializeComponent();
		}

	    void gotoLoginHandler2(object sender, System.EventArgs e)
		{
            App.Current.MainPage = new NavigationPage(new MainLoginPage());
        }

        void Handle_CheckedChanged(object sender, bool e)
        {
            logger.info("" + sender + ", " + e);
        }
    }

}
