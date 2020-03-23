using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IBApi;
using IBSampleApp.Messages;
using tws_lib;

namespace tws_lib
{
    public class TwsClient : ILogHandler
    {
        private static int currentClientId = 0;

        private TwsWrapper _wrapper;
        private EReaderMonitorSignal _signal;
        private EClientSocket _clientSocket;
        private SynchronizationContext _context;

        public TextWriter Logger
        {
            get; set;
        }

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

        public TwsClient()
        {
            ClientId = ++currentClientId;
            _wrapper = new TwsWrapper(this);
            _signal = new EReaderMonitorSignal();
            _clientSocket = new EClientSocket(_wrapper, _signal);
            _context = SynchronizationContext.Current;
        }

        public void Connect(int port = 7496, string host = "127.0.0.1")
        {
            OnMessage(String.Format("Connect called with host: {0} port: {1}", port, host));
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
                    OnErrorMessage("Failed to connect. Please check your connection attributes.");
                }
            }
        }

        public void Disconnect()
        {
            _clientSocket.eDisconnect();
        }

        #region ILogHandler

        protected void OnMessage(string message)
        {
            if (Logger != null)
            {
                Logger.WriteLine(message);
            }
        }

        protected void OnErrorMessage(string message)
        {
            OnMessage("Error: " + message);
        }

        #endregion
    }
}
