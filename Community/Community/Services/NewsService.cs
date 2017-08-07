using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Community.Helps;
using Community.Models;
using Xamarin.Forms;

namespace Community.Services
{
    /// <summary>
    /// 新闻服务
    /// </summary>
    public class NewsService
    {
        private static NewsService NEWS_SERVICE = null;

        private static LogHelp logger = null;
        public static NewsService GetInstance(){
            if(NEWS_SERVICE == null){
				logger = DependencyService.Get<LogHelp>();
                NEWS_SERVICE = new NewsService();
            }
            return NEWS_SERVICE;
        }

        public IList<NewsListBean> GetNewsList(){
            IList<NewsListBean> list = new List<NewsListBean>();
            for (int i = 0; i < 5; i++){
                int random = DateTime.Now.Millisecond % 20;
				string name = random < 10 ? "0" + random + ".jpg" : random + ".jpg";
                string image = "http://image5.tuku.cn/pic/wallpaper/fengjing/daziranshenqishanshuifengjingbizhi/0" + name;
                list.Add(new NewsListBean { title = "大自然神奇山水风景全" + Guid.NewGuid().ToString(), image = image });
			}
            return list;
		}

        public async Task<IList<NewsListBean>> GetNewsList(long time){
            string type = "top";
            string key = "ff3460eb96b32f8dca051ae1248a2e8a";
            string result = await HttpHelp.getInstance().Get("http://v.juhe.cn/toutiao/index?type=" + type + "&key=" + key);
            logger.info("GetNewsList - " + time + ", " + result);
            NewsResultBean resultBean = JsonHelp.FromJson<NewsResultBean>(result);
            return resultBean.result.data;
        }

    }
}
