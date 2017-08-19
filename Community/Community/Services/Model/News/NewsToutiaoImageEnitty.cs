using System;
namespace Community.Services.Model.News
{
    public class NewsToutiaoImageEnitty
    {
        public string url { get; set; }

        public override string ToString()
        {
            return string.Format("[NewsToutiaoImageEnitty: url={0}]", url);
        }
    }
}
