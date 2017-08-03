using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Community.Helps
{
    public class HttpHelp
    {
       

		public const String CONTENT_TYPE_PLAIN = "text/plain";
		public const String CONTENT_TYPE_XML = "text/xml";
		public const String CONTENT_TYPE_HTML = "text/html";
		public const String CONTENT_TYPE_JS = "text/javascript";
		public const String CONTENT_TYPE_APP_JSON = "application/json";
		public const String CONTENT_TYPE_APP_EXCEL = "application/vnd.ms-excel";
		public const String CONTENT_TYPE_APP_FORM = "application/x-www-form-urlencoded";
		public const String DEFAULT_ENCODING = "UTF-8";
		public const int TIME_OUT_HTTP = 5000;

		Semaphore throttle;

		public HttpHelp(int maxConcurrent)
		{
			throttle = new Semaphore(maxConcurrent, maxConcurrent);
		}

		public Stream Get(Uri uri)
		{
			var req = WebRequest.Create(uri);
			var getTask = Task.Factory.FromAsync<System.Net.WebResponse>(req.BeginGetResponse, req.EndGetResponse, null);

			return getTask.ContinueWith(task =>
			{
				throttle.Release();
				var res = task.Result;
				return res.GetResponseStream();
			}).Result;
		}
    }
}
