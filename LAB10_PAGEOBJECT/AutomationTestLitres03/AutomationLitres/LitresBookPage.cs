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
  public class LitresBookPage
  {
    private IWebDriver driverChrome;
    private WebDriverWait wait;
    private string xPathUserBookPageButton = "//*[@id='litres_header']/header/div[2]/span/div/a";
    private string xPathAddToBasketButton = "//button[@data-action='addbasket']";

    public LitresBookPage(IWebDriver driver)
    {
      driverChrome = driver;
      wait = new WebDriverWait(driverChrome, TimeSpan.FromSeconds(3000));
    }

    public IWebElement FindAddToBasketButton()
    {
      return wait.Until(drv => drv.FindElement(By.XPath(xPathAddToBasketButton)));
    }

    public UserBookPage GoToUserBookPage()
    {
       wait.Until(drv => drv.FindElement(By.XPath(xPathUserBookPageButton))).Click();
       return new UserBookPage(driverChrome);
    }
  }
}
