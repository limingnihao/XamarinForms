﻿using System;
namespace Community.Helps
{
    public interface XmppHelp
    {
        void connent(String ip, int port, String hostname, String username, String password);

        void sendMessage(String targetId, String msg);

    }
}
