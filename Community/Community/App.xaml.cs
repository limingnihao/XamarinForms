using Xamarin.Forms;
using Community.Views;

namespace Community
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

			 Current.MainPage = new MainNavPage();
			// Current.MainPage = new LoginMainPage();
			//Current.MainPage = new WelcomePage();
	

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
