using Application.Logging;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILogger = Application.Logging.ILogger;

namespace Application.Testing.Logging
{
    public class TestLogger : ILogger
    {
        private void Log(string prefix, string message) => TestContext.WriteLine(prefix + ": " + message);
        public void Error(string message) => Log(nameof(Error), message);

        public void Info(string message) => Log(nameof(Info), message);

        public void Warning(string message) => Log(nameof(Warning), message);
    }
}
