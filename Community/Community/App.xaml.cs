using Xamarin.Forms;
using Community.Views;
namespace Community
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

			//MainPage = new MobileLoginPage();
			MainPage = new NavigationPage(new WelcomePage()){
				BarBackgroundColor = (Color)Current.Resources["Primary"],
				BarTextColor = Color.White
			};
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
