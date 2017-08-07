using System;
using Community.Droid;
using Community.Helps;
using Xamarin.Forms;

[assembly: Dependency(typeof(Logger))]
namespace Community.Droid
{
    public class Logger : LogHelp
    {
        public void info(string msg)
        {
            System.Console.WriteLine("" + msg);
        }
    }
}
