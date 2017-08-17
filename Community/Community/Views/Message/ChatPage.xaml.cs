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

		ChatBean chat1 = new ChatBean { Id = 1, HeadImg = "head1.jpg", Message = "1请你吃饭啊，你去不去？？", IsOwner = false, IsTarget = true };
		ChatBean chat2 = new ChatBean { Id = 2, HeadImg = "head2.jpg", Message = "2“表情包”是一种利用图片来表示感情的一种方式。表情包是在社交软件活跃之后，形成的一种流行文化，表情包流行于互联网上面“表情包”是一种利用图片来表示感情的一种方式。表情包是在社交软件活跃之后，形成的一种流行文化，表情包流行于互联网上面", IsOwner = true, IsTarget = false };
		ChatBean chat3 = new ChatBean { Id = 3, HeadImg = "head1.jpg", Message = "3“表情包”是一种利用图片来表示感情的一种方式。表情包是在社交软件活跃之后，形成的一种流行文化，表情包流行于互联网上面", IsOwner = false, IsTarget = true };
		ChatBean chat4 = new ChatBean { Id = 4, HeadImg = "head1.jpg", Message = "4“表情包”是一种利用图片来表示感情的一种方式。表情包是在社交软件活跃之后，形成的一种流行文化，表情包流行于互联网上面", IsOwner = false, IsTarget = true };
        ChatBean chat5 = new ChatBean { Id = 5, HeadImg = "head1.jpg", Message = "5“表情包”是一种利用图片来表示感情的一种方式。表情包是在社交软件活跃之后，形成的一种流行文化，表情包流行于互联网上面“表情包”是一种利用图片来表示感情的一种方式。表情包是在社交软件活跃之后，形成的一种流行文化，表情包流行于互联网上面", IsOwner = false, IsTarget = true };
		ChatBean chat6 = new ChatBean { Id = 6, HeadImg = "head1.jpg", Message = "6“表情包”是一种利用图片来表示感情的一种方式。表情包是在社交软件活跃之后，形成的一种流行文化，表情包流行于互联网上面", IsOwner = false, IsTarget = true };
		ChatBean chat7 = new ChatBean { Id = 7, HeadImg = "head1.jpg", Message = "7“表情包”是一种利用图片来表示感情的一种方式。表情包是在社交软件活跃之后，形成的一种流行文化，表情包流行于互联网上面“表情包”是一种利用图片来表示感情的一种方式。表情包是在社交软件活跃之后，形成的一种流行文化，表情包流行于互联网上面", IsOwner = false, IsTarget = true };
		ChatBean chat8 = new ChatBean { Id = 8, HeadImg = "head1.jpg", Message = "8“表情包”是一种利用图片来表示感情的一种方式。表情包是在社交软件活跃之后，形成的一种流行文化，表情包流行于互联网上面“表情包”是一种利用图片来表示感情的一种方式。表情包是在社交软件活跃之后，形成的一种流行文化，表情包流行于互联网上面", IsOwner = true, IsTarget = false };
		ChatBean chat9 = new ChatBean { Id = 9, HeadImg = "head1.jpg", Message = "9“表情包”是一种利用图片来表示感情的一种方式。表情包是在社交软件活跃之后，形成的一种流行文化，表情包流行于互联网上面“表情包”是一种利用图片来表示感情的一种方式。表情包是在社交软件活跃之后，形成的一种流行文化，表情包流行于互联网上面", IsOwner = false, IsTarget = true };
		ChatBean chat10 = new ChatBean { Id = 10, HeadImg = "head1.jpg", Message = "10“表情包”是一种利用图片来表示感情的一种方式。表情包是在社交软件活跃之后，形成的一种流行文化，表情包流行于互联网上面“表情包”是一种利用图片来表示感情的一种方式。表情包是在社交软件活跃之后，形成的一种流行文化，表情包流行于互联网上面", IsOwner = true, IsTarget = false };

		public ChatPage()
        {
            InitializeComponent();

            this.listView.ItemsSource = this.chatList;
			this.listView.ItemSelected += this.onSelectionHandler;

			this.chatList.Add(chat1);
			this.chatList.Add(chat2);
			this.chatList.Add(chat3);
			this.chatList.Add(chat4);
			this.chatList.Add(chat5);
			this.chatList.Add(chat6);
			this.chatList.Add(chat7);
			this.chatList.Add(chat8);
			this.chatList.Add(chat9);
			this.chatList.Add(chat10);
            this.listView.ScrollTo(chat10, ScrollToPosition.Center, true);
			this.UpdateChildrenLayout();

		}

		/// <summary>
		/// 选择一条
		/// </summary>
		private void onSelectionHandler(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return;
			}
			this.listView.SelectedItem = null;
		}
        void moreClickHandler(object sender, System.EventArgs e)
        {
            this.layoutMore.IsVisible = !this.layoutMore.IsVisible;
            if(this.layoutMore.IsVisible){
				this.listView.ScrollTo(chat10, ScrollToPosition.Center, true);
				this.UpdateChildrenLayout();
			}

		}
    }
}
