using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Community.Beans
{
    public class FriendBean 
    {
        public string Nickname { get; set; }
        public string HeadImg { get; set; }
    }

    public class FriendGroupBean : ObservableCollection<FriendBean>
    {
		public string GroupName { get; set; }
		public string ShortName { get; set; }


	}
}
