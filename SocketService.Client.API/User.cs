﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocketService.Client.API
{
    public class User
    {
        public string UserName
        {
            get;
            set;
        }

        public bool IsMe
        {
            get;
            set;
        }

    }
}