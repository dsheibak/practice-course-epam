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
  public class PopularAuthorsPage
  {
    private IWebDriver driverChrome;
    private WebDriverWait wait;
    private string xPathSelectedPopluarAuthor = "//a[@href='/author/viktor-pelevin/']";
    public PopularAuthorsPage(IWebDriver driver)
    {
      driverChrome = driver;
      wait = new WebDriverWait(driverChrome, TimeSpan.FromSeconds(4000));
    }
    public SelectedPopularAuthorPage FindPopularAuthor()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathSelectedPopluarAuthor)));
      driverChrome.FindElement(By.XPath(xPathSelectedPopluarAuthor)).Click();
      return new SelectedPopularAuthorPage(driverChrome);
    }
  }
}
