using System;
using System.ComponentModel;

namespace Community.Models
{
    public class MessageListBean : INotifyPropertyChanged
    {
  

        private int id;
        private string nickname;
        private string headImg;
        private string message;
        private string lastTime;

        public int Id
        {
			get { return id; }
			set { id = value; this.OnPropertyChanged("Id"); }
        }

		public string Nickname
		{
			get { return nickname; }
			set { nickname = value; this.OnPropertyChanged("Nickname"); }
		}

		public string HeadImg
		{
			get { return headImg; }
			set { headImg = value; this.OnPropertyChanged("HeadImg"); }
		}

		public string Message
		{
			get { return message; }
			set { message = value; this.OnPropertyChanged("Message"); }
		}

		public string LastTime
		{
			get { return lastTime; }
			set { lastTime = value; this.OnPropertyChanged("LastTime"); }
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(string property)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(property));
			}
		}

    }
}

