using System;
using Community.Helps;
using Community.iOS.Helps;
using Xamarin.Forms;

[assembly: Dependency(typeof(Logger))]
namespace Community.iOS.Helps
{
    public class Logger : LogHelp
    {
        public string name { get; set; }
       
        public Logger(){
        }

        public Logger(string name){
            this.name = name;
        }

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
