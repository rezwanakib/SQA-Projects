using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleProject.Framework.Pages;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    internal class WishlistAddingTest : BaseTest
    {
        private ProductPage productPage = new();

        string expectedTitle = "Ladily. Home page title";
        string expectedWishlistText = "1 new item have been added to your wishlist";

        [Test]
        public void TestWishlist()
        {
            Assert.AreEqual(productPage.GetMainPageTitle(),expectedTitle, "Main page is not loaded");
            productPage.ClickProductButton();
            productPage.ClickAddToWishlistButton();
            Assert.That(productPage.GetWishlistAddedText().Contains(expectedWishlistText), "Wishlist adding failed");
        }

       
    }
}
