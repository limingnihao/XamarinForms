using System;
using CoreGraphics;
using Library.Map.Baidu.Base;
using Library.Map.Baidu.Map;
using UIKit;

namespace iOSBaiduMap
{
	public class CustomViewController : UIViewController
	{
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = UIColor.White;
			Title = "My Custom View Controller";

			var btn = UIButton.FromType(UIButtonType.System);
			btn.Frame = new CGRect(20, 200, 280, 44);
			btn.SetTitle("Click Me", UIControlState.Normal);

			var user = new UIViewController();
			user.View.BackgroundColor = UIColor.Magenta;

			btn.TouchUpInside += (sender, e) => {
				this.NavigationController.PushViewController(user, true);
			};
            BMKMapView mapView = new BMKMapView();

            mapView.Frame = View.Frame;
			mapView.MapType = BMKMapType.BMKMapTypeStandard;
			//View.AddSubview(btn);
            View.AddSubview(mapView);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}


	}
}
