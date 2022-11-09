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
  public class UserBookPage
  {
    private IWebDriver driverChrome;
    private WebDriverWait wait;

    private string xPathUserBookListTitle = "//*[@id='my-books-list__bookshelf']/a";
    private string xPathBookTitle = "//a[@title='Игра престолов']";

    public UserBookPage(IWebDriver driver)
    {
      driverChrome = driver;
      wait = new WebDriverWait(driverChrome, TimeSpan.FromSeconds(1000));
    }

    public IWebElement FindUserBookListTitle()
    {
      return wait.Until(drv => drv.FindElement(By.XPath(xPathUserBookListTitle)));
    }

    public IWebElement GetBookNameFromUserReadedList()
    {
      return wait.Until(drv => drv.FindElement(By.XPath(xPathBookTitle)));
    }

  }
}
