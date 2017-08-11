using System;
using System.ComponentModel;

namespace Community.Models
{
    public class GoodsListBean : INotifyPropertyChanged
    {
        protected string _title;
		protected string _image;
		protected string _description;
        protected string _postage;
        protected double _price;
		protected int    _total;

		protected GoodsListBean _other;

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

		public string Description
		{
			get { return _description; }
			set { _description = value; this.OnPropertyChanged("Description"); }
		}

		public string Postage
		{
			get { return _postage; }
			set { _postage = value; this.OnPropertyChanged("postage"); }
		}

		public double Price
		{
			get { return _price; }
			set { _price = value; this.OnPropertyChanged("Price"); }
		}

		public int Total
		{
			get { return _total; }
			set { _total = value; this.OnPropertyChanged("Total"); }
		}

		public GoodsListBean Other
		{
			get { return _other; }
			set { _other = value; this.OnPropertyChanged("Other"); }
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
