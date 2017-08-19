using System;
namespace Community.Services.Model.News
{
    public class NewsToutiaoNext
    {
		public long max_behot_time { get; set; }

        public override string ToString()
        {
            return string.Format("[NewsToutiaoNext: max_behot_time={0}]", max_behot_time);
        }
    }
}
