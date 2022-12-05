using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logging
{
    public static class LogContext
    {
        private static ILogger _logger;

        public static ILogger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new DefaultConsoleLogger();
                }
                return Logger;
            }

            set => _logger = value;
        }
    }
}
