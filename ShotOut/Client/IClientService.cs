﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShotOut.Client
{
    internal interface IClientService
    {
        int ConnectToServer(string server, string nickname);
    }
}
