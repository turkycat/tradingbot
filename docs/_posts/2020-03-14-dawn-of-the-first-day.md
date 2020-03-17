---
title: dawn of the first day
date: 2020-03-14 14:10:58 -0700
category: mar2020
imageroot: /images/d0
permalink: /
---

<!--start-->
This blog has been set up to keep track of the development process of automated stock trading software. I spent the vast majority of the day (and the next) setting up this blog, so while there is some background here as to the inspiration, the real work will begin on the next entry.

### project objective

develop trading software that consistently and efficiently generates profits from day trading. day trading is fun and enjoyable (when you're right), but also is very time consuming and very emotional. My experience with software engineering tells me that software should be better and more effective at executing a winning strategy consistently.
<!--end-->

### Initial resources:  
- [http://reddit.com/r/algotrading](http://reddit.com/r/algotrading)  
- youtube video on R (super old):  
[https://www.youtube.com/watch?v=61_F2fcvrsw](https://www.youtube.com/watch?v=61_F2fcvrsw)  
- API and resources available from TD Ameritrade and TradingView.  

It seems R and Python are heavily preferred in the community. I've used R in college stats courses, but that was more than 5 years ago. I know that it is preferred for running statistical models and from what I've read on algotrading, it seems to have existing libraries and models that will help evaulate strategies.

TradingView also provides a scripting language called Pine that allows you to write little scripts (each called a "study") that run once every historical time point, but once again each time a new "live" price is received during the current time frame. Here is an example of a Pine script from the [TradingView Wiki](https://www.tradingview.com/wiki/Example_of_an_Indicator_in_Pine)

```c
study("MACD")
fast = 12, slow = 26
fastMA = ema(close, fast)
slowMA = ema(close, slow)
macd = fastMA - slowMA
signal = sma(macd, 9)
plot(macd, color=blue)
plot(signal, color=orange)
```

It's important to note that a historical point of data only consists of "OHLC" data, meaning "open, high, low, close". This means that there are four data points saved per entry in time (or for our purposes, per candle). 

Thinking like a computer scientist, we can define a generic representation of data that is agnostic of the timeframe being used (this is C, not Pine):

```c
typedef double price;

struct 
{
  price open;
  price high;
  price low;
  price close;
} candle;

candle
openCandle(price open)
{
  candle data;
  data.open = open;
  data.low = open;
  data.high = open;

  return data;
}

void
updateCandle(candle &data, price current)
{
  if(current > data.high) data.high = current;
  if(current < data.low) data.low = current;
}

void
closeCandle(candle &data, price close)
{
  data.close = close;
}
```

The point of all this is that strategy may vary greatly depending on the timeframe being used, even for a human. For example, the following image represents just over four hours of time data for the SPDR S&P500 ETF yesterday, March 13th 2020.

![March 13, 2020]({{ page.imageroot | append: "/march-13-2020-minute.png" | relative_url}})

While the next image represents the same period of time, but on a 5 minute timeframe.

![March 13, 2020]({{ page.imageroot | append: "/march-13-2020-5minute.png" | relative_url}})  

the same overall pattern can be observed, but it's clear from these two pictures that the perceived pattern changes drastically depending on the timeframe.

TradingView (and most data sources) only saves OHLC datah. Yet when observing real time data hundreds of data points may be processed per candle. The takeaway here is that there may be behavioral differences with a software application that is developed using historical data and ran on live data. I'll table this for now, but it may be useful to restrict decision trees to only be executed at the close of a candle.
