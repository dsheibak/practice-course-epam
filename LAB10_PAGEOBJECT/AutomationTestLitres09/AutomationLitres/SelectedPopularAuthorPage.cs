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
    private string xPathSunscribeButton = "//*[@id='subscribe_button']";
    private string xPathSubscribedButton = "//*[@id='subscribe_button' and text()='Отписаться от автора']";
    public SelectedPopularAuthorPage(IWebDriver driver)
    {
      driverChrome = driver;
      wait = new WebDriverWait(driverChrome, TimeSpan.FromSeconds(4000));
    }
    public IWebElement FindSubscribeButton()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathSunscribeButton)));
      return driverChrome.FindElement(By.XPath(xPathSunscribeButton));
    }
    public string GetSubscribeButtonStatus()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathSubscribedButton)));
      return wait.Until(drv => drv.FindElement(By.XPath(xPathSubscribedButton))).Text;
    }
  }
}
