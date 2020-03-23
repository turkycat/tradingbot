using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tws_lib
{
    public class TwsWrapper : EWrapper
    {
        private static int currentRequestId = 0;

        ILogHandler _handler;

        public TwsWrapper(ILogHandler handler)
        {
            _handler = handler;
        }

        private int NextRequestId()
        {
            return ++currentRequestId;
        }

        /*
         * EWrapper
         */
        void EWrapper.error(Exception e)
        {
            _handler.OnErrorMessage("Exception occurred: " + e.Message);
        }

        void EWrapper.error(int id, int errorCode, string errorMsg)
        {
            _handler.OnErrorMessage(String.Format("An error occurred with id: {0}. Error Code: {1}, Error Message: {2}", id, errorCode, errorMsg));
        }

        void EWrapper.error(string str)
        {
            _handler.OnErrorMessage(str);
        }

        public void accountDownloadEnd(string account)
        {
            _handler.OnMessage("accountDownloadEnd");
        }

        public void accountSummary(int reqId, string account, string tag, string value, string currency)
        {
            _handler.OnMessage("accountSummary");
        }

        public void accountSummaryEnd(int reqId)
        {
            _handler.OnMessage("accountSummaryEnd");
        }

        public void accountUpdateMulti(int requestId, string account, string modelCode, string key, string value, string currency)
        {
            _handler.OnMessage("accountUpdateMulti");
        }

        public void accountUpdateMultiEnd(int requestId)
        {
            _handler.OnMessage("accountUpdateMultiEnd");
        }

        public void bondContractDetails(int reqId, ContractDetails contract)
        {
            _handler.OnMessage("bondContractDetails");
        }

        public void commissionReport(CommissionReport commissionReport)
        {
            _handler.OnMessage("commissionReport");
        }

        public void completedOrder(Contract contract, Order order, OrderState orderState)
        {
            _handler.OnMessage("completedOrder");
        }

        public void completedOrdersEnd()
        {
            _handler.OnMessage("completedOrdersEnd");
        }

        public void connectAck()
        {
            _handler.OnMessage("connectAck");
        }

        public void connectionClosed()
        {
            _handler.OnMessage("connectionClosed");
        }

        public void contractDetails(int reqId, ContractDetails contractDetails)
        {
            _handler.OnMessage("contractDetails");
        }

        public void contractDetailsEnd(int reqId)
        {
            _handler.OnMessage("contractDetailsEnd");
        }

        public void currentTime(long time)
        {
            _handler.OnMessage("currentTime");
        }

        public void deltaNeutralValidation(int reqId, DeltaNeutralContract deltaNeutralContract)
        {
            _handler.OnMessage("deltaNeutralValidation");
        }

        public void displayGroupList(int reqId, string groups)
        {
            _handler.OnMessage("displayGroupList");
        }

        public void displayGroupUpdated(int reqId, string contractInfo)
        {
            _handler.OnMessage("displayGroupUpdated");
        }

        public void error(Exception e)
        {
            _handler.OnMessage("error");
        }

        public void error(string str)
        {
            _handler.OnMessage("error");
        }

        public void error(int id, int errorCode, string errorMsg)
        {
            _handler.OnMessage("error");
        }

        public void execDetails(int reqId, Contract contract, Execution execution)
        {
            _handler.OnMessage("execDetails");
        }

        public void execDetailsEnd(int reqId)
        {
            _handler.OnMessage("execDetailsEnd");
        }

        public void familyCodes(FamilyCode[] familyCodes)
        {
            _handler.OnMessage("familyCodes");
        }

        public event Action<FundamentalsMessage> FundamentalData;

        public void fundamentalData(int reqId, string data)
        {
            _handler.OnMessage("fundamentalData");

            var tmp = FundamentalData;

            _context.Post((t) => tmp(new FundamentalsMessage(data)), null);
        }

        public void headTimestamp(int reqId, string headTimestamp)
        {
            _handler.OnMessage("headTimestamp");
        }

        public void histogramData(int reqId, HistogramEntry[] data)
        {
            _handler.OnMessage("histogramData");
        }

        public void historicalData(int reqId, Bar bar)
        {
            _handler.OnMessage("historicalData");
        }

        public void historicalDataEnd(int reqId, string start, string end)
        {
            _handler.OnMessage("historicalDataEnd");
        }

        public void historicalDataUpdate(int reqId, Bar bar)
        {
            _handler.OnMessage("historicalDataUpdate");
        }

        public void historicalNews(int requestId, string time, string providerCode, string articleId, string headline)
        {
            _handler.OnMessage("historicalNews");
        }

        public void historicalNewsEnd(int requestId, bool hasMore)
        {
            _handler.OnMessage("historicalNewsEnd");
        }

        public void historicalTicks(int reqId, HistoricalTick[] ticks, bool done)
        {
            _handler.OnMessage("historicalTicks");
        }

        public void historicalTicksBidAsk(int reqId, HistoricalTickBidAsk[] ticks, bool done)
        {
            _handler.OnMessage("historicalTicksBidAsk");
        }

        public void historicalTicksLast(int reqId, HistoricalTickLast[] ticks, bool done)
        {
            _handler.OnMessage("historicalTicksLast");
        }

        public void managedAccounts(string accountsList)
        {
            _handler.OnMessage("managedAccounts");
        }

        public void marketDataType(int reqId, int marketDataType)
        {
            _handler.OnMessage("marketDataType");
        }

        public void marketRule(int marketRuleId, PriceIncrement[] priceIncrements)
        {
            _handler.OnMessage("marketRule");
        }

        public void mktDepthExchanges(DepthMktDataDescription[] depthMktDataDescriptions)
        {
            _handler.OnMessage("mktDepthExchanges");
        }

        public void newsArticle(int requestId, int articleType, string articleText)
        {
            _handler.OnMessage("newsArticle");
        }

        public void newsProviders(NewsProvider[] newsProviders)
        {
            _handler.OnMessage("newsProviders");
        }

        public void nextValidId(int orderId)
        {
            _handler.OnMessage("nextValidId");
        }

        public void openOrder(int orderId, Contract contract, Order order, OrderState orderState)
        {
            _handler.OnMessage("openOrder");
        }

        public void openOrderEnd()
        {
            _handler.OnMessage("openOrderEnd");
        }

        public void orderBound(long orderId, int apiClientId, int apiOrderId)
        {
            _handler.OnMessage("orderBound");
        }

        public void orderStatus(int orderId, string status, double filled, double remaining, double avgFillPrice, int permId, int parentId, double lastFillPrice, int clientId, string whyHeld, double mktCapPrice)
        {
            _handler.OnMessage("orderStatus");
        }

        public void pnl(int reqId, double dailyPnL, double unrealizedPnL, double realizedPnL)
        {
            _handler.OnMessage("pnl");
        }

        public void pnlSingle(int reqId, int pos, double dailyPnL, double unrealizedPnL, double realizedPnL, double value)
        {
            _handler.OnMessage("pnlSingle");
        }

        public void position(string account, Contract contract, double pos, double avgCost)
        {
            _handler.OnMessage("position");
        }

        public void positionEnd()
        {
            _handler.OnMessage("positionEnd");
        }

        public void positionMulti(int requestId, string account, string modelCode, Contract contract, double pos, double avgCost)
        {
            _handler.OnMessage("positionMulti");
        }

        public void positionMultiEnd(int requestId)
        {
            _handler.OnMessage("positionMultiEnd");
        }

        public void realtimeBar(int reqId, long date, double open, double high, double low, double close, long volume, double WAP, int count)
        {
            _handler.OnMessage("realtimeBar");
        }

        public void receiveFA(int faDataType, string faXmlData)
        {
            _handler.OnMessage("receiveFA");
        }

        public void rerouteMktDataReq(int reqId, int conId, string exchange)
        {
            _handler.OnMessage("rerouteMktDataReq");
        }

        public void rerouteMktDepthReq(int reqId, int conId, string exchange)
        {
            _handler.OnMessage("rerouteMktDepthReq");
        }

        public void scannerData(int reqId, int rank, ContractDetails contractDetails, string distance, string benchmark, string projection, string legsStr)
        {
            _handler.OnMessage("scannerData");
        }

        public void scannerDataEnd(int reqId)
        {
            _handler.OnMessage("scannerDataEnd");
        }

        public void scannerParameters(string xml)
        {
            _handler.OnMessage("scannerParameters");
        }

        public void securityDefinitionOptionParameter(int reqId, string exchange, int underlyingConId, string tradingClass, string multiplier, HashSet<string> expirations, HashSet<double> strikes)
        {
            _handler.OnMessage("securityDefinitionOptionParameter");
        }

        public void securityDefinitionOptionParameterEnd(int reqId)
        {
            _handler.OnMessage("securityDefinitionOptionParameterEnd");
        }

        public void smartComponents(int reqId, Dictionary<int, KeyValuePair<string, char>> theMap)
        {
            _handler.OnMessage("smartComponents");
        }

        public void softDollarTiers(int reqId, SoftDollarTier[] tiers)
        {
            _handler.OnMessage("softDollarTiers");
        }

        public void symbolSamples(int reqId, ContractDescription[] contractDescriptions)
        {
            _handler.OnMessage("symbolSamples");
        }

        public void tickByTickAllLast(int reqId, int tickType, long time, double price, int size, TickAttribLast tickAttriblast, string exchange, string specialConditions)
        {
            _handler.OnMessage("tickByTickAllLast");
        }

        public void tickByTickBidAsk(int reqId, long time, double bidPrice, double askPrice, int bidSize, int askSize, TickAttribBidAsk tickAttribBidAsk)
        {
            _handler.OnMessage("tickByTickBidAsk");
        }

        public void tickByTickMidPoint(int reqId, long time, double midPoint)
        {
            _handler.OnMessage("tickByTickMidPoint");
        }

        public void tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints, double impliedFuture, int holdDays, string futureLastTradeDate, double dividendImpact, double dividendsToLastTradeDate)
        {
            _handler.OnMessage("tickEFP");
        }

        public void tickGeneric(int tickerId, int field, double value)
        {
            _handler.OnMessage("tickGeneric");
        }

        public void tickNews(int tickerId, long timeStamp, string providerCode, string articleId, string headline, string extraData)
        {
            _handler.OnMessage("tickNews");
        }

        public void tickOptionComputation(int tickerId, int field, double impliedVolatility, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice)
        {
            _handler.OnMessage("tickOptionComputation");
        }

        public void tickPrice(int tickerId, int field, double price, TickAttrib attribs)
        {
            _handler.OnMessage("tickPrice");
        }

        public void tickReqParams(int tickerId, double minTick, string bboExchange, int snapshotPermissions)
        {
            _handler.OnMessage("tickReqParams");
        }

        public void tickSize(int tickerId, int field, int size)
        {
            _handler.OnMessage("tickSize");
        }

        public void tickSnapshotEnd(int tickerId)
        {
            _handler.OnMessage("tickSnapshotEnd");
        }

        public void tickString(int tickerId, int field, string value)
        {
            _handler.OnMessage("tickString");
        }

        public void updateAccountTime(string timestamp)
        {
            _handler.OnMessage("updateAccountTime");
        }

        public void updateAccountValue(string key, string value, string currency, string accountName)
        {
            _handler.OnMessage("updateAccountValue");
        }

        public void updateMktDepth(int tickerId, int position, int operation, int side, double price, int size)
        {
            _handler.OnMessage("updateMktDepth");
        }

        public void updateMktDepthL2(int tickerId, int position, string marketMaker, int operation, int side, double price, int size, bool isSmartDepth)
        {
            _handler.OnMessage("updateMktDepthL2");
        }

        public void updateNewsBulletin(int msgId, int msgType, string message, string origExchange)
        {
            _handler.OnMessage("updateNewsBulletin");
        }

        public void updatePortfolio(Contract contract, double position, double marketPrice, double marketValue, double averageCost, double unrealizedPNL, double realizedPNL, string accountName)
        {
            _handler.OnMessage("updatePortfolio");
        }

        public void verifyAndAuthCompleted(bool isSuccessful, string errorText)
        {
            _handler.OnMessage("verifyAndAuthCompleted");
        }

        public void verifyAndAuthMessageAPI(string apiData, string xyzChallenge)
        {
            _handler.OnMessage("verifyAndAuthMessageAPI");
        }

        public void verifyCompleted(bool isSuccessful, string errorText)
        {
            _handler.OnMessage("verifyCompleted");
        }

        public void verifyMessageAPI(string apiData)
        {
            _handler.OnMessage("verifyMessageAPI");
        }
    }
}
