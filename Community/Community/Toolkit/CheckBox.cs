using System;
using Xamarin.Forms;

namespace Community.Toolkit
{
    public class CheckBox : Button
    {
		public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(
			"IsChecked",
			typeof(bool),
			typeof(CheckBox),
			false,
			propertyChanged: (bindable, oldValue, newValue) =>
			{
				CheckBox checkbox = (CheckBox)bindable;
	            if (checkbox.OnImage != null && checkbox.OffImage != null)
	            {
                    checkbox.Text = "";
                    checkbox.Image = (bool)newValue ? checkbox.OnImage : checkbox.OffImage;
	            } 
                else
                {
					checkbox.Text = (bool)newValue ? "\u2611" : "\u2610";
				}

				EventHandler<bool> eventHandler = checkbox.CheckedChanged;
				if (eventHandler != null)
				{
					eventHandler(checkbox, (bool)newValue);
				}
			}
        );

		public static readonly BindableProperty OnImageProperty = BindableProperty.Create(
			"OnImage",
			typeof(string),
			typeof(CheckBox),
			null,
			propertyChanged: (bindable, oldValue, newValue) =>
			{
				CheckBox checkbox = (CheckBox)bindable;
				checkbox.changeImage();
			}
		);

		public static readonly BindableProperty OffImageProperty = BindableProperty.Create(
			"OffImage",
			typeof(string),
			typeof(CheckBox),
			null,
			propertyChanged: (bindable, oldValue, newValue) =>
			{
				CheckBox checkbox = (CheckBox)bindable;
				checkbox.changeImage();
			}
		);

		public event EventHandler<bool> CheckedChanged;

		public CheckBox()
		{
            this.Clicked += OnCheckBoxTapped;
            this.BackgroundColor = Color.Transparent;
			this.IsChecked = false;
            this.changeImage();
		}

		public bool IsChecked
		{
			set { SetValue(IsCheckedProperty, value); }
			get { return (bool)GetValue(IsCheckedProperty); }
		}

        public string OnImage
        {
			set { SetValue(OnImageProperty, value); }
			get { return (string)GetValue(OnImageProperty); }
		}

        public string OffImage
		{
			set { SetValue(OffImageProperty, value); }
			get { return (string)GetValue(OffImageProperty); }
		}

		// TapGestureRecognizer handler.
		void OnCheckBoxTapped(object sender, EventArgs args)
		{
			IsChecked = !IsChecked;
		}

        void changeImage(){
			if (this.OnImage != null && this.OffImage != null)
			{
				this.Text = "";
                this.Image = this.IsChecked ? this.OnImage : this.OffImage;
			}
			else
			{
                this.Text = this.IsChecked ? "\u2611" : "\u2610";
			}
        }

    }
}
