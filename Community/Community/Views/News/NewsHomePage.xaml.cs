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

		private ObservableCollection<NewsListBean> newsList { get; set; }

        private string type = "top";

		public NewsHomePage()
        {
            InitializeComponent();
            this.newsService = NewsService.GetInstance();
            this.newsList = new ObservableCollection<NewsListBean>();
            this.listView.ItemsSource = this.newsList;
			this.listView.ItemSelected += this.onSelection;
            this.listView.RefreshCommand = new CommandHelp<NewsListBean>(p=>this.onRefreshHandler(), null);
            this.setTypeView();
		}

        private void setTypeView(){
            IList<NewsTypeBean> list = new List<NewsTypeBean>();
            list.Add(new NewsTypeBean { name = "热点", code = "top" });
			list.Add(new NewsTypeBean { name = "社会", code = "shehui" });
			list.Add(new NewsTypeBean { name = "国内", code = "guonei" });
			list.Add(new NewsTypeBean { name = "国际", code = "guoji" });
			list.Add(new NewsTypeBean { name = "娱乐", code = "yule" });
			list.Add(new NewsTypeBean { name = "体育", code = "tiyu" });
			list.Add(new NewsTypeBean { name = "军事", code = "junshi" });
			list.Add(new NewsTypeBean { name = "科技", code = "keji" });
			list.Add(new NewsTypeBean { name = "财经", code = "caijing" });
			list.Add(new NewsTypeBean { name = "时尚", code = "shishang" });
            foreach(NewsTypeBean b in list){
                Button button = new Button();
                button.Text = b.name;
                button.Margin = new Thickness(5, 0, 0, 0);
                if(b.code.Equals("top")){
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
            logger.info("onTypeRefreshHandler - " + p.name + ", " + p.code);
            this.type = p.code;
			this.newsList.Clear();
            this.getNewsList();
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
        async private void onSelection(object sender, SelectedItemChangedEventArgs e)
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
        private void onRefreshHandler(){
            this.newsList.Clear();
            logger.info("OnRefreshHandler----start----");
			this.getNewsList();
			logger.info("OnRefreshHandler----over----");
		}

        /// <summary>
        /// 获取新闻列表
        /// </summary>
        async private void getNewsList(){
            double now = DateTime.Now.Subtract(DateTime.Parse("1970-1-1")).TotalSeconds;
            ResultBean<IList<NewsListBean>> rb = await this.newsService.GetNewsList((long)now, this.type);
            logger.info("---getNewsList----get---, type=" + this.type + ", msg=" + rb.Message);
            if(rb.Success){
                foreach (NewsListBean bean in rb.Data)
				{
					this.newsList.Add(bean);
				}
			}
            this.listView.EndRefresh();
			this.listView.IsRefreshing = false;
		}
	}


    class NewsTypeBean{
        public string name { get; set; }
        public string code { get; set; }
    }

}
