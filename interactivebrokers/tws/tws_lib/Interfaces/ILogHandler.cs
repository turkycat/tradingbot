using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwsLib
{
   public interface ILogHandler
    {
        void Log(string message);

        void LogError(string message);
    }
}
