---
title: excuse me, why are you breathing?
date: 2020-03-21 8:20:23 -0700
category: mar2020
imageroot: /images/d1
permalink: /
---

<!--start-->
Well this week has been absolutely insane. COVID-19 is taking over the world and the entire country is shutting down little by little. I've been working from home myself for the past three weeks or so, but more and more drastic measures are being put in place daily to try and normalize the curve. Just today california imposed a statewide "shelter-in-place" policy, which is essentially a curfew.

Not to let this derail the focus of this blog, but context is everything. sometime this week the homepage of tradingview began charting the worldwide spread of the virus... let's just say the the technicals say COVID-19 is a strong "BUY"
<!--end-->

![covid19]({{ page.imageroot | append: "/covid19.png" | relative_url}})

while the S&P500 is looking *a bit* like a sell signal:

![anp]({{ page.imageroot | append: "/snp.png" | relative_url}})

### but I'm from the future and the DOW is over 90,000 lol  

Fair enough. The volatility kept me insanely busy this past week, today gives me time to focus on this!  

I've been passively reading some content from reddit and other resources, and it seems that a lot of people prefer Python for their algotrading solutions. I'm not personally too big a fan of Python, but it may be necessary for me to consider this approach and determine it's advantages. For now, I'm going to be looking into Interactive Brokers web API- as they are highly rated by Barrons, have paper trading accounts, and have a [pretty comprehensive looking guide to their API](http://interactivebrokers.github.io/tws-api/index.html) available online.

## resources referenced in this post:
- [Interactive Brokers API Guide](http://interactivebrokers.github.io/tws-api/index.html)
- [Interactive Brokers API Download](http://interactivebrokers.github.io/)
- [Interactive Brokers API Source](http://interactivebrokers.github.io/) (404 without approval)

### IB preview

Interactive Brokers trading station, like their web API, goes by the name "Trader Workstation" or TWS. The introduction gives a few limitions as a warning. Most notably, the message limit:

> The TWS is designed to accept up to fifty messages per second coming from the client side. Anything coming from the client application to the TWS counts as a message (i.e. requesting data, placing orders, requesting your portfolio... etc.). This limitation is applied to all connected clients in the sense were all connected client applications to the same instance of TWS combined cannot exceed this number. On the other hand, there are no limits on the amount of messages the TWS can send to the client application.

In addition, paper trading accounts have the following additional limitations:

>
- No support for some order types including: VWAP, Auction, RFQ, and Pegged to Market.
- Fills are simulated from the top of the book; no deep book access.
- Limited combo and EFP trading.
- Stops and other complex order types are always simulated in paper trading; this may result in slightly different behavior from a production account.
- Penny trading for US Options is not supported. You will be able to submit the order but it will not receive a penny fill.
- The trade simulator will reject the remainder of any exchange-directed market order that partially executes. This may or may not match behavior of a real-world exchange.   Market orders received while there is no quote on the opposite side will be held until the market data arrives (i.e. until the first partial fill).
- Mutual Fund trading is not supported in a Paper Trader Account.

### TWS API Connections

Applications written for TWS cannot authenticate themselves. According to their guide, socket connections must be enabled from an online session one time, but that same account must be logged in in order for the API to connect to the server. It appears that the connection may be maintained for one week or less, as the servers are reset on Sunday evening and require authentication to reconnect.  

### API install and source

okay, so I followed the introduction's guide to enable socket connection and followed the link to the web API's download page at [http://interactivebrokers.github.io/](http://interactivebrokers.github.io/). From digging in to the terms a bit further, I can see that the source code is located at [https://github.com/InteractiveBrokers/tws-api](https://github.com/InteractiveBrokers/tws-api), but if you click this link you'll likely get a 404. This is because the project is private. You have to request and submit a license agreement in order to view or clone the project. The [contribution page](http://interactivebrokers.github.io/api_software_contribute.html) will have the most up-to-date details, but at the time of writing this post a button on the page was set to a `mailto:` link with the following parameters. If you're interested in seeing the source, you may follow these steps as well.

Email: `opensource@interactivebrokers.com`  
Subject: `License Agreement Request`  
Body: `I am requesting a license agreement.`  

okay, so after enabling the connections in TWS and installing the MSI from the download page listed above, I located the sample projects in my install location (default: `C:\TWS API\`). The C# Sample app has the following appearance, with a large number of source files to work with:

![tws sample app]({{ page.imageroot | append: "/tws-sample.png" | relative_url}})

I was able to get the sample app connected after putting in my host and port in the corner. if you are using a paper trading account, you'll need to set the port to 7497 or change the port number in the TWS application.

configuration:
```
host: localhost \ 127.0.0.1
port: 7496 (live) \ 7497 (paper)
```

I was able to retrieve my paper trading account detauls on the "Account Info" tab after connecting! (I made $160.11) with a successful trade on Friday, testing this account out.

![tws sample app \ account data]({{ page.imageroot | append: "/account.png" | relative_url}})

There is a ton of code to explore in this sample, so I'll leave you to it! I'll be back soon with more

`// to be continued`