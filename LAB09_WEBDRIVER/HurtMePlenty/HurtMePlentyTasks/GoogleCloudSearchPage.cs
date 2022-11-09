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
  public class GoogleCloudSearchPage
  {
    private IWebDriver driverChrome;
    private WebDriverWait wait;

    private string xPathRequestHref = "//div[@class='gs-title']/a[1]";
    public GoogleCloudSearchPage(IWebDriver driver)
    {
      driverChrome = driver;
      wait = new WebDriverWait(driverChrome, TimeSpan.FromSeconds(1000));
    }
    public GoogleCloudFormPage GetHrefToTargetPage()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathRequestHref)));
      driverChrome.FindElement(By.XPath(xPathRequestHref)).Click();
      return new GoogleCloudFormPage(driverChrome);  
    }
  }
}
