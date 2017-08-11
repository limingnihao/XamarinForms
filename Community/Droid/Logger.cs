using System;
using Community.Droid;
using Community.Helps;
using Xamarin.Forms;

[assembly: Dependency(typeof(Logger))]
namespace Community.Droid
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
