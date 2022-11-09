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
  public class UnreadedBookCanBeCorrectlyAddedToReadedListTest
  {
    ChromeDriver driverChrome;
    ChromeOptions options;
    LitresHomePage homepage;
    LitresSearchPage searchpage;
    LitresBookPage bookpage;
    UserBookPage userbookpage;

    public string bookName = "Игра Престолов";
    public string expectedStatus = "ПРОЧИТАНА";

    [OneTimeSetUp]
    public void InitializeContext()
    {
      options = new ChromeOptions();
      options.AddArguments("user-data-dir=C:/Users/User/AppData/Local/Google/Chrome/User Data");
      driverChrome = new ChromeDriver(options);
      homepage = new LitresHomePage(driverChrome);

      homepage.OpenTargetPage();
      homepage.FindSearchFieldInput().SendKeys(bookName);
      searchpage = homepage.GoToSearchResultsPage();
      bookpage = searchpage.GetHrefToTargetPage();
      bookpage.FindMarkAsReadButton().Click();
    }
    [Test]
    public void UnreadedBookCanBeCorrectlyMarkedAsReadedByByttonClick()
    { 
      Assert.True(bookpage.GetButtonMarkAsReadStatus().Equals(expectedStatus));
    }
    [Test]
    public void UserBookListIsFilledByBookMarkedAsReaded()
    {
      userbookpage = bookpage.GoToUserBookPage();
      userbookpage.FindUserBookListTitle().Click();
      Assert.True(userbookpage.GetBookNameFromUserReadedList() != null);
    }
    [OneTimeTearDown]
    public void close_Browser()
    {
      driverChrome.Close();
      driverChrome.Quit();
    }
  }
}
