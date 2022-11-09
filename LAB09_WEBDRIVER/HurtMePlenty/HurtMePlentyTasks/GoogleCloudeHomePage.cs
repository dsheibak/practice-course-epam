using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;

namespace HurtMePlenty
{
  public class GoogleCloudeHomePage
  {
    private IWebDriver driverChrome;
    private WebDriverWait wait;
    private string targetUrl = "https://cloud.google.com/";

    private string xPathSearchButton = "//div[@class='devsite-searchbox']/input[@class='devsite-search-field devsite-search-query']";
    private string xPathSearchFieldInput = "//input[@aria-label='Search']"; 

    public GoogleCloudeHomePage(IWebDriver driver)
    {
      driverChrome = driver;
      wait = new WebDriverWait(driverChrome, TimeSpan.FromSeconds(1000));
    }
    public void OpenTargetPage()
    {
      driverChrome.Navigate().GoToUrl(targetUrl);
    }
    public IWebElement FindSearchButton()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathSearchButton)));
      return driverChrome.FindElement(By.XPath(xPathSearchButton));
    }
    public IWebElement SearchFormPage()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathSearchFieldInput)));
      return driverChrome.FindElement(By.XPath(xPathSearchFieldInput));
    }
    public GoogleCloudSearchPage GetSearchResultPage()
    {
      driverChrome.FindElement(By.XPath(xPathSearchFieldInput)).SendKeys(Keys.Enter);
      return new GoogleCloudSearchPage(driverChrome);
    }
  }
}
