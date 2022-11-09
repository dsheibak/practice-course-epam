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
using SeleniumExtras;

namespace Hardcore
{
  public class GenerateEmailPage
  {
    private IWebDriver driverChrome;
    private WebDriverWait wait;
    private string xPathGenerateEmailButton = "//*[@id='listeliens']/a[1]/div[@class='txtlien']";
    private string xPathGeneratedEmailElement = "//*[@id='egen']";
    private string xPathCheckInboxButton = "/html/body/div/div[2]/main/div/div[2]/div/div/div[2]/button[2]";
    private string xPathSendTotalCost = "//*[@id='mail']/div/div/table/tbody/tr[2]/td/table/tbody/tr[2]/td[2]/h3";
    public GenerateEmailPage(IWebDriver driver)
    {
      driverChrome = driver;
      wait = new WebDriverWait(driverChrome, TimeSpan.FromSeconds(9000));
    }

    public IWebElement FindGereyageEmailButton()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathGenerateEmailButton)));
      return driverChrome.FindElement(By.XPath(xPathGenerateEmailButton));
    }

    public IWebElement FindCheckInboxButton()
    {
      wait.Until(drv => drv.FindElement(By.XPath(xPathCheckInboxButton)));
      return driverChrome.FindElement(By.XPath(xPathCheckInboxButton));
    }

    public string GetGeneratedEmail()
    {
      return driverChrome.FindElement(By.XPath(xPathGeneratedEmailElement)).Text;  
    }

    public void SwitchBackToVMCalculator()
    {
      driverChrome.SwitchTo().Window(driverChrome.WindowHandles.First());
    }

    public string GetEmailTotalCost()
    {
      driverChrome.SwitchTo().Frame(driverChrome.FindElement(By.XPath("//iframe[@id='ifmail']")));

      return driverChrome.FindElement(By.XPath(xPathSendTotalCost)).Text;
    }



  }
}
