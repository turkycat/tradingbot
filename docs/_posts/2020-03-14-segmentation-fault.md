---
layout: default
title: segmentation fault
date: 2020-03-14 14:10:58 -0700
imageroot: /images/d0
category: March 2020
permalink: /tradingbot
redirect_from: /tradingbot/2020/Mar/segmentation-fault
---

# day 0: march 14th, 2020

I'm using this project and blog to keep track of my learning and development process. This is the first day, where I spent most of it setting up this blog.

### project objective

develop trading software that consistently and efficiently generates profits from day trading. day trading is fun and enjoyable (when you're right), but also is very time consuming and very emotional. My experience with software engineering tells me that software should be better and more effective at executing a winning strategy consistently.

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

 These vary greatly depending on the timeframe being used. For example, the following image represents just over four hours of time data for the SPDR S&P500 ETF yesterday, March 13th 2020.

![March 13, 2020]({{site.baseurl}}{{imageroot}}/d0/march-13-2020-minute.png)

While the next image represents the same period of time, but on a 5 minute timeframe.

![March 13, 2020]({{site.baseurl}}{{imageroot}}/d0/march-13-2020-5minute.png)  
the same overall pattern can be observed, but it is important to note that when it comes to historical data, TradingView (and most data sources, as I currently understand it) only save OHLC data. However, when observing real time data, hundreds of data points may be processed per candle, with only a single 4-point set of data (`price_data`) retained after the time period ends.

The takeaway here is that there may be behavioral differences with a software application that is developed using historical data and ran on live data. I'll table this for now, but it may be useful to restrict decision trees to only be executed at the close of a candle

### initial setup

Using the 5+ year old youtube video as a starting point with R, I decided to go against the actual steps he laid out, and try to set things up with the latest versions. We will see if this comes back to bite me in the ass eventually.

**R - version 3.6.3**  
https://cran.r-project.org/

**Rtools - version 35**  
https://cran.rstudio.com/bin/windows/Rtools/

**RStudio - version 1.2.5033**  
https://rstudio.com/products/rstudio/download/#download

In RStudio, I installed a ton of packages (using the console). I saved a script in `<root>\scratchpad\package_install.R` that I will keep up to date with the necessary packages. Run this R file and it should automatically download everything you need. The basics though, seem to be devtools and quantstrat (https://github.com/braverock/quantstrat)

##### useful commands in R

You can use `?<command>` in the console to get help on the command

```r
View(<object>)
head(<object>)
tail(<object>)
```

`// to be continued`