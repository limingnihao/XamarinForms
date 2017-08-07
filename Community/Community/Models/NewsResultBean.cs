using System;
using System.Collections.Generic;

namespace Community.Models
{
    public class NewsResultBean 
    {

        public int error_code { get; set; }
        public string reason { get; set; }
        public NewsListObj result { get; set; }
    }

    public class NewsListObj
	{
        public int stat { get; set; }
		public IList<NewsListBean> data { get; set; }
	}

}
