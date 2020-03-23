using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tws_lib
{
   public interface ILogHandler
    {
        void OnMessage(string message);

        void OnErrorMessage(string message);
    }
}
