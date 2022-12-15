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

namespace AutomationLitres
{
  public class SelectedPopularAuthorPage
  {
    private IWebDriver driverChrome;
    private WebDriverWait wait;
    private string xPathSubscribeButton = "//div[@class='Author-module__subscribeAction_vCXGI']//button";
    private string xPathSubscribedButton = "//div[text()='Вы подписаны']";
    public SelectedPopularAuthorPage(IWebDriver driver, WebDriverWait wait)
    {
      driverChrome = driver;
      this.wait = wait;
    }
    public IWebElement FindSubscribeButton()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathSubscribeButton)));
      return driverChrome.FindElement(By.XPath(xPathSubscribeButton));
    }
    public string GetSubscribeButtonStatus()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathSubscribedButton)));
      return wait.Until(drv => drv.FindElement(By.XPath(xPathSubscribedButton))).Text;
    }
  }
}
