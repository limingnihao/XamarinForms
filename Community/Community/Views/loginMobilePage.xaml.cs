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
			    this.imageRemeber.Image = "check_mark_1.png";
			}
			else{
			    this.imageRemeber.Image = "check_mark_0.png";
			}
		}

        void onLoginHandler(object sender, System.EventArgs e)
        {
			App.Current.MainPage = new NavigationPage(new MainNavPage());
		}

    }
}
