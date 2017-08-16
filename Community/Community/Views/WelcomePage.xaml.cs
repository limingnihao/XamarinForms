using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Community.Helps;
using Xamarin.Forms;

namespace Community.Views
{
    public partial class WelcomePage : CarouselPage
    {
        private LogHelp logger = DependencyService.Get<LogHelp>().setName("WelcomePage");
		private XmppHelp xmpp = null;

		public WelcomePage()
        {
			InitializeComponent();
            xmpp = DependencyService.Get<XmppHelp>();
		}

	    void gotoLoginHandler2(object sender, System.EventArgs e)
		{
            App.Current.MainPage = new NavigationPage(new MainLoginPage());
        }

        void xmppConnentHandler(object sender, System.EventArgs e)
        {
            logger.info("xmppConnentHandler - " + sender + ", " + e);
            this.xmpp.connent("123.57.192.195", 5222, "dhcc", "user1", "123456");
        }

        void sendMesssageHandler(object sender, System.EventArgs e)
        {
            this.xmpp.sendMessage("user2", "nihao");     
        }

    }

}
