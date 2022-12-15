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
using OpenQA.Selenium.Interactions;

namespace AutomationLitres.Pages
{
  public class LitresSearchPage
  {
    private IWebDriver driver;
    private WebDriverWait wait;
    private string xPathRequestHref = "//*[@id='__next']/div[1]/div[2]/div/div/div[3]/div/div/div[1]/div/div[2]/a";
    private string xPathFrame = "//*[@id='iframe_flock_data_provider']";

    private string xPathSeries = "//*[@id='__next']/div[1]/div[2]/div/div/div[2]/div[1]/ul/li[6]";

    public LitresSearchPage(IWebDriver driver, WebDriverWait wait)
    {
      this.driver = driver;
      this.wait = wait;
    }
    public void SwitchToSearchFrame()
    {
      driver.SwitchTo().Frame(driver.FindElement(By.XPath(xPathFrame)));
    }
    public LitresBookPage GetHrefToTargetPage()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathRequestHref)));
      driver.FindElement(By.XPath(xPathRequestHref)).Click();
      return new LitresBookPage(driver, wait);
    }

    public LitresSeriesPage GetHrefToSeriesPage()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathSeries)));
      driver.FindElement(By.XPath(xPathSeries)).Click();
      return new LitresSeriesPage(driver, wait);
    }

  }
}
