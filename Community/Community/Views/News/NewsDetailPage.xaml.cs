using System;
using System.Collections.Generic;
using Community.Beans;
using Community.Helps;
using Xamarin.Forms;

namespace Community.Views.News
{
    public partial class NewsDetailPage : ContentPage
    {
		private LogHelp logger = DependencyService.Get<LogHelp>().setName("NewsDetailPage");

		private NewsItemBean newsItemBean = null;

        public NewsDetailPage()
        {
			InitializeComponent();

		}

        public NewsDetailPage(NewsItemBean bean)
        {
            InitializeComponent();
            this.newsItemBean = bean;
            this.Title = bean.Title;
			this.webView.Source = new UrlWebViewSource
			{
                Url = bean.Url
			};
            logger.info("goto - " + bean.Url);
		}

		/// <summary>
		/// Called when the webview starts navigating. Displays the loading label.
		/// </summary>
		void webviewNavigating(object sender, WebNavigatingEventArgs e)
		{
			this.labelLoading.IsVisible = true; //display the label when navigating starts
		}

		/// <summary>
		/// Called when the webview finished navigating. Hides the loading label.
		/// </summary>
		void webviewNavigated(object sender, WebNavigatedEventArgs e)
		{
			this.labelLoading.IsVisible = false; //remove the loading indicator when navigating is finished
		}


    }
}
