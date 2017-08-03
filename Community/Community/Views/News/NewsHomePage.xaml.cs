using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Community.Helps;
using Community.Models;
using Community.Services;
using Xamarin.Forms;

namespace Community.Views.News
{
    public partial class NewsHomePage : ContentPage
    {
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
			this.getNewsList();
		}

        /// <summary>
        /// 选择一条
        /// </summary>
        private void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
			{
				return;
			}
			DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
        }

        /// <summary>
        /// 下拉刷新
        /// </summary>
        private void OnRefreshHandler(){
            this.newsList.Clear();
            this.getNewsList();
			this.listView.EndRefresh();
        }

        /// <summary>
        /// Handles the scroll to requested.
        /// </summary>
        private void Handle_ScrollToRequested(object sender, ScrollToRequestedEventArgs e)
        {
			this.getNewsList();
		}

        /// <summary>
        /// 获取新闻列表
        /// </summary>
        private void getNewsList(){
            IList<NewsListBean> list = this.newsService.GetNewsList();
            foreach(NewsListBean bean in list){
                this.newsList.Add(bean);
            }
        }



	}
}
