using System.Collections.ObjectModel;
using Community.Models;
using Xamarin.Forms;

namespace Community.Views.Message
{
    public partial class MessageHomePage : ContentPage
    {
        public ObservableCollection<MessageListBean> messageList { get; set; }

		public MessageHomePage()
        {
            InitializeComponent();
			this.messageList = new ObservableCollection<MessageListBean>();
			this.listView.ItemsSource = this.messageList;

			this.messageList.Add(new MessageListBean { Nickname = "周杰伦", Message = "下午来看我的演唱会吧", LastTime = "2017-05-05 12:12:12", HeadImg = "http://img.qqzhi.com/upload/img_2_2807906048D2523014482_23.jpg" });
			this.messageList.Add(new MessageListBean { Nickname = "蔡依林", Message = "我要参加真人秀了", LastTime = "5分钟前", HeadImg = "https://gss0.baidu.com/-Po3dSag_xI4khGko9WTAnF6hhy/zhidao/wh%3D600%2C800/sign=acb66ec874c6a7efb973a020cdca8369/6a600c338744ebf851ebaf28dbf9d72a6059a70b.jpg" });
			this.messageList.Add(new MessageListBean { Nickname = "漩涡鸣人", Message = "螺旋丸发射", LastTime = "三天前", HeadImg = "http://www.qqzhi.com/uploadpic/2015-01-19/184557866.jpg" });
			this.messageList.Add(new MessageListBean { Nickname = "马里奥", Message = "和我去救公主吧", LastTime = "12:12:12", HeadImg = "https://gss0.baidu.com/-vo3dSag_xI4khGko9WTAnF6hhy/zhidao/wh%3D600%2C800/sign=916da508c9ef76093c5e91991eed8ff4/09fa513d269759eea0f4c15eb0fb43166c22dffb.jpg" });

		}
    }
}
