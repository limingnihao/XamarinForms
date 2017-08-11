using System;
using Community.Helps;
using Community.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(Logger))]
namespace Community.iOS
{
    public class Logger : LogHelp
    {
        private string name = "";
       
        public LogHelp setName(string name)
        {
            this.name = name;
            return this;
        }

		public void info(string msg)
		{
			System.Console.WriteLine("[" + name + "] - " + msg);
		}
    }

}
