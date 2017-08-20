using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Community.Beans;
using Xamarin.Forms;

namespace Community.Views.Message
{
    public partial class FriendPage : ContentPage
    {
		private ObservableCollection<FriendGroupBean> grouped { get; set; }

		public FriendPage()
        {
            InitializeComponent();

			grouped = new ObservableCollection<FriendGroupBean>();
            var a = new FriendGroupBean() { GroupName = "A", ShortName = "A" };
            var b = new FriendGroupBean() { GroupName = "B", ShortName = "B" };
			var c = new FriendGroupBean() { GroupName = "C", ShortName = "C" };
			var d = new FriendGroupBean() { GroupName = "D", ShortName = "D" };
			var e = new FriendGroupBean() { GroupName = "E", ShortName = "E" };
			var f = new FriendGroupBean() { GroupName = "F", ShortName = "F" };
            for (var i = 0; i < 5; i++)
            {
                var headImg = i % 2 == 0 ? "head1.jpg" : "head2.jpg";
				a.Add(new FriendBean() { Nickname = "刘德华", HeadImg = headImg });
				b.Add(new FriendBean() { Nickname = "奥巴马", HeadImg = headImg });
				c.Add(new FriendBean() { Nickname = "马可波罗", HeadImg = headImg });
				d.Add(new FriendBean() { Nickname = "奥斯特洛夫斯基", HeadImg = headImg });
				e.Add(new FriendBean() { Nickname = "happ", HeadImg = headImg });
				f.Add(new FriendBean() { Nickname = "（~_~）", HeadImg = headImg });

			}
			grouped.Add(a); grouped.Add(b);grouped.Add(c);grouped.Add(d);grouped.Add(e);grouped.Add(f);
			listView.ItemsSource = grouped;
        }
    }
}
