using Xamarin.Forms;
using Community.Views;
using Community.Views.Message;

namespace Community
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Current.MainPage = new MainNavPage();
            //Current.MainPage = new ChatPage();
            //Current.MainPage = new WelcomePage();

            //NavigationPage main = new NavigationPage(new MainNavPage());
			//Current.MainPage = main;

			Current.MainPage = new NavigationPage(new MainLoginPage());

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
