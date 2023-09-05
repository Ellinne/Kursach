<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Slider.aspx.cs" Inherits="GallerySite.Slider" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="~/Slider.css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div class="slider-container">
  <div class="slider">
    <div class="slides">
      <div id="slides__1" class="slide">
        <span class="slide__text"><img src="images/Берег_моря_со_скалой_пейзаж.jpg" /></span>
        <a class="slide__prev" href="#slides__4" title="Next"></a>
        <a class="slide__next" href="#slides__2" title="Next"></a>
      </div>
      <div id="slides__2" class="slide">
        <span class="slide__text">Petrova</span>
        <a class="slide__prev" href="#slides__1" title="Prev"></a>
        <a class="slide__next" href="#slides__3" title="Next"></a>
      </div>
      <div id="slides__3" class="slide">
        <span class="slide__text">3</span>
        <a class="slide__prev" href="#slides__2" title="Prev"></a>
        <a class="slide__next" href="#slides__4" title="Next"></a>
      </div>
      <div id="slides__4" class="slide">
        <span class="slide__text">4</span>
        <a class="slide__prev" href="#slides__3" title="Prev"></a>
        <a class="slide__next" href="#slides__1" title="Prev"></a>
      </div>
    </div>
    <div class="slider__nav">
      <a class="slider__navlink" href="#slides__1"></a>
      <a class="slider__navlink" href="#slides__2"></a>
      <a class="slider__navlink" href="#slides__3"></a>
      <a class="slider__navlink" href="#slides__4"></a>
    </div>
  </div>
</div>

<a href="https://alvarotrigo.com/fullPage/blog/create-a-slider-with-just-CSS/" target="_blank" class="read-article">
  Read the article 👉
</a>
</body>
</html>
