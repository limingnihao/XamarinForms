using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Community.Helps;
using Community.Models;
using Xamarin.Forms;

namespace Community.Views.Message
{
    public partial class ChatPage : ContentPage
    {
		private LogHelp logger = DependencyService.Get<LogHelp>().setName("ChatPage");

        private ObservableCollection<ChatBean> chatList = new ObservableCollection<ChatBean>();

		public ChatPage()
        {
            InitializeComponent();

            this.listView.ItemsSource = this.chatList;
			this.listView.ItemSelected += this.onSelectionHandler;

			var chat1 = new ChatBean { HeadImg = "head1.jpg", Message = "请你吃饭啊，你去不去？？", IsOwner = false, IsTarget=true };
            var chat2 = new ChatBean { HeadImg = "head2.jpg", Message = "“表情包”是一种利用图片来表示感情的一种方式。表情包是在社交软件活跃之后，形成的一种流行文化，表情包流行于互联网上面", IsOwner = true, IsTarget=false };
			var chat3 = new ChatBean { HeadImg = "head1.jpg", Message = "“表情包”是一种利用图片来表示感情的一种方式。表情包是在社交软件活跃之后，形成的一种流行文化，表情包流行于互联网上面", IsOwner = false, IsTarget = true };

			this.chatList.Add(chat1);
			this.chatList.Add(chat2);
			this.chatList.Add(chat2);
			this.chatList.Add(chat2);
			this.chatList.Add(chat2);
			this.chatList.Add(chat2);
			this.chatList.Add(chat3);
			this.chatList.Add(chat3);
			this.chatList.Add(chat1);
			this.chatList.Add(chat2);
            this.chatList.Add(chat1);
			this.chatList.Add(chat2);
			this.chatList.Add(chat1);
			this.chatList.Add(chat2);
            this.listView.ScrollTo(this.chatList[this.chatList.Count-1], ScrollToPosition.End, true);
		}

		/// <summary>
		/// 选择一条
		/// </summary>
		private void onSelectionHandler(object sender, SelectedItemChangedEventArgs e)
		{
			this.listView.SelectedItem = null;
		}

        void Handle_ScrollToRequested(object sender, Xamarin.Forms.ScrollToRequestedEventArgs e)
        {
        }
    }
}
