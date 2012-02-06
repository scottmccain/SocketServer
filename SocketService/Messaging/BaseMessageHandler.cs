﻿using System;
using log4net;
using System.Reflection;

namespace SocketServer.Messaging
{
    [Serializable]
    public abstract class BaseMessageHandler : ICommand
    {
        protected static ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public abstract void Execute();
    }
}