using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TwsLib;

namespace tws_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing...");

            TwsClient client = new TwsClient(Console.Out);

            client.Connect(7497);




            while(client.IsConnected)
            {
                Thread.Sleep(5000);
            }
        }
    }

    
}
