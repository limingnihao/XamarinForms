﻿using System;
using Xamarin.Forms;
using Community.Helps;
using Community.Droid.Helps;
using Matrix.Xmpp.Client;
using Matrix.Xmpp;

[assembly: Dependency(typeof(Xmpper))]
namespace Community.Droid.Helps
{
    public class Xmpper : XmppHelp
    {
        private Logger logger = new Logger("Xmpper");

		XmppClient xmppClient = null;

        public void connent(string ip, int port, string hostname, string username, string password)
        {
            logger.info("connent - ip=" + ip + ", port=" + port + ", hostname=" + hostname + ", username=" + username + ", password=" + password);
            this.xmppClient = new XmppClient { XmppDomain = ip, Port = port, Hostname=hostname, Username = username, Password = password };
            this.xmppClient.OnLogin += this.onLoginHandler;
            this.xmppClient.OnRosterEnd += this.OnRosterEndHandler;
            this.xmppClient.OnMessage += this.onMessageHandler; 
            this.xmppClient.Open();
        }

        public void sendMessage(string targetId, string msg)
        {
			xmppClient.Send(new Message 
            { 
                To = targetId, 
                Type = MessageType.Chat, 
                Body = msg 
            });
        }

        private void onLoginHandler(object sender, System.EventArgs e)
		{
            logger.info("onLoginHandler");
		}

		private void OnRosterEndHandler(object sender, System.EventArgs e)
		{
			logger.info("OnRosterEndHandler");
		}

		private void onMessageHandler(object sender, System.EventArgs e)
		{
			logger.info("onMessageHandler");
		}
    }
}
