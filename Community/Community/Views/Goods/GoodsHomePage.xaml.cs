using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Community.Beans;
using Community.Helps;
using Community.Models;
using Community.Services;
using Community.Views.News;
using Xamarin.Forms;

namespace Community.Views.Goods
{
    public partial class GoodsHomePage : ContentPage
    {
		private LogHelp logger = DependencyService.Get<LogHelp>().setName("GoodsHomePage");
		private NewsService newsService = null;

        private ObservableCollection<GoodsListBean> goodsList = new ObservableCollection<GoodsListBean>();
        private IList<NewsListBean> dataList = null;
		public GoodsHomePage()
        {
            InitializeComponent();
			this.newsService = NewsService.GetInstance();
		    this.listView.ItemsSource = this.goodsList;
			this.listView.ItemSelected += this.onSelectionHandler;
			this.listView.RefreshCommand = new CommandHelp<NewsListBean>(p => this.onRefreshHandler(), null);
            //this.listView.BeginRefresh();
            this.onRefreshHandler();
		}

		/// <summary>
		/// 选择一条
		/// </summary>
		async private void onSelectionHandler(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return;
			}
			this.listView.SelectedItem = null;
			await Navigation.PushAsync(new GoodsDetailPage());
		}

		/// <summary>
		/// 下拉刷新
		/// </summary>
		private void onRefreshHandler()
		{
			logger.info("OnRefreshHandler----start----");
			this.getNewsList();
			logger.info("OnRefreshHandler----over----");
		}

        /// <summary>
        /// 切换列表和网格显示
        /// </summary>
        private void switchHandler(object sender, bool e)
        {
            logger.info("switchHandler - IsChecked=" + this.checkType.IsChecked);
            this.refreshListView();
        }

		/// <summary>
		/// 获取新闻列表
		/// </summary>
		async private void getNewsList()
		{
			double now = DateTime.Now.Subtract(DateTime.Parse("1970-1-1")).TotalSeconds;
			ResultBean<IList<NewsListBean>> rb = await this.newsService.GetNewsList((long)now, "shishang");
			if (rb.Success)
			{
                this.dataList = rb.Data;
				this.refreshListView();
			}
            else
            {
                await DisplayAlert("提示", "请求网络失败！", "ERROR");
            }
			this.listView.EndRefresh();
		}

        /// <summary>
        /// 切换显示模板：列表or网格
        /// </summary>
		private void refreshListView()
		{
			this.goodsList.Clear();
			// 表格
			if (this.checkType.IsChecked)
			{
				for (int i = 0; i < this.dataList.Count; i += 2)
				{
					NewsListBean bean1 = this.dataList[i];
					GoodsListBean b1 = new GoodsListBean { Image = bean1.image, Title = bean1.title, Price = 123.500, Postage = "包邮", Total = 12312, Description = "这是一个商品的介绍" };
				    if(i + 1 <  this.dataList.Count){
						NewsListBean bean2 = this.dataList[i + 1];
						GoodsListBean b2 = new GoodsListBean { Image = bean2.image, Title = bean2.title, Price = 123.500, Postage = "包邮", Total = 12312, Description = "这是一个商品的介绍" };
						b1.Other = b2;
					}
					this.goodsList.Add(b1);
				}
				this.listView.RowHeight = 160;
				this.listView.ItemTemplate = new DataTemplate(() =>
				{
					return new ViewCell { View = new ItemGirdView() };
				});
			}
            // 列表
			else
			{
				foreach (NewsListBean bean in this.dataList)
				{
					GoodsListBean b = new GoodsListBean { Image = bean.image, Title = bean.title, Price = 123.500, Postage = "包邮", Total = 12312, Description = "这是一个商品的介绍" };
					this.goodsList.Add(b);
				}
				this.listView.RowHeight = 100;
				this.listView.ItemTemplate = new DataTemplate(() =>
				{
					return new ViewCell { View = new ItemListView() };
				});
			}
		}

	}
}
