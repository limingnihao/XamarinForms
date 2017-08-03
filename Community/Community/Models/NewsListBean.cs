using System;
using System.ComponentModel;

namespace Community.Models
{
    public class NewsListBean : INotifyPropertyChanged
    {
        private int id;
        private string title;
        private string subtitle;
        private string image;

        public int Id 
        { 
            get { return id; } 
            set { id = value; this.OnPropertyChanged("Id"); } 
        }
        public string Title 
        { 
            get { return title;  }
            set { title = value; this.OnPropertyChanged("Title");} 
        }
        public string Subtitle 
        { 
            get { return subtitle; } 
            set { subtitle = value; this.OnPropertyChanged("Subtitle"); }
        }
        public string Image 
        {
			get { return image; }
			set { image = value; this.OnPropertyChanged("Image"); }
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
