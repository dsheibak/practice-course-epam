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

namespace BringItOn
{
  public class PublishPastePage
  {

    private IWebDriver driverChrome;
    private WebDriverWait wait;
    public PublishPastePage(IWebDriver driver)
    {
      driverChrome = driver;
      wait = new WebDriverWait(driverChrome, TimeSpan.FromSeconds(2000));
    }

    public string GetSelectedProgrammingLanguage()
    {
      return wait.Until(drv => drv.FindElement(By.XPath("//div[@class='left']/a[@class='btn -small h_800']"))).Text;
    }

    public List<string> GetPastCode()
    {
      wait.Until(drv => drv.FindElement(By.XPath("//div[@class='de1']")));
      List<string> pastedCode = new List<string>();
      List<IWebElement> list = new List<IWebElement>();
      list = driverChrome.FindElements(By.XPath("//div[@class='de1']")).ToList();
      foreach (var element in list)
      {
        pastedCode.Add(element.Text);
      }
      return pastedCode;
    }

    public string GetPageTitle()
    {
      return wait.Until(drv => drv.FindElement(By.XPath("//h1[contains(text(),'how to gain dominance among developers')]"))).Text;
    }

  }
}
