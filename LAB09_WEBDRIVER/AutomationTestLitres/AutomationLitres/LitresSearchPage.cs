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


namespace AutomationLitres
{
  public class LitresSearchPage
  {
    private IWebDriver driverChrome;
    private WebDriverWait wait;
    private string xPathRequestHref = "//*[@id='__next']/div[1]/div[2]/div/div/div[3]/div/div/div[1]/div/div[2]/a/span";
    public LitresSearchPage(IWebDriver driver)
    {
      driverChrome = driver;
      wait = new WebDriverWait(driverChrome, TimeSpan.FromSeconds(1000));
    }
    public void SwitchToSearchFrame()
    {
      driverChrome.SwitchTo().Frame(driverChrome.FindElement(By.XPath("//*[@id='iframe_flock_data_provider']")));
    }
    public LitresBookPage GetHrefToTargetPage()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathRequestHref)));
      driverChrome.FindElement(By.XPath(xPathRequestHref)).Click();
      return new LitresBookPage(driverChrome);
    }
  }
}
