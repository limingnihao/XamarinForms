using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Community.Helps;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform;

namespace Community.Toolkit
{
	public class ListGridView : ListView
    {
		private LogHelp logger = DependencyService.Get<LogHelp>().setName("ListGridView");

		private int column = 2;

        public ListGridView() : base()
        {
        }


        protected override void OnSizeAllocated(double width, double height)
        {
            logger.info("OnSizeAllocated - " + width + ", " + height);
            base.OnSizeAllocated(width, height);
        }

		protected override Cell CreateDefault(object item)
		{
			logger.info("CreateDefault - " + item);
			string text = null;
			if (item != null)
				text = item.ToString();

			return new TextCell { Text = text };
		}

	
        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
			var minimumSize = new Size(40, 40);
			Size request;

			double width = Math.Min(Device.Info.ScaledScreenSize.Width, Device.Info.ScaledScreenSize.Height) / column;

			var list = ItemsSource as IList;
			if (list != null )
			{
				// we can calculate this
				request = new Size(width, list.Count * RowHeight / this.column);
			}
			else
			{
				// probably not worth it
				request = new Size(width, Math.Max(Device.Info.ScaledScreenSize.Width, Device.Info.ScaledScreenSize.Height));
			}
            logger.info("OnMeasure - " + request.Width + ", " + request.Height);
			return new SizeRequest(request, minimumSize);
        }
    }
}
