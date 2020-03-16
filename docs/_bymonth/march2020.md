---
title: March 2020
month: 03
year: 2020
---

<h1>{{ page.title }}</h1>

{% comment %}
*
*   dates are given in the following format: YYYY-MM-DD HH:MM:SS TZ
*     example: 2020-02-15 2:10:58 -0700
*
{% endcomment %}

<ul>
{% for post in site.posts %}
  {% assign postmonth = post.date | date: "%m" | remove: '0' | plus: 0 %}
  {% assign postyear = post.date | date: "%Y" | plus: 0 %}
  {% if page.month == postmonth and page.year == postyear %}
    <li>
      {% assign postday = post.date | date: "%d" %}
      {% assign postmonth = post.date | date: "%M"%}
      <a href="{{ post.url }}">{{ postmonth | append: " " | append: postday | append: ' : ' | append: post.title }}</a><br/>
      {% assign extract = post.content | split: "<!--start-->" | last | split: "<!--end-->" | first %}
      {{ extract | strip_html }}
    </li>
  {% endif %}
{% endfor %}
</ul>