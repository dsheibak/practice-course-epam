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
  public class LitresSeriesPage
  {
    private IWebDriver driver;
    private WebDriverWait wait;

    private string xPathSeriesTitle = "//div[@class='Series-module__numberOfBooks_2tsWr']";

    public LitresSeriesPage(IWebDriver driver, WebDriverWait wait)
    {
      this.driver = driver;
      this.wait = wait;
    }

    public bool FindTitlesOnSeriesPage()
    {
      bool result = false;

      ReadOnlyCollection<IWebElement> titles = driver.FindElements(By.XPath(xPathSeriesTitle));

      foreach (var titl in titles)
      {
        if (titl.Text.Contains("Серия"))
        {
          result = true;
          return result;
        }
      }

      return result;
    }

  }
}
