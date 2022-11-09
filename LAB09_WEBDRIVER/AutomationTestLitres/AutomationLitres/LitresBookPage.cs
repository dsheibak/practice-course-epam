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
    private string xPathMarkAsReadButton = "//*[@id='page-wrap']/div[3]/div[2]/div/div[1]/div/div[2]/div[8]/div/div[@class='mark_as_read-btn']";
    private string xPathMakeAsReadActivateLabel = "//*[@id='page-wrap']/div[3]/div[2]/div/div[1]/div/div[2]/div[8]/div/div[@class='mark_as_read-btn' and text()='Прочитана']";
    private string xPathUserBookPageButton = "//*[@id='litres_header']/header/div[2]/span/div/a";
    public LitresBookPage(IWebDriver driver)
    {
      driverChrome = driver;
      wait = new WebDriverWait(driverChrome, TimeSpan.FromSeconds(1000));
    }
    public IWebElement FindMarkAsReadButton()
    {
      return wait.Until(drv => drv.FindElement(By.XPath(xPathMarkAsReadButton)));
    }

    public string GetButtonMarkAsReadStatus()
    {
      return wait.Until(drv => drv.FindElement(By.XPath(xPathMakeAsReadActivateLabel))).Text;
    }

    public UserBookPage GoToUserBookPage()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathUserBookPageButton))).Click();
      return new UserBookPage(driverChrome);
    }

  }
}
