using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Community.Views
{
    public partial class MobileLoginPage : ContentPage
    {
        private bool isRemeber = true;

        public MobileLoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 记住密码
        /// </summary>
        protected void onRemeberHandler(object sender, System.EventArgs e)
        {
            this.isRemeber = !this.isRemeber;
			if (this.isRemeber)
			{
			    this.imageRemeber.Image = "tick-mark.png";
			}
			else{
			    this.imageRemeber.Image = "";
			}
		}

        protected async void onLoginHandler(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
		}

    }
}
