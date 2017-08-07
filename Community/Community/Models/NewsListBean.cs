using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Community.Models
{
    public class NewsListBean : INotifyPropertyChanged
    {
        private string _title;
        private string _image;
        //private string _author_name;
        //private string _category;
        //private string _date;
        public string thumbnail_pic_s { get; set; }
        public string thumbnail_pic_s02 { get; set; }
        public string thumbnail_pic_s03 { get; set; }

        public string title 
        { 
            get { return _title;  }
            set { _title = value; this.OnPropertyChanged("title");} 
        }
        public string image 
        {
			get { return _image; }
			set { _image = value; this.OnPropertyChanged("image"); }
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
