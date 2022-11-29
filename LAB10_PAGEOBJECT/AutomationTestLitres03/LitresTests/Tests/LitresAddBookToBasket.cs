using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using AutomationLitres;
using System.IO;

namespace LitresTests.Tests
{
  [TestFixture]
  public class LitresAddBookToBasket
  {
    ChromeDriver driverChrome;
    ChromeOptions options;
    LitresHomePage homepage;
    LitresSearchPage searchpage;
    LitresBookPage bookpage;
    UserBookPage userbookpage;

    public string bookName = "Игра Престолов";

    [OneTimeSetUp]
    public void InitializeContext()
    {
      options = new ChromeOptions();
      options.AddArguments("user-data-dir=C:/Users/User/AppData/Local/Google/Chrome/User Data");

      //options.AddArguments("--headless");
      options.AddArguments("--window-size=1920,1080");

      driverChrome = new ChromeDriver(options);
      homepage = new LitresHomePage(driverChrome);

      Thread.Sleep(3000);
      homepage.OpenTargetPage();
      Thread.Sleep(9000);
      homepage.FindSearchFieldInput().SendKeys(bookName);
      Thread.Sleep(3000);
      searchpage = homepage.GoToSearchResultsPage();
      Thread.Sleep(3000);
      bookpage = searchpage.GetHrefToTargetPage();
      Thread.Sleep(3000);
    }
    [Test]
    public void BookCanBeCorrectlyAddedToBasket()
    {
      bookpage.FindAddToBasketButton().Click();
      userbookpage = bookpage.GoToUserBookPage();
      userbookpage.FindUserBookBasketPanel().Click();
      Assert.True(userbookpage.GetBookNameFromBasket() != null);
    }
    
    [OneTimeTearDown]
    public void close_Browser()
    {
      driverChrome.Close();
      driverChrome.Quit();
    }
  }
}
