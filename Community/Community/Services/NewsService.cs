using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Community.Beans;
using Community.Helps;
using Community.Models;
using Community.Services.Model.News;
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

        private static long max_behot_time = 0;

        public static NewsService GetInstance(){
            if(NEWS_SERVICE == null){
                NEWS_SERVICE = new NewsService();
            }
            return NEWS_SERVICE;
        }

        public async Task<ResultBean<IList<NewsItemBean>>> GetToutiaoList(long time, string type){
			ResultBean<IList<NewsItemBean>> rb = new ResultBean<IList<NewsItemBean>>();

            //string url = "http://www.toutiao.com/api/article/feed/?category=" + type + "&utm_source=toutiao&widen=1&max_behot_time=0&max_behot_time_tmp=0&tadrequire=true&as=A1C529791677EE2&cp=599667FE4E32EE1";
            string url = "http://www.toutiao.com/api/pc/feed/?category=" + type + "&utm_source=toutiao&max_behot_time=" + max_behot_time;
            string result = await HttpHelp.getInstance().Get(url);
            if(result == null || "".Equals(result)){
				rb.Success = false;
				rb.Message = "请求http失败";
            }
            else
            {
				NewsToutiaoResultEntity resultBean = JsonHelp.FromJson<NewsToutiaoResultEntity>(result);
                logger.info("GetToutiaoList - url=" + url + ", " + resultBean.next.max_behot_time + ", " + resultBean.message);
				IList<NewsItemBean> list = new List<NewsItemBean>();
				if (resultBean.message.Equals("success") && resultBean.data != null)
				{
                    max_behot_time = resultBean.next.max_behot_time;
					foreach (NewsToutiaoItemEntity item in resultBean.data)
					{
                        NewsItemBean bean = new NewsItemBean { Title = item.title, Source = item.source, Image = "http:" + item.image_url, Url = "https://www.toutiao.com" + item.source_url};
                        DateTime utcdt = DateTime.Parse(DateTime.UtcNow.ToString("1970-01-01 00:00:00")).AddSeconds(item.behot_time);
                        bean.Datetime = utcdt.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
                        if(item.image_url != null)
                        {
                            bean.IsImage = true;
                        } 
                        else if(item.image_list !=null)
                        {
                            bean.IsThird = true;
                            bean.Image1 = "http:" + item.image_list[0].url;
							bean.Image2 = "http:" + item.image_list[1].url;
							bean.Image3 = "http:" + item.image_list[2].url;
						}
                        else
                        {
                            bean.IsText = true;
                        }

                        list.Add(bean);
					}
					rb.Success = true;
					rb.Data = list;
					rb.Message = "请求成功，返回" + list.Count + "条";
				}
				else
				{
					rb.Success = false;
					rb.Message = "请求结果为空";
				}
			}
			return rb;
		}

        public async Task<ResultBean<IList<NewsListBean>>> GetNewsList(long time, string type){
            string key = "ff3460eb96b32f8dca051ae1248a2e8a";
            string result = await HttpHelp.getInstance().Get("http://v.juhe.cn/toutiao/index?type=" + type + "&key=" + key);
            NewsResultBean resultBean = JsonHelp.FromJson<NewsResultBean>(result);
            logger.info("GetNewsList - " + time + ", " + resultBean.error_code + ", " + resultBean.reason);
			ResultBean<IList<NewsListBean>> rb = new ResultBean<IList<NewsListBean>>();
            if(resultBean != null && resultBean.result != null && resultBean.result.data != null){
				rb.Success = true;
				rb.Message = "请求成功";
				rb.Data = resultBean.result.data;
                foreach(NewsListBean b in rb.Data){
                    b.image = b.thumbnail_pic_s;
                }
            } 
            else {
                rb.Success = false;
				rb.Message = "请求失败";
			}
            return rb;
        }

    }
}
