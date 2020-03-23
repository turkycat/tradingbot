using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IBApi;
using TwsLib;

namespace TwsLib
{
    public class TwsClient
    {
        private static int currentClientId = 0;
        private static int currentRequestId = 0;

        private TwsLogger _logger;
        private TwsWrapper _wrapper;
        private EReaderMonitorSignal _signal;
        private EClientSocket _clientSocket;

        public bool IsConnected
        {
            get
            {
                return _clientSocket.IsConnected();
            }
        }

        public int ClientId
        {
            get; private set;
        }

        public TwsClient(TextWriter writer)
        {
            ClientId = ++currentClientId;
            _logger = new TwsLogger(writer);
            _wrapper = new TwsWrapper(_logger);
            _signal = new EReaderMonitorSignal();
            _clientSocket = new EClientSocket(_wrapper, _signal);
        }

        public void Connect(int port = 7496, string host = "127.0.0.1")
        {
            _logger.Log(String.Format("Connect called with host: {0} port: {1}", port, host));
            if (!IsConnected)
            {
                if (host == null || host.Equals(""))
                    host = "127.0.0.1";
                try
                {
                    _clientSocket.eConnect(host, port, ClientId);

                    var reader = new EReader(_clientSocket, _signal);

                    reader.Start();

                    new Thread(() => { while (_clientSocket.IsConnected()) { _signal.waitForSignal(); reader.processMsgs(); } }) { IsBackground = true }.Start();
                }
                catch (Exception)
                {
                    _logger.LogError("Failed to connect. Please check your connection attributes.");
                }
            }
        }

        public void Disconnect()
        {
            _clientSocket.eDisconnect();
        }

        public int NextRequestId()
        {
            return ++currentRequestId;
        }
    }
}
