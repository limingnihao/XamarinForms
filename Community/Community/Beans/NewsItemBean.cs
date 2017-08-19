using System;
using System.ComponentModel;

namespace Community.Beans
{
	public class NewsItemBean : INotifyPropertyChanged
	{
		private string _title;
		private string _image;
        private string _source;
        private string _url;
        private string _datetime;

        private string _image1;
        private string _image2;
        private string _image3;

        private bool _isImage = false; //单图;
        private bool _isText = false;  //纯文本
        private bool _isThird = false;//三图

		public string Title
		{
			get { return _title; }
			set { _title = value; this.OnPropertyChanged("Title"); }
		}
		public string Image
		{
			get { return _image; }
			set { _image = value; this.OnPropertyChanged("Image"); }
		}
		public string Source
		{
			get { return _source; }
			set { _source = value; this.OnPropertyChanged("Source"); }
		}
		public string Url
		{
			get { return _url; }
			set { _url = value; this.OnPropertyChanged("Url"); }
		}
		public string Datetime
		{
			get { return _datetime; }
			set { _datetime = value; this.OnPropertyChanged("Datetime"); }
		}
		public string Image1
		{
			get { return _image1; }
			set { _image1 = value; this.OnPropertyChanged("Image1"); }
		}
		public string Image2
		{
			get { return _image2; }
			set { _image2 = value; this.OnPropertyChanged("Image2"); }
		}
		public string Image3
		{
			get { return _image3; }
			set { _image3 = value; this.OnPropertyChanged("Image3"); }
		}

		public bool IsImage
		{
			get { return _isImage; }
			set { _isImage = value; this.OnPropertyChanged("IsImage"); }
		}

		public bool IsText
		{
			get { return _isText; }
			set { _isText = value; this.OnPropertyChanged("IsText"); }
		}

		public bool IsThird
		{
			get { return _isThird; }
			set { _isThird = value; this.OnPropertyChanged("IsThird"); }
		}


		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string property)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(property));
			}
		}

        public override string ToString()
        {
            return string.Format("[NewsItemBean: Title={0}, Image={1}, Source={2}, Url={3}, Image1={4}, Image2={5}, Image3={6}, IsImage={7}, IsText={8}, IsThird={9}]", Title, Image, Source, Url, Image1, Image2, Image3, IsImage, IsText, IsThird);
        }
	}
}
