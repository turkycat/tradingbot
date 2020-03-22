using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IBApi;

namespace tws_lib
{
    public class TwsClient : EWrapper
    {
        static int currentClientId = 0;

        private EReaderMonitorSignal _signal;
        private EClientSocket _clientSocket;
        private SynchronizationContext _syncContext;

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
            _signal = new EReaderMonitorSignal();
            _clientSocket = new EClientSocket(this, _signal);
            _syncContext = SynchronizationContext.Current;
        }

        public void Connect(int port = 7496, string host = "127.0.0.1")
        {
            LogMessage(String.Format("Connect called with host: {0} port: {1}", port, host));
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
                    HandleErrorMessage("Failed to connect. Please check your connection attributes.");
                }
            }
        }

        public void Disconnect()
        {
            _clientSocket.eDisconnect();
        }

        private void LogMessage(string message)
        {
            if(Logger != null)
            {
                Logger.WriteLine(message);
            }
        }

        private void HandleErrorMessage(string message)
        {
            LogMessage(message);
        }

        /*
         * EWrapper
         */
        void EWrapper.error(Exception e)
        {
            HandleErrorMessage("Exception occurred: " + e.Message);
        }

        void EWrapper.error(int id, int errorCode, string errorMsg)
        {
            HandleErrorMessage(String.Format("An error occurred with id: {0}. Error Code: {1}, Error Message: {2}", id, errorCode, errorMsg));
        }

        void EWrapper.error(string str)
        {
            HandleErrorMessage(str);
        }

        public void accountDownloadEnd(string account)
        {
            LogMessage("accountDownloadEnd");
        }

        public void accountSummary(int reqId, string account, string tag, string value, string currency)
        {
            LogMessage("accountSummary");
        }

        public void accountSummaryEnd(int reqId)
        {
            LogMessage("accountSummaryEnd");
        }

        public void accountUpdateMulti(int requestId, string account, string modelCode, string key, string value, string currency)
        {
            LogMessage("accountUpdateMulti");
        }

        public void accountUpdateMultiEnd(int requestId)
        {
            LogMessage("accountUpdateMultiEnd");
        }

        public void bondContractDetails(int reqId, ContractDetails contract)
        {
            LogMessage("bondContractDetails");
        }

        public void commissionReport(CommissionReport commissionReport)
        {
            LogMessage("commissionReport");
        }

        public void completedOrder(Contract contract, Order order, OrderState orderState)
        {
            LogMessage("completedOrder");
        }

        public void completedOrdersEnd()
        {
            LogMessage("completedOrdersEnd");
        }

        public void connectAck()
        {
            LogMessage("connectAck");
        }

        public void connectionClosed()
        {
            LogMessage("connectionClosed");
        }

        public void contractDetails(int reqId, ContractDetails contractDetails)
        {
            LogMessage("contractDetails");
        }

        public void contractDetailsEnd(int reqId)
        {
            LogMessage("contractDetailsEnd");
        }

        public void currentTime(long time)
        {
            LogMessage("currentTime");
        }

        public void deltaNeutralValidation(int reqId, DeltaNeutralContract deltaNeutralContract)
        {
            LogMessage("deltaNeutralValidation");
        }

        public void displayGroupList(int reqId, string groups)
        {
            LogMessage("displayGroupList");
        }

        public void displayGroupUpdated(int reqId, string contractInfo)
        {
            LogMessage("displayGroupUpdated");
        }

        public void error(Exception e)
        {
            LogMessage("error");
        }

        public void error(string str)
        {
            LogMessage("error");
        }

        public void error(int id, int errorCode, string errorMsg)
        {
            LogMessage("error");
        }

        public void execDetails(int reqId, Contract contract, Execution execution)
        {
            LogMessage("execDetails");
        }

        public void execDetailsEnd(int reqId)
        {
            LogMessage("execDetailsEnd");
        }

        public void familyCodes(FamilyCode[] familyCodes)
        {
            LogMessage("familyCodes");
        }

        public void fundamentalData(int reqId, string data)
        {
            LogMessage("fundamentalData");
        }

        public void headTimestamp(int reqId, string headTimestamp)
        {
            LogMessage("headTimestamp");
        }

        public void histogramData(int reqId, HistogramEntry[] data)
        {
            LogMessage("histogramData");
        }

        public void historicalData(int reqId, Bar bar)
        {
            LogMessage("historicalData");
        }

        public void historicalDataEnd(int reqId, string start, string end)
        {
            LogMessage("historicalDataEnd");
        }

        public void historicalDataUpdate(int reqId, Bar bar)
        {
            LogMessage("historicalDataUpdate");
        }

        public void historicalNews(int requestId, string time, string providerCode, string articleId, string headline)
        {
            LogMessage("historicalNews");
        }

        public void historicalNewsEnd(int requestId, bool hasMore)
        {
            LogMessage("historicalNewsEnd");
        }

        public void historicalTicks(int reqId, HistoricalTick[] ticks, bool done)
        {
            LogMessage("historicalTicks");
        }

        public void historicalTicksBidAsk(int reqId, HistoricalTickBidAsk[] ticks, bool done)
        {
            LogMessage("historicalTicksBidAsk");
        }

        public void historicalTicksLast(int reqId, HistoricalTickLast[] ticks, bool done)
        {
            LogMessage("historicalTicksLast");
        }

        public void managedAccounts(string accountsList)
        {
            LogMessage("managedAccounts");
        }

        public void marketDataType(int reqId, int marketDataType)
        {
            LogMessage("marketDataType");
        }

        public void marketRule(int marketRuleId, PriceIncrement[] priceIncrements)
        {
            LogMessage("marketRule");
        }

        public void mktDepthExchanges(DepthMktDataDescription[] depthMktDataDescriptions)
        {
            LogMessage("mktDepthExchanges");
        }

        public void newsArticle(int requestId, int articleType, string articleText)
        {
            LogMessage("newsArticle");
        }

        public void newsProviders(NewsProvider[] newsProviders)
        {
            LogMessage("newsProviders");
        }

        public void nextValidId(int orderId)
        {
            LogMessage("nextValidId");
        }

        public void openOrder(int orderId, Contract contract, Order order, OrderState orderState)
        {
            LogMessage("openOrder");
        }

        public void openOrderEnd()
        {
            LogMessage("openOrderEnd");
        }

        public void orderBound(long orderId, int apiClientId, int apiOrderId)
        {
            LogMessage("orderBound");
        }

        public void orderStatus(int orderId, string status, double filled, double remaining, double avgFillPrice, int permId, int parentId, double lastFillPrice, int clientId, string whyHeld, double mktCapPrice)
        {
            LogMessage("orderStatus");
        }

        public void pnl(int reqId, double dailyPnL, double unrealizedPnL, double realizedPnL)
        {
            LogMessage("pnl");
        }

        public void pnlSingle(int reqId, int pos, double dailyPnL, double unrealizedPnL, double realizedPnL, double value)
        {
            LogMessage("pnlSingle");
        }

        public void position(string account, Contract contract, double pos, double avgCost)
        {
            LogMessage("position");
        }

        public void positionEnd()
        {
            LogMessage("positionEnd");
        }

        public void positionMulti(int requestId, string account, string modelCode, Contract contract, double pos, double avgCost)
        {
            LogMessage("positionMulti");
        }

        public void positionMultiEnd(int requestId)
        {
            LogMessage("positionMultiEnd");
        }

        public void realtimeBar(int reqId, long date, double open, double high, double low, double close, long volume, double WAP, int count)
        {
            LogMessage("realtimeBar");
        }

        public void receiveFA(int faDataType, string faXmlData)
        {
            LogMessage("receiveFA");
        }

        public void rerouteMktDataReq(int reqId, int conId, string exchange)
        {
            LogMessage("rerouteMktDataReq");
        }

        public void rerouteMktDepthReq(int reqId, int conId, string exchange)
        {
            LogMessage("rerouteMktDepthReq");
        }

        public void scannerData(int reqId, int rank, ContractDetails contractDetails, string distance, string benchmark, string projection, string legsStr)
        {
            LogMessage("scannerData");
        }

        public void scannerDataEnd(int reqId)
        {
            LogMessage("scannerDataEnd");
        }

        public void scannerParameters(string xml)
        {
            LogMessage("scannerParameters");
        }

        public void securityDefinitionOptionParameter(int reqId, string exchange, int underlyingConId, string tradingClass, string multiplier, HashSet<string> expirations, HashSet<double> strikes)
        {
            LogMessage("securityDefinitionOptionParameter");
        }

        public void securityDefinitionOptionParameterEnd(int reqId)
        {
            LogMessage("securityDefinitionOptionParameterEnd");
        }

        public void smartComponents(int reqId, Dictionary<int, KeyValuePair<string, char>> theMap)
        {
            LogMessage("smartComponents");
        }

        public void softDollarTiers(int reqId, SoftDollarTier[] tiers)
        {
            LogMessage("softDollarTiers");
        }

        public void symbolSamples(int reqId, ContractDescription[] contractDescriptions)
        {
            LogMessage("symbolSamples");
        }

        public void tickByTickAllLast(int reqId, int tickType, long time, double price, int size, TickAttribLast tickAttriblast, string exchange, string specialConditions)
        {
            LogMessage("tickByTickAllLast");
        }

        public void tickByTickBidAsk(int reqId, long time, double bidPrice, double askPrice, int bidSize, int askSize, TickAttribBidAsk tickAttribBidAsk)
        {
            LogMessage("tickByTickBidAsk");
        }

        public void tickByTickMidPoint(int reqId, long time, double midPoint)
        {
            LogMessage("tickByTickMidPoint");
        }

        public void tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints, double impliedFuture, int holdDays, string futureLastTradeDate, double dividendImpact, double dividendsToLastTradeDate)
        {
            LogMessage("tickEFP");
        }

        public void tickGeneric(int tickerId, int field, double value)
        {
            LogMessage("tickGeneric");
        }

        public void tickNews(int tickerId, long timeStamp, string providerCode, string articleId, string headline, string extraData)
        {
            LogMessage("tickNews");
        }

        public void tickOptionComputation(int tickerId, int field, double impliedVolatility, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice)
        {
            LogMessage("tickOptionComputation");
        }

        public void tickPrice(int tickerId, int field, double price, TickAttrib attribs)
        {
            LogMessage("tickPrice");
        }

        public void tickReqParams(int tickerId, double minTick, string bboExchange, int snapshotPermissions)
        {
            LogMessage("tickReqParams");
        }

        public void tickSize(int tickerId, int field, int size)
        {
            LogMessage("tickSize");
        }

        public void tickSnapshotEnd(int tickerId)
        {
            LogMessage("tickSnapshotEnd");
        }

        public void tickString(int tickerId, int field, string value)
        {
            LogMessage("tickString");
        }

        public void updateAccountTime(string timestamp)
        {
            LogMessage("updateAccountTime");
        }

        public void updateAccountValue(string key, string value, string currency, string accountName)
        {
            LogMessage("updateAccountValue");
        }

        public void updateMktDepth(int tickerId, int position, int operation, int side, double price, int size)
        {
            LogMessage("updateMktDepth");
        }

        public void updateMktDepthL2(int tickerId, int position, string marketMaker, int operation, int side, double price, int size, bool isSmartDepth)
        {
            LogMessage("updateMktDepthL2");
        }

        public void updateNewsBulletin(int msgId, int msgType, string message, string origExchange)
        {
            LogMessage("updateNewsBulletin");
        }

        public void updatePortfolio(Contract contract, double position, double marketPrice, double marketValue, double averageCost, double unrealizedPNL, double realizedPNL, string accountName)
        {
            LogMessage("updatePortfolio");
        }

        public void verifyAndAuthCompleted(bool isSuccessful, string errorText)
        {
            LogMessage("verifyAndAuthCompleted");
        }

        public void verifyAndAuthMessageAPI(string apiData, string xyzChallenge)
        {
            LogMessage("verifyAndAuthMessageAPI");
        }

        public void verifyCompleted(bool isSuccessful, string errorText)
        {
            LogMessage("verifyCompleted");
        }

        public void verifyMessageAPI(string apiData)
        {
            LogMessage("verifyMessageAPI");
        }
    }
}
