using System.Collections.Generic;

namespace Community.Services.Model.News
{
    public class NewsToutiaoResultEntity
    {
        public bool has_more { get; set; }
        public string message { get; set; }
        public NewsToutiaoNext next { get; set; }
        public IList<NewsToutiaoItemEntity> data { get; set; }

    }
}
