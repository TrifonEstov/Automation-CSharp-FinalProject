﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logging
{
    public interface ILogger
    {
        void Info(string message);
        void Warning(string message);
        void Error(string message);
    }
}
