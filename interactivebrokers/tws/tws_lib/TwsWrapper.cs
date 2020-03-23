using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwsLib.Messages;

namespace TwsLib
{
    public class TwsWrapper : EWrapper
    {
        ILogHandler _handler;
        private SynchronizationContext _context;

        public TwsWrapper(ILogHandler handler)
        {
            _handler = handler;
            _context = SynchronizationContext.Current;
        }

        /*
         * EWrapper
         */
        void EWrapper.error(Exception e)
        {
            _handler.LogError("Exception occurred: " + e.Message);
        }

        void EWrapper.error(int id, int errorCode, string errorMsg)
        {
            _handler.LogError(String.Format("An error occurred with id: {0}. Error Code: {1}, Error Message: {2}", id, errorCode, errorMsg));
        }

        void EWrapper.error(string str)
        {
            _handler.LogError(str);
        }

        public void accountDownloadEnd(string account)
        {
            _handler.Log("accountDownloadEnd");
        }

        public void accountSummary(int reqId, string account, string tag, string value, string currency)
        {
            _handler.Log("accountSummary");
        }

        public void accountSummaryEnd(int reqId)
        {
            _handler.Log("accountSummaryEnd");
        }

        public void accountUpdateMulti(int requestId, string account, string modelCode, string key, string value, string currency)
        {
            _handler.Log("accountUpdateMulti");
        }

        public void accountUpdateMultiEnd(int requestId)
        {
            _handler.Log("accountUpdateMultiEnd");
        }

        public void bondContractDetails(int reqId, ContractDetails contract)
        {
            _handler.Log("bondContractDetails");
        }

        public void commissionReport(CommissionReport commissionReport)
        {
            _handler.Log("commissionReport");
        }

        public void completedOrder(Contract contract, Order order, OrderState orderState)
        {
            _handler.Log("completedOrder");
        }

        public void completedOrdersEnd()
        {
            _handler.Log("completedOrdersEnd");
        }

        public void connectAck()
        {
            _handler.Log("connectAck");
        }

        public void connectionClosed()
        {
            _handler.Log("connectionClosed");
        }

        public void contractDetails(int reqId, ContractDetails contractDetails)
        {
            _handler.Log("contractDetails");
        }

        public void contractDetailsEnd(int reqId)
        {
            _handler.Log("contractDetailsEnd");
        }

        public void currentTime(long time)
        {
            _handler.Log("currentTime");
        }

        public void deltaNeutralValidation(int reqId, DeltaNeutralContract deltaNeutralContract)
        {
            _handler.Log("deltaNeutralValidation");
        }

        public void displayGroupList(int reqId, string groups)
        {
            _handler.Log("displayGroupList");
        }

        public void displayGroupUpdated(int reqId, string contractInfo)
        {
            _handler.Log("displayGroupUpdated");
        }

        public void error(Exception e)
        {
            _handler.Log("error");
        }

        public void error(string str)
        {
            _handler.Log("error");
        }

        public void error(int id, int errorCode, string errorMsg)
        {
            _handler.Log("error");
        }

        public void execDetails(int reqId, Contract contract, Execution execution)
        {
            _handler.Log("execDetails");
        }

        public void execDetailsEnd(int reqId)
        {
            _handler.Log("execDetailsEnd");
        }

        public void familyCodes(FamilyCode[] familyCodes)
        {
            _handler.Log("familyCodes");
        }

        public event Action<FundamentalsMessage> FundamentalData;

        public void fundamentalData(int reqId, string data)
        {
            _handler.Log("fundamentalData");

            var tmp = FundamentalData;

            _context.Post((t) => tmp(new FundamentalsMessage(data)), null);
        }

        public void headTimestamp(int reqId, string headTimestamp)
        {
            _handler.Log("headTimestamp");
        }

        public void histogramData(int reqId, HistogramEntry[] data)
        {
            _handler.Log("histogramData");
        }

        public void historicalData(int reqId, Bar bar)
        {
            _handler.Log("historicalData");
        }

        public void historicalDataEnd(int reqId, string start, string end)
        {
            _handler.Log("historicalDataEnd");
        }

        public void historicalDataUpdate(int reqId, Bar bar)
        {
            _handler.Log("historicalDataUpdate");
        }

        public void historicalNews(int requestId, string time, string providerCode, string articleId, string headline)
        {
            _handler.Log("historicalNews");
        }

        public void historicalNewsEnd(int requestId, bool hasMore)
        {
            _handler.Log("historicalNewsEnd");
        }

        public void historicalTicks(int reqId, HistoricalTick[] ticks, bool done)
        {
            _handler.Log("historicalTicks");
        }

        public void historicalTicksBidAsk(int reqId, HistoricalTickBidAsk[] ticks, bool done)
        {
            _handler.Log("historicalTicksBidAsk");
        }

        public void historicalTicksLast(int reqId, HistoricalTickLast[] ticks, bool done)
        {
            _handler.Log("historicalTicksLast");
        }

        public void managedAccounts(string accountsList)
        {
            _handler.Log("managedAccounts");
        }

        public void marketDataType(int reqId, int marketDataType)
        {
            _handler.Log("marketDataType");
        }

        public void marketRule(int marketRuleId, PriceIncrement[] priceIncrements)
        {
            _handler.Log("marketRule");
        }

        public void mktDepthExchanges(DepthMktDataDescription[] depthMktDataDescriptions)
        {
            _handler.Log("mktDepthExchanges");
        }

        public void newsArticle(int requestId, int articleType, string articleText)
        {
            _handler.Log("newsArticle");
        }

        public void newsProviders(NewsProvider[] newsProviders)
        {
            _handler.Log("newsProviders");
        }

        public void nextValidId(int orderId)
        {
            _handler.Log("nextValidId");
        }

        public void openOrder(int orderId, Contract contract, Order order, OrderState orderState)
        {
            _handler.Log("openOrder");
        }

        public void openOrderEnd()
        {
            _handler.Log("openOrderEnd");
        }

        public void orderBound(long orderId, int apiClientId, int apiOrderId)
        {
            _handler.Log("orderBound");
        }

        public void orderStatus(int orderId, string status, double filled, double remaining, double avgFillPrice, int permId, int parentId, double lastFillPrice, int clientId, string whyHeld, double mktCapPrice)
        {
            _handler.Log("orderStatus");
        }

        public void pnl(int reqId, double dailyPnL, double unrealizedPnL, double realizedPnL)
        {
            _handler.Log("pnl");
        }

        public void pnlSingle(int reqId, int pos, double dailyPnL, double unrealizedPnL, double realizedPnL, double value)
        {
            _handler.Log("pnlSingle");
        }

        public void position(string account, Contract contract, double pos, double avgCost)
        {
            _handler.Log("position");
        }

        public void positionEnd()
        {
            _handler.Log("positionEnd");
        }

        public void positionMulti(int requestId, string account, string modelCode, Contract contract, double pos, double avgCost)
        {
            _handler.Log("positionMulti");
        }

        public void positionMultiEnd(int requestId)
        {
            _handler.Log("positionMultiEnd");
        }

        public void realtimeBar(int reqId, long date, double open, double high, double low, double close, long volume, double WAP, int count)
        {
            _handler.Log("realtimeBar");
        }

        public void receiveFA(int faDataType, string faXmlData)
        {
            _handler.Log("receiveFA");
        }

        public void rerouteMktDataReq(int reqId, int conId, string exchange)
        {
            _handler.Log("rerouteMktDataReq");
        }

        public void rerouteMktDepthReq(int reqId, int conId, string exchange)
        {
            _handler.Log("rerouteMktDepthReq");
        }

        public void scannerData(int reqId, int rank, ContractDetails contractDetails, string distance, string benchmark, string projection, string legsStr)
        {
            _handler.Log("scannerData");
        }

        public void scannerDataEnd(int reqId)
        {
            _handler.Log("scannerDataEnd");
        }

        public void scannerParameters(string xml)
        {
            _handler.Log("scannerParameters");
        }

        public void securityDefinitionOptionParameter(int reqId, string exchange, int underlyingConId, string tradingClass, string multiplier, HashSet<string> expirations, HashSet<double> strikes)
        {
            _handler.Log("securityDefinitionOptionParameter");
        }

        public void securityDefinitionOptionParameterEnd(int reqId)
        {
            _handler.Log("securityDefinitionOptionParameterEnd");
        }

        public void smartComponents(int reqId, Dictionary<int, KeyValuePair<string, char>> theMap)
        {
            _handler.Log("smartComponents");
        }

        public void softDollarTiers(int reqId, SoftDollarTier[] tiers)
        {
            _handler.Log("softDollarTiers");
        }

        public void symbolSamples(int reqId, ContractDescription[] contractDescriptions)
        {
            _handler.Log("symbolSamples");
        }

        public void tickByTickAllLast(int reqId, int tickType, long time, double price, int size, TickAttribLast tickAttriblast, string exchange, string specialConditions)
        {
            _handler.Log("tickByTickAllLast");
        }

        public void tickByTickBidAsk(int reqId, long time, double bidPrice, double askPrice, int bidSize, int askSize, TickAttribBidAsk tickAttribBidAsk)
        {
            _handler.Log("tickByTickBidAsk");
        }

        public void tickByTickMidPoint(int reqId, long time, double midPoint)
        {
            _handler.Log("tickByTickMidPoint");
        }

        public void tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints, double impliedFuture, int holdDays, string futureLastTradeDate, double dividendImpact, double dividendsToLastTradeDate)
        {
            _handler.Log("tickEFP");
        }

        public void tickGeneric(int tickerId, int field, double value)
        {
            _handler.Log("tickGeneric");
        }

        public void tickNews(int tickerId, long timeStamp, string providerCode, string articleId, string headline, string extraData)
        {
            _handler.Log("tickNews");
        }

        public void tickOptionComputation(int tickerId, int field, double impliedVolatility, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice)
        {
            _handler.Log("tickOptionComputation");
        }

        public void tickPrice(int tickerId, int field, double price, TickAttrib attribs)
        {
            _handler.Log("tickPrice");
        }

        public void tickReqParams(int tickerId, double minTick, string bboExchange, int snapshotPermissions)
        {
            _handler.Log("tickReqParams");
        }

        public void tickSize(int tickerId, int field, int size)
        {
            _handler.Log("tickSize");
        }

        public void tickSnapshotEnd(int tickerId)
        {
            _handler.Log("tickSnapshotEnd");
        }

        public void tickString(int tickerId, int field, string value)
        {
            _handler.Log("tickString");
        }

        public void updateAccountTime(string timestamp)
        {
            _handler.Log("updateAccountTime");
        }

        public void updateAccountValue(string key, string value, string currency, string accountName)
        {
            _handler.Log("updateAccountValue");
        }

        public void updateMktDepth(int tickerId, int position, int operation, int side, double price, int size)
        {
            _handler.Log("updateMktDepth");
        }

        public void updateMktDepthL2(int tickerId, int position, string marketMaker, int operation, int side, double price, int size, bool isSmartDepth)
        {
            _handler.Log("updateMktDepthL2");
        }

        public void updateNewsBulletin(int msgId, int msgType, string message, string origExchange)
        {
            _handler.Log("updateNewsBulletin");
        }

        public void updatePortfolio(Contract contract, double position, double marketPrice, double marketValue, double averageCost, double unrealizedPNL, double realizedPNL, string accountName)
        {
            _handler.Log("updatePortfolio");
        }

        public void verifyAndAuthCompleted(bool isSuccessful, string errorText)
        {
            _handler.Log("verifyAndAuthCompleted");
        }

        public void verifyAndAuthMessageAPI(string apiData, string xyzChallenge)
        {
            _handler.Log("verifyAndAuthMessageAPI");
        }

        public void verifyCompleted(bool isSuccessful, string errorText)
        {
            _handler.Log("verifyCompleted");
        }

        public void verifyMessageAPI(string apiData)
        {
            _handler.Log("verifyMessageAPI");
        }
    }
}
