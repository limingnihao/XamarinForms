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

            //单独调试页面
			//Current.MainPage = new MainNavPage();
			//Current.MainPage = new ChatPage();
			//Current.MainPage = new WelcomePage();
			//Current.MainPage = new FriendPage();

            //正式运行
			//MainLoginPage page = new MainLoginPage);

			MainNavPage page = new MainNavPage();
			NavigationPage.SetBackButtonTitle(page, "");
			Current.MainPage = new NavigationPage(page);
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
