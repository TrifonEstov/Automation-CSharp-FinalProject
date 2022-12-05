using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logging
{
    public class DefaultConsoleLogger : ILogger
    {
        private void Log(string prefix, string message) => Console.WriteLine(prefix + ": " + message);
        public void Error(string message) => Log(nameof(Error), message);

        public void Info(string message) => Log(nameof(Info), message);

        public void Warning(string message) => Log(nameof(Warning), message);
    }
}
