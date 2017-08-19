using Xamarin.Forms;
using Community.Views;
using Community.Views.Message;
using Community.Views.News;

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

            Current.MainPage = new NavigationPage(new MainNavPage()); ;

            //Current.MainPage = new NavigationPage(new MainLoginPage());
            //Current.MainPage = new NewsDetailPage();
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
