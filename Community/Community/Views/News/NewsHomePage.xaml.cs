using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Community.Helps;
using Community.Models;
using Community.Services;
using Xamarin.Forms;

namespace Community.Views.News
{
    public partial class NewsHomePage : ContentPage
    {
		private LogHelp logger = DependencyService.Get<LogHelp>();
		private NewsService newsService = null;

		public ObservableCollection<NewsListBean> newsList { get; set; }

		public NewsHomePage()
        {
            InitializeComponent();
            this.newsService = NewsService.GetInstance();
            this.newsList = new ObservableCollection<NewsListBean>();
            this.listView.ItemsSource = this.newsList;
			this.listView.ItemSelected += OnSelection;
            this.listView.RefreshCommand = new CommandHelp<NewsListBean>(p=>this.OnRefreshHandler(), null);
			this.OnRefreshHandler();
		}

        /// <summary>
        /// 选择一条
        /// </summary>
        async private void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
			{
				return;
			}
			//DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
			await Navigation.PushAsync(new NewsDetailPage());
		}

        /// <summary>
        /// 下拉刷新
        /// </summary>
        private void OnRefreshHandler(){
            this.newsList.Clear();
            logger.info("OnRefreshHandler----start----");
			this.getNewsList();
			logger.info("OnRefreshHandler----over----");
		}

        /// <summary>
        /// 获取新闻列表
        /// </summary>
        async void getNewsList(){
            double now = DateTime.Now.Subtract(DateTime.Parse("1970-1-1")).TotalSeconds;
            IList<NewsListBean> list = await this.newsService.GetNewsList((long)now);
			logger.info("---getNewsList----get---" + list);
            if(list != null){
				foreach (NewsListBean bean in list)
				{
					bean.image = bean.thumbnail_pic_s02;
					logger.info(bean.title + ", " + bean.image);
					this.newsList.Add(bean);
				}
			}
            this.listView.EndRefresh();
			this.listView.IsRefreshing = false;
		}
	}


}
