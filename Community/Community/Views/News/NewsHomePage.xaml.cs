using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Community.Beans;
using Community.Helps;
using Community.Services;
using Xamarin.Forms;

namespace Community.Views.News
{
    public partial class NewsHomePage : ContentPage
    {
        private LogHelp logger = DependencyService.Get<LogHelp>().setName("NewsHomePage");
		private NewsService newsService = null;

	    private ObservableCollection<NewsItemBean> newsList;

        private string defaultNewsType = "news_hot";

		public NewsHomePage()
        {
            InitializeComponent();
            this.newsService = NewsService.GetInstance();
            this.newsList = new ObservableCollection<NewsItemBean>();
            this.listView.ItemsSource = this.newsList;
			this.listView.ItemSelected += this.onSelectionHandler;
            this.listView.RefreshCommand = new CommandHelp<NewsItemBean>(p=>this.onRefreshHandler(), null);

            this.newsList.Add(new NewsItemBean { Title = "我这行好长一些，好看见他可以换行啊，应该够长了吧，我觉得而已了，那就这样吧。", Source="你好", Datetime="2019-01-01", IsImage = false, IsText = false, IsThird=true, Image1="Background_1.png", Image2= "Background_3.png", Image3= "Background_2.png" });
			this.newsList.Add(new NewsItemBean { Title = "我这行好长一些，好看见他可以换行啊，应该够长了吧，我觉得而已了，那就这样吧。", Image = "head1.jpg", IsImage=true, IsText=false });
			this.newsList.Add(new NewsItemBean { Title = "我这行好长一些，好看见他可以换行啊，应该够长了吧，我觉得而已了，那就这样吧。", IsImage = false, IsText = true });
			this.newsList.Add(new NewsItemBean { Title = "那就这样吧。", Image = "bg_tools.png", IsImage = true, IsText = false });
			this.newsList.Add(new NewsItemBean { Title = "比气体", Image = "Background_1.png", IsImage = true, IsText = false });
			this.newsList.Add(new NewsItemBean { Title = "比气体", Image = "head1.jpg", IsImage = true, IsText = false });
			this.newsList.Add(new NewsItemBean { Title = "比气体", Image = "Background_1.png", IsImage = true, IsText = false });

			this.newsList.Add(new NewsItemBean { Title = "比气体", Image = "head2.jpg", IsImage = true, IsText = false });
			this.setTypeView();
		}

        protected void setTypeView(){
            IList<NewsTypeBean> list = new List<NewsTypeBean>();
            list.Add(new NewsTypeBean { Name = "热点", Code = "news_hot" });
			list.Add(new NewsTypeBean { Name = "社会", Code = "news_society" });
			list.Add(new NewsTypeBean { Name = "美食", Code = "news_food" });
			list.Add(new NewsTypeBean { Name = "国际", Code = "news_world" });
			list.Add(new NewsTypeBean { Name = "娱乐", Code = "news_entertainment" });
			list.Add(new NewsTypeBean { Name = "体育", Code = "news_sports" });
			list.Add(new NewsTypeBean { Name = "军事", Code = "news_military" });
			list.Add(new NewsTypeBean { Name = "科技", Code = "news_tech" });
			list.Add(new NewsTypeBean { Name = "财经", Code = "news_finance" });
			list.Add(new NewsTypeBean { Name = "时尚", Code = "news_fashion" });
			list.Add(new NewsTypeBean { Name = "游戏", Code = "news_game" });
			list.Add(new NewsTypeBean { Name = "探索", Code = "news_discovery" });
			list.Add(new NewsTypeBean { Name = "美文", Code = "news_essay" });
			list.Add(new NewsTypeBean { Name = "历史", Code = "news_history" });
			list.Add(new NewsTypeBean { Name = "汽车", Code = "news_car" });
			list.Add(new NewsTypeBean { Name = "组图", Code = "组图" });
			list.Add(new NewsTypeBean { Name = "历史", Code = "news_history" });
			list.Add(new NewsTypeBean { Name = "历史", Code = "news_history" });

			foreach(NewsTypeBean b in list){
                Button button = new Button();
                button.Text = b.Name;
                button.Margin = new Thickness(5, 0, 0, 0);
                button.BackgroundColor = Color.Transparent;
                if(b.Code.Equals(this.defaultNewsType)){
					button.TextColor = Color.Red;
                }else{
					button.TextColor = Color.Black;
				}
				button.CommandParameter = b;
				button.Clicked += this.onTypeClickHandler;
                button.Command = new CommandHelp<NewsTypeBean>(p => this.onTypeRefreshHandler(p), null);
				this.layoutType.Children.Add(button);
			}
			this.onRefreshHandler();
		}

        private void onTypeRefreshHandler(NewsTypeBean p)
        {
            logger.info("onTypeRefreshHandler - " + p.Name + ", " + p.Code);
            this.defaultNewsType = p.Code;
            this.newsList.Clear();
            this.listView.BeginRefresh();
		}

        private void onTypeClickHandler(object sender, EventArgs e)
        {
            foreach(View v in this.layoutType.Children){
                ((Button)v).TextColor = Color.Black;
            }
            Button button = (Button)sender;
            button.TextColor = Color.Red;
        }

        /// <summary>
        /// 选择一条
        /// </summary>
        async private void onSelectionHandler(object sender, SelectedItemChangedEventArgs e)
        {
			logger.info("onSelectionHandler - " + sender + ", " + e.SelectedItem);
			if (e.SelectedItem == null)
			{
				return;
			}
            NewsDetailPage detailPage = new NewsDetailPage(e.SelectedItem as NewsItemBean);
            NavigationPage.SetBackButtonTitle(detailPage, "返回");
			await this.Navigation.PushAsync(detailPage);
			this.listView.SelectedItem = null;
		}

        /// <summary>
        /// 下拉刷新
        /// </summary>
        private void onRefreshHandler(){
            logger.info("OnRefreshHandler----start----");
			this.getNewsList();
			logger.info("OnRefreshHandler----over----");
		}

        /// <summary>
        /// 获取新闻列表
        /// </summary>
        async private void getNewsList(){
            double now = DateTime.Now.Subtract(DateTime.Parse("1970-1-1")).TotalSeconds;
            ResultBean<IList<NewsItemBean>> rb = await this.newsService.GetToutiaoList((long)now, this.defaultNewsType);
            logger.info("---getNewsList----get---, type=" + this.defaultNewsType + ", msg=" + rb.Message);
            if(rb.Success){
				this.newsList.Clear();
				foreach (NewsItemBean bean in rb.Data)
				{
                    logger.info("getNewsList - add - " + bean);
					this.newsList.Add(bean);
				}
			}
            this.listView.EndRefresh();
			this.listView.IsRefreshing = false;
		}
	}


    class NewsTypeBean{
        public string Name { get; set; }
        public string Code { get; set; }
    }

}
