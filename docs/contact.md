---
layout: default
title: contact
permalink: /contact/
---

<br/>
<h1>{{ page.title }}</h1>
&nbsp;&nbsp;<a onclick="window.history.back();" href="javascript:void(0);"><< go back</a>
<br/>

<hr>
  
![Site Owner]({{ site.images | append: "/jesse.png" | relative_url }}){:height="250" width="270"}

{{site.owner}}  
email: [{{site.email}}](mailto:{{site.email}})  
linkedin: [{{site.linkedin_url}}](https://www.{{site.linkedin_url}})  
twitter: [@{{site.twitter_username}}](https://twitter.com/{{site.twitter_username}})

# about the blog

This site was developed using Jekyll & Ruby for Github Pages. It is intended for entertainment and educational purposes only.

This project will use [technical analysis](https://www.investopedia.com/terms/t/technicalanalysis.asp) concepts and machine learning to develop a winning trading strategy that can be executed, without emotion, by software.

The project root can be found at: [{{site.github.repository_nwo}}]({{ site.github.repository_nwo }})
