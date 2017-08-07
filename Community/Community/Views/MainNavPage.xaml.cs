using Community.Views.Goods;
using Community.Views.Myself;
using Xamarin.Forms;

namespace Community.Views
{
    public partial class MainNavPage : TabbedPage
    {
        public MainNavPage()
        {
            InitializeComponent();
   //         this.Children.Add(new NavigationPage(new GoodsHomePage()){ Title="购物", Icon="nav_shopping.png"});
			//this.Children.Add(new NavigationPage(new MyselfHomePage()) { Title = "我的", Icon = "nav_myself.png" });

		}
    }
}
