using System;
using Community.Helps;
using Community.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(Logger))]
namespace Community.iOS
{
    public class Logger : LogHelp
    {
        public void info(string msg)
        {
            System.Console.WriteLine(msg);
        }
    }
}
