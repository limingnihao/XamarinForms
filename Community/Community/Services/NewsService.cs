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

        private static LogHelp logger = DependencyService.Get<LogHelp>().setName("NewsService");
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
                list.Add(new NewsListBean { title = "大自然神奇山水风景全" + Guid.NewGuid().ToString(), image = image });
			}
            return list;
		}

        public async Task<ResultBean<IList<NewsListBean>>> GetNewsList(long time, string type){
            string key = "ff3460eb96b32f8dca051ae1248a2e8a";
            string result = await HttpHelp.getInstance().Get("http://v.juhe.cn/toutiao/index?type=" + type + "&key=" + key);
            logger.info("GetNewsList - " + time + ", " + result);
            NewsResultBean newsresultBean = JsonHelp.FromJson<NewsResultBean>(result);
            ResultBean<IList<NewsListBean>> rb = new ResultBean<IList<NewsListBean>>();
            if(newsresultBean != null && newsresultBean.result != null && newsresultBean.result.data != null){
				rb.Success = true;
				rb.Message = "请求成功";
				rb.Data = newsresultBean.result.data;
                foreach(NewsListBean b in rb.Data){
                    b.image = b.thumbnail_pic_s;
                }
            } else {
                rb.Success = false;
				rb.Message = "请求失败";
			}
            return rb;
        }

    }
}
