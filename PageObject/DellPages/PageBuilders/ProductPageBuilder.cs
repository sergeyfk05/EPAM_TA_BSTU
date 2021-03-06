﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using DellPages.Pages;

namespace DellPages.PageBuilders
{
    public class ProductPageBuilder
    {
        private IWebDriver _driver;
        private ProductPage _product;
        public ProductPageBuilder(IWebDriver driver)
        {
            _driver = driver;
            _product = new ProductPage(driver);
        }

        public ProductPageBuilder SetProductLink(string link)
        {
            _product.Link = link;
            return this;
        }

        public ProductPage Build()
        {
            return _product;
        }
    }
}
