﻿using AutumnBox.Basic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutumnBox.Basic.Util
{
    public interface IDevicesGetter
    {
        DevicesList GetDevices();
    }
}