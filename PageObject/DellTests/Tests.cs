using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;
using DellPages;
using DellPages.Pages;
using DellPages.PageBuilders;
using System.Collections.Generic;
using System.Linq;

namespace DellTests
{
    public class Tests : IDisposable
    {
        private readonly IWebDriver _driver;
        public Tests()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("no-sandbox");
            _driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(150));
        }

        public void Dispose()
        {
            _driver?.Quit();
        }


        [Theory]
        [InlineData("https://www.dell.com/en-us/shop/cty/pdp/spd/xps-15-9500-laptop/xn9500cto210s")]
        [InlineData("https://www.dell.com/en-us/shop/dell-laptops/alienware-m17-r3-gaming-laptop/spd/alienware-m17-r3-laptop/wnm17r312sbf")]
        //[InlineData("https://www.dell.com/en-us/shop/dell-ultrasharp-32-8k-monitor-up3218k/apd/210-alez/monitors-monitor-accessories")]
        //[InlineData("https://www.dell.com/en-us/shop/dell-laptops/new-dell-g7-17-gaming-laptop/spd/g-series-17-7700-laptop/gn7700ehyyh")]
        //[InlineData("https://www.dell.com/en-us/shop/new-alienware-low-profile-rgb-mechanical-gaming-keyboard-aw510k/apd/580-aimo/pc-accessories")]
        //[InlineData("https://www.dell.com/en-us/shop/desktop-computers/new-inspiron-24-5000-black-all-in-one-with-bipod-stand/spd/inspiron-24-5400-aio/na5400ekphh")]
        //[InlineData("https://www.dell.com/en-us/shop/desktop-computers/inspiron-desktop/spd/inspiron-3880-desktop/nd3880eejks")]
        //[InlineData("https://www.dell.com/en-us/shop/dell-urban-backpack-15/apd/460-bbyl/carrying-cases")]
        //[InlineData("https://www.dell.com/en-us/shop/kensington-ld4650p-usb-c-universal-dock-with-k-fob-smart-lock-docking-station-usb-c-gige-north-america/apd/aa659274/pc-accessories")]
        //[InlineData("https://www.dell.com/en-us/shop/dell-32-curved-gaming-monitor-s3220dgf/apd/210-atyt/monitors-monitor-accessories")]
        //[InlineData("https://www.dell.com/en-us/shop/pny-nvidia-quadro-rtx-6000-graphics-card-24-gb-gddr6-pcie-30-x16-4-x-displayport-usb-c/apd/aa413562/graphic-video-cards")]
        //[InlineData("https://www.dell.com/en-us/shop/samsung-98-inch-tv-2020-qled-8k-ultra-hd-hdr10-smart-tv-q900-series-qn98q900rbfxza/apd/ab168598/tv-home-theater")]
        public void AddingToCartTest(string link)
        {
            ProductPage product = new ProductPageBuilder(_driver).SetProductLink(link).Build();
            product.Open();
            product.AcceptCookies();

            double productPagePrice = product.Price;
            string productPageTitle = product.Title;

            double addedToCartPageSubtotal = product.AddToCart().Subtotal;

            Assert.Equal(productPagePrice, addedToCartPageSubtotal);

            CartPage cart = new CartPage(_driver);
            cart.Open();
            List<Product> cartProducts = cart.Products.ToList();

            Assert.Single(cartProducts);
            Assert.Equal(1, cartProducts[0].Count);
            Assert.Equal(productPageTitle, cartProducts[0].Title);
            Assert.Equal(productPagePrice, cartProducts[0].Subtotal);
        }

        [Theory]
        [ClassData(typeof(RemoveFromCartTestData))]
        public void RemoveFromCartTest(IEnumerable<string> links)
        {
            foreach(var link in links)
            {
                ProductPage product = new ProductPageBuilder(_driver).SetProductLink(link).Build();
                product.Open();
                product.AcceptCookies();

                product.AddToCart();
            }


            CartPage cart = new CartPage(_driver);
            cart.Open();
            List<Product> cartProducts = cart.Products.ToList();

            Assert.Equal(links.Count(), cartProducts.Count);

            for(int i = links.Count(); i > 0; i--)
            {
                Assert.Equal(cartProducts.Sum(x => x.Subtotal), cart.Subtotal);

                cartProducts[0].Remove();
                cartProducts = cart.Products.ToList();
                Assert.Equal(i, cartProducts.Count);
            }

            cartProducts = cart.Products.ToList();
            Assert.Empty(cartProducts);
        }
    }
}
