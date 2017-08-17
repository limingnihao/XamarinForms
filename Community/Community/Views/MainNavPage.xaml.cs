using Community.Helps;
using Community.Views.Goods;
using Community.Views.Myself;
using Xamarin.Forms;

namespace Community.Views
{
    public partial class MainNavPage : TabbedPage
    {
		private static LogHelp logger = DependencyService.Get<LogHelp>().setName("MainNavPage");

		public MainNavPage()
        {
            InitializeComponent();

		}

        protected override void OnCurrentPageChanged()
        {
            logger.info("OnCurrentPageChanged");
        }

        protected override void OnPagesChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
			//logger.info("OnPagesChanged");

		}

        protected override bool OnBackButtonPressed()
        {
			logger.info("OnBackButtonPressed");

			return base.OnBackButtonPressed();
        }
    }
}
