using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Community.Helps
{
    public class HttpHelp
    {

		private static LogHelp logger = DependencyService.Get<LogHelp>();

        private static HttpHelp HTTP_HELP = null;

        public static HttpHelp getInstance(){
            if(HTTP_HELP == null){
                HTTP_HELP = new HttpHelp();
            }
			return HTTP_HELP;
		}

		public HttpHelp()
		{
		}

        public async Task<string> Get(String url)
		{
            Uri uri = new Uri(url);
            HttpWebRequest req = WebRequest.CreateHttp(uri);
            req.Method = "GET";
            WebResponse res = await req.GetResponseAsync();
            Stream input = res.GetResponseStream();
			byte[] buffer = new byte[16 * 1024];
			using (MemoryStream ms = new MemoryStream())
			{
				int read;
				while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
				{
				    ms.Write(buffer, 0, read);
				}
				byte[] results = ms.ToArray();
				String str = System.Text.Encoding.UTF8.GetString(results, 0, results.Length);
				return str;
			}

			//         var getTask = Task.Factory.FromAsync<WebResponse>(req.BeginGetResponse, req.EndGetResponse, null);
			//         return getTask.ContinueWith(task =>
			//{
			//	var res = task.Result;
			//	Stream input = res.GetResponseStream();
			//	byte[] buffer = new byte[16 * 1024];
			//	using (MemoryStream ms = new MemoryStream())
			//	{
			//		int read;
			//		while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
			//		{
			//			ms.Write(buffer, 0, read);
			//		}
			//		byte[] results = ms.ToArray();
			//		String str = System.Text.Encoding.UTF8.GetString(results, 0, results.Length);
			

            //                 return str;
			//	}
			//}).Result;
		}
    }
}
