﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILoggerService
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogError(string message);
    }
}
