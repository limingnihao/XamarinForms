using System;
using System.Collections.Generic;

namespace Community.Services.Model.News
{
    public class NewsToutiaoItemEntity
    {
        public string title { get; set; }
        public string source { get; set; }
        public string image_url { get; set; }
        public string source_url { get; set; }
        public long behot_time { get; set; }
        public bool has_gallery { get; set; }
        public IList<NewsToutiaoImageEnitty> image_list { get; set; }


        public override string ToString()
        {
            return string.Format("[NewsToutiaoItemEntity: title={0}, source={1}, image_url={2}, source_url={3}, behot_time={4}, has_gallery={5}, image_list={6}]", title, source, image_url, source_url, behot_time, has_gallery, image_list);
        }
    }
}
