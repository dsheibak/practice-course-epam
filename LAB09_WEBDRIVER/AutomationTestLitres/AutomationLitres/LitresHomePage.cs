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


namespace AutomationLitres
{
  public class LitresHomePage
  {
    private IWebDriver driverChrome;
    private WebDriverWait wait;
    private string targetUrl = "https://www.litres.ru/";

    private string xPathSearchButton = "//form[@action='/pages/rmd_search/']/div/button";
    private string xPathSearchFieldInput = "//form[@action='/pages/rmd_search/']/div/input";

    public LitresHomePage(IWebDriver driver)
    {
      driverChrome = driver;
      wait = new WebDriverWait(driverChrome, TimeSpan.FromSeconds(1000));
    }
    public void OpenTargetPage()
    {
      driverChrome.Navigate().GoToUrl(targetUrl);
    }
    public IWebElement FindSearchFieldInput()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathSearchFieldInput)));
      return driverChrome.FindElement(By.XPath(xPathSearchFieldInput));
    }
    public LitresSearchPage GoToSearchResultsPage()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathSearchButton))).Click();
      return new LitresSearchPage(driverChrome);
    }

  }
}
