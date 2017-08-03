using System;
using System.Collections.Generic;
using Community.Models;

namespace Community.Services
{
    /// <summary>
    /// 新闻服务
    /// </summary>
    public class NewsService
    {
        private static NewsService NEWS_SERVICE = null;

        public static NewsService GetInstance(){
            if(NEWS_SERVICE == null){
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
                list.Add(new NewsListBean { Title = "大自然神奇山水风景全" + Guid.NewGuid().ToString(), Image = image });
			}
            return list;
		}
    }
}
