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
  public class LitresSubscriptionPopularAuthor
  {
    ChromeDriver driverChrome;
    ChromeOptions options;
    LitresHomePage homepage;
    PopularAuthorsPage popularAuthors;
    SelectedPopularAuthorPage selectedPopularAuthor;
    private string expectedSubscribeButtonStatus = "ОТПИСАТЬСЯ ОТ АВТОРА";

    [OneTimeSetUp]
    public void InitializeContext()
    {
      options = new ChromeOptions();
      options.AddArguments("user-data-dir=C:/Users/User/AppData/Local/Google/Chrome/User Data");
      //options.AddArguments("--headless");
      options.AddArguments("--window-size=1920,1080");

      driverChrome = new ChromeDriver(options);
      homepage = new LitresHomePage(driverChrome);
      homepage.OpenTargetPage();
      Thread.Sleep(9000);

      homepage.FindMenuElementAnother().Click();
      Thread.Sleep(4000);
      popularAuthors = homepage.GoToPopularAuthorsPage();
      Thread.Sleep(4000);
      selectedPopularAuthor = popularAuthors.FindPopularAuthor();
      Thread.Sleep(4000);
    }
    [Test]
    public void UserCanBeCorrectlySubscribedToPopularAuthor()
    {
      selectedPopularAuthor.FindSubscribeButton().Click();
      Thread.Sleep(4000);
      Assert.True(selectedPopularAuthor.GetSubscribeButtonStatus().Equals(expectedSubscribeButtonStatus));
    }
    
    [OneTimeTearDown]
    public void closeBrowser()
    {
      driverChrome.Close();
      driverChrome.Quit();
    }
  }
}
