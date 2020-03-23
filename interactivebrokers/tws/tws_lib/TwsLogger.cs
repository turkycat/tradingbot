using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwsLib
{
    public class TwsLogger : ILogHandler
    {
        TextWriter _logger;

        public TwsLogger(TextWriter logger)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            if (_logger != null)
            {
                _logger.WriteLine(message);
            }
        }

        public void LogError(string message)
        {
            Log("Error: " + message);
        }
    }
}
